using System;
using System.Windows.Forms;
using System.Drawing;

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
        public static event RELibraryAddition? ItemAdded;
        internal static void AddItem(REBaseItem Item)
        {
            if (ItemAdded != null)
                ItemAdded(Item);
        }
    }

    public class REItemMenuItem : ToolStripMenuItem
    {
        private Type itemType;
        public Type ItemType { get { return itemType; } }

        public REItemMenuItem(Type ItemType)
            : base()
        {
            itemType = ItemType;
            foreach (REItemAttribute r in itemType.GetCustomAttributes(typeof(REItemAttribute), true))
                Text = r.DisplayName;//break after one?
            //if none found throw?
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var c = itemType.GetConstructor(Type.EmptyTypes);
            var b = c?.Invoke(Array.Empty<object>()) as REBaseItem;
            if (b != null)
                RELibraryRegistry.AddItem(b);
        }

    }


}
