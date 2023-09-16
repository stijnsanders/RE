namespace REHTTP
{
    partial class REHTTPDownload
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
            components = new System.ComponentModel.Container();
            txtURL = new System.Windows.Forms.TextBox();
            lpList = new RE.RELinkPoint();
            lpOutput = new RE.RELinkPoint();
            lpHeaders = new RE.RELinkPoint();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panItemClient.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panItemClient
            // 
            panItemClient.Controls.Add(lpHeaders);
            panItemClient.Controls.Add(lpOutput);
            panItemClient.Controls.Add(lpList);
            panItemClient.Controls.Add(txtURL);
            panItemClient.Size = new System.Drawing.Size(201, 54);
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(3, 5);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(167, 21);
            txtURL.TabIndex = 0;
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
            lpList.Location = new System.Drawing.Point(177, 4);
            lpList.Name = "lpList";
            lpList.Size = new System.Drawing.Size(21, 21);
            lpList.TabIndex = 1;
            lpList.Signal += lpList_Signal;
            // 
            // lpOutput
            // 
            lpOutput.AllowDrop = true;
            lpOutput.Caption = "output";
            lpOutput.ConnectedTo = null;
            lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            lpOutput.Direction = RE.RELinkPointDirection.Output;
            lpOutput.Key = "output";
            lpOutput.Location = new System.Drawing.Point(3, 32);
            lpOutput.Name = "lpOutput";
            lpOutput.Size = new System.Drawing.Size(48, 16);
            lpOutput.TabIndex = 2;
            // 
            // lpHeaders
            // 
            lpHeaders.AllowDrop = true;
            lpHeaders.Caption = "headers";
            lpHeaders.ConnectedTo = null;
            lpHeaders.ConnectionColor = System.Drawing.Color.Transparent;
            lpHeaders.Direction = RE.RELinkPointDirection.Output;
            lpHeaders.Key = "output";
            lpHeaders.Location = new System.Drawing.Point(57, 32);
            lpHeaders.Name = "lpHeaders";
            lpHeaders.Size = new System.Drawing.Size(48, 16);
            lpHeaders.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { methodToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // methodToolStripMenuItem
            // 
            methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            methodToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            methodToolStripMenuItem.Text = "Method";
            // 
            // REHTTPDownload
            // 
            Caption = "HTTP Download";
            ContextMenuStrip = contextMenuStrip1;
            MaximumSize = new System.Drawing.Size(0, 79);
            MinimumSize = new System.Drawing.Size(120, 79);
            Name = "REHTTPDownload";
            Size = new System.Drawing.Size(208, 79);
            Controls.SetChildIndex(panItemClient, 0);
            panItemClient.ResumeLayout(false);
            panItemClient.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpList;
        private System.Windows.Forms.TextBox txtURL;
        private RE.RELinkPoint lpHeaders;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
    }
}
