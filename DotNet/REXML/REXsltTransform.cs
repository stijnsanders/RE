﻿using System.IO;
using System.Xml;
using System.Xml.Xsl;
using RE;

namespace REXML
{
    [REItem("xslttransform", "Xslt Transform", "Perform an XSLT transformation on node or document")]
    public partial class REXsltTransform : REBaseItem
    {
        public REXsltTransform()
        {
            InitializeComponent();
        }

        private XslCompiledTransform? transform;
        private bool inputsuspended;
        private object? inputdata;

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

        private void lpXSLT_Signal(RELinkPoint Sender, object? Data)
        {
            //if(transform!=0) throw EReUnexpectedInputException?
            if (Data != null)
            {
                var x = REXML.AsXmlNode(Data);
                if (x != null)
                {
                    transform = new XslCompiledTransform();
                    transform.Load(x);
                    if (inputsuspended && inputdata != null && lpInput.ConnectedTo != null)
                    {
                        lpInput.ConnectedTo.Resume(inputdata);
                        inputsuspended = false;
                        inputdata = null;
                    }
                }
            }
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            if (Data != null)
            {
                XmlNode? x = REXML.AsXmlNode(Data);
                if (x != null)
                    if (lpXSLT.ConnectedTo != null)
                    {
                        if (transform == null)
                        {
                            inputdata = Data;
                            inputsuspended = true;
                            if (lpInput.ConnectedTo != null)
                                lpInput.ConnectedTo.Suspend();
                        }
                        else
                        {
                            MemoryStream m = new();
                            XsltArgumentList al = new();
                            //TODO: fill argumentlist?
                            transform.Transform(x, al, m);
                            m.Position = 0;
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
}