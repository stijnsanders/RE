using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Runtime.InteropServices; //used by GetFocus

namespace RE
{
    internal partial class REMainForm : Form
    {
        public REMainForm()
        {
            InitializeComponent();
            reLinkPanel1.LinkPointSignal += new LinkPointSignalEvent(reLinkPanel1_LinkPointSignal);
        }

        private void exitToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private bool ClassIsLibraryRegistry(Type m, object? filterCriteria)
        {
            return m.IsSubclassOf(typeof(RELibraryRegistry));
        }

        private bool ClassIsBaseItem(Type m, object? filterCriteria)
        {
            return m.IsSubclassOf(typeof(REBaseItem));
        }

        internal static void AddToMenu(RELibraryMenuItem NewMenuItem, ToolStripMenuItem ParentMenuItem)
        {
            if (ParentMenuItem.DropDownItems.Count == 0)
                ParentMenuItem.DropDownItems.Add(NewMenuItem);
            else
            {
                int i = 0;
                while (i < ParentMenuItem.DropDownItems.Count &&
                    NewMenuItem.Precedence > (ParentMenuItem.DropDownItems[i] as RELibraryMenuItem)?.Precedence) i++;
                if (i < ParentMenuItem.DropDownItems.Count)
                    ParentMenuItem.DropDownItems.Insert(i, NewMenuItem);
                else
                    ParentMenuItem.DropDownItems.Add(NewMenuItem);
            }
        }

        internal static void AddSeparators(ToolStripMenuItem MenuItem)
        {
            if (MenuItem.DropDownItems.Count != 0)
            {
                int i = 0;
                int p = -1;
                int q;
                while (i < MenuItem.DropDownItems.Count)
                {
                    RELibraryMenuItem? m = MenuItem.DropDownItems[i] as RELibraryMenuItem;
                    if (m != null)
                    {
                        q = p;
                        p = m.Precedence;
                        if (q != -1 && p / 100 > q / 100) MenuItem.DropDownItems.Insert(i++, new ToolStripSeparator());
                    }
                    i++;
                }
            }
        }

        private Hashtable KnownItemTypes = new Hashtable();
        private bool PopupPointKnown;
        private bool OutputDebugLog = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RELibraryRegistry.ItemAdded += new RELibraryAddition(RELibraryRegistry_ItemAdded);

            //TODO: other path(s) from setting?
            var p = Path.GetDirectoryName(Application.ExecutablePath);
            if (p == null) p = "InvalidExecutablePath";
            DirectoryInfo LibraryPath = new DirectoryInfo(p);
            foreach (FileInfo f in LibraryPath.GetFiles("RE*.dll"))//something else than dll?
            {
                Assembly a = Assembly.LoadFile(f.FullName);//policy?
                foreach (Module m in a.GetModules(false))
                {
                    foreach (System.Type lregt in m.FindTypes(new TypeFilter(ClassIsLibraryRegistry), null))
                    {
                        var c = lregt.GetConstructor(System.Type.EmptyTypes);
                        RELibraryRegistry? lreg = c?.Invoke(Array.Empty<object>()) as RELibraryRegistry;
                        if (lreg != null)
                        {
                            AddToMenu(lreg.Register(), addToolStripMenuItem);
                            AddToMenu(lreg.Register(), addToolStripMenuItem1);
                        }
                    }

                    foreach (System.Type rbt in m.FindTypes(new TypeFilter(ClassIsBaseItem), null))
                    {
                        foreach (REItemAttribute r in (rbt.GetCustomAttributes(typeof(REItemAttribute), true)))
                        {
                            if (KnownItemTypes.ContainsKey(r.SystemName))
                            {
                                var i = KnownItemTypes[r.SystemName] as REItemType;
                                throw new Exception(String.Format("Item type system names are required to be unique: \"{0}\"\r\n{1}\r\n{2}",
                                    r.SystemName, i?.Module, f.FullName));
                            }
                            else
                                KnownItemTypes.Add(r.SystemName, new REItemType(r, rbt, f.FullName));
                        }
                    }
                }
            }
            AddSeparators(addToolStripMenuItem);
            AddSeparators(addToolStripMenuItem1);

            //command line parameters
            string fn = "";
            string cx;
            string[] cl = System.Environment.GetCommandLineArgs();
            for (int i = 1; i < cl.Length; i++)
            {
                cx = cl[i].ToLower();
                if (cx == "/debug") OutputDebugLog = true;
                else
                    //TODO: auto start option
                    //TODO: close when done option
                    if (fn == "" && File.Exists(cl[i])) fn = cl[i];
                //TODO: concatenate-load others
                //TODO: message unknown parameters?
            }
            if (fn != "")
            {
                try
                {
                    LoadFile(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        void RELibraryRegistry_ItemAdded(REBaseItem Item)
        {
            reLinkPanel1.AddItem(Item, !PopupPointKnown);
        }

        private void REMainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            KeyboardFlags.CtrlPressed = e.Control;
            //KeyboardFlags.AltPressed = e.Alt;
        }

        private void REMainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            KeyboardFlags.CtrlPressed = e.Control;
            //KeyboardFlags.AltPressed = e.Alt;
        }

        private void REMainForm_Deactivate(object? sender, EventArgs e)
        {
            KeyboardFlags.CtrlPressed = false;
        }

        private void addToolStripMenuItem_DropDownOpening(object? sender, EventArgs e)
        {
            PopupPointKnown = false;
        }

        private void addToolStripMenuItem1_DropDownOpening(object? sender, EventArgs e)
        {
            PopupPointKnown = true;
        }

        #region Loading and Saving

        private string filename = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                if (filename == "")
                    Text = "Regular Expression";
                else
                    Text = "RE - " + filename;
            }
        }

        private bool CheckChanges()
        {
            bool b = reLinkPanel1.Modified;
            if (!b)
                foreach (REBaseItem i in reLinkPanel1.Controls)
                    if (i.Modified)
                    {
                        b = true;
                        break;
                    }
            if (b && reLinkPanel1.Controls.Count == 0) b = false;
            if (b)
            {
                switch (MessageBox.Show(this, "Do you want to save changes?", "Regular Expression",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        return SaveFile(false);
                    case DialogResult.No:
                        return true;
                    //case DialogResult.Cancel:
                    default:
                        return false;
                }
            }
            else
                return true;
        }

        private bool SaveFile(bool ForceAskFileName)
        {
            bool filenameok = true;
            if (FileName == "" || ForceAskFileName)
            {
                saveFileDialog1.FileName = FileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    FileName = saveFileDialog1.FileName;
                else
                    filenameok = false;
            }
            if (filenameok)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.PreserveWhitespace = true;
                    xdoc.LoadXml("<reData version=\"2.0\" />");
                    XmlElement? xroot = xdoc.DocumentElement;
                    if (xroot != null)
                    {
                        xroot.SetAttribute("scrollX", reLinkPanel1.HorizontalScroll.Value.ToString());
                        xroot.SetAttribute("scrollY", reLinkPanel1.VerticalScroll.Value.ToString());
                        //TODO: bounds/maximized?
                        reLinkPanel1.SaveItems(xroot, false);
                    }
                    XmlTextWriter xwrt = new XmlTextWriter(FileName, Encoding.UTF8);
                    try
                    {
                        xdoc.Save(xwrt);
                        reLinkPanel1.Modified = false;
                        toolStripStatusLabel3.Text = "File saved: " + filename;
                    }
                    finally
                    {
                        xwrt.Close();
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            return filenameok;
        }

        private void LoadFile(string LoadFileName)
        {
            FileName = LoadFileName;
            Cursor = Cursors.WaitCursor;
            try
            {
                Point scroll = new Point(0, 0);
                XmlDocument xdoc = new XmlDocument();
                xdoc.PreserveWhitespace = true;
                xdoc.Load(FileName);
                XmlElement? xroot = xdoc.DocumentElement;
                if (xroot != null)
                {
                    //TODO: check version?
                    //TODO: bounds/maximized?
                    try
                    {
                        scroll = new Point(
                            Int32.Parse(xroot.GetAttribute("scrollX")),
                            Int32.Parse(xroot.GetAttribute("scrollY")));
                    }
                    catch (FormatException)
                    {
                        //silent, use defaults
                    }

                    reLinkPanel1.LoadItems(xroot, KnownItemTypes, false, new Point(0, 0));
                }

                if (scroll.X < reLinkPanel1.HorizontalScroll.Minimum) scroll.X = reLinkPanel1.HorizontalScroll.Minimum;
                if (scroll.Y < reLinkPanel1.VerticalScroll.Minimum) scroll.Y = reLinkPanel1.VerticalScroll.Minimum;
                if (scroll.X > reLinkPanel1.HorizontalScroll.Maximum) scroll.X = reLinkPanel1.HorizontalScroll.Maximum;
                if (scroll.Y > reLinkPanel1.VerticalScroll.Maximum) scroll.Y = reLinkPanel1.VerticalScroll.Maximum;
                reLinkPanel1.HorizontalScroll.Value = scroll.X;
                reLinkPanel1.VerticalScroll.Value = scroll.Y;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            toolStripStatusLabel3.Text = "File loaded: " + FileName;
            reLinkPanel1.Modified = false;
        }

        private void newToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (CheckChanges())
            {
                if (filename == "" && reLinkPanel1.Controls.Count == 0)
                    MessageBox.Show(this, "A new expression is already started, use Add to add items.", "New", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileName = "";
                reLinkPanel1.Visible = false;
                try
                {
                    reLinkPanel1.ClearAllItems();
                }
                finally
                {
                    reLinkPanel1.Visible = true;
                    reLinkPanel1.Modified = false;
                }
            }
        }

        private void openToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (CheckChanges())
            {
                openFileDialog1.FileName = FileName;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    LoadFile(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFile(false);
        }

        private void saveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFile(true);
        }

        #endregion

        #region Running

        private RunState RunState = RunState.NotRunning;
        private bool CancelPressed = false;
        private bool CloseRequested = false;

        private void runToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (RunState == RunState.NotRunning)
                Run();
            else
                CancelPressed = true;
        }

        private List<RunQueueSlot>? RunQueue;
        private RunQueueEntry? NextRunQueueEntry;
        private bool FireEmitCalled;
        private RELinkPoint? SuspendCalled;
        private StreamWriter? DebugLog = null;

        private static string DebugDisplay(object? Data)
        {
            if (Data == null)
                return "(null)";
            else
            {
                string? x = Data.ToString();
                if (x == null) x = "(null)";
                int y = x.IndexOf("\r\n", 0, Math.Min(x.Length, 128));
                if (x.Length > 128 || y != -1)
                    return x.Substring(0, y == -1 ? 128 : y) + "(" + x.Length.ToString() + ")";
                else
                    return x;
            }
        }

        void reLinkPanel1_LinkPointSignal(RELinkPoint LinkPoint, RELinkPointSignalType Signal, object? Data, bool MoreToCome)
        {
            if (RunQueue == null)
                throw new Exception("No RunQueue currently active");
            if (DebugLog != null) DebugLog.WriteLine("{0}({1}{2}){3}", Signal, LinkPoint, MoreToCome ? "*" : "", DebugDisplay(Data));
            switch (RunState)
            {
                case RunState.Starting:
                    switch (Signal)
                    {
                        case RELinkPointSignalType.Sending:
                            if (Data is RELinkPoint)
                            {
                                //another RELinkPoint is emitted to get the sequence end signalled
                                throw new EReException("Emitting LinkPoints on when starting is not supported.");
                            }
                            else
                            {
                                if (LinkPoint.ConnectedTo != null)
                                    RunQueue.Add(new RunQueueSlot(
                                        new RunQueueEntry(LinkPoint.ConnectedTo, Data,
                                            MoreToCome ? new RunQueueEntry(LinkPoint, null, null) : null), null));
                            }
                            break;
                        case RELinkPointSignalType.Suspending:
                            //assert Data==null
                            if (LinkPoint.ConnectedTo != null)
                                RunQueue.Add(new RunQueueSlot(
                                    new RunQueueEntry(LinkPoint, null, null), LinkPoint));
                            break;
                        case RELinkPointSignalType.Resuming:
                            throw new EReException("LinkPoint can't resume when starting.");
                    }
                    break;
                case RunState.Running:
                    switch (Signal)
                    {
                        case RELinkPointSignalType.Sending:
                            var d = Data as RELinkPoint;
                            if (d != null)
                            {
                                //another RELinkPoint is emitted to get the sequence end signalled
                                if (NextRunQueueEntry == null)
                                    //throw new EReException("No sequence started to signal end for.");//?
                                    NextRunQueueEntry = new RunQueueEntry(d, null, null);
                                else
                                    NextRunQueueEntry.PostReportBack(d, null);
                            }
                            else
                            {
                                if (FireEmitCalled)
                                    throw new EReException("Don't call Emit more than once when processing a Signal.");
                                if (SuspendCalled != null)
                                    throw new EReException("Can't Emit after Suspend.");
                                FireEmitCalled = true;
                                if (LinkPoint.ConnectedTo != null)
                                    NextRunQueueEntry = new RunQueueEntry(LinkPoint.ConnectedTo, Data,
                                        MoreToCome ? new RunQueueEntry(LinkPoint, null, NextRunQueueEntry) : NextRunQueueEntry);
                            }
                            break;
                        case RELinkPointSignalType.Suspending:
                            //assert Data==null
                            if (SuspendCalled != null)
                                throw new EReException("Don't call Suspend more then once when processing a Signal.");
                            foreach (RunQueueSlot rqs1 in RunQueue)
                                if (rqs1.Reserved == LinkPoint)
                                    throw new EReException("LinkPoint is trying to suspend but was suspended already.");
                            SuspendCalled = LinkPoint;
                            break;
                        case RELinkPointSignalType.Resuming:
                            if (Data is RELinkPoint)
                                throw new EReException("Can't resume and send a RELinkPoint.");
                            if (SuspendCalled == LinkPoint)
                            {
                                SuspendCalled = null;
                                if (LinkPoint.ConnectedTo != null)
                                    NextRunQueueEntry = new RunQueueEntry(LinkPoint.ConnectedTo, Data,
                                        MoreToCome ? new RunQueueEntry(LinkPoint, null, NextRunQueueEntry) : NextRunQueueEntry);
                            }
                            else
                            {
                                RunQueueSlot? rqs = null;
                                foreach (RunQueueSlot rqs1 in RunQueue)
                                    if (rqs1.Reserved == LinkPoint)
                                    {
                                        rqs = rqs1;
                                        break;
                                    }
                                if (rqs == null)
                                    throw new EReException("LinkPoint is trying to resume but wasn't suspended.");
                                rqs.Reserved = null;
                                if (MoreToCome && LinkPoint.ConnectedTo != null)
                                    rqs.Entry = new RunQueueEntry(LinkPoint.ConnectedTo, Data,
                                        new RunQueueEntry(LinkPoint, null, rqs.Entry));
                                else
                                    if (rqs.Entry == null)
                                    rqs.Entry = new RunQueueEntry(LinkPoint, null, null);
                            }
                            break;
                    }
                    break;
                default:
                    throw new EReException("LinkPoint can't change state when not running.");
            }
        }

        const int StateUpdateMS = 500;

        private void Run()
        {
            //TODO: thread (or multiple threads?)
            int startTC = Environment.TickCount;
            int stateTC = startTC + StateUpdateMS;
            int nowTC;
            int qcount = 0;
            RunQueue = new List<RunQueueSlot>();
            CancelPressed = false;
            string FailMessage = "";
            if (OutputDebugLog)
            {
                DebugLog = new StreamWriter((filename == "" ? "debug" : filename) + ".log", false, Encoding.UTF8);
                DebugLog.AutoFlush = true;//?
            }
            try
            {
                RunState = RunState.Starting;
                toolStripStatusLabel3.Text = "Starting...";
                if (DebugLog != null) DebugLog.WriteLine("RunState.Starting");
                runToolStripMenuItem.Text = "Abort";
                runToolStripMenuItem1.Text = "Abort";
                foreach (REBaseItem item in reLinkPanel1.Controls) item.Start();

                RunState = RunState.Running;
                toolStripStatusLabel3.Text = "Running...";
                if (DebugLog != null) DebugLog.WriteLine("RunState.Running");
                int rindex = 0;
                bool rskipactive = false;
                int rlastactive = 0;
                int rdone = RunQueue.Count;
                while (rdone != 0 && !CancelPressed)
                {
                    RunQueueSlot rqs = RunQueue[rindex];
                    if (rqs.Reserved == null && rqs.Entry != null)
                    {
                        qcount++;
                        RunQueueEntry rqe = rqs.Entry;
                        NextRunQueueEntry = rqs.Entry.ReportBack;
                        //Fire() signals linkpoint, action there may emit on another linkpoint, setting NextRunQueueEntry
                        FireEmitCalled = false;
                        SuspendCalled = null;

                        if (DebugLog != null) DebugLog.WriteLine("{0}:Fire[{1}/{2}]{3}", qcount, rindex, RunQueue.Count, rqe.DebugDisplay);
                        rqe.Fire();
                        rqs.Entry = NextRunQueueEntry;
                        if (SuspendCalled != null) rqs.Reserved = SuspendCalled;
                        if (NextRunQueueEntry == null && SuspendCalled == null) rdone--;
                        rlastactive = rindex;
                        rskipactive = false;
                    }
                    rindex++;
                    if (rindex >= RunQueue.Count) rindex = 0;
                    if (rindex == rlastactive)
                        if (rskipactive)
                        {
                            StringBuilder sb = new StringBuilder("Only suspended LinkPoints left, some item did not resume properly.");
                            foreach (RunQueueSlot rqx in RunQueue)
                                if (rqx.Reserved != null)
                                    sb.Append(String.Format("\r\n{0}", rqx.Reserved.ToString()));
                            throw new EReException(sb.ToString());
                        }
                        else
                            rskipactive = true;
                    nowTC = Environment.TickCount;
                    if (nowTC >= stateTC)
                    {
                        stateTC = nowTC + StateUpdateMS;
                        toolStripStatusLabel1.Text = String.Format("{0} passes", qcount);
                        toolStripStatusLabel2.Text = String.Format("{0:F3} seconds", (nowTC - startTC) / 1000.0);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                //
                if (DebugLog != null) DebugLog.WriteLine(ex);
                FailMessage = ex.ToString();
            }

            RunState = RunState.Stopping;
            toolStripStatusLabel3.Text = "Stopping...";
            if (DebugLog != null)
            {
                DebugLog.WriteLine("RunState.Stopping");
                int rindex = 0;
                foreach (RunQueueSlot rqs in RunQueue)
                    if (rqs.Entry != null && rqs.Reserved != null)
                    {
                        DebugLog.WriteLine("[{0}/{1}]{2}", rindex, RunQueue.Count, rqs.Entry.DebugDisplay);
                        DebugLog.WriteLine(rqs.Reserved.ToString());
                        rindex++;
                    }
            }
            foreach (REBaseItem item in reLinkPanel1.Controls)
            {
                try
                {
                    item.Stop();
                }
                catch
                {
                    //ignore!
                }
            }

            //clean-up
            NextRunQueueEntry = null;
            RunState = RunState.NotRunning;
            if (DebugLog != null)
            {
                DebugLog.WriteLine("RunState.NotRunning");
                DebugLog.Close();
                DebugLog = null;
            }
            RunQueue = null;

            toolStripStatusLabel1.Text = String.Format("{0} passes", qcount);
            toolStripStatusLabel2.Text = String.Format("{0:F3} seconds", (Environment.TickCount - startTC) / 1000.0);
            if (CancelPressed)
                toolStripStatusLabel3.Text = "Aborted by user.";
            else
                if (FailMessage == "")
                    toolStripStatusLabel3.Text = "Done.";
                else
                {
                    toolStripStatusLabel3.Text = "Failed.";
                    MessageBox.Show(this, FailMessage, "Run", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            runToolStripMenuItem.Text = "Run";
            runToolStripMenuItem1.Text = "Run";
            if (CloseRequested) Close();
        }

        internal class RunQueueEntry
        {
            private RELinkPoint _linkpoint;
            private object? _data;
            private RunQueueEntry? _reportBack;

            public RunQueueEntry(RELinkPoint LinkPoint, object? Data, RunQueueEntry? ReportBack)
            {
                _data = Data;
                _linkpoint = LinkPoint;
                _reportBack = ReportBack;
            }

            public void Fire()
            {
                _linkpoint.FireSignal(_data);
            }

            public void AddReportBack(RELinkPoint LinkPoint, object Data)
            {
                _reportBack = new RunQueueEntry(LinkPoint, Data, _reportBack);
            }

            public void PostReportBack(RELinkPoint LinkPoint, object? Data)
            {
                RunQueueEntry e = this;
                while (e._reportBack != null) e = e._reportBack;
                e._reportBack = new RunQueueEntry(LinkPoint, Data, null);
            }

            public RunQueueEntry? ReportBack
            {
                get { return _reportBack; }
            }

            internal RELinkPoint LinkPoint
            {
                get { return _linkpoint; }
            }

            internal string DebugDisplay
            {
                get { return String.Format("({0}{2}){1}", _linkpoint, DebugDisplay(_data), _reportBack == null ? "" : "*"); }
            }

        }

        internal class RunQueueSlot
        {
            private RunQueueEntry? _entry;
            private RELinkPoint? _reserved;

            public RunQueueSlot(RunQueueEntry Entry, RELinkPoint? Reserved)
            {
                _entry = Entry;
                _reserved = Reserved;
            }

            internal RunQueueEntry? Entry
            {
                get { return _entry; }
                set { _entry = value; }
            }

            internal RELinkPoint? Reserved
            {
                get { return _reserved; }
                set { _reserved = value; }
            }
        }

        #endregion

        private void REMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (RunState != RunState.NotRunning)
            {
                if (MessageBox.Show(this, "Expression is still running, do you want to stop it?", "Close",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CancelPressed = true;
                    CloseRequested = true;
                }
                e.Cancel = true;
            }
            else
                if (!CheckChanges()) e.Cancel = true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        internal Control? GetFocusControl()
        {
            Control? focusControl = null;
            IntPtr focusHandle = GetFocus();
            if (focusHandle != IntPtr.Zero)
                // returns null if handle is not to a .NET control
                focusControl = Control.FromHandle(focusHandle);
            return focusControl;
        }

        private void selectAllToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            TextBoxBase? c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.SelectAll();
            else
                reLinkPanel1.SelectAllItems();
        }

        private void deleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            //TODO: Del shortcut and if GetFocusControl is TextBoxBase
            reLinkPanel1.DeleteSelectedItems();
        }

        private void cutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.Cut();
            else
            {
                int x = reLinkPanel1.SaveClipboard(true);
                toolStripStatusLabel3.Text = String.Format("{0} items cut to clipboard", x);
            }
        }

        private void copyToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.Copy();
            else
            {
                int x = reLinkPanel1.SaveClipboard(false);
                toolStripStatusLabel3.Text = String.Format("{0} items copied to clipboard", x);
            }
        }

        private void pasteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.Paste();
            else
            {
                int x = reLinkPanel1.LoadClipboard(true, KnownItemTypes);
                toolStripStatusLabel3.Text = String.Format("{0} items pasted from clipboard", x);
            }
        }

        private void undoToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.Undo();
            //TODO: else reLinkPanel1.Undo();
        }

        private void redoToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var c = GetFocusControl() as TextBoxBase;
            if (c != null)
                c.Undo();//TextBoxBase doesn't have Redo()?
            //TODO: else reLinkPanel1.Redo();
        }

        private void contextMenuStrip1_Opening(object? sender, CancelEventArgs e)
        {
            pasteToolStripMenuItem2.Visible = reLinkPanel1.CanLoadClipboard();
        }

        private void pasteToolStripMenuItem2_Click(object? sender, EventArgs e)
        {
            int x = reLinkPanel1.LoadClipboard(false, KnownItemTypes);
            toolStripStatusLabel3.Text = String.Format("{0} items pasted from clipboard", x);
        }

        private void pasteFromToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    string filename1 = openFileDialog1.FileName;
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.PreserveWhitespace = true;
                    xdoc.Load(filename1);
                    XmlElement? xroot = xdoc.DocumentElement;
                    //TODO: check version?
                    int i = xroot == null ? 0 : reLinkPanel1.LoadItems(xroot, KnownItemTypes, true, new Point(0, 0));
                    toolStripStatusLabel3.Text = String.Format("Pasted {0} items from: {1}", i, filename1);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void copyToToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    string filename1 = saveFileDialog1.FileName;
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.PreserveWhitespace = true;
                    xdoc.LoadXml("<reData version=\"2.0\" />");
                    XmlElement? xroot = xdoc.DocumentElement;
                    int i = 0;
                    if (xroot != null)
                    {
                        xroot.SetAttribute("scrollX", reLinkPanel1.HorizontalScroll.Value.ToString());
                        xroot.SetAttribute("scrollY", reLinkPanel1.VerticalScroll.Value.ToString());
                        //TODO: bounds/maximized?
                        i = reLinkPanel1.SaveItems(xroot, true);
                    }
                    XmlTextWriter xwrt = new XmlTextWriter(filename1, Encoding.UTF8);
                    try
                    {
                        xdoc.Save(xwrt);
                        toolStripStatusLabel3.Text = String.Format("Copied {0} items to: {1}", i, filename1);
                    }
                    finally
                    {
                        xwrt.Close();
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void REMainForm_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
                e.Effect = DragDropEffects.Copy;
        }

        private void REMainForm_DragDrop(object? sender, DragEventArgs e)
        {
            if (CheckChanges())
            {
                var d = e.Data?.GetData(DataFormats.FileDrop);
                if (d != null)
                    LoadFile(((string[])d)[0]);
            }
        }

    }

    internal class KeyboardFlags
    {
        static public bool CtrlPressed = false;
    }

    internal enum RunState
    {
        NotRunning,
        Starting,
        Running,
        Stopping
    }
}