using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text.Json;
using RE;

namespace REJSON
{
    [REItem("texttojson","text to JSON","Convert text to JSON")]
    public partial class RETextToJson : REBaseItem
    {
        public RETextToJson()
        {
            InitializeComponent();
        }
        public override void LoadFromXml(XmlElement Element)
        {
            base.LoadFromXml(Element);
            //preserveWhiteSpaceToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("preservewhitespace"));
        }

        public override void SaveToXml(XmlElement Element)
        {
            base.SaveToXml(Element);
            //Element.SetAttribute("preservewhitespace", BoolToStr(preserveWhiteSpaceToolStripMenuItem.Checked));
        }

        public override void Start()
        {
            base.Start();
            //setpresws = preserveWhiteSpaceToolStripMenuItem.Checked;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            string? s = Data.ToString();
            if (s != null)
                lpOutput.Emit(JsonDocument.Parse(s).RootElement);
        }
    }
}
