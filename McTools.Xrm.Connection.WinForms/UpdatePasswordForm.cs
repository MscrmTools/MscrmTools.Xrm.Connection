using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class UpdatePasswordForm : Form
    {
        private readonly IEnumerable<ConnectionDetail> connections;

        public UpdatePasswordForm(IEnumerable<ConnectionDetail> connections)
        {
            InitializeComponent();

            this.connections = connections;

            lblHeaderDesc.Text = string.Format(lblHeaderDesc.Text,
                connections.Count(),
                connections.Count() > 1 ? "s" : "");

            txtNewPassword.Focus();
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
                int updated = 0;

                foreach (var connection in connections)
                {
                    if (!connection.SavePassword)
                    {
                        continue;
                    }

                    connection.SetPassword(txtNewPassword.Text);
                    updated++;
                }

                DialogResult = updated > 0 ? DialogResult.OK : DialogResult.Ignore;
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "It seems something went wrong when updating the password: " + error,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}