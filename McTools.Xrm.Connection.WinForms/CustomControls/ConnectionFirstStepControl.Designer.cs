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
            this.lblUseMfa = new System.Windows.Forms.Label();
            this.chkUseMfa = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOrganizationUrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWindowsAuth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkUseIntegratedAuthentication, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUseMfa, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkUseMfa, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeout, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblUrl
            // 
            this.lblUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUrl.Location = new System.Drawing.Point(4, 0);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(312, 50);
            this.lblUrl.TabIndex = 11;
            this.lblUrl.Text = "Organization url";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrganizationUrl
            // 
            this.txtOrganizationUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrganizationUrl.Location = new System.Drawing.Point(324, 10);
            this.txtOrganizationUrl.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtOrganizationUrl.Name = "txtOrganizationUrl";
            this.txtOrganizationUrl.Size = new System.Drawing.Size(572, 29);
            this.txtOrganizationUrl.TabIndex = 13;
            // 
            // lblWindowsAuth
            // 
            this.lblWindowsAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowsAuth.Location = new System.Drawing.Point(4, 50);
            this.lblWindowsAuth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWindowsAuth.Name = "lblWindowsAuth";
            this.lblWindowsAuth.Size = new System.Drawing.Size(312, 50);
            this.lblWindowsAuth.TabIndex = 14;
            this.lblWindowsAuth.Text = "Use your current credentials";
            this.lblWindowsAuth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUseIntegratedAuthentication
            // 
            this.chkUseIntegratedAuthentication.AutoSize = true;
            this.chkUseIntegratedAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseIntegratedAuthentication.Location = new System.Drawing.Point(324, 54);
            this.chkUseIntegratedAuthentication.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseIntegratedAuthentication.Name = "chkUseIntegratedAuthentication";
            this.chkUseIntegratedAuthentication.Size = new System.Drawing.Size(572, 42);
            this.chkUseIntegratedAuthentication.TabIndex = 15;
            this.chkUseIntegratedAuthentication.UseVisualStyleBackColor = true;
            // 
            // lblUseMfa
            // 
            this.lblUseMfa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUseMfa.Location = new System.Drawing.Point(4, 100);
            this.lblUseMfa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUseMfa.Name = "lblUseMfa";
            this.lblUseMfa.Size = new System.Drawing.Size(312, 50);
            this.lblUseMfa.TabIndex = 16;
            this.lblUseMfa.Text = "Use Multi Factor Authentication";
            this.lblUseMfa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUseMfa
            // 
            this.chkUseMfa.AutoSize = true;
            this.chkUseMfa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseMfa.Location = new System.Drawing.Point(324, 104);
            this.chkUseMfa.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseMfa.Name = "chkUseMfa";
            this.chkUseMfa.Size = new System.Drawing.Size(572, 42);
            this.chkUseMfa.TabIndex = 17;
            this.chkUseMfa.Text = "(CRM online only - preview)";
            this.chkUseMfa.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 50);
            this.label4.TabIndex = 18;
            this.label4.Text = "Service timeout";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTimeout.Location = new System.Drawing.Point(324, 160);
            this.txtTimeout.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(84, 29);
            this.txtTimeout.TabIndex = 19;
            this.txtTimeout.Text = "00:02:00";
            // 
            // ConnectionFirstStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectionFirstStepControl";
            this.Size = new System.Drawing.Size(900, 274);
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
        private System.Windows.Forms.Label lblUseMfa;
        private System.Windows.Forms.CheckBox chkUseMfa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeout;
    }
}
