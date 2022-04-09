using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REBasic
{
    [REItem("translate", "Translate", "Translate: perform a series of plain text replaces")]
    public partial class RETranslate : REBaseItem
    {
        private List<RETranslateItem> TranslateItems = new List<RETranslateItem>();
        private const int _column1Margin = 8;
        private RELinkPointPatch patch;

        public RETranslate()
        {
            InitializeComponent();
            lpInput.Signal += new RELinkPointSignal(lpInput_Signal);
            patch = new RELinkPointPatch(lpInput, lpOutput);
            _column1Left = panColumn1.Left - _column1Margin;
            AddNewItem();
            ReOrderItems();
        }

        private RETranslateItem AddNewItem()
        {
            RETranslateItem i = new RETranslateItem();
            i.Enter += new EventHandler(i_Enter);
            i.Visible = false;
            i.Width = panItems.ClientSize.Width;
            panItems.Controls.Add(i);
            i.Column1Left = _column1Left;
            i.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            TranslateItems.Add(i);
            //ReOrderItems(); caller should call after loop
            return i;
        }

        private int lastItemIndex = 0;

        void i_Enter(object? sender, EventArgs e)
        {
            var i = sender as RETranslateItem;
            if (i == null)
                lastItemIndex = -1;
            else
                lastItemIndex = TranslateItems.IndexOf(i);
        }

        private void ReOrderItems()
        {
            SuspendLayout();
            int y = 0;
            foreach (RETranslateItem i in TranslateItems)
            {
                i.Bounds = new Rectangle(0, y, panItems.ClientRectangle.Width, i.Height);
                i.Visible = true;
                y += i.Height;
            }
            ResumeLayout();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            AddNewItem();
            ReOrderItems();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (TranslateItems.Count != 0)
            {
                if (lastItemIndex < 0 || lastItemIndex >= TranslateItems.Count)
                    lastItemIndex = 0;
                RETranslateItem i = TranslateItems[lastItemIndex];
                TranslateItems.RemoveAt(lastItemIndex);
                panItems.Controls.Remove(i);
                ReOrderItems();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (TranslateItems.Count > 1)
            {
                if (lastItemIndex < 0 || lastItemIndex >= TranslateItems.Count)
                    lastItemIndex = 0;
                if (lastItemIndex > 0)
                {
                    RETranslateItem i = TranslateItems[lastItemIndex];
                    TranslateItems.RemoveAt(lastItemIndex);
                    lastItemIndex--;
                    TranslateItems.Insert(lastItemIndex, i);
                    ReOrderItems();
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (TranslateItems.Count > 1)
            {
                if (lastItemIndex < 0 || lastItemIndex >= TranslateItems.Count)
                    lastItemIndex = 0;
                if (lastItemIndex < TranslateItems.Count - 1)
                {
                    RETranslateItem i = TranslateItems[lastItemIndex];
                    TranslateItems.RemoveAt(lastItemIndex);
                    if (lastItemIndex == TranslateItems.Count - 1)
                        TranslateItems.Add(i);
                    else
                        TranslateItems.Insert(lastItemIndex + 1, i);
                    lastItemIndex++;
                    ReOrderItems();
                }
            }
        }

        public override void LoadFromXml(XmlElement Element)
        {
            panItems.Controls.Clear();
            TranslateItems.Clear();
            base.LoadFromXml(Element);
            cbGlobal.Checked = StrToBool(Element.GetAttribute("global"));
            cbIgnoreCase.Checked = StrToBool(Element.GetAttribute("ignorecase"));
            try
            {
                Column1Left = Int32.Parse(Element.GetAttribute("column1"));
            }
            catch
            {
                //silent
            }
            var l = Element.SelectNodes("translations/translationitem");
            if (l != null)
                foreach (XmlElement t in l)
                {
                    RETranslateItem i = AddNewItem();
                    i.SearchString = t.GetAttribute("search");
                    i.ReplaceString = t.InnerText;
                }
            ReOrderItems();
        }

        public override void SaveToXml(XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("global", BoolToStr(cbGlobal.Checked));
            Element.SetAttribute("ignorecase", BoolToStr(cbIgnoreCase.Checked));
            Element.SetAttribute("column1", _column1Left.ToString());
            XmlElement tx = Element.OwnerDocument.CreateElement("translations");
            Element.AppendChild(tx);
            foreach (RETranslateItem i in TranslateItems)
            {
                XmlElement t = Element.OwnerDocument.CreateElement("translationitem");
                t.SetAttribute("search", i.SearchString);
                t.InnerText = i.ReplaceString;
                tx.AppendChild(t);
            }
        }

        public override void Start()
        {
            base.Start();
        }

        void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            //InvariantCulture?
            StringComparison c = StringComparison.CurrentCulture;
            if (cbIgnoreCase.Checked) c = StringComparison.CurrentCultureIgnoreCase;
            string? s = Data?.ToString();
            if (s != null)
            {
                foreach (RETranslateItem i in TranslateItems)
                    if (i.SearchString != "")
                    {
                        //s = s.Replace(i.SearchString, i.ReplaceString);
                        int j = 0;
                        while (j != -1)
                        {
                            j = s.IndexOf(i.SearchString, j, c);
                            if (j != -1)
                            {
                                s = s.Substring(0, j) + i.ReplaceString + s.Substring(j + i.SearchString.Length);
                                j += i.ReplaceString.Length;
                                if (!cbGlobal.Checked || j > s.Length) j = -1;
                            }
                        }
                    }
                lpOutput.Emit(s);
            }
        }

        private int _column1Left;
        private bool _column1LeftDragging = false;
        private int _column1LeftDragStart;
        private int _column1LeftDragStartX;

        private void panColumn1_MouseDown(object sender, MouseEventArgs e)
        {
            _column1LeftDragging = true;
            _column1LeftDragStart = _column1Left;
            _column1LeftDragStartX = MousePosition.X;
        }

        private int Column1Left
        {
            get
            {
                return _column1Left;
            }
            set
            {
                _column1Left = value;
                if (_column1Left < 32)
                    _column1Left = 32;
                if (_column1Left > panItems.ClientSize.Width - 32)
                    _column1Left = panItems.ClientSize.Width - 32;
                panColumn1.Left = _column1Left + _column1Margin;
                lblReplace.Left = _column1Left + _column1Margin + 3;
                foreach (RETranslateItem i in TranslateItems) i.Column1Left = _column1Left;
            }
        }

        private void panColumn1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_column1LeftDragging)
                Column1Left = _column1LeftDragStart + MousePosition.X - _column1LeftDragStartX;
        }

        private void panColumn1_MouseUp(object sender, MouseEventArgs e)
        {
            _column1LeftDragging = false;
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}