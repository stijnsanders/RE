using System.Text.Json;
using RE;

namespace REJSON
{
    [REItem("jsonkeyvalue", "JSON key value", "JSON document get value by key")]
    public partial class REJsonKeyValue : REBaseItem
    {
        public REJsonKeyValue()
        {
            InitializeComponent();
            _key = ""; //default, see Start
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            textBox1.Text = Element.GetAttribute("key");
            silentWhenMissingToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("silent"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("key", textBox1.Text);
            Element.SetAttribute("silent",BoolToStr(silentWhenMissingToolStripMenuItem.Checked));
        }

        private string _key;
        private bool _silent;

        public override void Start()
        {
            base.Start();
            _key = textBox1.Text;
            _silent = silentWhenMissingToolStripMenuItem.Checked;
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            JsonElement? e = Data as JsonElement?;
            if (e.HasValue)
                if (_silent)
                {
                    if (e.Value.TryGetProperty(_key, out JsonElement v)) lpOutput.Emit(v);
                }
                else
                    lpOutput.Emit(e.Value.GetProperty(_key));
        }

        private void silentWhenMissingToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            silentWhenMissingToolStripMenuItem.Checked = !silentWhenMissingToolStripMenuItem.Checked;
        }
    }
}