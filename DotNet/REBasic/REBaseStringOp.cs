using System;
using RE;

namespace REBasic
{
    public /*abstract*/ partial class REBaseStringOp : REBaseItem
    {
        private RELinkPointPatch patch;

        public REBaseStringOp()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        private void lpInput_Signal(RE.RELinkPoint Sender, object Data)
        {
            var d = Data.ToString();
            if (d != null)
                lpOutput.Emit(Perform(d));
        }

        protected virtual string Perform(string Data)
        {
            //inheritants do something to Data (and not inherit this!)
            throw new NotImplementedException("No perform implemented on REBaseStringOp inheritant");
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}

