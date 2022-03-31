namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionSucceededControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearEnvHighlight = new System.Windows.Forms.Button();
            this.btnSetEnvHighlight = new System.Windows.Forms.Button();
            this.lblHighlight = new System.Windows.Forms.Label();
            this.lblBrowser = new System.Windows.Forms.Label();
            this.btnClearBrowser = new System.Windows.Forms.Button();
            this.btnSetBrowser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionName.Location = new System.Drawing.Point(125, 49);
            this.txtConnectionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(607, 26);
            this.txtConnectionName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(736, 62);
            this.label1.TabIndex = 17;
            this.label1.Text = "The connection was created successfully. If you want to save this connection, ple" +
    "ase provide a name for this connection.";
            // 
            // btnClearEnvHighlight
            // 
            this.btnClearEnvHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearEnvHighlight.Location = new System.Drawing.Point(484, 95);
            this.btnClearEnvHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearEnvHighlight.Name = "btnClearEnvHighlight";
            this.btnClearEnvHighlight.Size = new System.Drawing.Size(248, 33);
            this.btnClearEnvHighlight.TabIndex = 23;
            this.btnClearEnvHighlight.Text = "Clear Environment Highlight";
            this.btnClearEnvHighlight.UseVisualStyleBackColor = true;
            this.btnClearEnvHighlight.Visible = false;
            this.btnClearEnvHighlight.Click += new System.EventHandler(this.btnClearEnvHighlight_Click);
            // 
            // btnSetEnvHighlight
            // 
            this.btnSetEnvHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetEnvHighlight.Location = new System.Drawing.Point(248, 95);
            this.btnSetEnvHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetEnvHighlight.Name = "btnSetEnvHighlight";
            this.btnSetEnvHighlight.Size = new System.Drawing.Size(232, 33);
            this.btnSetEnvHighlight.TabIndex = 22;
            this.btnSetEnvHighlight.Text = "Set Environment Highlight";
            this.btnSetEnvHighlight.UseVisualStyleBackColor = true;
            this.btnSetEnvHighlight.Click += new System.EventHandler(this.btnSetEnvHighlight_Click);
            // 
            // lblHighlight
            // 
            this.lblHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHighlight.Location = new System.Drawing.Point(2, 101);
            this.lblHighlight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(255, 24);
            this.lblHighlight.TabIndex = 21;
            this.lblHighlight.Text = "Define an environment highlight";
            // 
            // lblBrowser
            // 
            this.lblBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrowser.Location = new System.Drawing.Point(2, 138);
            this.lblBrowser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(221, 27);
            this.lblBrowser.TabIndex = 24;
            this.lblBrowser.Text = "Define a browser and profile\r\n";
            // 
            // btnClearBrowser
            // 
            this.btnClearBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearBrowser.Location = new System.Drawing.Point(484, 132);
            this.btnClearBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearBrowser.Name = "btnClearBrowser";
            this.btnClearBrowser.Size = new System.Drawing.Size(248, 33);
            this.btnClearBrowser.TabIndex = 26;
            this.btnClearBrowser.Text = "Clear Browser";
            this.btnClearBrowser.UseVisualStyleBackColor = true;
            this.btnClearBrowser.Visible = false;
            this.btnClearBrowser.Click += new System.EventHandler(this.btnClearBrowser_Click);
            // 
            // btnSetBrowser
            // 
            this.btnSetBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBrowser.Location = new System.Drawing.Point(248, 132);
            this.btnSetBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetBrowser.Name = "btnSetBrowser";
            this.btnSetBrowser.Size = new System.Drawing.Size(232, 33);
            this.btnSetBrowser.TabIndex = 25;
            this.btnSetBrowser.Text = "Set Browser";
            this.btnSetBrowser.UseVisualStyleBackColor = true;
            this.btnSetBrowser.Click += new System.EventHandler(this.btnSetBrowser_Click);
            // 
            // ConnectionSucceededControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearBrowser);
            this.Controls.Add(this.btnSetBrowser);
            this.Controls.Add(this.lblBrowser);
            this.Controls.Add(this.btnClearEnvHighlight);
            this.Controls.Add(this.btnSetEnvHighlight);
            this.Controls.Add(this.lblHighlight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnectionName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionSucceededControl";
            this.Size = new System.Drawing.Size(736, 228);
            this.Load += new System.EventHandler(this.ConnectionSucceededControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearEnvHighlight;
        private System.Windows.Forms.Button btnSetEnvHighlight;
        private System.Windows.Forms.Label lblHighlight;
        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.Button btnClearBrowser;
        private System.Windows.Forms.Button btnSetBrowser;
    }
}
