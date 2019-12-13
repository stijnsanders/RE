using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;

namespace RERegex
{
    public partial class REBaseRegExItem : RE.REBaseItem
    {
        public REBaseRegExItem()
        {
            InitializeComponent();
        }

        private void checkPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Regex re1 = new Regex(txtRegExPattern.Text);
                MessageBox.Show(this, "Pattern is ok.",
                    "Check pattern", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex1)
            {
                MessageBox.Show(this, "Pattern is not ok.\r\n\r\n" + ex1.ToString(),
                    "Check pattern", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string ToString()
        {
            return base.ToString() + ":\"" + txtRegExPattern.Text + "\"";
        }

        private Regex _regex;

        protected Regex ItemRegex
        {
            get {
                if (_regex != null) return _regex;

                RegexOptions ro=RegexOptions.None;
                //more RegexOptions? compiled?
                if(cbRegExIgnoreCase.Checked)
                    ro|=RegexOptions.IgnoreCase;
                //always one or the other?
                if(cbRegExMultiLine.Checked)
                    ro|=RegexOptions.Multiline;
                else
                    ro|=RegexOptions.Singleline;
                if (explicitCaptureToolStripMenuItem.Checked)
                    ro |= RegexOptions.ExplicitCapture;
                if (compiledToolStripMenuItem.Checked)
                    ro |= RegexOptions.Compiled;
                if (ignorePatternWhitespaceToolStripMenuItem.Checked)
                    ro |= RegexOptions.IgnorePatternWhitespace;
                if (rightToLeftToolStripMenuItem.Checked)
                    ro |= RegexOptions.RightToLeft;
                if (eCMAScriptToolStripMenuItem.Checked)
                    ro |= RegexOptions.ECMAScript;
                if (cultureInvariantToolStripMenuItem.Checked)
                    ro |= RegexOptions.CultureInvariant;

                return new Regex(txtRegExPattern.Text, ro);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            txtRegExPattern.Width = panItemClient.ClientSize.Width - 4;
            base.OnLoad(e);
        }

        public override void Start()
        {
            base.Start();
            _regex = ItemRegex;
        }

        public override void Stop()
        {
            base.Stop();
            _regex = null;
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement xPattern = Element.SelectSingleNode("pattern") as XmlElement;
            txtRegExPattern.Text = xPattern.InnerText;
            cbRegExIgnoreCase.Checked = StrToBool(xPattern.GetAttribute("ignoreCase"));
            cbRegExMultiLine.Checked = StrToBool(xPattern.GetAttribute("multiLine"));
            explicitCaptureToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("explicitCapture"));
            compiledToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("compiled"));
            ignorePatternWhitespaceToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("ignorePatternWhiteSpace"));
            rightToLeftToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("rightToLeft"));
            eCMAScriptToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("ecmaScript"));
            cultureInvariantToolStripMenuItem.Checked = StrToBool(xPattern.GetAttribute("cultureInvariant"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement xPattern = Element.OwnerDocument.CreateElement("pattern");
            xPattern.InnerText = txtRegExPattern.Text;
            xPattern.SetAttribute("ignoreCase", BoolToStr(cbRegExIgnoreCase.Checked));
            xPattern.SetAttribute("multiLine", BoolToStr(cbRegExMultiLine.Checked));
            xPattern.SetAttribute("explicitCapture", BoolToStr(explicitCaptureToolStripMenuItem.Checked));
            xPattern.SetAttribute("compiled", BoolToStr(compiledToolStripMenuItem.Checked));
            xPattern.SetAttribute("ignorePatternWhiteSpace", BoolToStr(ignorePatternWhitespaceToolStripMenuItem.Checked));
            xPattern.SetAttribute("rightToLeft", BoolToStr(rightToLeftToolStripMenuItem.Checked));
            xPattern.SetAttribute("ecmaScript", BoolToStr(eCMAScriptToolStripMenuItem.Checked));
            xPattern.SetAttribute("cultureInvariant", BoolToStr(cultureInvariantToolStripMenuItem.Checked));

            Element.AppendChild(xPattern);
        }

        private void cbRegExIgnoreCase_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void cbRegExMultiLine_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ignorePatternWhitespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = !ignorePatternWhitespaceToolStripMenuItem.Checked;
        }

        private void explicitCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explicitCaptureToolStripMenuItem.Checked = !explicitCaptureToolStripMenuItem.Checked;
        }

        private void compiledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compiledToolStripMenuItem.Checked = !compiledToolStripMenuItem.Checked;
        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rightToLeftToolStripMenuItem.Checked = !rightToLeftToolStripMenuItem.Checked;
        }

        private void eCMAScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eCMAScriptToolStripMenuItem.Checked = !eCMAScriptToolStripMenuItem.Checked;
        }

        private void cultureInvariantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cultureInvariantToolStripMenuItem.Checked = !cultureInvariantToolStripMenuItem.Checked;
        }
    }
}

