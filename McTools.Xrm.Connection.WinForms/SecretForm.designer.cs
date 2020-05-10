namespace McTools.Xrm.Connection.WinForms
{
    partial class SecretForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.tbClientSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bValidate = new System.Windows.Forms.Button();
            this.chkShowCharacters = new System.Windows.Forms.CheckBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblConnectionName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Id";
            // 
            // tbClientId
            // 
            this.tbClientId.Location = new System.Drawing.Point(198, 114);
            this.tbClientId.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.ReadOnly = true;
            this.tbClientId.Size = new System.Drawing.Size(411, 31);
            this.tbClientId.TabIndex = 4;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(490, 6);
            this.bCancel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(151, 44);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // tbClientSecret
            // 
            this.tbClientSecret.Location = new System.Drawing.Point(198, 156);
            this.tbClientSecret.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbClientSecret.Name = "tbClientSecret";
            this.tbClientSecret.PasswordChar = '•';
            this.tbClientSecret.Size = new System.Drawing.Size(411, 31);
            this.tbClientSecret.TabIndex = 1;
            this.tbClientSecret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Client Secret";
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bValidate.Location = new System.Drawing.Point(326, 8);
            this.bValidate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(151, 44);
            this.bValidate.TabIndex = 4;
            this.bValidate.Text = "OK";
            this.bValidate.UseVisualStyleBackColor = true;
            this.bValidate.Click += new System.EventHandler(this.bValidate_Click);
            // 
            // chkShowCharacters
            // 
            this.chkShowCharacters.AutoSize = true;
            this.chkShowCharacters.Location = new System.Drawing.Point(198, 199);
            this.chkShowCharacters.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chkShowCharacters.Name = "chkShowCharacters";
            this.chkShowCharacters.Size = new System.Drawing.Size(269, 29);
            this.chkShowCharacters.TabIndex = 2;
            this.chkShowCharacters.Text = "Show secret characters";
            this.chkShowCharacters.UseVisualStyleBackColor = true;
            this.chkShowCharacters.CheckedChanged += new System.EventHandler(this.chkShowCharacters_CheckedChanged);
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Location = new System.Drawing.Point(198, 240);
            this.chkSavePassword.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(379, 29);
            this.chkSavePassword.TabIndex = 3;
            this.chkSavePassword.Text = "Save this secret (will be encrypted)";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.bCancel);
            this.pnlFooter.Controls.Add(this.bValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 304);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(646, 62);
            this.pnlFooter.TabIndex = 6;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblConnectionName);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(646, 104);
            this.pnlHeader.TabIndex = 7;
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.AutoSize = true;
            this.lblConnectionName.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.lblConnectionName.Location = new System.Drawing.Point(15, 53);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(237, 37);
            this.lblConnectionName.TabIndex = 1;
            this.lblConnectionName.Text = "[Connection Name]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(509, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "Client secret required for connection";
            // 
            // SecretForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 366);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.chkSavePassword);
            this.Controls.Add(this.chkShowCharacters);
            this.Controls.Add(this.tbClientSecret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbClientId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "SecretForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Client secret required";
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TextBox tbClientSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bValidate;
        private System.Windows.Forms.CheckBox chkShowCharacters;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblConnectionName;
        private System.Windows.Forms.Label label3;
    }
}