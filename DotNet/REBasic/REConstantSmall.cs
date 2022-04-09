using System.Xml;
using RE;

namespace REBasic
{
    [REItem("tinyconst","Small constant value","Outputs a constant value (single line)")]
    public partial class REConstantSmall : RE.REBaseItem
    {
        public REConstantSmall()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement? value = Element.SelectSingleNode("value") as XmlElement;
            if (value != null)
                textBox1.Text = value.InnerText;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement value = Element.OwnerDocument.CreateElement("value");
            value.InnerText = textBox1.Text;
            Element.AppendChild(value);
        }

        public override void Start()
        {
            base.Start();
            reLinkPoint1.Emit(textBox1.Text);
        }

    }
}

