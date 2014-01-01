namespace REXML
{
    partial class RETextToXml
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
            this.lpOutput = new RE.RELinkPoint();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preserveWhiteSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Size = new System.Drawing.Size(124, 35);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(10, 10);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 0;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "xml";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(64, 10);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preserveWhiteSpaceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 48);
            // 
            // preserveWhiteSpaceToolStripMenuItem
            // 
            this.preserveWhiteSpaceToolStripMenuItem.Name = "preserveWhiteSpaceToolStripMenuItem";
            this.preserveWhiteSpaceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.preserveWhiteSpaceToolStripMenuItem.Text = "PreserveWhiteSpace";
            this.preserveWhiteSpaceToolStripMenuItem.Click += new System.EventHandler(this.preserveWhiteSpaceToolStripMenuItem_Click);
            // 
            // RETextToXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "text to XML";
            this.Name = "RETextToXml";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(131, 60);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpOutput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem preserveWhiteSpaceToolStripMenuItem;
    }
}
