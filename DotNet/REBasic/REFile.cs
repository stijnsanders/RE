using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using RE;

namespace REBasic
{
    [REItem("file", "File", "Writes to a file and/or reads an entire file")]
    public partial class REFile : RE.REBaseItem
    {
        private RELinkPointPatch? patch;

        public REFile()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpRead, lpWrite);
        }

        private void button1_Click(object? sender, EventArgs e)
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
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement path = Element.OwnerDocument.CreateElement("path");
            path.InnerText = txtFilePath.Text;
            Element.AppendChild(path);
        }

        private void copyFileLocationToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            txtFilePath.SelectAll();
            txtFilePath.Copy();
        }

        private void pasteFileLocationToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            txtFilePath.SelectAll();
            txtFilePath.Paste();
        }

        private StreamWriter? FileWriter;
        private bool inputsuspended;
        private object? inputdata;

        public override void Start()
        {
            base.Start();
            FileWriter = null;
            if (lpList.ConnectedTo == null) DoFile(txtFilePath.Text);
            inputsuspended = false;
        }

        public override void Stop()
        {
            base.Stop();
            inputdata = null;
            if (FileWriter != null)
            {
                FileWriter.Close();
                FileWriter = null;
            }
        }

        private void DoFile(string FileName)
        {
            if (FileWriter != null)
            {
                FileWriter.Close();
                FileWriter = null;
            }
            if (lpWrite.ConnectedTo != null)
            {
                FileWriter = new StreamWriter(FileName);
                //see lpWrite.Signal handler
            }
            else
            {
                if (lpRead.ConnectedTo != null)
                {
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        lpRead.Emit(sr.ReadToEnd());
                    }
                }
            }
        }

        void lpList_Signal(RELinkPoint Sender, object Data)
        {
            var s = Data.ToString();
            if (s != null)
            {
                DoFile(s);
                if (inputsuspended && inputdata != null)
                {
                    lpWrite.Resume(inputdata);
                    inputsuspended = false;
                    inputdata = null;
                }
            }
        }

        void lpWrite_Signal(RELinkPoint Sender, object Data)
        {
            if (FileWriter == null)
            {
                //assert lpList.IsConnected
                inputdata = Data;
                inputsuspended = true;
                lpWrite.Suspend();
            }
            else
            {
                FileWriter.Write(Data);
                if (lpRead.ConnectedTo != null) lpRead.Emit(Data);
            }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            if (patch != null)
                patch.Disconnect();
            lpList.ConnectedTo = null;
        }

    }
}

