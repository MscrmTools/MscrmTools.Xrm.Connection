namespace McTools.Xrm.Connection.TestWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnWhoAmI = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbManageConnections = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMergeConnectionsFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClearLogs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRequestPassword = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImpersonate = new System.Windows.Forms.ToolStripButton();
            this.tsbClearImpersonate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tssbMetadata = new System.Windows.Forms.ToolStripSplitButton();
            this.updateCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenXtbPortal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.pnlHighlight = new System.Windows.Forms.Panel();
            this.lblEnvName = new System.Windows.Forms.Label();
            this.pbEnvLogo = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnvLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWhoAmI
            // 
            this.btnWhoAmI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWhoAmI.Location = new System.Drawing.Point(7, 6);
            this.btnWhoAmI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWhoAmI.Name = "btnWhoAmI";
            this.btnWhoAmI.Size = new System.Drawing.Size(1413, 28);
            this.btnWhoAmI.TabIndex = 0;
            this.btnWhoAmI.Text = "Who am I?";
            this.btnWhoAmI.UseVisualStyleBackColor = true;
            this.btnWhoAmI.Click += new System.EventHandler(this.btnWhoAmI_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbManageConnections,
            this.toolStripSeparator1,
            this.tsbMergeConnectionsFiles,
            this.toolStripSeparator2,
            this.tsbClearLogs,
            this.toolStripSeparator3,
            this.tsbRequestPassword,
            this.toolStripSeparator4,
            this.tsbImpersonate,
            this.tsbClearImpersonate,
            this.toolStripSeparator5,
            this.tssbMetadata,
            this.toolStripSeparator6,
            this.tsbOpenXtbPortal,
            this.toolStripSeparator7,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1427, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "tsMain";
            // 
            // tsbManageConnections
            // 
            this.tsbManageConnections.Image = ((System.Drawing.Image)(resources.GetObject("tsbManageConnections.Image")));
            this.tsbManageConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbManageConnections.Name = "tsbManageConnections";
            this.tsbManageConnections.Size = new System.Drawing.Size(174, 28);
            this.tsbManageConnections.Text = "Manage connections";
            this.tsbManageConnections.Click += new System.EventHandler(this.tsbManageConnections_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbMergeConnectionsFiles
            // 
            this.tsbMergeConnectionsFiles.CheckOnClick = true;
            this.tsbMergeConnectionsFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbMergeConnectionsFiles.Image")));
            this.tsbMergeConnectionsFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMergeConnectionsFiles.Name = "tsbMergeConnectionsFiles";
            this.tsbMergeConnectionsFiles.Size = new System.Drawing.Size(194, 28);
            this.tsbMergeConnectionsFiles.Text = "Merge connections files";
            this.tsbMergeConnectionsFiles.Click += new System.EventHandler(this.tsbMergeConnectionsFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbClearLogs
            // 
            this.tsbClearLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearLogs.Image")));
            this.tsbClearLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearLogs.Name = "tsbClearLogs";
            this.tsbClearLogs.Size = new System.Drawing.Size(79, 28);
            this.tsbClearLogs.Text = "Clear logs";
            this.tsbClearLogs.Click += new System.EventHandler(this.tsbClearLogs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRequestPassword
            // 
            this.tsbRequestPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRequestPassword.Image = ((System.Drawing.Image)(resources.GetObject("tsbRequestPassword.Image")));
            this.tsbRequestPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRequestPassword.Name = "tsbRequestPassword";
            this.tsbRequestPassword.Size = new System.Drawing.Size(131, 28);
            this.tsbRequestPassword.Text = "Request Password";
            this.tsbRequestPassword.Click += new System.EventHandler(this.tsbRequestPassword_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbImpersonate
            // 
            this.tsbImpersonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbImpersonate.Image = ((System.Drawing.Image)(resources.GetObject("tsbImpersonate.Image")));
            this.tsbImpersonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImpersonate.Name = "tsbImpersonate";
            this.tsbImpersonate.Size = new System.Drawing.Size(96, 28);
            this.tsbImpersonate.Text = "Impersonate";
            this.tsbImpersonate.Click += new System.EventHandler(this.tsbImpersonate_Click);
            // 
            // tsbClearImpersonate
            // 
            this.tsbClearImpersonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearImpersonate.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearImpersonate.Image")));
            this.tsbClearImpersonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearImpersonate.Name = "tsbClearImpersonate";
            this.tsbClearImpersonate.Size = new System.Drawing.Size(147, 28);
            this.tsbClearImpersonate.Text = "Clear Impersonation";
            this.tsbClearImpersonate.Click += new System.EventHandler(this.tsbClearImpersonate_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tssbMetadata
            // 
            this.tssbMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbMetadata.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateCacheToolStripMenuItem,
            this.flushCacheToolStripMenuItem});
            this.tssbMetadata.Image = ((System.Drawing.Image)(resources.GetObject("tssbMetadata.Image")));
            this.tssbMetadata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbMetadata.Name = "tssbMetadata";
            this.tssbMetadata.Size = new System.Drawing.Size(132, 28);
            this.tssbMetadata.Text = "Show Metadata";
            this.tssbMetadata.ButtonClick += new System.EventHandler(this.tssbMetadata_ButtonClick);
            // 
            // updateCacheToolStripMenuItem
            // 
            this.updateCacheToolStripMenuItem.Name = "updateCacheToolStripMenuItem";
            this.updateCacheToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.updateCacheToolStripMenuItem.Text = "Update Cache";
            this.updateCacheToolStripMenuItem.Click += new System.EventHandler(this.updateCacheToolStripMenuItem_Click);
            // 
            // flushCacheToolStripMenuItem
            // 
            this.flushCacheToolStripMenuItem.Name = "flushCacheToolStripMenuItem";
            this.flushCacheToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.flushCacheToolStripMenuItem.Text = "Flush Cache";
            this.flushCacheToolStripMenuItem.Click += new System.EventHandler(this.flushCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbOpenXtbPortal
            // 
            this.tsbOpenXtbPortal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpenXtbPortal.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenXtbPortal.Image")));
            this.tsbOpenXtbPortal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenXtbPortal.Name = "tsbOpenXtbPortal";
            this.tsbOpenXtbPortal.Size = new System.Drawing.Size(178, 28);
            this.tsbOpenXtbPortal.Text = "Open XrmToolBox portal";
            this.tsbOpenXtbPortal.Click += new System.EventHandler(this.tsbOpenXtbPortal_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(118, 28);
            this.toolStripButton1.Text = "Add connection";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnWhoAmI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Size = new System.Drawing.Size(1427, 39);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbLogs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Size = new System.Drawing.Size(1427, 217);
            this.panel2.TabIndex = 3;
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 16;
            this.lbLogs.Location = new System.Drawing.Point(7, 6);
            this.lbLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(1413, 205);
            this.lbLogs.TabIndex = 0;
            // 
            // pnlHighlight
            // 
            this.pnlHighlight.Controls.Add(this.lblEnvName);
            this.pnlHighlight.Controls.Add(this.pbEnvLogo);
            this.pnlHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHighlight.Location = new System.Drawing.Point(0, 70);
            this.pnlHighlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHighlight.Name = "pnlHighlight";
            this.pnlHighlight.Size = new System.Drawing.Size(1427, 47);
            this.pnlHighlight.TabIndex = 8;
            this.pnlHighlight.Visible = false;
            // 
            // lblEnvName
            // 
            this.lblEnvName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnvName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvName.Location = new System.Drawing.Point(55, 0);
            this.lblEnvName.Name = "lblEnvName";
            this.lblEnvName.Size = new System.Drawing.Size(1372, 47);
            this.lblEnvName.TabIndex = 1;
            this.lblEnvName.Text = "Env";
            this.lblEnvName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbEnvLogo
            // 
            this.pbEnvLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbEnvLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEnvLogo.Location = new System.Drawing.Point(0, 0);
            this.pbEnvLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbEnvLogo.Name = "pbEnvLogo";
            this.pbEnvLogo.Size = new System.Drawing.Size(55, 47);
            this.pbEnvLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnvLogo.TabIndex = 0;
            this.pbEnvLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 334);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHighlight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Who Am I Sample";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlHighlight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnvLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWhoAmI;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbManageConnections;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbMergeConnectionsFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClearLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbRequestPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbImpersonate;
        private System.Windows.Forms.ToolStripButton tsbClearImpersonate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tssbMetadata;
        private System.Windows.Forms.ToolStripMenuItem updateCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flushCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbOpenXtbPortal;
        private System.Windows.Forms.Panel pnlHighlight;
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.PictureBox pbEnvLogo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

