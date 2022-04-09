using System.Collections.Generic;
using RE;

namespace REMulti
{
    [REItem("invert","Invert","Invert the items of a multiple input.")]
    public partial class REInvert : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REInvert()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        private List<object>? _data;
        private int _index;
        private bool _registered;

        public override void Start()
        {
            base.Start();
            _data = null;
            _index = -1;
            _registered = false;
        }

        public override void Stop()
        {
            _data = null;
            base.Stop();
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (_index == -1)
            {
                if (!_registered)
                {
                    _registered = true;
                    //register to get sequence end signal
                    lpOutput.Emit(lpOutput);
                }
                if (_data == null) _data = new List<object>();
                _data.Add(Data);
            }
            else
                throw new EReUnexpectedInputException(lpInput);
        }

        private void lpOutput_Signal(RELinkPoint Sender, object? Data)
        {
            if (_data != null)
            {
                if (_index == -1) _index = _data.Count;
                _index--;
                if (_index != -1) lpOutput.Emit(_data[_index], true);
            }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}

