using McTools.Xrm.Connection.WinForms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.TestWinForm
{
    public partial class Form1 : Form
    {
        #region Variables

        /// <summary>
        /// Connection control
        /// </summary>
        private CrmConnectionStatusBar ccsb;

        /// <summary>
        /// Connection manager
        /// </summary>
        private ConnectionManager cManager;

        private int connectionCount = 0;
        private ConnectionDetail currentDetail;
        private FormHelper formHelper;

        /// <summary>
        /// Dynamics CRM 2011 organization service
        /// </summary>
        private IOrganizationService service;

        #endregion Variables

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            // Create the connection manager with its events
            this.cManager = ConnectionManager.Instance;
            this.cManager.FromXrmToolBox = true;
            this.cManager.ConnectionSucceed += new ConnectionManager.ConnectionSucceedEventHandler(cManager_ConnectionSucceed);
            this.cManager.ConnectionFailed += new ConnectionManager.ConnectionFailedEventHandler(cManager_ConnectionFailed);
            this.cManager.StepChanged += new ConnectionManager.StepChangedEventHandler(cManager_StepChanged);
            this.cManager.RequestPassword += new ConnectionManager.RequestPasswordEventHandler(cManager_RequestPassword);
            formHelper = new FormHelper(this);
            // formHelper.UseDarkTheme = true;

            // Instantiate and add the connection control to the form
            ccsb = new CrmConnectionStatusBar(formHelper, tsbMergeConnectionsFiles.Checked);
            this.Controls.Add(ccsb);

            this.ccsb.SetMessage("A message to display...");
        }

        private bool cManager_RequestPassword(object sender, RequestPasswordEventArgs e)
        {
            return formHelper.RequestPassword(e.ConnectionDetail);
        }

        #endregion Constructor

        #region Connection event handlers

        /// <summary>
        /// Occurs when the connection to a server failed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cManager_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            // Set error message
            this.ccsb.SetMessage("Error: " + e.FailureReason);

            // Clear the current organization service
            this.service = null;
        }

        /// <summary>
        /// Occurs when the connection to a server succeed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cManager_ConnectionSucceed(object sender, ConnectionSucceedEventArgs e)
        {
            connectionCount++;
            ccsb.RebuildConnectionList();

            // Store connection Organization Service
            this.service = e.OrganizationService;
            currentDetail = e.ConnectionDetail;
            currentDetail.OnImpersonate += CurrentDetail_OnImpersonate;

            // Displays connection status
            this.ccsb.SetConnectionStatus(true, e.ConnectionDetail);

            // Clear the current action message
            this.ccsb.SetMessage(string.Empty);

            lbLogs.Items.Add($"Connected to {e.ConnectionDetail.ConnectionName}");

            if (connectionCount == e.NumberOfConnectionsRequested && e.NumberOfConnectionsRequested > 1)
            {
                lbLogs.Items.Add("All connections done!");
            }

            // Do action if needed
            if (e.Parameter != null)
            {
                if (e.Parameter.ToString() == "WhoAmI")
                {
                    WhoAmI();
                }
            }
        }

        /// <summary>
        /// Occurs when the connection manager sends a step change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cManager_StepChanged(object sender, StepChangedEventArgs e)
        {
            this.ccsb.SetMessage(e.CurrentStep);
        }

        private void CurrentDetail_OnImpersonate(object sender, AppCode.ImpersonationEventArgs e)
        {
            MessageBox.Show("Impersonated as " + (e.UserName ?? "yourself"));
        }

        #endregion Connection event handlers

        #region WhoAmI Sample methods

        private void btnWhoAmI_Click(object sender, EventArgs e)
        {
            if (this.service == null)
            {
                formHelper.AskForConnection("WhoAmI", (listDetails) =>
                    {
                        lbLogs.Items.Add($"Connection requested to {listDetails.First().ConnectionName}");
                    });
            }
            else
            {
                WhoAmI();
            }
        }

        private void WhoAmI()
        {
            int i = 0;

            lblEnvName.ForeColor = currentDetail.EnvironmentHighlightingInfo?.TextColor ?? DefaultForeColor;
            lblEnvName.Text = ($"{currentDetail.EnvironmentHighlightingInfo?.Text ?? ""} - {currentDetail.ConnectionName}");

            if (currentDetail.ParentConnectionFile != null)
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(currentDetail.ParentConnectionFile.Base64Image);

                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                    {
                        pbEnvLogo.Image = Image.FromStream(ms);
                    }
                }
                catch { }
            }
            else
            {
                pbEnvLogo.Visible = false;
            }
            pnlHighlight.BackColor = currentDetail.EnvironmentHighlightingInfo?.Color ?? DefaultBackColor;
            pnlHighlight.Visible = true;

            do
            {
                //WhoAmIRequest request = new WhoAmIRequest();
                //WhoAmIResponse response = (WhoAmIResponse)this.service.Execute(request);

                var user = this.service.RetrieveMultiple(new QueryExpression("systemuser")
                {
                    ColumnSet = new ColumnSet("fullname"),

                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("systemuserid", ConditionOperator.EqualUserId)
                        }
                    }
                }).Entities.First();

                i++;

                ccsb.SetMessage("Doing...");
                ccsb.SetProgress(i * 10);

                lbLogs.Items.Add($"Hello {user.GetAttributeValue<string>("fullname")},Your ID is: {user.Id:B}");
            } while (i < 1);

            ccsb.SetMessage("Done");
            ccsb.SetProgress(null);
        }

        #endregion WhoAmI Sample methods

        private void flushCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDetail == null)
            {
                MessageBox.Show("Please connect first");
                return;
            }

            ccsb.SetMessage("Refreshing Metadata Cache...");
            var startTime = DateTime.Now;

            currentDetail.UpdateMetadataCache(true)
                .ContinueWith(task =>
                {
                    if (task.Exception == null)
                        ccsb.SetMessage("Metadata cache refreshed: " + (DateTime.Now - startTime));
                    else
                        ccsb.SetMessage("Metadata cache refresh failed: " + task.Exception.Message);
                });
        }

        private void tsbClearImpersonate_Click(object sender, EventArgs e)
        {
            currentDetail.RemoveImpersonation();
        }

        private void tsbClearLogs_Click(object sender, EventArgs e)
        {
            lbLogs.Items.Clear();
        }

        private void tsbImpersonate_Click(object sender, EventArgs e)
        {
            var user = service.RetrieveMultiple(new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("fullname"),
            }).Entities.First();

            currentDetail.Impersonate(user.Id, user.GetAttributeValue<string>("fullname"));
        }

        private void tsbManageConnections_Click(object sender, EventArgs e)
        {
            formHelper.DisplayConnectionsList(this, currentDetail);
        }

        private void tsbMergeConnectionsFiles_Click(object sender, EventArgs e)
        {
            ccsb.MergeConnectionsFiles = tsbMergeConnectionsFiles.Checked;
        }

        private void tsbOpenXtbPortal_Click(object sender, EventArgs e)
        {
            currentDetail.OpenUrlWithBrowserProfile(new Uri("https://www.xrmtoolbox.com"));
        }

        private void tsbRequestPassword_Click(object sender, EventArgs e)
        {
            if (currentDetail == null)
            {
                MessageBox.Show("Please connect first");
                return;
            }

            if (currentDetail.TryRequestPassword(this,
                "This is a test to describe how to request the password for further processing",
                out string password,
                out SensitiveDataNotFoundReason reason))
            {
                MessageBox.Show($"Password is {password}");
            }
            else
            {
                MessageBox.Show($"Cannot get password for the following reason: {reason}");
            }
        }

        private void tssbMetadata_ButtonClick(object sender, EventArgs e)
        {
            if (currentDetail == null)
            {
                MessageBox.Show("Please connect first");
                return;
            }

            if (!currentDetail.MetadataCacheLoader.IsCompleted)
            {
                ccsb.SetMessage("Waiting for metadata cache...");
                var startTime = DateTime.Now;
                currentDetail.MetadataCacheLoader.GetAwaiter().GetResult();
                ccsb.SetMessage("Metadata cache loaded: " + (DateTime.Now - startTime));
            }

            foreach (var entity in currentDetail.MetadataCache.OrderBy(entity => entity.LogicalName))
            {
                lbLogs.Items.Add($"{entity.LogicalName}: {entity.DisplayName.UserLocalizedLabel?.Label}");
            }
        }

        private void updateCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDetail == null)
            {
                MessageBox.Show("Please connect first");
                return;
            }

            ccsb.SetMessage("Updating Metadata Cache...");
            var startTime = DateTime.Now;

            currentDetail.UpdateMetadataCache(false)
                .ContinueWith(task =>
                {
                    if (task.Exception == null)
                        ccsb.SetMessage("Metadata cache updated: " + (DateTime.Now - startTime));
                    else
                        ccsb.SetMessage("Metadata cache update failed: " + task.Exception.Message);
                });
        }
    }
}