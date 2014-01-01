using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace REBasic
{
    [RE.REItem("count","Count","Count number of items passed.")]
    public partial class RECount : RE.REBaseItem
    {
        private int scount;
        private RE.RELinkPointPatch patch;

        public RECount()
        {
            InitializeComponent();
            patch = new RE.RELinkPointPatch(lpInput, lpOutput);
        }

        public override void Start()
        {
            base.Start();
            scount = 0;
            textBox1.Text = scount.ToString();
        }

        void lpInput_Signal(RE.RELinkPoint Sender, object Data)
        {
            scount++;
            textBox1.Text = scount.ToString();
            //textBox1.Invalidate(false);//?
            lpOutput.Emit(Data);
            //TODO: count sequences?
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}

