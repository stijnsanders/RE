namespace REBasic
{
    partial class REComment
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.readonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.textBox1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 122);
            this.textBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.underlineToolStripMenuItem,
            this.toolStripMenuItem1,
            this.readonlyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 98);
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.boldToolStripMenuItem.Text = "Bold";
            this.boldToolStripMenuItem.CheckedChanged += new System.EventHandler(this.boldToolStripMenuItem_CheckedChanged);
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.toggleToolStripMenuItem);
            // 
            // italicToolStripMenuItem
            // 
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.italicToolStripMenuItem.Text = "Italic";
            this.italicToolStripMenuItem.CheckedChanged += new System.EventHandler(this.italicToolStripMenuItem_CheckedChanged);
            this.italicToolStripMenuItem.Click += new System.EventHandler(this.toggleToolStripMenuItem);
            // 
            // underlineToolStripMenuItem
            // 
            this.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem";
            this.underlineToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.underlineToolStripMenuItem.Text = "Underline";
            this.underlineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.underlineToolStripMenuItem_CheckedChanged);
            this.underlineToolStripMenuItem.Click += new System.EventHandler(this.toggleToolStripMenuItem);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 6);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            this.readonlyToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.readonlyToolStripMenuItem.Text = "Read-only";
            this.readonlyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.readonlyToolStripMenuItem_CheckedChanged);
            this.readonlyToolStripMenuItem.Click += new System.EventHandler(this.toggleToolStripMenuItem);
            // 
            // REComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Comment";
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "REComment";
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem readonlyToolStripMenuItem;
    }
}
