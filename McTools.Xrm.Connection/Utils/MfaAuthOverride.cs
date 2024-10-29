using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Xrm.Tooling.Connector;

namespace McTools.Xrm.Connection.Utils
{
    class MfaAuthOverride : IOverrideAuthHookWrapper
    {
        private readonly ConnectionDetail _connection;
        private readonly IPublicClientApplication _app;
        private readonly IDictionary<string, AuthenticationResult> _accessTokens;

        public MfaAuthOverride(ConnectionDetail connection)
        {
            _connection = connection;
            _accessTokens = new Dictionary<string, AuthenticationResult>();

            var path = Path.Combine(Path.GetTempPath(), connection.ConnectionId.Value.ToString("B"));
            var storageProperties = new StorageCreationPropertiesBuilder("token.cache", path).Build();

            _app = PublicClientApplicationBuilder.Create(connection.AzureAdAppId.ToString())
                .WithRedirectUri(connection.ReplyUrl)
                .WithAuthority(AadAuthorityAudience.AzureAdMultipleOrgs)
                .WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows))
                .WithParentActivityOrWindow(() => GetMainForm().Handle)
                .Build();

            var cacheHelper = MsalCacheHelper.CreateAsync(storageProperties).ExecuteSync();
            cacheHelper.RegisterCache(_app.UserTokenCache);
        }

        public string GetAuthToken(Uri connectedUri)
        {
            if (_accessTokens.TryGetValue(connectedUri.Host, out var token) && token.ExpiresOn > DateTimeOffset.Now)
                return token.AccessToken;

            _accessTokens[connectedUri.Host] = GetAccessTokenFromAzureAD(connectedUri);
            return _accessTokens[connectedUri.Host].AccessToken;
        }

        private AuthenticationResult GetAccessTokenFromAzureAD(Uri orgUrl)
        {
            var scopes = new[] { new Uri(orgUrl, "/user_impersonation").ToString() };

            try
            {
                return _app.AcquireTokenSilent(scopes, _connection.UserName).ExecuteAsync().ExecuteSync();
            }
            catch (MsalUiRequiredException)
            {
                return InvokeIfRequired(GetMainForm(), () => AcquireTokenInteractive(scopes));
            }
        }

        private AuthenticationResult AcquireTokenInteractive(string[] scopes)
        {
            return _app.AcquireTokenInteractive(scopes)
                .WithPrompt(Prompt.SelectAccount)
                .WithLoginHint(_connection.UserName)
                .ExecuteAsync()
                .ExecuteSync();
        }

        private Form GetMainForm()
        {
            return Form.ActiveForm;
        }

        private T InvokeIfRequired<T>(Form form, Func<T> func)
        {
            if (form.InvokeRequired)
                return (T)form.Invoke(func);

            return func();
        }
    }
}