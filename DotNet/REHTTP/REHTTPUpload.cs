using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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

        private WebClient webc;
        private object listdata;
        private String listurl;

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
            if (lpList.ConnectedTo == null)
                lpOutput.Emit(webc.UploadString(textBox1.Text, Data.ToString()));
            else
            {
                listdata = Data;
                if (listurl != null) lpOutput.Emit(webc.UploadString(listurl, listdata.ToString()));
            }
        }

        private void lpList_Signal(RELinkPoint Sender, object Data)
        {
            listurl = Data.ToString();
            if (listdata != null) lpOutput.Emit(webc.UploadString(listurl, listdata.ToString()));
        }

        protected override void DisconnectAll()
        {
            //replacing: base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }

    }
}
