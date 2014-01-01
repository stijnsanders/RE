using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RE;

namespace RE_template
{
    [REItem("demoitem","Demo Item","Demo item inheriting from REBaseItem")]
    public partial class RE_demoitem : REBaseItem
    {
        public RE_demoitem()
        {
            InitializeComponent();
        }

        //override LoadFromXml...
		//override SaveToXml...
		//override Start...
        //override Stop...
        //...add RELinkPoints and handle Signal events
    }
}
