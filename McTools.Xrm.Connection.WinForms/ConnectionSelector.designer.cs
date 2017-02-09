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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSelector));
            this.bValidate = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.tsbNewConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbCloneConnection = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdatePassword = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_UseMru = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscbbConnectionsFile = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRemoveConnectionList = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToExistingFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bValidate.Location = new System.Drawing.Point(726, 577);
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
            this.bCancel.Location = new System.Drawing.Point(848, 577);
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
            this.lvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4});
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.GridLines = true;
            this.lvConnections.LabelEdit = true;
            this.lvConnections.Location = new System.Drawing.Point(18, 43);
            this.lvConnections.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(940, 522);
            this.lvConnections.TabIndex = 2;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvConnectionsColumnClick);
            this.lvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvConnections_KeyDown);
            this.lvConnections.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvConnectionsMouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Server";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Organization";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            this.columnHeader4.Width = 100;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewConnection,
            this.tsbUpdateConnection,
            this.tsbCloneConnection,
            this.tsbDeleteConnection,
            this.toolStripSeparator3,
            this.tsbUpdatePassword,
            this.toolStripSeparator1,
            this.tsb_UseMru,
            this.toolStripSeparator2,
            this.tscbbConnectionsFile,
            this.tsbRemoveConnectionList,
            this.tsbMoveToNewFile,
            this.tsbMoveToExistingFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.menu.Size = new System.Drawing.Size(978, 33);
            this.menu.TabIndex = 1;
            this.menu.Text = "toolStrip1";
            // 
            // tsbNewConnection
            // 
            this.tsbNewConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewConnection.Image")));
            this.tsbNewConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewConnection.Name = "tsbNewConnection";
            this.tsbNewConnection.Size = new System.Drawing.Size(167, 30);
            this.tsbNewConnection.Text = "New connection";
            this.tsbNewConnection.Click += new System.EventHandler(this.tsbNewConnection_Click);
            // 
            // tsbUpdateConnection
            // 
            this.tsbUpdateConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdateConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateConnection.Image")));
            this.tsbUpdateConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateConnection.Name = "tsbUpdateConnection";
            this.tsbUpdateConnection.Size = new System.Drawing.Size(28, 30);
            this.tsbUpdateConnection.Text = "Update connection";
            this.tsbUpdateConnection.Click += new System.EventHandler(this.tsbUpdateConnection_Click);
            // 
            // tsbCloneConnection
            // 
            this.tsbCloneConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloneConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloneConnection.Image")));
            this.tsbCloneConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloneConnection.Name = "tsbCloneConnection";
            this.tsbCloneConnection.Size = new System.Drawing.Size(28, 30);
            this.tsbCloneConnection.Text = "Clone connection";
            this.tsbCloneConnection.Click += new System.EventHandler(this.tsbCloneConnection_Click);
            // 
            // tsbDeleteConnection
            // 
            this.tsbDeleteConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteConnection.Image")));
            this.tsbDeleteConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteConnection.Name = "tsbDeleteConnection";
            this.tsbDeleteConnection.Size = new System.Drawing.Size(28, 30);
            this.tsbDeleteConnection.Text = "Delete connection";
            this.tsbDeleteConnection.Click += new System.EventHandler(this.tsbDeleteConnection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbUpdatePassword
            // 
            this.tsbUpdatePassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdatePassword.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdatePassword.Image")));
            this.tsbUpdatePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdatePassword.Name = "tsbUpdatePassword";
            this.tsbUpdatePassword.Size = new System.Drawing.Size(28, 30);
            this.tsbUpdatePassword.Text = "Update password";
            this.tsbUpdatePassword.ToolTipText = "Update password for selected connection(s)";
            this.tsbUpdatePassword.Click += new System.EventHandler(this.tsbUpdatePassword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // tsb_UseMru
            // 
            this.tsb_UseMru.CheckOnClick = true;
            this.tsb_UseMru.Image = ((System.Drawing.Image)(resources.GetObject("tsb_UseMru.Image")));
            this.tsb_UseMru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UseMru.Name = "tsb_UseMru";
            this.tsb_UseMru.Size = new System.Drawing.Size(177, 30);
            this.tsb_UseMru.Text = "Display MRU first";
            this.tsb_UseMru.ToolTipText = "Display Most Recently Used connections first";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tscbbConnectionsFile
            // 
            this.tscbbConnectionsFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbbConnectionsFile.Name = "tscbbConnectionsFile";
            this.tscbbConnectionsFile.Size = new System.Drawing.Size(280, 33);
            this.tscbbConnectionsFile.SelectedIndexChanged += new System.EventHandler(this.tscbbConnectionsFile_SelectedIndexChanged);
            // 
            // tsbRemoveConnectionList
            // 
            this.tsbRemoveConnectionList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveConnectionList.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveConnectionList.Image")));
            this.tsbRemoveConnectionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveConnectionList.Name = "tsbRemoveConnectionList";
            this.tsbRemoveConnectionList.Size = new System.Drawing.Size(28, 30);
            this.tsbRemoveConnectionList.Text = "Remove selected connection list";
            this.tsbRemoveConnectionList.Click += new System.EventHandler(this.tsbRemoveConnectionList_Click);
            // 
            // tsbMoveToNewFile
            // 
            this.tsbMoveToNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoveToNewFile.Image")));
            this.tsbMoveToNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToNewFile.Name = "tsbMoveToNewFile";
            this.tsbMoveToNewFile.Size = new System.Drawing.Size(28, 30);
            this.tsbMoveToNewFile.Text = "Move selected connections to a new file";
            this.tsbMoveToNewFile.Click += new System.EventHandler(this.tsbMoveToNewFile_Click);
            // 
            // tsbMoveToExistingFile
            // 
            this.tsbMoveToExistingFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToExistingFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoveToExistingFile.Image")));
            this.tsbMoveToExistingFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToExistingFile.Name = "tsbMoveToExistingFile";
            this.tsbMoveToExistingFile.Size = new System.Drawing.Size(42, 30);
            this.tsbMoveToExistingFile.Text = "Move selected connections to existing file";
            this.tsbMoveToExistingFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbMoveToExistingFile_DropDownItemClicked);
            // 
            // ConnectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(978, 631);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.bValidate);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.lvConnections);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConnectionSelector";
            this.ShowIcon = false;
            this.Text = "Connection Manager";
            this.Load += new System.EventHandler(this.ConnectionSelector_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSelector_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        #endregion

        private System.Windows.Forms.Button bValidate;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
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
    }
}