using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionAzureKeyVaultControl : UserControl, IConnectionWizardControl
    {
        public ConnectionAzureKeyVaultControl()
        {
            InitializeComponent();
        }

        public Guid AzureAdAppId
        {
            get
            {
                if (!Guid.TryParse(txtAzureAdAppId.Text, out Guid id))
                {
                    MessageBox.Show(this, @"The Azure AD Application Id is not a valid GUID!", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return Guid.Empty;
                }

                return id;
            }
            set => txtAzureAdAppId.Text = value.ToString();
        }


        public string AzureKeyVaultName
        {
            get
            {
                return txtAzureKeyVaultName.Text;
            }
            set => txtAzureKeyVaultName.Text = value;
        }

        private void ConnectionOauthControl_Load(object sender, EventArgs e)
        {
            txtAzureAdAppId.Focus();

        }

        private void llMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://docs.microsoft.com/{CultureInfo.CurrentUICulture.Name}/dynamics365/customer-engagement/developer/walkthrough-register-dynamics-365-app-azure-active-directory");
        }
    }
}