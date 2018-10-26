﻿namespace McTools.Xrm.Connection.WinForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSelector));
            this.bValidate = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrganization = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.tsbNewConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbCloneConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdatePassword = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowConnectionString = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_UseMru = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscbbConnectionsFile = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRemoveConnectionList = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToExistingFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.bClearFilter = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bValidate.Location = new System.Drawing.Point(488, 3);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(75, 23);
            this.bValidate.TabIndex = 3;
            this.bValidate.Text = "OK";
            this.bValidate.UseVisualStyleBackColor = true;
            this.bValidate.Click += new System.EventHandler(this.BValidateClick);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(569, 3);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
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
            this.chVersion});
            this.lvConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.GridLines = true;
            this.lvConnections.LabelEdit = true;
            this.lvConnections.Location = new System.Drawing.Point(4, 4);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(644, 344);
            this.lvConnections.TabIndex = 2;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LvConnections_AfterLabelEdit);
            this.lvConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvConnectionsColumnClick);
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            this.lvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvConnections_KeyDown);
            this.lvConnections.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvConnectionsMouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 180;
            // 
            // chServer
            // 
            this.chServer.Text = "Server";
            this.chServer.Width = 120;
            // 
            // chOrganization
            // 
            this.chOrganization.Text = "Organization";
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
            // menu
            // 
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewConnection,
            this.tsbUpdateConnection,
            this.tsbCloneConnection,
            this.tsbDeleteConnection,
            this.toolStripSeparator3,
            this.tsbUpdatePassword,
            this.toolStripSeparator4,
            this.tsbShowConnectionString,
            this.toolStripSeparator1,
            this.tsb_UseMru,
            this.toolStripSeparator2,
            this.tscbbConnectionsFile,
            this.tsbRemoveConnectionList,
            this.tsbMoveToNewFile,
            this.tsbMoveToExistingFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(652, 25);
            this.menu.TabIndex = 1;
            this.menu.Text = "toolStrip1";
            // 
            // tsbNewConnection
            // 
            this.tsbNewConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewConnection.Image")));
            this.tsbNewConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewConnection.Name = "tsbNewConnection";
            this.tsbNewConnection.Size = new System.Drawing.Size(114, 22);
            this.tsbNewConnection.Text = "New connection";
            this.tsbNewConnection.Click += new System.EventHandler(this.tsbNewConnection_Click);
            // 
            // tsbUpdateConnection
            // 
            this.tsbUpdateConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdateConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateConnection.Image")));
            this.tsbUpdateConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateConnection.Name = "tsbUpdateConnection";
            this.tsbUpdateConnection.Size = new System.Drawing.Size(23, 22);
            this.tsbUpdateConnection.Text = "Update connection";
            this.tsbUpdateConnection.Click += new System.EventHandler(this.tsbUpdateConnection_Click);
            // 
            // tsbCloneConnection
            // 
            this.tsbCloneConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloneConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloneConnection.Image")));
            this.tsbCloneConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloneConnection.Name = "tsbCloneConnection";
            this.tsbCloneConnection.Size = new System.Drawing.Size(23, 22);
            this.tsbCloneConnection.Text = "Clone connection";
            this.tsbCloneConnection.Click += new System.EventHandler(this.tsbCloneConnection_Click);
            // 
            // tsbDeleteConnection
            // 
            this.tsbDeleteConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteConnection.Image")));
            this.tsbDeleteConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteConnection.Name = "tsbDeleteConnection";
            this.tsbDeleteConnection.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteConnection.Text = "Delete connection";
            this.tsbDeleteConnection.Click += new System.EventHandler(this.tsbDeleteConnection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUpdatePassword
            // 
            this.tsbUpdatePassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdatePassword.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdatePassword.Image")));
            this.tsbUpdatePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdatePassword.Name = "tsbUpdatePassword";
            this.tsbUpdatePassword.Size = new System.Drawing.Size(23, 22);
            this.tsbUpdatePassword.Text = "Update password";
            this.tsbUpdatePassword.ToolTipText = "Update password for selected connection(s)";
            this.tsbUpdatePassword.Click += new System.EventHandler(this.tsbUpdatePassword_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbShowConnectionString
            // 
            this.tsbShowConnectionString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowConnectionString.Image = global::McTools.Xrm.Connection.WinForms.Properties.Resources.database_link;
            this.tsbShowConnectionString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowConnectionString.Name = "tsbShowConnectionString";
            this.tsbShowConnectionString.Size = new System.Drawing.Size(23, 22);
            this.tsbShowConnectionString.Text = "Show connection string";
            this.tsbShowConnectionString.ToolTipText = "Show connection string for this connection";
            this.tsbShowConnectionString.Click += new System.EventHandler(this.tsbShowConnectionString_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_UseMru
            // 
            this.tsb_UseMru.CheckOnClick = true;
            this.tsb_UseMru.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_UseMru.Image = ((System.Drawing.Image)(resources.GetObject("tsb_UseMru.Image")));
            this.tsb_UseMru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UseMru.Name = "tsb_UseMru";
            this.tsb_UseMru.Size = new System.Drawing.Size(23, 22);
            this.tsb_UseMru.Text = "Display MRU first";
            this.tsb_UseMru.ToolTipText = "Display Most Recently Used connections first";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tscbbConnectionsFile
            // 
            this.tscbbConnectionsFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbbConnectionsFile.Name = "tscbbConnectionsFile";
            this.tscbbConnectionsFile.Size = new System.Drawing.Size(188, 25);
            this.tscbbConnectionsFile.SelectedIndexChanged += new System.EventHandler(this.tscbbConnectionsFile_SelectedIndexChanged);
            // 
            // tsbRemoveConnectionList
            // 
            this.tsbRemoveConnectionList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveConnectionList.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveConnectionList.Image")));
            this.tsbRemoveConnectionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveConnectionList.Name = "tsbRemoveConnectionList";
            this.tsbRemoveConnectionList.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveConnectionList.Text = "Remove selected connection list";
            this.tsbRemoveConnectionList.Click += new System.EventHandler(this.tsbRemoveConnectionList_Click);
            // 
            // tsbMoveToNewFile
            // 
            this.tsbMoveToNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoveToNewFile.Image")));
            this.tsbMoveToNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToNewFile.Name = "tsbMoveToNewFile";
            this.tsbMoveToNewFile.Size = new System.Drawing.Size(23, 22);
            this.tsbMoveToNewFile.Text = "Move selected connections to a new file";
            this.tsbMoveToNewFile.Visible = false;
            this.tsbMoveToNewFile.Click += new System.EventHandler(this.tsbMoveToNewFile_Click);
            // 
            // tsbMoveToExistingFile
            // 
            this.tsbMoveToExistingFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToExistingFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoveToExistingFile.Image")));
            this.tsbMoveToExistingFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToExistingFile.Name = "tsbMoveToExistingFile";
            this.tsbMoveToExistingFile.Size = new System.Drawing.Size(29, 22);
            this.tsbMoveToExistingFile.Text = "Move selected connections to existing file";
            this.tsbMoveToExistingFile.Visible = false;
            this.tsbMoveToExistingFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbMoveToExistingFile_DropDownItemClicked);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.bClearFilter);
            this.pnlFooter.Controls.Add(this.lbFilter);
            this.pnlFooter.Controls.Add(this.tbFilter);
            this.pnlFooter.Controls.Add(this.bCancel);
            this.pnlFooter.Controls.Add(this.bValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 377);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(652, 33);
            this.pnlFooter.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lvConnections);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Size = new System.Drawing.Size(652, 352);
            this.pnlMain.TabIndex = 6;
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(41, 5);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(309, 20);
            this.tbFilter.TabIndex = 5;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(3, 8);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(32, 13);
            this.lbFilter.TabIndex = 6;
            this.lbFilter.Text = "Filter:";
            // 
            // bClearFilter
            // 
            this.bClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClearFilter.Location = new System.Drawing.Point(349, 4);
            this.bClearFilter.Name = "bClearFilter";
            this.bClearFilter.Size = new System.Drawing.Size(22, 22);
            this.bClearFilter.TabIndex = 7;
            this.bClearFilter.Text = "X";
            this.bClearFilter.UseVisualStyleBackColor = true;
            this.bClearFilter.Click += new System.EventHandler(this.bClearFilter_Click);
            // 
            // ConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(652, 410);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.menu);
            this.Name = "ConnectionSelector";
            this.ShowIcon = false;
            this.Text = "Connection Manager";
            this.Load += new System.EventHandler(this.ConnectionSelector_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSelector_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_UseMru;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tscbbConnectionsFile;
        private System.Windows.Forms.ToolStripButton tsbRemoveConnectionList;
        private System.Windows.Forms.ToolStripButton tsbMoveToNewFile;
        private System.Windows.Forms.ToolStripDropDownButton tsbMoveToExistingFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbUpdatePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbShowConnectionString;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ColumnHeader chUser;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.Button bClearFilter;
    }
}