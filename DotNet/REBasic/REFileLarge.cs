using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using RE;

namespace REBasic
{
    [RE.REItem("largefile","Large file","Writes to a file and/or reads from a file")]
    public partial class REFileLarge : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REFileLarge()
        {
            InitializeComponent();
            patch = new RE.RELinkPointPatch(lpRead, lpWrite);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtFilePath.Text;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                txtFilePath.Text = openFileDialog1.FileName;
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            XmlElement path = Element.SelectSingleNode("path") as XmlElement;
            if (path != null) txtFilePath.Text = path.InnerText;
            cbReadStyle.SelectedIndex = Int32.Parse(Element.GetAttribute("readtype"));
            txtParameter.Text = Element.GetAttribute("readparam");
            //TODO: encoding, append
            Modified = false;
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement path = Element.OwnerDocument.CreateElement("path");
            path.InnerText = txtFilePath.Text;
            Element.AppendChild(path);
            Element.SetAttribute("readtype",cbReadStyle.SelectedIndex.ToString());
            Element.SetAttribute("readparam",txtParameter.Text);
        }

        private void copyFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFilePath.SelectAll();
            txtFilePath.Copy();
        }

        private void pasteFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFilePath.SelectAll();
            txtFilePath.Paste();
        }

        private enum ReadStyle { LineByLine, FixedSize, Separator, NumberOfLines };

        private StreamReader FileReader;
        private StreamWriter FileWriter;
        private int FixedSizeLength;
        private string Separator;

        public override void Start()
        {
            base.Start();
            FileWriter = null;
            FileReader = null;
            if (!lpList.IsConnected) DoFile(txtFilePath.Text);
        }

        public override void Stop()
        {
            base.Stop();
            if (FileWriter != null)
            {
                FileWriter.Close();
                FileWriter = null;
            }
            if (FileReader != null)
            {
                FileReader.Close();
                FileReader = null;
            }
        }

        private void DoFile(string FileName)
        {
            if (lpWrite.IsConnected)
            {
                FileWriter = new StreamWriter(FileName);
                if (lpRead.IsConnected) lpRead.Suspend();
            }
            else
                if (lpRead.IsConnected)
                {
                    switch ((ReadStyle)cbReadStyle.SelectedIndex)
                    {
                        case ReadStyle.LineByLine:
                            //all is ok, ReadLine will do the work
                            break;
                        case ReadStyle.FixedSize:
                            if (txtParameter.Text == "")
                                throw new Exception("[LargeFile] Fixed size block length not defined");
                            FixedSizeLength = Convert.ToInt32(txtParameter.Text);
                            break;
                        case ReadStyle.Separator:
                            if (txtParameter.Text == "")
                                throw new Exception("[LargeFile] Separator not defined");
                            Separator = txtParameter.Text;
                            break;
                        case ReadStyle.NumberOfLines:
                            if (txtParameter.Text == "")
                                throw new Exception("[LargeFile] Number of lines not defined");
                            FixedSizeLength = Convert.ToInt32(txtParameter.Text);
                            break;
                        default:
                            throw new Exception("[LargeFile] No read style selected");
                    }
                    FileReader = new StreamReader(FileName);
                    DoNext();
                }
        }

        private void DoNext()
        {
            //assert lpRead.IsConnected
            //assert FileReader!=null
            switch ((ReadStyle)cbReadStyle.SelectedIndex)
            {
                case ReadStyle.LineByLine:
                    lpRead.Emit(FileReader.ReadLine(), !FileReader.EndOfStream);
                    break;
                case ReadStyle.FixedSize:
                    char[] c = new char[FixedSizeLength];
                    lpRead.Emit(new String(c, 0,
                           FileReader.ReadBlock(c, 0, FixedSizeLength)),
                           !FileReader.EndOfStream);
                    break;
                case ReadStyle.Separator:
                    char[] buf = Separator.ToCharArray();
                    int l = Separator.Length;
                    int i = FileReader.Read(buf, 0, l);
                    if (i < l)
                        lpRead.Emit(new String(buf, 0, i), false);
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        i = 0;
                        while (i < l && buf[i] == Separator[i]) i++;
                        while (i < l && !FileReader.EndOfStream)
                        {
                            sb.Append(buf[0]);
                            for (i = 1; i < l; i++) buf[i - 1] = buf[i];
                            buf[l - 1] = (char)FileReader.Read();
                            i = 0;
                            while (i < l && buf[i] == Separator[i]) i++;
                        }
                        lpRead.Emit(sb.ToString(), !FileReader.EndOfStream);
                    }
                    break;
                case ReadStyle.NumberOfLines:
                    StringBuilder sb1 = new StringBuilder();
                    int j = 0;
                    while (j < FixedSizeLength && !FileReader.EndOfStream)
                    {
                        sb1.AppendLine(FileReader.ReadLine());
                        j++;
                    }
                    lpRead.Emit(sb1.ToString(), !FileReader.EndOfStream);
                    break;
            }
        }

        void lpList_Signal(RELinkPoint Sender, object Data)
        {
            DoFile(Data.ToString());
        }

        void lpRead_Signal(RELinkPoint Sender, object Data)
        {
            DoNext();
        }

        void lpWrite_Signal(RELinkPoint Sender, object Data)
        {
            FileWriter.Write(Data.ToString());
            if (lpRead.IsConnected) lpRead.Emit(Data.ToString());
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }

        private void cbReadStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

    }
}

