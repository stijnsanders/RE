using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REMulti
{
    [REItem("decide","Decide","Decide which items of a multiple input get trhough using another multiple input")]
    public partial class REDecide : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch1;
        private RE.RELinkPointPatch patch2;

        public REDecide()
        {
            InitializeComponent();
            patch1 = new RELinkPointPatch(lpInput, lpOutput);
            patch2 = new RELinkPointPatch(lpSelect, lpEcho);
        }

        private object inputdata;
        private object selectdata;
        private bool inputsent;
        private bool inputdone;
        private bool outputsuspended;
        private bool selectsuspended;
        private RELinkPoint inputSeqEnd;

        public override void Start()
        {
            base.Start();
            inputdone = true;
            inputdata = null;
            inputsent = false;
            selectdata = null;
            outputsuspended = true;
            selectsuspended = false;
            lpOutput.Suspend();
            inputSeqEnd = new RELinkPoint("input_sequence_end", this);
            inputSeqEnd.Signal += new RELinkPointSignal(inputSeqEnd_Signal);
        }

        public override void Stop()
        {
            base.Stop();
            inputSeqEnd = null;
            inputdata = null;
            selectdata = null;
        }

        private void lpSelect_Signal(RELinkPoint Sender, object Data)
        {
            if (inputdata == null)
            {
                lpEcho.Suspend();
                selectsuspended = true;
                selectdata = Data;
            }
            else
            {
                //TODO: switch repeat by select?
                if (outputsuspended && !inputsent)
                {
                    lpOutput.Resume(inputdata);
                    inputdata = null;
                    inputsent = true;
                    outputsuspended = false;
                }
                lpEcho.Emit(Data);
            }
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (inputdone)
            {
                lpOutput.Emit(inputSeqEnd);
                inputdone = false;
            }
            if (selectsuspended)
            {
                lpEcho.Resume(selectdata);
                selectsuspended = false;
                selectdata = null;
                if (outputsuspended)
                {
                    lpOutput.Resume(Data);
                    outputsuspended = false;
                }
            }
            else
            {
                inputdata = Data;
                inputsent = false;
            }
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            if (!inputdone)
            {
                lpOutput.Suspend();
                outputsuspended = true;
            }
        }

        void inputSeqEnd_Signal(RELinkPoint Sender, object Data)
        {
            if (outputsuspended)
            {
                lpOutput.Resume();
                outputsuspended = false;
            }
            inputdone = true;
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch1.Disconnect();
            patch2.Disconnect();
        }

    }
}
