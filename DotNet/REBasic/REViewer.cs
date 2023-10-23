using System;
using System.Runtime.CompilerServices;
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

        private const int RelaxDisplayAfterXInputs = 200;
        private const int RelaxDisplayEachMS = 1250;
        private int _inputs;
        private string _buffer = "";//StringBuilder?
        private DateTime _lastDisplay;

        public override void Start()
        {
            base.Start();
            textBox1.Clear();
            _inputs = 0;
            _buffer = "";
            _lastDisplay = DateTime.Now;
        }

        public override void Stop()
        {
            textBox1.Text += _buffer;
            base.Stop();
        }

        void reLinkPoint1_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
            {
                DateTime n = DateTime.Now;
                if (_inputs < RelaxDisplayAfterXInputs)
                {
                    textBox1.Text += Data.ToString();
                    _lastDisplay = n;
                    _inputs++;
                }
                else
                {
                    _buffer += Data.ToString();
                    if (_lastDisplay < n.AddMilliseconds(-RelaxDisplayEachMS))
                    {
                        textBox1.Text += _buffer;
                        _buffer = "";
                        _lastDisplay = n;
                    }
                }
            }
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

