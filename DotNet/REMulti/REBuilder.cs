using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("builder", "Builder", "Repeats most recent data for each input on selected inputs")]
    public partial class REBuilder : REBaseItem
    {
        private List<REBuilderSlot> inputs = new();

        public REBuilder()
        {
            InitializeComponent();
            InputCount = 2;
            lpOutput.Signal += new RELinkPointSignal(lpOutput_Signal);
        }

        private int InputCount
        {
            set
            {
                SuspendLayout();
                for (int i = inputs.Count; i < value; i++)
                {
                    RELinkPoint lp = new RELinkPoint();
                    panItemClient.Controls.Add(lp);
                    lp.Caption = String.Format("input {0}", i + 1);
                    lp.Key = String.Format("input{0}", i + 1);
                    lp.Direction = RELinkPointDirection.Input;
                    lp.Bounds = new Rectangle(3, 26 + i * 20, 57, 16);
                    //lp.signal
                    CheckBox cb = new CheckBox();
                    panItemClient.Controls.Add(cb);
                    cb.Text = "";
                    cb.Checked = true;
                    cb.Bounds = new Rectangle(64, 26 + i * 20, 16, 16);
                    inputs.Add(new REBuilderSlot(lp, cb));
                }
                for (int i = inputs.Count - 1; i >= value; i--)
                {
                    inputs[i].LinkPoint.ConnectedTo = null;
                    panItemClient.Controls.Remove(inputs[i].LinkPoint);
                    panItemClient.Controls.Remove(inputs[i].CheckBox);
                    inputs.RemoveAt(i);
                }
                ResumeLayout();
                Invalidate(false);//some border-line get garbled?
                Height = 50 + inputs.Count * 20;
            }
            get
            {
                return inputs.Count;
            }
        }

        private bool OutputSuspended;
        private List<List<object>>? SendQueue;
        private int SendIndex;

        public override void Start()
        {
            base.Start();
            OutputSuspended = false;
            SendIndex = 0;
            SendQueue = new List<List<object>>();
            if (lpOutput.ConnectedTo != null)
            {
                int count = 0;
                foreach (REBuilderSlot ss in inputs) if (ss.Start(this)) count++;
                if (count != 0)
                {
                    OutputSuspended = true;
                    lpOutput.Suspend();
                }
            }
        }

        public override void Stop()
        {
            foreach (REBuilderSlot ss in inputs) ss.Stop();
            base.Stop();
        }

        internal void CheckOutput()
        {
            if (lpOutput.ConnectedTo != null && SendQueue!=null && SendQueue.Count != 0)
            {
                if (SendIndex == SendQueue[0].Count)
                {
                    SendQueue.RemoveAt(0);
                    SendIndex = 0;
                }
                //TODO if SendQueue.Count==0: suspend lpOutput again, also follow EndSeq in all inputs (!)
                if (SendQueue.Count != 0)
                {
                    if (OutputSuspended)
                    {
                        OutputSuspended = false;
                        lpOutput.Resume(SendQueue[0][SendIndex]);
                    }
                    else
                        lpOutput.Emit(SendQueue[0][SendIndex], true);
                }
            }
        }

        internal void QueueData()
        {
            List<object> entry = new List<object>();
            foreach (REBuilderSlot ss in inputs) if (ss.Data != null) entry.Add(ss.Data);
            //assert entry.Count>1
            if (SendQueue != null)
                SendQueue.Add(entry);
            if (OutputSuspended) CheckOutput();
        }

        void lpOutput_Signal(RELinkPoint Sender, object? Data)
        {
            if (SendQueue != null && SendQueue.Count != 0) SendIndex++;
            CheckOutput();
        }

        private void btnPlus_Click(object? sender, EventArgs e)
        {
            InputCount = InputCount + 1;
        }

        private void btnMinus_Click(object? sender, EventArgs e)
        {
            if (InputCount > 2) InputCount = InputCount - 1;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("inputs", InputCount.ToString());
            for (int i = 0; i < InputCount; i++)
                if (inputs[i].CheckBox.Checked)
                {
                    System.Xml.XmlElement emit = Element.OwnerDocument.CreateElement("emit");
                    emit.SetAttribute("id", Convert.ToString(i + 1));
                    Element.AppendChild(emit);
                }
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            InputCount = Int32.Parse(Element.GetAttribute("inputs"));
            base.LoadFromXml(Element);
            foreach (REBuilderSlot ss in inputs) ss.CheckBox.Checked = false;
            var l = Element.SelectNodes("emit");
            if (l != null)
                foreach (System.Xml.XmlNode x in l)
                    inputs[Convert.ToInt32(x.Attributes?["id"]?.Value) - 1].CheckBox.Checked = true;
        }

        private class REBuilderSlot
        {
            private REBuilder? _owner;
            private RELinkPoint _linkpoint;
            private CheckBox _checkbox;
            private object? _data;

            public REBuilderSlot(RELinkPoint LinkPoint, CheckBox CheckBox)
            {
                _owner = null;
                _linkpoint = LinkPoint;
                _linkpoint.Signal += new RELinkPointSignal(_linkpoint_Signal);
                _checkbox = CheckBox;
                _data = null;
            }

            public RELinkPoint LinkPoint
            {
                get { return _linkpoint; }
            }

            public CheckBox CheckBox
            {
                get { return _checkbox; }
            }

            public object? Data
            {
                get { return _data; }
            }

            public bool Start(REBuilder Owner)
            {
                _owner = Owner;
                _data = null;
                return _linkpoint.ConnectedTo != null;
            }

            public void Stop()
            {
                //clean-up
                _owner = null;
                _data = null;
            }

            void _linkpoint_Signal(RELinkPoint Sender, object? Data)
            {
                if (_owner!=null && _owner.lpOutput.ConnectedTo != null)
                {
                    _data = Data;
                    if (_checkbox.Checked) _owner.QueueData();
                }
            }
        }
    }
}