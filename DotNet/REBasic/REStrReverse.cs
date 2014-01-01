using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace REBasic
{
    [RE.REItem("strrev","Reverse string","Reverses a string front to back")]
    public partial class REStrReverse : REBasic.REBaseStringOp
    {
        public REStrReverse()
        {
            InitializeComponent();
        }

        protected override string Perform(string Data)
        {
            int l = Data.Length;
            StringBuilder x=new StringBuilder(l);
            for (int i = 0; i < l; i++) x.Append(Data[l - i - 1]);
            return x.ToString();
        }

    }
}

