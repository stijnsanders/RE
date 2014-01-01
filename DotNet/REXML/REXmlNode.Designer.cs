namespace REXML
{
    partial class REXmlNode
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProp = new System.Windows.Forms.ComboBox();
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.cbProp);
            this.panItemClient.Size = new System.Drawing.Size(134, 53);
            // 
            // cbProp
            // 
            this.cbProp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProp.FormattingEnabled = true;
            this.cbProp.Items.AddRange(new object[] {
            "FirstChild",
            "NextSibling",
            "ParentNode",
            "LastChild",
            "PreviousSibling",
            "OwnerDocument*"});
            this.cbProp.Location = new System.Drawing.Point(4, 4);
            this.cbProp.Name = "cbProp";
            this.cbProp.Size = new System.Drawing.Size(127, 21);
            this.cbProp.TabIndex = 0;
            this.cbProp.SelectedIndexChanged += new System.EventHandler(this.cbProp_SelectedIndexChanged);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "xml in";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(4, 31);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(60, 16);
            this.lpInput.TabIndex = 1;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "xml out";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(70, 31);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(60, 16);
            this.lpOutput.TabIndex = 2;
            // 
            // REXmlNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "XML node";
            this.MaximumSize = new System.Drawing.Size(0, 78);
            this.MinimumSize = new System.Drawing.Size(141, 78);
            this.Name = "REXmlNode";
            this.Size = new System.Drawing.Size(141, 78);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProp;
        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
    }
}
