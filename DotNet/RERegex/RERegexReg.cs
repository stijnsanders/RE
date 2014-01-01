using System;
using System.Collections.Generic;
using System.Text;
using RE;

namespace RERegex
{
    public class RERegex : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("RegExps", -80);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RESplit)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RESelect)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REReplace)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REGroups)));
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            //ri.DropDownItems.Add(new ToolStripSeparator());
            return ri;
        }
    }
}
