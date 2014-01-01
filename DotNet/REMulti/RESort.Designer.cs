namespace REMulti
{
    partial class RESort
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
            this.lpInput = new RE.RELinkPoint();
            this.lpSortBy = new RE.RELinkPoint();
            this.lpPrepare = new RE.RELinkPoint();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ignoreCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpSortBy);
            this.panItemClient.Controls.Add(this.lpPrepare);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Size = new System.Drawing.Size(241, 35);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(182, 9);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(52, 16);
            this.lpOutput.TabIndex = 11;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(8, 9);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(52, 16);
            this.lpInput.TabIndex = 10;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpSortBy
            // 
            this.lpSortBy.AllowDrop = true;
            this.lpSortBy.Caption = "sort by";
            this.lpSortBy.ConnectedTo = null;
            this.lpSortBy.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpSortBy.Direction = RE.RELinkPointDirection.Input;
            this.lpSortBy.Key = "sortby";
            this.lpSortBy.Location = new System.Drawing.Point(124, 9);
            this.lpSortBy.Name = "lpSortBy";
            this.lpSortBy.Size = new System.Drawing.Size(52, 16);
            this.lpSortBy.TabIndex = 13;
            this.lpSortBy.Signal += new RE.RELinkPointSignal(this.lpSortBy_Signal);
            // 
            // lpPrepare
            // 
            this.lpPrepare.AllowDrop = true;
            this.lpPrepare.Caption = "prepare";
            this.lpPrepare.ConnectedTo = null;
            this.lpPrepare.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpPrepare.Direction = RE.RELinkPointDirection.Output;
            this.lpPrepare.Key = "prepare";
            this.lpPrepare.Location = new System.Drawing.Point(66, 9);
            this.lpPrepare.Name = "lpPrepare";
            this.lpPrepare.Size = new System.Drawing.Size(52, 16);
            this.lpPrepare.TabIndex = 12;
            this.lpPrepare.Signal += new RE.RELinkPointSignal(this.lpPrepare_Signal);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreCaseToolStripMenuItem,
            this.numericToolStripMenuItem,
            this.allowDuplicatesToolStripMenuItem,
            this.descendingToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 92);
            // 
            // ignoreCaseToolStripMenuItem
            // 
            this.ignoreCaseToolStripMenuItem.Checked = true;
            this.ignoreCaseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCaseToolStripMenuItem.Name = "ignoreCaseToolStripMenuItem";
            this.ignoreCaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ignoreCaseToolStripMenuItem.Text = "Ignore case";
            this.ignoreCaseToolStripMenuItem.Click += new System.EventHandler(this.ignoreCaseToolStripMenuItem_Click);
            // 
            // numericToolStripMenuItem
            // 
            this.numericToolStripMenuItem.Name = "numericToolStripMenuItem";
            this.numericToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.numericToolStripMenuItem.Text = "Numeric";
            this.numericToolStripMenuItem.Click += new System.EventHandler(this.numericToolStripMenuItem_Click);
            // 
            // allowDuplicatesToolStripMenuItem
            // 
            this.allowDuplicatesToolStripMenuItem.Checked = true;
            this.allowDuplicatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowDuplicatesToolStripMenuItem.Name = "allowDuplicatesToolStripMenuItem";
            this.allowDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.allowDuplicatesToolStripMenuItem.Text = "Allow duplicates";
            this.allowDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.allowDuplicatesToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.descendingToolStripMenuItem_Click);
            // 
            // RESort
            // 
            this.Caption = "Sort";
            this.ContextMenuStrip = null;
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.Name = "RESort";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(248, 60);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpSortBy;
        private RE.RELinkPoint lpPrepare;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ignoreCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowDuplicatesToolStripMenuItem;
    }
}
