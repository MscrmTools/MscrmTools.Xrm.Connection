namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class SdkLoginControlControl
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
            this.rdbUseDefault = new System.Windows.Forms.RadioButton();
            this.rdbUseCustom = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOpenSdkLoginCtrl = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAzureAdAppId = new System.Windows.Forms.Label();
            this.txtAzureAdAppId = new System.Windows.Forms.TextBox();
            this.lblReplyUrl = new System.Windows.Forms.Label();
            this.txtReplyUrl = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbUseDefault
            // 
            this.rdbUseDefault.AutoSize = true;
            this.rdbUseDefault.Checked = true;
            this.rdbUseDefault.Location = new System.Drawing.Point(2, 2);
            this.rdbUseDefault.Margin = new System.Windows.Forms.Padding(2);
            this.rdbUseDefault.Name = "rdbUseDefault";
            this.rdbUseDefault.Size = new System.Drawing.Size(212, 24);
            this.rdbUseDefault.TabIndex = 0;
            this.rdbUseDefault.TabStop = true;
            this.rdbUseDefault.Text = "Use default configuration";
            this.rdbUseDefault.UseVisualStyleBackColor = true;
            // 
            // rdbUseCustom
            // 
            this.rdbUseCustom.AutoSize = true;
            this.rdbUseCustom.Location = new System.Drawing.Point(2, 32);
            this.rdbUseCustom.Margin = new System.Windows.Forms.Padding(2);
            this.rdbUseCustom.Name = "rdbUseCustom";
            this.rdbUseCustom.Size = new System.Drawing.Size(546, 24);
            this.rdbUseCustom.TabIndex = 1;
            this.rdbUseCustom.Text = "Provide your own details for OAuth (Required only for IFD on ADFS 4.0+)";
            this.rdbUseCustom.UseVisualStyleBackColor = true;
            this.rdbUseCustom.CheckedChanged += new System.EventHandler(this.rdbUseCustom_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbUseDefault);
            this.panel1.Controls.Add(this.rdbUseCustom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 71);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOpenSdkLoginCtrl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 178);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 50);
            this.panel2.TabIndex = 17;
            // 
            // btnOpenSdkLoginCtrl
            // 
            this.btnOpenSdkLoginCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSdkLoginCtrl.Location = new System.Drawing.Point(447, 6);
            this.btnOpenSdkLoginCtrl.Name = "btnOpenSdkLoginCtrl";
            this.btnOpenSdkLoginCtrl.Size = new System.Drawing.Size(286, 35);
            this.btnOpenSdkLoginCtrl.TabIndex = 4;
            this.btnOpenSdkLoginCtrl.Text = "Open Microsoft Login Control";
            this.btnOpenSdkLoginCtrl.UseVisualStyleBackColor = true;
            this.btnOpenSdkLoginCtrl.Click += new System.EventHandler(this.btnOpenSdkLoginCtrl_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblAzureAdAppId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAzureAdAppId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblReplyUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtReplyUrl, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Enabled = false;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 107);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // lblAzureAdAppId
            // 
            this.lblAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAzureAdAppId.Location = new System.Drawing.Point(3, 0);
            this.lblAzureAdAppId.Name = "lblAzureAdAppId";
            this.lblAzureAdAppId.Size = new System.Drawing.Size(239, 42);
            this.lblAzureAdAppId.TabIndex = 11;
            this.lblAzureAdAppId.Text = "Application Id";
            this.lblAzureAdAppId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAzureAdAppId
            // 
            this.txtAzureAdAppId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAzureAdAppId.Location = new System.Drawing.Point(248, 8);
            this.txtAzureAdAppId.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtAzureAdAppId.Name = "txtAzureAdAppId";
            this.txtAzureAdAppId.Size = new System.Drawing.Size(485, 26);
            this.txtAzureAdAppId.TabIndex = 2;
            // 
            // lblReplyUrl
            // 
            this.lblReplyUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplyUrl.Location = new System.Drawing.Point(3, 42);
            this.lblReplyUrl.Name = "lblReplyUrl";
            this.lblReplyUrl.Size = new System.Drawing.Size(239, 42);
            this.lblReplyUrl.TabIndex = 14;
            this.lblReplyUrl.Text = "Reply Url";
            this.lblReplyUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReplyUrl
            // 
            this.txtReplyUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplyUrl.Location = new System.Drawing.Point(248, 50);
            this.txtReplyUrl.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtReplyUrl.Name = "txtReplyUrl";
            this.txtReplyUrl.Size = new System.Drawing.Size(485, 26);
            this.txtReplyUrl.TabIndex = 3;
            // 
            // SdkLoginControlControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SdkLoginControlControl";
            this.Size = new System.Drawing.Size(736, 228);
            this.Load += new System.EventHandler(this.SdkLoginControlControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbUseDefault;
        private System.Windows.Forms.RadioButton rdbUseCustom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAzureAdAppId;
        private System.Windows.Forms.TextBox txtAzureAdAppId;
        private System.Windows.Forms.Label lblReplyUrl;
        private System.Windows.Forms.TextBox txtReplyUrl;
        private System.Windows.Forms.Button btnOpenSdkLoginCtrl;
    }
}
