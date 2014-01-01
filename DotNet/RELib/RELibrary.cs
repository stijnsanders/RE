using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace RE
{
    public class RELibraryMenuItem : ToolStripMenuItem
    {
        private int _menuItemPrecedence = 0;
        public int Precedence { get { return _menuItemPrecedence; } }

        public RELibraryMenuItem(string Text, int Precedence)
            : base(Text)
        {
            _menuItemPrecedence = Precedence;
        }

        public RELibraryMenuItem(string Text, Image Image, int Precedence)
            : base(Text, Image)
        {
            _menuItemPrecedence = Precedence;
        }

    }

    //delegate used by main application
    public delegate void RELibraryAddition(REBaseItem Item);

    public abstract class RELibraryRegistry
    {
        public abstract RELibraryMenuItem Register();

        //handle used by main application
        public static event RELibraryAddition ItemAdded;
        internal static void AddItem(REBaseItem Item)
        {
            ItemAdded(Item);
        }
    }

    public class REItemMenuItem : ToolStripMenuItem
    {
        private System.Type itemType; 
        public System.Type ItemType { get { return itemType; } }

        public REItemMenuItem(System.Type ItemType)
            : base()
        {
            itemType=ItemType;
            foreach (REItemAttribute r in itemType.GetCustomAttributes(typeof(REItemAttribute), true))
                Text = r.DisplayName;//break after one?
            //if none found throw?
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            RELibraryRegistry.AddItem(
                itemType.GetConstructor(System.Type.EmptyTypes).Invoke(new object[] { }) as REBaseItem);
        }

    }


}
