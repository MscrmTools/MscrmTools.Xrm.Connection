using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class RenameConnectionFileDialog : Form
    {
        public RenameConnectionFileDialog(string name)
        {
            InitializeComponent();

            txtConnectionName.Text = name;
        }

        public string NewName { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            NewName = txtConnectionName.Text;
            Close();
        }
    }
}