using System;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("xmlnode", "Node", "Get a related xml node")]
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

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
            {
                XmlNode? x = REXML.AsXmlNode(Data);
                XmlNode? y = null;
                if (x != null)
                    switch (xprop)
                    {
                        case 0: y = x.FirstChild; break;
                        case 1: y = x.NextSibling; break;
                        case 2: y = x.ParentNode; break;
                        case 3: y = x.LastChild; break;
                        case 4: y = x.PreviousSibling; break;
                        case 5: y = x.OwnerDocument?.DocumentElement; break;
                    }
                if (y != null) lpOutput.Emit(y);
            }
        }

        private void cbProp_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Modified = true;
        }
    }
}