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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lpList = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpList);
            this.panItemClient.Controls.Add(this.textBox1);
            this.panItemClient.Size = new System.Drawing.Size(201, 54);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 21);
            this.textBox1.TabIndex = 0;
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
            this.lpList.Location = new System.Drawing.Point(177, 4);
            this.lpList.Name = "lpList";
            this.lpList.Size = new System.Drawing.Size(21, 21);
            this.lpList.TabIndex = 1;
            this.lpList.Signal += new RE.RELinkPointSignal(this.lpList_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(4, 32);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 2;
            // 
            // REHTTPDownload
            // 
            this.Caption = "HTTP Download";
            this.MaximumSize = new System.Drawing.Size(0, 79);
            this.MinimumSize = new System.Drawing.Size(60, 79);
            this.Name = "REHTTPDownload";
            this.Size = new System.Drawing.Size(208, 79);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpList;
        private System.Windows.Forms.TextBox textBox1;
    }
}
