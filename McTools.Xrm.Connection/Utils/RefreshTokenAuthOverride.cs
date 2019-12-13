using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json;

namespace McTools.Xrm.Connection.Utils
{
    class RefreshTokenAuthOverride : IOverrideAuthHookWrapper
    {
        private readonly ConnectionDetail _connection;
        private readonly IDictionary<string, Token> _accessTokens;

        class Token
        {
            public string access_token;
            public string refresh_token;
            public int expires_on;
        }

        public RefreshTokenAuthOverride(ConnectionDetail connection)
        {
            _connection = connection;
            _accessTokens = new Dictionary<string, Token>();
        }

        public string GetAuthToken(Uri connectedUri)
        {
            if (_accessTokens.TryGetValue(connectedUri.Host, out var token) && new DateTime(1970, 1, 1).AddSeconds(token.expires_on) > DateTimeOffset.Now)
                return token.access_token;

            _accessTokens[connectedUri.Host] = GetAccessTokenFromAzureAD(connectedUri);
            return _accessTokens[connectedUri.Host].access_token;
        }

        private Token GetAccessTokenFromAzureAD(Uri orgUrl)
        {
            var secret = CryptoManager.Decrypt(_connection.S2SClientSecret, ConnectionManager.CryptoPassPhrase,
                 ConnectionManager.CryptoSaltValue,
                 ConnectionManager.CryptoHashAlgorythm,
                 ConnectionManager.CryptoPasswordIterations,
                 ConnectionManager.CryptoInitVector,
                 ConnectionManager.CryptoKeySize);

            var resource = new Uri(orgUrl, "/");

            var url = "https://login.microsoftonline.com/common/oauth2/token";
            var data = new Dictionary<string, string>
            {
                ["client_id"] = _connection.AzureAdAppId.ToString(),
                ["client_secret"] = secret,
                ["resource"] = resource.ToString(),
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = _connection.RefreshToken,
                ["redirect_uri"] = _connection.ReplyUrl
            };

            var req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            using (var reqStream = req.GetRequestStream())
            using (var writer = new StreamWriter(reqStream))
            {
                writer.Write(String.Join("&", data.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}")));
            }

            using (var resp = req.GetResponse())
            using (var respStream = resp.GetResponseStream())
            using (var reader = new StreamReader(respStream))
            {
                var json = reader.ReadToEnd();
                var token = JsonConvert.DeserializeObject<Token>(json);

                if (!String.IsNullOrEmpty(token.refresh_token))
                    _connection.RefreshToken = token.refresh_token;

                return token;
            }
        }
    }
}