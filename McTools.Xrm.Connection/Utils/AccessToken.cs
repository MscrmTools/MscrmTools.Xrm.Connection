using Newtonsoft.Json;

namespace McTools.Xrm.Connection.Utils
{
    /// <summary>
    /// Represents the details of the OAuth authentication response
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The OAuth access token that can be used to authenticate immediate requests
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// The OAuth refresh token that can be used to authenticate future requests
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        
        /// <summary>
        /// Any error that was encountered during the access token request
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// A human-readable description of the <see cref="Error"/>
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        
        /// <summary>
        /// Another possible source of the <see cref="ErrorDescription"/> information
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// The Unix timestamp at which the token expires
        /// </summary>
        [JsonProperty("expires_on")]
        public long ExpiresOn { get; set; }
    }
}