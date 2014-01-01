using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace REBasic
{
    [RE.REItem("splitbyeol", "Split by EOL", "Split text by end-of-line codes")]
    public partial class RESplitByEOL : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public RESplitByEOL()
        {
            InitializeComponent();
            patch = new RE.RELinkPointPatch(lpInput, lpOutput);
        }

        private bool IsSplitting;
        private string[] SplitList;
        private int SplitIndex;

        public override void Start()
        {
            base.Start();
            IsSplitting = false;
        }

        public override void Stop()
        {
            base.Stop();
            if (IsSplitting) SplitList = null;
        }

        private void lpInput_Signal(RE.RELinkPoint Sender, object Data)
        {
            if (IsSplitting)
                throw new RE.EReUnexpectedInputException(lpInput);
            if (lpOutput.IsConnected)
            {
                SplitIndex = 0;
                string[] EOLs=new string[1];
                EOLs[0]="\r\n";
                SplitList = Data.ToString().Split(EOLs, StringSplitOptions.None);
                IsSplitting = true;
                NextItem();
            }
        }

        private void NextItem()
        {
            //assert IsSplitting
            if (SplitIndex < SplitList.Length)
            {
                lpOutput.Emit(SplitList[SplitIndex],true);
                SplitIndex++;
            }
            else
                IsSplitting = false;
        }

        private void lpOutput_Signal(RE.RELinkPoint Sender, object Data)
        {
            if (IsSplitting)
                NextItem();
            else
                throw new RE.EReUnexpectedInputException(lpOutput);
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }


    }
}
