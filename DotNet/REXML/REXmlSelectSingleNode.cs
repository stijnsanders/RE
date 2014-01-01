using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmlselectsinglenode","SelectSingleNode","Perform SelectSingleNode")]
    public partial class REXmlSelectSingleNode : REBaseItem
    {
        public REXmlSelectSingleNode()
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

        public override void Start()
        {
            base.Start();
            xquery = textBox1.Text;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            lpOutput.Emit(REXML.AsXmlNode(Data).SelectSingleNode(xquery));
        }
    }
}
