using System.Net.Http;
using System.Threading.Tasks;
using RE;

namespace REHTTP
{
    [REItem("httpupload", "HTTP Upload", "Post data to a URL")]
    public partial class REHTTPUpload : REBaseItem
    {
        private RELinkPointPatch patch;

        public REHTTPUpload()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
            contenttype = ""; //default, see Start
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            cbMethod.Text = Element.GetAttribute("method");
            txtURL.Text = Element.GetAttribute("url");
            txtContentType.Text = Element.GetAttribute("contenttype");
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("method", cbMethod.Text);
            Element.SetAttribute("url", txtURL.Text);
            Element.SetAttribute("contenttype", txtContentType.Text);
        }

        private HttpClient? webc;
        private Task<string>? webd;
        private string? method;
        private object? listdata;
        private string? listurl;
        private string contenttype;

        public override void Start()
        {
            base.Start();
            webc = new HttpClient();
            webd = null;
            method = cbMethod.Text;
            listdata = null;
            listurl = null;
            contenttype = txtContentType.Text;
        }

        public override void Stop()
        {
            base.Stop();
            webc = null;
            listdata = null;
            listurl = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (webc != null)
                if (lpList.ConnectedTo == null)
                    DoRequest(txtURL.Text, Data);
                else
                {
                    listdata = Data;
                    if (listdata != null && listurl != null)
                    {
                        DoRequest(listurl, listdata);
                        listurl = null;
                        listdata = null;
                    }
                }
        }

        private void lpList_Signal(RELinkPoint Sender, object? Data)
        {
            listurl = Data?.ToString();
            if (webc != null && listurl != null && listdata != null)
            {
                DoRequest(listurl, listdata);
                listurl = null;
                listdata = null;
            }
        }

        private void DoRequest(string Url, object Data)
        {
            if (webc == null)
                throw new EReException("Unexpected DoRequest outside of Start/Stop");
            var r = new HttpRequestMessage(new HttpMethod(method ?? "POST"), Url);
            if (contenttype != "") r.Headers.Add("Content-Type", contenttype);
            if (Data != null)
                if (Data is string)
                    r.Content = new StringContent(Data as string ?? "");
                else
                    /*
                    if (Data is Stream)
                        r.Content = new StreamContent(Data as Stream);
                    else
                    //TODO: more?
                    */
                    r.Content = new StringContent(Data.ToString() ?? "");//throw?
            var m = webc.Send(r);
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

        protected override void DisconnectAll()
        {
            //replacing: base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }
    }
}