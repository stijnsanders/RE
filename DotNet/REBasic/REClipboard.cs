using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REBasic
{
    [RE.REItem("clipboard","Clipboard","Gets or sets text content to the clipboard")]
    public partial class REClipboard : REBaseItem
    {
        public REClipboard()
        {
            InitializeComponent();
            lpSet.Signal += new RELinkPointSignal(lpSet_Signal);
        }

        void lpSet_Signal(RELinkPoint Sender, object Data)
        {
            Clipboard.SetText(Data.ToString());
            if (lpGet.IsConnected) lpGet.Emit(Data);
        }

        public override void Start()
        {
            base.Start();
            if (!lpSet.IsConnected && lpGet.IsConnected)
                lpGet.Emit(Clipboard.GetText());
        }

        //TODO switch to/from HTML?
    }
}

