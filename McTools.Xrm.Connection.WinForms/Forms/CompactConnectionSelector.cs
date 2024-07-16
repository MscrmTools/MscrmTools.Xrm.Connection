using McTools.Xrm.Connection.WinForms.AppCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.Forms
{
    public partial class CompactConnectionSelector : Form
    {
        private readonly IConnectionControlSettings settings;
        private readonly ToolTip toolTip = new ToolTip();

        private int sizeFactor = 4;

        public CompactConnectionSelector(IConnectionControlSettings settings)
        {
            InitializeComponent();

            this.settings = settings;
            btnMru.Tag = settings?.ShowMostRecentConnections ?? true;
            btnSearch.Tag = settings?.ShowSearchBarInCompactSelector ?? false;
            btnDetailsView.Tag = settings?.UseDetailsViewForConnectionSelector ?? false;

            foreach (var file in ConnectionsList.Instance.Files)
            {
                file.ApplyLinkWithConnectionDetails();
            }

            FillConnectionFilesList();

            chFile.Width = lvConnections.Width - 26;
            btnConnectionManager.Image = btnConnectionManager.Image.ResizeImage(20, 20);
            btnNewConnection.Image = btnNewConnection.Image.ResizeImage(20, 20);

            var ll = new LinkLabel
            {
                Text = "Open Connection Manager to create a new connection"
            };
            ll.LinkClicked += llOpenConnectionManager_LinkClicked;

            noConnectionControl1.ActionLabel = ll;

            SetDisplay();

            CustomTheme.Instance.ApplyTheme(this);
        }

        public List<ConnectionDetail> SelectedConnections { get; set; }

        private void btnChangeSize_Click(object sender, EventArgs e)
        {
            if (sizeFactor == 2) sizeFactor = 4;
            else if (sizeFactor == 1) sizeFactor = 2;
            else if (sizeFactor == 4) sizeFactor = 1;

            SimpleImageList.ImageSize = new Size(SimpleImageList.ImageSize.Width, Convert.ToInt32(40 + 8 * sizeFactor));

            if (settings != null)
            {
                settings.DisplaySizeFactor = sizeFactor;
            }

            lvConnections.Invalidate();
        }

        private void btnConnectionManager_Click(object sender, EventArgs e)
        {
            using (var cm = new ConnectionSelector(false, cbbFiles.SelectedItem as ConnectionFile))
            {
                cm.OpenCreationWizard = e is OpenCreateWizardEventArgs;

                if (cm.ShowDialog(this) == DialogResult.OK)
                {
                    if (cm.HadCreatedNewConnection)
                    {
                        cbbFiles_SelectedIndexChanged(cbbFiles, new EventArgs());
                    }

                    var cd = cm.SelectedConnections.FirstOrDefault();
                    if (cd != null)
                    {
                        cbbFiles.SelectedItem = cd.ParentConnectionFile;
                        var item = lvConnections.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag == cd);
                        if (item != null)
                        {
                            item.Selected = true;
                            item.EnsureVisible();
                        }
                    }
                }

                cbbFiles_SelectedIndexChanged(cbbFiles, new EventArgs());
            }
        }

        private void btnDetailsView_Click(object sender, EventArgs e)
        {
            btnDetailsView.Tag = !(bool)btnDetailsView.Tag;
            if (settings != null)
            {
                settings.UseDetailsViewForConnectionSelector = (bool)btnDetailsView.Tag;
            }

            SetDisplay();
        }

        private void btnMru_Click(object sender, EventArgs e)
        {
            btnMru.Tag = !(bool)btnMru.Tag;
            if (settings != null)
            {
                settings.ShowMostRecentConnections = (bool)btnMru.Tag;
            }

            SetDisplay();
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            var parentFile = cbbFiles.SelectedIndex == 0 ? null : (ConnectionFile)cbbFiles.SelectedItem;

            using (var cForm = new ConnectionWizard2(null, parentFile)
            {
                StartPosition = FormStartPosition.CenterParent
            })
            {
                if (cForm.ShowDialog(this) == DialogResult.OK)
                {
                    var newConnection = cForm.CrmConnectionDetail;
                    newConnection.LastUsedOn = DateTime.Now;

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
                    item.EnsureVisible();

                    lvConnections.Sort();

                    if (cForm.HasCreatedNewFolder)
                    {
                        FillConnectionFilesList();
                        cbbFiles.SelectedItem = newConnection.ParentConnectionFile;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedConnections = new List<ConnectionDetail>();
            SelectedConnections.AddRange(lvConnections.SelectedItems.Cast<ListViewItem>().Select(i => (ConnectionDetail)i.Tag).ToList());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Tag = !(bool)btnSearch.Tag;

            if (settings != null)
            {
                settings.ShowSearchBarInCompactSelector = (bool)btnSearch.Tag;
            }
            SetDisplay();
            cbbFiles_SelectedIndexChanged(cbbFiles, new EventArgs());
        }

        private void btnShowHideSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible;
        }

        private void cbbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvConnections.Items.Clear();

            if (cbbFiles.SelectedIndex == 0)
            {
                if ((bool)btnMru.Tag)
                {
                    var list = ConnectionManager.Instance.ConnectionsFilesList.Files.SelectMany(f => f.Connections.Connections).OrderByDescending(c => c.LastUsedOn).Take(settings?.NumberOfRecentConnectionsToDisplay ?? 10);
                    lvConnections.Sorting = SortOrder.None;
                    lvConnections.Items.AddRange(list.Select(c => GetListViewItem(c)).ToArray());
                }
                else
                {
                    var list = ConnectionManager.Instance.ConnectionsFilesList.Files.SelectMany(f => f.Connections.Connections).OrderBy(c => c.ConnectionName);
                    lvConnections.Sorting = SortOrder.Ascending;
                    lvConnections.Items.AddRange(list.Select(c => GetListViewItem(c)).ToArray());
                }
            }
            else
            {
                var file = (ConnectionFile)cbbFiles.SelectedItem;
                lvConnections.Items.AddRange(file.Connections.Connections.Select(c => GetListViewItem(c)).ToArray());
            }

            if ((settings?.UseDetailsViewForConnectionSelector ?? false) || (bool)btnDetailsView.Tag)
            {
                for (var i = 0; i < lvConnections.Columns.Count; i++)
                {
                    if (i == lvConnections.Columns.Count - 1) continue;

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
                lvConnections.Columns[0].Text = "Name";
            }
            else
            {
                lvConnections.Columns[0].Width = lvConnections.Width - 26;
                lvConnections.Columns[0].Text = "";
            }

            lvConnections.Invalidate();

            noConnectionControl1.Visible = lvConnections.Items.Count == 0;
        }

        private void CompactConnectionSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else if (e.KeyCode == Keys.Enter && lvConnections.SelectedItems.Count == 1)
            {
                btnOK_Click(btnOK, new EventArgs());
            }
        }

        private void CompactConnectionSelector_Load(object sender, EventArgs e)
        {
            cbbFiles_SelectedIndexChanged(cbbFiles, new EventArgs());
            if (lvConnections.Items.Count > 0)
            {
                lvConnections.Items[0].Selected = true;
                lvConnections.Focus();
                lvConnections.Select();
            }
        }

        private void FillConnectionFilesList()
        {
            cbbFiles.Items.Clear();
            cbbFiles.Items.Add("Recently used connections");

            foreach (var file in ConnectionManager.Instance.ConnectionsFilesList.Files.OrderBy(cf => cf.Name))
            {
                cbbFiles.Items.Add(file);
            }

            cbbFiles.SelectedIndex = 0;
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

        private ListViewItem GetListViewItem(ConnectionDetail cd)
        {
            return new ListViewItem(cd.ConnectionName)
            {
                SubItems = {
                    new ListViewItem.ListViewSubItem { Text = cd.WebApplicationUrl },
                    new ListViewItem.ListViewSubItem { Text = cd.UserName },
                },
                Group = GetGroup(cd),
                ImageIndex = GetImageIndex(cd),
                Tag = cd
            };
        }

        private void llOpenConnectionManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnConnectionManager_Click(btnConnectionManager, new OpenCreateWizardEventArgs());
        }

        private void lvConnections_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(lvConnections, new EventArgs());
        }

        private void LvConnections_GotFocus(object sender, System.EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 0)
                lvConnections.Items[0].Selected = true;
        }

        private void lvConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }

        private void SetDisplay()
        {
            pnlTopSearch.Visible = (bool)btnSearch.Tag;

            btnMru.Image = ((Image)((bool)btnMru.Tag ? Properties.Resources.NoHistory32 : Properties.Resources.history)).ResizeImage(20, 20);
            btnSearch.Image = ((Image)((bool)btnSearch.Tag ? Properties.Resources.NoSearch32 : Properties.Resources.Search32)).ResizeImage(20, 20);
            btnDetailsView.Image = ((Image)((bool)btnDetailsView.Tag ? Properties.Resources.NoDetails32 : Properties.Resources.Details32)).ResizeImage(20, 20);
            btnChangeSize.Image = Properties.Resources.Size32.ResizeImage(20, 20);
            btnChangeSize.Visible = !(bool)btnDetailsView.Tag;

            lvConnections.ShowGroups = !(bool)btnMru.Tag;

            toolTip.SetToolTip(btnShowHideSettings, "Show display settings");
            toolTip.SetToolTip(btnMru, (bool)btnMru.Tag ? "Display all connections" : "Display Most recently used connections");
            toolTip.SetToolTip(btnSearch, (bool)btnSearch.Tag ? "Hide search bar" : "Show search bar");
            toolTip.SetToolTip(btnDetailsView, (bool)btnDetailsView.Tag ? "Do not use details view" : "Use details view");

            btnMru.Text = (bool)btnMru.Tag ? "Do not use MRU" : "Use MRU";
            btnSearch.Text = (bool)btnSearch.Tag ? "Hide search bar" : "Show search bar";
            btnDetailsView.Text = (bool)btnDetailsView.Tag ? "Show compact mode" : "Show details mode";

            if ((settings?.UseDetailsViewForConnectionSelector ?? false) || (bool)btnDetailsView.Tag)
            {
                lvConnections.Columns.Clear();
                lvConnections.Columns.AddRange(new ColumnHeader[] {
                    chFile,
                    chUrl,
                    chUsername, chOther});

                lvConnections.SmallImageList = detailImageList;
                lvConnections.Columns[0].Text = "Name";
                lvConnections.HeaderStyle = ColumnHeaderStyle.Clickable;
            }
            else
            {
                lvConnections.Columns.Clear();
                lvConnections.Columns.AddRange(new ColumnHeader[] { chFile });
                lvConnections.SmallImageList = SimpleImageList;
                for (int i = lvConnections.Columns.Count - 1; i > 0; i--)
                {
                    lvConnections.Columns.RemoveAt(i);
                }
                lvConnections.Columns[0].Text = "";
                lvConnections.HeaderStyle = ColumnHeaderStyle.None;
            }

            cbbFiles.Items.RemoveAt(0);

            if ((bool)btnMru.Tag)
            {
                cbbFiles.Items.Insert(0, "Recently used connections");
            }
            else
            {
                cbbFiles.Items.Insert(0, "All connections");
            }
            cbbFiles.Invalidate();
            cbbFiles.SelectedIndex = 0;

            cbbFiles_SelectedIndexChanged(cbbFiles, new EventArgs());
        }

        #region Search

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = "Search";
                txtSearch.ForeColor = SystemColors.GrayText;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lvConnections.Items.Clear();

            if (cbbFiles.SelectedIndex == 0)
            {
                if ((bool)btnMru.Tag)
                {
                    var list = ConnectionManager.Instance.ConnectionsFilesList.Files.SelectMany(f => f.Connections.Connections)
                        .Where(c => c.ConnectionName.IndexOf(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        .OrderByDescending(c => c.LastUsedOn)
                        .Take(settings?.NumberOfRecentConnectionsToDisplay ?? 10);
                    lvConnections.Items.AddRange(list.Select(c => GetListViewItem(c)).ToArray());
                }
                else
                {
                    var list = ConnectionManager.Instance.ConnectionsFilesList.Files.SelectMany(f => f.Connections.Connections)
                        .Where(c => c.ConnectionName.IndexOf(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        .OrderBy(c => c.ConnectionName);
                    lvConnections.Items.AddRange(list.Select(c => GetListViewItem(c)).ToArray());
                }
            }
            else
            {
                var file = (ConnectionFile)cbbFiles.SelectedItem;
                lvConnections.Items.AddRange(file.Connections.Connections.Select(c => GetListViewItem(c)).ToArray());
            }
        }

        #endregion Search
    }
}