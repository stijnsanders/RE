using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("repeat", "Repeat", "Repeats the input by the items of the index input")]
    public partial class RERepeat : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch1;
        private RE.RELinkPointPatch patch2;

        public RERepeat()
        {
            InitializeComponent();
            patch1 = new RELinkPointPatch(lpIndex, lpEcho);
            patch2 = new RELinkPointPatch(lpInput, lpOutput);
        }

        private bool hasRequiredConnections;
        private object repeatData;
        private object echoData;
        private int isRepeating;
        // 0: no
        // 1: yes but no index yet
        // 2: yes and waiting for output back 
        private bool passAsItComes;
        private bool indexSeqEndRegistered;
        private RELinkPoint indexSeqEnd;

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            passAsItComesToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("passasitcomes"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("passasitcomes", BoolToStr(passAsItComesToolStripMenuItem.Checked));
        }

        public override void Start()
        {
            base.Start();
            hasRequiredConnections = lpInput.IsConnected && lpOutput.IsConnected && lpIndex.IsConnected;
            isRepeating = 0;
            repeatData = null;
            echoData = null;
            passAsItComes = passAsItComesToolStripMenuItem.Checked;
            indexSeqEndRegistered = false;
            indexSeqEnd = new RELinkPoint("index_sequence_end", this);
            indexSeqEnd.Signal += new RELinkPointSignal(indexSeqEnd_Signal);
            if (hasRequiredConnections) lpOutput.Suspend();
        }

        public override void Stop()
        {
            base.Stop();
            indexSeqEnd = null;
            repeatData = null;
            echoData = null;
        }

        private void lpIndex_Signal(RELinkPoint Sender, object Data)
        {
            if (hasRequiredConnections)
            {
                if (!indexSeqEndRegistered)
                {
                    lpIndex.Emit(indexSeqEnd);
                    indexSeqEndRegistered = true;
                }
                if (isRepeating == 1)
                {
                    isRepeating = 2;
                    lpOutput.Resume(repeatData);
                    lpEcho.Emit(Data);
                }
                else
                {
                    echoData = Data;
                    lpEcho.Suspend();
                }
            }
        }

        private void indexSeqEnd_Signal(RELinkPoint Sender, object Data)
        {
            indexSeqEndRegistered = false;
            repeatData = null;
            if (isRepeating != 2) lpOutput.Resume();
            if (isRepeating != 0 && !passAsItComes) lpInput.ConnectedTo.Resume();
        }

        private void lpEcho_Signal(RELinkPoint Sender, object Data)
        {
            //
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (hasRequiredConnections)
                if (isRepeating == 0)
                {
                    repeatData = Data;
                    if (echoData == null)
                        isRepeating = 1;
                    else
                    {
                        lpEcho.Resume(echoData);
                        echoData = null;
                        isRepeating = 2;
                        lpOutput.Resume(repeatData);
                    }
                    if (!passAsItComes) lpInput.ConnectedTo.Suspend();
                }
                else
                {
                    if (passAsItComes)
                        repeatData = Data;
                    else
                        throw new EReUnexpectedInputException(lpInput);
                }
            else
                lpOutput.Emit(Data);
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            if (isRepeating == 2)
            {
                if (echoData == null)
                {
                    isRepeating = 1;
                    lpOutput.Suspend();
                }
                else
                {
                    lpEcho.Resume(echoData);
                    echoData = null;
                    isRepeating = 2;
                    lpOutput.Emit(repeatData, true);
                }
            }
            //else throw new EReUnexpectedInputException(lpOutput);
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch1.Disconnect();
            patch2.Disconnect();
        }

        private void passAsItComesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passAsItComesToolStripMenuItem.Checked = !passAsItComesToolStripMenuItem.Checked;
            Modified = true;
        }
    }
}
