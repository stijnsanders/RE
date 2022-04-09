using System.Net;
using RE;

namespace REHTTP
{
    [REItem("httpdownload", "HTTP Download", "Get data from a URL")]
    public partial class REHTTPDownload : REBaseItem
    {
        public REHTTPDownload()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            textBox1.Text = Element.GetAttribute("url");
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("url", textBox1.Text);
        }

        private WebClient? webc;

        public override void Start()
        {
            base.Start();
            webc = new WebClient();
            if (lpList.ConnectedTo == null)
            {
                webc.Encoding = System.Text.Encoding.UTF8;
                lpOutput.Emit(webc.DownloadString(textBox1.Text));
            }
        }

        public override void Stop()
        {
            base.Stop();
            webc = null;
        }

        private void lpList_Signal(RELinkPoint Sender, object? Data)
        {
            if (webc != null)
            {
                var s = Data?.ToString();
                if(s!=null)
                lpOutput.Emit(webc.DownloadString(s));
            }
        }

    }
}