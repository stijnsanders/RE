namespace REMulti
{
    partial class REDecide
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
            this.lpSelect = new RE.RELinkPoint();
            this.lpEcho = new RE.RELinkPoint();
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.lpEcho);
            this.panItemClient.Controls.Add(this.lpSelect);
            this.panItemClient.Size = new System.Drawing.Size(110, 46);
            // 
            // lpSelect
            // 
            this.lpSelect.AllowDrop = true;
            this.lpSelect.Caption = "select";
            this.lpSelect.ConnectedTo = null;
            this.lpSelect.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpSelect.Direction = RE.RELinkPointDirection.Input;
            this.lpSelect.Key = "select";
            this.lpSelect.Location = new System.Drawing.Point(4, 3);
            this.lpSelect.Name = "lpSelect";
            this.lpSelect.Size = new System.Drawing.Size(48, 16);
            this.lpSelect.TabIndex = 0;
            this.lpSelect.Signal += new RE.RELinkPointSignal(this.lpSelect_Signal);
            // 
            // lpEcho
            // 
            this.lpEcho.AllowDrop = true;
            this.lpEcho.Caption = "echo";
            this.lpEcho.ConnectedTo = null;
            this.lpEcho.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpEcho.Direction = RE.RELinkPointDirection.Output;
            this.lpEcho.Key = "echo";
            this.lpEcho.Location = new System.Drawing.Point(58, 3);
            this.lpEcho.Name = "lpEcho";
            this.lpEcho.Size = new System.Drawing.Size(48, 16);
            this.lpEcho.TabIndex = 1;
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "input";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(4, 26);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 2;
            this.lpInput.Signal += new RE.RELinkPointSignal(this.lpInput_Signal);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(58, 26);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 3;
            this.lpOutput.Signal += new RE.RELinkPointSignal(this.lpOutput_Signal);
            // 
            // REDecide
            // 
            this.Caption = "Decide";
            this.Name = "REDecide";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(117, 71);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpSelect;
        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpEcho;
    }
}
