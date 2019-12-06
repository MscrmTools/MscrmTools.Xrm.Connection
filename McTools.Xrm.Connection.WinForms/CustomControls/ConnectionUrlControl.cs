using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionUrlControl : UserControl, IConnectionWizardControl
    {
        private bool invalidUrlWarned;

        public ConnectionUrlControl(ConnectionDetail detail)
        {
            InitializeComponent();

            txtOrganizationUrl.Text = detail.OriginalUrl;
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
            txtOrganizationUrl.Focus();
        }
    }
}