using McTools.Xrm.Connection.WinForms.Properties;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class ConnectionWizard : Form
    {
        private const string PasswordTip = "Please specify the password";
        private const string DomainTip = "Provide domain name, possibly not mandatory for IFD connection";
        private const string UserTip = "Provide user name. For IFD connections, try domain\\username";
        private const string PasswordTemp = "@@PASSWORD@@";

        private readonly ConnectionDetail originalDetail;
        private readonly List<string> visitedPath;
        private CrmServiceClient serviceClient;
        private ConnectionDetail updatedDetail;
        private string initialDomainText;

        public ConnectionWizard(ConnectionDetail detail = null)
        {
            InitializeComponent();

            initialDomainText = txtDomain.Text;

            originalDetail = (ConnectionDetail)detail?.Clone();
            updatedDetail = new ConnectionDetail(true);

            visitedPath = new List<string> { pnlConnectUrl.Name };

            if (detail != null)
            {
                txtOrganizationUrl.Text = string.IsNullOrEmpty(detail.OriginalUrl) ? detail.WebApplicationUrl : detail.OriginalUrl;
                txtDomain.Text = detail.UserDomain;
                txtUsername.Text = detail.UserName;
                txtConnectionName.Text = detail.ConnectionName;
                chkSavePassword.Checked = detail.SavePassword;
                if (detail.PasswordIsEmpty || detail.SavePassword == false)
                {
                    txtPassword.PasswordChar = (char)0;
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.Text = PasswordTip;
                    txtPassword.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    txtPassword.PasswordChar = '•';
                    txtPassword.UseSystemPasswordChar = true;
                    txtPassword.Text = PasswordTemp;
                    txtPassword.ForeColor = SystemColors.ActiveCaptionText;
                }

                txtConnectionString.Text = detail.ConnectionString;
                txtHomeRealm.Text = detail.HomeRealmUrl;
                chkUseIntegratedAuthentication.Checked = !detail.IsCustomAuth;
                rbIfdYes.Checked = detail.UseIfd;
                txtTimeout.Text = string.Format("{0:dd\\.hh\\:mm\\:ss}", detail.Timeout);

                updatedDetail = (ConnectionDetail)originalDetail.Clone();

                lblHeader.Text = "Edit connection";

                if (originalDetail.UseConnectionString)
                {
                    llUseConnectionString_LinkClicked(null, null);
                }
            }
        }

        public ConnectionDetail CrmConnectionDetail { get { return updatedDetail; } }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            visitedPath.Remove(visitedPath.Last());

            if (visitedPath.Count == 0)
            {
                visitedPath.Add(pnlConnectUrl.Name);
                DisplayPanel(pnlConnectUrl, btnGo);
                return;
            }

            foreach (var ctrl in Controls)
            {
                var pnl = ctrl as Panel;
                if (pnl != null && pnl != pnlHeader)
                {
                    pnl.Visible = pnl.Name == visitedPath.Last();
                }
            }
        }

        private void btnConnectWithConnectionString_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text.Length == 0)
            {
                return;
            }

            if (!txtConnectionString.Text.EndsWith(";"))
            {
                txtConnectionString.Text += ";";
            }
            txtConnectionString.Text += "RequireNewInstance=True;";

            updatedDetail = new ConnectionDetail(true)
            {
                UseConnectionString = true,
                ConnectionString = txtConnectionString.Text
            };

            lblDescription.Text = Resources.ConnectionWizard_ConnectingHeaderDescription;
            DisplayPanel(pnlWaiting, null);
            Connect();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (serviceClient != null)
            {
                // This happens when the connection is created. When updating
                // a connection, the service client is not instanciated
                updatedDetail.Organization = serviceClient.ConnectedOrgUniqueName;
                updatedDetail.OrganizationFriendlyName = serviceClient.ConnectedOrgFriendlyName;
                updatedDetail.OrganizationUrlName = updatedDetail.OrganizationUrlName;
                updatedDetail.OrganizationVersion = serviceClient.ConnectedOrgVersion.ToString();
                updatedDetail.OrganizationDataServiceUrl = serviceClient.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                updatedDetail.OrganizationServiceUrl = serviceClient.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
            }

            updatedDetail.ConnectionName = txtConnectionName.Text;
            updatedDetail.ServiceClient = serviceClient;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Uri uri;
            if (!Uri.TryCreate(txtOrganizationUrl.Text, UriKind.Absolute, out uri))
            {
                MessageBox.Show(Resources.ConnectionWizard_InvalidUrl);
                return;
            }

            txtOrganizationUrl.Text = txtOrganizationUrl.Text.Trim();
            txtOrganizationUrl.Text = txtOrganizationUrl.Text.EndsWith("/")
                ? txtOrganizationUrl.Text.Remove(txtOrganizationUrl.Text.Length - 1, 1)
                : txtOrganizationUrl.Text;

            updatedDetail.OriginalUrl = txtOrganizationUrl.Text.ToLower();

            TimeSpan timeOut;
            if (!TimeSpan.TryParse(txtTimeout.Text, CultureInfo.InvariantCulture, out timeOut))
            {
                MessageBox.Show(this, Resources.ConnectionWizard_InvalidTimeoutValue, Resources.ConnectionWizard_WarningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updatedDetail.Timeout = timeOut;
            updatedDetail.UseSsl = updatedDetail.OriginalUrl.StartsWith("https");

            var urlWithoutProtocol = updatedDetail.OriginalUrl.Remove(0, updatedDetail.UseSsl ? 8 : 7);
            var urlParts = urlWithoutProtocol.Split('/');
            var host = urlParts[0];
            var hostParts = host.Split(':');

            updatedDetail.ServerName = hostParts[0];
            updatedDetail.ServerPort = hostParts.Length == 2 ? int.Parse(hostParts[1]) : new int?();
            if (!updatedDetail.ServerPort.HasValue)
            {
                updatedDetail.ServerPort = updatedDetail.UseSsl ? 443 : 80;
            }

            updatedDetail.OrganizationUrlName = urlParts.Length > 1 && !urlParts[1].ToLower().StartsWith("main.aspx") ? urlParts[1] : null;
            updatedDetail.IsCustomAuth = !chkUseIntegratedAuthentication.Checked;

            txtDomain.Enabled = true;

            if (updatedDetail.OrganizationUrlName == null)
            {
                IPAddress ipa;
                if (!IPAddress.TryParse(updatedDetail.ServerName, out ipa))
                {
                    updatedDetail.OrganizationUrlName = updatedDetail.ServerName.Split('.')[0];
                }

                if (updatedDetail.ServerName.IndexOf("dynamics.com", StringComparison.Ordinal) > 0)
                {
                    updatedDetail.UseOnline = true;
                    updatedDetail.UseOsdp = true;

                    txtDomain.Enabled = false;
                    lblDescription.Text = Resources.ConnectionWizard_CredentialsHeaderDescription;
                    DisplayPanel(pnlConnectAuthentication, btnConnect);

                    if (txtDomain.Enabled)
                    {
                        txtDomain.Focus();
                    }
                    else
                    {
                        txtUsername.Focus();
                    }
                }
                else
                {
                    // IFD or AD??
                    // Requires additional information
                    visitedPath.Add(pnlConnectMoreActiveDirectoryInfo.Name);

                    lblDescription.Text = Resources.ConnectionWizard_IfdSelectionHeaderDescription;
                    DisplayPanel(pnlConnectMoreActiveDirectoryInfo, btnValidateIfdInfo);
                    rbIfdNo.Focus();
                }
            }
            else
            {
                if (chkUseIntegratedAuthentication.Checked)
                {
                    if (updatedDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
                    {
                        lblDescription.Text = Resources.ConnectionWizard_ConnectingHeaderDescription;
                        DisplayPanel(pnlWaiting, null);
                        Connect();
                    }
                    else
                    {
                        lblDescription.Text = Resources.ConnectionWizard_SuccessHeaderDescription;
                        DisplayPanel(pnlConnected, btnFinish);
                        txtConnectionName.Focus();
                    }
                }
                else
                {
                    visitedPath.Add(pnlConnectAuthentication.Name);
                    lblDescription.Text = Resources.ConnectionWizard_CredentialsHeaderDescription;
                    DisplayPanel(pnlConnectAuthentication, btnConnect);
                    if (txtDomain.Enabled)
                    {
                        txtDomain.Focus();
                    }
                    else
                    {
                        txtUsername.Focus();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            updatedDetail = new ConnectionDetail(true);
            txtOrganizationUrl.Text = string.Empty;
            txtHomeRealm.Text = string.Empty;
            txtDomain.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            visitedPath.Clear();
            visitedPath.Add(pnlConnectUrl.Name);

            lblDescription.Text = Resources.ConnectionWizard_EnterUrlHeaderDescription;
            txtOrganizationUrl.Focus();
            DisplayPanel(pnlConnectUrl, btnGo);
        }

        private void btnValidaIfdInfo_Click(object sender, EventArgs e)
        {
            if (rbIfdYes.Checked)
            {
                updatedDetail.UseIfd = true;
                updatedDetail.HomeRealmUrl = txtHomeRealm.Text;
            }

            if (updatedDetail.OrganizationUrlName == null || updatedDetail.OrganizationUrlName == updatedDetail.ServerName)
            {
                lblDescription.Text = Resources.ConnectionWizard_EnterUrlHeaderDescription;

                if (!updatedDetail.UseIfd)
                {
                    MessageBox.Show(this,
                        Resources.ConnectionWizard_UnableToDetermineOrganization,
                        Resources.ConnectionWizard_WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtOrganizationUrl.Focus();
                    DisplayPanel(pnlConnectUrl, btnGo);
                    return;
                }

                updatedDetail.OrganizationUrlName = updatedDetail.ServerName.Split('.')[0];

                if (updatedDetail.OrganizationUrlName == updatedDetail.ServerName)
                {
                    MessageBox.Show(this,
                        Resources.ConnectionWizard_InvalidIfUrl,
                        Resources.ConnectionWizard_WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtOrganizationUrl.Focus();
                    DisplayPanel(pnlConnectUrl, btnGo);
                    return;
                }
            }

            if (updatedDetail.UseIfd || updatedDetail.IsCustomAuth)
            {
                visitedPath.Add(pnlConnectAuthentication.Name);
                lblDescription.Text = Resources.ConnectionWizard_CredentialsHeaderDescription;
                DisplayPanel(pnlConnectAuthentication, btnConnect);

                if (txtDomain.Enabled)
                {
                    txtDomain.Focus();
                }
                else
                {
                    txtUsername.Focus();
                }
            }
            else
            {
                lblDescription.Text = Resources.ConnectionWizard_ConnectingHeaderDescription;
                DisplayPanel(pnlWaiting, null);

                Connect();
            }
        }

        private void chkUseIntegratedAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            btnGo.Text = chkUseIntegratedAuthentication.Checked ? "Connect" : "Go";
        }

        private void Connect()
        {
            visitedPath.Add(pnlWaiting.Name);

            var bw = new BackgroundWorker();
            bw.DoWork += (bwSender, evt) =>
            {
                var detail = (ConnectionDetail)evt.Argument;
                evt.Result = detail.GetCrmServiceClient(true);
            };
            bw.RunWorkerCompleted += (bwSender, evt) =>
            {
                if (evt.Error != null)
                {
                    lblDescription.Text = Resources.ConnectionWizard_ErrorHeaderDescription;

                    lblError.Text = evt.Error.Message;

                    if (updatedDetail.UseOsdp)
                    {
                        lblError.Text += "\r\nIf the unique name for your organization is different from the name used in the url you provided, please replace the organization name in the url with the organization unique name";
                    }

                    DisplayPanel(pnlError, null);

                    return;
                }

                CrmServiceClient crmSvc = (CrmServiceClient)evt.Result;

                if (!crmSvc.IsReady)
                {
                    lblDescription.Text = Resources.ConnectionWizard_ErrorHeaderDescription;

                    lblError.Text = crmSvc.LastCrmError;

                    DisplayPanel(pnlError, null);

                    return;
                }

                lblDescription.Text = Resources.ConnectionWizard_SuccessHeaderDescription;

                DisplayPanel(pnlConnected, btnFinish);
                txtConnectionName.Focus();

                serviceClient = crmSvc;
            };
            bw.RunWorkerAsync(updatedDetail);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            // Check data if authentication panel is the current displayed one
            if (pnlConnectAuthentication.Visible)
            {
                if (string.IsNullOrEmpty(txtUsername.Text)
                    || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(this, Resources.ConnectionWizard_PleaseEnterCredentials,
                        Resources.ConnectionWizard_WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            updatedDetail.UserDomain = txtDomain.Text != initialDomainText ? txtDomain.Text : "";
            updatedDetail.UserName = txtUsername.Text;
            updatedDetail.SavePassword = chkSavePassword.Checked;
            if (txtPassword.Text != PasswordTemp)
            {
                updatedDetail.SetPassword(txtPassword.Text);
            }

            if (originalDetail == null)
            {
                lblDescription.Text = Resources.ConnectionWizard_ConnectingHeaderDescription;
                DisplayPanel(pnlWaiting, null);

                Connect();
            }
            else if (updatedDetail.IsConnectionBrokenWithUpdatedData(originalDetail))
            {
                if (DialogResult.Yes == MessageBox.Show(this, Resources.ConnectionWizard_NeedToTestConnectionAgain,
                        Resources.ConnectionWizard_QuestionHeaderTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    lblDescription.Text = Resources.ConnectionWizard_ConnectingHeaderDescription;
                    DisplayPanel(pnlWaiting, null);

                    Connect();
                }
            }
            else
            {
                lblDescription.Text = Resources.ConnectionWizard_SuccessHeaderDescription;
                DisplayPanel(pnlConnected, btnFinish);
                txtConnectionName.Focus();
            }
        }

        private void DisplayPanel(Panel panel, Button acceptButton)
        {
            foreach (var ctrl in Controls)
            {
                var pnl = ctrl as Panel;
                if (pnl != null && pnl != pnlHeader)
                {
                    pnl.Visible = pnl == panel;
                }
            }
            AcceptButton = acceptButton;
        }

        private void llConnectionStringHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("https://msdn.microsoft.com/{0}/library/mt608573.aspx", CultureInfo.CurrentUICulture.Name));

            txtConnectionString.Focus();
        }

        private void llUseConnectionString_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            visitedPath.Add(pnlConnectWithConnectionString.Name);

            lblDescription.Text = Resources.ConnectionWizard_ConnectionStringConnectionHeaderDescription;

            DisplayPanel(pnlConnectWithConnectionString, btnConnectWithConnectionString);

            txtConnectionString.Focus();
        }

        private void rbIfdYes_CheckedChanged(object sender, EventArgs e)
        {
            txtHomeRealm.Enabled = rbIfdYes.Checked;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFinish_Click(null, null);
            }
        }

        private void txtOrganizationUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(null, null);
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (txt.ForeColor == SystemColors.GrayText)
            {
                if (txt == txtDomain && txt.Text == DomainTip || 
                    txt == txtUsername && txt.Text == UserTip)
                {
                    txt.Text = string.Empty;
                }

                txt.ForeColor = SystemColors.ActiveCaptionText;

                if (txt == txtPassword)
                {
                    txt.Text = string.Empty;
                    txt.UseSystemPasswordChar = true;
                    txt.PasswordChar = '•';
                }
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;

            if (txt.Text.Length == 0)
            {
                txt.ForeColor = SystemColors.GrayText;
                if (txt == txtDomain)
                {
                    txt.Text = DomainTip;
                }
                else if (txt == txtUsername)
                {
                    txt.Text = UserTip;
                }
                else if (txt == txtPassword)
                {
                    txt.PasswordChar = '\0';
                    txt.UseSystemPasswordChar = false;
                    txt.Text = "Type your password here";
                }
            }
        }

        private void llOpenConnectionLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Log folder is defined by configuration file and follows Microsoft
            // SDK tools configuration. It stores connection log file in path
            // path\Company\Product\Version
            var assembly = Assembly.GetEntryAssembly();
            var companyName = ((AssemblyCompanyAttribute)assembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute))).Company;
            var productName = ((AssemblyProductAttribute)assembly.GetCustomAttribute(typeof(AssemblyProductAttribute))).Product;
            var version = assembly.GetName().Version.ToString();

            var logFolder = string.Format("{0}\\{1}\\{2}\\{3}", 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                companyName,
                productName,
                version);

            if (string.IsNullOrEmpty(logFolder))
            {
                MessageBox.Show(this, "There is no connection log folder available currently!");
            }
            else
            {
                Process.Start(logFolder);
            }
        }
    }
}