using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REFileSystem
{
    public class RE_template : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("File system", -40);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REListFiles)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REFileExists)));
            //ri.DropDownItems.Add(new ToolStripSeparator());
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            return ri;
        }
    }
}
