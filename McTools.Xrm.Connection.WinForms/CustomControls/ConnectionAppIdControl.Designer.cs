namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionAppIdControl
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
            this.lblHomeRealmQuestion = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHomeRealmQuestion
            // 
            this.lblHomeRealmQuestion.AutoSize = true;
            this.lblHomeRealmQuestion.Location = new System.Drawing.Point(4, 0);
            this.lblHomeRealmQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeRealmQuestion.Name = "lblHomeRealmQuestion";
            this.lblHomeRealmQuestion.Size = new System.Drawing.Size(238, 25);
            this.lblHomeRealmQuestion.TabIndex = 11;
            this.lblHomeRealmQuestion.Text = "Azure AD Application Id";
            // 
            // txtAppId
            // 
            this.txtAppId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppId.Location = new System.Drawing.Point(9, 39);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(956, 31);
            this.txtAppId.TabIndex = 3;
            // 
            // ConnectionAppIdControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHomeRealmQuestion);
            this.Controls.Add(this.txtAppId);
            this.Name = "ConnectionAppIdControl";
            this.Size = new System.Drawing.Size(982, 285);
            this.Load += new System.EventHandler(this.ConnectionIfdControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHomeRealmQuestion;
        private System.Windows.Forms.TextBox txtAppId;
    }
}
