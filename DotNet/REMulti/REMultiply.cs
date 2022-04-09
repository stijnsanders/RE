using System;
using System.Collections.Generic;
using System.Drawing;
using RE;

namespace REMulti
{
    [REItem("multiply", "Multiply", "Multiplies a single input")]
    public partial class REMultiply : RE.REBaseItem
    {
        private List<RELinkPoint> outputs = new();

        public REMultiply()
        {
            InitializeComponent();
            OutputCount = 2;
        }

        private int OutputCount
        {
            set
            {
                SuspendLayout();
                for (int i = outputs.Count; i < value; i++)
                {
                    RELinkPoint lp = new RELinkPoint();
                    panItemClient.Controls.Add(lp);
                    lp.Caption = String.Format("output {0}", i + 1);
                    lp.Key = String.Format("output{0}", i + 1);
                    lp.Direction = RELinkPointDirection.Output;
                    lp.Bounds = new Rectangle(63, 26 + i * 20, 57, 16);
                    lp.Signal += new RELinkPointSignal(lp_Signal);
                    outputs.Add(lp);
                }
                for (int i = outputs.Count - 1; i >= value; i--)
                {
                    outputs[i].ConnectedTo = null;
                    panItemClient.Controls.Remove(outputs[i]);
                    outputs.RemoveAt(i);
                }
                ResumeLayout();
                Invalidate(false);//some border-line get garbled?
                Height = 50 + outputs.Count * 20;
            }
            get
            {
                return outputs.Count;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            OutputCount = OutputCount + 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (OutputCount > 2) OutputCount = OutputCount - 1;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("outputs", OutputCount.ToString());
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            OutputCount = Int32.Parse(Element.GetAttribute("outputs"));
            base.LoadFromXml(Element);
        }

        private bool inputdone;
        private int waitingcount;
        private int workingcount;
        private RELinkPoint? inputSeqEnd;

        public override void Start()
        {
            base.Start();
            waitingcount = 0;
            if (lpInput.ConnectedTo != null)
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
            inputSeqEnd = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (inputdone)
            {
                inputdone = false;
                if (inputSeqEnd != null)
                    lpInput.Emit(inputSeqEnd);
            }
            if (Data != null)
            {
                if (workingcount != 0)
                    throw new EReUnexpectedInputException(lpInput);
                foreach (RELinkPoint lp in outputs)
                    if (lp.ConnectedTo != null)
                        lp.Resume(Data);
                workingcount = waitingcount;
                if (lpInput.ConnectedTo != null)
                    lpInput.ConnectedTo.Suspend();
            }
        }

        void lp_Signal(RELinkPoint Sender, object? Data)
        {
            if (!inputdone)
            {
                Sender.Suspend();
                workingcount--;
                if (workingcount == 0 && lpInput.ConnectedTo != null)
                    lpInput.ConnectedTo.Resume();
            }
        }

        void inputSeqEnd_Signal(RELinkPoint Sender, object? Data)
        {
            inputdone = true;
            foreach (RELinkPoint lp in outputs)
                if (lp.ConnectedTo != null)
                    lp.Resume();
        }

    }
}