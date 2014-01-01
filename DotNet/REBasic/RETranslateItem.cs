using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace REBasic
{
    public partial class RETranslateItem : UserControl
    {
        public RETranslateItem()
        {
            InitializeComponent();
        }

        public string SearchString
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string ReplaceString
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public int Column1Left
        {
            get { return textBox1.Width; }
            set
            {
                int nx = value;
                textBox1.Bounds = new Rectangle(4, 4, nx, textBox1.Height);
                textBox2.Bounds = new Rectangle(nx + 11, 4, ClientSize.Width - nx - 15, textBox2.Height);
            }
        }
    }
}
