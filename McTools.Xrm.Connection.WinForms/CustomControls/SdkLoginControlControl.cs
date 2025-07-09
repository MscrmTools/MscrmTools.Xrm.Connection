using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Tooling.CrmConnectControl;
using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class SdkLoginControlControl : UserControl, IConnectionWizardControl
    {
        private readonly Guid connectionDetailId;
        private readonly bool isNew;

        public SdkLoginControlControl(Guid connectionDetailId, bool isNew, TimeSpan timeout)
        {
            InitializeComponent();

            this.connectionDetailId = connectionDetailId;
            this.isNew = isNew;
            txtTimeout.Text = $@"{timeout:hh\:mm\:ss}";
        }

        public event EventHandler ConnectionSucceeded;

        public AuthenticationProviderType AuthType { get; private set; }
        public CrmConnectionManager ConnectionManager { get; private set; }
        public TimeSpan Timeout => TimeSpan.Parse(txtTimeout.Text);

        private void btnOpenSdkLoginCtrl_Click(object sender, EventArgs e)
        {
            var ctrl = new CRMLoginForm1(connectionDetailId, !isNew);

            if (rdbUseCustom.Checked)
            {
                ctrl.AppId = txtAzureAdAppId.Text;
                ctrl.RedirectUri = new Uri(txtReplyUrl.Text);
            }
            else
            {
                ctrl.AppId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
                ctrl.RedirectUri = new Uri("app://58145B91-0C36-4500-8554-080854F2AC97");
            }
            ctrl.ConnectionToCrmCompleted += (loginCtrl, evt) =>
            {
                ConnectionManager = ((CRMLoginForm1)loginCtrl).CrmConnectionMgr;
                SetAuthType();
                ConnectionSucceeded?.Invoke(this, null);
            };
            ctrl.ShowDialog();
        }

        private void rdbUseCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtAzureAdAppId.ReadOnly = !rdbUseCustom.Checked;
            txtReplyUrl.ReadOnly = !rdbUseCustom.Checked;
        }

        private void SdkLoginControlControl_Load(object sender, System.EventArgs e)
        {
        }

        private void SetAuthType()
        {
            switch (ConnectionManager.CrmSvc.ActiveAuthenticationType)
            {
                case AuthenticationType.AD:
                    AuthType = AuthenticationProviderType.ActiveDirectory;
                    break;

                case AuthenticationType.IFD:
                case AuthenticationType.Claims:
                    AuthType = AuthenticationProviderType.Federation;
                    break;

                default:
                    AuthType = AuthenticationProviderType.OnlineFederation;
                    break;
            }
        }
    }
}