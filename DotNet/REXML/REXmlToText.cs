﻿using System;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmltotext", "XML to text", "Convert XML to text")]
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

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
            {
                XmlNode? x = REXML.AsXmlNode(Data);
                string? y = null;
                if (x != null)
                    switch (xmethod)
                    {
                        case 0: y = x.InnerText; break;
                        case 1: y = x.Value; break;
                        case 2: y = x.OuterXml; break;
                        case 3: y = x.InnerXml; break;
                        case 4: y = x.Name; break;
                        case 5: y = x.LocalName; break;
                        case 6: y = x.Prefix; break;
                        case 7: y = x.NamespaceURI; break;
                        case 8: y = x.BaseURI; break;
                        case 9: y = x.ToString(); break;
                    }
                if (y != null) lpOutput.Emit(y);
            }
        }

    }
}