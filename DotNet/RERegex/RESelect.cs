using RE;

namespace RERegex
{
    [RE.REItem("select", "Select", "Select items using a regular expression")]
    public partial class RESelect : REBaseRegExItem
    {
        public RESelect()
        {
            InitializeComponent();
            lpRegExInput.Signal += new RELinkPointSignal(lpRegExInput_Signal);
        }

        void lpRegExInput_Signal(RELinkPoint Sender, object? Data)
        {
            var s = Data?.ToString();
            if (s != null)
                if (ItemRegex.IsMatch(s))
                    reLinkPoint1.Emit(s);
                else
                    reLinkPoint2.Emit(s);
        }
    }
}

