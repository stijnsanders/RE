namespace REMulti
{
    partial class REIndex
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
            this.lpCount = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.txtFormatPar = new System.Windows.Forms.TextBox();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.txtFormatPar);
            this.panItemClient.Controls.Add(this.cbFormat);
            this.panItemClient.Controls.Add(this.label3);
            this.panItemClient.Controls.Add(this.txtStep);
            this.panItemClient.Controls.Add(this.txtStart);
            this.panItemClient.Controls.Add(this.label2);
            this.panItemClient.Controls.Add(this.label1);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpCount);
            this.panItemClient.Size = new System.Drawing.Size(218, 108);
            // 
            // lpCount
            // 
            this.lpCount.AllowDrop = true;
            this.lpCount.Caption = "count";
            this.lpCount.ConnectedTo = null;
            this.lpCount.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpCount.Direction = RE.RELinkPointDirection.Input;
            this.lpCount.Key = "count";
            this.lpCount.Location = new System.Drawing.Point(6, 85);
            this.lpCount.Name = "lpCount";
            this.lpCount.Size = new System.Drawing.Size(48, 16);
            this.lpCount.TabIndex = 0;
            this.lpCount.Signal += new RE.RELinkPointSignal(this.lpCount_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(60, 85);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 1;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(6, 17);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 21);
            this.txtStart.TabIndex = 4;
            this.txtStart.Text = "1";
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(112, 17);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(100, 21);
            this.txtStep.TabIndex = 5;
            this.txtStep.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Format";
            // 
            // cbFormat
            // 
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "Variable length",
            "Left-pad zeroes to:",
            "Left-pad spaces to:",
            "Hexadecimal"});
            this.cbFormat.Location = new System.Drawing.Point(6, 58);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(140, 21);
            this.cbFormat.TabIndex = 7;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // txtFormatPar
            // 
            this.txtFormatPar.Location = new System.Drawing.Point(152, 58);
            this.txtFormatPar.Name = "txtFormatPar";
            this.txtFormatPar.Size = new System.Drawing.Size(60, 21);
            this.txtFormatPar.TabIndex = 8;
            // 
            // REIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Index";
            this.Name = "REIndex";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(225, 133);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpCount;
        private System.Windows.Forms.TextBox txtFormatPar;
    }
}
