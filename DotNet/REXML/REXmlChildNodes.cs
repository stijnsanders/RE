using RE;

namespace REXML
{
    [REItem("xmlchildnodes","ChildNodes","Enumerate child nodes")]
    public partial class REXmlChildNodes : REBaseItem
    {
        public REXmlChildNodes()
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
            if (Data != null)
            {
                list = REXML.AsXmlNode(Data)?.ChildNodes.GetEnumerator();
                SendNext();
            }
        }

        private void lpOutput_Signal(RELinkPoint Sender, object? Data)
        {
            SendNext();
        }
    }
}
