using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace REBasic
{
    public /*abstract*/ partial class REBaseStringOp : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REBaseStringOp()
        {
            InitializeComponent();
            patch = new RE.RELinkPointPatch(lpInput, lpOutput);
        }

        private void lpInput_Signal(RE.RELinkPoint Sender, object Data)
        {
            lpOutput.Emit(Perform(Data.ToString()));
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

