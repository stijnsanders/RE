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
        private object? listdata;
        private String? listurl;

        public override void Start()
        {
            base.Start();
            webc = new WebClient();
            listdata = null;
            listurl = null;
            //TODO: sequence of lpList?
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
                        lpOutput.Emit(webc.UploadString(textBox1.Text, s));
                }
                else
                {
                    listdata = Data;
                    var s = listdata.ToString();
                    if (s != null && listurl != null) lpOutput.Emit(webc.UploadString(listurl, s));
                }
        }

        private void lpList_Signal(RELinkPoint Sender, object? Data)
        {
            listurl = Data?.ToString();
            var s = listdata?.ToString();
            if (webc != null && listurl != null && s != null) lpOutput.Emit(webc.UploadString(listurl, s));
        }

        protected override void DisconnectAll()
        {
            //replacing: base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }

    }
}