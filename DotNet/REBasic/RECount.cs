using RE;

namespace REBasic
{
    [REItem("count","Count","Count number of items passed.")]
    public partial class RECount : REBaseItem
    {
        private int scount;
        private RELinkPointPatch patch;

        public RECount()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpInput, lpOutput);
        }

        public override void Start()
        {
            base.Start();
            scount = 0;
            textBox1.Text = scount.ToString();
        }

        void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            scount++;
            textBox1.Text = scount.ToString();
            //textBox1.Invalidate(false);//?
            lpOutput.Emit(Data);
            //TODO: count sequences?
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
        }

    }
}

