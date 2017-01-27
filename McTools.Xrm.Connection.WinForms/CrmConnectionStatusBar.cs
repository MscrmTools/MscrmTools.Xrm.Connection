using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    /// <summary>
    /// StatusStrip child object allowing to list, create, upadate and connect
    /// to Crm server.
    /// </summary>
    public partial class CrmConnectionStatusBar : StatusStrip
    {
        #region Variables

        private readonly FormHelper _formHelper;

        private bool mergeConnectionFiles;

        /// <summary>
        /// Resources manager
        /// </summary>
        private readonly System.ComponentModel.ComponentResourceManager resources;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class CrmConnectionStatusBar
        /// </summary>
        public CrmConnectionStatusBar(FormHelper formHelper, bool mergeConnectionFiles = false)
        {
            this.mergeConnectionFiles = mergeConnectionFiles;
            resources = new System.ComponentModel.ComponentResourceManager(typeof(CrmConnectionStatusBar));

            ConnectionManager.Instance.ConnectionListUpdated += cManager_ConnectionListUpdated;
            _formHelper = formHelper;

            // Build connection control
            BuildConnectionControl();

            // Add label that will display information about connection
            ToolStripStatusLabel informationLabel = new ToolStripStatusLabel
            {
                Spring = true,
                TextAlign = ContentAlignment.MiddleRight
            };

            Items.Add(informationLabel);

            ToolStripProgressBar progress = new ToolStripProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Visible = false
            };
            Items.Add(progress);

            RenderMode = ToolStripRenderMode.Professional;
        }

        private void cManager_ConnectionListUpdated(object sender, EventArgs e)
        {
            RebuildConnectionList();
        }

        #endregion Constructor

        #region Properties

        public bool MergeConnectionsFiles
        {
            get { return mergeConnectionFiles; }
            set
            {
                if (value != mergeConnectionFiles)
                {
                    mergeConnectionFiles = value;
                    RebuildConnectionList();
                }
            }
        }

        #endregion Properties

        #region Methods

        public void RebuildConnectionList()
        {
            AddActionsList((ToolStripDropDownButton)Items[0]);
        }

        /// <summary>
        /// Updates the connection status displayed on the main ToolStripDropDownButton
        /// </summary>
        /// <param name="isConnected">Indicates if the status is 'Connected'</param>
        /// <param name="detail">Connection details</param>
        public void SetConnectionStatus(bool isConnected, ConnectionDetail detail)
        {
            ToolStripDropDownButton btn = (ToolStripDropDownButton)Items[0];

            if (isConnected)
            {
                SetMessage("Connected!");
                btn.Text = $"Connected to '{detail.ServerName} ({detail.OrganizationFriendlyName})'";
                btn.Image = (Image)resources.GetObject("server_lightning");
            }
            else
            {
                btn.Text = "Not connected";
                btn.Image = (Image)resources.GetObject("server");
            }
        }

        /// <summary>
        /// Displays a message about the connection
        /// </summary>
        /// <param name="message">Message to display</param>
        public void SetMessage(string message)
        {
            ToolStripStatusLabel label = (ToolStripStatusLabel)Items[1];

            MethodInvoker mi = delegate
            {
                label.Text = message;
            };

            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        public void SetProgress(int? percent)
        {
            ToolStripProgressBar progress = (ToolStripProgressBar)Items[2];

            MethodInvoker mi = delegate
            {
                if (percent.HasValue)
                {
                    progress.Value = percent.Value;
                    progress.Visible = true;
                }
                else
                {
                    progress.Value = 0;
                    progress.Visible = false;
                }
            };

            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        /// <summary>
        /// Adds the ToolStripMenuItems representing connections to the
        /// ToolStripDropDownButton
        /// </summary>
        /// <param name="btn">ToolStripDropDownButton where to add connections</param>
        private void AddActionsList(ToolStripDropDownButton btn)
        {
            var list = new List<ToolStripItem>();
            int filesCount = ConnectionsList.Instance.Files.Count;

            if (filesCount == 0)
            {
                var defaultFilePath = Path.Combine(new FileInfo(ConnectionsList.ConnectionsListFilePath).DirectoryName, "ConnectionsList.Default.xml");

                CrmConnections cc = new CrmConnections("Default");
                cc.SerializeToFile(defaultFilePath);

                ConnectionsList.Instance.Files.Add(new ConnectionFile(cc) { Path = defaultFilePath, LastUsed = DateTime.Now});
                ConnectionsList.Instance.Save();
            }

            foreach (var file in ConnectionsList.Instance.Files)
            {
                var connections = CrmConnections.LoadFromFile(file.Path);
                connections.Connections.Sort();

                var fileItem = new ToolStripMenuItem(file.Name);
                fileItem.Tag = file;
                if (!mergeConnectionFiles && filesCount > 1)
                {
                    list.Add(fileItem);
                }

                foreach (var cDetail in connections.Connections)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = cDetail.ConnectionName;
                    item.Tag = cDetail;

                    if (cDetail.UseOnline)
                    {
                        item.Image =
                            RessourceManager.GetImage(
                                "McTools.Xrm.Connection.WinForms.Resources.CRMOnlineLive_16.png");
                    }
                    else if (cDetail.UseOsdp)
                    {
                        item.Image =
                            RessourceManager.GetImage(
                                "McTools.Xrm.Connection.WinForms.Resources.CRMOnlineLive_16.png");
                    }
                    else if (cDetail.UseIfd)
                    {
                        item.Image =
                            RessourceManager.GetImage(
                                "McTools.Xrm.Connection.WinForms.Resources.server_key.png");
                    }
                    else
                    {
                        item.Image =
                            RessourceManager.GetImage(
                                "McTools.Xrm.Connection.WinForms.Resources.server.png");
                    }

                    BuildActionItems(item);
                    if (!mergeConnectionFiles && filesCount > 1)
                    {
                        fileItem.DropDownItems.Add(item);
                    }
                    else
                    {
                        list.Add(item);
                    }
                }

                if (!mergeConnectionFiles && filesCount > 1)
                {
                    if (fileItem.DropDownItems.Count > 0)
                    {
                        fileItem.DropDownItems.Add(new ToolStripSeparator());
                    }
                }

                

                var newConnectionItem = new ToolStripMenuItem();
                newConnectionItem.Text = "Create new connection";
                newConnectionItem.Image = (Image)resources.GetObject("server_add");
                newConnectionItem.Click += newConnectionItem_Click;

                if (!mergeConnectionFiles && filesCount > 1)
                {
                    fileItem.DropDownItems.Add(newConnectionItem);
                }
            }

            if (mergeConnectionFiles || filesCount == 1)
            {
                if (list.Count > 0)
                {
                    list.Add(new ToolStripSeparator());
                }

                var newConnectionItem = new ToolStripMenuItem();
                newConnectionItem.Text = "Create new connection";
                newConnectionItem.Image = (Image)resources.GetObject("server_add");
                newConnectionItem.Click += newConnectionItem_Click;

                list.Add(newConnectionItem);
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    btn.DropDownItems.Clear();
                    btn.DropDownItems.AddRange(list.ToArray());
                }));
            }
            else
            {
                btn.DropDownItems.Clear();
                btn.DropDownItems.AddRange(list.ToArray());
            }
        }

        /// <summary>
        /// Creates the three action menus for a connection
        /// </summary>
        /// <param name="item">Menu where to add the actions</param>
        private void BuildActionItems(ToolStripMenuItem item)
        {
            ToolStripMenuItem cItem = new ToolStripMenuItem();
            cItem.Click += actionItem_Click;
            cItem.Text = "Connect";
            cItem.Image = (Image) resources.GetObject("server_connect");
            item.DropDownItems.Add(cItem);

            ToolStripMenuItem eItem = new ToolStripMenuItem();
            eItem.Click += actionItem_Click;
            eItem.Text = "Edit";
            eItem.Image = (Image)resources.GetObject("server_edit");
            item.DropDownItems.Add(eItem);

            ToolStripMenuItem dItem = new ToolStripMenuItem();
            dItem.Click += actionItem_Click;
            dItem.Text = "Delete";
            dItem.Image = (Image)resources.GetObject("server_delete");
            item.DropDownItems.Add(dItem);
        }

        /// <summary>
        /// Builds the ToolStripDropDownButton that will manage connections
        /// </summary>
        private void BuildConnectionControl()
        {
            ToolStripDropDownButton connexionManager = new ToolStripDropDownButton();
            connexionManager.Text = "Not connected";
            connexionManager.Image = (Image)resources.GetObject("server");
            connexionManager.Click += connexionManager_Click;
            AddActionsList(connexionManager);

            Items.Add(connexionManager);
        }

        #endregion Methods

        #region Events

        private void actionItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            ToolStripDropDownItem parentItem = (ToolStripDropDownItem)clickedItem.OwnerItem;
            ConnectionDetail currentConnection = (ConnectionDetail)parentItem.Tag;
            ToolStripDropDownItem connexionManager = (ToolStripDropDownItem)parentItem.OwnerItem;

            switch (clickedItem.Text)
            {
                case "Connect":

                    if (currentConnection.IsCustomAuth)
                    {
                        if (_formHelper.RequestPassword(currentConnection))
                        {
                            ConnectionManager.Instance.ConnectToServer(currentConnection);
                        }
                    }
                    else
                    {
                        ConnectionManager.Instance.ConnectToServer(currentConnection);
                    }
                    break;

                case "Edit":
                    currentConnection = _formHelper.EditConnection(false, currentConnection);

                    if (currentConnection != null && parentItem.Text != currentConnection.ConnectionName)
                    {
                        parentItem.Text = currentConnection.ConnectionName;
                        parentItem.Tag = currentConnection;
                    }

                    break;

                case "Delete":
                    if (MessageBox.Show(this, "Are you sure you want to delete selected connection(s)?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    connexionManager.DropDownItems.Remove(parentItem);

                    if (connexionManager.DropDownItems.Count == 2)
                    {
                        connexionManager.DropDownItems.RemoveAt(0);
                    }

                    _formHelper.DeleteConnection(currentConnection);

                    break;
            }
        }

        private void connexionManager_Click(object sender, EventArgs e)
        {
            // On main ToolStripDropDownButton button click, we rebuild the list
            // of crm connections
            AddActionsList((ToolStripDropDownButton)sender);
        }

        private void newConnectionItem_Click(object sender, EventArgs e)
        {
            var actionMenu = (ToolStripMenuItem) sender;
            ToolStripDropDownItem parentItem = (ToolStripDropDownItem)actionMenu.OwnerItem;
            var connectionFile = (ConnectionFile)parentItem.Tag;

            ConnectionDetail detail = _formHelper.EditConnection(true, null, connectionFile);

            if (detail != null)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = detail.ConnectionName;
                item.Tag = detail;

                if (detail.UseOnline)
                {
                    item.Image =
                        RessourceManager.GetImage(
                            "McTools.Xrm.Connection.WinForms.Resources.CRMOnlineLive_16.png");
                }
                else if (detail.UseOsdp)
                {
                    item.Image =
                        RessourceManager.GetImage(
                            "McTools.Xrm.Connection.WinForms.Resources.CRMOnlineLive_16.png");
                }
                else if (detail.UseIfd)
                {
                    item.Image =
                        RessourceManager.GetImage(
                            "McTools.Xrm.Connection.WinForms.Resources.server_key.png");
                }
                else
                {
                    item.Image =
                        RessourceManager.GetImage(
                            "McTools.Xrm.Connection.WinForms.Resources.server.png");
                }

                BuildActionItems(item);

               
                if (parentItem.DropDownItems.Count == 1)
                {
                    parentItem.DropDownItems.Insert(0, new ToolStripSeparator());
                    parentItem.DropDownItems.Insert(0, item);
                }
                else
                {
                    parentItem.DropDownItems.Insert(parentItem.DropDownItems.Count - 2, item);
                }

                MessageBox.Show(this, "Connection Created Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Events
    }
}