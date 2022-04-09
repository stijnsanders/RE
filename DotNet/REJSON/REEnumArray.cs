using RE;
using System.Text.Json;

namespace REJSON
{
    [REItem("jsonenumarray","JSON enumerate array","Enumerate JSON array elements")]
    public partial class REEnumArray : REBaseItem
    {
        public REEnumArray()
        {
            InitializeComponent();
        }

        private System.Collections.IEnumerator? list;

        public override void Start()
        {
            base.Start();
            list = null;
        }

        public override void Stop()
        {
            base.Stop();
            list = null;
        }

        private void SendNext()
        {
            if (list!=null && list.MoveNext())
                lpOutput.Emit(list.Current, true);
            else
                list = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            JsonElement? e = Data as JsonElement?;
            if (e.HasValue)
            {
                list = e.Value.EnumerateArray();
                SendNext();
            }
        }

        private void lpOutput_Signal(RELinkPoint Sender, object? Data)
        {
            SendNext();
        }
    }
}
