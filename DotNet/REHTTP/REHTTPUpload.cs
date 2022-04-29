using System;
using System.Net;
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

        private WebClient? webc;
        private string? method;
        private object? listdata;
        private string? listurl;
        private string contenttype;

        public override void Start()
        {
            base.Start();
            webc = new WebClient();
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
                {
                    var s = Data.ToString();
                    if (s != null)
                    {
                        if (contenttype != "") webc.Headers.Add(HttpRequestHeader.ContentType, contenttype);
                        webc.Encoding = System.Text.Encoding.UTF8;
                        lpOutput.Emit(webc.UploadString(txtURL.Text, method, s));
                        if (webc.ResponseHeaders != null) lpHeaders.Emit(webc.ResponseHeaders);
                    }
                }
                else
                {
                    listdata = Data;
                    var s = listdata.ToString();
                    if (s != null && listurl != null)
                    {
                        if (contenttype != "") webc.Headers.Add(HttpRequestHeader.ContentType, contenttype);
                        webc.Encoding = System.Text.Encoding.UTF8;
                        lpOutput.Emit(webc.UploadString(listurl, s));
                        if (webc.ResponseHeaders != null) lpHeaders.Emit(webc.ResponseHeaders);
                    }
                }
        }

        private void lpList_Signal(RELinkPoint Sender, object? Data)
        {
            listurl = Data?.ToString();
            var s = listdata?.ToString();
            if (webc != null && listurl != null && s != null)
            {
                if (contenttype != "") webc.Headers.Add(HttpRequestHeader.ContentType, contenttype);
                webc.Encoding = System.Text.Encoding.UTF8;
                lpOutput.Emit(webc.UploadString(listurl, s));
                if (webc.ResponseHeaders != null) lpHeaders.Emit(webc.ResponseHeaders);
            }
        }

        protected override void DisconnectAll()
        {
            //replacing: base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }
    }
}