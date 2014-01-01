namespace REFileSystem
{
    partial class REListFiles
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lpList = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbRecurse = new System.Windows.Forms.CheckBox();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.cbRecurse);
            this.panItemClient.Controls.Add(this.button1);
            this.panItemClient.Controls.Add(this.txtPattern);
            this.panItemClient.Controls.Add(this.label2);
            this.panItemClient.Controls.Add(this.label1);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpList);
            this.panItemClient.Controls.Add(this.txtPath);
            this.panItemClient.Size = new System.Drawing.Size(161, 133);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(3, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(100, 21);
            this.txtPath.TabIndex = 0;
            // 
            // lpList
            // 
            this.lpList.AllowDrop = true;
            this.lpList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lpList.Caption = "";
            this.lpList.ConnectedTo = null;
            this.lpList.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpList.Direction = RE.RELinkPointDirection.Input;
            this.lpList.Key = "list";
            this.lpList.Location = new System.Drawing.Point(136, 20);
            this.lpList.Name = "lpList";
            this.lpList.Size = new System.Drawing.Size(21, 21);
            this.lpList.TabIndex = 1;
            this.lpList.Signal += new RE.RELinkPointSignal(this.lpList_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(3, 112);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 2;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search pattern";
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(3, 61);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(154, 21);
            this.txtPattern.TabIndex = 5;
            this.txtPattern.Text = "*.*";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(109, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 21);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbRecurse
            // 
            this.cbRecurse.AutoSize = true;
            this.cbRecurse.Location = new System.Drawing.Point(4, 89);
            this.cbRecurse.Name = "cbRecurse";
            this.cbRecurse.Size = new System.Drawing.Size(153, 17);
            this.cbRecurse.TabIndex = 7;
            this.cbRecurse.Text = "search sub-directories";
            this.cbRecurse.UseVisualStyleBackColor = true;
            this.cbRecurse.CheckedChanged += new System.EventHandler(this.cbRecurse_CheckedChanged);
            // 
            // REListFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "List Files";
            this.MaximumSize = new System.Drawing.Size(0, 158);
            this.MinimumSize = new System.Drawing.Size(168, 158);
            this.Name = "REListFiles";
            this.Size = new System.Drawing.Size(168, 158);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpList;
        private System.Windows.Forms.TextBox txtPath;
        private RE.RELinkPoint lpOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbRecurse;
    }
}
