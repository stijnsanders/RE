namespace RERegex
{
    partial class REReplace
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
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbGlobal = new System.Windows.Forms.CheckBox();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lpRegExInput
            // 
            this.lpRegExInput.Location = new System.Drawing.Point(4, 100);
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.cbGlobal);
            this.panItemClient.Controls.Add(this.textBox1);
            this.panItemClient.Size = new System.Drawing.Size(253, 120);
            this.panItemClient.Controls.SetChildIndex(this.textBox1, 0);
            this.panItemClient.Controls.SetChildIndex(this.cbGlobal, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpOutput, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpRegExInput, 0);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 54);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(246, 40);
            this.textBox1.TabIndex = 4;
            this.textBox1.WordWrap = false;
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wordWrapToolStripMenuItem.Text = "Word wrap";
            this.wordWrapToolStripMenuItem.CheckedChanged += new System.EventHandler(this.wordWrapToolStripMenuItem_CheckedChanged);
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // cbGlobal
            // 
            this.cbGlobal.AutoSize = true;
            this.cbGlobal.Checked = true;
            this.cbGlobal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGlobal.Location = new System.Drawing.Point(188, 30);
            this.cbGlobal.Name = "cbGlobal";
            this.cbGlobal.Size = new System.Drawing.Size(62, 17);
            this.cbGlobal.TabIndex = 5;
            this.cbGlobal.Text = "Global";
            this.cbGlobal.UseVisualStyleBackColor = true;
            this.cbGlobal.CheckedChanged += new System.EventHandler(this.cbGlobal_CheckedChanged);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(59, 100);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 6;
            // 
            // REReplace
            // 
            this.Caption = "Replace";
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimumSize = new System.Drawing.Size(255, 145);
            this.Name = "REReplace";
            this.Size = new System.Drawing.Size(260, 145);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbGlobal;
        private RE.RELinkPoint lpOutput;
    }
}
