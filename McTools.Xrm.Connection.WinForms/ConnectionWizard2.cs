using McTools.Xrm.Connection.WinForms.AppCode;
using McTools.Xrm.Connection.WinForms.CustomControls;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class ConnectionWizard2 : Form
    {
        private readonly bool isNew;
        private readonly List<Type> navigationHistory = new List<Type>();
        private readonly ConnectionFile parentFile;
        private IConnectionWizardControl ctrl;
        private string lastError;
        private ConnectionDetail originalDetail;
        private ConnectionType type;

        public ConnectionWizard2(ConnectionDetail detail = null, ConnectionFile parentFile = null)
        {
            InitializeComponent();

            isNew = detail == null;
            originalDetail = (ConnectionDetail)detail?.Clone();
            CrmConnectionDetail = detail ?? new ConnectionDetail(true);
            this.parentFile = parentFile;

            Text = originalDetail == null ? "New connection" : "Update connection";

            btnBack.Visible = false;
            btnReset.Visible = false;
        }

        public ConnectionDetail CrmConnectionDetail { get; private set; }

        public bool HasCreatedNewFolder { get; private set; }

        public override sealed string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        #region Buttons events

        private void btnBack_Click(object sender, EventArgs e)
        {
            navigationHistory.RemoveAt(navigationHistory.Count - 1);
            var type = navigationHistory.Last();
            navigationHistory.RemoveAt(navigationHistory.Count - 1);

            if (type == typeof(ConnectionFirstStepControl))
                DisplayControl<ConnectionFirstStepControl>();
            else if (type == typeof(ConnectionCredentialsControl))
                DisplayControl<ConnectionCredentialsControl>();
            else if (type == typeof(ConnectionFailedControl))
                DisplayControl<ConnectionFailedControl>();
            else if (type == typeof(ConnectionIfdControl))
                DisplayControl<ConnectionIfdControl>();
            else if (type == typeof(ConnectionLoadingControl))
                DisplayControl<ConnectionLoadingControl>();
            else if (type == typeof(ConnectionStringControl))
                DisplayControl<ConnectionStringControl>();
            else if (type == typeof(ConnectionSucceededControl))
                DisplayControl<ConnectionSucceededControl>();
            else if (type == typeof(SdkLoginControlControl))
                DisplayControl<SdkLoginControlControl>();
            else if (type == typeof(StartPageControl))
                DisplayControl<StartPageControl>();
            else if (type == typeof(ConnectionCertificateControl))
                DisplayControl<ConnectionCertificateControl>();
            else if (type == typeof(ConnectionUrlControl))
                DisplayControl<ConnectionUrlControl>();
            else if (type == typeof(ConnectionClientSecretControl))
                DisplayControl<ConnectionClientSecretControl>();
            else if (type == typeof(ConnectionAppIdControl))
                DisplayControl<ConnectionAppIdControl>();
            else if (type == typeof(ConnectionMfaControl))
                DisplayControl<ConnectionMfaControl>();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrl is ConnectionFirstStepControl cfsc)
            {
                CrmConnectionDetail.OriginalUrl = cfsc.Url;
                CrmConnectionDetail.IsCustomAuth = !cfsc.UseIntegratedAuth;
                //CrmConnectionDetail.UseMfa = cfsc.UseMfa;
                CrmConnectionDetail.ServerName = cfsc.HostName;
                CrmConnectionDetail.ServerPort = cfsc.HostPort;
                CrmConnectionDetail.OrganizationUrlName = cfsc.OrganizationUrlName;
                CrmConnectionDetail.Timeout = cfsc.Timeout;

                if (CrmConnectionDetail.Timeout.Ticks == 0 || CrmConnectionDetail.ServerName == null) return;

                if (CrmConnectionDetail.OrganizationUrlName == null)
                {
                    if (!IPAddress.TryParse(CrmConnectionDetail.ServerName, out _))
                    {
                        if (CrmConnectionDetail.ServerName.Split('.').Length > 1)
                            CrmConnectionDetail.OrganizationUrlName = CrmConnectionDetail.ServerName.Split('.')[0];
                    }

                    if (CrmConnectionDetail.UseOnline)
                    {
                        if (!cfsc.UseIntegratedAuth)
                        {
                            //if (CrmConnectionDetail.UseMfa)
                            //{
                            //    DisplayControl<ConnectionOauthControl>();
                            //}
                            //else
                            if (!CrmConnectionDetail.UseOnline && CrmConnectionDetail.OriginalUrl.Split('.').Length > 1)
                            {
                                DisplayControl<ConnectionIfdControl>();
                            }
                            else
                            {
                                DisplayControl<ConnectionCredentialsControl>();
                            }
                        }
                        else
                        {
                            DisplayControl<ConnectionLoadingControl>();
                            Connect();
                        }
                    }
                    else
                    {
                        DisplayControl<ConnectionIfdControl>();
                    }
                }
                else
                {
                    if (CrmConnectionDetail.IsCustomAuth)
                    {
                        //if (CrmConnectionDetail.UseMfa)
                        //{
                        //    DisplayControl<ConnectionOauthControl>();
                        //}
                        //else
                        if (!CrmConnectionDetail.UseOnline && CrmConnectionDetail.OriginalUrl.Split('.').Length > 1)
                        {
                            DisplayControl<ConnectionIfdControl>();
                        }
                        else
                        {
                            DisplayControl<ConnectionCredentialsControl>();
                        }
                    }
                    else
                    {
                        DisplayControl<ConnectionLoadingControl>();
                        Connect();
                    }
                }
            }
            else if (ctrl is ConnectionCredentialsControl ccc)
            {
                CrmConnectionDetail.UserDomain = ccc.Domain;
                CrmConnectionDetail.UserName = ccc.Username;
                CrmConnectionDetail.SavePassword = ccc.SavePassword;

                if (ccc.PasswordChanged)
                {
                    CrmConnectionDetail.SetPassword(ccc.Password);
                }

                if (string.IsNullOrEmpty(CrmConnectionDetail.UserName)
                    || CrmConnectionDetail.PasswordIsEmpty)
                {
                    MessageBox.Show(this,
                        @"Please enter your credentials before trying to connect",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (originalDetail == null)
                {
                    DisplayControl<ConnectionLoadingControl>();
                    Connect();
                }
                else if (CrmConnectionDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
                {
                    if (DialogResult.Yes == MessageBox.Show(this, @"You changed some values that require to test the connection. Would you like to test it now?

Note that this is required to validate this wizard",
                            @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DisplayControl<ConnectionLoadingControl>();
                        Connect();
                    }
                }
                else
                {
                    DisplayControl<ConnectionSucceededControl>();
                }
            }
            else if (ctrl is ConnectionIfdControl cic)
            {
                CrmConnectionDetail.UseIfd = cic.IsIfd;
                CrmConnectionDetail.HomeRealmUrl = cic.HomeRealmUrl;

                if (CrmConnectionDetail.OrganizationUrlName == null)
                {
                    if (!CrmConnectionDetail.UseIfd)
                    {
                        MessageBox.Show(this,
                            @"We were unable to determine the environment name based on the information you specified. Please complete the url to add the environment name inside",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        DisplayControl<ConnectionFirstStepControl>();
                        return;
                    }

                    CrmConnectionDetail.OrganizationUrlName = CrmConnectionDetail.ServerName.Split('.')[0];

                    if (CrmConnectionDetail.OrganizationUrlName == CrmConnectionDetail.ServerName)
                    {
                        MessageBox.Show(this,
                            @"The url you specified does not look like a valid url for an IFD deployment. Please correct the url",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        DisplayControl<ConnectionFirstStepControl>();
                        return;
                    }
                }

                CrmConnectionDetail.NewAuthType = cic.IsIfd ? AuthenticationType.IFD : AuthenticationType.AD;

                if (CrmConnectionDetail.IsCustomAuth)
                {
                    DisplayControl<ConnectionCredentialsControl>();
                }
                else if (originalDetail == null)
                {
                    DisplayControl<ConnectionLoadingControl>();
                    Connect();
                }
                else
                {
                    if (CrmConnectionDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
                    {
                        if (DialogResult.Yes == MessageBox.Show(this, @"You changed some values that require to test the connection. Would you like to test it now?

Note that this is required to validate this wizard",
                                @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            DisplayControl<ConnectionLoadingControl>();
                            Connect();
                        }
                    }
                    else
                    {
                        DisplayControl<ConnectionSucceededControl>();
                    }
                }
            }
            else if (ctrl is ConnectionStringControl csc)
            {
                CrmConnectionDetail.SetConnectionString(csc.ConnectionString);

                DisplayControl<ConnectionLoadingControl>();
                Connect();
            }
            else if (ctrl is ConnectionSucceededControl cokc)
            {
                CrmConnectionDetail.ConnectionName = cokc.ConnectionName;
                CrmConnectionDetail.ParentConnectionFile = cokc.ParentFolder;

                HasCreatedNewFolder = cokc.HasCreatedNewFolder;

                if (isNew)
                {
                    cokc.ParentFolder.Connections.Connections.Add(CrmConnectionDetail);
                }
                cokc.ParentFolder.Save();

                DialogResult = DialogResult.OK;
                Close();
            }
            else if (ctrl is SdkLoginControlControl slcc)
            {
                CrmConnectionDetail.IsFromSdkLoginCtrl = true;
                CrmConnectionDetail.AuthType = slcc.AuthType;
                CrmConnectionDetail.UseIfd = slcc.AuthType == AuthenticationProviderType.Federation;
                CrmConnectionDetail.Organization = slcc.ConnectionManager.ConnectedOrgUniqueName;
                CrmConnectionDetail.OrganizationFriendlyName = slcc.ConnectionManager.ConnectedOrgFriendlyName;
                CrmConnectionDetail.OrganizationDataServiceUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                CrmConnectionDetail.OrganizationServiceUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                CrmConnectionDetail.WebApplicationUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.WebApplication];
                CrmConnectionDetail.OriginalUrl = CrmConnectionDetail.WebApplicationUrl;
                CrmConnectionDetail.ServerName = new Uri(CrmConnectionDetail.WebApplicationUrl).Host;
                CrmConnectionDetail.OrganizationVersion = slcc.ConnectionManager.CrmSvc.ConnectedOrgVersion.ToString();
                CrmConnectionDetail.ServiceClient = slcc.ConnectionManager.CrmSvc;
                if (!string.IsNullOrEmpty(slcc.ConnectionManager.ClientId))
                {
                    CrmConnectionDetail.AzureAdAppId = new Guid(slcc.ConnectionManager.ClientId);
                    CrmConnectionDetail.ReplyUrl = slcc.ConnectionManager.RedirectUri.AbsoluteUri;
                }

                CrmConnectionDetail.UserName = CrmConnectionDetail.ServiceClient.OAuthUserId;

                DisplayControl<ConnectionSucceededControl>();
            }
            else if (ctrl is ConnectionUrlControl cuc)
            {
                if (string.IsNullOrEmpty(cuc.Url) || !Uri.TryCreate(cuc.Url, UriKind.Absolute, out _))
                {
                    MessageBox.Show(this, @"Please provide a valid url", @"Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                CrmConnectionDetail.OriginalUrl = cuc.Url;
                CrmConnectionDetail.Timeout = cuc.Timeout;

                if (type == ConnectionType.Certificate)
                {
                    DisplayControl<ConnectionCertificateControl>();
                }
                else if (type == ConnectionType.ClientSecret)
                {
                    DisplayControl<ConnectionClientSecretControl>();
                }
                else if (type == ConnectionType.Mfa)
                {
                    DisplayControl<ConnectionMfaControl>();
                }
            }
            else if (ctrl is ConnectionClientSecretControl ccsc)
            {
                CrmConnectionDetail.AzureAdAppId = ccsc.AzureAdAppId;
                CrmConnectionDetail.SavePassword = ccsc.SaveClientSecret;
                CrmConnectionDetail.NewAuthType = AuthenticationType.ClientSecret;

                if (ccsc.ClientSecretChanged)
                {
                    CrmConnectionDetail.SetClientSecret(ccsc.ClientSecret);
                }

                if (CrmConnectionDetail.AzureAdAppId == Guid.Empty
                    || CrmConnectionDetail.ClientSecretIsEmpty)
                {
                    MessageBox.Show(this,
                        @"Please provide all information for Client Id/Secret authentication",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!CrmConnectionDetail.ClientSecretIsEmpty)
                {
                    DisplayControl<ConnectionLoadingControl>();
                    Connect();
                }
            }
            else if (ctrl is ConnectionMfaControl cmfac)
            {
                CrmConnectionDetail.AzureAdAppId = cmfac.AzureAdAppId;
                CrmConnectionDetail.ReplyUrl = cmfac.ReplyUrl;
                CrmConnectionDetail.UserName = cmfac.Username;
                CrmConnectionDetail.AzureAdAppId = cmfac.AzureAdAppId;
                CrmConnectionDetail.NewAuthType = AuthenticationType.OAuth;
                CrmConnectionDetail.UseMfa = true;

                if (CrmConnectionDetail.AzureAdAppId == Guid.Empty
                    || string.IsNullOrEmpty(CrmConnectionDetail.ReplyUrl))
                {
                    MessageBox.Show(this,
                        @"Please provide at least Application Id and Reply Url for multi factor authentication",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DisplayControl<ConnectionLoadingControl>();
                Connect();
            }
            else if (ctrl is ConnectionCertificateControl ccertc)
            {
                CrmConnectionDetail.Certificate = new CertificateInfo
                {
                    Thumbprint = ccertc.Certificate.Thumbprint,
                    Issuer = ccertc.Certificate.Issuer,
                    Name = ccertc.Certificate.GetNameInfo(X509NameType.SimpleName, false)
                };

                CrmConnectionDetail.NewAuthType = AuthenticationType.Certificate;

                DisplayControl<ConnectionAppIdControl>();
            }
            else if (ctrl is ConnectionAppIdControl cac)
            {
                if (Guid.TryParse(cac.AppId, out Guid appId))
                {
                    CrmConnectionDetail.AzureAdAppId = appId;

                    DisplayControl<ConnectionLoadingControl>();
                    Connect();
                }
                else
                {
                    MessageBox.Show(this, @"Invalid Application Id", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CrmConnectionDetail = new ConnectionDetail(true);
            navigationHistory.Clear();
            DisplayControl<StartPageControl>();
        }

        #endregion Buttons events

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.xrmtoolbox.com/documentation/for-users/connecting-to-an-organization/");
        }

        private void Connect()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (bwSender, evt) =>
            {
                var currentDetail = (ConnectionDetail)evt.Argument;
                evt.Result = currentDetail.GetCrmServiceClient(true);
            };
            bw.RunWorkerCompleted += (bwSender, evt) =>
            {
                if (evt.Error != null)
                {
                    lastError = evt.Error.ToString();
                    DisplayControl<ConnectionFailedControl>();

                    return;
                }

                CrmServiceClient crmSvc = (CrmServiceClient)evt.Result;

                if (!crmSvc.IsReady)
                {
                    lastError = crmSvc.LastCrmError;
                    DisplayControl<ConnectionFailedControl>();

                    return;
                }

                CrmConnectionDetail.Organization = crmSvc.ConnectedOrgUniqueName;
                CrmConnectionDetail.OrganizationFriendlyName = crmSvc.ConnectedOrgFriendlyName;
                CrmConnectionDetail.OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();
                CrmConnectionDetail.OrganizationDataServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                CrmConnectionDetail.OrganizationServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                CrmConnectionDetail.ServiceClient = crmSvc;
                CrmConnectionDetail.UserName = CrmConnectionDetail.UserName?.Length > 0
                    ? CrmConnectionDetail.UserName
                    : crmSvc.OAuthUserId?.Length > 0
                        ? crmSvc.OAuthUserId
                        : CrmConnectionDetail.AzureAdAppId != Guid.Empty
                            ? CrmConnectionDetail.AzureAdAppId.ToString("B")
                            : null;

                DisplayControl<ConnectionSucceededControl>();
            };
            bw.RunWorkerAsync(CrmConnectionDetail);
        }

        private void ConnectionWizard2_Load(object sender, EventArgs e)
        {
            if (!isNew)
            {
                if (CrmConnectionDetail.UseConnectionString)
                {
                    DisplayControl<ConnectionStringControl>();
                }
                else if (CrmConnectionDetail.IsFromSdkLoginCtrl)
                {
                    // Should not be possible as updating a
                    // connection from the SDK login control
                    // is handled in ConnectionSelector class
                    DisplayControl<SdkLoginControlControl>();
                }
                else if (CrmConnectionDetail.Certificate != null)
                {
                    type = ConnectionType.Certificate;
                    DisplayControl<ConnectionUrlControl>();
                }
                else if (CrmConnectionDetail.NewAuthType == AuthenticationType.ClientSecret)
                {
                    type = ConnectionType.ClientSecret;
                    DisplayControl<ConnectionUrlControl>();
                }
                else if (CrmConnectionDetail.UseMfa)
                {
                    type = ConnectionType.Mfa;
                    DisplayControl<ConnectionUrlControl>();
                }
                else
                {
                    DisplayControl<ConnectionFirstStepControl>();
                }
            }
            else
            {
                DisplayControl<StartPageControl>();
            }
        }

        private void DisplayControl<T>() where T : IConnectionWizardControl
        {
            btnBack.Visible = navigationHistory.Count > 0;

            if (typeof(T) != typeof(ConnectionLoadingControl))
                navigationHistory.Add(typeof(T));

            llIconLink.Visible = false;

            if (typeof(T) == typeof(StartPageControl))
            {
                llIconLink.Visible = true;
                pnlFooter.Visible = false;
                lblHeader.Text = @"Choose a connection method";

                ctrl = new StartPageControl();
                ((StartPageControl)ctrl).TypeSelected += (sender, e) =>
                {
                    type = ((StartPageControl)ctrl).Type;

                    switch (((StartPageControl)ctrl).Type)
                    {
                        case ConnectionType.Wizard:
                            DisplayControl<ConnectionFirstStepControl>();
                            break;

                        case ConnectionType.Sdk:
                            DisplayControl<SdkLoginControlControl>();
                            break;

                        case ConnectionType.ConnectionString:
                            DisplayControl<ConnectionStringControl>();
                            break;

                        case ConnectionType.Certificate:
                            DisplayControl<ConnectionUrlControl>();
                            break;

                        case ConnectionType.ClientSecret:
                            DisplayControl<ConnectionUrlControl>();
                            break;

                        case ConnectionType.Mfa:
                            DisplayControl<ConnectionUrlControl>();
                            break;
                    }
                };

                btnReset.Visible = false;
                btnNext.Visible = false;
            }
            else if (typeof(T) == typeof(ConnectionFirstStepControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"General information and options";

                var timespan = CrmConnectionDetail?.Timeout;
                if (!timespan.HasValue || timespan.Value.Ticks == 0)
                {
                    timespan = new TimeSpan(0, 2, 0);
                }
                ctrl = new ConnectionFirstStepControl
                {
                    // Connection Properties
                    Url = CrmConnectionDetail?.OriginalUrl,
                    UseIntegratedAuth = !(CrmConnectionDetail?.IsCustomAuth ?? false),
                    Timeout = timespan.Value
                };

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionCredentialsControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"User credentials";

                ctrl = new ConnectionCredentialsControl
                {
                    // Connection Properties
                    Domain = CrmConnectionDetail?.UserDomain,
                    Username = CrmConnectionDetail?.UserName,
                    IsOnline = CrmConnectionDetail?.UseOnline ?? false,
                    PasswordIsSet = !CrmConnectionDetail?.PasswordIsEmpty ?? false,
                    SavePassword = CrmConnectionDetail?.SavePassword ?? false
                };

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionIfdControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Internet Facing Deployment settings";

                ctrl = new ConnectionIfdControl
                {
                    // Connection Properties
                    IsIfd = CrmConnectionDetail?.UseIfd ?? false,
                    HomeRealmUrl = CrmConnectionDetail?.HomeRealmUrl
                };

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionLoadingControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connecting...";

                ctrl = new ConnectionLoadingControl(CrmConnectionDetail);

                btnBack.Visible = false;
                btnReset.Visible = false;
                btnNext.Visible = false;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionSucceededControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connection validated!";

                ctrl = new ConnectionSucceededControl(parentFile)
                {
                    ConnectionName = CrmConnectionDetail.ConnectionName,
                    ConnectionDetail = CrmConnectionDetail
                };

                btnBack.Visible = true;
                btnReset.Visible = false;
                btnNext.Visible = true;
                btnNext.Text = @"Finish";
            }
            else if (typeof(T) == typeof(ConnectionFailedControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connection failed!";

                ctrl = new ConnectionFailedControl
                {
                    ErrorMEssage = lastError
                };

                btnBack.Visible = true;
                btnReset.Visible = true;
                btnNext.Visible = false;
                btnNext.Text = @"Finish";
            }
            else if (typeof(T) == typeof(ConnectionStringControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connectionstring settings";

                ctrl = new ConnectionStringControl
                {
                    ConnectionString = CrmConnectionDetail.ConnectionString
                };

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(SdkLoginControlControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Microsoft Login control";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new SdkLoginControlControl(CrmConnectionDetail.ConnectionId.Value, isNew);
                ((SdkLoginControlControl)ctrl).ConnectionSucceeded += (sender, evt) => { btnNext_Click(btnNext, null); };

                btnReset.Visible = true;
                btnNext.Visible = false;
            }
            else if (typeof(T) == typeof(ConnectionUrlControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Provide environment information";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new ConnectionUrlControl(CrmConnectionDetail);

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionCertificateControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connection with certificate";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new ConnectionCertificateControl(CrmConnectionDetail);

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionAppIdControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Application user Application ID";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new ConnectionAppIdControl();
                if (CrmConnectionDetail.AzureAdAppId != Guid.Empty)
                {
                    ((ConnectionAppIdControl)ctrl).AppId = CrmConnectionDetail.AzureAdAppId.ToString("B");
                }

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionClientSecretControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Client Id / Secret";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new ConnectionClientSecretControl();
                ((ConnectionClientSecretControl)ctrl).HasClientSecret = !CrmConnectionDetail.ClientSecretIsEmpty;
                if (CrmConnectionDetail.AzureAdAppId != Guid.Empty)
                {
                    ((ConnectionClientSecretControl)ctrl).AzureAdAppId = CrmConnectionDetail.AzureAdAppId;
                }
                ((ConnectionClientSecretControl)ctrl).SaveClientSecret = CrmConnectionDetail.SavePassword;

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Connect";
            }
            else if (typeof(T) == typeof(ConnectionMfaControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"OAuth Authentication";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new ConnectionMfaControl();
                ((ConnectionMfaControl)ctrl).Username = CrmConnectionDetail.UserName;
                ((ConnectionMfaControl)ctrl).ReplyUrl = CrmConnectionDetail.ReplyUrl;
                if (CrmConnectionDetail.AzureAdAppId != Guid.Empty)
                {
                    ((ConnectionMfaControl)ctrl).AzureAdAppId = CrmConnectionDetail.AzureAdAppId;
                }

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }

            ((UserControl)ctrl).Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add((UserControl)ctrl);

            CustomTheme.Instance.ApplyTheme(this);
        }

        private void llIconLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://icons8.com/icons/fluent");
        }
    }
}