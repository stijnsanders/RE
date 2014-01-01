using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RE;

namespace RERegex
{
    [RE.REItem("split","Split","Split text using a regular expression")]
    public partial class RESplit : REBaseRegExItem
    {
        public RESplit()
        {
            InitializeComponent();
        }

        private bool IsSplitting;
        private string SplitData;
        private MatchCollection SplitList;
        private int SplitIndex;
        private int SplitPosition;

        public override void Start()
        {
            base.Start();
            IsSplitting = false;
        }

        public override void Stop()
        {
            base.Stop();
            if (IsSplitting)
            {
                SplitData = null;
                SplitList = null;
            }
        }

        void lpRegExInput_Signal(RELinkPoint Sender, object Data)
        {
            if (lpInbetweens.IsConnected || lpMatches.IsConnected)
            {
                if (IsSplitting)
                    throw new EReUnexpectedInputException(lpRegExInput);
                else
                {
                    SplitIndex = 0;
                    SplitPosition = 0;
                    SplitData = Data.ToString();
                    SplitList = ItemRegex.Matches(SplitData);
                    IsSplitting = true;
                    if(lpInbetweens.IsConnected)
                        NextInbetween();
                    else
                        NextMatch();
                }
            }
        }

        void lpInbetweens_Signal(RELinkPoint Sender, object Data)
        {
            if (lpMatches.IsConnected)
                NextMatch();
            else
            {
                Advance();
                NextInbetween();
            }
        }

        void lpMatches_Signal(RELinkPoint Sender, object Data)
        {
            if (lpInbetweens.IsConnected)
                NextInbetween();
            else
                NextMatch();
        }

        private void NextInbetween()
        {
            if(IsSplitting)
                if (SplitIndex < SplitList.Count)
                {
                    int npos = SplitList[SplitIndex].Index;
                    lpInbetweens.Emit(SplitData.Substring(SplitPosition, npos - SplitPosition), true);
                    SplitPosition = npos;
                }
                else
                {
                    //trailing bit
                    lpInbetweens.Emit(SplitData.Substring(SplitPosition));//till end
                    SplitPosition = SplitData.Length;
                    IsSplitting = false;
                }
        }

        private void NextMatch()
        {
            if (SplitIndex < SplitList.Count)
            {
                //string Data=SplitData.Substring(...
                lpMatches.Emit(SplitList[SplitIndex].Value, true);
                Advance();
            }
            else
                IsSplitting = false;
        }

        private void Advance()
        {
            //assert SplitIndex < SplitList.Count
            SplitPosition = SplitList[SplitIndex].Index + SplitList[SplitIndex].Length;
            SplitIndex++;
        }
    }
}

