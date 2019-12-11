using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionUrlControl : UserControl, IConnectionWizardControl
    {
        public ConnectionUrlControl(ConnectionDetail detail)
        {
            InitializeComponent();

            txtOrganizationUrl.Text = string.IsNullOrEmpty(detail.OriginalUrl) ? "https://organization.crm.dynamics.com" : detail.OriginalUrl;
        }

        public TimeSpan Timeout
        {
            get
            {
                if (!TimeSpan.TryParse(txtTimeout.Text, out TimeSpan result))
                {
                    MessageBox.Show(this,
                        @"Please enter a valid timeout (format => HH:mm:ss)",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return new TimeSpan();
                }
                return result;
            }
            set => txtTimeout.Text = $@"{value:hh\:mm\:ss}";
        }

        public string Url
        {
            get => txtOrganizationUrl.Text.ToLower();
            set => txtOrganizationUrl.Text = value;
        }

        public bool UseSsl => Url.StartsWith("https://");

        private void ConnectionUrlControl_Load(object sender, EventArgs e)
        {
            if (txtOrganizationUrl.Text == @"https://organization.crm.dynamics.com")
            {
                txtOrganizationUrl.Select(8, 12);
            }

            txtOrganizationUrl.Focus();
        }
    }
}