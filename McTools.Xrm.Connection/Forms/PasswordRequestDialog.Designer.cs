namespace McTools.Xrm.Connection.Forms
{
    partial class PasswordRequestDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bValidate = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlReason = new System.Windows.Forms.Panel();
            this.lblReason = new System.Windows.Forms.Label();
            this.pnlDecision = new System.Windows.Forms.Panel();
            this.rdbThisSession = new System.Windows.Forms.RadioButton();
            this.rdbThisTimeOnly = new System.Windows.Forms.RadioButton();
            this.rdbDoNotAllow = new System.Windows.Forms.RadioButton();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlReason.SuspendLayout();
            this.pnlDecision.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(705, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "The reason of this request is displayed below. Please provide an answer";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(13, 13);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(446, 37);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "The tool needs your password";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.bCancel);
            this.pnlFooter.Controls.Add(this.bValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 501);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 60);
            this.pnlFooter.TabIndex = 1;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(633, 9);
            this.bCancel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(151, 44);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bValidate.Location = new System.Drawing.Point(468, 9);
            this.bValidate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(151, 44);
            this.bValidate.TabIndex = 6;
            this.bValidate.Text = "OK";
            this.bValidate.UseVisualStyleBackColor = true;
            this.bValidate.Click += new System.EventHandler(this.bValidate_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlReason);
            this.pnlMain.Controls.Add(this.pnlDecision);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 100);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(800, 401);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlReason
            // 
            this.pnlReason.AutoScroll = true;
            this.pnlReason.Controls.Add(this.lblReason);
            this.pnlReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReason.Location = new System.Drawing.Point(10, 10);
            this.pnlReason.Name = "pnlReason";
            this.pnlReason.Size = new System.Drawing.Size(780, 257);
            this.pnlReason.TabIndex = 2;
            // 
            // lblReason
            // 
            this.lblReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReason.Location = new System.Drawing.Point(0, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(780, 257);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "[reason]";
            // 
            // pnlDecision
            // 
            this.pnlDecision.Controls.Add(this.rdbThisSession);
            this.pnlDecision.Controls.Add(this.rdbThisTimeOnly);
            this.pnlDecision.Controls.Add(this.rdbDoNotAllow);
            this.pnlDecision.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDecision.Location = new System.Drawing.Point(10, 267);
            this.pnlDecision.Name = "pnlDecision";
            this.pnlDecision.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDecision.Size = new System.Drawing.Size(780, 124);
            this.pnlDecision.TabIndex = 1;
            // 
            // rdbThisSession
            // 
            this.rdbThisSession.AutoSize = true;
            this.rdbThisSession.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdbThisSession.Location = new System.Drawing.Point(10, 68);
            this.rdbThisSession.Name = "rdbThisSession";
            this.rdbThisSession.Size = new System.Drawing.Size(760, 29);
            this.rdbThisSession.TabIndex = 2;
            this.rdbThisSession.Text = "I share my password for this session";
            this.rdbThisSession.UseVisualStyleBackColor = true;
            // 
            // rdbThisTimeOnly
            // 
            this.rdbThisTimeOnly.AutoSize = true;
            this.rdbThisTimeOnly.Checked = true;
            this.rdbThisTimeOnly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdbThisTimeOnly.Location = new System.Drawing.Point(10, 39);
            this.rdbThisTimeOnly.Name = "rdbThisTimeOnly";
            this.rdbThisTimeOnly.Size = new System.Drawing.Size(760, 29);
            this.rdbThisTimeOnly.TabIndex = 1;
            this.rdbThisTimeOnly.TabStop = true;
            this.rdbThisTimeOnly.Text = "I share my password just for now";
            this.rdbThisTimeOnly.UseVisualStyleBackColor = true;
            // 
            // rdbDoNotAllow
            // 
            this.rdbDoNotAllow.AutoSize = true;
            this.rdbDoNotAllow.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdbDoNotAllow.Location = new System.Drawing.Point(10, 10);
            this.rdbDoNotAllow.Name = "rdbDoNotAllow";
            this.rdbDoNotAllow.Size = new System.Drawing.Size(760, 29);
            this.rdbDoNotAllow.TabIndex = 0;
            this.rdbDoNotAllow.Text = "I don\'t want to share my password";
            this.rdbDoNotAllow.UseVisualStyleBackColor = true;
            // 
            // PasswordRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordRequestDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your password is required";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlReason.ResumeLayout(false);
            this.pnlDecision.ResumeLayout(false);
            this.pnlDecision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Panel pnlDecision;
        private System.Windows.Forms.RadioButton rdbThisSession;
        private System.Windows.Forms.RadioButton rdbThisTimeOnly;
        private System.Windows.Forms.RadioButton rdbDoNotAllow;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bValidate;
    }
}