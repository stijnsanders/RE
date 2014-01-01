namespace REMulti
{
    partial class RESequence
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
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lpOutput = new RE.RELinkPoint();
            this.panItemClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemClient
            // 
            this.panItemClient.Controls.Add(this.btnMinus);
            this.panItemClient.Controls.Add(this.btnPlus);
            this.panItemClient.Controls.Add(this.lpOutput);
            this.panItemClient.Size = new System.Drawing.Size(123, 49);
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Image = global::REMulti.Properties.Resources.Minus;
            this.btnMinus.Location = new System.Drawing.Point(26, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(17, 17);
            this.btnMinus.TabIndex = 5;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Image = global::REMulti.Properties.Resources.Plus;
            this.btnPlus.Location = new System.Drawing.Point(3, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(17, 17);
            this.btnPlus.TabIndex = 4;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lpOutput
            // 
            this.lpOutput.AllowDrop = true;
            this.lpOutput.Caption = "output";
            this.lpOutput.ConnectedTo = null;
            this.lpOutput.ConnectionColor = System.Drawing.Color.Empty;
            this.lpOutput.Direction = RE.RELinkPointDirection.Output;
            this.lpOutput.Key = "output";
            this.lpOutput.Location = new System.Drawing.Point(63, 26);
            this.lpOutput.Name = "lpOutput";
            this.lpOutput.Size = new System.Drawing.Size(57, 16);
            this.lpOutput.TabIndex = 3;
            // 
            // RESequence
            // 
            this.Caption = "Sequence";
            this.Name = "RESequence";
            this.Resizable = false;
            this.Size = new System.Drawing.Size(130, 74);
            this.panItemClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private RE.RELinkPoint lpOutput;
    }
}
