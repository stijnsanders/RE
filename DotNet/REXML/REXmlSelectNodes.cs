using RE;

namespace REXML
{
    [REItem("xmlselectnodes", "SelectNodes", "Perform SelectNodes")]
    public partial class REXmlSelectNodes : REBaseItem
    {
        public REXmlSelectNodes()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            textBox1.Text = Element.GetAttribute("query");
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("query", textBox1.Text);
        }

        private string? xquery;
        //private XmlNodeList list;
        private System.Collections.IEnumerator? list;

        public override void Start()
        {
            base.Start();
            list = null;
            xquery = textBox1.Text;
        }

        public override void Stop()
        {
            base.Stop();
            list = null;
        }

        private void SendNext()
        {
            if (list != null && list.MoveNext())
                lpOutput.Emit(list.Current, true);
            else
                list = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            if (list != null) throw new EReUnexpectedInputException(lpInput);
            if (Data != null && xquery != null)
            {
                var l = REXML.AsXmlNode(Data)?.SelectNodes(xquery);
                if (l != null)
                    list = l.GetEnumerator();
            }
            SendNext();
        }

        private void lpOutput_Signal(RELinkPoint Sender, object? Data)
        {
            SendNext();
        }

    }
}