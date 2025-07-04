namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionFirstStepControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtOrganizationUrl = new System.Windows.Forms.TextBox();
            this.lblWindowsAuth = new System.Windows.Forms.Label();
            this.chkUseIntegratedAuthentication = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOrganizationUrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWindowsAuth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkUseIntegratedAuthentication, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeout, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblUrl
            // 
            this.lblUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUrl.Location = new System.Drawing.Point(3, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(227, 34);
            this.lblUrl.TabIndex = 11;
            this.lblUrl.Text = "Environment url";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrganizationUrl
            // 
            this.txtOrganizationUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrganizationUrl.Location = new System.Drawing.Point(236, 6);
            this.txtOrganizationUrl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.txtOrganizationUrl.Name = "txtOrganizationUrl";
            this.txtOrganizationUrl.Size = new System.Drawing.Size(418, 22);
            this.txtOrganizationUrl.TabIndex = 1;
            this.txtOrganizationUrl.Text = "https://organization.crm.dynamics.com";
            // 
            // lblWindowsAuth
            // 
            this.lblWindowsAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowsAuth.Location = new System.Drawing.Point(3, 34);
            this.lblWindowsAuth.Name = "lblWindowsAuth";
            this.lblWindowsAuth.Size = new System.Drawing.Size(227, 34);
            this.lblWindowsAuth.TabIndex = 14;
            this.lblWindowsAuth.Text = "Use your current credentials";
            this.lblWindowsAuth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUseIntegratedAuthentication
            // 
            this.chkUseIntegratedAuthentication.AutoSize = true;
            this.chkUseIntegratedAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseIntegratedAuthentication.Location = new System.Drawing.Point(236, 36);
            this.chkUseIntegratedAuthentication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseIntegratedAuthentication.Name = "chkUseIntegratedAuthentication";
            this.chkUseIntegratedAuthentication.Size = new System.Drawing.Size(418, 30);
            this.chkUseIntegratedAuthentication.TabIndex = 2;
            this.chkUseIntegratedAuthentication.Text = "(AD and IFD instances only)";
            this.chkUseIntegratedAuthentication.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 34);
            this.label4.TabIndex = 18;
            this.label4.Text = "Service timeout";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTimeout.Location = new System.Drawing.Point(236, 74);
            this.txtTimeout.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(62, 22);
            this.txtTimeout.TabIndex = 4;
            this.txtTimeout.Text = "00:02:00";
            // 
            // ConnectionFirstStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionFirstStepControl";
            this.Size = new System.Drawing.Size(654, 182);
            this.Load += new System.EventHandler(this.ConnectionFirstStepControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtOrganizationUrl;
        private System.Windows.Forms.Label lblWindowsAuth;
        private System.Windows.Forms.CheckBox chkUseIntegratedAuthentication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeout;
    }
}
