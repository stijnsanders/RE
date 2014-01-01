using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RE;

namespace RE_template
{
    public class RE_template : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("Library Entry", 0);
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            //ri.DropDownItems.Add(new ToolStripSeparator());
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            return ri;
        }
    }
}
