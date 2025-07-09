using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.TestWinForm
{
    public class CrmConnectionProvider : ICrmConnectionsProvider
    {
        class PromptOnConnectConnectionDetail : ConnectionDetail
        {
            public override CrmServiceClient GetCrmServiceClient(bool forceNewService = false)
            {
                MessageBox.Show("Connecting to " + ConnectionName);

                return base.GetCrmServiceClient(forceNewService);
            }
        }

        public CrmConnections LoadCrmConnections()
        {
            // Provider can load the connection list dynamically here, from a database, API, ...
            return new CrmConnections("Dynamic Demo")
            {
                IsReadOnly = true,
                Connections = new List<ConnectionDetail>
                {
                    new PromptOnConnectConnectionDetail
                    {
                        ConnectionId = Guid.NewGuid(),
                        OriginalUrl = "https://contoso.crm.dynamics.com",
                        WebApplicationUrl = "https://contoso.crm.dynamics.com",
                        ConnectionName = "Demo Connection",
                        NewAuthType = AuthenticationType.OAuth,
                        UseMfa = true,
                        AzureAdAppId = new Guid("51f81489-12ee-4a9e-aaae-a2591f45987d"),
                        ReplyUrl = "app://58145B91-0C36-4500-8554-080854F2AC97",
                        UserName = "example@contoso.com"
                    }
                }
            };
        }
    }
}
