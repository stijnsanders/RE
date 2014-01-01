using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REBasic
{
    [REItem("comment","Comment","")]
    public partial class REComment : REBaseItem
    {
        public REComment()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement c=Element.SelectSingleNode("comment") as XmlElement;
            if (c != null)
            {
                textBox1.Text = c.InnerText;
                readonlyToolStripMenuItem.Checked = StrToBool(c.GetAttribute("locked"));
                boldToolStripMenuItem.Checked = StrToBool(c.GetAttribute("bold"));
                italicToolStripMenuItem.Checked = StrToBool(c.GetAttribute("italic"));
                underlineToolStripMenuItem.Checked = StrToBool(c.GetAttribute("underline"));
            }
        }

        public override void SaveToXml(XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement c = Element.OwnerDocument.CreateElement("comment");
            c.InnerText = textBox1.Text;
            c.SetAttribute("locked",BoolToStr(readonlyToolStripMenuItem.Checked));
            c.SetAttribute("bold", BoolToStr(boldToolStripMenuItem.Checked));
            c.SetAttribute("italic", BoolToStr(italicToolStripMenuItem.Checked));
            c.SetAttribute("underline", BoolToStr(underlineToolStripMenuItem.Checked));
            Element.AppendChild(c);
        }

        private void toggleToolStripMenuItem(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
        }

        private void boldToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle fs = textBox1.Font.Style;
            if(boldToolStripMenuItem.Checked)
                fs|=FontStyle.Bold;
            else
                fs^=FontStyle.Bold;
            textBox1.Font = new Font(textBox1.Font, fs);
        }

        private void italicToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle fs = textBox1.Font.Style;
            if (italicToolStripMenuItem.Checked)
                fs |= FontStyle.Italic;
            else
                fs ^= FontStyle.Italic;
            textBox1.Font = new Font(textBox1.Font, fs);
        }

        private void underlineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle fs = textBox1.Font.Style;
            if (underlineToolStripMenuItem.Checked)
                fs |= FontStyle.Underline;
            else
                fs ^= FontStyle.Underline;
            textBox1.Font = new Font(textBox1.Font, fs);
        }

        private void readonlyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = readonlyToolStripMenuItem.Checked;
        }
    }

}