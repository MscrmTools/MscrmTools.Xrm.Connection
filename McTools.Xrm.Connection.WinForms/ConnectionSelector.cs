﻿using McTools.Xrm.Connection.WinForms.AppCode;
using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace McTools.Xrm.Connection.WinForms
{
    /// <summary>
    /// Formulaire de sélection d'une connexion à un serveur
    /// Crm dans une liste de connexions existantes.
    /// </summary>
    public partial class ConnectionSelector : Form
    {
        #region Variables

        private readonly bool isConnectionSelection;
        private Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();
        private int currentIndex;
        private int FoldersListWidth = 300;
        private bool hadCreatedNewConnection;
        private Thread searchThread;
        private bool showCompact = false;
        private ConnectionFile sourceFile;

        #endregion Variables

        #region Constructeur

        /// <summary>
        /// Créé une nouvelle instance de la classe ConnectionSelector
        /// </summary>
        public ConnectionSelector(bool isConnectionSelection = true, ConnectionFile sourceFile = null)
        {
            InitializeComponent();

            Width = 1200;

            this.isConnectionSelection = isConnectionSelection;
            this.sourceFile = sourceFile;

            if (isConnectionSelection)
            {
                bValidate.Text = @"Connect";
            }

            rbDisplayModeDetails.Checked = ConnectionManager.Instance.ConnectionsList.UseDetailsView;
            rbDisplayModeDetails.SetAutoWidth();
            rbDisplayModeSimple.SetAutoWidth();
            lblDisplayMode.SetAutoWidth();
            rbDisplayModeDetails_CheckedChanged(rbDisplayModeDetails, new EventArgs());

            foreach (var file in Connection.ConnectionsList.Instance.Files)
            {
                file.ApplyLinkWithConnectionDetails();
            }
        }

        #endregion Constructeur

        #region Properties

        public bool HadCreatedNewConnection => hadCreatedNewConnection;

        /// <summary>
        /// Obtient la connexion sélectionnée
        /// </summary>
        public List<ConnectionDetail> SelectedConnections { get; private set; }

        public IConnectionControlSettings Settings { get; set; }

        #endregion Properties

        #region Méthodes

        private void BCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BValidateClick(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count > 0)
            {
                SelectedConnections = new List<ConnectionDetail>();

                foreach (ListViewItem item in lvConnections.SelectedItems)
                {
                    SelectedConnections.Add(item.Tag as ConnectionDetail);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void DisplayConnections(object searchTerm = null)
        {
            Invoke(new Action(() =>
            {
                lvConnections.Items.Clear();
                lvConnections.Groups.Clear();

                //ConnectionManager.Instance.ConnectionsList.Connections.Sort();

                //var details = ConnectionManager.Instance.ConnectionsList.Connections;

                var details = ((ConnectionFile)lvConnectionFiles.SelectedItems[0].Tag).Connections.Connections.OrderBy(c => c.ConnectionName);

                var filteredDetails = details.Where(d => string.IsNullOrEmpty(searchTerm?.ToString())
                || d.ConnectionName.ToLower().IndexOf(searchTerm?.ToString().ToLower()) >= 0
                || d.WebApplicationUrl.ToLower().IndexOf(searchTerm?.ToString().ToLower()) >= 0
                || d.UserName.ToLower().IndexOf(searchTerm?.ToString().ToLower()) >= 0
                ).ToList();

                if (ConnectionManager.Instance.ConnectionsList.UseMruDisplay)
                {
                    filteredDetails = filteredDetails.OrderByDescending(c => c.LastUsedOn).ThenBy(c => c.ConnectionName).ToList();
                }

                foreach (ConnectionDetail detail in filteredDetails)
                {
                    var item = new ListViewItem(detail.ConnectionName);
                    item.SubItems.Add(detail.ServerName);
                    item.SubItems.Add(detail.Organization);
                    item.SubItems.Add(string.IsNullOrEmpty(detail.UserDomain) ? detail.UserName : $"{detail.UserDomain}\\{detail.UserName}");
                    item.SubItems.Add(detail.OrganizationVersion);
                    item.SubItems.Add(detail.LastUsedOn.ToString(CultureInfo.CurrentCulture));
                    item.Tag = detail;
                    item.ImageIndex = GetImageIndex(detail);

                    if (!ConnectionManager.Instance.ConnectionsList.UseMruDisplay)
                    {
                        item.Group = GetGroup(detail);
                    }

                    lvConnections.Items.Add(item);
                }

                if (!ConnectionManager.Instance.ConnectionsList.UseMruDisplay)
                {
                    var groups = new ListViewGroup[lvConnections.Groups.Count];

                    lvConnections.Groups.CopyTo(groups, 0);

                    Array.Sort(groups, new GroupComparer());

                    lvConnections.BeginUpdate();
                    lvConnections.Groups.Clear();
                    lvConnections.Groups.AddRange(groups);
                    lvConnections.EndUpdate();
                }

                tsbNewConnection.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;
                tsbUpdateConnection.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;
                tsbCloneConnection.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;
                tsbDeleteConnection.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;
                tsbUpdatePassword.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;
                tsb_UseMru.Enabled = !ConnectionManager.Instance.ConnectionsList.IsReadOnly;

                pnlNoConnection.Visible = lvConnections.Items.Count == 0;

                DisplayConnectionsMenu(lvConnections.SelectedItems.Count);
            }));
        }

        private void DisplayConnectionsMenu(int selectedCount)
        {
            tsbUpdateConnection.Visible = selectedCount == 1;
            tsbCloneConnection.Visible = selectedCount == 1;
            tsbDeleteConnection.Visible = selectedCount > 0;

            tsbUpdatePassword.Visible = lvConnections.SelectedItems.Count > 0;
            tsSeparator1.Visible = tsbUpdatePassword.Visible;

            tsbShowConnectionString.Visible = lvConnections.SelectedItems.Count == 1;
            tsbSetProfile.Visible = lvConnections.SelectedItems.Count > 0;
            tsSeparator2.Visible = tsbShowConnectionString.Visible || tsbSetProfile.Visible;

            tsbMoveToExistingFile.Visible = lvConnections.SelectedItems.Count > 0;
            tsbMoveToNewFile.Visible = lvConnections.SelectedItems.Count > 0;
            tsSeparator4.Visible = tsbMoveToExistingFile.Visible || tsbMoveToNewFile.Visible;
        }

        private ListViewGroup GetGroup(ConnectionDetail detail)
        {
            string groupName;

            if (detail.UseOnline)
            {
                groupName = "Dataverse";
            }
            else if (detail.UseIfd)
            {
                groupName = "Claims authentication - Internet Facing Deployment";
            }
            else
            {
                groupName = "OnPremise";
            }

            var group = lvConnections.Groups.Cast<ListViewGroup>().FirstOrDefault(g => g.Name == groupName);
            if (group == null)
            {
                group = new ListViewGroup(groupName, groupName);
                lvConnections.Groups.Add(group);
            }

            return group;
        }

        private int GetImageIndex(ConnectionDetail detail)
        {
            if (detail.UseOnline)
            {
                return 2;
            }

            if (detail.UseIfd)
            {
                return 1;
            }

            return 0;
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //var lv = (ListView)sender;
            //if (ModifierKeys == Keys.Control)
            //{
            //    var item = lv.HitTest(e.Location).Item;
            //    item.Selected = !item.Selected;
            //    lv.Invalidate();
            //    return;
            //}

            //foreach (ListViewItem item in lv.Items)
            //{
            //    item.Selected = false;
            //}

            //lv.HitTest(e.Location).Item.Selected = true;
        }

        private void listview_Resize(object sender, EventArgs e)
        {
            var lv = (ListView)sender;

            if (lv.Items.Count == 0 || !lv.Visible) return;

            bool hasScrollBar = lv.ClientSize.Height < (lv.Items.Count + 1) * lv.Items[0].Bounds.Height;
            lv.Columns[0].Width = lv.Width;// - (hasScrollBar ? 16 : 0);
        }

        private void LoadConnectionFile()
        {
            tsb_UseMru.Checked = ConnectionManager.Instance.ConnectionsList.UseMruDisplay;
            tsb_UseMru.CheckedChanged += tsb_UseMru_CheckedChanged;

            if (isConnectionSelection)
            {
                Text = @"Select a connection";
                tsbDeleteConnection.Visible = false;
                tsbUpdateConnection.Visible = false;
                tsbCloneConnection.Visible = false;
                tsbRemoveConnectionList.Visible = false;
                bCancel.Text = @"Cancel";
                bValidate.Visible = true;
            }
            else
            {
                Text = @"Connections Manager";
                tsbDeleteConnection.Visible = true;
                tsbUpdateConnection.Visible = true;
                tsbCloneConnection.Visible = true;
                tsbRemoveConnectionList.Visible = true;
                bCancel.Text = @"Close";
                bValidate.Visible = false;
            }

            DisplayConnections();
        }

        private void rbDisplayModeDetails_CheckedChanged(object sender, EventArgs e)
        {
            showCompact = rbDisplayModeDetails.Checked;
            if (Settings == null)
            {
                Settings = new Settings();
            }

            Settings.UseDetailsViewForConnectionManager = showCompact;

            if (showCompact)
            {
                lvConnections.SmallImageList = detailImageList;

                lvConnections.Columns.Clear();
                lvConnections.Columns.AddRange(new ColumnHeader[] {
                    chName,
                    chServer,
                    chOrganization,
                    chUser,
                    chVersion,
                    chLastUsedOn});

                for (var i = 0; i < lvConnections.Columns.Count; i++)
                {
                    var maxString = "";
                    foreach (ListViewItem item in lvConnections.Items)
                    {
                        if (maxString.Length < item.SubItems[i].Text.Length)
                        {
                            maxString = item.SubItems[i].Text;
                        }
                    }
                    lvConnections.Columns[i].Width = TextRenderer.MeasureText(maxString, lvConnections.Font).Width + (i == 0 ? 20 : 10);
                }
            }
            else
            {
                lvConnections.SmallImageList = SimpleImageList;
                lvConnections.Columns[0].Width = lvConnections.Width;

                for (int i = lvConnections.Columns.Count - 1; i >= 1; i--)
                {
                    lvConnections.Columns.RemoveAt(i);
                }

                lvConnections.Columns[0].Width = lvConnections.Width - 30;
            }

            lvConnections.Invalidate();

            ConnectionManager.Instance.ConnectionsList.UseDetailsView = rbDisplayModeDetails.Checked;
        }

        private void tsb_UseMru_CheckedChanged(object sender, EventArgs e)
        {
            var tsb = (ToolStripButton)sender;
            ConnectionManager.Instance.ConnectionsList.UseMruDisplay = tsb.Checked;

            DisplayConnections();
        }

        #endregion Méthodes

        #region Form

        private void ConnectionSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                tsbNewConnection_Click(null, null);
            }

            if (e.Control && e.KeyCode == Keys.U)
            {
                tsbUpdateConnection_Click(null, null);
            }

            if (e.Control && e.KeyCode == Keys.D)
            {
                tsbDeleteConnection_Click(null, null);
            }
        }

        private void ConnectionSelector_Load(object sender, EventArgs e)
        {
            showCompact = Settings?.UseDetailsViewForConnectionManager ?? rbDisplayModeDetails.Checked;

            var mostRecentFile = ConnectionsList.Instance.Files.OrderByDescending(f => f.LastUsed).FirstOrDefault();
            tsbRemoveConnectionList.Enabled = false;
            int index = 0;
            int selectedIndex = 0;
            string maxLengthName = "";
            ListViewItem selectedItem = null;
            if (mostRecentFile != null)
            {
                foreach (var file in ConnectionsList.Instance.Files.OrderBy(k => k.Name))
                {
                    if (maxLengthName.Length < file.Name.Length)
                    {
                        maxLengthName = file.Name;
                    }

                    var item = new ListViewItem
                    {
                        Text = file.Name,
                        Tag = file
                    };

                    if (file.Name == mostRecentFile.Name)
                    {
                        selectedItem = item;
                        item.Selected = true;
                        selectedIndex = index;
                    }
                    else if (!Uri.IsWellFormedUriString(file.Path, UriKind.Absolute))
                    {
                        tsbMoveToExistingFile.DropDownItems.Add(new ToolStripButton
                        {
                            Text = file.Name,
                            Tag = file,
                            Size = new Size(155, 22),
                            AutoSize = true
                        });
                    }

                    lvConnectionFiles.Items.Add(item);

                    if (sourceFile != null && sourceFile.Equals(file))
                    {
                        if (selectedItem != null)
                        {
                            selectedItem.Selected = false;
                        }
                        selectedItem = item;

                        item.Selected = true;
                        sourceFile = null;
                    }

                    index++;
                }
                lvConnectionFiles.EnsureVisible(selectedIndex);
                selectedItem?.EnsureVisible();
            }

            tsbMoveToExistingFile.Enabled = lvConnectionFiles.Items.Count > 0;
            tsbRemoveConnectionList.Enabled = lvConnectionFiles.Items.Count > 0;

            using (var font = new Font(lvConnectionFiles.Font.FontFamily, 16))
            {
                FoldersListWidth = TextRenderer.MeasureText(maxLengthName, font).Width + 120;
            }
            // Display connections
            LoadConnectionFile();

            lvConnections_SelectedIndexChanged(this, new EventArgs());

            ConnectionSelector_Resize(this, new EventArgs());
        }

        private void ConnectionSelector_Resize(object sender, EventArgs e)
        {
            scMain.SplitterDistance = FoldersListWidth;
            scConnections.SplitterDistance = scConnections.Width < 400 ? scConnections.Width : scConnections.Width - 400;

            pbNoConnection.Location = new Point(pnlNoConnection.Width / 2 - pbNoConnection.Width / 2, pnlNoConnection.Height / 2 - pbNoConnection.Height / 2);
            lblNoConnectionFound.Location = new Point(lblNoConnectionFound.Location.X, pbNoConnection.Location.Y + pbNoConnection.Height);
            llCreateNewConnection.Location = new Point(llCreateNewConnection.Location.X, pbNoConnection.Location.Y + pbNoConnection.Height + lblNoConnectionFound.Height);
        }

        private void ConnectionSelector_ResizeEnd(object sender, EventArgs e)
        {
            lvConnectionFiles.Invalidate();
            lvConnections.Invalidate();
        }

        #endregion Form

        #region Files

        private void lvConnectionFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvConnectionFiles.SelectedItems.Count == 0) return;

            var file = (ConnectionFile)lvConnectionFiles.SelectedItems[0].Tag;

            if (!ConnectionManager.FileExists(file.Path))
            {
                CleanFileList(file);
                return;
            }

            // Or it is a connection file so we load it for the connection manager
            ConnectionManager.ConfigurationFile = file.Path;

            file.LastUsed = DateTime.Now;

            tsbMoveToExistingFile.DropDownItems.Clear();
            foreach (var cf in ConnectionsList.Instance.Files.OrderBy(k => k.Name))
            {
                if (cf.Path == file.Path || Uri.IsWellFormedUriString(file.Path, UriKind.Absolute))
                {
                    continue;
                }

                tsbMoveToExistingFile.DropDownItems.Add(new ToolStripButton
                {
                    Text = cf.Name,
                    Tag = cf,
                    Size = new Size(155, 22),
                    AutoSize = true
                });
            }

            LoadConnectionFile();
        }

        #endregion Files

        #region Connections

        private void LvConnections_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (!e.CancelEdit && e.Label != null)
            {
                var detail = (ConnectionDetail)lvConnections.Items[e.Item].Tag;
                detail.ConnectionName = e.Label;

                ConnectionManager.Instance.SaveConnectionsFile();
            }
        }

        private void lvConnections_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || lvConnections.SelectedItems.Count == 0)
                return;

            BValidateClick(null, null);
        }

        private void lvConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayConnectionsMenu(lvConnections.SelectedItems.Count);

            if (lvConnections.SelectedItems.Count == 1)
            {
                pgConnection.SelectedObject = lvConnections.SelectedItems[0].Tag;
            }
        }

        private void lvConnections_SizeChanged(object sender, EventArgs e)
        {
            if (!showCompact)
            {
                lvConnections.Columns[0].Width = lvConnections.Width - 30;
            }
        }

        private void LvConnectionsColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvConnections.Sorting = lvConnections.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvConnections.ListViewItemSorter = new ListViewItemComparer(e.Column, lvConnections.Sorting);
        }

        private void LvConnectionsMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isConnectionSelection)
            {
                BValidateClick(sender, e);
            }
            else if (!ConnectionManager.Instance.ConnectionsList.IsReadOnly)
            {
                tsbUpdateConnection_Click(sender, null);
            }
        }

        #endregion Connections

        #region Connection actions

        private void tsbCloneConnection_Click(object sender, EventArgs e)
        {
            var newItems = new List<ListViewItem>();

            foreach (ListViewItem item in lvConnections.SelectedItems)
            {
                var detail = (ConnectionDetail)item.Tag;

                var newDetail = ConnectionManager.Instance.ConnectionsList.CloneConnection(detail);

                var newItem = new ListViewItem(newDetail.ConnectionName);
                newItem.SubItems.Add(newDetail.ServerName);
                newItem.SubItems.Add(newDetail.Organization);
                newItem.SubItems.Add(newDetail.OrganizationVersion);
                newItem.Tag = newDetail;
                newItem.Group = GetGroup(newDetail);
                newItem.ImageIndex = GetImageIndex(newDetail);

                newItems.Add(newItem);
            }

            lvConnections.Items.AddRange(newItems.ToArray());
        }

        private void tsbConnectionProperties_Click(object sender, EventArgs e)
        {
            scConnections.Panel2Collapsed = !scConnections.Panel2Collapsed;
            scConnections.SplitterDistance = scConnections.Width - 400;
        }

        private void tsbDeleteConnection_Click(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count > 0 &&
                MessageBox.Show(this, @"Are you sure you want to delete selected connection(s)?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (ListViewItem connectionItem in lvConnections.SelectedItems)
            {
                var detailToRemove = (ConnectionDetail)connectionItem.Tag;

                lvConnections.Items.Remove(lvConnections.SelectedItems[0]);

                ConnectionManager.Instance.ConnectionsList.Connections.RemoveAll(d => d.ConnectionId == detailToRemove.ConnectionId);
            }

            ConnectionManager.Instance.SaveConnectionsFile();
        }

        private void tsbNewConnection_Click(object sender, EventArgs e)
        {
            var cForm = new ConnectionWizard2
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (cForm.ShowDialog(this) == DialogResult.OK)
            {
                var newConnection = cForm.CrmConnectionDetail;
                newConnection.ParentConnectionFile = lvConnectionFiles.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag as ConnectionFile;
                hadCreatedNewConnection = true;

                var item = new ListViewItem(newConnection.ConnectionName);
                item.SubItems.Add(newConnection.ServerName);
                item.SubItems.Add(newConnection.Organization);
                item.SubItems.Add(newConnection.UserName);
                item.SubItems.Add(newConnection.OrganizationVersion);
                item.Tag = newConnection;
                item.Group = GetGroup(newConnection);
                item.ImageIndex = GetImageIndex(newConnection);

                lvConnections.Items.Add(item);
                lvConnections.SelectedItems.Clear();
                item.Selected = true;

                lvConnections.Sort();

                if (isConnectionSelection)
                {
                    BValidateClick(sender, e);
                }

                // If the connection id is not found and the user want to save
                // the connection (ie. he provided a name for the connection)
                if (ConnectionManager.Instance.ConnectionsList.Connections.FirstOrDefault(d => d.ConnectionId == newConnection.ConnectionId) == null
                             && !string.IsNullOrEmpty(newConnection.ConnectionName))
                {
                    ConnectionManager.Instance.ConnectionsList.Connections.Add(newConnection);
                    ConnectionManager.Instance.SaveConnectionsFile();
                }
            }
        }

        private void tsbSetProfile_Click(object sender, EventArgs e)
        {
            var connections = lvConnections.SelectedItems
               .Cast<ListViewItem>().Select(lvi => (ConnectionDetail)lvi.Tag)
               .ToList();

            if (!connections.Any())
            {
                return;
            }

            var browser = BrowserEnum.None;
            string profile = null;

            if (connections.Count == 1)
            {
                browser = connections.First().BrowserName;
                profile = connections.First().BrowserProfile;
            }

            var dialog = new BrowserSelectionDialog(browser, profile);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var connection in connections)
                {
                    connection.BrowserName = dialog.Browser;
                    connection.BrowserProfile = dialog.Profile;
                }

                try
                {
                    ConnectionManager.Instance.SaveConnectionsFile();
                }
                catch (Exception error)
                {
                    MessageBox.Show(this, $"An error occured when saving connection(s): {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbShowConnectionString_Click(object sender, EventArgs e)
        {
            var connections = lvConnections.SelectedItems
                .Cast<ListViewItem>().Select(lvi => (ConnectionDetail)lvi.Tag)
                .ToList();

            if (connections.Count == 1)
            {
                var csd = new ConnectionStringDialog(connections.First());
                csd.ShowDialog(this);
            }
        }

        private void tsbUpdateConnection_Click(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 1)
            {
                ListViewItem item = lvConnections.SelectedItems[0];

                var cd = (ConnectionDetail)item.Tag;

                if (cd.IsFromSdkLoginCtrl)
                {
                    var ctrl = new CRMLoginForm1(cd.ConnectionId.Value, true);
                    ctrl.ShowDialog();

                    if (ctrl.CrmConnectionMgr.CrmSvc?.IsReady ?? false)
                    {
                        cd.Organization = ctrl.CrmConnectionMgr.ConnectedOrgUniqueName;
                        cd.OrganizationFriendlyName = ctrl.CrmConnectionMgr.ConnectedOrgFriendlyName;
                        cd.OrganizationDataServiceUrl =
                            ctrl.CrmConnectionMgr.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                        cd.OrganizationServiceUrl =
                            ctrl.CrmConnectionMgr.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                        cd.WebApplicationUrl =
                            ctrl.CrmConnectionMgr.ConnectedOrgPublishedEndpoints[EndpointType.WebApplication];
                        cd.ServerName = new Uri(cd.WebApplicationUrl).Host;
                        cd.OrganizationVersion = ctrl.CrmConnectionMgr.CrmSvc.ConnectedOrgVersion.ToString();

                        item.Tag = cd;
                        lvConnections.Items.Remove(item);
                        lvConnections.Items.Add(item);
                        lvConnections.Refresh();//RedrawItems(0, lvConnections.Items.Count - 1, false);

                        var updatedConnectionDetail = ConnectionManager.Instance.ConnectionsList.Connections.FirstOrDefault(
                            c => c.ConnectionId == cd.ConnectionId);

                        ConnectionManager.Instance.ConnectionsList.Connections.Remove(updatedConnectionDetail);
                        ConnectionManager.Instance.ConnectionsList.Connections.Add(cd);

                        ConnectionManager.Instance.SaveConnectionsFile();
                    }

                    return;
                }

                var cForm = new ConnectionWizard2(cd)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                if (cForm.ShowDialog(this) == DialogResult.OK)
                {
                    item.Tag = cForm.CrmConnectionDetail;
                    item.SubItems[0].Text = cForm.CrmConnectionDetail.ConnectionName;
                    item.SubItems[1].Text = cForm.CrmConnectionDetail.ServerName;
                    item.SubItems[2].Text = cForm.CrmConnectionDetail.Organization;
                    if (item.SubItems.Count == 4)
                    {
                        item.SubItems[3].Text = cForm.CrmConnectionDetail.OrganizationVersion;
                    }
                    else
                    {
                        item.SubItems.Add(cForm.CrmConnectionDetail.OrganizationVersion);
                    }
                    item.Group = GetGroup(cForm.CrmConnectionDetail);

                    lvConnections.Refresh();

                    var updatedConnectionDetail = ConnectionManager.Instance.ConnectionsList.Connections.FirstOrDefault(
                            c => c.ConnectionId == cForm.CrmConnectionDetail.ConnectionId);

                    ConnectionManager.Instance.ConnectionsList.Connections.Remove(updatedConnectionDetail);
                    ConnectionManager.Instance.ConnectionsList.Connections.Add(cForm.CrmConnectionDetail);

                    ConnectionManager.Instance.SaveConnectionsFile();
                }
            }
        }

        private void tsbUpdatePassword_Click(object sender, EventArgs e)
        {
            var connections = lvConnections.SelectedItems
                .Cast<ListViewItem>().Select(lvi => (ConnectionDetail)lvi.Tag)
                .ToList();

            if (!connections.Any())
            {
                return;
            }

            var upDialog = new UpdatePasswordForm(connections);
            var result = upDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ConnectionManager.Instance.SaveConnectionsFile();
                MessageBox.Show(this, @"Connections have been updated!", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Ignore)
            {
                MessageBox.Show(this, @"No connection were updated!", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        #endregion Connection actions

        #region Connection file actions

        private void CleanFileList(ConnectionFile connectionFile)
        {
            var message = $"The file '{connectionFile.Path}' does not exist and will be removed from the list!";
            MessageBox.Show(this, message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var item = lvConnectionFiles.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag.Equals(connectionFile));
            if (item != null)
            {
                lvConnectionFiles.Items.Remove(item);
            }

            ConnectionsList.Instance.Files.Remove(connectionFile);
            ConnectionsList.Instance.Save();
        }

        private void tsbAddExisting_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = @"XML file|*.xml"
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    var newCc = CrmConnections.LoadFromFile(dialog.FileName);
                    var ncf = new ConnectionFile(newCc)
                    {
                        Path = dialog.FileName,
                        Name = newCc.Name,
                        LastUsed = DateTime.Now
                    };

                    string newName = newCc.Name ?? "New File";
                    if (ConnectionsList.Instance.Files.Any(f => f.Name == dialog.FileName))
                    {
                        int cloneId = 1;

                        while (ConnectionsList.Instance.Files.FirstOrDefault(f => f.Name == newName) != null)
                        {
                            var rule = new System.Text.RegularExpressions.Regex(".* \\(" + cloneId + "\\)$");
                            if (rule.IsMatch(newName))
                            {
                                cloneId++;
                                newName = $"{newName?.Replace($" ({cloneId - 1})", "") ?? "New File"} ({cloneId})";
                            }
                            else
                            {
                                newName = $"{newName} ({cloneId})";
                            }
                        }

                        MessageBox.Show(this, $"A connection file with this name already exists!\n\nIt has been renamed to '{newName}'", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    ConnectionManager.ConfigurationFile = dialog.FileName;
                    ConnectionsList.Instance.Files.First(f => f.Path == dialog.FileName).Name = newName;
                    ConnectionManager.Instance.LoadConnectionsList();
                    ConnectionsList.Instance.Save();

                    var item = new ListViewItem(ncf.Name) { Tag = ncf };
                    lvConnectionFiles.Items.Add(item);
                    item.Selected = true;
                }
            }
        }

        private void tsbCreateConnectionFile_Click(object sender, EventArgs e)
        {
            bool loadConnections = true;
            var ncf = new ConnectionFile(new CrmConnections("Default"));

            using (var nfd = new EditConnectionFileDialog(ncf, true, false))
            {
                if (nfd.ShowDialog(this) == DialogResult.OK)
                {
                    ncf.Connections.Name = nfd.NewName;
                    ncf.Save();

                    ConnectionsList.Instance.Files.Add(ncf);

                    lvConnectionFiles.Items.Add(new ListViewItem(ncf.Name) { Tag = ncf });
                    tsbRemoveConnectionList.Enabled = true;
                }
                else
                {
                    loadConnections = false;
                }

                if (loadConnections)
                {
                    LoadConnectionFile();
                }
            }

            ConnectionsList.Instance.Save();

            tsbMoveToExistingFile.Enabled = lvConnectionFiles.Items.Count > 0;
        }

        private void tsbMoveToExistingFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var connectionsIds =
                lvConnections.SelectedItems.Cast<ListViewItem>().Select(i => ((ConnectionDetail)i.Tag).ConnectionId);

            var currentFilePath = ConnectionManager.ConfigurationFile;
            var newFilePath = ((ConnectionFile)e.ClickedItem.Tag).Path;

            var currentDoc = new XmlDocument();
            currentDoc.Load(currentFilePath);
            var newDoc = new XmlDocument();
            newDoc.Load(newFilePath);

            foreach (var connectionId in connectionsIds)
            {
                var nodeToMove = currentDoc.SelectSingleNode("//ConnectionDetail[ConnectionId/text()='" + connectionId + "']");
                if (nodeToMove == null) continue;

                newDoc.SelectSingleNode("//Connections")?.AppendChild(newDoc.ImportNode(nodeToMove, true));
                currentDoc.SelectSingleNode("//Connections")?.RemoveChild(nodeToMove);
            }

            currentDoc.Save(currentFilePath);
            newDoc.Save(newFilePath);
            LoadConnectionFile();
        }

        private void tsbMoveToNewFile_Click(object sender, EventArgs e)
        {
            bool loadConnections = true;
            var nf = new ConnectionFile();

            using (var nfd = new EditConnectionFileDialog(nf, true, false))
            {
                if (nfd.ShowDialog(this) == DialogResult.OK)
                {
                    var scs = lvConnections.SelectedItems.Cast<ListViewItem>().Select(i => (ConnectionDetail)i.Tag).ToList();
                    foreach (var sc in scs)
                    {
                        ConnectionManager.Instance.ConnectionsList.Connections.Remove(sc);
                    }

                    ConnectionManager.Instance.SaveConnectionsFile();

                    ConnectionManager.ConfigurationFile = nf.Path;

                    tsbRemoveConnectionList.Enabled = true;

                    ConnectionManager.Instance.ConnectionsList.Connections = scs;
                    ConnectionManager.Instance.SaveConnectionsFile();
                }
                else
                {
                    loadConnections = false;
                }

                if (loadConnections)
                {
                    LoadConnectionFile();
                }
            }

            ConnectionsList.Instance.Save();

            tsbMoveToExistingFile.Enabled = lvConnectionFiles.Items.Count > 0;
        }

        private void tsbRemoveConnectionList_Click(object sender, EventArgs e)
        {
            if (lvConnectionFiles.SelectedItems.Count == 0) return;

            var message = "Are you sure you want to remove this connections list file?\n\nThe file is not deleted physically but just removed from connections files list";
            if (MessageBox.Show(this, message, @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
                return;

            var item = (ConnectionFile)lvConnectionFiles.SelectedItems[0].Tag;

            ConnectionsList.Instance.Files.Remove(item);
            ConnectionsList.Instance.Save();
            lvConnectionFiles.Items.Remove(lvConnectionFiles.SelectedItems[0]);

            tsbMoveToExistingFile.Enabled = lvConnectionFiles.Items.Count > 0;
        }

        private void tsbRenameFile_Click(object sender, EventArgs e)
        {
            if (lvConnectionFiles.SelectedItems.Count == 0) return;

            var item = (ConnectionFile)lvConnectionFiles.SelectedItems[0].Tag;
            using (var dialog = new EditConnectionFileDialog(item, false, false))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    item.Name = dialog.NewName;
                    item.Connections.Name = dialog.NewName;
                    if (!string.IsNullOrEmpty(dialog.Base64Image))
                    {
                        item.Connections.Base64Image = dialog.Base64Image;
                    }
                    item.Connections.SerializeToFile(item.Path);
                    ConnectionsList.Instance.Save();

                    lvConnectionFiles.Invalidate();
                }
            }
        }

        #endregion Connection file actions

        #region Search

        private void tstSearch_Enter(object sender, EventArgs e)
        {
            var ctrl = (ToolStripTextBox)sender;

            if (ctrl.ForeColor == SystemColors.GrayText)
            {
                ctrl.Text = string.Empty;
                ctrl.ForeColor = SystemColors.WindowText;
            }
        }

        private void tstSearch_Leave(object sender, EventArgs e)
        {
            var ctrl = (ToolStripTextBox)sender;

            if (ctrl.ForeColor != SystemColors.GrayText && ctrl.Text.Length == 0)
            {
                ctrl.ForeColor = SystemColors.GrayText;
                ctrl.TextChanged -= tstSearch_TextChanged;
                ctrl.Text = "Search";
                ctrl.TextChanged += tstSearch_TextChanged;
            }
        }

        private void tstSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchThread != null) searchThread.Abort();

            searchThread = new Thread(new ParameterizedThreadStart(DisplayConnections));
            searchThread.Start(tstSearch.Text);
        }

        #endregion Search

        private void llCreateNewConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tsbNewConnection_Click(llCreateNewConnection, new EventArgs());
        }
    }
}