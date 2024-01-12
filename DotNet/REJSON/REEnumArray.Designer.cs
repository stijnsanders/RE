namespace REJSON
{
    partial class REEnumArray
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
            lpInput = new RE.RELinkPoint();
            lpOutput = new RE.RELinkPoint();
            panItemClient.SuspendLayout();
            SuspendLayout();
            // 
            // panItemClient
            // 
            panItemClient.Controls.Add(lpOutput);
            panItemClient.Controls.Add(lpInput);
            panItemClient.Size = new System.Drawing.Size(147, 35);
            // 
            // lpInput
            // 
            lpInput.AllowDrop = true;
            lpInput.Caption = "json in";
            lpInput.ConnectedTo = null;
            lpInput.ConnectionColor = System.Drawing.Color.Transparent;
            lpInput.Direction = RE.RELinkPointDirection.Input;
            lpInput.Key = "input";
            lpInput.Location = new System.Drawing.Point(10, 10);
            lpInput.Name = "lpInput";
            lpInput.Size = new System.Drawing.Size(60, 16);
            lpInput.TabIndex = 0;
            lpInput.Signal += lpInput_Signal;
            // 
            // lpOutput
            // 
            lpOutput.AllowDrop = true;
            lpOutput.Caption = "items";
            lpOutput.ConnectedTo = null;
            lpOutput.ConnectionColor = System.Drawing.Color.Transparent;
            lpOutput.Direction = RE.RELinkPointDirection.Output;
            lpOutput.Key = "output";
            lpOutput.Location = new System.Drawing.Point(76, 10);
            lpOutput.Name = "lpOutput";
            lpOutput.Size = new System.Drawing.Size(60, 16);
            lpOutput.TabIndex = 1;
            lpOutput.Signal += lpOutput_Signal;
            // 
            // REEnumArray
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Caption = "JSON array";
            Name = "REEnumArray";
            Resizable = false;
            Size = new System.Drawing.Size(154, 60);
            panItemClient.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpOutput;
    }
}
