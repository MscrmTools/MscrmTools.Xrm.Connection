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
            this.bValidate = new System.Windows.Forms.Button();
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
            this.pnlDisplayMode = new System.Windows.Forms.Panel();
            this.rbDisplayModeSimple = new System.Windows.Forms.RadioButton();
            this.rbDisplayModeDetails = new System.Windows.Forms.RadioButton();
            this.lblDisplayMode = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lvConnectionFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCreateConnectionFile = new System.Windows.Forms.ToolStripButton();
            this.tsbAddExisting = new System.Windows.Forms.ToolStripButton();
            this.scConnections = new System.Windows.Forms.SplitContainer();
            this.pnlNoConnection = new System.Windows.Forms.Panel();
            this.llCreateNewConnection = new System.Windows.Forms.LinkLabel();
            this.lblNoConnectionFound = new System.Windows.Forms.Label();
            this.pbNoConnection = new System.Windows.Forms.PictureBox();
            this.pgConnection = new System.Windows.Forms.PropertyGrid();
            this.detailImageList = new System.Windows.Forms.ImageList(this.components);
            this.menu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlDisplayMode.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConnections)).BeginInit();
            this.scConnections.Panel1.SuspendLayout();
            this.scConnections.Panel2.SuspendLayout();
            this.scConnections.SuspendLayout();
            this.pnlNoConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).BeginInit();
            this.SuspendLayout();
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bValidate.Location = new System.Drawing.Point(1130, 7);
            this.bValidate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(112, 35);
            this.bValidate.TabIndex = 3;
            this.bValidate.Text = "OK";
            this.bValidate.UseVisualStyleBackColor = true;
            this.bValidate.Click += new System.EventHandler(this.BValidateClick);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(1252, 7);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(112, 35);
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
            this.lvConnections.Size = new System.Drawing.Size(1035, 526);
            this.lvConnections.SmallImageList = this.SimpleImageList;
            this.lvConnections.TabIndex = 2;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LvConnections_AfterLabelEdit);
            this.lvConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvConnectionsColumnClick);
            this.lvConnections.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConnections_DrawColumnHeader);
            this.lvConnections.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnections_DrawItem);
            this.lvConnections.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvConnections_DrawSubItem);
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            this.lvConnections.SizeChanged += new System.EventHandler(this.lvConnections_SizeChanged);
            this.lvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvConnections_KeyDown);
            this.lvConnections.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
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
            this.menu.Size = new System.Drawing.Size(1035, 41);
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
            this.pnlFooter.Controls.Add(this.pnlDisplayMode);
            this.pnlFooter.Controls.Add(this.bCancel);
            this.pnlFooter.Controls.Add(this.bValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 579);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1376, 52);
            this.pnlFooter.TabIndex = 5;
            // 
            // pnlDisplayMode
            // 
            this.pnlDisplayMode.Controls.Add(this.rbDisplayModeSimple);
            this.pnlDisplayMode.Controls.Add(this.rbDisplayModeDetails);
            this.pnlDisplayMode.Controls.Add(this.lblDisplayMode);
            this.pnlDisplayMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDisplayMode.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplayMode.Name = "pnlDisplayMode";
            this.pnlDisplayMode.Size = new System.Drawing.Size(502, 52);
            this.pnlDisplayMode.TabIndex = 5;
            // 
            // rbDisplayModeSimple
            // 
            this.rbDisplayModeSimple.Checked = true;
            this.rbDisplayModeSimple.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbDisplayModeSimple.Location = new System.Drawing.Point(235, 0);
            this.rbDisplayModeSimple.Name = "rbDisplayModeSimple";
            this.rbDisplayModeSimple.Size = new System.Drawing.Size(166, 52);
            this.rbDisplayModeSimple.TabIndex = 3;
            this.rbDisplayModeSimple.TabStop = true;
            this.rbDisplayModeSimple.Text = "Simple";
            this.rbDisplayModeSimple.UseVisualStyleBackColor = true;
            // 
            // rbDisplayModeDetails
            // 
            this.rbDisplayModeDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbDisplayModeDetails.Location = new System.Drawing.Point(121, 0);
            this.rbDisplayModeDetails.Name = "rbDisplayModeDetails";
            this.rbDisplayModeDetails.Size = new System.Drawing.Size(114, 52);
            this.rbDisplayModeDetails.TabIndex = 2;
            this.rbDisplayModeDetails.Text = "Details";
            this.rbDisplayModeDetails.UseVisualStyleBackColor = true;
            this.rbDisplayModeDetails.CheckedChanged += new System.EventHandler(this.rbDisplayModeDetails_CheckedChanged);
            // 
            // lblDisplayMode
            // 
            this.lblDisplayMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDisplayMode.Location = new System.Drawing.Point(0, 0);
            this.lblDisplayMode.Name = "lblDisplayMode";
            this.lblDisplayMode.Size = new System.Drawing.Size(121, 52);
            this.lblDisplayMode.TabIndex = 1;
            this.lblDisplayMode.Text = "Display mode : ";
            this.lblDisplayMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.scMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlMain.Size = new System.Drawing.Size(1376, 579);
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
            this.scMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scConnections);
            this.scMain.Panel2.Controls.Add(this.menu);
            this.scMain.Size = new System.Drawing.Size(1362, 567);
            this.scMain.SplitterDistance = 323;
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
            this.lvConnectionFiles.Name = "lvConnectionFiles";
            this.lvConnectionFiles.OwnerDraw = true;
            this.lvConnectionFiles.Size = new System.Drawing.Size(323, 526);
            this.lvConnectionFiles.SmallImageList = this.SimpleImageList;
            this.lvConnectionFiles.StateImageList = this.SimpleImageList;
            this.lvConnectionFiles.TabIndex = 2;
            this.lvConnectionFiles.UseCompatibleStateImageBehavior = false;
            this.lvConnectionFiles.View = System.Windows.Forms.View.Details;
            this.lvConnectionFiles.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConnectionFiles_DrawColumnHeader);
            this.lvConnectionFiles.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvConnectionFiles_DrawItem);
            this.lvConnectionFiles.SelectedIndexChanged += new System.EventHandler(this.lvConnectionFiles_SelectedIndexChanged);
            this.lvConnectionFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            this.lvConnectionFiles.Resize += new System.EventHandler(this.listview_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateConnectionFile,
            this.tsbRenameFile,
            this.tsbRemoveConnectionList,
            this.tsbAddExisting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(323, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            this.scConnections.Panel1.Controls.Add(this.pnlNoConnection);
            this.scConnections.Panel1.Controls.Add(this.lvConnections);
            // 
            // scConnections.Panel2
            // 
            this.scConnections.Panel2.Controls.Add(this.pgConnection);
            this.scConnections.Panel2Collapsed = true;
            this.scConnections.Size = new System.Drawing.Size(1035, 526);
            this.scConnections.SplitterDistance = 821;
            this.scConnections.TabIndex = 0;
            // 
            // pnlNoConnection
            // 
            this.pnlNoConnection.BackColor = System.Drawing.Color.White;
            this.pnlNoConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoConnection.Controls.Add(this.llCreateNewConnection);
            this.pnlNoConnection.Controls.Add(this.lblNoConnectionFound);
            this.pnlNoConnection.Controls.Add(this.pbNoConnection);
            this.pnlNoConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoConnection.Location = new System.Drawing.Point(0, 0);
            this.pnlNoConnection.Name = "pnlNoConnection";
            this.pnlNoConnection.Size = new System.Drawing.Size(1035, 526);
            this.pnlNoConnection.TabIndex = 3;
            this.pnlNoConnection.Visible = false;
            // 
            // llCreateNewConnection
            // 
            this.llCreateNewConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llCreateNewConnection.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCreateNewConnection.Location = new System.Drawing.Point(10, 418);
            this.llCreateNewConnection.Name = "llCreateNewConnection";
            this.llCreateNewConnection.Size = new System.Drawing.Size(1009, 35);
            this.llCreateNewConnection.TabIndex = 2;
            this.llCreateNewConnection.TabStop = true;
            this.llCreateNewConnection.Text = "Create a new connection";
            this.llCreateNewConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llCreateNewConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreateNewConnection_LinkClicked);
            // 
            // lblNoConnectionFound
            // 
            this.lblNoConnectionFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoConnectionFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoConnectionFound.Location = new System.Drawing.Point(2, 362);
            this.lblNoConnectionFound.Name = "lblNoConnectionFound";
            this.lblNoConnectionFound.Size = new System.Drawing.Size(1017, 56);
            this.lblNoConnectionFound.TabIndex = 1;
            this.lblNoConnectionFound.Text = "No connection found!";
            this.lblNoConnectionFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbNoConnection
            // 
            this.pbNoConnection.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.NoConnection512;
            this.pbNoConnection.Location = new System.Drawing.Point(386, 97);
            this.pbNoConnection.Name = "pbNoConnection";
            this.pbNoConnection.Size = new System.Drawing.Size(265, 262);
            this.pbNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoConnection.TabIndex = 0;
            this.pbNoConnection.TabStop = false;
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
            this.ClientSize = new System.Drawing.Size(1376, 631);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConnectionSelector";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Manager";
            this.Load += new System.EventHandler(this.ConnectionSelector_Load);
            this.ResizeEnd += new System.EventHandler(this.ConnectionSelector_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSelector_KeyDown);
            this.Resize += new System.EventHandler(this.ConnectionSelector_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlDisplayMode.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.scConnections.Panel1.ResumeLayout(false);
            this.scConnections.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scConnections)).EndInit();
            this.scConnections.ResumeLayout(false);
            this.pnlNoConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNoConnection)).EndInit();
            this.ResumeLayout(false);

        }

     

        #endregion

        private System.Windows.Forms.Button bValidate;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCreateConnectionFile;
        private System.Windows.Forms.ToolStripButton tsbAddExisting;
        private System.Windows.Forms.Panel pnlDisplayMode;
        private System.Windows.Forms.RadioButton rbDisplayModeSimple;
        private System.Windows.Forms.RadioButton rbDisplayModeDetails;
        private System.Windows.Forms.Label lblDisplayMode;
        private System.Windows.Forms.ImageList detailImageList;
        private System.Windows.Forms.PropertyGrid pgConnection;
        private System.Windows.Forms.ToolStripButton tsbConnectionProperties;
        private System.Windows.Forms.Panel pnlNoConnection;
        private System.Windows.Forms.PictureBox pbNoConnection;
        private System.Windows.Forms.LinkLabel llCreateNewConnection;
        private System.Windows.Forms.Label lblNoConnectionFound;
    }
}