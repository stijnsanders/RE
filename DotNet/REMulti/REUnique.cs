﻿using System;
using System.Collections.Generic;
using RE;

namespace REMulti
{
    [REItem("unique", "Unique", "Select unique items from a multiple input")]
    public partial class REUnique : REBaseItem
    {
        public REUnique()
        {
            InitializeComponent();
        }

        public override void LoadFromXml(System.Xml.XmlElement Element)
        {
            base.LoadFromXml(Element);
            ignoreCaseToolStripMenuItem.Checked = StrToBool(Element.GetAttribute("ignorecase"));
        }

        public override void SaveToXml(System.Xml.XmlElement Element)
        {
            base.SaveToXml(Element);
            Element.SetAttribute("ignorecase", BoolToStr(ignoreCaseToolStripMenuItem.Checked));
        }

        private void ignoreCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ignoreCaseToolStripMenuItem.Checked = !ignoreCaseToolStripMenuItem.Checked;
            Modified = true;
        }

        public override void Start()
        {
            base.Start();
            //registered = false;
        }

        public override void Stop()
        {
            base.Stop();
            uniqueData = null;
        }

        private SortedList<string, int>? uniqueData;
        //private bool registered;

        private void lpInput_Signal(RELinkPoint Sender, object Data)
        {
            if (lpUnique.ConnectedTo != null || lpDuplicate.ConnectedTo != null)
            {
                if (uniqueData == null)
                {
                    uniqueData = new SortedList<string, int>();
                    //register for sequence end
                    lpUnique.Emit(lpUnique);
                    //registered = true;
                }
                string? x = Data.ToString();
                if (x != null)
                {
                    if (ignoreCaseToolStripMenuItem.Checked)
                        x = x.ToLower();
                    if (uniqueData.ContainsKey(x))
                        lpDuplicate.Emit(Data);
                    else
                    {
                        uniqueData.Add(x, 1);
                        lpUnique.Emit(Data);
                    }
                }
            }
        }

        private void lpUnique_Signal(RELinkPoint Sender, object Data)
        {
            //sequence end report
            //registered = false;
            uniqueData = null;
        }



    }
}
