using McTools.Xrm.Connection.WinForms.CustomControls;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class ConnectionWizard2 : Form
    {
        private readonly bool isNew;
        private readonly List<Type> navigationHistory = new List<Type>();
        private IConnectionWizardControl ctrl;
        private string lastError;
        private ConnectionDetail originalDetail;

        public ConnectionWizard2(ConnectionDetail detail = null)
        {
            InitializeComponent();

            isNew = detail == null;
            originalDetail = (ConnectionDetail)detail?.Clone();
            CrmConnectionDetail = detail ?? new ConnectionDetail(true);

            Text = originalDetail == null ? "New connection" : "Update connection";

            btnBack.Visible = false;
            btnReset.Visible = false;
        }

        public ConnectionDetail CrmConnectionDetail { get; private set; }

        public sealed override string Text
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
            else if (type == typeof(ConnectionOauthControl))
                DisplayControl<ConnectionOauthControl>();
            else if (type == typeof(ConnectionStringControl))
                DisplayControl<ConnectionStringControl>();
            else if (type == typeof(ConnectionSucceededControl))
                DisplayControl<ConnectionSucceededControl>();
            else if (type == typeof(SdkLoginControlControl))
                DisplayControl<SdkLoginControlControl>();
            else if (type == typeof(StartPageControl))
                DisplayControl<StartPageControl>();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrl is ConnectionFirstStepControl cfsc)
            {
                CrmConnectionDetail.OriginalUrl = cfsc.Url;
                CrmConnectionDetail.IsCustomAuth = !cfsc.UseIntegratedAuth;
                CrmConnectionDetail.UseMfa = cfsc.UseMfa;
                CrmConnectionDetail.UseSsl = cfsc.UseSsl;
                CrmConnectionDetail.ServerName = cfsc.HostName;
                CrmConnectionDetail.ServerPort = cfsc.HostPort;
                CrmConnectionDetail.OrganizationUrlName = cfsc.OrganizationUrlName;
                CrmConnectionDetail.UseOnline = CrmConnectionDetail.OriginalUrl.ToLower().Contains(".dynamics.com");
                CrmConnectionDetail.UseOsdp = CrmConnectionDetail.UseOnline;
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
                        if (CrmConnectionDetail.IsCustomAuth)
                        {
                            if (CrmConnectionDetail.UseMfa)
                            {
                                DisplayControl<ConnectionOauthControl>();
                            }
                            else if (!CrmConnectionDetail.UseOnline && CrmConnectionDetail.OriginalUrl.Split('.').Length > 1)
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
                        if (CrmConnectionDetail.UseMfa)
                        {
                            DisplayControl<ConnectionOauthControl>();
                        }
                        else if (!CrmConnectionDetail.UseOnline && CrmConnectionDetail.OriginalUrl.Split('.').Length > 1)
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
                            @"We were unable to determine the organization name based on the information you specified. Please complete the url to add the organization name inside",
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
            else if (ctrl is ConnectionOauthControl coc)
            {
                CrmConnectionDetail.AzureAdAppId = coc.AzureAdAppId;
                CrmConnectionDetail.ReplyUrl = coc.ReplyUrl;
                CrmConnectionDetail.S2SClientSecret = coc.ClientSecret;
                CrmConnectionDetail.RefreshToken = coc.RefreshToken;

                if (CrmConnectionDetail.AzureAdAppId == Guid.Empty
                    || string.IsNullOrEmpty(CrmConnectionDetail.ReplyUrl))
                {
                    MessageBox.Show(this,
                        @"Please provide all information for OAuth authentication",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!String.IsNullOrEmpty(CrmConnectionDetail.S2SClientSecret))
                {
                    CrmConnectionDetail.IsCustomAuth = false;
                    DisplayControl<ConnectionLoadingControl>();
                    Connect();
                }
                else
                {
                    DisplayControl<ConnectionCredentialsControl>();
                }
            }
            else if (ctrl is ConnectionStringControl csc)
            {
                CrmConnectionDetail.ConnectionString = csc.ConnectionString;

                DisplayControl<ConnectionLoadingControl>();
                Connect();
            }
            else if (ctrl is ConnectionSucceededControl cokc)
            {
                CrmConnectionDetail.ConnectionName = cokc.ConnectionName;

                DialogResult = DialogResult.OK;
                Close();
            }
            else if (ctrl is SdkLoginControlControl slcc)
            {
                CrmConnectionDetail.IsFromSdkLoginCtrl = true;
                CrmConnectionDetail.AuthType = slcc.AuthType;
                CrmConnectionDetail.UseOnline = slcc.AuthType == AuthenticationProviderType.OnlineFederation;
                CrmConnectionDetail.UseIfd = slcc.AuthType == AuthenticationProviderType.Federation;
                CrmConnectionDetail.Organization = slcc.ConnectionManager.ConnectedOrgUniqueName;
                CrmConnectionDetail.OrganizationFriendlyName = slcc.ConnectionManager.ConnectedOrgFriendlyName;
                CrmConnectionDetail.OrganizationDataServiceUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                CrmConnectionDetail.OrganizationServiceUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                CrmConnectionDetail.WebApplicationUrl =
                    slcc.ConnectionManager.ConnectedOrgPublishedEndpoints[EndpointType.WebApplication];
                CrmConnectionDetail.ServerName = new Uri(CrmConnectionDetail.WebApplicationUrl).Host;
                CrmConnectionDetail.OrganizationVersion = slcc.ConnectionManager.CrmSvc.ConnectedOrgVersion.ToString();
                CrmConnectionDetail.ServiceClient = slcc.ConnectionManager.CrmSvc;
                if (!string.IsNullOrEmpty(slcc.ConnectionManager.ClientId))
                {
                    CrmConnectionDetail.AzureAdAppId = new Guid(slcc.ConnectionManager.ClientId);
                    CrmConnectionDetail.ReplyUrl = slcc.ConnectionManager.RedirectUri.AbsoluteUri;
                }

                if (CrmConnectionDetail.ServiceClient.OrganizationServiceProxy != null)
                {
                    CrmConnectionDetail.UserName =
                        CrmConnectionDetail.ServiceClient.OrganizationServiceProxy.ClientCredentials.UserName.UserName ??
                        CrmConnectionDetail.ServiceClient.OrganizationServiceProxy.ClientCredentials.Windows.ClientCredential
                            .UserName;
                }
                else if (CrmConnectionDetail.ServiceClient.OrganizationWebProxyClient != null)
                {
                    CrmConnectionDetail.UserName = CrmConnectionDetail.ServiceClient.OAuthUserId;
                }

                DisplayControl<ConnectionSucceededControl>();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CrmConnectionDetail = new ConnectionDetail(true);
            navigationHistory.Clear();
            DisplayControl<StartPageControl>();
        }

        #endregion Buttons events

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
                    lastError = evt.Error.Message;
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
                CrmConnectionDetail.OrganizationUrlName = CrmConnectionDetail.OrganizationUrlName;
                CrmConnectionDetail.OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();
                CrmConnectionDetail.OrganizationDataServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                CrmConnectionDetail.OrganizationServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                CrmConnectionDetail.ServiceClient = crmSvc;

                DisplayControl<ConnectionSucceededControl>();
            };
            bw.RunWorkerAsync(CrmConnectionDetail);
        }

        private void ConnectionWizard2_Load(object sender, EventArgs e)
        {
            if (CrmConnectionDetail != null)
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
            navigationHistory.Add(typeof(T));

            if (typeof(T) == typeof(StartPageControl))
            {
                pnlFooter.Visible = false;
                lblHeader.Text = @"Choose a connection method";

                ctrl = new StartPageControl();
                ((StartPageControl)ctrl).TypeSelected += (sender, e) =>
               {
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
                    UseIntegratedAuth = !isNew && !(CrmConnectionDetail?.IsCustomAuth ?? true),
                    UseMfa = CrmConnectionDetail?.UseMfa ?? false,
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

                ctrl = new ConnectionLoadingControl();

                btnReset.Visible = false;
                btnNext.Visible = false;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionSucceededControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"Connection validated!";

                ctrl = new ConnectionSucceededControl
                {
                    ConnectionName = CrmConnectionDetail.ConnectionName,
                    ConnectionDetail = CrmConnectionDetail
                };

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
            else if (typeof(T) == typeof(ConnectionOauthControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"OAuth protocol settings";

                ctrl = new ConnectionOauthControl
                {
                    AzureAdAppId = CrmConnectionDetail.AzureAdAppId,
                    ReplyUrl = CrmConnectionDetail.ReplyUrl,
                    ClientSecret = CrmConnectionDetail.S2SClientSecret,
                    RefreshToken = CrmConnectionDetail.RefreshToken
                };

                btnReset.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(SdkLoginControlControl))
            {
                pnlFooter.Visible = true;
                lblHeader.Text = @"SDK Login control (Preview)";

                if (!CrmConnectionDetail.ConnectionId.HasValue)
                {
                    CrmConnectionDetail.ConnectionId = Guid.NewGuid();
                }

                ctrl = new SdkLoginControlControl(CrmConnectionDetail.ConnectionId.Value, isNew);
                ((SdkLoginControlControl)ctrl).ConnectionSucceeded += (sender, evt) => { btnNext_Click(btnNext, null); };

                btnReset.Visible = true;
                btnNext.Visible = false;
            }

        ((UserControl)ctrl).Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add((UserControl)ctrl);
        }
    }
}