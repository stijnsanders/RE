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
            lpOutput = new RE.RELinkPoint();
            lpList = new RE.RELinkPoint();
            txtURL = new System.Windows.Forms.TextBox();
            lpInput = new RE.RELinkPoint();
            lpHeaders = new RE.RELinkPoint();
            txtContentType = new System.Windows.Forms.TextBox();
            lblContentType = new System.Windows.Forms.Label();
            lblMethod = new System.Windows.Forms.Label();
            cbMethod = new System.Windows.Forms.ComboBox();
            panItemClient.SuspendLayout();
            SuspendLayout();
            // 
            // panItemClient
            // 
            panItemClient.Controls.Add(cbMethod);
            panItemClient.Controls.Add(lblMethod);
            panItemClient.Controls.Add(lblContentType);
            panItemClient.Controls.Add(txtContentType);
            panItemClient.Controls.Add(lpHeaders);
            panItemClient.Controls.Add(lpInput);
            panItemClient.Controls.Add(lpOutput);
            panItemClient.Controls.Add(lpList);
            panItemClient.Controls.Add(txtURL);
            panItemClient.Size = new System.Drawing.Size(201, 93);
            // 
            // lpOutput
            // 
            lpOutput.AllowDrop = true;
            lpOutput.Caption = "output";
            lpOutput.ConnectedTo = null;
            lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            lpOutput.Direction = RE.RELinkPointDirection.Output;
            lpOutput.Key = "output";
            lpOutput.Location = new System.Drawing.Point(57, 72);
            lpOutput.Name = "lpOutput";
            lpOutput.Size = new System.Drawing.Size(48, 16);
            lpOutput.TabIndex = 8;
            // 
            // lpList
            // 
            lpList.AllowDrop = true;
            lpList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lpList.Caption = "";
            lpList.ConnectedTo = null;
            lpList.ConnectionColor = System.Drawing.Color.Transparent;
            lpList.Direction = RE.RELinkPointDirection.Input;
            lpList.Key = "list";
            lpList.Location = new System.Drawing.Point(177, 5);
            lpList.Name = "lpList";
            lpList.Size = new System.Drawing.Size(21, 21);
            lpList.TabIndex = 1;
            lpList.Signal += lpList_Signal;
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(3, 5);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(167, 21);
            txtURL.TabIndex = 0;
            // 
            // lpInput
            // 
            lpInput.AllowDrop = true;
            lpInput.Caption = "input";
            lpInput.ConnectedTo = null;
            lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            lpInput.Direction = RE.RELinkPointDirection.Input;
            lpInput.Key = "input";
            lpInput.Location = new System.Drawing.Point(3, 72);
            lpInput.Name = "lpInput";
            lpInput.Size = new System.Drawing.Size(48, 16);
            lpInput.TabIndex = 7;
            lpInput.Signal += lpInput_Signal;
            // 
            // lpHeaders
            // 
            lpHeaders.AllowDrop = true;
            lpHeaders.Caption = "headers";
            lpHeaders.ConnectedTo = null;
            lpHeaders.ConnectionColor = System.Drawing.Color.Transparent;
            lpHeaders.Direction = RE.RELinkPointDirection.Output;
            lpHeaders.Key = "headers";
            lpHeaders.Location = new System.Drawing.Point(111, 72);
            lpHeaders.Name = "lpHeaders";
            lpHeaders.Size = new System.Drawing.Size(48, 16);
            lpHeaders.TabIndex = 9;
            lpHeaders.Signal += lpHeaders_Signal;
            // 
            // txtContentType
            // 
            txtContentType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContentType.Location = new System.Drawing.Point(89, 45);
            txtContentType.Name = "txtContentType";
            txtContentType.Size = new System.Drawing.Size(109, 21);
            txtContentType.TabIndex = 5;
            // 
            // lblContentType
            // 
            lblContentType.AutoSize = true;
            lblContentType.Location = new System.Drawing.Point(89, 29);
            lblContentType.Name = "lblContentType";
            lblContentType.Size = new System.Drawing.Size(83, 13);
            lblContentType.TabIndex = 4;
            lblContentType.Text = "Content-Type";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new System.Drawing.Point(3, 29);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new System.Drawing.Size(48, 13);
            lblMethod.TabIndex = 2;
            lblMethod.Text = "Method";
            // 
            // cbMethod
            // 
            cbMethod.FormattingEnabled = true;
            cbMethod.Items.AddRange(new object[] { "POST", "PUT", "PATCH", "DELETE" });
            cbMethod.Location = new System.Drawing.Point(3, 45);
            cbMethod.Name = "cbMethod";
            cbMethod.Size = new System.Drawing.Size(80, 21);
            cbMethod.TabIndex = 3;
            cbMethod.Text = "POST";
            // 
            // REHTTPUpload
            // 
            Caption = "HTTP Upload";
            ContextMenuStrip = null;
            MaximumSize = new System.Drawing.Size(0, 118);
            MinimumSize = new System.Drawing.Size(170, 118);
            Name = "REHTTPUpload";
            Size = new System.Drawing.Size(208, 118);
            panItemClient.ResumeLayout(false);
            panItemClient.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpList;
        private System.Windows.Forms.TextBox txtURL;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpHeaders;
        private System.Windows.Forms.TextBox txtContentType;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.Label lblMethod;
    }
}
