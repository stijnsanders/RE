namespace REMulti
{
    partial class REUnique
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
            this.lpInput = new RE.RELinkPoint();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ignoreCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lpUnique = new RE.RELinkPoint();
            this.lpDuplicate = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpDuplicate);
            this.panItemClient.Controls.Add(this.lpUnique);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Size = new System.Drawing.Size(143, 55);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(8, 8);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(60, 16);
            this.lpInput.TabIndex = 0;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreCaseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
            // 
            // ignoreCaseToolStripMenuItem
            // 
            this.ignoreCaseToolStripMenuItem.Name = "ignoreCaseToolStripMenuItem";
            this.ignoreCaseToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ignoreCaseToolStripMenuItem.Text = "Ignore case";
            this.ignoreCaseToolStripMenuItem.Click += new System.EventHandler(this.ignoreCaseToolStripMenuItem_Click);
            // 
            // lpUnique
            // 
            this.lpUnique.AllowDrop = true;
            this.lpUnique.Caption = "unique";
            this.lpUnique.ConnectedTo = null;
            this.lpUnique.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpUnique.Direction = RE.RELinkPointDirection.Output;
            this.lpUnique.Key = "unique";
            this.lpUnique.Location = new System.Drawing.Point(74, 8);
            this.lpUnique.Name = "lpUnique";
            this.lpUnique.Size = new System.Drawing.Size(60, 16);
            this.lpUnique.TabIndex = 1;
            this.lpUnique.Signal += new RE.RELinkPointSignal(this.lpUnique_Signal);
            // 
            // lpDuplicate
            // 
            this.lpDuplicate.AllowDrop = true;
            this.lpDuplicate.Caption = "duplicate";
            this.lpDuplicate.ConnectedTo = null;
            this.lpDuplicate.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpDuplicate.Direction = RE.RELinkPointDirection.Output;
            this.lpDuplicate.Key = "duplicate";
            this.lpDuplicate.Location = new System.Drawing.Point(74, 30);
            this.lpDuplicate.Name = "lpDuplicate";
            this.lpDuplicate.Size = new System.Drawing.Size(60, 16);
            this.lpDuplicate.TabIndex = 2;
            // 
            // REUnique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Unique";
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "REUnique";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(150, 80);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ignoreCaseToolStripMenuItem;
        private RE.RELinkPoint lpDuplicate;
        private RE.RELinkPoint lpUnique;
    }
}
