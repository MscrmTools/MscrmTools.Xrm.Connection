namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionAzureKeyVaultControl
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
            this.lblOauthDesc = new System.Windows.Forms.Label();
            this.llMoreInfo = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAzureKeyVaultName = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.txtAzureAdAppId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.lblAzureKeyVaultName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOauthDesc
            // 
            this.lblOauthDesc.AutoSize = true;
            this.lblOauthDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOauthDesc.Location = new System.Drawing.Point(0, 0);
            this.lblOauthDesc.Name = "lblOauthDesc";
            this.lblOauthDesc.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblOauthDesc.Size = new System.Drawing.Size(499, 28);
            this.lblOauthDesc.TabIndex = 7;
            this.lblOauthDesc.Text = "Enter a Client ID, along with the details of the Key Vault where the Client Secre" +
    "t exists";
            // 
            // llMoreInfo
            // 
            this.llMoreInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llMoreInfo.Location = new System.Drawing.Point(0, 168);
            this.llMoreInfo.Name = "llMoreInfo";
            this.llMoreInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.llMoreInfo.Size = new System.Drawing.Size(657, 22);
            this.llMoreInfo.TabIndex = 3;
            this.llMoreInfo.TabStop = true;
            this.llMoreInfo.Text = "Show me how to create an Azure AD application";
            this.llMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMoreInfo_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtAzureKeyVaultName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAdAppId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 140);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // txtAzureKeyVaultName
            // 
            this.txtAzureKeyVaultName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureKeyVaultName.Location = new System.Drawing.Point(222, 35);
            this.txtAzureKeyVaultName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.txtAzureKeyVaultName.Name = "txtAzureKeyVaultName";
            this.txtAzureKeyVaultName.Size = new System.Drawing.Size(433, 22);
            this.txtAzureKeyVaultName.TabIndex = 16;
            // 
            // lblClientId
            // 
            this.lblClientId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientId.Location = new System.Drawing.Point(3, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(213, 30);
            this.lblClientId.TabIndex = 11;
            this.lblClientId.Text = "Client Id";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAdAppId
            // 
            this.txtAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAdAppId.Location = new System.Drawing.Point(222, 6);
            this.txtAzureAdAppId.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.txtAzureAdAppId.Name = "txtAzureAdAppId";
            this.txtAzureAdAppId.Size = new System.Drawing.Size(433, 22);
            this.txtAzureAdAppId.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbHelp);
            this.panel1.Controls.Add(this.lblAzureKeyVaultName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 24);
            this.panel1.TabIndex = 17;
            // 
            // pbHelp
            // 
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbHelp.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources._16_L_help;
            this.pbHelp.Location = new System.Drawing.Point(190, 0);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(23, 24);
            this.pbHelp.TabIndex = 17;
            this.pbHelp.TabStop = false;
            // 
            // lblAzureKeyVaultName
            // 
            this.lblAzureKeyVaultName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAzureKeyVaultName.Location = new System.Drawing.Point(0, 0);
            this.lblAzureKeyVaultName.Name = "lblAzureKeyVaultName";
            this.lblAzureKeyVaultName.Size = new System.Drawing.Size(156, 24);
            this.lblAzureKeyVaultName.TabIndex = 16;
            this.lblAzureKeyVaultName.Text = "Azure Key Vault Name";
            this.lblAzureKeyVaultName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectionAzureKeyVaultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.llMoreInfo);
            this.Controls.Add(this.lblOauthDesc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConnectionAzureKeyVaultControl";
            this.Size = new System.Drawing.Size(657, 190);
            this.Load += new System.EventHandler(this.ConnectionOauthControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOauthDesc;
        private System.Windows.Forms.LinkLabel llMoreInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtAzureAdAppId;
        private System.Windows.Forms.TextBox txtAzureKeyVaultName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.Label lblAzureKeyVaultName;
    }
}
