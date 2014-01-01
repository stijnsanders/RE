using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmlselectnodes","SelectNodes","Perform SelectNodes")]
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

        private string xquery;
        //private XmlNodeList list;
        private System.Collections.IEnumerator list;

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
            if (list.MoveNext())
                lpOutput.Emit(list.Current, true);
            else
                list = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (list != null) throw new EReUnexpectedInputException(lpInput);
            list = REXML.AsXmlNode(Data).SelectNodes(xquery).GetEnumerator();
            SendNext();
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            SendNext();
        }

    }
}
