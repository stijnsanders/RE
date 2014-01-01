namespace REMulti
{
    partial class REJoin
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
            this.lpOutput = new RE.RELinkPoint();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.passAsItComesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.btnMinus);
            this.panItemClient.Controls.Add(this.btnPlus);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Size = new System.Drawing.Size(123, 49);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(63, 26);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(57, 16);
            this.lpOutput.TabIndex = 0;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
            // 
            // btnPlus
            // 
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Image = global::REMulti.Properties.Resources.Plus;
            this.btnPlus.Location = new System.Drawing.Point(3, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(17, 17);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Image = global::REMulti.Properties.Resources.Minus;
            this.btnMinus.Location = new System.Drawing.Point(26, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(17, 17);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passAsItComesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 26);
            // 
            // passAsItComesToolStripMenuItem
            // 
            this.passAsItComesToolStripMenuItem.Name = "passAsItComesToolStripMenuItem";
            this.passAsItComesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.passAsItComesToolStripMenuItem.Text = "Pass as it comes";
            this.passAsItComesToolStripMenuItem.Click += new System.EventHandler(this.passAsItComesToolStripMenuItem_Click);
            // 
            // REJoin
            // 
            this.Caption = "Join";
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "REJoin";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(130, 74);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem passAsItComesToolStripMenuItem;
    }
}
