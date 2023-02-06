using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionMfaControl : UserControl, IConnectionWizardControl
    {
        private ToolTip toolTip = new ToolTip();

        public ConnectionMfaControl()
        {
            InitializeComponent();

            toolTip.SetToolTip(pbHelp, @"To connect to Microsoft Dynamics 365 with Oauth, it is required to connect to an Azure AD application.

For development and prototyping purposes Microsoft has provided AppId or ClientId and Redirect URI for use in OAuth Flows.
For production use, you should create an AppId or ClientId that is specific to your tenant in the Azure Management portal.");
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

        private void ConnectionOauthControl_Load(object sender, EventArgs e)
        {
            rdbUseCustomAppId.Checked = !txtAzureAdAppId.Text.Equals("51f81489-12ee-4a9e-aaae-a2591f45987d", StringComparison.InvariantCultureIgnoreCase);

            SetAppIdDisplay();
            txtUsername.Focus();
        }

        private void llMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://docs.microsoft.com/{CultureInfo.CurrentUICulture.Name}/dynamics365/customer-engagement/developer/walkthrough-register-dynamics-365-app-azure-active-directory");
        }

        private void rdbUseCustomAppId_CheckedChanged(object sender, EventArgs e)
        {
            rdbUseDevAppId.CheckedChanged -= rdbUseDevAppId_CheckedChanged;
            rdbUseDevAppId.Checked = !rdbUseCustomAppId.Checked;
            rdbUseDevAppId.CheckedChanged += rdbUseDevAppId_CheckedChanged;

            SetAppIdDisplay();
        }

        private void rdbUseDevAppId_CheckedChanged(object sender, EventArgs e)
        {
            rdbUseCustomAppId.CheckedChanged -= rdbUseCustomAppId_CheckedChanged;
            rdbUseCustomAppId.Checked = !rdbUseDevAppId.Checked;
            rdbUseCustomAppId.CheckedChanged += rdbUseCustomAppId_CheckedChanged;

            SetAppIdDisplay();
        }

        private void SetAppIdDisplay()
        {
            if (rdbUseCustomAppId.Checked)
            {
                txtAzureAdAppId.Enabled = true;
                txtReplyUrl.Enabled = true;
                txtAzureAdAppId.Text = string.Empty;
                txtReplyUrl.Text = string.Empty;
            }
            else
            {
                txtAzureAdAppId.Enabled = false;
                txtReplyUrl.Enabled = false;
                txtAzureAdAppId.Text = @"51f81489-12ee-4a9e-aaae-a2591f45987d";
                txtReplyUrl.Text = new Uri("app://58145B91-0C36-4500-8554-080854F2AC97").ToString();
            }
        }
    }
}