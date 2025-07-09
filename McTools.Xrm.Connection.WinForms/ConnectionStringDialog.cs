using McTools.Xrm.Connection.WinForms.AppCode;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class ConnectionStringDialog : Form
    {
        public ConnectionStringDialog(ConnectionDetail detail)
        {
            InitializeComponent();

            txtConnectionString.Text = detail.GetConnectionString();
            lblTitle.Text = string.Format(lblTitle.Text, detail.ConnectionName);

            CustomTheme.Instance.ApplyTheme(this);
        }
    }
}