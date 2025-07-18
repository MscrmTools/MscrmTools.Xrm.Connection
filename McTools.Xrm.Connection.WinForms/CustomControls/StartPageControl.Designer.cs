﻿namespace McTools.Xrm.Connection.WinForms.CustomControls
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
            this.btnMfa = new System.Windows.Forms.Button();
            this.btnClientSecret = new System.Windows.Forms.Button();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStandard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.connection_wizard_32;
            this.btnStandard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStandard.Location = new System.Drawing.Point(7, 6);
            this.btnStandard.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnStandard.Size = new System.Drawing.Size(258, 53);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "Connection Wizard";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSdkLoginControl
            // 
            this.btnSdkLoginControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSdkLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSdkLoginControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSdkLoginControl.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Dataverse_32x32;
            this.btnSdkLoginControl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSdkLoginControl.Location = new System.Drawing.Point(279, 6);
            this.btnSdkLoginControl.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSdkLoginControl.Name = "btnSdkLoginControl";
            this.btnSdkLoginControl.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnSdkLoginControl.Size = new System.Drawing.Size(259, 53);
            this.btnSdkLoginControl.TabIndex = 1;
            this.btnSdkLoginControl.Text = "Microsoft Login Control";
            this.btnSdkLoginControl.UseVisualStyleBackColor = true;
            this.btnSdkLoginControl.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnConnectionString
            // 
            this.btnConnectionString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectionString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConnectionString.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.connection_string_32;
            this.btnConnectionString.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectionString.Location = new System.Drawing.Point(279, 71);
            this.btnConnectionString.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnConnectionString.Name = "btnConnectionString";
            this.btnConnectionString.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnConnectionString.Size = new System.Drawing.Size(259, 53);
            this.btnConnectionString.TabIndex = 2;
            this.btnConnectionString.Text = "Connection String";
            this.btnConnectionString.UseVisualStyleBackColor = true;
            this.btnConnectionString.Click += new System.EventHandler(this.btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnMfa, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClientSecret, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCertificate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSdkLoginControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStandard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConnectionString, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 12, 7, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 197);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnMfa
            // 
            this.btnMfa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMfa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMfa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMfa.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.connection_mfa_32;
            this.btnMfa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMfa.Location = new System.Drawing.Point(7, 136);
            this.btnMfa.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnMfa.Name = "btnMfa";
            this.btnMfa.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnMfa.Size = new System.Drawing.Size(258, 55);
            this.btnMfa.TabIndex = 5;
            this.btnMfa.Text = "OAuth / MFA";
            this.btnMfa.UseVisualStyleBackColor = true;
            this.btnMfa.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnClientSecret
            // 
            this.btnClientSecret.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClientSecret.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClientSecret.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.connection_secret_32;
            this.btnClientSecret.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientSecret.Location = new System.Drawing.Point(279, 136);
            this.btnClientSecret.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnClientSecret.Name = "btnClientSecret";
            this.btnClientSecret.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnClientSecret.Size = new System.Drawing.Size(259, 55);
            this.btnClientSecret.TabIndex = 4;
            this.btnClientSecret.Text = "Client Id / Secret";
            this.btnClientSecret.UseVisualStyleBackColor = true;
            this.btnClientSecret.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCertificate
            // 
            this.btnCertificate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCertificate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCertificate.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.connection_certificate_32;
            this.btnCertificate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCertificate.Location = new System.Drawing.Point(7, 71);
            this.btnCertificate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnCertificate.Size = new System.Drawing.Size(258, 53);
            this.btnCertificate.TabIndex = 3;
            this.btnCertificate.Text = "Certificate";
            this.btnCertificate.UseVisualStyleBackColor = true;
            this.btnCertificate.Click += new System.EventHandler(this.btn_Click);
            // 
            // StartPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "StartPageControl";
            this.Size = new System.Drawing.Size(545, 197);
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