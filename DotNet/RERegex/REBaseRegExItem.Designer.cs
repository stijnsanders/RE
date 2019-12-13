namespace RERegex
{
    partial class REBaseRegExItem
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
            this.txtRegExPattern = new System.Windows.Forms.TextBox();
            this.cbRegExIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cbRegExMultiLine = new System.Windows.Forms.CheckBox();
            this.lpRegExInput = new RE.RELinkPoint();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explicitCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compiledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignorePatternWhitespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eCMAScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cultureInvariantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpRegExInput);
            this.panItemClient.Controls.Add(this.cbRegExMultiLine);
            this.panItemClient.Controls.Add(this.cbRegExIgnoreCase);
            this.panItemClient.Controls.Add(this.txtRegExPattern);
            this.panItemClient.Size = new System.Drawing.Size(214, 74);
            // 
            // txtRegExPattern
            // 
            this.txtRegExPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegExPattern.Location = new System.Drawing.Point(3, 3);
            this.txtRegExPattern.Name = "txtRegExPattern";
            this.txtRegExPattern.Size = new System.Drawing.Size(208, 21);
            this.txtRegExPattern.TabIndex = 0;
            // 
            // cbRegExIgnoreCase
            // 
            this.cbRegExIgnoreCase.AutoSize = true;
            this.cbRegExIgnoreCase.Checked = true;
            this.cbRegExIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRegExIgnoreCase.Location = new System.Drawing.Point(4, 30);
            this.cbRegExIgnoreCase.Name = "cbRegExIgnoreCase";
            this.cbRegExIgnoreCase.Size = new System.Drawing.Size(94, 17);
            this.cbRegExIgnoreCase.TabIndex = 1;
            this.cbRegExIgnoreCase.Text = "Ignore case";
            this.cbRegExIgnoreCase.UseVisualStyleBackColor = true;
            this.cbRegExIgnoreCase.CheckedChanged += new System.EventHandler(this.cbRegExIgnoreCase_CheckedChanged);
            // 
            // cbRegExMultiLine
            // 
            this.cbRegExMultiLine.AutoSize = true;
            this.cbRegExMultiLine.Checked = true;
            this.cbRegExMultiLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRegExMultiLine.Location = new System.Drawing.Point(104, 30);
            this.cbRegExMultiLine.Name = "cbRegExMultiLine";
            this.cbRegExMultiLine.Size = new System.Drawing.Size(77, 17);
            this.cbRegExMultiLine.TabIndex = 2;
            this.cbRegExMultiLine.Text = "Multi-line";
            this.cbRegExMultiLine.UseVisualStyleBackColor = true;
            this.cbRegExMultiLine.CheckedChanged += new System.EventHandler(this.cbRegExMultiLine_CheckedChanged);
            // 
            // lpRegExInput
            // 
            this.lpRegExInput.AllowDrop = true;
            this.lpRegExInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lpRegExInput.Caption = "input";
            this.lpRegExInput.ConnectedTo = null;
            this.lpRegExInput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpRegExInput.Direction = RE.RELinkPointDirection.Input;
            this.lpRegExInput.Key = "input";
            this.lpRegExInput.Location = new System.Drawing.Point(4, 54);
            this.lpRegExInput.Name = "lpRegExInput";
            this.lpRegExInput.Size = new System.Drawing.Size(48, 16);
            this.lpRegExInput.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkPatternToolStripMenuItem,
            this.explicitCaptureToolStripMenuItem,
            this.compiledToolStripMenuItem,
            this.ignorePatternWhitespaceToolStripMenuItem,
            this.rightToLeftToolStripMenuItem,
            this.eCMAScriptToolStripMenuItem,
            this.cultureInvariantToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 180);
            // 
            // checkPatternToolStripMenuItem
            // 
            this.checkPatternToolStripMenuItem.Name = "checkPatternToolStripMenuItem";
            this.checkPatternToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkPatternToolStripMenuItem.Text = "Check pattern";
            this.checkPatternToolStripMenuItem.Click += new System.EventHandler(this.checkPatternToolStripMenuItem_Click);
            // 
            // explicitCaptureToolStripMenuItem
            // 
            this.explicitCaptureToolStripMenuItem.Name = "explicitCaptureToolStripMenuItem";
            this.explicitCaptureToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.explicitCaptureToolStripMenuItem.Text = "Explicit capture";
            this.explicitCaptureToolStripMenuItem.Click += new System.EventHandler(this.explicitCaptureToolStripMenuItem_Click);
            // 
            // compiledToolStripMenuItem
            // 
            this.compiledToolStripMenuItem.Name = "compiledToolStripMenuItem";
            this.compiledToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.compiledToolStripMenuItem.Text = "Compiled";
            this.compiledToolStripMenuItem.Click += new System.EventHandler(this.compiledToolStripMenuItem_Click);
            // 
            // ignorePatternWhitespaceToolStripMenuItem
            // 
            this.ignorePatternWhitespaceToolStripMenuItem.Name = "ignorePatternWhitespaceToolStripMenuItem";
            this.ignorePatternWhitespaceToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.ignorePatternWhitespaceToolStripMenuItem.Text = "Ignore pattern whitespace";
            this.ignorePatternWhitespaceToolStripMenuItem.Click += new System.EventHandler(this.ignorePatternWhitespaceToolStripMenuItem_Click);
            // 
            // rightToLeftToolStripMenuItem
            // 
            this.rightToLeftToolStripMenuItem.Name = "rightToLeftToolStripMenuItem";
            this.rightToLeftToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.rightToLeftToolStripMenuItem.Text = "Right to left";
            this.rightToLeftToolStripMenuItem.Click += new System.EventHandler(this.rightToLeftToolStripMenuItem_Click);
            // 
            // eCMAScriptToolStripMenuItem
            // 
            this.eCMAScriptToolStripMenuItem.Name = "eCMAScriptToolStripMenuItem";
            this.eCMAScriptToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.eCMAScriptToolStripMenuItem.Text = "ECMA Script";
            this.eCMAScriptToolStripMenuItem.Click += new System.EventHandler(this.eCMAScriptToolStripMenuItem_Click);
            // 
            // cultureInvariantToolStripMenuItem
            // 
            this.cultureInvariantToolStripMenuItem.Name = "cultureInvariantToolStripMenuItem";
            this.cultureInvariantToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cultureInvariantToolStripMenuItem.Text = "Culture invariant";
            this.cultureInvariantToolStripMenuItem.Click += new System.EventHandler(this.cultureInvariantToolStripMenuItem_Click);
            // 
            // REBaseRegExItem
            // 
            this.Caption = "REBaseRegExItem";
            this.MaximumSize = new System.Drawing.Size(0, 99);
            this.MergeContextMenuStrip = this.contextMenuStrip1;
            this.MinimumSize = new System.Drawing.Size(221, 99);
            this.Name = "REBaseRegExItem";
            this.Size = new System.Drawing.Size(221, 99);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRegExMultiLine;
        private System.Windows.Forms.CheckBox cbRegExIgnoreCase;
        private System.Windows.Forms.ToolStripMenuItem checkPatternToolStripMenuItem;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        protected RE.RELinkPoint lpRegExInput;
        protected System.Windows.Forms.TextBox txtRegExPattern;
        private System.Windows.Forms.ToolStripMenuItem explicitCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compiledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignorePatternWhitespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eCMAScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cultureInvariantToolStripMenuItem;
    }
}
