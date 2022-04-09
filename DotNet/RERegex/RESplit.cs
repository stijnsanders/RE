using System.Text.RegularExpressions;
using RE;

namespace RERegex
{
    [RE.REItem("split", "Split", "Split text using a regular expression")]
    public partial class RESplit : REBaseRegExItem
    {
        public RESplit()
        {
            InitializeComponent();
        }

        private bool IsSplitting;
        private string? SplitData;
        private MatchCollection? SplitList;
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
            if (lpInbetweens.ConnectedTo != null || lpMatches.ConnectedTo != null)
            {
                if (IsSplitting)
                    throw new EReUnexpectedInputException(lpRegExInput);
                else
                {
                    SplitIndex = 0;
                    SplitPosition = 0;
                    SplitData = Data.ToString();
                    if (SplitData != null)
                        SplitList = ItemRegex.Matches(SplitData);
                    IsSplitting = true;
                    if (lpInbetweens.ConnectedTo != null)
                        NextInbetween();
                    else
                        NextMatch();
                }
            }
        }

        void lpInbetweens_Signal(RELinkPoint Sender, object Data)
        {
            if (lpMatches.ConnectedTo != null)
                NextMatch();
            else
            {
                Advance();
                NextInbetween();
            }
        }

        void lpMatches_Signal(RELinkPoint Sender, object Data)
        {
            if (lpInbetweens.ConnectedTo != null)
                NextInbetween();
            else
                NextMatch();
        }

        private void NextInbetween()
        {
            if (IsSplitting && SplitData != null && SplitList != null)
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
            if (SplitList != null && SplitIndex < SplitList.Count)
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
            if (SplitList != null)
            {
                //assert SplitIndex < SplitList.Count
                SplitPosition = SplitList[SplitIndex].Index + SplitList[SplitIndex].Length;
                SplitIndex++;
            }
        }
    }
}