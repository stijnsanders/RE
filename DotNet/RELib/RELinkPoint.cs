using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RE
{
    public enum RELinkPointDirection { Unknown, Input, Output };

    public delegate void RELinkPointSignal(RELinkPoint Sender, object? Data);

    public delegate void RELinkPointConnecting(RELinkPoint Sender, RELinkPoint ConnectingTo);

    public partial class RELinkPoint : UserControl
    {
        private RELinkPoint? connectedTo = null;
        private Color conColor = Color.Transparent;
        private bool isReconnecting = false;
        private RELinkPointDirection direction = RELinkPointDirection.Unknown;
        private string caption = "";
        private string key = "";
        private REBaseItem? ownerItem = null;

        public RELinkPoint()
        {
            InitializeComponent();
        }

        //used by run-time-link-points (such as for catching sequence ends)
        public RELinkPoint(String ShowKey, REBaseItem ShowParent)
        {
            Visible = false;
            Key = ShowKey;
            ownerItem = ShowParent;
            InitializeComponent();
        }

        //Dispose: ConnectedTo=null?

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen p;
            p = new Pen(SystemColors.ControlDarkDark, 1);
            e.Graphics.DrawLine(p, 0, 0, Width - 2, 0);
            e.Graphics.DrawLine(p, 0, 1, 0, Height - 2);
            p.Dispose();
            p = new Pen(SystemColors.ControlLightLight, 1);
            e.Graphics.DrawLine(p, Width - 1, 1, Width - 1, Height - 1);
            e.Graphics.DrawLine(p, 1, Height - 1, Width - 2, Height - 1);
            p.Dispose();
            if (connectedTo != null)
            {
                Brush b = new SolidBrush(conColor);
                e.Graphics.FillRectangle(b, 1, 1, Width - 2, Height - 2);
                b.Dispose();
            }

            if (caption != "")
            {
                SizeF ts = e.Graphics.MeasureString(caption, Font);
                e.Graphics.DrawString(caption, Font, new SolidBrush(SystemColors.WindowText), (Width - ts.Width) / 2, (Height - ts.Height) / 2);
            }
        }

        public override string ToString()
        {
            //connectedto?
            string x;
            if (ownerItem == null)
                if (Parent == null)
                    x = "null";
                else
                    x = BaseItem.ToString();
            else
                x = ownerItem.ToString();
            return String.Format("{0}:\"{1}\"[{2}]@{3}", base.ToString(), caption, key, x);
        }

        [Browsable(false)]
        public IRELinkPanel LinkPanel
        {
            get
            {
                Control? c = Parent;
                if (c == null) c = ownerItem;
                while (c != null && !(c is IRELinkPanel)) c = c.Parent;
                var p = c as IRELinkPanel;
                if (p != null)
                    return p;
                else
                    throw new Exception("Unable to obtain LinkPanel reference");
            }
        }

        public REBaseItem BaseItem
        {
            get
            {
                Control? c = Parent;
                while (!(c == null || c is REBaseItem)) c = c.Parent;
                REBaseItem? b = c as REBaseItem;
                if (b != null)
                    return b;
                else
                    throw new Exception("Unable to obtain BaseItem reference");
            }
        }

        private void Disconnect()
        {
            if (connectedTo != null)
            {
                connectedTo.connectedTo = null;
                LinkPanel.ReportLinkDisconnect(this);
            }
            //connectedTo = null; ??caller should do this (hence private)
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RELinkPoint? ConnectedTo
        {
            get
            {
                return connectedTo;
            }
            set
            {
                if (value != connectedTo && !isReconnecting)
                {
                    isReconnecting = true;
                    try
                    {
                        if (Connecting != null && value != null) Connecting(this, value);
                        Disconnect();
                        connectedTo = value;
                        if (connectedTo != null)
                        {
                            connectedTo.Disconnect();
                            connectedTo.connectedTo = this;
                            LinkPanel.ReportLinkConnect(this, connectedTo);
                        }
                    }
                    finally
                    {
                        isReconnecting = false;
                    }
                }
            }
        }

        [Browsable(false)]
        public Point PanelHotSpot
        {
            get
            {
                Point a = new Point(Left + Width / 2, Top + Height / 2);
                Control? c = Parent;
                while (c != null && !(c is IRELinkPanel))
                {
                    a.Offset(c.Left, c.Top);
                    c = c.Parent ?? null;
                }
                return a;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color ConnectionColor
        {
            get { return conColor; }
            set
            {
                conColor = value;
                //if (connectedTo != null) connectedTo.conColor = conColor;
                //Invalidate();
                //linkpanel should cater for link color
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //startdrag?
            DoDragDrop(this, DragDropEffects.Link);
        }
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            //enddrag?
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            drgevent.Effect = DragDropEffects.None;//default not allowed!
            //if(drgevent.Data.GetDataPresent(typeof(ucLinkPoint)))??
            RELinkPoint? Item = drgevent.Data?.GetData(typeof(RELinkPoint)) as RELinkPoint;
            if (Item != null)
            {
                if (Item == this || (
                    ((direction == RELinkPointDirection.Input && Item.Direction == RELinkPointDirection.Output) ||
                    (direction == RELinkPointDirection.Output && Item.Direction == RELinkPointDirection.Input)) &&
                    BaseItem != Item.BaseItem
                    ) || (
                    ((direction == RELinkPointDirection.Input && Item.Direction == RELinkPointDirection.Input) ||
                    (direction == RELinkPointDirection.Output && Item.Direction == RELinkPointDirection.Output)) &&
                    Item.ConnectedTo != null
                    ))
                    drgevent.Effect = drgevent.AllowedEffect;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            //assert(FLinkPanel!=null)
            //Connection=;
            RELinkPoint? lp = drgevent.Data?.GetData(typeof(RELinkPoint)) as RELinkPoint;
            if (lp == null || lp == this)
                ConnectedTo = null;
            else if (direction == lp.Direction)
                ConnectedTo = lp.connectedTo;
            else
                ConnectedTo = lp;
        }

        [Category("Appearance"), Description("Text label to display on the link point"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                Invalidate(false);
            }
        }

        [Category("Behavior"), Description("Label used internally to store connection information"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        [Category("Behavior"), Description("Determines which connections are allowed to make"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RELinkPointDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public void Emit(object Data)
        {
            Emit(Data, false);
        }

        public void Emit(object Data, bool MoreToCome)
        {
            //if(direction!=RELinkPointDirection.Output) throw?
            if (connectedTo != null)
                LinkPanel.ReportLinkSignal(this, RELinkPointSignalType.Sending, Data, MoreToCome);
            //else throw?
        }

        public void Suspend()
        {
            LinkPanel.ReportLinkSignal(this, RELinkPointSignalType.Suspending, null, true);
        }

        public void Resume()
        {
            LinkPanel.ReportLinkSignal(this, RELinkPointSignalType.Resuming, null, false);
        }

        public void Resume(object Data)
        {
            LinkPanel.ReportLinkSignal(this, RELinkPointSignalType.Resuming, Data, true);
        }

        [Browsable(true), Category("Behavior"), Description("Event fired when action is required from the linkpoint when performing.")]
        public event RELinkPointSignal? Signal;

        [Browsable(true), Category("Behavior"), Description("Event fired when a linkpoint is about to get connected to another linkpoint.")]
        public event RELinkPointConnecting? Connecting;

        [Description("Don't call FireSignal yourself. It is used internally when performing. Use Emit and handle Signal events fired for you.")]
        public void FireSignal(object? Data)
        {
            if (Signal != null) Signal(this, Data);
        }

    }
}
