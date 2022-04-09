using System;
using System.Xml;
using System.Text.Json;
using RE;

namespace REJSON
{
    [REItem("jsontotext", "JSON to text", "Convert JSON to text")]
    public partial class REJsonToText : REBaseItem
    {
        public REJsonToText()
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
                throw new Exception("[JsonToText] no method selected");
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            object? y = null;
            switch (xmethod)
            {
                case 0:
                    y = Data?.ToString();
                    break;
                case 1:
                    {
                        JsonProperty? p = Data as JsonProperty?;
                        if (p.HasValue) y = p.Value.Name;
                    }
                    break;
                case 2:
                    {
                        JsonProperty? p = Data as JsonProperty?;
                        if (p.HasValue) y = p.Value.Value;
                    }
                    break;
                case 3:
                    {
                        JsonProperty? p = Data as JsonProperty?;
                        if (p.HasValue) y = p.Value.Value;
                    }
                    break;
            }
            if (y != null) lpOutput.Emit(y);
        }

    }
}