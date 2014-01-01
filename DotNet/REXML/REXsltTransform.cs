using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using RE;

namespace REXML
{
    [REItem("xslttransform","Xslt Transform","Perform an XSLT transformation on node or document")]
    public partial class REXsltTransform : REBaseItem
    {
        public REXsltTransform()
        {
            InitializeComponent();
        }

        private XslCompiledTransform transform;
        private bool inputsuspended;
        private object inputdata;

        public override void Start()
        {
            base.Start();
            transform = null;
            inputsuspended = false;
        }

        public override void Stop()
        {
            base.Stop();
            transform = null;
        }

        private void lpXSLT_Signal(RELinkPoint Sender, object Data)
        {
            //if(transform!=0) throw EReUnexpectedInputException?
            transform = new XslCompiledTransform();
            transform.Load(REXML.AsXmlNode(Data));
            if (inputsuspended)
            {
                lpInput.ConnectedTo.Resume(inputdata);
                inputsuspended = false;
                inputdata = null;
            }
        }

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            XmlNode x=REXML.AsXmlNode(Data);
            if (lpXSLT.IsConnected)
            {
                if (transform == null)
                {
                    inputdata = Data;
                    inputsuspended = true;
                    lpInput.ConnectedTo.Suspend();
                }
                else
                {
                    MemoryStream m=new MemoryStream();
                    XsltArgumentList al = new XsltArgumentList();
                    //TODO: fill argumentlist?
                    transform.Transform(x, al, m);
                    m.Position=0;
                    lpOutput.Emit(new StreamReader(m).ReadToEnd());
                }
            }
            else
            {
                //throw?
                lpOutput.Emit(x);
            }
        }

    }
}
