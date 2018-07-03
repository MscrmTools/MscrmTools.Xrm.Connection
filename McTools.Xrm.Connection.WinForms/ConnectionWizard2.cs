using McTools.Xrm.Connection.WinForms.CustomControls;
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
        private readonly List<Type> navigationHistory = new List<Type> { typeof(ConnectionFirstStepControl) };
        private IConnectionWizardControl ctrl;
        private string lastError;
        private ConnectionDetail originalDetail;
        private ConnectionDetail updatedDetail;

        public ConnectionWizard2(ConnectionDetail detail = null)
        {
            InitializeComponent();

            isNew = detail == null;
            originalDetail = (ConnectionDetail)detail?.Clone();
            updatedDetail = detail ?? new ConnectionDetail(true);

            Text = originalDetail == null ? "New connection" : "Update connection";

            if (originalDetail != null && originalDetail.ConnectionString.Length > 0)
            {
                llConnectionString_LinkClicked(null, null);
                return;
            }

            btnBack.Visible = false;
            btnReset.Visible = false;
        }

        public ConnectionDetail CrmConnectionDetail => updatedDetail;

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        #region Buttons events

        private void btnBack_Click(object sender, EventArgs e)
        {
            var type = navigationHistory.Last();

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

            navigationHistory.RemoveAt(navigationHistory.Count - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrl is ConnectionFirstStepControl cfsc)
            {
                navigationHistory.Add(cfsc.GetType());

                updatedDetail.OriginalUrl = cfsc.Url;
                updatedDetail.IsCustomAuth = !cfsc.UseIntegratedAuth;
                updatedDetail.UseMfa = cfsc.UseMfa;
                updatedDetail.UseSsl = cfsc.UseSsl;
                updatedDetail.ServerName = cfsc.HostName;
                updatedDetail.ServerPort = cfsc.HostPort;
                updatedDetail.OrganizationUrlName = cfsc.OrganizationUrlName;
                updatedDetail.UseOnline = updatedDetail.OriginalUrl.ToLower().Contains(".dynamics.com");
                updatedDetail.UseOsdp = updatedDetail.UseOnline;
                updatedDetail.Timeout = cfsc.Timeout;

                if (updatedDetail.Timeout.Ticks == 0 || updatedDetail.ServerName == null) return;

                if (updatedDetail.OrganizationUrlName == null)
                {
                    if (!IPAddress.TryParse(updatedDetail.ServerName, out _))
                    {
                        if (updatedDetail.ServerName.Split('.').Length > 1)
                            updatedDetail.OrganizationUrlName = updatedDetail.ServerName.Split('.')[0];
                    }

                    if (updatedDetail.UseOnline)
                    {
                        if (updatedDetail.IsCustomAuth)
                        {
                            if (updatedDetail.UseMfa)
                            {
                                DisplayControl<ConnectionOauthControl>();
                            }
                            else if (!updatedDetail.UseOnline && updatedDetail.OriginalUrl.Split('.').Length > 1)
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
                    if (updatedDetail.IsCustomAuth)
                    {
                        if (updatedDetail.UseMfa)
                        {
                            DisplayControl<ConnectionOauthControl>();
                        }
                        else if (!updatedDetail.UseOnline && updatedDetail.OriginalUrl.Split('.').Length > 1)
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
                navigationHistory.Add(ccc.GetType());

                updatedDetail.UserDomain = ccc.Domain;
                updatedDetail.UserName = ccc.Username;
                updatedDetail.SavePassword = ccc.SavePassword;

                if (ccc.PasswordChanged)
                {
                    updatedDetail.SetPassword(ccc.Password);
                }

                if (string.IsNullOrEmpty(updatedDetail.UserName)
                    || updatedDetail.PasswordIsEmpty)
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
                else if (updatedDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
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
                navigationHistory.Add(cic.GetType());

                updatedDetail.UseIfd = cic.IsIfd;
                updatedDetail.HomeRealmUrl = cic.HomeRealmUrl;

                if (updatedDetail.OrganizationUrlName == null)
                {
                    if (!updatedDetail.UseIfd)
                    {
                        MessageBox.Show(this,
                            @"We were unable to determine the organization name based on the information you specified. Please complete the url to add the organization name inside",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        DisplayControl<ConnectionFirstStepControl>();
                        return;
                    }

                    updatedDetail.OrganizationUrlName = updatedDetail.ServerName.Split('.')[0];

                    if (updatedDetail.OrganizationUrlName == updatedDetail.ServerName)
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

                if (updatedDetail.IsCustomAuth)
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
                    if (updatedDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
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
                navigationHistory.Add(coc.GetType());

                updatedDetail.AzureAdAppId = coc.AzureAdAppId;
                updatedDetail.ReplyUrl = coc.ReplyUrl;

                if (updatedDetail.AzureAdAppId == Guid.Empty
                    || string.IsNullOrEmpty(updatedDetail.ReplyUrl))
                {
                    MessageBox.Show(this,
                        @"Please provide all information for OAuth authentication",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DisplayControl<ConnectionCredentialsControl>();
            }
            else if (ctrl is ConnectionStringControl csc)
            {
                navigationHistory.Add(csc.GetType());

                updatedDetail.ConnectionString = csc.ConnectionString;

                DisplayControl<ConnectionLoadingControl>();
                Connect();
            }
            else if (ctrl is ConnectionSucceededControl cokc)
            {
                navigationHistory.Add(cokc.GetType());

                updatedDetail.ConnectionName = cokc.ConnectionName;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            updatedDetail = new ConnectionDetail(true);
            DisplayControl<ConnectionFirstStepControl>();
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

                updatedDetail.Organization = crmSvc.ConnectedOrgUniqueName;
                updatedDetail.OrganizationFriendlyName = crmSvc.ConnectedOrgFriendlyName;
                updatedDetail.OrganizationUrlName = updatedDetail.OrganizationUrlName;
                updatedDetail.OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();
                updatedDetail.OrganizationDataServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                updatedDetail.OrganizationServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                updatedDetail.ServiceClient = crmSvc;

                DisplayControl<ConnectionSucceededControl>();
            };
            bw.RunWorkerAsync(updatedDetail);
        }

        private void ConnectionWizard2_Load(object sender, EventArgs e)
        {
            DisplayControl<ConnectionFirstStepControl>();
        }

        private void DisplayControl<T>() where T : IConnectionWizardControl
        {
            if (typeof(T) == typeof(ConnectionFirstStepControl))
            {
                lblHeader.Text = @"General information and options";

                var timespan = updatedDetail?.Timeout;
                if (!timespan.HasValue || timespan.Value.Ticks == 0)
                {
                    timespan = new TimeSpan(0, 2, 0);
                }
                ctrl = new ConnectionFirstStepControl
                {
                    // Connection Properties
                    Url = updatedDetail?.OriginalUrl,
                    UseIntegratedAuth = !isNew && !(updatedDetail?.IsCustomAuth ?? true),
                    UseMfa = updatedDetail?.UseMfa ?? false,
                    Timeout = timespan.Value
                };

                llConnectionString.Visible = true;
                btnBack.Visible = false;
                btnReset.Visible = false;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionCredentialsControl))
            {
                lblHeader.Text = @"User credentials";

                ctrl = new ConnectionCredentialsControl
                {
                    // Connection Properties
                    Domain = updatedDetail?.UserDomain,
                    Username = updatedDetail?.UserName,
                    IsOnline = updatedDetail?.UseOnline ?? false,
                    PasswordIsSet = !updatedDetail?.PasswordIsEmpty ?? false,
                    SavePassword = updatedDetail?.SavePassword ?? false
                };

                llConnectionString.Visible = false;
                btnReset.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionIfdControl))
            {
                lblHeader.Text = @"Internet Facing Deployment settings";

                ctrl = new ConnectionIfdControl
                {
                    // Connection Properties
                    IsIfd = updatedDetail?.UseIfd ?? false,
                    HomeRealmUrl = updatedDetail?.HomeRealmUrl
                };

                llConnectionString.Visible = false;
                btnReset.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionLoadingControl))
            {
                lblHeader.Text = @"Connecting...";

                ctrl = new ConnectionLoadingControl();

                llConnectionString.Visible = false;
                btnReset.Visible = false;
                btnBack.Visible = false;
                btnNext.Visible = false;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionSucceededControl))
            {
                lblHeader.Text = @"Connection validated!";

                ctrl = new ConnectionSucceededControl
                {
                    ConnectionName = updatedDetail.ConnectionName,
                    ConnectionDetail = updatedDetail
                };

                llConnectionString.Visible = false;
                btnReset.Visible = false;
                btnBack.Visible = false;
                btnNext.Visible = true;
                btnNext.Text = @"Finish";
            }
            else if (typeof(T) == typeof(ConnectionFailedControl))
            {
                lblHeader.Text = @"Connection failed!";

                ctrl = new ConnectionFailedControl
                {
                    ErrorMEssage = lastError
                };

                llConnectionString.Visible = false;
                btnReset.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = false;
                btnNext.Text = @"Finish";
            }
            else if (typeof(T) == typeof(ConnectionStringControl))
            {
                lblHeader.Text = @"Connectionstring settings";

                ctrl = new ConnectionStringControl
                {
                    ConnectionString = updatedDetail.ConnectionString
                };

                llConnectionString.Visible = false;
                btnReset.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }
            else if (typeof(T) == typeof(ConnectionOauthControl))
            {
                lblHeader.Text = @"OAuth protocol settings";

                ctrl = new ConnectionOauthControl
                {
                    AzureAdAppId = updatedDetail.AzureAdAppId,
                    ReplyUrl = updatedDetail.ReplyUrl
                };

                llConnectionString.Visible = false;
                btnReset.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnNext.Text = @"Next";
            }

        ((UserControl)ctrl).Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add((UserControl)ctrl);
        }

        private void llConnectionString_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayControl<ConnectionStringControl>();
        }
    }
}