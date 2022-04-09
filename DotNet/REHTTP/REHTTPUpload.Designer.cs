namespace REHTTP
{
    partial class REHTTPUpload
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
            this.lpOutput = new RE.RELinkPoint();
            this.lpList = new RE.RELinkPoint();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lpInput = new RE.RELinkPoint();
            this.lpHeaders = new RE.RELinkPoint();
            this.txtContentType = new System.Windows.Forms.TextBox();
            this.lblContentType = new System.Windows.Forms.Label();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lblContentType);
            this.panItemClient.Controls.Add(this.txtContentType);
            this.panItemClient.Controls.Add(this.lpHeaders);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpList);
            this.panItemClient.Controls.Add(this.txtURL);
            this.panItemClient.Size = new System.Drawing.Size(201, 93);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(57, 72);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 8;
            // 
            // lpList
            // 
            this.lpList.AllowDrop = true;
            this.lpList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lpList.Caption = "";
            this.lpList.ConnectedTo = null;
            this.lpList.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpList.Direction = RE.RELinkPointDirection.Input;
            this.lpList.Key = "list";
            this.lpList.Location = new System.Drawing.Point(177, 5);
            this.lpList.Name = "lpList";
            this.lpList.Size = new System.Drawing.Size(21, 21);
            this.lpList.TabIndex = 4;
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(3, 5);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(167, 21);
            this.txtURL.TabIndex = 3;
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(3, 72);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 7;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpHeaders
            // 
            this.lpHeaders.AllowDrop = true;
            this.lpHeaders.Caption = "headers";
            this.lpHeaders.ConnectedTo = null;
            this.lpHeaders.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpHeaders.Direction = RE.RELinkPointDirection.Output;
            this.lpHeaders.Key = "output";
            this.lpHeaders.Location = new System.Drawing.Point(111, 72);
            this.lpHeaders.Name = "lpHeaders";
            this.lpHeaders.Size = new System.Drawing.Size(48, 16);
            this.lpHeaders.TabIndex = 9;
            // 
            // txtContentType
            // 
            this.txtContentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContentType.Location = new System.Drawing.Point(3, 45);
            this.txtContentType.Name = "txtContentType";
            this.txtContentType.Size = new System.Drawing.Size(195, 21);
            this.txtContentType.TabIndex = 6;
            // 
            // lblContentType
            // 
            this.lblContentType.AutoSize = true;
            this.lblContentType.Location = new System.Drawing.Point(3, 29);
            this.lblContentType.Name = "lblContentType";
            this.lblContentType.Size = new System.Drawing.Size(83, 13);
            this.lblContentType.TabIndex = 5;
            this.lblContentType.Text = "Content-Type";
            // 
            // REHTTPUpload
            // 
            this.Caption = "HTTP Upload";
            this.MaximumSize = new System.Drawing.Size(0, 118);
            this.MinimumSize = new System.Drawing.Size(170, 118);
            this.Name = "REHTTPUpload";
            this.Size = new System.Drawing.Size(208, 118);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpList;
        private System.Windows.Forms.TextBox txtURL;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpHeaders;
        private System.Windows.Forms.TextBox txtContentType;
        private System.Windows.Forms.Label lblContentType;
    }
}
