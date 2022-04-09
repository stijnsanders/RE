using System.Text;
using RE;

namespace REMulti
{
    [REItem("merge","Merge","Merge a multiple input into a singular output")]
    public partial class REMerge : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REMerge()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        private StringBuilder? _mergedata;
        private bool _registered;

        public override void Start()
        {
            base.Start();
            _mergedata = null;
            _registered = false;
        }

        public override void Stop()
        {
            _mergedata = null;
            base.Stop();
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (!_registered)
            {
                //register for sequence end
                lpOutput.Emit(lpOutput);
                _registered = true;
            }
            if (_mergedata == null) _mergedata = new StringBuilder();
            _mergedata.Append(Data.ToString());
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            _registered = false;
            if (_mergedata != null)
                lpOutput.Emit(_mergedata.ToString());
            _mergedata = null;
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}

