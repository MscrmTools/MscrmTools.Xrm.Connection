using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionFirstStepControl : UserControl, IConnectionWizardControl
    {
        private bool invalidUrlWarned;

        public ConnectionFirstStepControl()
        {
            InitializeComponent();
        }

        public string HostName
        {
            get
            {
                if (!txtOrganizationUrl.Text.StartsWith("http"))
                {
                    if (!invalidUrlWarned)
                    {
                        invalidUrlWarned = true;
                        MessageBox.Show(this,
                            @"Please enter a valid url",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    return null;
                }

                var urlWithoutProtocol = txtOrganizationUrl.Text.Remove(0, UseSsl ? 8 : 7);
                var urlParts = urlWithoutProtocol.Split('/');
                var host = urlParts[0];
                var hostParts = host.Split(':');

                return hostParts[0];
            }
        }

        public int HostPort
        {
            get
            {
                if (!txtOrganizationUrl.Text.StartsWith("http"))
                {
                    if (!invalidUrlWarned)
                    {
                        invalidUrlWarned = true;
                        MessageBox.Show(this,
                            @"Please enter a valid url",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    return -1;
                }

                var urlWithoutProtocol = txtOrganizationUrl.Text.Remove(0, UseSsl ? 8 : 7);
                var urlParts = urlWithoutProtocol.Split('/');
                var host = urlParts[0];
                var hostParts = host.Split(':');

                var hostPort = hostParts.Length == 2 ? int.Parse(hostParts[1]) : new int?();
                if (!hostPort.HasValue)
                {
                    return UseSsl ? 443 : 80;
                }

                return hostPort.Value;
            }
        }

        public string OrganizationUrlName
        {
            get
            {
                if (!txtOrganizationUrl.Text.StartsWith("http"))
                {
                    if (!invalidUrlWarned)
                    {
                        invalidUrlWarned = true;
                        MessageBox.Show(this,
                            @"Please enter a valid url",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    return null;
                }

                var urlWithoutProtocol = txtOrganizationUrl.Text.Remove(0, UseSsl ? 8 : 7);
                if (urlWithoutProtocol.EndsWith("/"))
                {
                    urlWithoutProtocol = urlWithoutProtocol.Substring(0, urlWithoutProtocol.Length - 1);
                }
                var urlParts = urlWithoutProtocol.Split('/');

                return urlParts.Length > 1 && !urlParts[1].ToLower().StartsWith("main.aspx") ? urlParts[1] : urlParts[0].Split('.')[0];
            }
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
            set => txtOrganizationUrl.Text = string.IsNullOrEmpty(value) ? txtOrganizationUrl.Text : value;
        }

        public bool UseIntegratedAuth
        {
            get => chkUseIntegratedAuthentication.Checked;
            set => chkUseIntegratedAuthentication.Checked = value;
        }

        //public bool UseMfa
        //{
        //    get => chkUseMfa.Checked;
        //    set => chkUseMfa.Checked = value;
        //}

        public bool UseSsl => Url.StartsWith("https://");

        private void ConnectionFirstStepControl_Load(object sender, EventArgs e)
        {
            if (txtOrganizationUrl.Text == "https://organization.crm.dynamics.com")
            {
                txtOrganizationUrl.Select(8, 12);
            }

            txtOrganizationUrl.Focus();
        }
    }
}