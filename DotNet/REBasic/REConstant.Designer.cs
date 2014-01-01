namespace REBasic
{
    partial class REConstant
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
            this.components = new System.ComponentModel.Container();
            this.reLinkPoint1 = new RE.RELinkPoint();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.reLinkPoint1);
            this.panItemClient.Controls.Add(this.textBox1);
            // 
            // reLinkPoint1
            // 
            this.reLinkPoint1.AllowDrop = true;
            this.reLinkPoint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reLinkPoint1.Caption = "";
            this.reLinkPoint1.ConnectedTo = null;
            this.reLinkPoint1.ConnectionColor = System.Drawing.Color.Empty;
            this.reLinkPoint1.Direction = RE.RELinkPointDirection.Output;
            this.reLinkPoint1.Key = "output";
            this.reLinkPoint1.Location = new System.Drawing.Point(4, 103);
            this.reLinkPoint1.Name = "reLinkPoint1";
            this.reLinkPoint1.Size = new System.Drawing.Size(48, 16);
            this.reLinkPoint1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(195, 94);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.wordWrapToolStripMenuItem.Text = "Word wrap";
            this.wordWrapToolStripMenuItem.CheckedChanged += new System.EventHandler(this.wordWrapToolStripMenuItem_CheckedChanged);
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // REConstant
            // 
            this.Caption = "Constant value";
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "REConstant";
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint reLinkPoint1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
    }
}
