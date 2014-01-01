namespace RERegex
{
    partial class REGroups
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
            this.lpInbetweens = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lpRegExInput
            // 
            this.lpRegExInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lpRegExInput.Location = new System.Drawing.Point(4, 53);
            this.lpRegExInput.Signal += new RE.RELinkPointSignal(this.lpRegExInput_Signal);
            // 
            // txtRegExPattern
            // 
            this.txtRegExPattern.Size = new System.Drawing.Size(210, 21);
            this.txtRegExPattern.TextChanged += new System.EventHandler(this.txtRegExPattern_TextChanged);
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpInbetweens);
            this.panItemClient.Controls.SetChildIndex(this.txtRegExPattern, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpRegExInput, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpInbetweens, 0);
            // 
            // lpInbetweens
            // 
            this.lpInbetweens.AllowDrop = true;
            this.lpInbetweens.Caption = "inbetweens";
            this.lpInbetweens.ConnectedTo = null;
            this.lpInbetweens.ConnectionColor = System.Drawing.Color.Empty;
            this.lpInbetweens.Direction = RE.RELinkPointDirection.Output;
            this.lpInbetweens.Key = "nomatch";
            this.lpInbetweens.Location = new System.Drawing.Point(58, 53);
            this.lpInbetweens.Name = "lpInbetweens";
            this.lpInbetweens.Size = new System.Drawing.Size(85, 16);
            this.lpInbetweens.TabIndex = 6;
            this.lpInbetweens.Signal += new RE.RELinkPointSignal(this.lpMatch_Signal);
            // 
            // REGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Groups";
            this.Name = "REGroups";
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInbetweens;

    }
}
