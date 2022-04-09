using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using RE;

namespace REJSON
{
    public class REJSON : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("JSON", -40);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RETextToJson)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonToText)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonKeyValue)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REEnumObject)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REEnumArray)));
            /*
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonNode)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonSelectSingleNode)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonChildNodes)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJsonSelectNodes)));
			*/
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            return ri;
        }
    }
}
