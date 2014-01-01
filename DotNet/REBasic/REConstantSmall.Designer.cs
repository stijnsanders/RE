namespace REBasic
{
    partial class REConstantSmall
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reLinkPoint1 = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.reLinkPoint1);
            this.panItemClient.Controls.Add(this.textBox1);
            this.panItemClient.Size = new System.Drawing.Size(212, 28);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 21);
            this.textBox1.TabIndex = 0;
            // 
            // reLinkPoint1
            // 
            this.reLinkPoint1.AllowDrop = true;
            this.reLinkPoint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reLinkPoint1.Caption = "";
            this.reLinkPoint1.ConnectedTo = null;
            this.reLinkPoint1.ConnectionColor = System.Drawing.Color.Empty;
            this.reLinkPoint1.Direction = RE.RELinkPointDirection.Output;
            this.reLinkPoint1.Key = "output";
            this.reLinkPoint1.Location = new System.Drawing.Point(174, 6);
            this.reLinkPoint1.Name = "reLinkPoint1";
            this.reLinkPoint1.Size = new System.Drawing.Size(32, 16);
            this.reLinkPoint1.TabIndex = 1;
            // 
            // REConstantSmall
            // 
            this.Caption = "Constant value";
            this.MaximumSize = new System.Drawing.Size(0, 53);
            this.MinimumSize = new System.Drawing.Size(93, 53);
            this.Name = "REConstantSmall";
            this.Size = new System.Drawing.Size(219, 53);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint reLinkPoint1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
