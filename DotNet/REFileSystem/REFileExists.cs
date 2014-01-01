using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using RE;

namespace REFileSystem
{
    [REItem("fileexists","File Exists","Check if files exists")]
    public partial class REFileExists : REBaseItem
    {
        public REFileExists()
        {
            InitializeComponent();
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            //TODO: prefix? relative path?
            string path = Data.ToString();
            if (File.Exists(path))
                lpExists.Emit(path);
            else
                lpNotFound.Emit(path);
        }

    }
}
