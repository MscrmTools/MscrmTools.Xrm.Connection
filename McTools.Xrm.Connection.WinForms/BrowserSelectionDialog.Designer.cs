
namespace McTools.Xrm.Connection.WinForms
{
    partial class BrowserSelectionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblBrowser = new System.Windows.Forms.Label();
            this.cbbBrowser = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(587, 58);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a browser and profile name to use";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 204);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(587, 58);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(342, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(459, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.comboBox1);
            this.pnlMain.Controls.Add(this.btnTest);
            this.pnlMain.Controls.Add(this.lblProfileName);
            this.pnlMain.Controls.Add(this.lblBrowser);
            this.pnlMain.Controls.Add(this.cbbBrowser);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 58);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(587, 146);
            this.pnlMain.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Chrome",
            "Edge",
            "Firefox"});
            this.comboBox1.Location = new System.Drawing.Point(125, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(450, 28);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 5;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(464, 92);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(111, 31);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Location = new System.Drawing.Point(12, 52);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(53, 20);
            this.lblProfileName.TabIndex = 2;
            this.lblProfileName.Text = "Profile";
            // 
            // lblBrowser
            // 
            this.lblBrowser.AutoSize = true;
            this.lblBrowser.Location = new System.Drawing.Point(12, 18);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(67, 20);
            this.lblBrowser.TabIndex = 1;
            this.lblBrowser.Text = "Browser";
            // 
            // cbbBrowser
            // 
            this.cbbBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBrowser.FormattingEnabled = true;
            this.cbbBrowser.Items.AddRange(new object[] {
            "Chrome",
            "Edge",
            "Firefox"});
            this.cbbBrowser.Location = new System.Drawing.Point(125, 15);
            this.cbbBrowser.Name = "cbbBrowser";
            this.cbbBrowser.Size = new System.Drawing.Size(450, 28);
            this.cbbBrowser.TabIndex = 0;
            this.cbbBrowser.SelectedIndexChanged += new System.EventHandler(this.cbbBrowser_SelectedIndexChanged);
            // 
            // BrowserSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 262);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowserSelectionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browser Selection";
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.ComboBox cbbBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}