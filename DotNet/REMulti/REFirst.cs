using RE;

namespace REMulti
{
    [REItem("first", "First", "Output only the first item of a sequence")]
    public partial class REFirst : REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REFirst()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        private bool gotItem;
        private object? firstItem;
        private bool indexSeqEndRegistered;
        private RELinkPoint? indexSeqEnd;

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
            firstItem = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (!gotItem)
            {
                gotItem = true;
                firstItem = Data;
            }
            if (!indexSeqEndRegistered)
            {
                indexSeqEndRegistered = true;
                if (indexSeqEnd != null)
                    Sender.Emit(indexSeqEnd);
            }
        }

        private void indexSeqEnd_Signal(RELinkPoint Sender, object? Data)
        {
            indexSeqEndRegistered = false;
            if (gotItem)
            {
                if (firstItem != null)
                    lpOutput.Emit(firstItem);
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
