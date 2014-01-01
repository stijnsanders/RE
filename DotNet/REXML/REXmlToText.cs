using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmltotext","XML to text","Convert XML to text")]
    public partial class REXmlToText : REBaseItem
    {
        public REXmlToText()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(XmlElement Element)
        {
            base.LoadFromXml(Element);
            cbMethod.SelectedIndex = Convert.ToInt32(Element.GetAttribute("method"));
            Modified = false;
        }

        public override void SaveToXml(XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("method", cbMethod.SelectedIndex.ToString());
        }

        private int xmethod;

        public override void Start()
        {
            base.Start();
            xmethod = cbMethod.SelectedIndex;
            if (xmethod == -1)
                throw new Exception("[XmlToText] no method selected");
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            XmlNode x = REXML.AsXmlNode(Data);
            switch (xmethod)
            {
                case 0: lpOutput.Emit(x.InnerText); break;
                case 1: lpOutput.Emit(x.Value); break;
                case 2: lpOutput.Emit(x.OuterXml); break;
                case 3: lpOutput.Emit(x.InnerXml); break;
                case 4: lpOutput.Emit(x.Name); break;
                case 5: lpOutput.Emit(x.LocalName); break;
                case 6: lpOutput.Emit(x.Prefix); break;
                case 7: lpOutput.Emit(x.NamespaceURI); break;
                case 8: lpOutput.Emit(x.BaseURI); break;
                case 9: lpOutput.Emit(x.ToString()); break;
            }
        }

    }
}
