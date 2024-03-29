using System;
using System.Xml;

namespace RERegex
{
    [RE.REItem("replace", "Replace", "Replace text using a regular expression")]
    public partial class REReplace : REBaseRegExItem
    {
        private RE.RELinkPointPatch patch;

        public REReplace()
        {
            InitializeComponent();
            patch = new RE.RELinkPointPatch(lpRegExInput, lpOutput);
            lpRegExInput.Signal += new RE.RELinkPointSignal(lpRegExInput_Signal);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
        }

        private void wordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        void lpRegExInput_Signal(RE.RELinkPoint Sender, object? Data)
        {
            var s = Data?.ToString();
            if (s != null)
                if (cbGlobal.Checked)
                    lpOutput.Emit(ItemRegex.Replace(s, textBox1.Text));
                else
                    lpOutput.Emit(ItemRegex.Replace(s, textBox1.Text, 1));
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement? replace = Element.SelectSingleNode("replace") as XmlElement;
            if (replace != null)
            {
                textBox1.Text = replace.InnerText;
                wordWrapToolStripMenuItem.Checked = StrToBool(replace.GetAttribute("wrap"));
            }
            XmlElement? pattern = Element.SelectSingleNode("pattern") as XmlElement;
            if (pattern != null)
                cbGlobal.Checked = StrToBool(pattern.GetAttribute("global"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement replace = Element.OwnerDocument.CreateElement("replace");
            replace.InnerText = textBox1.Text;
            replace.SetAttribute("wrap", BoolToStr(wordWrapToolStripMenuItem.Checked));
            Element.AppendChild(replace);
            XmlElement? pattern = Element.SelectSingleNode("pattern") as XmlElement;
            if (pattern != null)
                pattern.SetAttribute("global", BoolToStr(cbGlobal.Checked));
        }

        private void cbGlobal_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}