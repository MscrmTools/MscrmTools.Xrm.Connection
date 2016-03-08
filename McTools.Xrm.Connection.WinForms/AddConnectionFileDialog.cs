using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class AddConnectionFileDialog : Form
    {
        public AddConnectionFileDialog()
        {
            InitializeComponent();
        }

        public string OpenedFilePath { get; private set; }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "XML file|*.xml|CONFIG file|*.config",
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionManager.ConfigurationFile = txtFilePath.Text;
                ConnectionManager.Instance.LoadConnectionsList();

                ConnectionsList.Instance.Files.Add(new ConnectionFile
                {
                    Name = ConnectionManager.Instance.ConnectionsList.Name,
                    Path = txtFilePath.Text,
                    LastUsed = DateTime.Now
                });
                ConnectionsList.Instance.Save();

                OpenedFilePath = txtFilePath.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "It seems something went wrong when loading your file: " + error,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}