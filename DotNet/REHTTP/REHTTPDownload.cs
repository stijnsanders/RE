using System.Net.Http;
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

        public override async void Start()
        {
            base.Start();
            webc = new HttpClient();
            if (lpList.ConnectedTo == null)
            {
                var m = webc.Send(new HttpRequestMessage(HttpMethod.Get, txtURL.Text));
                lpOutput.Emit(await m.Content.ReadAsStringAsync());
                lpHeaders.Emit(m.Headers.ToString());
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
                if (s != null)
                {
                    var m = webc.Send(new HttpRequestMessage(HttpMethod.Get, s));
                    var t = m.Content.ReadAsStringAsync();
                    t.Wait();
                    lpOutput.Emit(t.Result);
                    lpHeaders.Emit(m.Headers.ToString());
                }
            }
        }

    }
}