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
    [RE.REItem("file","File","Writes to a file and/or reads an entire file")]
    public partial class REFile : RE.REBaseItem
    {
        private RE.RELinkPointPatch patch;

        public REFile()
        {
            InitializeComponent();
            patch = new RELinkPointPatch(lpRead, lpWrite);
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
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            XmlElement path = Element.OwnerDocument.CreateElement("path");
            path.InnerText = txtFilePath.Text;
            Element.AppendChild(path);
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

        private StreamWriter FileWriter;
        private bool inputsuspended;
        private object inputdata;

        public override void Start()
        {
            base.Start();
            FileWriter = null;
            if (!lpList.IsConnected) DoFile(txtFilePath.Text);
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
            if (lpWrite.IsConnected)
            {
                FileWriter = new StreamWriter(FileName);
                //see lpWrite.Signal handler
            }
            else
            {
                if (lpRead.IsConnected)
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
            DoFile(Data.ToString());
            if (inputsuspended)
            {
                lpWrite.Resume(inputdata);
                inputsuspended = false;
                inputdata = null;
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
                if (lpRead.IsConnected) lpRead.Emit(Data);
            }
        }

        protected override void DisconnectAll()
        {
            //replacing base.DisconnectAll();
            patch.Disconnect();
            lpList.ConnectedTo = null;
        }

    }
}

