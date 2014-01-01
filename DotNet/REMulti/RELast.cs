using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("last","Last","Output only the last item of a sequence")]
    public partial class RELast : REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public RELast()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        private bool gotItem;
        private object lastItem;
        private bool indexSeqEndRegistered;
        private RELinkPoint indexSeqEnd;

        public override void Start()
        {
            base.Start();
            gotItem = false;
            indexSeqEndRegistered = false;
            indexSeqEnd = new RELinkPoint("index_sequence_end", this);
            indexSeqEnd.Signal += new RELinkPointSignal(indexSeqEnd_Signal);
        }

        public override void Stop()
        {
            base.Stop();
            lastItem = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            gotItem = true;
            lastItem = Data;
            if (!indexSeqEndRegistered)
            {
                indexSeqEndRegistered = true;
                Sender.Emit(indexSeqEnd);
            }
        }

        private void indexSeqEnd_Signal(RELinkPoint Sender, object Data)
        {
            indexSeqEndRegistered = false;
            if (gotItem)
            {
                lpOutput.Emit(lastItem);
                gotItem = false;
            }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}
