using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionStringControl : UserControl, IConnectionWizardControl
    {
        public ConnectionStringControl()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            get => txtConnectionString.Text;
            set => txtConnectionString.Text = value;
        }

        private void ConnectionStringControl_Load(object sender, System.EventArgs e)
        {
            txtConnectionString.Focus();
        }

        private void llConnectionStringHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://msdn.microsoft.com/{CultureInfo.CurrentUICulture.Name}/library/mt608573.aspx");

            txtConnectionString.Focus();
        }
    }
}