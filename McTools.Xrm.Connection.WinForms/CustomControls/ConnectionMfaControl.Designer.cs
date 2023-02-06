namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionMfaControl
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
            this.llMoreInfo = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAzureAdAppId = new System.Windows.Forms.Label();
            this.txtAzureAdAppId = new System.Windows.Forms.TextBox();
            this.lblReplyUrl = new System.Windows.Forms.Label();
            this.txtReplyUrl = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.rdbUseDevAppId = new System.Windows.Forms.RadioButton();
            this.pnlApp = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.rdbUseCustomAppId = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // llMoreInfo
            // 
            this.llMoreInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llMoreInfo.Location = new System.Drawing.Point(0, 192);
            this.llMoreInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llMoreInfo.Name = "llMoreInfo";
            this.llMoreInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.llMoreInfo.Size = new System.Drawing.Size(783, 27);
            this.llMoreInfo.TabIndex = 3;
            this.llMoreInfo.TabStop = true;
            this.llMoreInfo.Text = "Show me how to create an Azure AD application";
            this.llMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMoreInfo_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblAzureAdAppId, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAdAppId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblReplyUrl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReplyUrl, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbUseDevAppId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlApp, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 192);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // lblAzureAdAppId
            // 
            this.lblAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAzureAdAppId.Location = new System.Drawing.Point(3, 76);
            this.lblAzureAdAppId.Name = "lblAzureAdAppId";
            this.lblAzureAdAppId.Size = new System.Drawing.Size(239, 38);
            this.lblAzureAdAppId.TabIndex = 11;
            this.lblAzureAdAppId.Text = "Azure AD Application Id";
            this.lblAzureAdAppId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAdAppId
            // 
            this.txtAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAdAppId.Enabled = false;
            this.txtAzureAdAppId.Location = new System.Drawing.Point(248, 84);
            this.txtAzureAdAppId.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtAzureAdAppId.Name = "txtAzureAdAppId";
            this.txtAzureAdAppId.Size = new System.Drawing.Size(853, 26);
            this.txtAzureAdAppId.TabIndex = 1;
            this.txtAzureAdAppId.Text = "51f81489-12ee-4a9e-aaae-a2591f45987d";
            // 
            // lblReplyUrl
            // 
            this.lblReplyUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplyUrl.Location = new System.Drawing.Point(3, 114);
            this.lblReplyUrl.Name = "lblReplyUrl";
            this.lblReplyUrl.Size = new System.Drawing.Size(239, 78);
            this.lblReplyUrl.TabIndex = 14;
            this.lblReplyUrl.Text = "Reply Url";
            this.lblReplyUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReplyUrl
            // 
            this.txtReplyUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplyUrl.Enabled = false;
            this.txtReplyUrl.Location = new System.Drawing.Point(248, 122);
            this.txtReplyUrl.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtReplyUrl.Name = "txtReplyUrl";
            this.txtReplyUrl.Size = new System.Drawing.Size(853, 26);
            this.txtReplyUrl.TabIndex = 2;
            this.txtReplyUrl.Text = "app://58145B91-0C36-4500-8554-080854F2AC97";
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Location = new System.Drawing.Point(2, 0);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(241, 38);
            this.lblUsername.TabIndex = 15;
            this.lblUsername.Text = "Username / Email address";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(247, 6);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 6, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(855, 26);
            this.txtUsername.TabIndex = 16;
            // 
            // rdbUseDevAppId
            // 
            this.rdbUseDevAppId.AutoSize = true;
            this.rdbUseDevAppId.Checked = true;
            this.rdbUseDevAppId.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbUseDevAppId.Location = new System.Drawing.Point(3, 41);
            this.rdbUseDevAppId.Name = "rdbUseDevAppId";
            this.rdbUseDevAppId.Size = new System.Drawing.Size(209, 32);
            this.rdbUseDevAppId.TabIndex = 17;
            this.rdbUseDevAppId.TabStop = true;
            this.rdbUseDevAppId.Text = "Use development App Id";
            this.rdbUseDevAppId.UseVisualStyleBackColor = true;
            // 
            // pnlApp
            // 
            this.pnlApp.Controls.Add(this.pbHelp);
            this.pnlApp.Controls.Add(this.rdbUseCustomAppId);
            this.pnlApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApp.Location = new System.Drawing.Point(248, 41);
            this.pnlApp.Name = "pnlApp";
            this.pnlApp.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.pnlApp.Size = new System.Drawing.Size(853, 32);
            this.pnlApp.TabIndex = 18;
            // 
            // pbHelp
            // 
            this.pbHelp.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbHelp.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Info_16;
            this.pbHelp.Location = new System.Drawing.Point(175, 0);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(84, 32);
            this.pbHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHelp.TabIndex = 2;
            this.pbHelp.TabStop = false;
            // 
            // rdbUseCustomAppId
            // 
            this.rdbUseCustomAppId.AutoSize = true;
            this.rdbUseCustomAppId.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbUseCustomAppId.Location = new System.Drawing.Point(4, 0);
            this.rdbUseCustomAppId.Name = "rdbUseCustomAppId";
            this.rdbUseCustomAppId.Size = new System.Drawing.Size(171, 32);
            this.rdbUseCustomAppId.TabIndex = 1;
            this.rdbUseCustomAppId.Text = "Use my own App Id";
            this.rdbUseCustomAppId.UseVisualStyleBackColor = true;
            this.rdbUseCustomAppId.CheckedChanged += new System.EventHandler(this.rdbUseCustomAppId_CheckedChanged);
            // 
            // ConnectionMfaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.llMoreInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionMfaControl";
            this.Size = new System.Drawing.Size(783, 219);
            this.Load += new System.EventHandler(this.ConnectionOauthControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlApp.ResumeLayout(false);
            this.pnlApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel llMoreInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblAzureAdAppId;
        private System.Windows.Forms.TextBox txtAzureAdAppId;
        private System.Windows.Forms.Label lblReplyUrl;
        private System.Windows.Forms.TextBox txtReplyUrl;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.RadioButton rdbUseDevAppId;
        private System.Windows.Forms.Panel pnlApp;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.RadioButton rdbUseCustomAppId;
    }
}
