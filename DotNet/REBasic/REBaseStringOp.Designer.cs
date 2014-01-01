namespace REBasic
{
    partial class REBaseStringOp
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
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Size = new System.Drawing.Size(129, 37);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(12, 12);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 0;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(70, 12);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 1;
            // 
            // REBaseStringOp
            // 
            this.Name = "REBaseStringOp";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(136, 62);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpOutput;
    }
}
