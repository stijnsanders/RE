using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using RE;

namespace REFileSystem
{
    [REItem("listfiles","List Files","List files in a folder")]
    public partial class REListFiles : REBaseItem
    {
        public REListFiles()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            txtPath.Text = Element.GetAttribute("path");
            txtPattern.Text = Element.GetAttribute("pattern");
            cbRecurse.Checked = StrToBool(Element.GetAttribute("recurse"));
        }
        
        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("path", txtPath.Text);
            Element.SetAttribute("pattern", txtPattern.Text);
            Element.SetAttribute("recurse", BoolToStr(cbRecurse.Checked));
        }

        private FileInfo[] list;
        private int listindex;
        private string pattern;
        private SearchOption option;

        public override void Start()
        {
            base.Start();
            pattern = txtPattern.Text;
            option = cbRecurse.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            if (!lpList.IsConnected) DoPath(txtPath.Text);
        }

        private void DoPath(string Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            list = di.GetFiles(pattern, option);
            listindex = 0;
            DoNext();
        }

        private void DoNext()
        {
            if (listindex < list.Length)
            {
                lpOutput.Emit(list[listindex].FullName, true);
                listindex++;
            }
            else
                list = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPath.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void lpList_Signal(RELinkPoint Sender, object Data)
        {
            DoPath(Data.ToString());
        }

        private void lpOutput_Signal(RELinkPoint Sender, object Data)
        {
            DoNext();
        }

        private void cbRecurse_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }
    }
}
