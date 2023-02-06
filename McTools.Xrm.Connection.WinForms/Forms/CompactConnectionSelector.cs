using McTools.Xrm.Connection.WinForms.AppCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.Forms
{
    public partial class CompactConnectionSelector : Form
    {
        private readonly IConnectionControlSettings settings;

        public CompactConnectionSelector(IConnectionControlSettings settings)
        {
            this.settings = settings;

            InitializeComponent();

            foreach (var file in Connection.ConnectionsList.Instance.Files)
            {
                file.ApplyLinkWithConnectionDetails();
            }

            FillConnectionFilesList();

            chFile.Width = lvConnections.Width - 26;
            btnConnectionManager.Image = btnConnectionManager.Image.ResizeImage(20, 20);
        }

        public List<ConnectionDetail> SelectedConnections { get; set; }

        private void btnConnectionManager_Click(object sender, EventArgs e)
        {
            using (var cm = new ConnectionSelector(false, comboBox1.SelectedItem as ConnectionFile))
            {
                if (cm.ShowDialog(this) == DialogResult.OK)
                {
                    if (cm.HadCreatedNewConnection)
                    {
                        comboBox1_SelectedIndexChanged(comboBox1, new EventArgs());
                    }

                    var cd = cm.SelectedConnections.FirstOrDefault();
                    if (cd != null)
                    {
                        comboBox1.SelectedItem = cd.ParentConnectionFile;
                        var item = lvConnections.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag == cd);
                        if (item != null)
                        {
                            item.Selected = true;
                            item.EnsureVisible();
                        }
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

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var obj = comboBox1.Items[e.Index];
            string text;
            Image img = Properties.Resources.Folder32;
            if (obj is ConnectionFile cf)
            {
                text = cf.Name;

                if (!string.IsNullOrEmpty(cf.Connections.Base64Image))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cf.Connections.Base64Image)))
                    {
                        img = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                img = Properties.Resources.history;
                text = obj.ToString();
            }

            img = img.ResizeImage(32, 32);
            e.Graphics.DrawImage(img, e.Bounds.X + 4, e.Bounds.Y + (e.Bounds.Height - 32) / 2);

            using (var f = new Font(comboBox1.Font.FontFamily, 14))
            {
                var textSize = TextRenderer.MeasureText(text, f);

                e.Graphics.DrawString(text, f, new SolidBrush(Color.Black), e.Bounds.X + 40, e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvConnections.Items.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                var list = ConnectionManager.Instance.ConnectionsFilesList.Files.SelectMany(f => f.Connections.Connections).OrderByDescending(c => c.LastUsedOn).Take(settings?.NumberOfRecentConnectionsToDisplay ?? 10);
                lvConnections.Items.AddRange(list.Select(c => new ListViewItem(c.ConnectionName) { SubItems = { new ListViewItem.ListViewSubItem { Text = c.ConnectionName } }, Tag = c }).ToArray());
            }
            else
            {
                var file = (ConnectionFile)comboBox1.SelectedItem;
                lvConnections.Items.AddRange(file.Connections.Connections.Select(c => new ListViewItem(c.ConnectionName) { SubItems = { new ListViewItem.ListViewSubItem { Text = c.ConnectionName } }, Tag = c }).ToArray());
            }

            pnlNoConnection.Visible = lvConnections.Items.Count == 0;
        }

        private void FillConnectionFilesList()
        {
            comboBox1.Items.Add("Recently used connections");

            foreach (var file in ConnectionManager.Instance.ConnectionsFilesList.Files)
            {
                comboBox1.Items.Add(file);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void llOpenConnectionManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnConnectionManager_Click(btnConnectionManager, new EventArgs());
        }

        private void lvConnections_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(lvConnections, new EventArgs());
        }

        private void lvConnections_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
        }

        private void lvConnections_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            DrawingHelper.DrawConnectionDetailItem(e, false);
        }

        private void lvConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }
    }
}