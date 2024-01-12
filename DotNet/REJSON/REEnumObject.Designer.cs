namespace REJSON
{
    partial class REEnumObject
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
            lpOutputKeys = new RE.RELinkPoint();
            lpOutputValues = new RE.RELinkPoint();
            panItemClient.SuspendLayout();
            SuspendLayout();
            // 
            // panItemClient
            // 
            panItemClient.Controls.Add(lpOutputValues);
            panItemClient.Controls.Add(lpOutputKeys);
            panItemClient.Controls.Add(lpInput);
            panItemClient.Size = new System.Drawing.Size(211, 35);
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
            // lpOutputKeys
            // 
            lpOutputKeys.AllowDrop = true;
            lpOutputKeys.Caption = "keys";
            lpOutputKeys.ConnectedTo = null;
            lpOutputKeys.ConnectionColor = System.Drawing.Color.Transparent;
            lpOutputKeys.Direction = RE.RELinkPointDirection.Output;
            lpOutputKeys.Key = "keys";
            lpOutputKeys.Location = new System.Drawing.Point(76, 10);
            lpOutputKeys.Name = "lpOutputKeys";
            lpOutputKeys.Size = new System.Drawing.Size(60, 16);
            lpOutputKeys.TabIndex = 1;
            lpOutputKeys.Signal += lpOutputKeys_Signal;
            // 
            // lpOutputValues
            // 
            lpOutputValues.AllowDrop = true;
            lpOutputValues.Caption = "values";
            lpOutputValues.ConnectedTo = null;
            lpOutputValues.ConnectionColor = System.Drawing.Color.Transparent;
            lpOutputValues.Direction = RE.RELinkPointDirection.Output;
            lpOutputValues.Key = "values";
            lpOutputValues.Location = new System.Drawing.Point(142, 10);
            lpOutputValues.Name = "lpOutputValues";
            lpOutputValues.Size = new System.Drawing.Size(60, 16);
            lpOutputValues.TabIndex = 2;
            lpOutputValues.Signal += lpOutputValues_Signal;
            // 
            // REEnumObject
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Caption = "JSON object";
            Name = "REEnumObject";
            Resizable = false;
            Size = new System.Drawing.Size(218, 60);
            panItemClient.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RE.RELinkPoint lpInput;
        private RE.RELinkPoint lpOutputKeys;
        private RE.RELinkPoint lpOutputValues;
    }
}
