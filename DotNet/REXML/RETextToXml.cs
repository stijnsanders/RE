using System;
using System.Xml;
using RE;

namespace REXML
{
    [REItem("texttoxml","text to XML","Convert text to XML")]
    public partial class RETextToXml : REBaseItem
    {
        public RETextToXml()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(XmlElement Element)
        {
            base.LoadFromXml(Element);
            preserveWhiteSpaceToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("preservewhitespace"));
        }

        public override void SaveToXml(XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("preservewhitespace", BoolToStr(preserveWhiteSpaceToolStripMenuItem.Checked));
        }

        private bool setpresws;

        public override void Start()
        {
            base.Start();
            setpresws = preserveWhiteSpaceToolStripMenuItem.Checked;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            var s = Data.ToString();
            if (s != null)
            {
                XmlDocument doc = new XmlDocument();
                if (setpresws) doc.PreserveWhitespace = true;
                doc.LoadXml(s);
                lpOutput.Emit(doc);//.DocumentElement);?
            }
        }

        private void preserveWhiteSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preserveWhiteSpaceToolStripMenuItem.Checked = !preserveWhiteSpaceToolStripMenuItem.Checked;
        }

    }
}
