namespace McTools.Xrm.Connection.WinForms
{
    partial class EnvHighlightSettingsDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUseOrgTheme = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTextColor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBackColor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBackColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtText, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTextColor
            // 
            this.btnTextColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTextColor.Location = new System.Drawing.Point(221, 55);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(82, 46);
            this.btnTextColor.TabIndex = 3;
            this.btnTextColor.Text = "...";
            this.btnTextColor.UseVisualStyleBackColor = true;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackColor
            // 
            this.lblBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackColor.Location = new System.Drawing.Point(3, 0);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(212, 52);
            this.lblBackColor.TabIndex = 0;
            this.lblBackColor.Text = "Background color";
            this.lblBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBackColor
            // 
            this.btnBackColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackColor.Location = new System.Drawing.Point(221, 3);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(82, 46);
            this.btnBackColor.TabIndex = 1;
            this.btnBackColor.Text = "...";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // txtText
            // 
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(221, 107);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(649, 31);
            this.txtText.TabIndex = 5;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(707, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 42);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUseOrgTheme
            // 
            this.btnUseOrgTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseOrgTheme.Location = new System.Drawing.Point(404, 158);
            this.btnUseOrgTheme.Name = "btnUseOrgTheme";
            this.btnUseOrgTheme.Size = new System.Drawing.Size(297, 42);
            this.btnUseOrgTheme.TabIndex = 21;
            this.btnUseOrgTheme.Text = "Use organization theme";
            this.btnUseOrgTheme.UseVisualStyleBackColor = true;
            this.btnUseOrgTheme.Click += new System.EventHandler(this.btnUseOrgTheme_Click);
            // 
            // EnvHighlightSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 212);
            this.Controls.Add(this.btnUseOrgTheme);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnvHighlightSettingsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom template settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUseOrgTheme;
    }
}