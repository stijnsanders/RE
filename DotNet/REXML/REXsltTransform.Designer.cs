namespace REXML
{
    partial class REXsltTransform
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
            this.lpXSLT = new RE.RELinkPoint();
            this.lpInput = new RE.RELinkPoint();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Controls.Add(this.lpInput);
            this.panItemClient.Controls.Add(this.lpXSLT);
            this.panItemClient.Size = new System.Drawing.Size(111, 47);
            // 
            // lpXSLT
            // 
            this.lpXSLT.AllowDrop = true;
            this.lpXSLT.Caption = "xslt";
            this.lpXSLT.ConnectedTo = null;
            this.lpXSLT.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpXSLT.Direction = RE.RELinkPointDirection.Input;
            this.lpXSLT.Key = "xslt";
            this.lpXSLT.Location = new System.Drawing.Point(4, 4);
            this.lpXSLT.Name = "lpXSLT";
            this.lpXSLT.Size = new System.Drawing.Size(48, 16);
            this.lpXSLT.TabIndex = 0;
            this.lpXSLT.Signal += new RE.RELinkPointSignal(this.lpXSLT_Signal);
            // 
            // lpInput
            // 
            this.lpInput.AllowDrop = true;
            this.lpInput.Caption = "xml in";
            this.lpInput.ConnectedTo = null;
            this.lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            this.lpInput.Direction = RE.RELinkPointDirection.Input;
            this.lpInput.Key = "input";
            this.lpInput.Location = new System.Drawing.Point(4, 26);
            this.lpInput.Name = "lpInput";
            this.lpInput.Size = new System.Drawing.Size(48, 16);
            this.lpInput.TabIndex = 1;
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
            this.lpOutput.Location = new System.Drawing.Point(59, 26);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(48, 16);
            this.lpOutput.TabIndex = 2;
            // 
            // REXsltTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Xslt Transform";
            this.Name = "REXsltTransform";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(118, 72);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RE.RELinkPoint lpOutput;
        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpXSLT;
    }
}
