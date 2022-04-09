using System.Windows.Forms;
using RE;

namespace REMulti
{
    public class REMulti : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("Single/Multiple", -60);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REJoin)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REMultiply)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RESequence)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REBuilder)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RERepeat)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RELimit)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REDecide)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REMerge)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REInvert)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REFirst)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RELast)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RESort)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REUnique)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REIndex)));
            return ri;
        }
    }
}
