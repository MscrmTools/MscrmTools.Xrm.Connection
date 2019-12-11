namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class StartPageControl
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
            this.btnStandard = new System.Windows.Forms.Button();
            this.btnSdkLoginControl = new System.Windows.Forms.Button();
            this.btnConnectionString = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClientSecret = new System.Windows.Forms.Button();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.btnMfa = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStandard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.logo_32;
            this.btnStandard.Location = new System.Drawing.Point(10, 20);
            this.btnStandard.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(471, 55);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "Connection Wizard";
            this.btnStandard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStandard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSdkLoginControl
            // 
            this.btnSdkLoginControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSdkLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSdkLoginControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSdkLoginControl.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.LogoDyn365_32;
            this.btnSdkLoginControl.Location = new System.Drawing.Point(501, 20);
            this.btnSdkLoginControl.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnSdkLoginControl.Name = "btnSdkLoginControl";
            this.btnSdkLoginControl.Size = new System.Drawing.Size(471, 55);
            this.btnSdkLoginControl.TabIndex = 1;
            this.btnSdkLoginControl.Text = "SDK Login Control";
            this.btnSdkLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSdkLoginControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSdkLoginControl.UseVisualStyleBackColor = true;
            this.btnSdkLoginControl.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnConnectionString
            // 
            this.btnConnectionString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectionString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConnectionString.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.ConnectionStringImage32;
            this.btnConnectionString.Location = new System.Drawing.Point(501, 115);
            this.btnConnectionString.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnConnectionString.Name = "btnConnectionString";
            this.btnConnectionString.Size = new System.Drawing.Size(471, 55);
            this.btnConnectionString.TabIndex = 2;
            this.btnConnectionString.Text = "Connection String";
            this.btnConnectionString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectionString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConnectionString.UseVisualStyleBackColor = true;
            this.btnConnectionString.Click += new System.EventHandler(this.btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnMfa, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClientSecret, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCertificate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSdkLoginControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStandard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConnectionString, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 285);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnClientSecret
            // 
            this.btnClientSecret.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClientSecret.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClientSecret.Location = new System.Drawing.Point(501, 210);
            this.btnClientSecret.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnClientSecret.Name = "btnClientSecret";
            this.btnClientSecret.Size = new System.Drawing.Size(471, 55);
            this.btnClientSecret.TabIndex = 4;
            this.btnClientSecret.Text = "Client Id / Secret";
            this.btnClientSecret.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientSecret.UseVisualStyleBackColor = true;
            this.btnClientSecret.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCertificate
            // 
            this.btnCertificate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCertificate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCertificate.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Certificate32;
            this.btnCertificate.Location = new System.Drawing.Point(10, 115);
            this.btnCertificate.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Size = new System.Drawing.Size(471, 55);
            this.btnCertificate.TabIndex = 3;
            this.btnCertificate.Text = "Certificate";
            this.btnCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCertificate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCertificate.UseVisualStyleBackColor = true;
            this.btnCertificate.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMfa
            // 
            this.btnMfa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMfa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMfa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMfa.Location = new System.Drawing.Point(10, 210);
            this.btnMfa.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.btnMfa.Name = "btnMfa";
            this.btnMfa.Size = new System.Drawing.Size(471, 55);
            this.btnMfa.TabIndex = 5;
            this.btnMfa.Text = "Multi Factor Auth.";
            this.btnMfa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMfa.UseVisualStyleBackColor = true;
            this.btnMfa.Click += new System.EventHandler(this.btn_Click);
            // 
            // StartPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StartPageControl";
            this.Size = new System.Drawing.Size(982, 285);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnSdkLoginControl;
        private System.Windows.Forms.Button btnConnectionString;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCertificate;
        private System.Windows.Forms.Button btnClientSecret;
        private System.Windows.Forms.Button btnMfa;
    }
}
