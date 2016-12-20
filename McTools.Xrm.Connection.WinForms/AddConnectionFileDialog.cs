using System;
using System.Linq;
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

        public ConnectionFile OpenedFile { get; private set; }

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
                var newCc = CrmConnections.LoadFromFile(txtFilePath.Text);
                OpenedFile = new ConnectionFile(newCc)
                {
                    Path = txtFilePath.Text,
                    LastUsed = DateTime.Now
                };

                if (ConnectionsList.Instance.Files.Any(f => f.Name == OpenedFile.Name))
                {
                    int cloneId = 1;
                    string newName = OpenedFile.Name;

                    while (ConnectionsList.Instance.Files.FirstOrDefault(f => f.Name == newName) != null)
                    {
                        var rule = new System.Text.RegularExpressions.Regex(".* \\(" + cloneId + "\\)$");
                        if (rule.IsMatch(newName))
                        {
                            cloneId++;
                            newName = $"{OpenedFile.Name.Replace($" ({cloneId-1})","")} ({cloneId})";
                        }
                        else
                        {
                            newName = $"{newName} ({cloneId})";
                        }
                    }

                    OpenedFile.Name = newName;

                    MessageBox.Show(this, $"A connection file with this name already exists!\n\nIt has been renamed to '{newName}'", "Warning",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ConnectionManager.ConfigurationFile = txtFilePath.Text;
                ConnectionsList.Instance.Files.First(f => f.Path == txtFilePath.Text).Name = OpenedFile.Name;
                ConnectionManager.Instance.LoadConnectionsList();
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