namespace REMulti
{
    partial class RERepeat
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
            this.lpIndex = new RE.RELinkPoint();
            this.lpEcho = new RE.RELinkPoint();
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.passAsItComesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.lpEcho);
            this.panItemClient.Controls.Add(this.lpIndex);
            this.panItemClient.Size = new System.Drawing.Size(110, 46);
            // 
            // lpIndex
            // 
            this.lpIndex.AllowDrop = true;
            this.lpIndex.Caption = "index";
            this.lpIndex.ConnectedTo = null;
            this.lpIndex.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpIndex.Direction = RE.RELinkPointDirection.Input;
            this.lpIndex.Key = "index";
            this.lpIndex.Location = new System.Drawing.Point(4, 3);
            this.lpIndex.Name = "lpIndex";
            this.lpIndex.Size = new System.Drawing.Size(48, 16);
            this.lpIndex.TabIndex = 0;
            this.lpIndex.Signal += new RE.RELinkPointSignal(this.lpIndex_Signal);
            // 
            // lpEcho
            // 
            this.lpEcho.AllowDrop = true;
            this.lpEcho.Caption = "echo";
            this.lpEcho.ConnectedTo = null;
            this.lpEcho.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpEcho.Direction = RE.RELinkPointDirection.Output;
            this.lpEcho.Key = "echo";
            this.lpEcho.Location = new System.Drawing.Point(58, 3);
            this.lpEcho.Name = "lpEcho";
            this.lpEcho.Size = new System.Drawing.Size(48, 16);
            this.lpEcho.TabIndex = 1;
            this.lpEcho.Signal += new RE.RELinkPointSignal(this.lpEcho_Signal);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(4, 26);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 2;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(58, 26);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 3;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
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
            // RERepeat
            // 
            this.Caption = "Repeat";
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "RERepeat";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(117, 71);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpIndex;
        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpEcho;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem passAsItComesToolStripMenuItem;
    }
}
