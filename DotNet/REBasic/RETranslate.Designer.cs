namespace REBasic
{
    partial class RETranslate
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
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panItems = new System.Windows.Forms.Panel();
            this.cbGlobal = new System.Windows.Forms.CheckBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panColumn1 = new System.Windows.Forms.Panel();
            this.lblReplace = new System.Windows.Forms.Label();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lblReplace);
            this.panItemClient.Controls.Add(this.panColumn1);
            this.panItemClient.Controls.Add(this.lblSearch);
            this.panItemClient.Controls.Add(this.panItems);
            this.panItemClient.Controls.Add(this.btnDown);
            this.panItemClient.Controls.Add(this.btnUp);
            this.panItemClient.Controls.Add(this.cbGlobal);
            this.panItemClient.Controls.Add(this.cbIgnoreCase);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.btnMinus);
            this.panItemClient.Controls.Add(this.btnPlus);
            this.panItemClient.Size = new System.Drawing.Size(265, 122);
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Image = global::REBasic.Properties.Resources.Minus;
            this.btnMinus.Location = new System.Drawing.Point(26, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(17, 17);
            this.btnMinus.TabIndex = 5;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Image = global::REBasic.Properties.Resources.Plus;
            this.btnPlus.Location = new System.Drawing.Point(3, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(17, 17);
            this.btnPlus.TabIndex = 4;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(3, 103);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 6;
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(58, 103);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 7;
            // 
            // cbIgnoreCase
            // 
            this.cbIgnoreCase.AutoSize = true;
            this.cbIgnoreCase.Checked = true;
            this.cbIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIgnoreCase.Location = new System.Drawing.Point(100, 3);
            this.cbIgnoreCase.Name = "cbIgnoreCase";
            this.cbIgnoreCase.Size = new System.Drawing.Size(94, 17);
            this.cbIgnoreCase.TabIndex = 9;
            this.cbIgnoreCase.Text = "Ignore case";
            this.cbIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Image = global::REBasic.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(72, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(17, 17);
            this.btnDown.TabIndex = 12;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Image = global::REBasic.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(49, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(17, 17);
            this.btnUp.TabIndex = 11;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panItems
            // 
            this.panItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panItems.AutoScroll = true;
            this.panItems.Location = new System.Drawing.Point(4, 43);
            this.panItems.Name = "panItems";
            this.panItems.Size = new System.Drawing.Size(258, 54);
            this.panItems.TabIndex = 13;
            // 
            // cbGlobal
            // 
            this.cbGlobal.AutoSize = true;
            this.cbGlobal.Checked = true;
            this.cbGlobal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGlobal.Location = new System.Drawing.Point(200, 3);
            this.cbGlobal.Name = "cbGlobal";
            this.cbGlobal.Size = new System.Drawing.Size(62, 17);
            this.cbGlobal.TabIndex = 10;
            this.cbGlobal.Text = "Global";
            this.cbGlobal.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(4, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search";
            // 
            // panColumn1
            // 
            this.panColumn1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panColumn1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.panColumn1.Location = new System.Drawing.Point(110, 22);
            this.panColumn1.Name = "panColumn1";
            this.panColumn1.Size = new System.Drawing.Size(8, 21);
            this.panColumn1.TabIndex = 15;
            this.panColumn1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panColumn1_MouseMove);
            this.panColumn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panColumn1_MouseDown);
            this.panColumn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panColumn1_MouseUp);
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(113, 27);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(52, 13);
            this.lblReplace.TabIndex = 16;
            this.lblReplace.Text = "Replace";
            // 
            // RETranslate
            // 
            this.Caption = "Translate";
            this.Name = "RETranslate";
            this.Size = new System.Drawing.Size(272, 147);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.CheckBox cbIgnoreCase;
        private System.Windows.Forms.Panel panItems;
        private System.Windows.Forms.CheckBox cbGlobal;
        private System.Windows.Forms.Panel panColumn1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblReplace;
    }
}
