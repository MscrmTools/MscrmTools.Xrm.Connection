using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;

namespace McTools.Xrm.Connection.Utils
{
    internal class RefreshTokenAuthOverride : IOverrideAuthHookWrapper
    {
        private readonly IDictionary<string, AuthenticationResult> _accessTokens;
        private readonly ConnectionDetail _connection;

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
            var clientSecret = CryptoManager.Decrypt(_connection.S2SClientSecret, ConnectionManager.CryptoPassPhrase,
                ConnectionManager.CryptoSaltValue,
                ConnectionManager.CryptoHashAlgorythm,
                ConnectionManager.CryptoPasswordIterations,
                ConnectionManager.CryptoInitVector,
                ConnectionManager.CryptoKeySize);

            var credentials = new ClientCredential(_connection.AzureAdAppId.ToString(), clientSecret);
            var parameters = AuthenticationParameters.CreateFromResourceUrlAsync(orgUrl).Result;
            var context = new AuthenticationContext(parameters.Authority);
            var result = context.AcquireTokenByRefreshToken(_connection.RefreshToken, credentials, parameters.Resource);

            if (!String.IsNullOrEmpty(result.RefreshToken))
                _connection.RefreshToken = result.RefreshToken;

            return result;
        }
    }
}