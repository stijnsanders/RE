using System.Windows.Forms;
using RE;

namespace REBasic
{
    [REItem("clipboard", "Clipboard", "Gets or sets text content to the clipboard")]
    public partial class REClipboard : REBaseItem
    {
        public REClipboard()
        {
            InitializeComponent();
            lpSet.Signal += new RELinkPointSignal(lpSet_Signal);
        }

        void lpSet_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
            {
                Clipboard.SetText(Data.ToString() ?? Data.GetType().ToString());
                if (lpGet.ConnectedTo != null) lpGet.Emit(Data);
            }
        }

        public override void Start()
        {
            base.Start();
            if (lpSet.ConnectedTo == null && lpGet.ConnectedTo != null)
                lpGet.Emit(Clipboard.GetText());
        }

        //TODO switch to/from HTML?
    }
}

