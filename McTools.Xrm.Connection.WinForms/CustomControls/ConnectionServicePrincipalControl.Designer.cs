namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionServicePrincipalControl
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
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblAzureAppId = new System.Windows.Forms.Label();
            this.txtAzureAppId = new System.Windows.Forms.TextBox();
            this.lblClientSecret = new System.Windows.Forms.Label();
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
            this.lblOauthDesc.Size = new System.Drawing.Size(489, 23);
            this.lblOauthDesc.TabIndex = 7;
            this.lblOauthDesc.Text = "To connect to Microsoft Dynamics 365 with Oauth, it is required to connect to an " +
    "Azure AD application";
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
            this.tableLayoutPanel1.Controls.Add(this.txtClientSecret, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblURL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtURL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAzureAppId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAppId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientSecret, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 107);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClientSecret.Location = new System.Drawing.Point(166, 51);
            this.txtClientSecret.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.PasswordChar = '*';
            this.txtClientSecret.Size = new System.Drawing.Size(327, 20);
            this.txtClientSecret.TabIndex = 16;
            this.txtClientSecret.TextChanged += new System.EventHandler(this.txtClientSecret_TextChanged);
            // 
            // lblURL
            // 
            this.lblURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblURL.Location = new System.Drawing.Point(2, 0);
            this.lblURL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(160, 24);
            this.lblURL.TabIndex = 11;
            this.lblURL.Text = "URL";
            this.lblURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtURL
            // 
            this.txtURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtURL.Location = new System.Drawing.Point(166, 5);
            this.txtURL.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(327, 20);
            this.txtURL.TabIndex = 1;
            // 
            // lblAzureAppId
            // 
            this.lblAzureAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAzureAppId.Location = new System.Drawing.Point(2, 24);
            this.lblAzureAppId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAzureAppId.Name = "lblAzureAppId";
            this.lblAzureAppId.Size = new System.Drawing.Size(160, 24);
            this.lblAzureAppId.TabIndex = 14;
            this.lblAzureAppId.Text = "Azure App Id";
            this.lblAzureAppId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAppId
            // 
            this.txtAzureAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAppId.Location = new System.Drawing.Point(166, 29);
            this.txtAzureAppId.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.txtAzureAppId.Name = "txtAzureAppId";
            this.txtAzureAppId.Size = new System.Drawing.Size(327, 20);
            this.txtAzureAppId.TabIndex = 2;
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientSecret.Location = new System.Drawing.Point(2, 48);
            this.lblClientSecret.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(160, 24);
            this.lblClientSecret.TabIndex = 15;
            this.lblClientSecret.Text = "Client Secret (OAuth or S2S)";
            this.lblClientSecret.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectionServicePrincipalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.llMoreInfo);
            this.Controls.Add(this.lblOauthDesc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionServicePrincipalControl";
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
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.Label lblAzureAppId;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtAzureAppId;
    }
}
