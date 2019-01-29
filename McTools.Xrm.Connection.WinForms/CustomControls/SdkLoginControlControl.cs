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

        public SdkLoginControlControl(Guid connectionDetailId, bool isNew)
        {
            InitializeComponent();

            this.connectionDetailId = connectionDetailId;
            this.isNew = isNew;
        }

        public event EventHandler ConnectionSucceeded;

        public AuthenticationProviderType AuthType { get; private set; }
        public CrmConnectionManager ConnectionManager { get; private set; }

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
                ctrl.AppId = "2ad88395-b77d-4561-9441-d0e40824f9bc";
                ctrl.RedirectUri = new Uri("app://5d3e90d6-aa8e-48a8-8f2c-58b45cc67315");
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
            tableLayoutPanel1.Enabled = rdbUseCustom.Checked;
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