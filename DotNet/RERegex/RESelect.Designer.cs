namespace RERegex
{
    partial class RESelect
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
            this.reLinkPoint1 = new RE.RELinkPoint();
            this.reLinkPoint2 = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.reLinkPoint2);
            this.panItemClient.Controls.Add(this.reLinkPoint1);
            this.panItemClient.Controls.SetChildIndex(this.reLinkPoint1, 0);
            this.panItemClient.Controls.SetChildIndex(this.reLinkPoint2, 0);
            this.panItemClient.Controls.SetChildIndex(this.lpRegExInput, 0);
            // 
            // reLinkPoint1
            // 
            this.reLinkPoint1.AllowDrop = true;
            this.reLinkPoint1.Caption = "matches";
            this.reLinkPoint1.ConnectedTo = null;
            this.reLinkPoint1.ConnectionColor = System.Drawing.Color.Empty;
            this.reLinkPoint1.Direction = RE.RELinkPointDirection.Output;
            this.reLinkPoint1.Key = "match";
            this.reLinkPoint1.Location = new System.Drawing.Point(59, 54);
            this.reLinkPoint1.Name = "reLinkPoint1";
            this.reLinkPoint1.Size = new System.Drawing.Size(57, 16);
            this.reLinkPoint1.TabIndex = 4;
            // 
            // reLinkPoint2
            // 
            this.reLinkPoint2.AllowDrop = true;
            this.reLinkPoint2.Caption = "doesn\'t match";
            this.reLinkPoint2.ConnectedTo = null;
            this.reLinkPoint2.ConnectionColor = System.Drawing.Color.Empty;
            this.reLinkPoint2.Direction = RE.RELinkPointDirection.Output;
            this.reLinkPoint2.Key = "nomatch";
            this.reLinkPoint2.Location = new System.Drawing.Point(122, 54);
            this.reLinkPoint2.Name = "reLinkPoint2";
            this.reLinkPoint2.Size = new System.Drawing.Size(89, 16);
            this.reLinkPoint2.TabIndex = 5;
            // 
            // RESelect
            // 
            this.Caption = "Select";
            this.Name = "RESelect";
            this.Controls.SetChildIndex(this.panItemClient, 0);
            this.panItemClient.ResumeLayout(false);
            this.panItemClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint reLinkPoint2;
        private RE.RELinkPoint reLinkPoint1;
    }
}
