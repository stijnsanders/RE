using System.Net.Http;
using System.Threading.Tasks;
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
            txtURL.Text = Element.GetAttribute("url");
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("url", txtURL.Text);
        }

        private HttpClient? webc;
        private Task<string>? webd;

        public override void Start()
        {
            base.Start();
            webc = new HttpClient();
            webd = null;
            if (lpList.ConnectedTo == null)
                DoRequest(txtURL.Text);
        }

        public override void Stop()
        {
            base.Stop();
            webc = null;
            webd = null;
        }

        private void lpList_Signal(RELinkPoint Sender, object? Data)
        {
            if (webc != null)
            {
                var s = Data?.ToString();
                if (s != null)
                    DoRequest(s);
            }
        }

        private void DoRequest(string Url)
        {
            if (webc == null)
                throw new EReException("Unexpected DoRequest outside of Start/Stop");
            var m = webc.Send(new HttpRequestMessage(HttpMethod.Get, Url));
            var c = m.Content.ReadAsStringAsync();
            if (lpHeaders.ConnectedTo == null)
            {
                c.Wait();
                lpOutput.Emit(c.Result);
            }
            else
            {
                if (lpOutput.ConnectedTo == null)
                    lpHeaders.Emit(m.Headers.ToString());
                else
                {
                    lpHeaders.Emit(m.Headers.ToString(), true);
                    webd = c;
                }
            }
        }

        private void lpHeaders_Signal(RELinkPoint Sender, object Data)
        {
            if (webd == null)
                throw new EReException("Unexpected return on Output");
            var d = webd;
            webd = null;
            d.Wait();
            lpOutput.Emit(d.Result);
        }
    }
}