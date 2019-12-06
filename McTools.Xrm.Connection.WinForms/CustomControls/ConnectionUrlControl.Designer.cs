namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionUrlControl
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
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOrganizationUrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeout, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 285);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblUrl
            // 
            this.lblUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUrl.Location = new System.Drawing.Point(4, 0);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(341, 52);
            this.lblUrl.TabIndex = 11;
            this.lblUrl.Text = "Organization url";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrganizationUrl
            // 
            this.txtOrganizationUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrganizationUrl.Location = new System.Drawing.Point(353, 10);
            this.txtOrganizationUrl.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtOrganizationUrl.Name = "txtOrganizationUrl";
            this.txtOrganizationUrl.Size = new System.Drawing.Size(625, 31);
            this.txtOrganizationUrl.TabIndex = 1;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(353, 62);
            this.txtTimeout.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(91, 31);
            this.txtTimeout.TabIndex = 4;
            this.txtTimeout.Text = "00:02:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(682, 104);
            this.label4.TabIndex = 19;
            this.label4.Text = "Service timeout";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectionUrlControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectionUrlControl";
            this.Size = new System.Drawing.Size(982, 285);
            this.Load += new System.EventHandler(this.ConnectionUrlControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtOrganizationUrl;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label4;
    }
}
