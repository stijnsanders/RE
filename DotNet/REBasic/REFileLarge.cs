using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using RE;

namespace REBasic
{
    [REItem("largefile", "Large file", "Writes to a file and/or reads from a file")]
    public partial class REFileLarge : REBaseItem
    {
        private RELinkPointPatch? patch;

        public REFileLarge()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpRead, lpWrite);
            Separator = ""; //default
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
            XmlElement? path = Element.SelectSingleNode("path") as XmlElement;
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
            Element.SetAttribute("readtype", cbReadStyle.SelectedIndex.ToString());
            Element.SetAttribute("readparam", txtParameter.Text);
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

        private StreamReader? FileReader;
        private StreamWriter? FileWriter;
        private int FixedSizeLength;
        private string Separator;

        public override void Start()
        {
            base.Start();
            FileWriter = null;
            FileReader = null;
            if (lpList.ConnectedTo == null) DoFile(txtFilePath.Text);
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
            if (lpWrite.ConnectedTo != null)
            {
                FileWriter = new StreamWriter(FileName);
                if (lpRead.ConnectedTo != null) lpRead.Suspend();
            }
            else
                if (lpRead.ConnectedTo != null)
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
            if (FileReader != null)
                switch ((ReadStyle)cbReadStyle.SelectedIndex)
                {
                    case ReadStyle.LineByLine:
                        var s = FileReader.ReadLine();
                        if (s != null)
                            lpRead.Emit(s, !FileReader.EndOfStream);
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
            var s = Data.ToString();
            if (s != null)
                DoFile(s);
        }

        void lpRead_Signal(RELinkPoint Sender, object Data)
        {
            DoNext();
        }

        void lpWrite_Signal(RELinkPoint Sender, object Data)
        {
            var s = Data.ToString();
            if (s != null)
            {
                if (FileWriter != null)
                    FileWriter.Write(Data.ToString());
                if (lpRead.ConnectedTo != null) lpRead.Emit(s);
            }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            if (patch != null)
                patch.Disconnect();
            lpList.ConnectedTo = null;
        }

        private void cbReadStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modified = true;
        }
    }
}