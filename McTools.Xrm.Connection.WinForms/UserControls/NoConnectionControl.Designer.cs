
namespace McTools.Xrm.Connection.WinForms.UserControls
{
    partial class NoConnectionControl
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
            this.lblNoConnectionFound = new System.Windows.Forms.Label();
            this.pbNoConnection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoConnectionFound
            // 
            this.lblNoConnectionFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoConnectionFound.Location = new System.Drawing.Point(0, 446);
            this.lblNoConnectionFound.Name = "lblNoConnectionFound";
            this.lblNoConnectionFound.Size = new System.Drawing.Size(773, 56);
            this.lblNoConnectionFound.TabIndex = 3;
            this.lblNoConnectionFound.Text = "No connection found!";
            this.lblNoConnectionFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbNoConnection
            // 
            this.pbNoConnection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbNoConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.NoConnection512;
            this.pbNoConnection.Location = new System.Drawing.Point(255, 181);
            this.pbNoConnection.Name = "pbNoConnection";
            this.pbNoConnection.Size = new System.Drawing.Size(265, 262);
            this.pbNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoConnection.TabIndex = 2;
            this.pbNoConnection.TabStop = false;
            // 
            // NoConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblNoConnectionFound);
            this.Controls.Add(this.pbNoConnection);
            this.Name = "NoConnectionControl";
            this.Size = new System.Drawing.Size(771, 618);
            this.Load += new System.EventHandler(this.NoConnectionControl_Load);
            this.Resize += new System.EventHandler(this.NoConnectionControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNoConnectionFound;
        private System.Windows.Forms.PictureBox pbNoConnection;
    }
}
