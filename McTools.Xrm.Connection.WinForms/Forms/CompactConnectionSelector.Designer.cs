
namespace McTools.Xrm.Connection.WinForms.Forms
{
    partial class CompactConnectionSelector
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnConnectionManager = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlNoConnection = new System.Windows.Forms.Panel();
            this.llOpenConnectionManager = new System.Windows.Forms.LinkLabel();
            this.lblNoConnectionFound = new System.Windows.Forms.Label();
            this.pbNoConnection = new System.Windows.Forms.PictureBox();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SimpleImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlNoConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Variable Text", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 40;
            this.comboBox1.Location = new System.Drawing.Point(10, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(774, 46);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.comboBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(794, 90);
            this.pnlTop.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnConnectionManager);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 803);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(794, 74);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnConnectionManager
            // 
            this.btnConnectionManager.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConnectionManager.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Connection32;
            this.btnConnectionManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectionManager.Location = new System.Drawing.Point(10, 10);
            this.btnConnectionManager.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnConnectionManager.Name = "btnConnectionManager";
            this.btnConnectionManager.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnConnectionManager.Size = new System.Drawing.Size(279, 54);
            this.btnConnectionManager.TabIndex = 2;
            this.btnConnectionManager.Text = "Open Connection Manager";
            this.btnConnectionManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectionManager.UseVisualStyleBackColor = true;
            this.btnConnectionManager.Click += new System.EventHandler(this.btnConnectionManager_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(499, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(144, 54);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(643, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlNoConnection);
            this.pnlMain.Controls.Add(this.lvConnections);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(794, 713);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlNoConnection
            // 
            this.pnlNoConnection.BackColor = System.Drawing.Color.White;
            this.pnlNoConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoConnection.Controls.Add(this.llOpenConnectionManager);
            this.pnlNoConnection.Controls.Add(this.lblNoConnectionFound);
            this.pnlNoConnection.Controls.Add(this.pbNoConnection);
            this.pnlNoConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoConnection.Location = new System.Drawing.Point(10, 10);
            this.pnlNoConnection.Name = "pnlNoConnection";
            this.pnlNoConnection.Size = new System.Drawing.Size(774, 693);
            this.pnlNoConnection.TabIndex = 4;
            this.pnlNoConnection.Visible = false;
            // 
            // llOpenConnectionManager
            // 
            this.llOpenConnectionManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llOpenConnectionManager.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llOpenConnectionManager.Location = new System.Drawing.Point(10, 418);
            this.llOpenConnectionManager.Name = "llOpenConnectionManager";
            this.llOpenConnectionManager.Size = new System.Drawing.Size(748, 35);
            this.llOpenConnectionManager.TabIndex = 2;
            this.llOpenConnectionManager.TabStop = true;
            this.llOpenConnectionManager.Text = "Open Connection Manager to create a new connection";
            this.llOpenConnectionManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llOpenConnectionManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenConnectionManager_LinkClicked);
            // 
            // lblNoConnectionFound
            // 
            this.lblNoConnectionFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoConnectionFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoConnectionFound.Location = new System.Drawing.Point(2, 362);
            this.lblNoConnectionFound.Name = "lblNoConnectionFound";
            this.lblNoConnectionFound.Size = new System.Drawing.Size(756, 56);
            this.lblNoConnectionFound.TabIndex = 1;
            this.lblNoConnectionFound.Text = "No connection found!";
            this.lblNoConnectionFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbNoConnection
            // 
            this.pbNoConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNoConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.NoConnection512;
            this.pbNoConnection.Location = new System.Drawing.Point(249, 97);
            this.pbNoConnection.Name = "pbNoConnection";
            this.pbNoConnection.Size = new System.Drawing.Size(265, 262);
            this.pbNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoConnection.TabIndex = 0;
            this.pbNoConnection.TabStop = false;
            // 
            // lvConnections
            // 
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile});
            this.lvConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnections.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.HideSelection = false;
            this.lvConnections.Location = new System.Drawing.Point(10, 10);
            this.lvConnections.MultiSelect = false;
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.OwnerDraw = true;
            this.lvConnections.Size = new System.Drawing.Size(774, 693);
            this.lvConnections.SmallImageList = this.SimpleImageList;
            this.lvConnections.TabIndex = 0;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnections_DrawItem);
            this.lvConnections.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvConnections_DrawSubItem);
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            this.lvConnections.DoubleClick += new System.EventHandler(this.lvConnections_DoubleClick);
            // 
            // chFile
            // 
            this.chFile.Text = "";
            // 
            // SimpleImageList
            // 
            this.SimpleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.SimpleImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.SimpleImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CompactConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 877);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "CompactConnectionSelector";
            this.ShowIcon = false;
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlNoConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.ImageList SimpleImageList;
        private System.Windows.Forms.Button btnConnectionManager;
        private System.Windows.Forms.Panel pnlNoConnection;
        private System.Windows.Forms.LinkLabel llOpenConnectionManager;
        private System.Windows.Forms.Label lblNoConnectionFound;
        private System.Windows.Forms.PictureBox pbNoConnection;
    }
}