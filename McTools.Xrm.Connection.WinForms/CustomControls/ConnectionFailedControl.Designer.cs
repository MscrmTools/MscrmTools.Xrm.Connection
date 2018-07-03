namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionFailedControl
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
            this.llOpenConnectionLog = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llOpenConnectionLog
            // 
            this.llOpenConnectionLog.AutoSize = true;
            this.llOpenConnectionLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llOpenConnectionLog.Location = new System.Drawing.Point(0, 249);
            this.llOpenConnectionLog.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.llOpenConnectionLog.Name = "llOpenConnectionLog";
            this.llOpenConnectionLog.Size = new System.Drawing.Size(162, 25);
            this.llOpenConnectionLog.TabIndex = 20;
            this.llOpenConnectionLog.TabStop = true;
            this.llOpenConnectionLog.Text = "Open Logs folder";
            this.llOpenConnectionLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenConnectionLog_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(10);
            this.lblError.Size = new System.Drawing.Size(900, 249);
            this.lblError.TabIndex = 21;
            this.lblError.Text = "[lblError]";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectionFailedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.llOpenConnectionLog);
            this.Name = "ConnectionFailedControl";
            this.Size = new System.Drawing.Size(900, 274);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llOpenConnectionLog;
        private System.Windows.Forms.Label lblError;
    }
}
