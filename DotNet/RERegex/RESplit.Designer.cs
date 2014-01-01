namespace RERegex
{
    partial class RESplit
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
            this.lpInbetweens = new RE.RELinkPoint();
            this.lpMatches = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lpRegExInput
            // 
            this.lpRegExInput.Signal += new RE.RELinkPointSignal(this.lpRegExInput_Signal);
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpMatches);
            this.panItemClient.Controls.Add(this.lpInbetweens);
            this.panItemClient.Controls.SetChildIndex(this.lpInbetweens, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpMatches, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpRegExInput, 0);
            // 
            // lpInbetweens
            // 
            this.lpInbetweens.AllowDrop = true;
            this.lpInbetweens.Caption = "inbetweens";
            this.lpInbetweens.ConnectedTo = null;
            this.lpInbetweens.ConnectionColor = System.Drawing.Color.Empty;
            this.lpInbetweens.Direction = RE.RELinkPointDirection.Output;
            this.lpInbetweens.Key = "nomatch";
            this.lpInbetweens.Location = new System.Drawing.Point(60, 54);
            this.lpInbetweens.Name = "lpInbetweens";
            this.lpInbetweens.Size = new System.Drawing.Size(85, 16);
            this.lpInbetweens.TabIndex = 4;
            this.lpInbetweens.Signal += new RE.RELinkPointSignal(this.lpInbetweens_Signal);
            // 
            // lpMatches
            // 
            this.lpMatches.AllowDrop = true;
            this.lpMatches.Caption = "matches";
            this.lpMatches.ConnectedTo = null;
            this.lpMatches.ConnectionColor = System.Drawing.Color.Empty;
            this.lpMatches.Direction = RE.RELinkPointDirection.Output;
            this.lpMatches.Key = "match";
            this.lpMatches.Location = new System.Drawing.Point(151, 54);
            this.lpMatches.Name = "lpMatches";
            this.lpMatches.Size = new System.Drawing.Size(60, 16);
            this.lpMatches.TabIndex = 5;
            this.lpMatches.Signal += new RE.RELinkPointSignal(this.lpMatches_Signal);
            // 
            // RESplit
            // 
            this.Caption = "Split";
            this.Name = "RESplit";
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInbetweens;
        private RE.RELinkPoint lpMatches;
    }
}
