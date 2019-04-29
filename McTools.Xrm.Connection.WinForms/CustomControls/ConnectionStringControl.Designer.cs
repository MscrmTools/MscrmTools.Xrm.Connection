namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionStringControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.llConnectionStringHelp = new System.Windows.Forms.LinkLabel();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // llConnectionStringHelp
            // 
            this.llConnectionStringHelp.AutoSize = true;
            this.llConnectionStringHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llConnectionStringHelp.Location = new System.Drawing.Point(0, 249);
            this.llConnectionStringHelp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.llConnectionStringHelp.Name = "llConnectionStringHelp";
            this.llConnectionStringHelp.Size = new System.Drawing.Size(307, 25);
            this.llConnectionStringHelp.TabIndex = 2;
            this.llConnectionStringHelp.TabStop = true;
            this.llConnectionStringHelp.Text = "Help me with the connection string";
            this.llConnectionStringHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llConnectionStringHelp_LinkClicked);
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnectionString.Location = new System.Drawing.Point(0, 0);
            this.lblConnectionString.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(164, 25);
            this.lblConnectionString.TabIndex = 19;
            this.lblConnectionString.Text = "Connection string";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionString.Location = new System.Drawing.Point(10, 10);
            this.txtConnectionString.Margin = new System.Windows.Forms.Padding(5);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(880, 204);
            this.txtConnectionString.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtConnectionString);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(900, 224);
            this.pnlMain.TabIndex = 23;
            // 
            // ConnectionStringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.llConnectionStringHelp);
            this.Controls.Add(this.lblConnectionString);
            this.Name = "ConnectionStringControl";
            this.Size = new System.Drawing.Size(900, 274);
            this.Load += new System.EventHandler(this.ConnectionStringControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llConnectionStringHelp;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Panel pnlMain;
    }
}
