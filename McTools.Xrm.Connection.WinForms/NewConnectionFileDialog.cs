using System;
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
            cc.SerializeToFile(txtFilePath.Text);

            ConnectionsList.Instance.Files.Add(new ConnectionFile { Name = txtConnectionName.Text, Path = txtFilePath.Text, LastUsed = DateTime.Now });
            ConnectionsList.Instance.Save();

            CreatedFilePath = txtFilePath.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}