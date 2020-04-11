using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionMfaControl : UserControl, IConnectionWizardControl
    {
        public ConnectionMfaControl()
        {
            InitializeComponent();
        }

        public Guid AzureAdAppId
        {
            get
            {
                if (!Guid.TryParse(txtAzureAdAppId.Text, out Guid id))
                {
                    return Guid.Empty;
                }

                return id;
            }
            set => txtAzureAdAppId.Text = value.ToString();
        }

        public string ReplyUrl
        {
            get => txtReplyUrl.Text;
            set => txtReplyUrl.Text = value;
        }

        public string Username
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }

        private void btnUseDevAzureAdApp_Click(object sender, EventArgs e)
        {
            var message = @"For development and prototyping purposes Microsoft has provided AppId or ClientId and Redirect URI for use in OAuth Flows.
For production use, you should create an AppId or ClientId that is specific to your tenant in the Azure Management portal.";

            if (MessageBox.Show(this, message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                txtAzureAdAppId.Text = @"51f81489-12ee-4a9e-aaae-a2591f45987d";
                txtReplyUrl.Text = new Uri("app://58145B91-0C36-4500-8554-080854F2AC97").ToString();
            }
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