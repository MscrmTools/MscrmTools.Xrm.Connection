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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.tsbClearImpersonate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWhoAmI
            // 
            this.btnWhoAmI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWhoAmI.Location = new System.Drawing.Point(10, 10);
            this.btnWhoAmI.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnWhoAmI.Name = "btnWhoAmI";
            this.btnWhoAmI.Size = new System.Drawing.Size(1353, 44);
            this.btnWhoAmI.TabIndex = 0;
            this.btnWhoAmI.Text = "Who am I?";
            this.btnWhoAmI.UseVisualStyleBackColor = true;
            this.btnWhoAmI.Click += new System.EventHandler(this.btnWhoAmI_Click);
            // 
            // toolStrip1
            // 
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
            this.tsbClearImpersonate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1373, 42);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "tsMain";
            // 
            // tsbManageConnections
            // 
            this.tsbManageConnections.Image = ((System.Drawing.Image)(resources.GetObject("tsbManageConnections.Image")));
            this.tsbManageConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbManageConnections.Name = "tsbManageConnections";
            this.tsbManageConnections.Size = new System.Drawing.Size(274, 36);
            this.tsbManageConnections.Text = "Manage connections";
            this.tsbManageConnections.Click += new System.EventHandler(this.tsbManageConnections_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tsbMergeConnectionsFiles
            // 
            this.tsbMergeConnectionsFiles.CheckOnClick = true;
            this.tsbMergeConnectionsFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbMergeConnectionsFiles.Image")));
            this.tsbMergeConnectionsFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMergeConnectionsFiles.Name = "tsbMergeConnectionsFiles";
            this.tsbMergeConnectionsFiles.Size = new System.Drawing.Size(307, 36);
            this.tsbMergeConnectionsFiles.Text = "Merge connections files";
            this.tsbMergeConnectionsFiles.Click += new System.EventHandler(this.tsbMergeConnectionsFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // tsbClearLogs
            // 
            this.tsbClearLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearLogs.Image")));
            this.tsbClearLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearLogs.Name = "tsbClearLogs";
            this.tsbClearLogs.Size = new System.Drawing.Size(124, 36);
            this.tsbClearLogs.Text = "Clear logs";
            this.tsbClearLogs.Click += new System.EventHandler(this.tsbClearLogs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // tsbRequestPassword
            // 
            this.tsbRequestPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRequestPassword.Image = ((System.Drawing.Image)(resources.GetObject("tsbRequestPassword.Image")));
            this.tsbRequestPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRequestPassword.Name = "tsbRequestPassword";
            this.tsbRequestPassword.Size = new System.Drawing.Size(208, 36);
            this.tsbRequestPassword.Text = "Request Password";
            this.tsbRequestPassword.Click += new System.EventHandler(this.tsbRequestPassword_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // tsbImpersonate
            // 
            this.tsbImpersonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbImpersonate.Image = ((System.Drawing.Image)(resources.GetObject("tsbImpersonate.Image")));
            this.tsbImpersonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImpersonate.Name = "tsbImpersonate";
            this.tsbImpersonate.Size = new System.Drawing.Size(152, 36);
            this.tsbImpersonate.Text = "Impersonate";
            this.tsbImpersonate.Click += new System.EventHandler(this.tsbImpersonate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnWhoAmI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1373, 66);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbLogs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1373, 414);
            this.panel2.TabIndex = 3;
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 25;
            this.lbLogs.Location = new System.Drawing.Point(10, 10);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(1353, 394);
            this.lbLogs.TabIndex = 0;
            // 
            // tsbClearImpersonate
            // 
            this.tsbClearImpersonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearImpersonate.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearImpersonate.Image")));
            this.tsbClearImpersonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearImpersonate.Name = "tsbClearImpersonate";
            this.tsbClearImpersonate.Size = new System.Drawing.Size(234, 36);
            this.tsbClearImpersonate.Text = "Clear Impersonation";
            this.tsbClearImpersonate.Click += new System.EventHandler(this.tsbClearImpersonate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Who Am I Sample";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
    }
}

