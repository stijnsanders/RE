using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmlnode","Node","Get a related xml node")]
    public partial class REXmlNode : REBaseItem
    {
        public REXmlNode()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            cbProp.SelectedIndex = Convert.ToInt32(Element.GetAttribute("property"));
            Modified = false;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("property", cbProp.SelectedIndex.ToString());
        }

        private int xprop;

        public override void Start()
        {
            base.Start();
            xprop = cbProp.SelectedIndex;
            if (xprop == -1) throw new Exception("[XmlNode]no XmlNode property selected");
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            XmlNode x=REXML.AsXmlNode(Data);
            switch (xprop)
            {
                case 0: lpOutput.Emit(x.FirstChild); break;
                case 1: lpOutput.Emit(x.NextSibling); break;
                case 2: lpOutput.Emit(x.ParentNode); break;
                case 3: lpOutput.Emit(x.LastChild); break;
                case 4: lpOutput.Emit(x.PreviousSibling); break;
                case 5: lpOutput.Emit(x.OwnerDocument.DocumentElement); break;
            }
        }

        private void cbProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modified = true;
        }
    }
}
