using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace RE
{
    public /*abstract*/ partial class REBaseItem : UserControl
    {
        private ContextMenuStrip? mergeContextMenu = null;
        private bool modified = false;

        public REBaseItem()
        {
            InitializeComponent();
            Bitmap? i = imgItemResize.Image as Bitmap;
            if (i != null)
                i.MakeTransparent(Color.White);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (mergeContextMenu != null)
            {
                int i = 0;
                while (mergeContextMenu.Items.Count != 0)
                {
                    contextMenuStrip1.Items.Insert(i, mergeContextMenu.Items[0]);
                    i++;
                }
            }
            else
            {
                menuTopSeparator.Visible = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblCaption.Width = ClientSize.Width - 8 - panContextMenu.Width;
            panContextMenu.Left = lblCaption.Width + 5;
            imgItemResize.Location = new Point(
                ClientSize.Width - imgItemResize.Width,
                ClientSize.Height - imgItemResize.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
 	        base.OnPaint(e);
			using(Pen p=new Pen(SystemColors.ControlLightLight,1))
            {
			    e.Graphics.DrawLine(p,0,0,Width-2,0);
			    e.Graphics.DrawLine(p,0,1,0,Height-2);
			}
            using(Pen p=new Pen(SystemColors.ControlDarkDark,1))
            {
			    e.Graphics.DrawLine(p,Width-1,1,Width-1,Height-1);
			    e.Graphics.DrawLine(p,1,Height-1,Width-2,Height-1);
			}
        }

		public void Close()
		{
            //TODO: add to undo stack!
            //ask parent verif? if(LinkPanel.VerifItemRemove)
            DisconnectAll();
            Parent?.Controls.Remove(this);
		}

        private void bringToFrontToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            BringToFront();
        }

        private void sendToBackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SendToBack();
        }

        private void closeToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            BackColor=SystemColors.Control;
            //too bad, on close Parent=null here already
        }

        public void ItemSelectFocus()
        {
            //divert focus to something on item other than textbox to enable clipboard shortcuts
            panContextMenu.Focus();
        }

        protected virtual void DisconnectAll()
        {
            ArrayList cq = new();
            cq.Add(this);
            Control? c;
            while (cq.Count != 0)
            {
                c = cq[0] as Control;
                cq.RemoveAt(0);
                if (c != null)
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1.Controls.Count != 0) cq.Add(c1);
                        RELinkPoint? c2 = c1 as RELinkPoint;
                        if (c2 != null)
                            c2.ConnectedTo = null;
                    }
            }
        }

        public RELinkPoint[] GetLinkPoints(bool OnlyConnected)
        {
            List<RELinkPoint> linkpoints = new();
            ArrayList cq = new();
            cq.Add(this);
            Control? c;
            while (cq.Count != 0)
            {
                c = cq[0] as Control;
                cq.RemoveAt(0);
                if (c != null)
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1.Controls.Count != 0) cq.Add(c1);
                        if (c1 is RELinkPoint)
                        {
                            RELinkPoint? linkpoint = c1 as RELinkPoint;
                            if (linkpoint != null && (!OnlyConnected || linkpoint.ConnectedTo != null)) linkpoints.Add(linkpoint);
                        }
                    }
            }
            return linkpoints.ToArray();
        }

		[Browsable(true),Category("Appearance"),Description("Text displayed as item title")]
		public string Caption
		{
			get
			{
				return lblCaption.Text;
			}
			set
			{
                lblCaption.Text = value;
			}
		}

		[Browsable(false),Category("Appearance"),Description("Display the item as focused or as member of a selection, controlled by parent LinkPanel at run-time")]
		public bool Selected
		{
			get
			{
				return lblCaption.BackColor==SystemColors.ActiveCaption;
			}
			set
			{
				if(value)
				{
					lblCaption.BackColor=SystemColors.ActiveCaption;
					lblCaption.ForeColor=SystemColors.ActiveCaptionText;
				}
				else
				{
					lblCaption.BackColor=SystemColors.InactiveCaption;
					lblCaption.ForeColor=SystemColors.InactiveCaptionText;
				}
				lblCaption.Invalidate();
			}
		}

		[Category("Layout"),Description("Switch the bottom right resize handle to allow resizing of item")]
		public bool Resizable
		{
			set{imgItemResize.Visible=value;}
			get{return imgItemResize.Visible;}
		}

        [Browsable(true), Category("Behavior"), Description("ContextMenuStrip to merge with item's ContextMenuStrip")]
        public ContextMenuStrip? MergeContextMenuStrip
        {
            set { mergeContextMenu = value; }
            get { return mergeContextMenu; }
        }

        public bool Modified
        {
            set
            {
                modified = value;
                if (!modified)
                    foreach (Control c in Controls)
                    {
                        TextBox? t = c as TextBox;
                        if (t != null)
                            t.Modified = false;
                    }
                //more classes? cascaded?
            }
            get
            {
                if (!modified)
                    foreach (Control c in Controls)
                    {
                        TextBox? t = c as TextBox;
                        if (t != null)
                            if (t.Modified) return true;
                    }
                return modified;
            }
        }

		public virtual void SaveToXml(XmlElement Element)
		{
            //inheritants must save properties
			Element.SetAttribute("left",Left.ToString());
			Element.SetAttribute("top",Top.ToString());
            if (Resizable)
            {
                Element.SetAttribute("width", Width.ToString());
                Element.SetAttribute("height", Height.ToString());
            }
		}

        public virtual void LoadFromXml(XmlElement Element)
        {
            //inheritants must link linkpoints and read properties
            if (Resizable)
                SetBounds(
                    Int32.Parse(Element.GetAttribute("left")),
                    Int32.Parse(Element.GetAttribute("top")),
                    Int32.Parse(Element.GetAttribute("width")),
                    Int32.Parse(Element.GetAttribute("height")));
            else
                SetBounds(
                    Int32.Parse(Element.GetAttribute("left")),
                    Int32.Parse(Element.GetAttribute("top")),
                    Width,
                    Height);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (lblCaption.ContextMenuStrip != null)
                lblCaption.ContextMenuStrip.Show(PointToScreen(panContextMenu.Location));
        }

        private void panContextMenu_MouseDown(object sender, MouseEventArgs e)
        {
            panContextMenu.BackColor = SystemColors.ButtonShadow;
        }

        private void panContextMenu_MouseUp(object sender, MouseEventArgs e)
        {
            panContextMenu.BackColor = SystemColors.ButtonFace;
        }

        private void panContextMenu_MouseEnter(object sender, EventArgs e)
        {
            panContextMenu.BackColor = SystemColors.ButtonHighlight;
        }

        private void panContextMenu_MouseLeave(object sender, EventArgs e)
        {
            panContextMenu.BackColor = SystemColors.ButtonFace;
        }

        protected bool StrToBool(string s)
        {
            return (s == "1") || (s == "true") || (s.ToLower() == "true");
        }

        protected string BoolToStr(bool b)
        {
            return b ? "1" : "0";
        }

        public virtual void Start()
        {
            //inheritants call emit on any linkpoints that have data ready
            //also perform further processing by handling linkpoint Signal events
        }

        public virtual void Stop()
        {
            //inheritants perform clean-up code, any exceptions go ignored
        }

    }

}
