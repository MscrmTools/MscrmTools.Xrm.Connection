using System;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class NewConnectionFileDialog : Form
    {
        public NewConnectionFileDialog()
        {
            InitializeComponent();
        }

        public string CreatedFilePath { get; private set; }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                FileName = string.Format("{0}.xml", txtConnectionName.Text),
                Filter = "XML file|*.xml",
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = sfd.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CrmConnections cc = new CrmConnections(txtConnectionName.Text);
            var file = new ConnectionFile(cc)
            {
                Path = txtFilePath.Text,
                LastUsed = DateTime.Now
            };
            
            if (ConnectionsList.Instance.Files.Any(f => f.Name == cc.Name))
            {
                int cloneId = 1;
                string newName = cc.Name;

                while (ConnectionsList.Instance.Files.FirstOrDefault(f => f.Name == newName) != null)
                {
                    var rule = new System.Text.RegularExpressions.Regex(".* \\(" + cloneId + "\\)$");
                    if (rule.IsMatch(newName))
                    {
                        cloneId++;
                        newName = $"{cc.Name.Replace($" ({cloneId - 1})", "")} ({cloneId})";
                    }
                    else
                    {
                        newName = $"{newName} ({cloneId})";
                    }
                }

                file.Name = newName;
              
                MessageBox.Show(this, $"A connection file with this name already exists!\n\nIt has been renamed to '{newName}'", "Warning",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cc.SerializeToFile(txtFilePath.Text);
            ConnectionsList.Instance.Save();

            CreatedFilePath = txtFilePath.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}