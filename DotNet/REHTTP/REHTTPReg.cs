using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RE;

namespace REHTTP
{
    public class REHttpReg : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("HTTP", -35);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REHTTPDownload)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REHTTPUpload)));
            //ri.DropDownItems.Add(new ToolStripSeparator());
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            return ri;
        }
    }
}
