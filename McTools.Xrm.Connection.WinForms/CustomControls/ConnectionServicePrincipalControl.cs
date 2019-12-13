using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionServicePrincipalControl : UserControl, IConnectionWizardControl
    {
        private string clientSecretTemp = "********************************************************";

        public ConnectionServicePrincipalControl()
        {
            InitializeComponent();
        }

        public Guid AzureAdAppId
        {
            get
            {
                if (!Guid.TryParse(txtAzureAppId.Text, out Guid id))
                {
                    MessageBox.Show(this, @"The Azure AD Application Id is not a valid GUID!", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return Guid.Empty;
                }

                return id;
            }
            set => txtAzureAppId.Text = value.ToString();
        }

        public string ClientSecret => txtClientSecret.Text == clientSecretTemp ? null : txtClientSecret.Text;

        public bool ClientSecretChanged { get; private set; }

        public bool HasClientSecret { get; set; }

        public string Url
        {
            get => txtURL.Text;
            set => txtURL.Text = value;
        }
        public string TokenCachePath { get; set; }
        private void ConnectionOauthControl_Load(object sender, EventArgs e)
        {
            txtURL.Focus();

            if (HasClientSecret)
                txtClientSecret.Text = clientSecretTemp;
        }

        private void llMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://docs.microsoft.com/{CultureInfo.CurrentUICulture.Name}/dynamics365/customer-engagement/developer/walkthrough-register-dynamics-365-app-azure-active-directory");
        }

        private void txtClientSecret_TextChanged(object sender, EventArgs e)
        {
            ClientSecretChanged = true;
        }

    }
}