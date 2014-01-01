namespace REBasic
{
    partial class REFileLarge
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lpList = new RE.RELinkPoint();
            this.lpWrite = new RE.RELinkPoint();
            this.lpRead = new RE.RELinkPoint();
            this.cbReadStyle = new System.Windows.Forms.ComboBox();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panItemClient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.txtParameter);
            this.panItemClient.Controls.Add(this.cbReadStyle);
            this.panItemClient.Controls.Add(this.lpWrite);
            this.panItemClient.Controls.Add(this.lpList);
            this.panItemClient.Controls.Add(this.button1);
            this.panItemClient.Controls.Add(this.lpRead);
            this.panItemClient.Controls.Add(this.txtFilePath);
            this.panItemClient.Size = new System.Drawing.Size(242, 78);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(3, 3);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(169, 21);
            this.txtFilePath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(178, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All files (*.*)|*.*";
            // 
            // lpList
            // 
            this.lpList.AllowDrop = true;
            this.lpList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lpList.Caption = "";
            this.lpList.ConnectedTo = null;
            this.lpList.ConnectionColor = System.Drawing.Color.Empty;
            this.lpList.Direction = RE.RELinkPointDirection.Input;
            this.lpList.Key = "list";
            this.lpList.Location = new System.Drawing.Point(215, 3);
            this.lpList.Name = "lpList";
            this.lpList.Size = new System.Drawing.Size(24, 20);
            this.lpList.TabIndex = 2;
            this.lpList.Signal += new RE.RELinkPointSignal(this.lpList_Signal);
            // 
            // lpWrite
            // 
            this.lpWrite.AllowDrop = true;
            this.lpWrite.Caption = "write to file";
            this.lpWrite.ConnectedTo = null;
            this.lpWrite.ConnectionColor = System.Drawing.Color.Empty;
            this.lpWrite.Direction = RE.RELinkPointDirection.Input;
            this.lpWrite.Key = "write";
            this.lpWrite.Location = new System.Drawing.Point(3, 58);
            this.lpWrite.Name = "lpWrite";
            this.lpWrite.Size = new System.Drawing.Size(92, 16);
            this.lpWrite.TabIndex = 3;
            this.lpWrite.Signal += new RE.RELinkPointSignal(this.lpWrite_Signal);
            // 
            // lpRead
            // 
            this.lpRead.AllowDrop = true;
            this.lpRead.Caption = "read from file";
            this.lpRead.ConnectedTo = null;
            this.lpRead.ConnectionColor = System.Drawing.Color.Empty;
            this.lpRead.Direction = RE.RELinkPointDirection.Output;
            this.lpRead.Key = "read";
            this.lpRead.Location = new System.Drawing.Point(101, 58);
            this.lpRead.Name = "lpRead";
            this.lpRead.Size = new System.Drawing.Size(92, 16);
            this.lpRead.TabIndex = 4;
            this.lpRead.Signal += new RE.RELinkPointSignal(this.lpRead_Signal);
            // 
            // cbReadStyle
            // 
            this.cbReadStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReadStyle.FormattingEnabled = true;
            this.cbReadStyle.Items.AddRange(new object[] {
            "Line-by-line",
            "Fixed size blocks, length:",
            "Separator:",
            "Number of lines:"});
            this.cbReadStyle.Location = new System.Drawing.Point(4, 31);
            this.cbReadStyle.Name = "cbReadStyle";
            this.cbReadStyle.Size = new System.Drawing.Size(168, 21);
            this.cbReadStyle.TabIndex = 5;
            this.cbReadStyle.SelectedIndexChanged += new System.EventHandler(this.cbReadStyle_SelectedIndexChanged);
            // 
            // txtParameter
            // 
            this.txtParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameter.Location = new System.Drawing.Point(178, 31);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(61, 21);
            this.txtParameter.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFileLocationToolStripMenuItem,
            this.pasteFileLocationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 48);
            // 
            // copyFileLocationToolStripMenuItem
            // 
            this.copyFileLocationToolStripMenuItem.Name = "copyFileLocationToolStripMenuItem";
            this.copyFileLocationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyFileLocationToolStripMenuItem.Text = "Copy file location";
            this.copyFileLocationToolStripMenuItem.Click += new System.EventHandler(this.copyFileLocationToolStripMenuItem_Click);
            // 
            // pasteFileLocationToolStripMenuItem
            // 
            this.pasteFileLocationToolStripMenuItem.Name = "pasteFileLocationToolStripMenuItem";
            this.pasteFileLocationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pasteFileLocationToolStripMenuItem.Text = "Paste file location";
            this.pasteFileLocationToolStripMenuItem.Click += new System.EventHandler(this.pasteFileLocationToolStripMenuItem_Click);
            // 
            // REFileLarge
            // 
            this.Caption = "Large file";
            this.MaximumSize = new System.Drawing.Size(0, 103);
            this.MinimumSize = new System.Drawing.Size(249, 103);
            this.Name = "REFileLarge";
            this.Size = new System.Drawing.Size(249, 103);
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private RE.RELinkPoint lpRead;
        private RE.RELinkPoint lpWrite;
        private System.Windows.Forms.ComboBox cbReadStyle;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteFileLocationToolStripMenuItem;
    }
}
