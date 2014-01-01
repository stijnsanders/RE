using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("sort", "Sort", "Sort the items of a multiple input.")]
    public partial class RESort : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch1;
        private RE.RELinkPointPatch patch2;

        public RESort()
        {
            InitializeComponent();
            patch1 = new RELinkPointPatch(lpInput, lpOutput);
            patch2 = new RELinkPointPatch(lpPrepare, lpSortBy);
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            ignoreCaseToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("ignorecase"));
            numericToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("numeric"));
            descendingToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("descending"));
            allowDuplicatesToolStripMenuItem.Checked=StrToBool(Element.GetAttribute("allowduplicates"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("ignorecase", BoolToStr(ignoreCaseToolStripMenuItem.Checked));
            Element.SetAttribute("numeric", BoolToStr(numericToolStripMenuItem.Checked));
            Element.SetAttribute("descending", BoolToStr(descendingToolStripMenuItem.Checked));
            Element.SetAttribute("allowduplicates", BoolToStr(allowDuplicatesToolStripMenuItem.Checked));
        }

        private bool _preparing;
        private object _prepareData;
        private bool _outputting;
        private SortedDictionary<string, object> _data;
        private List<object> _outputData;
        private int _outputIndex;
        private bool _registered;

        private class RESortComparer : Comparer<string>
        {
            internal RESortComparer(bool IgnoreCase, bool Numeric, bool Descending, bool AllowDuplicates)
            {
                _ignorecase = IgnoreCase;
                _numeric = Numeric;
                _descending = Descending;
                _allowdup = AllowDuplicates;
            }

            private bool _ignorecase;
            private bool _numeric;
            private bool _descending;
            private bool _allowdup;

            public override int Compare(string x, string y)
            {
                int r;
                if (_numeric)
                {
                    Int64 a = Convert.ToInt64(x);
                    Int64 b = Convert.ToInt64(y);
                    if (a < b)
                        r = -1;
                    else
                        if (a == b)
                            r = 0;
                        else
                            r = 1;
                }
                else
                    r = String.Compare(x, y, _ignorecase);
                if (_allowdup && r == 0) r = 1;//dirty fix perhaps, but it works
                if (_descending) return -r; else return r;
            }
        }

        public override void Start()
        {
            base.Start();
            _preparing = false;
            _prepareData = null;
            _outputting = false;
            _data = null;
            _registered = false;
        }

        public override void Stop()
        {
            base.Stop();
            _data = null;
            _outputData = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (_preparing || _outputting)
                throw new EReUnexpectedInputException(lpInput);
            else
                if (lpOutput.IsConnected)
                {
                    if (!_registered)
                    {
                        //register sequence end
                        lpOutput.Emit(lpOutput);
                        _registered = true;
                    }
                    if (_data == null)
                        _data = new SortedDictionary<string, object>(new RESortComparer(
                            ignoreCaseToolStripMenuItem.Checked,
                            numericToolStripMenuItem.Checked,
                            descendingToolStripMenuItem.Checked,
                            allowDuplicatesToolStripMenuItem.Checked));
                    if (lpPrepare.IsConnected)
                    {
                        _preparing = true;
                        _prepareData = Data;
                        lpPrepare.Emit(Data, true);
                    }
                    else
                        _data.Add(Data.ToString(), Data);
                }
        }

        private void lpSortBy_Signal(RELinkPoint Sender, object Data)
        {
            if (_preparing)
            {
                _preparing = false;
                _data.Add(Data.ToString(), _prepareData);
                _prepareData = null;
            }
            else
                throw new EReUnexpectedInputException(lpSortBy);
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            if (_outputting)
                OutputNext();
            else
                if (_preparing)
                    throw new EReUnexpectedInputException(lpOutput);
                else
                {
                    _registered = false;
                    _outputting = true;
                    _outputIndex = 0;
                    _outputData = new List<object>(_data.Values);
                    _data = null;
                    OutputNext();
                }
        }

        private void lpPrepare_Signal(RELinkPoint Sender, object Data)
        {
            if (_preparing)
            {
                //prepare to sortby track didn't post to sortby, cancel preparing and drop input?
                _preparing = false;
            }
            //else OK! (assert _preparing set to false by lpSortBy_Signal)
        }

        private void OutputNext()
        {
            //assert _outputting
            if (_outputIndex < _outputData.Count)
            {
                lpOutput.Emit(_outputData[_outputIndex], true);
                _outputIndex++;
            }
            else
                _outputting = false;
        }

        private void ignoreCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ignoreCaseToolStripMenuItem.Checked = !ignoreCaseToolStripMenuItem.Checked;
            Modified = true;
        }

        private void numericToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numericToolStripMenuItem.Checked = !numericToolStripMenuItem.Checked;
            Modified = true;
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            descendingToolStripMenuItem.Checked = !descendingToolStripMenuItem.Checked;
            Modified = true;
        }

        private void allowDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowDuplicatesToolStripMenuItem.Checked = !allowDuplicatesToolStripMenuItem.Checked;
            Modified = true;
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch1.Disconnect();
            patch2.Disconnect();
        }

    }
}