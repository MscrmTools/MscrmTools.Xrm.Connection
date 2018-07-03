namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionOauthControl
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
            this.lblAzureAdAppId = new System.Windows.Forms.Label();
            this.txtAzureAdAppId = new System.Windows.Forms.TextBox();
            this.lblReplyUrl = new System.Windows.Forms.Label();
            this.txtReplyUrl = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOauthDesc
            // 
            this.lblOauthDesc.AutoSize = true;
            this.lblOauthDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOauthDesc.Location = new System.Drawing.Point(0, 0);
            this.lblOauthDesc.Name = "lblOauthDesc";
            this.lblOauthDesc.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblOauthDesc.Size = new System.Drawing.Size(887, 45);
            this.lblOauthDesc.TabIndex = 7;
            this.lblOauthDesc.Text = "To connect to Microsoft Dynamics 365 with Oauth, it is required to connect to an " +
    "Azure AD application";
            // 
            // llMoreInfo
            // 
            this.llMoreInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llMoreInfo.Location = new System.Drawing.Point(0, 241);
            this.llMoreInfo.Name = "llMoreInfo";
            this.llMoreInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.llMoreInfo.Size = new System.Drawing.Size(900, 33);
            this.llMoreInfo.TabIndex = 14;
            this.llMoreInfo.TabStop = true;
            this.llMoreInfo.Text = "Show me how to create an Azure AD application";
            this.llMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMoreInfo_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblAzureAdAppId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAdAppId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblReplyUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtReplyUrl, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 196);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // lblAzureAdAppId
            // 
            this.lblAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAzureAdAppId.Location = new System.Drawing.Point(4, 0);
            this.lblAzureAdAppId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAzureAdAppId.Name = "lblAzureAdAppId";
            this.lblAzureAdAppId.Size = new System.Drawing.Size(292, 50);
            this.lblAzureAdAppId.TabIndex = 11;
            this.lblAzureAdAppId.Text = "Azure AD Application Id";
            this.lblAzureAdAppId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAdAppId
            // 
            this.txtAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAdAppId.Location = new System.Drawing.Point(304, 10);
            this.txtAzureAdAppId.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtAzureAdAppId.Name = "txtAzureAdAppId";
            this.txtAzureAdAppId.Size = new System.Drawing.Size(592, 29);
            this.txtAzureAdAppId.TabIndex = 13;
            // 
            // lblReplyUrl
            // 
            this.lblReplyUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplyUrl.Location = new System.Drawing.Point(4, 50);
            this.lblReplyUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplyUrl.Name = "lblReplyUrl";
            this.lblReplyUrl.Size = new System.Drawing.Size(292, 50);
            this.lblReplyUrl.TabIndex = 14;
            this.lblReplyUrl.Text = "Reply Url";
            this.lblReplyUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReplyUrl
            // 
            this.txtReplyUrl.Location = new System.Drawing.Point(304, 60);
            this.txtReplyUrl.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtReplyUrl.Name = "txtReplyUrl";
            this.txtReplyUrl.Size = new System.Drawing.Size(592, 29);
            this.txtReplyUrl.TabIndex = 20;
            // 
            // ConnectionOauthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.llMoreInfo);
            this.Controls.Add(this.lblOauthDesc);
            this.Name = "ConnectionOauthControl";
            this.Size = new System.Drawing.Size(900, 274);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOauthDesc;
        private System.Windows.Forms.LinkLabel llMoreInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAzureAdAppId;
        private System.Windows.Forms.TextBox txtAzureAdAppId;
        private System.Windows.Forms.Label lblReplyUrl;
        private System.Windows.Forms.TextBox txtReplyUrl;
    }
}
