
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
            this.btnShowHideSettings = new System.Windows.Forms.Button();
            this.btnConnectionManager = new System.Windows.Forms.Button();
            this.btnNewConnection = new System.Windows.Forms.Button();
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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFilterForAdditionnal = new System.Windows.Forms.Button();
            this.btnChangeSize = new System.Windows.Forms.Button();
            this.btnDetailsView = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMru = new System.Windows.Forms.Button();
            this.pnlAdditionnalConnectionInfo = new System.Windows.Forms.Panel();
            this.lblAdditionnalConnectionInfo = new System.Windows.Forms.Label();
            this.llClearAdditionalConnectionFilter = new System.Windows.Forms.LinkLabel();
            this.pnlAdditionnalConnectionInfoParent = new System.Windows.Forms.Panel();
            this.pnlTopMru.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTopSearch.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlAdditionnalConnectionInfo.SuspendLayout();
            this.pnlAdditionnalConnectionInfoParent.SuspendLayout();
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
            this.cbbFiles.Location = new System.Drawing.Point(9, 8);
            this.cbbFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbFiles.Name = "cbbFiles";
            this.cbbFiles.Size = new System.Drawing.Size(774, 46);
            this.cbbFiles.TabIndex = 1;
            this.cbbFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.cbbFiles.SelectedIndexChanged += new System.EventHandler(this.cbbFiles_SelectedIndexChanged);
            // 
            // pnlTopMru
            // 
            this.pnlTopMru.Controls.Add(this.cbbFiles);
            this.pnlTopMru.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMru.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMru.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTopMru.Name = "pnlTopMru";
            this.pnlTopMru.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlTopMru.Size = new System.Drawing.Size(792, 64);
            this.pnlTopMru.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnShowHideSettings);
            this.pnlBottom.Controls.Add(this.btnConnectionManager);
            this.pnlBottom.Controls.Add(this.btnNewConnection);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 573);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlBottom.Size = new System.Drawing.Size(792, 59);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnShowHideSettings
            // 
            this.btnShowHideSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowHideSettings.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Settings24;
            this.btnShowHideSettings.Location = new System.Drawing.Point(329, 8);
            this.btnShowHideSettings.Margin = new System.Windows.Forms.Padding(3, 2, 9, 2);
            this.btnShowHideSettings.Name = "btnShowHideSettings";
            this.btnShowHideSettings.Size = new System.Drawing.Size(48, 43);
            this.btnShowHideSettings.TabIndex = 9;
            this.btnShowHideSettings.UseVisualStyleBackColor = true;
            this.btnShowHideSettings.Click += new System.EventHandler(this.btnShowHideSettings_Click);
            // 
            // btnConnectionManager
            // 
            this.btnConnectionManager.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConnectionManager.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Connection32;
            this.btnConnectionManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectionManager.Location = new System.Drawing.Point(91, 8);
            this.btnConnectionManager.Margin = new System.Windows.Forms.Padding(3, 2, 9, 2);
            this.btnConnectionManager.Name = "btnConnectionManager";
            this.btnConnectionManager.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnConnectionManager.Size = new System.Drawing.Size(238, 43);
            this.btnConnectionManager.TabIndex = 1;
            this.btnConnectionManager.Text = "Open Connection Manager";
            this.btnConnectionManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectionManager.UseVisualStyleBackColor = true;
            this.btnConnectionManager.Click += new System.EventHandler(this.btnConnectionManager_Click);
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.plus;
            this.btnNewConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewConnection.Location = new System.Drawing.Point(9, 8);
            this.btnNewConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(82, 43);
            this.btnNewConnection.TabIndex = 10;
            this.btnNewConnection.Text = "New";
            this.btnNewConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewConnection.UseVisualStyleBackColor = true;
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(586, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 9, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 43);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(684, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 43);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.noConnectionControl1);
            this.pnlMain.Controls.Add(this.lvConnections);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 158);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlMain.Size = new System.Drawing.Size(792, 415);
            this.pnlMain.TabIndex = 2;
            // 
            // noConnectionControl1
            // 
            this.noConnectionControl1.ActionLabel = null;
            this.noConnectionControl1.BackColor = System.Drawing.Color.White;
            this.noConnectionControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noConnectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noConnectionControl1.Location = new System.Drawing.Point(9, 8);
            this.noConnectionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noConnectionControl1.Name = "noConnectionControl1";
            this.noConnectionControl1.Size = new System.Drawing.Size(774, 399);
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
            this.lvConnections.Location = new System.Drawing.Point(9, 8);
            this.lvConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.OwnerDraw = true;
            this.lvConnections.Size = new System.Drawing.Size(774, 399);
            this.lvConnections.SmallImageList = this.SimpleImageList;
            this.lvConnections.TabIndex = 2;
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
            this.pnlTopSearch.Location = new System.Drawing.Point(0, 64);
            this.pnlTopSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlTopSearch.Size = new System.Drawing.Size(792, 50);
            this.pnlTopSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(9, 8);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(774, 39);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.tableLayoutPanel1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSettings.Location = new System.Drawing.Point(0, 632);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(7, 0, 0, 8);
            this.pnlSettings.Size = new System.Drawing.Size(792, 99);
            this.pnlSettings.TabIndex = 4;
            this.pnlSettings.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnFilterForAdditionnal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeSize, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDetailsView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMru, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 91);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnFilterForAdditionnal
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnFilterForAdditionnal, 2);
            this.btnFilterForAdditionnal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilterForAdditionnal.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.filter;
            this.btnFilterForAdditionnal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterForAdditionnal.Location = new System.Drawing.Point(264, 47);
            this.btnFilterForAdditionnal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilterForAdditionnal.Name = "btnFilterForAdditionnal";
            this.btnFilterForAdditionnal.Size = new System.Drawing.Size(518, 42);
            this.btnFilterForAdditionnal.TabIndex = 18;
            this.btnFilterForAdditionnal.Text = "Use Additional connection Filter";
            this.btnFilterForAdditionnal.UseVisualStyleBackColor = true;
            this.btnFilterForAdditionnal.Click += new System.EventHandler(this.btnFilterForAdditionnal_Click);
            // 
            // btnChangeSize
            // 
            this.btnChangeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeSize.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Size32;
            this.btnChangeSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeSize.Location = new System.Drawing.Point(3, 47);
            this.btnChangeSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeSize.Name = "btnChangeSize";
            this.btnChangeSize.Size = new System.Drawing.Size(255, 42);
            this.btnChangeSize.TabIndex = 17;
            this.btnChangeSize.Text = "Change size";
            this.btnChangeSize.UseVisualStyleBackColor = true;
            // 
            // btnDetailsView
            // 
            this.btnDetailsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetailsView.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Details32;
            this.btnDetailsView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailsView.Location = new System.Drawing.Point(525, 2);
            this.btnDetailsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetailsView.Name = "btnDetailsView";
            this.btnDetailsView.Size = new System.Drawing.Size(257, 41);
            this.btnDetailsView.TabIndex = 14;
            this.btnDetailsView.Text = "Use Details view";
            this.btnDetailsView.UseVisualStyleBackColor = true;
            this.btnDetailsView.Click += new System.EventHandler(this.btnDetailsView_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Search32;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(3, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(255, 41);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Show Search bar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMru
            // 
            this.btnMru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMru.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.history;
            this.btnMru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMru.Location = new System.Drawing.Point(264, 2);
            this.btnMru.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMru.Name = "btnMru";
            this.btnMru.Size = new System.Drawing.Size(255, 41);
            this.btnMru.TabIndex = 8;
            this.btnMru.Text = "Show MRU";
            this.btnMru.UseVisualStyleBackColor = true;
            this.btnMru.Click += new System.EventHandler(this.btnMru_Click);
            // 
            // pnlAdditionnalConnectionInfo
            // 
            this.pnlAdditionnalConnectionInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnlAdditionnalConnectionInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdditionnalConnectionInfo.Controls.Add(this.lblAdditionnalConnectionInfo);
            this.pnlAdditionnalConnectionInfo.Controls.Add(this.llClearAdditionalConnectionFilter);
            this.pnlAdditionnalConnectionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdditionnalConnectionInfo.Location = new System.Drawing.Point(10, 0);
            this.pnlAdditionnalConnectionInfo.Name = "pnlAdditionnalConnectionInfo";
            this.pnlAdditionnalConnectionInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAdditionnalConnectionInfo.Size = new System.Drawing.Size(772, 44);
            this.pnlAdditionnalConnectionInfo.TabIndex = 5;
            // 
            // lblAdditionnalConnectionInfo
            // 
            this.lblAdditionnalConnectionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdditionnalConnectionInfo.Location = new System.Drawing.Point(10, 10);
            this.lblAdditionnalConnectionInfo.Name = "lblAdditionnalConnectionInfo";
            this.lblAdditionnalConnectionInfo.Size = new System.Drawing.Size(663, 22);
            this.lblAdditionnalConnectionInfo.TabIndex = 1;
            this.lblAdditionnalConnectionInfo.Text = "You asked to add additional connection. The list is filtered with connections fro" +
    "m the same file.";
            this.lblAdditionnalConnectionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llClearAdditionalConnectionFilter
            // 
            this.llClearAdditionalConnectionFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.llClearAdditionalConnectionFilter.Location = new System.Drawing.Point(673, 10);
            this.llClearAdditionalConnectionFilter.Name = "llClearAdditionalConnectionFilter";
            this.llClearAdditionalConnectionFilter.Size = new System.Drawing.Size(87, 22);
            this.llClearAdditionalConnectionFilter.TabIndex = 0;
            this.llClearAdditionalConnectionFilter.TabStop = true;
            this.llClearAdditionalConnectionFilter.Text = "Clear filter";
            this.llClearAdditionalConnectionFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llClearAdditionalConnectionFilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llClearAdditionalConnectionFilter_LinkClicked);
            // 
            // pnlAdditionnalConnectionInfoParent
            // 
            this.pnlAdditionnalConnectionInfoParent.Controls.Add(this.pnlAdditionnalConnectionInfo);
            this.pnlAdditionnalConnectionInfoParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdditionnalConnectionInfoParent.Location = new System.Drawing.Point(0, 114);
            this.pnlAdditionnalConnectionInfoParent.Name = "pnlAdditionnalConnectionInfoParent";
            this.pnlAdditionnalConnectionInfoParent.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlAdditionnalConnectionInfoParent.Size = new System.Drawing.Size(792, 44);
            this.pnlAdditionnalConnectionInfoParent.TabIndex = 6;
            this.pnlAdditionnalConnectionInfoParent.Visible = false;
            // 
            // CompactConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 731);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlAdditionnalConnectionInfoParent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlTopSearch);
            this.Controls.Add(this.pnlTopMru);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pnlSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlAdditionnalConnectionInfo.ResumeLayout(false);
            this.pnlAdditionnalConnectionInfoParent.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnShowHideSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDetailsView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMru;
        private System.Windows.Forms.Button btnNewConnection;
        private System.Windows.Forms.Panel pnlAdditionnalConnectionInfo;
        private System.Windows.Forms.Label lblAdditionnalConnectionInfo;
        private System.Windows.Forms.LinkLabel llClearAdditionalConnectionFilter;
        private System.Windows.Forms.Panel pnlAdditionnalConnectionInfoParent;
        private System.Windows.Forms.Button btnFilterForAdditionnal;
        private System.Windows.Forms.Button btnChangeSize;
    }
}