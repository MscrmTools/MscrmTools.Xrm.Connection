﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompactConnectionSelector));
            this.cbbFiles = new System.Windows.Forms.ComboBox();
            this.pnlTopMru = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnChangeSize = new System.Windows.Forms.Button();
            this.btnDetailsView = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMru = new System.Windows.Forms.Button();
            this.btnConnectionManager = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.noConnectionControl1 = new McTools.Xrm.Connection.WinForms.UserControls.NoConnectionControl();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOther = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SimpleImageList = new System.Windows.Forms.ImageList(this.components);
            this.detailImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlTopSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlTopMru.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTopSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbFiles
            // 
            this.cbbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFiles.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFiles.FormattingEnabled = true;
            this.cbbFiles.ItemHeight = 40;
            this.cbbFiles.Location = new System.Drawing.Point(10, 10);
            this.cbbFiles.Name = "cbbFiles";
            this.cbbFiles.Size = new System.Drawing.Size(813, 46);
            this.cbbFiles.TabIndex = 0;
            this.cbbFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.cbbFiles.SelectedIndexChanged += new System.EventHandler(this.cbbFiles_SelectedIndexChanged);
            // 
            // pnlTopMru
            // 
            this.pnlTopMru.Controls.Add(this.cbbFiles);
            this.pnlTopMru.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMru.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMru.Name = "pnlTopMru";
            this.pnlTopMru.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopMru.Size = new System.Drawing.Size(833, 80);
            this.pnlTopMru.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnChangeSize);
            this.pnlBottom.Controls.Add(this.btnDetailsView);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnMru);
            this.pnlBottom.Controls.Add(this.btnConnectionManager);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 803);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(833, 74);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnChangeSize
            // 
            this.btnChangeSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChangeSize.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Size32;
            this.btnChangeSize.Location = new System.Drawing.Point(440, 10);
            this.btnChangeSize.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnChangeSize.Name = "btnChangeSize";
            this.btnChangeSize.Size = new System.Drawing.Size(54, 54);
            this.btnChangeSize.TabIndex = 6;
            this.btnChangeSize.UseVisualStyleBackColor = true;
            this.btnChangeSize.Click += new System.EventHandler(this.btnChangeSize_Click);
            // 
            // btnDetailsView
            // 
            this.btnDetailsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailsView.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Details32;
            this.btnDetailsView.Location = new System.Drawing.Point(386, 10);
            this.btnDetailsView.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnDetailsView.Name = "btnDetailsView";
            this.btnDetailsView.Size = new System.Drawing.Size(54, 54);
            this.btnDetailsView.TabIndex = 5;
            this.btnDetailsView.UseVisualStyleBackColor = true;
            this.btnDetailsView.Click += new System.EventHandler(this.btnDetailsView_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Search32;
            this.btnSearch.Location = new System.Drawing.Point(332, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 54);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMru
            // 
            this.btnMru.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMru.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.history;
            this.btnMru.Location = new System.Drawing.Point(278, 10);
            this.btnMru.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnMru.Name = "btnMru";
            this.btnMru.Size = new System.Drawing.Size(54, 54);
            this.btnMru.TabIndex = 3;
            this.btnMru.UseVisualStyleBackColor = true;
            this.btnMru.Click += new System.EventHandler(this.btnMru_Click);
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
            this.btnConnectionManager.Size = new System.Drawing.Size(268, 54);
            this.btnConnectionManager.TabIndex = 2;
            this.btnConnectionManager.Text = "Open Connection Manager";
            this.btnConnectionManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectionManager.UseVisualStyleBackColor = true;
            this.btnConnectionManager.Click += new System.EventHandler(this.btnConnectionManager_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(602, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 54);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(712, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.noConnectionControl1);
            this.pnlMain.Controls.Add(this.lvConnections);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 142);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(833, 661);
            this.pnlMain.TabIndex = 3;
            // 
            // noConnectionControl1
            // 
            this.noConnectionControl1.ActionLabel = null;
            this.noConnectionControl1.BackColor = System.Drawing.Color.White;
            this.noConnectionControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noConnectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noConnectionControl1.Location = new System.Drawing.Point(10, 10);
            this.noConnectionControl1.Name = "noConnectionControl1";
            this.noConnectionControl1.Size = new System.Drawing.Size(813, 641);
            this.noConnectionControl1.TabIndex = 1;
            // 
            // lvConnections
            // 
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chUrl,
            this.chUsername,
            this.chOther});
            this.lvConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnections.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.HideSelection = false;
            this.lvConnections.Location = new System.Drawing.Point(10, 10);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.OwnerDraw = true;
            this.lvConnections.Size = new System.Drawing.Size(813, 641);
            this.lvConnections.SmallImageList = this.SimpleImageList;
            this.lvConnections.TabIndex = 0;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConnections_DrawColumnHeader);
            this.lvConnections.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnections_DrawItem);
            this.lvConnections.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvConnections_DrawSubItem);
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            this.lvConnections.DoubleClick += new System.EventHandler(this.lvConnections_DoubleClick);
            // 
            // chFile
            // 
            this.chFile.Text = "Name";
            // 
            // chUrl
            // 
            this.chUrl.Text = "Url";
            // 
            // chUsername
            // 
            this.chUsername.Text = "Username";
            // 
            // chOther
            // 
            this.chOther.Text = "";
            // 
            // SimpleImageList
            // 
            this.SimpleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.SimpleImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.SimpleImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // detailImageList
            // 
            this.detailImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("detailImageList.ImageStream")));
            this.detailImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.detailImageList.Images.SetKeyName(0, "CRMOnlineLive_16.png");
            this.detailImageList.Images.SetKeyName(1, "server.png");
            this.detailImageList.Images.SetKeyName(2, "Dataverse_16x16.png");
            // 
            // pnlTopSearch
            // 
            this.pnlTopSearch.Controls.Add(this.txtSearch);
            this.pnlTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSearch.Location = new System.Drawing.Point(0, 80);
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopSearch.Size = new System.Drawing.Size(833, 62);
            this.pnlTopSearch.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(10, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(813, 45);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // CompactConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 877);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTopSearch);
            this.Controls.Add(this.pnlTopMru);
            this.KeyPreview = true;
            this.Name = "CompactConnectionSelector";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CompactConnectionSelector_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompactConnectionSelector_KeyDown);
            this.pnlTopMru.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlTopSearch.ResumeLayout(false);
            this.pnlTopSearch.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.ComboBox cbbFiles;
        private System.Windows.Forms.Panel pnlTopMru;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.ImageList SimpleImageList;
        private System.Windows.Forms.Button btnConnectionManager;
        private UserControls.NoConnectionControl noConnectionControl1;
        private System.Windows.Forms.ImageList detailImageList;
        private System.Windows.Forms.ColumnHeader chUrl;
        private System.Windows.Forms.ColumnHeader chUsername;
        private System.Windows.Forms.ColumnHeader chOther;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMru;
        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDetailsView;
        private System.Windows.Forms.Button btnChangeSize;
    }
}