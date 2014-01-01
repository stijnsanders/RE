using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("sequence", "Sequence", "Sequences multiple inputs")]
    public partial class RESequence : RE.REBaseItem
    {
        private List<RESequenceSlot> inputs = new List<RESequenceSlot>();

        public RESequence()
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
                    inputs.Add(new RESequenceSlot(lp));
                }
                for (int i = inputs.Count - 1; i >= value; i--)
                {
                    inputs[i].LinkPoint.ConnectedTo = null;
                    panItemClient.Controls.Remove(inputs[i].LinkPoint);
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

        private int SequenceIndex;
        private bool OutputSuspended;

        public override void Start()
        {
            base.Start();
            SequenceIndex = 0;
            OutputSuspended = false;
            foreach (RESequenceSlot ss in inputs) if (ss.Start(this)) OutputSuspended = true;
            if (OutputSuspended) lpOutput.Suspend();
        }

        public override void Stop()
        {
            //assert !OutputSuspended
            foreach (RESequenceSlot ss in inputs) ss.Stop();
            base.Stop();
        }

        internal void CheckOutput(bool AllowEmit)
        {
            //assert !(AllowEmit&&OutputSuspended)
            while (SequenceIndex < inputs.Count && inputs[SequenceIndex].Terminated) SequenceIndex++;
            if (SequenceIndex < inputs.Count)
            {
                if (AllowEmit || OutputSuspended)
                {
                    object data;
                    if (inputs[SequenceIndex].IsReady(out data))
                    {
                        if (AllowEmit)
                            lpOutput.Emit(data, true);
                        else
                            if (OutputSuspended)
                            {
                                OutputSuspended = false;
                                lpOutput.Resume(data);
                            }
                    }
                    else
                    {
                        if (AllowEmit && !OutputSuspended)
                        {
                            OutputSuspended = true;
                            lpOutput.Suspend();
                        }
                    }
                }
            }
            else
                if (OutputSuspended)
                {
                    OutputSuspended = false;
                    lpOutput.Resume();
                }
        }

        void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            CheckOutput(true);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            InputCount = InputCount + 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (InputCount > 2) InputCount = InputCount - 1;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("inputs", InputCount.ToString());
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            InputCount = Int32.Parse(Element.GetAttribute("inputs"));
            base.LoadFromXml(Element);
        }

        private class RESequenceSlot
        {
            private RESequence _owner;
            private RELinkPoint _linkpoint;
            private RELinkPoint _lpSeqEnd;
            private object _data;
            private bool _registered;
            private bool _terminated;
            private bool _suspended;

            public RESequenceSlot(RELinkPoint LinkPoint)
            {
                _owner = null;
                _linkpoint = LinkPoint;
                _linkpoint.Signal += new RELinkPointSignal(_linkpoint_Signal);
                _data = null;
            }

            public RELinkPoint LinkPoint
            {
                get { return _linkpoint; }
            }

            public Boolean Terminated
            {
                get { return _terminated; }
            }

            public bool Start(RESequence Owner)
            {
                _owner = Owner;
                _registered = false;
                _suspended = false;
                _data = null;
                if (_linkpoint.IsConnected)
                {
                    _terminated = false;
                    _lpSeqEnd = new RELinkPoint(_linkpoint.Key + "_sequence_end", _owner);
                    _lpSeqEnd.Signal += new RELinkPointSignal(_lpSeqEnd_Signal);
                }
                else
                    _terminated = true;
                return !_terminated;
            }

            public void Stop()
            {
                //clean-up
                _owner = null;
                _data = null;
                _lpSeqEnd = null;
            }

            void _linkpoint_Signal(RELinkPoint Sender, object Data)
            {
                //assert _linkpoint==Sender
                if (_terminated)
                    throw new EReException("[Sequence]A new sequence started on an input, use merge to provide a single sequence per input (" + Sender.Caption + ").");
                //TODO: allow multiple sequences (toggle?)
                else
                {
                    if (!_registered)
                    {
                        //register for sequence end signal
                        Sender.Emit(_lpSeqEnd);
                        _registered = true;
                    }
                    _data = Data;
                    _suspended = true;
                    Sender.Suspend();
                    _owner.CheckOutput(false);
                }
            }

            void _lpSeqEnd_Signal(RELinkPoint Sender, object Data)
            {
                _registered = false;
                _terminated = true;
                _owner.CheckOutput(false);
            }

            public bool IsReady(out object Data)
            {
                if (_suspended)
                {
                    _linkpoint.Resume();
                    _suspended = false;
                    Data = _data;
                    _data = null;
                    return true;
                }
                else
                {
                    Data = null;
                    return false;
                }
            }
        }
    }
}

