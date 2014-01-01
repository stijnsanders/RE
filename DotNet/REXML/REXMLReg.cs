using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RE;

namespace REXML
{
    public class REXML : RELibraryRegistry
    {
        public override RELibraryMenuItem Register()
        {
            RELibraryMenuItem ri = new RELibraryMenuItem("XML", -40);
            ri.DropDownItems.Add(new REItemMenuItem(typeof(RETextToXml)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXmlToText)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXmlNode)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXmlSelectSingleNode)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXmlChildNodes)));
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXmlSelectNodes)));
            ri.DropDownItems.Add(new ToolStripSeparator());
            ri.DropDownItems.Add(new REItemMenuItem(typeof(REXsltTransform)));
            //ri.DropDownItems.Add(new REItemMenuItem(typeof()));
            return ri;
        }

        public static XmlNode AsXmlNode(object Data)
        {
            if (Data is XmlNode)
                return Data as XmlNode;
            else
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(Data.ToString());
                return xdoc as XmlNode;//.DocumentElement?
            }
        }
    }
}
