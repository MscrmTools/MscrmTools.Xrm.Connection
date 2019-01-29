using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Tooling.Connector;

namespace McTools.Xrm.Connection.Utils
{
    class RefreshTokenAuthOverride : IOverrideAuthHookWrapper
    {
        private readonly ConnectionDetail _connection;
        private readonly IDictionary<string, AuthenticationResult> _accessTokens;

        public RefreshTokenAuthOverride(ConnectionDetail connection)
        {
            _connection = connection;
            _accessTokens = new Dictionary<string, AuthenticationResult>();
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
            var credentials = new ClientCredential(_connection.AzureAdAppId.ToString(), _connection.S2SClientSecret);
            var parameters = AuthenticationParameters.CreateFromResourceUrlAsync(orgUrl).Result;
            var context = new AuthenticationContext(parameters.Authority);
            var result = context.AcquireTokenByRefreshToken(_connection.RefreshToken, credentials, parameters.Resource);

            if (!String.IsNullOrEmpty(result.RefreshToken))
                _connection.RefreshToken = result.RefreshToken;

            return result;
        }
    }
}
