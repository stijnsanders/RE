using System;
using System.Collections.Generic;
using System.Drawing;
using RE;

namespace REMulti
{
    [REItem("join", "Join", "Joins multiple inputs")]
    public partial class REJoin : RE.REBaseItem
    {
        private List<REJoinSlot> inputs = new List<REJoinSlot>();

        public REJoin()
        {
            InitializeComponent();
            InputCount = 2;
        }

        private int InputCount
        {
            set
            {
                SuspendLayout();
                for (int i = inputs.Count; i < value; i++)
                {
                    RELinkPoint lp = new();
                    panItemClient.Controls.Add(lp);
                    lp.Caption = String.Format("input {0}", i + 1);
                    lp.Key = String.Format("input{0}", i + 1);
                    lp.Direction = RELinkPointDirection.Input;
                    lp.Bounds = new Rectangle(3, 26 + i * 20, 57, 16);
                    inputs.Add(new REJoinSlot(lp));
                }
                for (int i = inputs.Count - 1; i >= value; i--)
                {
                    var l = inputs[i].LinkPoint;
                    if (l != null)
                    {
                        l.ConnectedTo = null;
                        panItemClient.Controls.Remove(l);
                    }
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
        private bool PassAsItComes;

        public override void Start()
        {
            base.Start();
            SequenceIndex = 0;
            OutputSuspended = false;
            PassAsItComes = passAsItComesToolStripMenuItem.Checked;
            if (lpOutput.ConnectedTo != null)
            {
                foreach (REJoinSlot js in inputs) if (js.Start(this)) OutputSuspended = true;
                if (OutputSuspended) lpOutput.Suspend();
            }
        }

        public override void Stop()
        {
            //assert !OutputSuspended
            if (lpOutput.ConnectedTo != null)
                foreach (REJoinSlot js in inputs) js.Stop();
            base.Stop();
        }

        internal void CheckOutput(bool AllowEmit)
        {
            //assert !(AllowEmit&&OutputSuspended)
            int s1 = SequenceIndex;
            bool allterminated = false;
            if (inputs[SequenceIndex].Terminated)
            {
                do
                {
                    SequenceIndex++;
                    if (SequenceIndex >= inputs.Count) SequenceIndex = 0;
                } while (s1 != SequenceIndex && inputs[SequenceIndex].Terminated);
                allterminated = s1 == SequenceIndex;
            }
            if (allterminated)
            {
                if (OutputSuspended)
                {
                    OutputSuspended = false;
                    lpOutput.Resume();//all done
                }
            }
            else
            {
                if (AllowEmit || OutputSuspended)
                {
                    object? data;
                    bool b = inputs[SequenceIndex].IsReady(out data);
                    if (PassAsItComes && !b)
                        do
                        {
                            SequenceIndex++;
                            if (SequenceIndex >= inputs.Count) SequenceIndex = 0;
                            b = inputs[SequenceIndex].IsReady(out data);
                        } while (!b && s1 != SequenceIndex);
                    if (b && data != null)
                    {
                        if (AllowEmit)
                            lpOutput.Emit(data, true);
                        else
                            if (OutputSuspended)
                        {
                            OutputSuspended = false;
                            lpOutput.Resume(data);
                        }
                        do
                            SequenceIndex++;
                        while (SequenceIndex < inputs.Count && inputs[SequenceIndex].Terminated);
                        if (SequenceIndex >= inputs.Count) SequenceIndex = 0;
                    }
                    else
                        if (!OutputSuspended)
                    {
                        lpOutput.Suspend();
                        OutputSuspended = true;
                    }
                }
            }
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            //assert !OutputSuspended
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
            Element.SetAttribute("passasitcomes", BoolToStr(passAsItComesToolStripMenuItem.Checked));
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            InputCount = Int32.Parse(Element.GetAttribute("inputs"));
            passAsItComesToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("passasitcomes"));
            base.LoadFromXml(Element);
        }

        private class REJoinSlot
        {
            private REJoin? _owner;
            private RELinkPoint? _linkpoint;
            private RELinkPoint? _lpSeqEnd;
            private object? _data;
            private bool _gotdata;
            private bool _registered;
            private bool _terminated;

            public REJoinSlot(RELinkPoint LinkPoint)
            {
                _owner = null;
                _linkpoint = LinkPoint;
                _linkpoint.Signal += new RELinkPointSignal(linkpoint_Signal);
                _data = null;
                _gotdata = false;
                //other see Start
            }

            public RELinkPoint? LinkPoint
            {
                get { return _linkpoint; }
            }

            public bool Terminated
            {
                get { return _terminated && !_gotdata; }
            }

            public bool Start(REJoin Owner)
            {
                _owner = Owner;
                _data = null;
                _gotdata = false;
                _registered = false;
                if (_linkpoint != null && _linkpoint.ConnectedTo != null)
                {
                    _terminated = false;
                    _lpSeqEnd = new RELinkPoint(_linkpoint.Key + "_sequence_end", _owner);
                    _lpSeqEnd.Signal += new RELinkPointSignal(lpSeqEnd_Signal);
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

            void linkpoint_Signal(RELinkPoint Sender, object? Data)
            {
                //assert Sender==_linkpoint
                if (_owner != null)
                    if (_gotdata)
                        throw new EReException("[Join]A second input received before output sent (" + Sender.Caption + ").");
                    else
                    {
                        if (!_registered)
                        {
                            //register for sequence end signal
                            if (_lpSeqEnd != null)
                                Sender.Emit(_lpSeqEnd);
                            _registered = true;
                        }
                        _data = Data;
                        _gotdata = true;
                        if (!_owner.PassAsItComes && _linkpoint != null) _linkpoint.Suspend();
                        _owner.CheckOutput(false);
                    }
            }

            void lpSeqEnd_Signal(RELinkPoint Sender, object? Data)
            {
                _registered = false;
                _terminated = true;
                if (_owner != null)
                    _owner.CheckOutput(false);
            }

            public bool IsReady(out object? Data)
            {
                if (_gotdata)
                {
                    Data = _data;
                    _data = null;
                    _gotdata = false;
                    if (_owner != null && _linkpoint != null && !_owner.PassAsItComes) _linkpoint.Resume();
                    return true;
                }
                else
                {
                    Data = null;
                    return false;
                }
            }

        }

        private void passAsItComesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passAsItComesToolStripMenuItem.Checked = !passAsItComesToolStripMenuItem.Checked;
        }
    }
}