using System.Windows.Forms;
using RE;

namespace REBasic
{
    public class REBasicIO: RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("Input/Output",-90);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REViewer)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REConstant)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REConstantSmall)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REClipboard)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REFile)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REFileLarge)));
            return ri;
        }
    }

    public class REStrOps : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("String operations", -70);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrAppendEOL)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RESplitByEOL)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RETranslate)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrTrim)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrTrimStart)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrTrimEnd)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrUpper)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrLower)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REStrReverse)));
            return ri;
        }
    }

    public class REBasicOther : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("Other", -10);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RECount)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REComment)));
            return ri;
        }
    }
}
