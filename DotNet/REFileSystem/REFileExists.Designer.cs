namespace REFileSystem
{
    partial class REFileExists
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
            this.lpInput = new RE.RELinkPoint();
            this.lpExists = new RE.RELinkPoint();
            this.lpNotFound = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpNotFound);
            this.panItemClient.Controls.Add(this.lpExists);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Size = new System.Drawing.Size(227, 35);
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
            this.lpInput.Size = new System.Drawing.Size(65, 16);
            this.lpInput.TabIndex = 0;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpExists
            // 
            this.lpExists.AllowDrop = true;
            this.lpExists.Caption = "exists";
            this.lpExists.ConnectedTo = null;
            this.lpExists.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpExists.Direction = RE.RELinkPointDirection.Output;
            this.lpExists.Key = "exists";
            this.lpExists.Location = new System.Drawing.Point(81, 10);
            this.lpExists.Name = "lpExists";
            this.lpExists.Size = new System.Drawing.Size(65, 16);
            this.lpExists.TabIndex = 1;
            // 
            // lpNotFound
            // 
            this.lpNotFound.AllowDrop = true;
            this.lpNotFound.Caption = "not found";
            this.lpNotFound.ConnectedTo = null;
            this.lpNotFound.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpNotFound.Direction = RE.RELinkPointDirection.Output;
            this.lpNotFound.Key = "notfound";
            this.lpNotFound.Location = new System.Drawing.Point(152, 10);
            this.lpNotFound.Name = "lpNotFound";
            this.lpNotFound.Size = new System.Drawing.Size(65, 16);
            this.lpNotFound.TabIndex = 2;
            // 
            // REFileExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "File Exists";
            this.Name = "REFileExists";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(234, 60);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpExists;
        private RE.RELinkPoint lpNotFound;
    }
}
