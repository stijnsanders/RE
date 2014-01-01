namespace REBasic
{
    partial class REClipboard
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
            this.lpGet = new RE.RELinkPoint();
            this.lpSet = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpSet);
            this.panItemClient.Controls.Add(this.lpGet);
            this.panItemClient.Size = new System.Drawing.Size(119, 32);
            // 
            // lpGet
            // 
            this.lpGet.AllowDrop = true;
            this.lpGet.Caption = "get";
            this.lpGet.ConnectedTo = null;
            this.lpGet.ConnectionColor = System.Drawing.Color.Empty;
            this.lpGet.Direction = RE.RELinkPointDirection.Output;
            this.lpGet.Key = "get";
            this.lpGet.Location = new System.Drawing.Point(62, 8);
            this.lpGet.Name = "lpGet";
            this.lpGet.Size = new System.Drawing.Size(48, 16);
            this.lpGet.TabIndex = 0;
            // 
            // lpSet
            // 
            this.lpSet.AllowDrop = true;
            this.lpSet.Caption = "set";
            this.lpSet.ConnectedTo = null;
            this.lpSet.ConnectionColor = System.Drawing.Color.Empty;
            this.lpSet.Direction = RE.RELinkPointDirection.Input;
            this.lpSet.Key = "set";
            this.lpSet.Location = new System.Drawing.Point(8, 8);
            this.lpSet.Name = "lpSet";
            this.lpSet.Size = new System.Drawing.Size(48, 16);
            this.lpSet.TabIndex = 1;
            // 
            // REClipboard
            // 
            this.Caption = "Clipboard";
            this.MinimumSize = new System.Drawing.Size(0, 40);
            this.Name = "REClipboard";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(126, 57);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpSet;
        private RE.RELinkPoint lpGet;
    }
}
