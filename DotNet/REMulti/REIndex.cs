using System;
using RE;

namespace REMulti
{
    [REItem("index","Index","Output numbers based on counting a multiple input.")]
    public partial class REIndex : RE.REBaseItem
    {
        public REIndex()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cbFormat.SelectedIndex == -1) cbFormat.SelectedIndex = 0;
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            txtStart.Text = Element.GetAttribute("indexStart");
            txtStep.Text = Element.GetAttribute("indexStep");
            cbFormat.SelectedIndex = Convert.ToInt32(Element.GetAttribute("indexFormat"));
            txtFormatPar.Text = Element.GetAttribute("indexFormatLength");
            Modified = false;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("indexStart", txtStart.Text);
            Element.SetAttribute("indexStep", txtStep.Text);
            Element.SetAttribute("indexFormat", cbFormat.SelectedIndex.ToString());
            Element.SetAttribute("indexFormatLength", txtFormatPar.Text);
        }

        private int indexvalue;
        private int indexmax;
        private int indexstep;
        private int formatpar;
        private bool indexcount;

        public override void Start()
        {
            base.Start();
            switch (cbFormat.SelectedIndex)
            {
                case 0:
                    formatpar = 0;
                    break;
                case 1:
                case 2:
                    formatpar = Convert.ToInt32(txtFormatPar.Text);
                    break;
                case 3:
                    formatpar = (txtFormatPar.Text == "" ? 0 : Convert.ToInt32(txtFormatPar.Text));
                    break;
                default:
                    throw new Exception("[index]No index format selected");
            }
            indexstep = Convert.ToInt32(txtStep.Text);
            string[] x = txtStart.Text.Split((':'));
            indexcount = x.Length == 2;
            //TODO: support comma-separated list of numbers and ranges?
            if(indexcount)
            {
                if (lpCount.ConnectedTo != null)
                    throw new Exception("[index]Don't connect count and specify a range");
                indexvalue = Convert.ToInt32(x[0].Trim());
                indexmax = Convert.ToInt32(x[1].Trim());
                SendIndexValue();
            }
            else
                indexvalue = Convert.ToInt32(txtStart.Text);
        }

        private void SendIndexValue()
        {
            string s;
            switch (cbFormat.SelectedIndex)
            {
                case 0:
                    s = indexvalue.ToString();
                    break;
                case 1: //left-pad zeroes
                    s = indexvalue.ToString("D" + formatpar.ToString());
                    break;
                case 2: //left-pad spaces
                    s = indexvalue.ToString();
                    while (s.Length < formatpar) s = " " + s;
                    break;
                case 3: //hex
                    if (formatpar == 0)
                        s = indexvalue.ToString("X");
                    else
                        s = indexvalue.ToString("X" + formatpar.ToString());
                    break;
                default: //counter warning
                    s = "";
                    break;
            }
            lpOutput.Emit(s, indexcount);
            indexvalue += indexstep;
        }

        private void lpCount_Signal(RELinkPoint Sender, object Data)
        {
            SendIndexValue();
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            if (indexcount)
                if (indexvalue > indexmax)
                    indexcount = false;
                else
                    SendIndexValue();
        }

        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modified = true; 
        }

    }
}
