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
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionName.Location = new System.Drawing.Point(154, 83);
            this.txtConnectionName.Margin = new System.Windows.Forms.Padding(5);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(741, 29);
            this.txtConnectionName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 74);
            this.label1.TabIndex = 17;
            this.label1.Text = "The connection was created successfully. If you want to save this connection, ple" +
    "ase provide a name for this connection.";
            // 
            // btnClearEnvHighlight
            // 
            this.btnClearEnvHighlight.Location = new System.Drawing.Point(294, 183);
            this.btnClearEnvHighlight.Name = "btnClearEnvHighlight";
            this.btnClearEnvHighlight.Size = new System.Drawing.Size(335, 40);
            this.btnClearEnvHighlight.TabIndex = 23;
            this.btnClearEnvHighlight.Text = "Clear Environment Highlight";
            this.btnClearEnvHighlight.UseVisualStyleBackColor = true;
            this.btnClearEnvHighlight.Visible = false;
            this.btnClearEnvHighlight.Click += new System.EventHandler(this.btnClearEnvHighlight_Click);
            // 
            // btnSetEnvHighlight
            // 
            this.btnSetEnvHighlight.Location = new System.Drawing.Point(5, 183);
            this.btnSetEnvHighlight.Name = "btnSetEnvHighlight";
            this.btnSetEnvHighlight.Size = new System.Drawing.Size(283, 40);
            this.btnSetEnvHighlight.TabIndex = 22;
            this.btnSetEnvHighlight.Text = "Set Environment Highlight";
            this.btnSetEnvHighlight.UseVisualStyleBackColor = true;
            this.btnSetEnvHighlight.Click += new System.EventHandler(this.btnSetEnvHighlight_Click);
            // 
            // lblHighlight
            // 
            this.lblHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHighlight.Location = new System.Drawing.Point(0, 137);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(895, 43);
            this.lblHighlight.TabIndex = 21;
            this.lblHighlight.Text = "You can also define an environment highlight for this connection";
            // 
            // ConnectionSucceededControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearEnvHighlight);
            this.Controls.Add(this.btnSetEnvHighlight);
            this.Controls.Add(this.lblHighlight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnectionName);
            this.Controls.Add(this.label1);
            this.Name = "ConnectionSucceededControl";
            this.Size = new System.Drawing.Size(900, 274);
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
    }
}
