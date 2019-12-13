namespace McTools.Xrm.Connection.WinForms.CustomControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPageControl));
            this.btnStandard = new System.Windows.Forms.Button();
            this.btnSdkLoginControl = new System.Windows.Forms.Button();
            this.btnConnectionString = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnServicePrincipal = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStandard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.logo_0100;
            this.btnStandard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStandard.Location = new System.Drawing.Point(22, 22);
            this.btnStandard.Margin = new System.Windows.Forms.Padding(22);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(135, 127);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "Connection Wizard";
            this.btnStandard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStandard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSdkLoginControl
            // 
            this.btnSdkLoginControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSdkLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSdkLoginControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSdkLoginControl.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.LogoDyn365;
            this.btnSdkLoginControl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSdkLoginControl.Location = new System.Drawing.Point(201, 22);
            this.btnSdkLoginControl.Margin = new System.Windows.Forms.Padding(22);
            this.btnSdkLoginControl.Name = "btnSdkLoginControl";
            this.btnSdkLoginControl.Size = new System.Drawing.Size(135, 127);
            this.btnSdkLoginControl.TabIndex = 1;
            this.btnSdkLoginControl.Text = "SDK Login Control";
            this.btnSdkLoginControl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSdkLoginControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSdkLoginControl.UseVisualStyleBackColor = true;
            this.btnSdkLoginControl.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnConnectionString
            // 
            this.btnConnectionString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectionString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConnectionString.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.ConnectionStringImage1;
            this.btnConnectionString.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnectionString.Location = new System.Drawing.Point(380, 22);
            this.btnConnectionString.Margin = new System.Windows.Forms.Padding(22);
            this.btnConnectionString.Name = "btnConnectionString";
            this.btnConnectionString.Size = new System.Drawing.Size(135, 127);
            this.btnConnectionString.TabIndex = 2;
            this.btnConnectionString.Text = "Connection String";
            this.btnConnectionString.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnectionString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnectionString.UseVisualStyleBackColor = true;
            this.btnConnectionString.Click += new System.EventHandler(this.btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnServicePrincipal, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConnectionString, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSdkLoginControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStandard, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 171);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnServicePrincipal
            // 
            this.btnServicePrincipal.AccessibleName = "Service Principal";
            this.btnServicePrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServicePrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnServicePrincipal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicePrincipal.Image = ((System.Drawing.Image)(resources.GetObject("btnServicePrincipal.Image")));
            this.btnServicePrincipal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnServicePrincipal.Location = new System.Drawing.Point(559, 22);
            this.btnServicePrincipal.Margin = new System.Windows.Forms.Padding(22);
            this.btnServicePrincipal.Name = "btnServicePrincipal";
            this.btnServicePrincipal.Size = new System.Drawing.Size(138, 127);
            this.btnServicePrincipal.TabIndex = 3;
            this.btnServicePrincipal.Text = "Service Principal";
            this.btnServicePrincipal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnServicePrincipal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServicePrincipal.UseVisualStyleBackColor = true;
            this.btnServicePrincipal.Click += new System.EventHandler(this.btn_Click);
            // 
            // StartPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartPageControl";
            this.Size = new System.Drawing.Size(719, 171);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnSdkLoginControl;
        private System.Windows.Forms.Button btnConnectionString;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnServicePrincipal;
    }
}
