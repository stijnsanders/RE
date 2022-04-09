using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace RE
{
    internal delegate void LinkPointSignalEvent(RELinkPoint LinkPoint, RELinkPointSignalType Signal, object? Data, bool MoreComing);

    internal partial class RELinkPanel : UserControl, IRELinkPanel
    {
        private bool isDragging = false;
        private bool wasDragging = false;
        private bool isResizing = false;
        private bool isSelecting = false;
        private int dragStartX;
        private int dragStartY;
        private int dragSelectX;
        private int dragSelectY;
        private int scrollStartX;
        private int scrollStartY;
        private int scrollSelectX;
        private int scrollSelectY;
        private int scrollDeltaX;
        private int scrollDeltaY;
        private List<LinkConnection> connections = new List<LinkConnection>();
        private List<REBaseItem> selectedItems = new List<REBaseItem>();
        private Point nextItemLocation = new Point(0, 0);
        private bool modified = false;

        public RELinkPanel()
        {
            InitializeComponent();
        }

        #region Items

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            REBaseItem? Item = e.Control as REBaseItem;
            if (Item != null)
            {
                modified = true;
                Item.Enter += new EventHandler(Item_Enter);
                Control ItemCaption = Item.Controls["lblCaption"];
                ItemCaption.MouseDown += new MouseEventHandler(ItemCaption_MouseDown);
                ItemCaption.MouseMove += new MouseEventHandler(ItemCaption_MouseMove);
                ItemCaption.MouseUp += new MouseEventHandler(ItemCaption_MouseUp);
                Control ItemResize = Item.Controls["imgItemResize"];
                ItemResize.MouseDown += new MouseEventHandler(ItemResize_MouseDown);
                ItemResize.MouseMove += new MouseEventHandler(ItemResize_MouseMove);
                ItemResize.MouseUp += new MouseEventHandler(ItemResize_MouseUp);
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (e.Control is REBaseItem)
                modified = true;
        }

        public void AddItem(REBaseItem Item, bool FindNextPosition)
        {
            if (FindNextPosition)
            {
                nextItemLocation.X = 0;
                nextItemLocation.Y = 0;
                if (Controls.Count != 0)
                {
                    foreach (REBaseItem Item1 in Controls)
                        if (nextItemLocation.X < Item1.Right)
                            nextItemLocation.X = Item1.Right;
                    nextItemLocation.X += 8;//margin;
                }
                //TODO: if more right than visile width, then down?
            }
            //else assert set by right-click for context menu
            Item.Location = nextItemLocation;
            Controls.Add(Item);
            Item.BringToFront();
            SelectedItem = Item;
            //modified = true;//see ControlAdded
        }

        public REBaseItem? SelectedItem
        {
            get
            {
                return selectedItems.Count == 0 ? null : selectedItems[0] as REBaseItem;
            }
            set
            {
                for (int i = 0; i < selectedItems.Count; i++) (selectedItems[i] as REBaseItem).Selected = false;
                selectedItems.Clear();
                if (value != null)
                {
                    selectedItems.Add(value);
                    (selectedItems[0] as REBaseItem).Selected = true;
                }
            }
        }

        private bool isMouseDown = false;

        void Item_Enter(object? sender, EventArgs e)
        {
            if (!isMouseDown) SelectedItem = sender as REBaseItem;
        }

        public void ClearAllItems()
        {
            connections.Clear();
            selectedItems.Clear();
            Controls.Clear();
            foreach (ColorStockEntry c in ColorStock) c.Count = 0;
            Invalidate(false);
        }

        public void SelectAllItems()
        {
            selectedItems.Clear();
            foreach (REBaseItem Item1 in Controls)
            {
                selectedItems.Add(Item1);
                Item1.Selected = true;
            }
        }

        public void DeleteSelectedItems()
        {
            //TODO: undo?
            REBaseItem[] list = selectedItems.ToArray();
            selectedItems.Clear();
            foreach (REBaseItem item in list) item.Close();
        }

        public bool Modified { get { return modified; } set { modified = value; } }

        private Color StrToColor(string x)
        {
            if (x == "")
                return Color.Black;
            else
                if (x[0] == '$')
                    return Color.FromArgb(
                        Int32.Parse(x.Substring(5, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(x.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(x.Substring(1, 2), System.Globalization.NumberStyles.HexNumber)
                        );
                else
                    return Color.FromName(x);
        }

        private string ColorToStr(Color color)
        {
            return String.Format("${2:X2}{1:X2}{0:X2}", color.R, color.G, color.B);
        }

        const string REClipboardFormat = "RE_CLIPBOARD_DATA_2_0";

        internal bool CanLoadClipboard()
        {
            return Clipboard.GetDataObject().GetDataPresent(REClipboardFormat);
        }

        internal int SaveClipboard(bool deleteSelectedItems)
        {
            int itemcount = 0;// = selectedItems.Count;
            Cursor = Cursors.WaitCursor;
            try
            {
                XmlDocument xdoc = new();
                xdoc.PreserveWhitespace = true;
                xdoc.LoadXml("<reClipboardData version=\"2.0\" />");
                XmlElement? xroot = xdoc.DocumentElement;

                if(xroot!=null)
                    itemcount = SaveItems(xroot, true);

                //TODO: extract and concat text from items?
                Clipboard.SetData(REClipboardFormat, xdoc.OuterXml);
                if (deleteSelectedItems) DeleteSelectedItems();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return itemcount;
        }

        internal int LoadClipboard(bool findLocation, Hashtable knownItemTypes)
        {
            int itemcount;// = selectedItems.Count;
            Cursor = Cursors.WaitCursor;
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.PreserveWhitespace = true;
                string? clipboarddata = Clipboard.GetData(REClipboardFormat) as string;
                XmlElement? xroot = null;
                if (clipboarddata != null)
                {
                    xdoc.LoadXml(clipboarddata);
                    xroot = xdoc.DocumentElement;
                }
                if (xroot == null)
                    throw new Exception("Clipboard does not contain RE clipboard data");
                if (findLocation) nextItemLocation = new Point(0, 0);
                itemcount = LoadItems(xroot, knownItemTypes, true, nextItemLocation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return itemcount;
        }

        internal int SaveItems(XmlElement xroot, bool selectedItemsOnly)
        {
            Hashtable links = new Hashtable();
            int linkrc = 1000;
            int itemcount = 0;
            foreach (REBaseItem item in (selectedItemsOnly ? (ICollection)selectedItems : (ICollection)Controls))
            {
                XmlElement xitem = xroot.OwnerDocument.CreateElement("item");
                foreach (REItemAttribute r in (item.GetType().GetCustomAttributes(typeof(REItemAttribute), true)))
                    xitem.SetAttribute("class", r.SystemName);
                item.SaveToXml(xitem);
                if (!selectedItemsOnly) item.Modified = false;
                itemcount++;

                foreach (RELinkPoint linkpoint in item.GetLinkPoints(true))
                {
                    string? linkref;
                    if (links.Contains(linkpoint))
                    {
                        linkref = links[linkpoint] as string;
                        links.Remove(linkpoint);
                    }
                    else
                    {
                        //TODO: use GUID and try to restore on paste?
                        linkref = String.Format("lp{0}", linkrc++);
                        if (linkpoint.ConnectedTo != null)
                            links.Add(linkpoint.ConnectedTo, linkref);
                    }
                    XmlElement xlink = xroot.OwnerDocument.CreateElement("link");
                    xlink.SetAttribute("name", linkpoint.Key);
                    xlink.SetAttribute("ref", linkref);
                    if (!selectedItemsOnly)
                        xlink.SetAttribute("color", ColorToStr(linkpoint.ConnectionColor));
                    xitem.AppendChild(xlink);
                }
                xroot.AppendChild(xitem);
            }
            return itemcount;
        }

        internal int LoadItems(XmlElement xroot, Hashtable knownItemTypes, bool addItems, Point delta)
        {
            Hashtable links = new Hashtable();
            Hashtable itemlinks = new Hashtable();
            bool itemlinkslisted;
            List<REBaseItem> items = new List<REBaseItem>();
            Point mosttopleft = new Point(0, 0);

            Visible = false;
            //SuspendLayout();
            try
            {
                if (addItems)
                {
                    //add to items, find suitable location when none provided
                    if (delta.X == 0 && delta.Y == 0 && Controls.Count != 0)
                    {
                        foreach (REBaseItem item in Controls)
                            if (delta.X < item.Right) delta.X = item.Right;
                        delta.X += 8;//margin
                    }
                    //unselect current selection
                    foreach (REBaseItem item in selectedItems) item.Selected = false;
                    selectedItems.Clear();
                }
                else
                {
                    //load from file
                    ClearAllItems();
                }

                foreach (XmlNode xitem in xroot.ChildNodes)
                {
                    XmlElement? e = xitem as XmlElement;
                    if (e!=null && e.Name == "item")
                    {
                        string sysname = e.GetAttribute("class");
                        REItemType? itemtype = knownItemTypes[sysname] as REItemType;
                        if (itemtype == null)
                        {
                            //throw new Exception(String.Format("Unknown item type \"{0}\"", sysname));
                            //TODO: replace by comment? msgbox at end?
                        }
                        else
                        {
                            REBaseItem? item = itemtype.CreateOne();
                            if (item == null)
                                throw new Exception("REBaseItem CreateOne failed");
                            items.Add(item);
                            item.LoadFromXml(e);
                            Controls.Add(item);

                            if (items.Count == 1)
                                mosttopleft = item.Location;
                            else
                            {
                                if (mosttopleft.X > item.Left) mosttopleft.X = item.Left;
                                if (mosttopleft.Y > item.Top) mosttopleft.Y = item.Top;
                            }

                            itemlinkslisted = false;
                            itemlinks.Clear();
                            var l = e.SelectNodes("link");
                            if (l != null)
                                foreach (XmlElement xlink in l)
                                {
                                    string linkref = xlink.GetAttribute("ref");
                                    if (!itemlinkslisted)
                                    {
                                        foreach (RELinkPoint linkpoint in item.GetLinkPoints(false))
                                            itemlinks.Add(linkpoint.Key, linkpoint);
                                        itemlinkslisted = true;
                                    }
                                    if (links.Contains(linkref))
                                    {
                                        //close link
                                        RELinkPoint? lp1 = itemlinks[xlink.GetAttribute("name")] as RELinkPoint;
                                        if (!addItems)
                                            NextLinkColor = StrToColor(xlink.GetAttribute("color"));
                                        //else use link color from stock
                                        if (lp1 != null) lp1.ConnectedTo = links[linkref] as RELinkPoint;
                                        links.Remove(linkref);
                                    }
                                    else
                                        links.Add(linkref, itemlinks[xlink.GetAttribute("name")]);
                                }
                        }
                    }
                    //else ignore? //TODO: keep to save later
                }
                //check all links closed?
                if (!addItems)
                {
                    if (mosttopleft.X > 0) mosttopleft.X = 0;
                    if (mosttopleft.Y > 0) mosttopleft.Y = 0;
                }
                foreach (REBaseItem item in items)
                {
                    item.Selected = addItems;
                    if (addItems) selectedItems.Add(item);
                    item.Location = new Point(item.Left - mosttopleft.X + delta.X, item.Top - mosttopleft.Y + delta.Y);
                }
            }
            finally
            {
                NextLinkColor = Color.Transparent;
                Visible = true;
                //ResumeLayout();
            }
            return items.Count;
        }

        #endregion

        #region Mouse Actions

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isMouseDown = true;
            base.OnMouseDown(e);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    isSelecting = true;
                    dragStartX=e.X;
                    dragStartY=e.Y;
                    dragSelectX = dragStartX;
                    dragSelectY = dragStartY;
                    scrollStartX = dragStartX;
                    scrollStartY = dragStartY;
                    scrollSelectX = dragStartX;
                    scrollSelectY = dragStartY;
                    scrollDeltaX = HorizontalScroll.Value;
                    scrollDeltaY = VerticalScroll.Value;
                    break;
                case MouseButtons.Right:
                    nextItemLocation.X = e.X;
                    nextItemLocation.Y = e.Y;
                    break;
            }
            isMouseDown = false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isSelecting)
            {
                isSelecting = false;
                Invalidate(false);
                bool invertSelect = KeyboardFlags.CtrlPressed;
                //build selection
                if(!invertSelect) SelectedItem = null;
                if (dragSelectX > dragStartX && dragSelectY > dragStartY)
                {
                    //items inside lines
                    foreach (REBaseItem Item in Controls)
                        if (Item.Left >= dragStartX && Item.Top >= dragStartY && Item.Right <= dragSelectX && Item.Bottom <= dragSelectY)
                            if (invertSelect && selectedItems.Contains(Item))
                            {
                                selectedItems.Remove(Item);
                                Item.Selected = false;
                            }
                            else
                            {
                                selectedItems.Add(Item);
                                Item.Selected = true;
                            }
                }
                else
                {
                    //items inside and crossing lines
                    int x1 = Math.Min(dragStartX, dragSelectX);
                    int y1 = Math.Min(dragStartY, dragSelectY);
                    int x2 = Math.Max(dragStartX, dragSelectX);
                    int y2 = Math.Max(dragStartY, dragSelectY);
                    foreach (REBaseItem Item in Controls)
                        if (Item.Left <= x2 && x1 <= Item.Right && Item.Top <= y2 && y1 <= Item.Bottom)
                            if (invertSelect && selectedItems.Contains(Item))
                            {
                                selectedItems.Remove(Item);
                                Item.Selected = false;
                            }
                            else
                            {
                                selectedItems.Add(Item);
                                Item.Selected = true;
                            }
                }
                
                Parent.Focus();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isSelecting)
            {
                dragSelectX = e.X;
                dragSelectY = e.Y;
                if (KeyboardFlags.CtrlPressed)
                {
                    int sx = scrollStartX + scrollDeltaX - e.X;
                    int sy = scrollStartY + scrollDeltaY - e.Y;
                    if (sx < HorizontalScroll.Minimum) sx = HorizontalScroll.Minimum;
                    if (sy < VerticalScroll.Minimum) sy = VerticalScroll.Minimum;
                    if (sx > HorizontalScroll.Maximum) sx = HorizontalScroll.Maximum;
                    if (sy > VerticalScroll.Maximum) sy = VerticalScroll.Maximum;
                    HorizontalScroll.Value = sx;
                    VerticalScroll.Value = sy;
                    dragStartX = scrollSelectX + scrollDeltaX - HorizontalScroll.Value;
                    dragStartY = scrollSelectY + scrollDeltaY - VerticalScroll.Value;
                }
                else
                {
                    scrollStartX = dragSelectX;
                    scrollStartY = dragSelectY;
                    scrollSelectX = dragStartX;
                    scrollSelectY = dragStartY;
                    scrollDeltaX = HorizontalScroll.Value;
                    scrollDeltaY = VerticalScroll.Value;
                }
                Invalidate(false);
            }
        }

        void ItemCaption_MouseDown(object? sender, MouseEventArgs e)
        {
            //TODO: treshold?
            isDragging = true;
            wasDragging = false;
            dragStartX = e.X;
            dragStartY = e.Y;
        }

        void ItemCaption_MouseUp(object? sender, MouseEventArgs e)
        {
            isDragging = false;
            if (!wasDragging)
            {
                var Item = (sender as Control)?.Parent as REBaseItem;
                if (Item != null)
                    if (KeyboardFlags.CtrlPressed)
                    {
                        if (selectedItems.Contains(Item))
                        {
                            selectedItems.Remove(Item);
                            Item.Selected = false;
                        }
                        else
                        {
                            selectedItems.Add(Item);
                            Item.Selected = true;
                        }
                    }
                    else
                    {
                        SelectedItem = Item;
                        Item.ItemSelectFocus();//Item.Focus();
                    }
            }
        }

        void ItemCaption_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                //TODO: dragging treshold
                if (!wasDragging)
                {
                    var Item = (sender as Control)?.Parent as REBaseItem;
                    if (Item != null && !selectedItems.Contains(Item))
                        if (KeyboardFlags.CtrlPressed)
                        {
                            selectedItems.Add(Item);
                            Item.Selected = true;
                        }
                        else
                            SelectedItem = Item;
                }
                wasDragging = true;
                int dx = e.X - dragStartX;
                int dy = e.Y - dragStartY;
                int sx = -HorizontalScroll.Value;
                int sy = -VerticalScroll.Value;
                foreach (REBaseItem Item1 in selectedItems)
                {
                    if (Item1.Left + dx < sx)
                        dx = -Item1.Left + sx;
                    if (Item1.Top + dy < sy)
                        dy = -Item1.Top + sy;
                }
                if (!(dx == 0 && dy == 0))
                {
                    foreach (REBaseItem Item1 in selectedItems)
                        Item1.SetBounds(Item1.Left + dx, Item1.Top + dy, Item1.Width, Item1.Height);
                    modified = true;
                    Invalidate(false);
                }
            }
        }

        void ItemResize_MouseDown(object? sender, MouseEventArgs e)
        {
            //TODO: treshold
            isResizing = true;
            dragStartX = e.X;
            dragStartY = e.Y;
        }

        void ItemResize_MouseUp(object? sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        void ItemResize_MouseMove(object? sender, MouseEventArgs e)
        {
            Control? BaseItem = (sender as Control)?.Parent;
            if (isResizing && BaseItem != null)
            {
                //other items in selection?
                BaseItem.SetBounds(BaseItem.Left, BaseItem.Top, BaseItem.Width + e.X - dragStartX, BaseItem.Height + e.Y - dragStartY);
                modified = true;
                Invalidate(false);
                BaseItem.Invalidate(true);
            }
        }

        #endregion

        #region LinkPoints

        const int ConnectionWidth = 6;
        const int ConnectionHang = 50;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //for each connection linkpoint couple draw arc
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen p = new Pen(Color.Black, ConnectionWidth);
            Point h1;
            Point h2;
            foreach (LinkConnection lc in connections)
            {
                h1 = lc.LinkPoint1.PanelHotSpot;
                h2 = lc.LinkPoint2.PanelHotSpot;
                p.Color = lc.ConnectionColor;
                e.Graphics.DrawBezier(p, h1, new Point(h1.X, h1.Y + ConnectionHang), new Point(h2.X, h2.Y + ConnectionHang), h2);
                //TODO: width tension and hang as settings parameters
            }
            p.Dispose();

            if (isSelecting)
            {
                p = new Pen(SystemColors.HighlightText, 1);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Point[] ps = new Point[4];
                ps[0] = new Point(dragStartX, dragStartY);
                ps[1] = new Point(dragStartX, dragSelectY);
                ps[2] = new Point(dragSelectX, dragSelectY);
                ps[3] = new Point(dragSelectX, dragStartY);
                e.Graphics.DrawPolygon(p, ps);
                p.Dispose();
            }

        }

        private class ColorStockEntry
        {
            public Color Color;
            public int Count;
            public ColorStockEntry(Color c)
            {
                Color = c;
                Count = 0;
            }
        }

        static private ColorStockEntry[] ColorStock =
		{
			new ColorStockEntry(Color.Red),
			new ColorStockEntry(Color.Lime),
			new ColorStockEntry(Color.Blue),
			new ColorStockEntry(Color.Aqua),
			new ColorStockEntry(Color.Fuchsia),
			new ColorStockEntry(Color.Yellow),
			new ColorStockEntry(Color.Brown),
			new ColorStockEntry(Color.Navy),
			new ColorStockEntry(Color.Beige),
			new ColorStockEntry(Color.Orange),

            new ColorStockEntry(Color.SkyBlue),
            new ColorStockEntry(Color.Firebrick),
            new ColorStockEntry(Color.DarkCyan),
			new ColorStockEntry(Color.HotPink),
			new ColorStockEntry(Color.ForestGreen),
            new ColorStockEntry(Color.Cyan),
			new ColorStockEntry(Color.DarkRed),
			new ColorStockEntry(Color.CornflowerBlue),
			new ColorStockEntry(Color.Purple),
			new ColorStockEntry(Color.LightGreen),

			new ColorStockEntry(Color.Gold),
			new ColorStockEntry(Color.PaleTurquoise),
            new ColorStockEntry(Color.Crimson),
			new ColorStockEntry(Color.Teal),
			new ColorStockEntry(Color.SlateGray),
            new ColorStockEntry(Color.AliceBlue),
			new ColorStockEntry(Color.White),
            new ColorStockEntry(Color.LawnGreen),
            new ColorStockEntry(Color.Chocolate),
            new ColorStockEntry(Color.DodgerBlue),

            new ColorStockEntry(Color.PeachPuff),
            new ColorStockEntry(Color.Coral),
            new ColorStockEntry(Color.Khaki),
            new ColorStockEntry(Color.FloralWhite),
            new ColorStockEntry(Color.DarkOliveGreen),
            new ColorStockEntry(Color.Violet),
            new ColorStockEntry(Color.Wheat),
            new ColorStockEntry(Color.Maroon),
            new ColorStockEntry(Color.SpringGreen),
            new ColorStockEntry(Color.Orchid),

            new ColorStockEntry(Color.Lavender),
            new ColorStockEntry(Color.Aquamarine),
            new ColorStockEntry(Color.Olive),
            new ColorStockEntry(Color.SteelBlue),
            new ColorStockEntry(Color.BurlyWood),
            new ColorStockEntry(Color.SeaGreen),
            new ColorStockEntry(Color.PaleGreen),
            new ColorStockEntry(Color.PapayaWhip),
            new ColorStockEntry(Color.CadetBlue),
            new ColorStockEntry(Color.Chartreuse)
		};

        private Color NextLinkColor = Color.Transparent;

        private bool ColorsEqual(Color c1, Color c2)
        {
            return c1.A == c2.A && c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
        }

        //called by linkpoints to report the link
        public void ReportLinkConnect(RELinkPoint LinkPoint1, RELinkPoint LinkPoint2)
        {
            Color c;
            if (NextLinkColor == Color.Transparent)
            {
                //get next color from stock
                ColorStockEntry ce1 = ColorStock[0];
                foreach (ColorStockEntry ce in ColorStock) if (ce.Count < ce1.Count) ce1 = ce;
                c = ce1.Color;
                ce1.Count++;
            }
            else
            {
                c = NextLinkColor;
                NextLinkColor = Color.Transparent;
                foreach (ColorStockEntry ce in ColorStock)
                    if (ColorsEqual(c, ce.Color))
                    {
                        ce.Count++;
                        break;
                    }
            }
            connections.Add(new LinkConnection(LinkPoint1, LinkPoint2, c));
            modified = true;
            Invalidate(false);
            LinkPoint1.Invalidate(false);
            LinkPoint2.Invalidate(false);
        }

        public void ReportLinkDisconnect(RELinkPoint LinkPoint)
        {
            LinkConnection? lc = null;
            foreach (LinkConnection lc1 in connections) if (lc1.LinkPoint1 == LinkPoint || lc1.LinkPoint2 == LinkPoint) lc = lc1;
            if (lc != null)
            {
                //decrease count in color stock
                foreach(ColorStockEntry c in ColorStock)
                    if (ColorsEqual(c.Color, lc.ConnectionColor))
                    {
                        c.Count--;
                        break;
                    }
                connections.Remove(lc);
                //lc.LinkPointX.Connection=null;?
                modified = true;
                Invalidate(false);
                lc.LinkPoint1.Invalidate(false);
                lc.LinkPoint2.Invalidate(false);
            }
        }

        internal event LinkPointSignalEvent? LinkPointSignal;

        public void ReportLinkSignal(RELinkPoint LinkPoint, RELinkPointSignalType Signal, object? Data, bool MoreComing)
        {
            if (LinkPointSignal != null)
                LinkPointSignal(LinkPoint, Signal, Data, MoreComing);
        }

        #endregion

    }

    internal class LinkConnection
    {
        RELinkPoint LP1;
        RELinkPoint LP2;
        Color FConColor;
        public LinkConnection(RELinkPoint LinkPoint1, RELinkPoint LinkPoint2, Color ConnectionColor)
        {
            LP1 = LinkPoint1;
            LP2 = LinkPoint2;
            FConColor = ConnectionColor;

            LP1.ConnectionColor = FConColor;
            LP2.ConnectionColor = FConColor;
            //assert LP1.Connection=LP2 && LP2.Connection=LP1
        }
        public Color ConnectionColor { get { return FConColor; } }
        public RELinkPoint LinkPoint1 { get { return LP1; } }
        public RELinkPoint LinkPoint2 { get { return LP2; } }
    }


}
