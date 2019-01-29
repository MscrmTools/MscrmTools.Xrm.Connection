using System;
using System.Diagnostics;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.WebServiceClient;

namespace McTools.Xrm.Connection.Utils
{
    /// <summary>
    /// An <see cref="OrganizationWebProxyClient"/> that automatically refreshes the
    /// <see cref="OrganizationWebProxyClient.HeaderToken"/> when the token being used
    /// is nearing its expiry time.
    /// </summary>
    internal class ManagedTokenOrganizationWebProxyClient : OrganizationWebProxyClient
    {
        private readonly Func<AccessToken, AccessToken> _tokenGenerator;

        /// <summary>
        /// Connects to an MSCRM instance
        /// </summary>
        /// <param name="serviceUrl">The URL of the Organization web service.</param>
        /// <param name="useStrongTypes">When true, use early-bound types; otherwise, false.</param>
        /// <param name="tokenGenerator">A function that generates access tokens on demand</param>
        public ManagedTokenOrganizationWebProxyClient(Uri serviceUrl, bool useStrongTypes, Func<AccessToken, AccessToken> tokenGenerator) : base(serviceUrl, useStrongTypes)
        {
            _tokenGenerator = tokenGenerator;
        }

        /// <summary>
        /// Checks if the current access token is approaching expiry and generates a new one
        /// </summary>
        /// <remarks>
        /// A new access token will be generated when the current token has 15 minutes or less remaining before expiry
        /// </remarks>
        private void RenewTokenIfRequired()
        {
            // If we don't have a token, or it will be expiring in the next 15 minutes, generate a new one
            if (Token == null || DateTime.UtcNow.AddMinutes(15) >= UnixTimeStampToDateTime(Token.ExpiresOn))
            {
                Token = _tokenGenerator(Token);

                Trace.TraceInformation("Retrieved new token valid until {0:u}", UnixTimeStampToDateTime(Token.ExpiresOn));

                HeaderToken = Token.Token;
            }
        }

        protected override WebProxyClientContextInitializer<IOrganizationService> CreateNewInitializer()
        {
            RenewTokenIfRequired();
            return base.CreateNewInitializer();
        }

        /// <summary>
        /// Returns the token currently being used for this connection
        /// </summary>
        public AccessToken Token { get; private set; }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTimeStamp);
        }
    }
}
