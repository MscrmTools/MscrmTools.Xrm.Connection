using McTools.Xrm.Connection.WinForms.AppCode;
using McTools.Xrm.Connection.WinForms.Forms;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public class FormHelper
    {
        private readonly Control innerAppForm;
        private readonly IConnectionControlSettings settings;

        public FormHelper(Control innerAppForm, IConnectionControlSettings settings = null)
        {
            this.innerAppForm = innerAppForm;
            this.settings = settings;

            if (this.settings == null)
            {
                this.settings = Settings.Load();
            }
        }

        public FormHelper(Control innerAppForm)
        {
            this.innerAppForm = innerAppForm;
            settings = Settings.Load();
        }

        /// <summary>
        /// Asks this manager to select a Crm connection to use
        /// </summary>
        /// <param name="connectionParameter">The connection parameter.</param>
        /// <param name="preConnectionRequestAction">The action to be performed before the async call to create the connection.  Useful to display a please wait message</param>
        /// <returns></returns>
        public bool AskForConnection(object connectionParameter, Action<List<ConnectionDetail>> preConnectionRequestAction)
        {
            using (var cs = new CompactConnectionSelector(settings)
            {
                StartPosition = FormStartPosition.CenterParent
            })
            {
                if (cs.ShowDialog(innerAppForm) == DialogResult.OK)
                {
                    if (cs.SelectedConnections.Any(c => c.IsFromSdkLoginCtrl)
                        && cs.SelectedConnections.Count > 1)
                    {
                        MessageBox.Show(innerAppForm, @"You cannot select multiple connections that used SDK Login control",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    foreach (var connectionDetail in cs.SelectedConnections)
                    {
                        if (!connectionDetail.UseConnectionString)
                        {
                            if (connectionDetail.NewAuthType == AuthenticationType.ClientSecret
                                && connectionDetail.ClientSecretIsEmpty)
                            {
                                using (var pForm = new SecretForm(connectionDetail)
                                {
                                    ClientId = connectionDetail.AzureAdAppId.ToString("B")
                                })
                                {
                                    if (pForm.ShowDialog(innerAppForm) == DialogResult.OK)
                                    {
                                        connectionDetail.SetClientSecret(pForm.ClientSecret);
                                        connectionDetail.SavePassword = pForm.SaveSecret;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else if (connectionDetail.IsCustomAuth)
                            {
                                if (connectionDetail.PasswordIsEmpty && connectionDetail.Certificate == null)
                                {
                                    using (var pForm = new PasswordForm(connectionDetail)
                                    {
                                        UserDomain = connectionDetail.UserDomain,
                                        UserLogin = connectionDetail.UserName
                                    })
                                    {
                                        if (pForm.ShowDialog(innerAppForm) == DialogResult.OK)
                                        {
                                            connectionDetail.SetPassword(pForm.UserPassword);
                                            connectionDetail.SavePassword = pForm.SavePassword;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    preConnectionRequestAction?.Invoke(cs.SelectedConnections);

                    if (cs.SelectedConnections.First().IsFromSdkLoginCtrl)
                    {
                        var cd = cs.SelectedConnections.First();

                        var ctrl = new CRMLoginForm1(cd.ConnectionId.Value);
                        if (cd.AzureAdAppId != Guid.Empty)
                        {
                            ctrl.AppId = cd.AzureAdAppId.ToString();
                            ctrl.RedirectUri = new Uri(cd.ReplyUrl);
                        }

                        ctrl.ShowDialog();

                        ConnectionManager.Instance.ConnectToServerWithSdkLoginCtrl(cd, ctrl.CrmConnectionMgr.CrmSvc,
                            connectionParameter);
                    }
                    else
                    {
                        ConnectionManager.Instance.ConnectToServer(cs.SelectedConnections, connectionParameter);
                    }

                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Asks this manager to select a Crm connection to use
        /// </summary>
        /// <param name="connectionDetail">The <see cref="ConnectionDetail"/> to use</param>
        /// <param name="connectionParameter">The connection parameter.</param>
        /// <param name="preConnectionRequestAction">The action to be performed before the async call to create the connection.  Useful to display a please wait message</param>
        /// <returns></returns>
        public bool AskForConnection(ConnectionDetail connectionDetail, object connectionParameter, Action preConnectionRequestAction)
        {
            if (!connectionDetail.UseConnectionString && connectionDetail.IsCustomAuth)
            {
                if (connectionDetail.PasswordIsEmpty && connectionDetail.Certificate == null)
                {
                    using (var pForm = new PasswordForm(connectionDetail)
                    {
                        UserDomain = connectionDetail.UserDomain,
                        UserLogin = connectionDetail.UserName
                    })
                    {
                        if (pForm.ShowDialog(innerAppForm) == DialogResult.OK)
                        {
                            connectionDetail.SetPassword(pForm.UserPassword);
                            connectionDetail.SavePassword = pForm.SavePassword;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            preConnectionRequestAction?.Invoke();

            if (connectionDetail.IsFromSdkLoginCtrl)
            {
                var cd = connectionDetail;

                var ctrl = new CRMLoginForm1(cd.ConnectionId.Value);
                if (cd.AzureAdAppId != Guid.Empty)
                {
                    ctrl.AppId = cd.AzureAdAppId.ToString();
                    ctrl.RedirectUri = new Uri(cd.ReplyUrl);
                }

                ctrl.ShowDialog();

                ConnectionManager.Instance.ConnectToServerWithSdkLoginCtrl(cd, ctrl.CrmConnectionMgr.CrmSvc,
                    connectionParameter);
            }
            else
            {
                ConnectionManager.Instance.ConnectToServer(new List<ConnectionDetail> { connectionDetail }, connectionParameter);
            }
            return true;
        }

        /// <summary>
        /// Asks this manager to select a Crm connection to use
        /// </summary>
        public bool AskForConnection(object connectionParameter) =>
            AskForConnection(connectionParameter, null);

        /// <summary>
        /// Deletes a Crm connection from the connections list
        /// </summary>
        /// <param name="connectionId">Id of the connection to delete</param>
        public void DeleteConnection(Guid? connectionId)
        {
            var connection = ConnectionManager.Instance.ConnectionsList.Connections.FirstOrDefault(x => x.ConnectionId == connectionId);

            if (connection != null)
            {
                ConnectionManager.Instance.ConnectionsList.Connections.Remove(connection);
                ConnectionManager.Instance.SaveConnectionsFile();
            }
        }

        public void DisplayCompactConnectionsSelection(Form form)
        {
            using (var cs = new CompactConnectionSelector(settings)
            {
                StartPosition = FormStartPosition.CenterParent,
            })
            {
                cs.ShowDialog(form);
            }
        }

        public void DisplayConnectionsList(Form form)
        {
            using (var cs = new ConnectionSelector(false)
            {
                StartPosition = FormStartPosition.CenterParent,
                Settings = settings
            })
            {
                cs.ShowDialog(form);
            }
        }

        /// <summary>
        /// Creates or updates a Crm connection
        /// </summary>
        /// <param name="isCreation">Indicates if it is a connection creation</param>
        /// <param name="connectionToUpdate">Details of the connection to update</param>
        /// <param name="connectionFile">List of connections where the connection is edited from</param>
        /// <returns>Created or updated connection</returns>
        public ConnectionDetail EditConnection(bool isCreation, ConnectionDetail connectionToUpdate, ConnectionFile connectionFile = null)
        {
            using (var cForm = new ConnectionWizard2(connectionToUpdate) { StartPosition = FormStartPosition.CenterParent })
            {
                if (cForm.ShowDialog(innerAppForm) == DialogResult.OK)
                {
                    if (isCreation)
                    {
                        if (connectionFile == null)
                        {
                            if (ConnectionManager.Instance.ConnectionsList.Connections.FirstOrDefault(
                                d => d.ConnectionId == cForm.CrmConnectionDetail.ConnectionId) == null
                                && !string.IsNullOrEmpty(cForm.CrmConnectionDetail.ConnectionName))
                            {
                                ConnectionManager.Instance.ConnectionsList.Connections.Add(cForm.CrmConnectionDetail);
                            }

                            ConnectionManager.Instance.SaveConnectionsFile();
                        }
                        else
                        {
                            var connections = CrmConnections.LoadFromFile(connectionFile.Path);
                            if (connections.Connections.FirstOrDefault(
                                d => d.ConnectionId == cForm.CrmConnectionDetail.ConnectionId) == null
                                && !string.IsNullOrEmpty(cForm.CrmConnectionDetail.ConnectionName))
                            {
                                connections.Connections.Add(cForm.CrmConnectionDetail);
                            }

                            connections.SerializeToFile(connectionFile.Path);
                        }
                    }
                    else
                    {
                        if (connectionFile == null)
                        {
                            ConnectionManager.Instance.ConnectionsList.Connections
                                .Where(x => x.ConnectionId == cForm.CrmConnectionDetail.ConnectionId)
                                .ToList()
                                .ForEach(x => x.UpdateAfterEdit(cForm.CrmConnectionDetail));

                            ConnectionManager.Instance.SaveConnectionsFile();
                        }
                        else
                        {
                            var connections = CrmConnections.LoadFromFile(connectionFile.Path);
                            foreach (ConnectionDetail detail in connections.Connections)
                            {
                                if (detail.ConnectionId == cForm.CrmConnectionDetail.ConnectionId)
                                {
                                    detail.UpdateAfterEdit(cForm.CrmConnectionDetail);
                                }
                            }

                            connections.SerializeToFile(connectionFile.Path);
                        }
                    }

                    return cForm.CrmConnectionDetail;
                }

                return null;
            }
        }

        /// <summary>
        /// Checks the existence of a user password and returns it
        /// </summary>
        /// <param name="detail">Details of the Crm connection</param>
        /// <returns>True if password defined</returns>
        public bool RequestPassword(ConnectionDetail detail)
        {
            if (!string.IsNullOrEmpty(detail.ConnectionString))
                return true;

            if (!detail.PasswordIsEmpty || detail.Certificate != null)
                return true;

            bool returnValue = false;

            using (var pForm = new PasswordForm(detail)
            {
                UserLogin = detail.UserName,
                UserDomain = detail.UserDomain,
            })
            {
                MethodInvoker mi = delegate
                {
                    if (pForm.ShowDialog(innerAppForm) == DialogResult.OK)
                    {
                        detail.SetPassword(pForm.UserPassword);
                        detail.SavePassword = pForm.SavePassword;
                        returnValue = true;
                    }
                };

                if (innerAppForm.InvokeRequired)
                {
                    innerAppForm.Invoke(mi);
                }
                else
                {
                    mi();
                }
            }
            return returnValue;
        }

        public List<ConnectionDetail> SelectMultipleConnectionDetails()
        {
            using (var cs = new CompactConnectionSelector(settings)
            {
                StartPosition = FormStartPosition.CenterParent,
            })
            {
                if (cs.ShowDialog(innerAppForm) == DialogResult.OK)
                {
                    return cs.SelectedConnections;
                }
            }

            return new List<ConnectionDetail>();
        }
    }
}