using McTools.Xrm.Connection.WinForms.AppCode;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class EditConnectionFileDialog : Form
    {
        private ConnectionFile file;
        private string imagePath;
        private bool isAddition;
        private bool isCreation;

        public EditConnectionFileDialog(ConnectionFile file, bool isCreation, bool isAddition)
        {
            InitializeComponent();

            this.file = file;
            this.isCreation = isCreation;
            this.isAddition = isAddition;

            if (!isCreation)
            {
                txtConnectionName.Text = file.Name ?? "N/A";

                if (!string.IsNullOrEmpty(file.Connections.Base64Image))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(file.Connections.Base64Image)))
                    {
                        var img = Image.FromStream(ms);

                        pbPreview.Image = img.ResizeImage(48, 48);
                    }
                }

                txtFilePath.Text = file.Path;
                txtFilePath.Enabled = false;
                btnBrowse.Enabled = false;
            }
        }

        public string Base64Image { get; private set; }
        public string NewName { get; private set; }
        public string Path { get; private set; }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (isAddition)
            {
                using (var sfd = new OpenFileDialog
                {
                    FileName = string.Format("{0}.xml", txtConnectionName.Text),
                    Filter = @"XML file|*.xml",
                })
                {
                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        txtFilePath.Text = sfd.FileName;
                    }
                }
            }
            else
            {
                using (var sfd = new SaveFileDialog
                {
                    FileName = string.Format("{0}.xml", txtConnectionName.Text),
                    Filter = @"XML file|*.xml",
                })
                {
                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        txtFilePath.Text = sfd.FileName;
                    }
                }
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (var sfd = new OpenFileDialog
            {
                FileName = string.Format("{0}.png", txtConnectionName.Text),
                Filter = @"PNG Image|*.png|JPG|*.jpg|JPEG|*.jpeg",
            })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(imagePath) && !File.Exists(imagePath))
                    {
                        MessageBox.Show(this, "The Image path is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(sfd.FileName)))
                    {
                        var img = Image.FromStream(ms);

                        pbPreview.Image = img.ResizeImage(48, 48);
                    }

                    imagePath = sfd.FileName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            NewName = txtConnectionName.Text;
            Path = txtFilePath.Text;
            file.Path = txtFilePath.Text;
            file.Name = txtConnectionName.Text;
            file.Connections.Name = txtConnectionName.Text;

            if (!string.IsNullOrEmpty(imagePath))
            {
                Base64Image = Convert.ToBase64String(File.ReadAllBytes(imagePath));
                file.Connections.Base64Image = Base64Image;
            }
            Close();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            Base64Image = null;
            pbPreview.Image = Properties.Resources.Folder32.ResizeImage(48, 48);
        }
    }
}