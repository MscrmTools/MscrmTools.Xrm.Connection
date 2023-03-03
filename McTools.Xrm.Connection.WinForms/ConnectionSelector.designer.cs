namespace McTools.Xrm.Connection.WinForms
{
    partial class ConnectionSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSelector));
            this.bCancel = new System.Windows.Forms.Button();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrganization = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastUsedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SimpleImageList = new System.Windows.Forms.ImageList(this.components);
            this.menu = new System.Windows.Forms.ToolStrip();
            this.tsbNewConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbCloneConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteConnection = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdatePassword = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowConnectionString = new System.Windows.Forms.ToolStripButton();
            this.tsbSetHighlight = new System.Windows.Forms.ToolStripButton();
            this.tsbSetProfile = new System.Windows.Forms.ToolStripButton();
            this.tsbConnectionProperties = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_UseMru = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMoveToNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToExistingFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tstSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbRenameFile = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveConnectionList = new System.Windows.Forms.ToolStripButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.bValidate = new System.Windows.Forms.Button();
            this.btnDetailsView = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lvConnectionFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsFiles = new System.Windows.Forms.ToolStrip();
            this.tsbCreateConnectionFile = new System.Windows.Forms.ToolStripButton();
            this.tsbAddExisting = new System.Windows.Forms.ToolStripButton();
            this.scConnections = new System.Windows.Forms.SplitContainer();
            this.txtSimpleRename = new System.Windows.Forms.TextBox();
            this.noConnectionControl1 = new McTools.Xrm.Connection.WinForms.UserControls.NoConnectionControl();
            this.pgConnection = new System.Windows.Forms.PropertyGrid();
            this.detailImageList = new System.Windows.Forms.ImageList(this.components);
            this.menu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tsFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConnections)).BeginInit();
            this.scConnections.Panel1.SuspendLayout();
            this.scConnections.Panel2.SuspendLayout();
            this.scConnections.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bCancel.Location = new System.Drawing.Point(1309, 10);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(114, 53);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancelClick);
            // 
            // lvConnections
            // 
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chServer,
            this.chOrganization,
            this.chUser,
            this.chVersion,
            this.chLastUsedOn});
            this.lvConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnections.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.GridLines = true;
            this.lvConnections.HideSelection = false;
            this.lvConnections.LabelEdit = true;
            this.lvConnections.Location = new System.Drawing.Point(0, 0);
            this.lvConnections.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.OwnerDraw = true;
            this.lvConnections.Size = new System.Drawing.Size(1080, 674);
            this.lvConnections.SmallImageList = this.SimpleImageList;
            this.lvConnections.TabIndex = 2;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LvConnections_AfterLabelEdit);
            this.lvConnections.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvConnections_BeforeLabelEdit);
            this.lvConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvConnectionsColumnClick);
            this.lvConnections.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConnections_DrawColumnHeader);
            this.lvConnections.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnections_DrawItem);
            this.lvConnections.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvConnections_DrawSubItem);
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            this.lvConnections.SizeChanged += new System.EventHandler(this.lvConnections_SizeChanged);
            this.lvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvConnections_KeyDown);
            this.lvConnections.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvConnectionsMouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 866;
            // 
            // chServer
            // 
            this.chServer.Text = "Server";
            this.chServer.Width = 120;
            // 
            // chOrganization
            // 
            this.chOrganization.Text = "Environment";
            this.chOrganization.Width = 80;
            // 
            // chUser
            // 
            this.chUser.Text = "User";
            this.chUser.Width = 150;
            // 
            // chVersion
            // 
            this.chVersion.Text = "Version";
            this.chVersion.Width = 90;
            // 
            // chLastUsedOn
            // 
            this.chLastUsedOn.Text = "Last used on";
            this.chLastUsedOn.Width = 150;
            // 
            // SimpleImageList
            // 
            this.SimpleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.SimpleImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.SimpleImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menu
            // 
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewConnection,
            this.tsbUpdateConnection,
            this.tsbCloneConnection,
            this.tsbDeleteConnection,
            this.tsSeparator1,
            this.tsbUpdatePassword,
            this.tsSeparator2,
            this.tsbShowConnectionString,
            this.tsbSetHighlight,
            this.tsbSetProfile,
            this.tsbConnectionProperties,
            this.tsSeparator3,
            this.tsb_UseMru,
            this.tsSeparator4,
            this.tsbMoveToNewFile,
            this.tsbMoveToExistingFile,
            this.tsSeparator5,
            this.tstSearch});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1080, 41);
            this.menu.TabIndex = 1;
            this.menu.Text = "tsMain";
            // 
            // tsbNewConnection
            // 
            this.tsbNewConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Create;
            this.tsbNewConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewConnection.Name = "tsbNewConnection";
            this.tsbNewConnection.Size = new System.Drawing.Size(175, 36);
            this.tsbNewConnection.Text = "New connection";
            this.tsbNewConnection.Click += new System.EventHandler(this.tsbNewConnection_Click);
            // 
            // tsbUpdateConnection
            // 
            this.tsbUpdateConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdateConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.edit;
            this.tsbUpdateConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateConnection.Name = "tsbUpdateConnection";
            this.tsbUpdateConnection.Size = new System.Drawing.Size(36, 36);
            this.tsbUpdateConnection.Text = "Update connection";
            this.tsbUpdateConnection.Click += new System.EventHandler(this.tsbUpdateConnection_Click);
            // 
            // tsbCloneConnection
            // 
            this.tsbCloneConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloneConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.copy;
            this.tsbCloneConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloneConnection.Name = "tsbCloneConnection";
            this.tsbCloneConnection.Size = new System.Drawing.Size(36, 36);
            this.tsbCloneConnection.Text = "Clone connection";
            this.tsbCloneConnection.Click += new System.EventHandler(this.tsbCloneConnection_Click);
            // 
            // tsbDeleteConnection
            // 
            this.tsbDeleteConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.delete;
            this.tsbDeleteConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteConnection.Name = "tsbDeleteConnection";
            this.tsbDeleteConnection.Size = new System.Drawing.Size(36, 36);
            this.tsbDeleteConnection.Text = "Delete connection";
            this.tsbDeleteConnection.Click += new System.EventHandler(this.tsbDeleteConnection_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbUpdatePassword
            // 
            this.tsbUpdatePassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdatePassword.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.key;
            this.tsbUpdatePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdatePassword.Name = "tsbUpdatePassword";
            this.tsbUpdatePassword.Size = new System.Drawing.Size(36, 36);
            this.tsbUpdatePassword.Text = "Update password";
            this.tsbUpdatePassword.ToolTipText = "Update password for selected connection(s)";
            this.tsbUpdatePassword.Click += new System.EventHandler(this.tsbUpdatePassword_Click);
            // 
            // tsSeparator2
            // 
            this.tsSeparator2.Name = "tsSeparator2";
            this.tsSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbShowConnectionString
            // 
            this.tsbShowConnectionString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowConnectionString.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources._string;
            this.tsbShowConnectionString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowConnectionString.Name = "tsbShowConnectionString";
            this.tsbShowConnectionString.Size = new System.Drawing.Size(36, 36);
            this.tsbShowConnectionString.Text = "Show connection string";
            this.tsbShowConnectionString.ToolTipText = "Show connection string for this connection";
            this.tsbShowConnectionString.Click += new System.EventHandler(this.tsbShowConnectionString_Click);
            // 
            // tsbSetHighlight
            // 
            this.tsbSetHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetHighlight.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Theme32;
            this.tsbSetHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetHighlight.Name = "tsbSetHighlight";
            this.tsbSetHighlight.Size = new System.Drawing.Size(36, 36);
            this.tsbSetHighlight.Text = "Set highlight info";
            this.tsbSetHighlight.Click += new System.EventHandler(this.tsbSetHighlight_Click);
            // 
            // tsbSetProfile
            // 
            this.tsbSetProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetProfile.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.earth;
            this.tsbSetProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetProfile.Name = "tsbSetProfile";
            this.tsbSetProfile.Size = new System.Drawing.Size(36, 36);
            this.tsbSetProfile.Text = "Set Browser profile";
            this.tsbSetProfile.Click += new System.EventHandler(this.tsbSetProfile_Click);
            // 
            // tsbConnectionProperties
            // 
            this.tsbConnectionProperties.CheckOnClick = true;
            this.tsbConnectionProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConnectionProperties.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Properties32;
            this.tsbConnectionProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnectionProperties.Name = "tsbConnectionProperties";
            this.tsbConnectionProperties.Size = new System.Drawing.Size(36, 36);
            this.tsbConnectionProperties.Text = "Properties";
            this.tsbConnectionProperties.ToolTipText = "See properties of the selected connection";
            this.tsbConnectionProperties.Click += new System.EventHandler(this.tsbConnectionProperties_Click);
            // 
            // tsSeparator3
            // 
            this.tsSeparator3.Name = "tsSeparator3";
            this.tsSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // tsb_UseMru
            // 
            this.tsb_UseMru.CheckOnClick = true;
            this.tsb_UseMru.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_UseMru.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.history;
            this.tsb_UseMru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UseMru.Name = "tsb_UseMru";
            this.tsb_UseMru.Size = new System.Drawing.Size(36, 36);
            this.tsb_UseMru.Text = "Display MRU first";
            this.tsb_UseMru.ToolTipText = "Display Most Recently Used connections first";
            // 
            // tsSeparator4
            // 
            this.tsSeparator4.Name = "tsSeparator4";
            this.tsSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbMoveToNewFile
            // 
            this.tsbMoveToNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToNewFile.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.add_folder;
            this.tsbMoveToNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToNewFile.Name = "tsbMoveToNewFile";
            this.tsbMoveToNewFile.Size = new System.Drawing.Size(36, 36);
            this.tsbMoveToNewFile.Text = "Move selected connections to a new file";
            this.tsbMoveToNewFile.Click += new System.EventHandler(this.tsbMoveToNewFile_Click);
            // 
            // tsbMoveToExistingFile
            // 
            this.tsbMoveToExistingFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToExistingFile.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.open_folder;
            this.tsbMoveToExistingFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToExistingFile.Name = "tsbMoveToExistingFile";
            this.tsbMoveToExistingFile.Size = new System.Drawing.Size(50, 36);
            this.tsbMoveToExistingFile.Text = "Move selected connections to existing file";
            this.tsbMoveToExistingFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbMoveToExistingFile_DropDownItemClicked);
            // 
            // tsSeparator5
            // 
            this.tsSeparator5.Name = "tsSeparator5";
            this.tsSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // tstSearch
            // 
            this.tstSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tstSearch.Name = "tstSearch";
            this.tstSearch.Size = new System.Drawing.Size(180, 41);
            this.tstSearch.Text = "Search";
            this.tstSearch.Enter += new System.EventHandler(this.tstSearch_Enter);
            this.tstSearch.Leave += new System.EventHandler(this.tstSearch_Leave);
            this.tstSearch.TextChanged += new System.EventHandler(this.tstSearch_TextChanged);
            // 
            // tsbRenameFile
            // 
            this.tsbRenameFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRenameFile.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.edit;
            this.tsbRenameFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRenameFile.Name = "tsbRenameFile";
            this.tsbRenameFile.Size = new System.Drawing.Size(36, 36);
            this.tsbRenameFile.Text = "Change the name of the current connection file";
            this.tsbRenameFile.Click += new System.EventHandler(this.tsbRenameFile_Click);
            // 
            // tsbRemoveConnectionList
            // 
            this.tsbRemoveConnectionList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveConnectionList.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.delete;
            this.tsbRemoveConnectionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveConnectionList.Name = "tsbRemoveConnectionList";
            this.tsbRemoveConnectionList.Size = new System.Drawing.Size(36, 36);
            this.tsbRemoveConnectionList.Text = "Remove selected connection list";
            this.tsbRemoveConnectionList.Click += new System.EventHandler(this.tsbRemoveConnectionList_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.bValidate);
            this.pnlFooter.Controls.Add(this.btnDetailsView);
            this.pnlFooter.Controls.Add(this.bCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 727);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFooter.Size = new System.Drawing.Size(1433, 73);
            this.pnlFooter.TabIndex = 5;
            // 
            // bValidate
            // 
            this.bValidate.Dock = System.Windows.Forms.DockStyle.Right;
            this.bValidate.Location = new System.Drawing.Point(1198, 10);
            this.bValidate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(111, 53);
            this.bValidate.TabIndex = 7;
            this.bValidate.Text = "OK";
            this.bValidate.UseVisualStyleBackColor = true;
            this.bValidate.Click += new System.EventHandler(this.BValidateClick);
            // 
            // btnDetailsView
            // 
            this.btnDetailsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailsView.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Details32;
            this.btnDetailsView.Location = new System.Drawing.Point(10, 10);
            this.btnDetailsView.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnDetailsView.Name = "btnDetailsView";
            this.btnDetailsView.Size = new System.Drawing.Size(81, 53);
            this.btnDetailsView.TabIndex = 6;
            this.btnDetailsView.UseVisualStyleBackColor = true;
            this.btnDetailsView.Click += new System.EventHandler(this.btnDetailsView_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.scMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlMain.Size = new System.Drawing.Size(1433, 727);
            this.pnlMain.TabIndex = 6;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(7, 6);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lvConnectionFiles);
            this.scMain.Panel1.Controls.Add(this.tsFiles);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scConnections);
            this.scMain.Panel2.Controls.Add(this.menu);
            this.scMain.Size = new System.Drawing.Size(1419, 715);
            this.scMain.SplitterDistance = 335;
            this.scMain.TabIndex = 3;
            // 
            // lvConnectionFiles
            // 
            this.lvConnectionFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvConnectionFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnectionFiles.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvConnectionFiles.HideSelection = false;
            this.lvConnectionFiles.Location = new System.Drawing.Point(0, 41);
            this.lvConnectionFiles.MultiSelect = false;
            this.lvConnectionFiles.Name = "lvConnectionFiles";
            this.lvConnectionFiles.OwnerDraw = true;
            this.lvConnectionFiles.Size = new System.Drawing.Size(335, 674);
            this.lvConnectionFiles.SmallImageList = this.SimpleImageList;
            this.lvConnectionFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvConnectionFiles.StateImageList = this.SimpleImageList;
            this.lvConnectionFiles.TabIndex = 2;
            this.lvConnectionFiles.UseCompatibleStateImageBehavior = false;
            this.lvConnectionFiles.View = System.Windows.Forms.View.Details;
            this.lvConnectionFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvConnectionsColumnClick);
            this.lvConnectionFiles.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConnectionFiles_DrawColumnHeader);
            this.lvConnectionFiles.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnectionFiles_DrawItem);
            this.lvConnectionFiles.SelectedIndexChanged += new System.EventHandler(this.lvConnectionFiles_SelectedIndexChanged);
            this.lvConnectionFiles.Resize += new System.EventHandler(this.listview_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 200;
            // 
            // tsFiles
            // 
            this.tsFiles.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateConnectionFile,
            this.tsbRenameFile,
            this.tsbRemoveConnectionList,
            this.tsbAddExisting});
            this.tsFiles.Location = new System.Drawing.Point(0, 0);
            this.tsFiles.Name = "tsFiles";
            this.tsFiles.Size = new System.Drawing.Size(335, 41);
            this.tsFiles.TabIndex = 1;
            this.tsFiles.Text = "tsFiles";
            // 
            // tsbCreateConnectionFile
            // 
            this.tsbCreateConnectionFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateConnectionFile.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.Create;
            this.tsbCreateConnectionFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateConnectionFile.Name = "tsbCreateConnectionFile";
            this.tsbCreateConnectionFile.Size = new System.Drawing.Size(36, 36);
            this.tsbCreateConnectionFile.Text = "Create a new Connections File";
            this.tsbCreateConnectionFile.Click += new System.EventHandler(this.tsbCreateConnectionFile_Click);
            // 
            // tsbAddExisting
            // 
            this.tsbAddExisting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddExisting.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.plus;
            this.tsbAddExisting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddExisting.Name = "tsbAddExisting";
            this.tsbAddExisting.Size = new System.Drawing.Size(36, 36);
            this.tsbAddExisting.Text = "Add an existing Connections File";
            this.tsbAddExisting.Click += new System.EventHandler(this.tsbAddExisting_Click);
            // 
            // scConnections
            // 
            this.scConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scConnections.Location = new System.Drawing.Point(0, 41);
            this.scConnections.Name = "scConnections";
            // 
            // scConnections.Panel1
            // 
            this.scConnections.Panel1.Controls.Add(this.txtSimpleRename);
            this.scConnections.Panel1.Controls.Add(this.noConnectionControl1);
            this.scConnections.Panel1.Controls.Add(this.lvConnections);
            // 
            // scConnections.Panel2
            // 
            this.scConnections.Panel2.Controls.Add(this.pgConnection);
            this.scConnections.Panel2Collapsed = true;
            this.scConnections.Size = new System.Drawing.Size(1080, 674);
            this.scConnections.SplitterDistance = 821;
            this.scConnections.TabIndex = 0;
            // 
            // txtSimpleRename
            // 
            this.txtSimpleRename.Location = new System.Drawing.Point(241, 87);
            this.txtSimpleRename.Name = "txtSimpleRename";
            this.txtSimpleRename.Size = new System.Drawing.Size(100, 26);
            this.txtSimpleRename.TabIndex = 4;
            this.txtSimpleRename.Visible = false;
            this.txtSimpleRename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSimpleRename_KeyDown);
            this.txtSimpleRename.Leave += new System.EventHandler(this.txtSimpleRename_Leave);
            // 
            // noConnectionControl1
            // 
            this.noConnectionControl1.ActionLabel = null;
            this.noConnectionControl1.BackColor = System.Drawing.Color.White;
            this.noConnectionControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noConnectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noConnectionControl1.Location = new System.Drawing.Point(0, 0);
            this.noConnectionControl1.Name = "noConnectionControl1";
            this.noConnectionControl1.Size = new System.Drawing.Size(1080, 674);
            this.noConnectionControl1.TabIndex = 3;
            this.noConnectionControl1.Visible = false;
            // 
            // pgConnection
            // 
            this.pgConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgConnection.HelpVisible = false;
            this.pgConnection.Location = new System.Drawing.Point(0, 0);
            this.pgConnection.Name = "pgConnection";
            this.pgConnection.Size = new System.Drawing.Size(96, 100);
            this.pgConnection.TabIndex = 0;
            this.pgConnection.ToolbarVisible = false;
            // 
            // detailImageList
            // 
            this.detailImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("detailImageList.ImageStream")));
            this.detailImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.detailImageList.Images.SetKeyName(0, "CRMOnlineLive_16.png");
            this.detailImageList.Images.SetKeyName(1, "server.png");
            this.detailImageList.Images.SetKeyName(2, "Dataverse_16x16.png");
            // 
            // ConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(1433, 800);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConnectionSelector";
            this.ShowIcon = false;
            this.Text = "Connection Manager";
            this.Load += new System.EventHandler(this.ConnectionSelector_Load);
            this.ResizeEnd += new System.EventHandler(this.ConnectionSelector_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSelector_KeyDown);
            this.Resize += new System.EventHandler(this.ConnectionSelector_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tsFiles.ResumeLayout(false);
            this.tsFiles.PerformLayout();
            this.scConnections.Panel1.ResumeLayout(false);
            this.scConnections.Panel1.PerformLayout();
            this.scConnections.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scConnections)).EndInit();
            this.scConnections.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     

        #endregion
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chOrganization;
        private System.Windows.Forms.ColumnHeader chServer;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton tsbNewConnection;
        private System.Windows.Forms.ToolStripButton tsbUpdateConnection;
        private System.Windows.Forms.ToolStripButton tsbCloneConnection;
        private System.Windows.Forms.ToolStripButton tsbDeleteConnection;
        private System.Windows.Forms.ToolStripSeparator tsSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_UseMru;
        private System.Windows.Forms.ToolStripSeparator tsSeparator4;
        private System.Windows.Forms.ToolStripButton tsbRemoveConnectionList;
        private System.Windows.Forms.ToolStripButton tsbMoveToNewFile;
        private System.Windows.Forms.ToolStripDropDownButton tsbMoveToExistingFile;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripButton tsbUpdatePassword;
        private System.Windows.Forms.ToolStripSeparator tsSeparator2;
        private System.Windows.Forms.ToolStripButton tsbShowConnectionString;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ColumnHeader chUser;
        private System.Windows.Forms.ToolStripButton tsbRenameFile;
        private System.Windows.Forms.ColumnHeader chLastUsedOn;
        private System.Windows.Forms.ToolStripTextBox tstSearch;
        private System.Windows.Forms.ToolStripSeparator tsSeparator5;
        private System.Windows.Forms.ToolStripButton tsbSetProfile;
        private System.Windows.Forms.ImageList SimpleImageList;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scConnections;
        private System.Windows.Forms.ListView lvConnectionFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip tsFiles;
        private System.Windows.Forms.ToolStripButton tsbCreateConnectionFile;
        private System.Windows.Forms.ToolStripButton tsbAddExisting;
        private System.Windows.Forms.ImageList detailImageList;
        private System.Windows.Forms.PropertyGrid pgConnection;
        private System.Windows.Forms.ToolStripButton tsbConnectionProperties;
        private UserControls.NoConnectionControl noConnectionControl1;
        private System.Windows.Forms.TextBox txtSimpleRename;
        private System.Windows.Forms.ToolStripButton tsbSetHighlight;
        private System.Windows.Forms.Button btnDetailsView;
        private System.Windows.Forms.Button bValidate;
    }
}