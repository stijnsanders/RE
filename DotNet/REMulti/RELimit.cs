using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("limit","Limit","Limit a multiple input by the index input.")]
    public partial class RELimit : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch1;
        private RE.RELinkPointPatch patch2;

        public RELimit()
        {
            InitializeComponent();
            patch1 = new RELinkPointPatch(lpIndex, lpEcho);
            patch2 = new RELinkPointPatch(lpInput, lpOutput);
        }

        private int gotindex;
        private object inputdata;
        private bool inputsuspended;
        private bool inputresumed;
        private bool indexSeqEndRegistered;
        private bool indexSeqEnded;
        private RELinkPoint indexSeqEnd;

        public override void Start()
        {
            base.Start();
            gotindex = 0;
            inputsuspended = false;
            inputresumed = false;
            indexSeqEnded = false;
            indexSeqEndRegistered = false;
            indexSeqEnd = new RELinkPoint("index_sequence_end", this);
            indexSeqEnd.Signal += new RELinkPointSignal(indexSeqEnd_Signal);
        }

        public override void Stop()
        {
            base.Stop();
            indexSeqEnd = null;
            inputdata = null;
        }

        private void lpIndex_Signal(RELinkPoint Sender, object Data)
        {
            if (!indexSeqEndRegistered)
            {
                lpIndex.Emit(indexSeqEnd);
                indexSeqEnded = false;
                indexSeqEndRegistered = true;
            }
            gotindex++;
            if (inputsuspended)
            {
                inputsuspended = false;
                inputresumed = true;
                lpInput.ConnectedTo.Resume();
            }
            lpEcho.Emit(Data);
        }

        void indexSeqEnd_Signal(RELinkPoint Sender, object Data)
        {
            indexSeqEndRegistered = false;
            indexSeqEnded = true;
            if (inputsuspended)
            {
                inputsuspended = false;
                inputresumed = true;
                lpInput.ConnectedTo.Resume();
            }
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (!indexSeqEnded || gotindex!=0)
                if (gotindex == 0)
                {
                    if (inputsuspended) throw new EReUnexpectedInputException(lpInput);
                    inputsuspended = true;
                    inputdata = Data;
                    lpInput.ConnectedTo.Suspend();
                }
                else
                {
                    gotindex--;
                    if (inputresumed)
                    {
                        lpOutput.Emit(inputdata);
                        inputresumed = false;
                        inputdata = null;
                    }
                    else
                        lpOutput.Emit(Data);
                }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch1.Disconnect();
            patch2.Disconnect();
        }

    }
}

