namespace McTools.Xrm.Connection.WinForms
{
    partial class EnvHighlightDialog
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbUAT = new System.Windows.Forms.PictureBox();
            this.pbCustom = new System.Windows.Forms.PictureBox();
            this.rdbCustom = new System.Windows.Forms.RadioButton();
            this.rdbUAT = new System.Windows.Forms.RadioButton();
            this.rdbProd = new System.Windows.Forms.RadioButton();
            this.pbProd = new System.Windows.Forms.PictureBox();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 625);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1375, 52);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(11, 8);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(225, 33);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Remove Highlight";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(1131, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 33);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1250, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 33);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1375, 83);
            this.pnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose an environment highlight";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 83);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1375, 542);
            this.pnlMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.pbUAT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbCustom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rdbCustom, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbUAT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbProd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbProd, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1375, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbUAT
            // 
            this.pbUAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbUAT.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.XTB_HIGHLIGHT_UAT;
            this.pbUAT.Location = new System.Drawing.Point(455, 44);
            this.pbUAT.Margin = new System.Windows.Forms.Padding(2);
            this.pbUAT.Name = "pbUAT";
            this.pbUAT.Size = new System.Drawing.Size(462, 471);
            this.pbUAT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUAT.TabIndex = 5;
            this.pbUAT.TabStop = false;
            // 
            // pbCustom
            // 
            this.pbCustom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCustom.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.XTB_HIGHLIGHT_CUSTOM;
            this.pbCustom.Location = new System.Drawing.Point(922, 44);
            this.pbCustom.Margin = new System.Windows.Forms.Padding(2);
            this.pbCustom.Name = "pbCustom";
            this.pbCustom.Size = new System.Drawing.Size(449, 471);
            this.pbCustom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCustom.TabIndex = 4;
            this.pbCustom.TabStop = false;
            // 
            // rdbCustom
            // 
            this.rdbCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbCustom.Location = new System.Drawing.Point(922, 2);
            this.rdbCustom.Margin = new System.Windows.Forms.Padding(2);
            this.rdbCustom.Name = "rdbCustom";
            this.rdbCustom.Size = new System.Drawing.Size(451, 38);
            this.rdbCustom.TabIndex = 2;
            this.rdbCustom.TabStop = true;
            this.rdbCustom.Text = "Custom";
            this.rdbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbCustom.UseVisualStyleBackColor = true;
            this.rdbCustom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbCustom_MouseClick);
            // 
            // rdbUAT
            // 
            this.rdbUAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbUAT.Location = new System.Drawing.Point(455, 2);
            this.rdbUAT.Margin = new System.Windows.Forms.Padding(2);
            this.rdbUAT.Name = "rdbUAT";
            this.rdbUAT.Size = new System.Drawing.Size(463, 38);
            this.rdbUAT.TabIndex = 1;
            this.rdbUAT.TabStop = true;
            this.rdbUAT.Text = "UAT";
            this.rdbUAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbUAT.UseVisualStyleBackColor = true;
            // 
            // rdbProd
            // 
            this.rdbProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbProd.Location = new System.Drawing.Point(2, 2);
            this.rdbProd.Margin = new System.Windows.Forms.Padding(2);
            this.rdbProd.Name = "rdbProd";
            this.rdbProd.Size = new System.Drawing.Size(449, 38);
            this.rdbProd.TabIndex = 0;
            this.rdbProd.TabStop = true;
            this.rdbProd.Text = "Production";
            this.rdbProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbProd.UseVisualStyleBackColor = true;
            // 
            // pbProd
            // 
            this.pbProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbProd.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.XTB_HIGHLIGHT_PRODUCTION;
            this.pbProd.Location = new System.Drawing.Point(2, 44);
            this.pbProd.Margin = new System.Windows.Forms.Padding(2);
            this.pbProd.Name = "pbProd";
            this.pbProd.Size = new System.Drawing.Size(448, 471);
            this.pbProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProd.TabIndex = 3;
            this.pbProd.TabStop = false;
            // 
            // EnvHighlightDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 677);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnvHighlightDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbCustom;
        private System.Windows.Forms.RadioButton rdbCustom;
        private System.Windows.Forms.RadioButton rdbUAT;
        private System.Windows.Forms.RadioButton rdbProd;
        private System.Windows.Forms.PictureBox pbProd;
        private System.Windows.Forms.PictureBox pbUAT;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
    }
}