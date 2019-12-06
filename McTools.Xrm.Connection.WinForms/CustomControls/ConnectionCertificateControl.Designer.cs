namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionCertificateControl
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
            this.btnBrowseCert = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIssuer = new System.Windows.Forms.Label();
            this.lblThumbprint = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBrowseCert.Location = new System.Drawing.Point(10, 209);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(962, 66);
            this.btnBrowseCert.TabIndex = 0;
            this.btnBrowseCert.Text = "Select certificate";
            this.btnBrowseCert.UseVisualStyleBackColor = true;
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblThumbprint);
            this.pnlMain.Controls.Add(this.lblIssuer);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(962, 199);
            this.pnlMain.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(962, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Current selected certificate";
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(962, 40);
            this.lblName.TabIndex = 1;
            this.lblName.Tag = "Name : {0}";
            this.lblName.Text = "Name :";
            // 
            // lblIssuer
            // 
            this.lblIssuer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIssuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuer.Location = new System.Drawing.Point(0, 80);
            this.lblIssuer.Name = "lblIssuer";
            this.lblIssuer.Size = new System.Drawing.Size(962, 40);
            this.lblIssuer.TabIndex = 2;
            this.lblIssuer.Tag = "Issuer : {0}";
            this.lblIssuer.Text = "Issuer :";
            // 
            // lblThumbprint
            // 
            this.lblThumbprint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThumbprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThumbprint.Location = new System.Drawing.Point(0, 120);
            this.lblThumbprint.Name = "lblThumbprint";
            this.lblThumbprint.Size = new System.Drawing.Size(962, 40);
            this.lblThumbprint.TabIndex = 3;
            this.lblThumbprint.Tag = "Thumbprint : {0}";
            this.lblThumbprint.Text = "Thumbprint  :";
            // 
            // ConnectionCertificateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnBrowseCert);
            this.Name = "ConnectionCertificateControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(982, 285);
            this.Load += new System.EventHandler(this.ConnectionStringControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseCert;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblThumbprint;
        private System.Windows.Forms.Label lblIssuer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
    }
}
