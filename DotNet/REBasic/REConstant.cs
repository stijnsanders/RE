using System;
using System.Xml;
using RE;

namespace REBasic
{
    [REItem("const","Constant value","Outputs a constant value")]
    public partial class REConstant : RE.REBaseItem
    {
        public REConstant()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement? value = Element.SelectSingleNode("value") as XmlElement;
            if (value != null)
            {
                textBox1.Text = value.InnerText;
                wordWrapToolStripMenuItem.Checked = StrToBool(value.GetAttribute("wrap"));
            }
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement value = Element.OwnerDocument.CreateElement("value");
            value.InnerText = textBox1.Text;
            value.SetAttribute("value", BoolToStr(wordWrapToolStripMenuItem.Checked));
            Element.AppendChild(value);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
        }

        private void wordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        public override void Start()
        {
            base.Start();
            reLinkPoint1.Emit(textBox1.Text);
        }
    }
}

