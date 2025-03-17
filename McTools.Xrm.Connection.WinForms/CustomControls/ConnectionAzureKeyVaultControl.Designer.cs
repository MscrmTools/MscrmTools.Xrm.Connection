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
            this.lblAzureKeyVaultName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOauthDesc
            // 
            this.lblOauthDesc.AutoSize = true;
            this.lblOauthDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOauthDesc.Location = new System.Drawing.Point(0, 0);
            this.lblOauthDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOauthDesc.Name = "lblOauthDesc";
            this.lblOauthDesc.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblOauthDesc.Size = new System.Drawing.Size(409, 23);
            this.lblOauthDesc.TabIndex = 7;
            this.lblOauthDesc.Text = "Enter a Client ID, along with the details of the Key Vault where the Client Secre" +
    "t exists";
            // 
            // llMoreInfo
            // 
            this.llMoreInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llMoreInfo.Location = new System.Drawing.Point(0, 130);
            this.llMoreInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llMoreInfo.Name = "llMoreInfo";
            this.llMoreInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.llMoreInfo.Size = new System.Drawing.Size(491, 18);
            this.llMoreInfo.TabIndex = 3;
            this.llMoreInfo.TabStop = true;
            this.llMoreInfo.Text = "Show me how to create an Azure AD application";
            this.llMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMoreInfo_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtAzureKeyVaultName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAdAppId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAzureKeyVaultName, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 107);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // txtAzureKeyVaultName
            // 
            this.txtAzureKeyVaultName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureKeyVaultName.Location = new System.Drawing.Point(166, 28);
            this.txtAzureKeyVaultName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.txtAzureKeyVaultName.Name = "txtAzureKeyVaultName";
            this.txtAzureKeyVaultName.Size = new System.Drawing.Size(326, 20);
            this.txtAzureKeyVaultName.TabIndex = 16;
            // 
            // lblClientId
            // 
            this.lblClientId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientId.Location = new System.Drawing.Point(2, 0);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(160, 24);
            this.lblClientId.TabIndex = 11;
            this.lblClientId.Text = "Client Id";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAdAppId
            // 
            this.txtAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAdAppId.Location = new System.Drawing.Point(166, 5);
            this.txtAzureAdAppId.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.txtAzureAdAppId.Name = "txtAzureAdAppId";
            this.txtAzureAdAppId.Size = new System.Drawing.Size(326, 20);
            this.txtAzureAdAppId.TabIndex = 1;
            // 
            // lblAzureKeyVaultName
            // 
            this.lblAzureKeyVaultName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAzureKeyVaultName.Location = new System.Drawing.Point(2, 24);
            this.lblAzureKeyVaultName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAzureKeyVaultName.Name = "lblAzureKeyVaultName";
            this.lblAzureKeyVaultName.Size = new System.Drawing.Size(160, 24);
            this.lblAzureKeyVaultName.TabIndex = 15;
            this.lblAzureKeyVaultName.Text = "Azure Key Vault Name";
            this.lblAzureKeyVaultName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectionAzureKeyVaultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.llMoreInfo);
            this.Controls.Add(this.lblOauthDesc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionAzureKeyVaultControl";
            this.Size = new System.Drawing.Size(491, 148);
            this.Load += new System.EventHandler(this.ConnectionOauthControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Label lblAzureKeyVaultName;
    }
}
