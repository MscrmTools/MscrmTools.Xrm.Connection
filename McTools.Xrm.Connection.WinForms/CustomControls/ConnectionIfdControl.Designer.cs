namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionIfdControl
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
            this.lblIfdQuestion = new System.Windows.Forms.Label();
            this.lblHomeRealmQuestion = new System.Windows.Forms.Label();
            this.txtHomeRealm = new System.Windows.Forms.TextBox();
            this.rbIfdNo = new System.Windows.Forms.RadioButton();
            this.rbIfdYes = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblIfdQuestion
            // 
            this.lblIfdQuestion.AutoSize = true;
            this.lblIfdQuestion.Location = new System.Drawing.Point(4, 18);
            this.lblIfdQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIfdQuestion.Name = "lblIfdQuestion";
            this.lblIfdQuestion.Size = new System.Drawing.Size(593, 25);
            this.lblIfdQuestion.TabIndex = 13;
            this.lblIfdQuestion.Text = "Are you connecting to an Internet Facing Deployment organization?";
            // 
            // lblHomeRealmQuestion
            // 
            this.lblHomeRealmQuestion.AutoSize = true;
            this.lblHomeRealmQuestion.Location = new System.Drawing.Point(4, 94);
            this.lblHomeRealmQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeRealmQuestion.Name = "lblHomeRealmQuestion";
            this.lblHomeRealmQuestion.Size = new System.Drawing.Size(427, 25);
            this.lblHomeRealmQuestion.TabIndex = 11;
            this.lblHomeRealmQuestion.Text = "If necessary, you can specify the home realm url";
            // 
            // txtHomeRealm
            // 
            this.txtHomeRealm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHomeRealm.Enabled = false;
            this.txtHomeRealm.Location = new System.Drawing.Point(9, 123);
            this.txtHomeRealm.Margin = new System.Windows.Forms.Padding(4);
            this.txtHomeRealm.Name = "txtHomeRealm";
            this.txtHomeRealm.Size = new System.Drawing.Size(877, 29);
            this.txtHomeRealm.TabIndex = 3;
            // 
            // rbIfdNo
            // 
            this.rbIfdNo.AutoSize = true;
            this.rbIfdNo.Checked = true;
            this.rbIfdNo.Location = new System.Drawing.Point(9, 47);
            this.rbIfdNo.Margin = new System.Windows.Forms.Padding(4);
            this.rbIfdNo.Name = "rbIfdNo";
            this.rbIfdNo.Size = new System.Drawing.Size(62, 29);
            this.rbIfdNo.TabIndex = 1;
            this.rbIfdNo.TabStop = true;
            this.rbIfdNo.Text = "No";
            this.rbIfdNo.UseVisualStyleBackColor = true;
            this.rbIfdNo.CheckedChanged += new System.EventHandler(this.rbIfdNo_CheckedChanged);
            // 
            // rbIfdYes
            // 
            this.rbIfdYes.AutoSize = true;
            this.rbIfdYes.Location = new System.Drawing.Point(90, 47);
            this.rbIfdYes.Margin = new System.Windows.Forms.Padding(4);
            this.rbIfdYes.Name = "rbIfdYes";
            this.rbIfdYes.Size = new System.Drawing.Size(71, 29);
            this.rbIfdYes.TabIndex = 2;
            this.rbIfdYes.Text = "Yes";
            this.rbIfdYes.UseVisualStyleBackColor = true;
            // 
            // ConnectionIfdControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIfdQuestion);
            this.Controls.Add(this.lblHomeRealmQuestion);
            this.Controls.Add(this.txtHomeRealm);
            this.Controls.Add(this.rbIfdNo);
            this.Controls.Add(this.rbIfdYes);
            this.Name = "ConnectionIfdControl";
            this.Size = new System.Drawing.Size(900, 274);
            this.Load += new System.EventHandler(this.ConnectionIfdControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIfdQuestion;
        private System.Windows.Forms.Label lblHomeRealmQuestion;
        private System.Windows.Forms.TextBox txtHomeRealm;
        private System.Windows.Forms.RadioButton rbIfdNo;
        private System.Windows.Forms.RadioButton rbIfdYes;
    }
}
