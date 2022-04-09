using System;
using RE;

namespace RE
{
    [REItem("viewer", "Viewer", "Displays input")]
    public partial class REViewer : REBaseItem
    {
        public REViewer()
        {
            InitializeComponent();
            reLinkPoint1.Signal += new RELinkPointSignal(reLinkPoint1_Signal);
        }

        public override void Start()
        {
            base.Start();
            textBox1.Clear();
        }

        void reLinkPoint1_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
                textBox1.Text += Data.ToString();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            wordWrapToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("wrap"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("wrap", BoolToStr(wordWrapToolStripMenuItem.Checked));
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
        }

        private void wordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }
    }
}

