using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RE;

namespace RERegex
{
    [RE.REItem("groups", "Groups", "Using a regular expression to separate text into match groups")]
    public partial class REGroups : REBaseRegExItem
    {
        private List<RELinkPoint> outputs = new();

        public REGroups()
        {
            InitializeComponent();
            UpdateGroups();
        }

        void txtRegExPattern_TextChanged(object? sender, EventArgs e)
        {
            UpdateGroups();
        }

        private void UpdateGroups()
        {
            try
            {
                string[] g = ItemRegex.GetGroupNames();
                SuspendLayout();
                int i = 0;
                while (i < g.Length)
                {
                    if (i == outputs.Count)
                    {
                        RELinkPoint lp = new RELinkPoint();
                        panItemClient.Controls.Add(lp);
                        lp.Direction = RELinkPointDirection.Output;
                        lp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        lp.Bounds = new Rectangle(ClientSize.Width - 72, 53 + i * 20, 60, 16);
                        lp.Signal += new RELinkPointSignal(lpMatch_Signal);
                        outputs.Add(lp);
                    }
                    outputs[i].Caption = g[i];
                    outputs[i].Key = String.Format("group{0}", i + 1);
                    i++;
                }
                while (i < outputs.Count)
                {
                    outputs[i].ConnectedTo = null;
                    panItemClient.Controls.Remove(outputs[i]);
                    outputs.RemoveAt(i);
                }
                ResumeLayout();
                Invalidate(false);//some border-line get garbled?
                //i = 79 + outputs.Count * 20;
                i = 79 + g.Length * 20;
                if (i > MinimumSize.Height)
                {
                    MaximumSize = new Size(MaximumSize.Width, i);
                    Height = i;
                    MinimumSize = new Size(MinimumSize.Width, i);
                }
                else
                {
                    MinimumSize = new Size(MinimumSize.Width, i);
                    Height = i;
                    MaximumSize = new Size(MaximumSize.Width, i);
                }
            }
            catch
            {
                //silent
            }
        }

        private bool IsGrouping;
        private string? GroupData;
        private MatchCollection? GroupList;
        private int GroupIndex;
        private int GroupPosition;
        private bool inputdone;
        private int waitingcount;
        private int workingcount;
        private RELinkPoint? inputSeqEnd;

        public override void Start()
        {
            base.Start();
            IsGrouping = false;
            base.Start();
            waitingcount = 0;
            if (lpInbetweens.ConnectedTo != null)
            {
                waitingcount++;
                lpInbetweens.Suspend();
            }
            if (lpRegExInput.ConnectedTo != null)
                foreach (RELinkPoint lp in outputs)
                    if (lp.ConnectedTo != null)
                    {
                        waitingcount++;
                        lp.Suspend();
                    }
            workingcount = 0;
            inputdone = true;
            inputSeqEnd = new RELinkPoint("input_sequence_end", this);
            inputSeqEnd.Signal += new RELinkPointSignal(inputSeqEnd_Signal);
        }

        public override void Stop()
        {
            base.Stop();
            if (IsGrouping)
            {
                GroupData = null;
                GroupList = null;
            }
            inputSeqEnd = null;
        }

        void lpRegExInput_Signal(RELinkPoint Sender, object Data)
        {
            if (inputdone)
            {
                inputdone = false;
                if (inputSeqEnd != null)
                    lpRegExInput.Emit(inputSeqEnd);
            }
            if (Data != null && waitingcount != 0)
            {
                if (IsGrouping || workingcount != 0)
                    throw new EReUnexpectedInputException(lpRegExInput);
                else
                {
                    GroupIndex = 0;
                    GroupPosition = 0;
                    GroupData = Data.ToString();
                    if (GroupData != null)
                        GroupList = ItemRegex.Matches(GroupData);
                    lpRegExInput.Suspend();
                    IsGrouping = true;
                    NextGroup();
                }
            }
        }

        private void lpMatch_Signal(RELinkPoint Sender, object? Data)
        {
            if (!inputdone)
                if (workingcount == 0)
                {
                    throw new EReUnexpectedInputException(Sender);
                }
                else
                {
                    Sender.Suspend();
                    workingcount--;
                    if (workingcount == 0)
                        if (IsGrouping)
                            NextGroup();
                        else
                            lpRegExInput.Resume();
                }
        }

        void inputSeqEnd_Signal(RELinkPoint Sender, object? Data)
        {
            inputdone = true;
            foreach (RELinkPoint lp in outputs)
                if (lp.ConnectedTo != null)
                    lp.Resume();
            if (lpInbetweens.ConnectedTo != null)
                lpInbetweens.Resume();
        }

        private void NextGroup()
        {
            if (IsGrouping && GroupData != null && GroupList != null)
                if (GroupIndex < GroupList.Count)
                {
                    Match m = GroupList[GroupIndex];
                    if (lpInbetweens.ConnectedTo != null)
                        lpInbetweens.Resume(GroupData.Substring(GroupPosition, m.Index - GroupPosition));
                    for (int i = 0; i < outputs.Count; i++)
                        if (outputs[i].ConnectedTo != null)
                            outputs[i].Resume(m.Groups[i].Value);
                    workingcount = waitingcount;
                    //advance
                    GroupPosition = m.Index + m.Length;
                    GroupIndex++;
                }
                else
                {
                    //trailing bit
                    if (lpInbetweens.ConnectedTo != null)
                    {
                        lpInbetweens.Resume(GroupData.Substring(GroupPosition));
                        workingcount = 1;
                    }
                    else
                        lpRegExInput.Resume();
                    GroupPosition = GroupData.Length;
                    IsGrouping = false;
                }
        }
    }
}