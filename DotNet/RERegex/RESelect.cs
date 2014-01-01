using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RE;

namespace RERegex
{
    [RE.REItem("select","Select","Select items using a regular expression")]
    public partial class RESelect : REBaseRegExItem
    {
        public RESelect()
        {
            InitializeComponent();
            lpRegExInput.Signal += new RELinkPointSignal(lpRegExInput_Signal);
        }

        void lpRegExInput_Signal(RELinkPoint Sender, object Data)
        {
            if(ItemRegex.IsMatch(Data.ToString()))
                reLinkPoint1.Emit(Data);
            else
                reLinkPoint2.Emit(Data);
        }
    }
}

