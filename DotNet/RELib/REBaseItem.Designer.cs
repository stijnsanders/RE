namespace RE
{
    partial class REBaseItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REBaseItem));
            this.lblCaption = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTopSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgItemResize = new System.Windows.Forms.PictureBox();
            this.panItemClient = new System.Windows.Forms.Panel();
            this.panContextMenu = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgItemResize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaption.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCaption.ContextMenuStrip = this.contextMenuStrip1;
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(3, 3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(183, 16);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Unknown Item";
            this.lblCaption.UseMnemonic = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTopSeparator,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 82);
            // 
            // menuTopSeparator
            // 
            this.menuTopSeparator.Name = "menuTopSeparator";
            this.menuTopSeparator.Size = new System.Drawing.Size(135, 6);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.bringToFrontToolStripMenuItem.Text = "&Bring to front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.sendToBackToolStripMenuItem.Text = "&Send to back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // imgItemResize
            // 
            this.imgItemResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgItemResize.BackColor = System.Drawing.Color.Transparent;
            this.imgItemResize.ContextMenuStrip = this.contextMenuStrip1;
            this.imgItemResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.imgItemResize.Image = ((System.Drawing.Image)(resources.GetObject("imgItemResize.Image")));
            this.imgItemResize.Location = new System.Drawing.Point(192, 131);
            this.imgItemResize.Name = "imgItemResize";
            this.imgItemResize.Size = new System.Drawing.Size(16, 16);
            this.imgItemResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgItemResize.TabIndex = 1;
            this.imgItemResize.TabStop = false;
            // 
            // panItemClient
            // 
            this.panItemClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panItemClient.Location = new System.Drawing.Point(3, 21);
            this.panItemClient.Name = "panItemClient";
            this.panItemClient.Size = new System.Drawing.Size(201, 122);
            this.panItemClient.TabIndex = 2;
            // 
            // panContextMenu
            // 
            this.panContextMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panContextMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panContextMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panContextMenu.ContextMenuStrip = this.contextMenuStrip1;
            this.panContextMenu.Location = new System.Drawing.Point(188, 3);
            this.panContextMenu.Name = "panContextMenu";
            this.panContextMenu.Size = new System.Drawing.Size(16, 16);
            this.panContextMenu.TabIndex = 3;
            this.panContextMenu.MouseLeave += new System.EventHandler(this.panContextMenu_MouseLeave);
            this.panContextMenu.Click += new System.EventHandler(this.panel1_Click);
            this.panContextMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panContextMenu_MouseDown);
            this.panContextMenu.MouseEnter += new System.EventHandler(this.panContextMenu_MouseEnter);
            this.panContextMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panContextMenu_MouseUp);
            // 
            // REBaseItem
            // 
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.panContextMenu);
            this.Controls.Add(this.panItemClient);
            this.Controls.Add(this.imgItemResize);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(60, 60);
            this.Name = "REBaseItem";
            this.Size = new System.Drawing.Size(208, 147);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgItemResize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgItemResize;
        protected System.Windows.Forms.Panel panItemClient;
        private System.Windows.Forms.Panel panContextMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator menuTopSeparator;
    }
}
