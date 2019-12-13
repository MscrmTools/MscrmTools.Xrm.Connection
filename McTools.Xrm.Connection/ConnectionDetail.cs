﻿using McTools.Xrm.Connection.Utils;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace McTools.Xrm.Connection
{
    /// <summary>
    /// Stores data regarding a specific connection to Crm server
    /// </summary>
    public class ConnectionDetail : IComparable, ICloneable
    {
        private string clientSecret;
        private string userPassword;

        #region Propriétés

        private CrmServiceClient crmSvc;
       

        public AuthenticationProviderType AuthType { get; set; }
        public Guid AzureAdAppId { get; set; }

        public bool ClientSecretIsEmpty => string.IsNullOrEmpty(clientSecret);

        /// <summary>
        /// Gets or sets the connection unique identifier
        /// </summary>
        public Guid? ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the connection
        /// </summary>
        public string ConnectionName { get; set; }

        public string ConnectionString { get; set; }

        /// <summary>
        /// Get or set the Crm Ticket
        /// </summary>
        public string CrmTicket { get; set; }

        /// <summary>
        /// Gets or sets custom information for use by consuming application
        /// </summary>
        public Dictionary<string, string> CustomInformation { get; set; }

        public Color? EnvironmentColor { get; set; }
        public string EnvironmentText { get; set; }
        public Color? EnvironmentTextColor { get; set; }

        /// <summary>
        /// Gets or sets the Home realm url for ADFS authentication
        /// </summary>
        public string HomeRealmUrl { get; set; }

        /// <summary>
        /// Get or set flag to know if custom authentication
        /// </summary>
        public bool IsCustomAuth { get; set; }

        public bool IsEnvironmentHighlightSet { get; set; }
        public bool IsFromSdkLoginCtrl { get; set; }

        public DateTime LastUsedOn { get; set; }

        /// <summary>
        /// Get or set the organization name
        /// </summary>
        public string Organization { get; set; }

        public string OrganizationDataServiceUrl { get; set; }

        /// <summary>
        /// Get or set the organization friendly name
        /// </summary>
        public string OrganizationFriendlyName { get; set; }

        public int OrganizationMajorVersion
        {
            get
            {
                return OrganizationVersion != null ? int.Parse(OrganizationVersion.Split('.')[0]) : -1;
            }
        }

        public int OrganizationMinorVersion
        {
            get
            {
                return OrganizationVersion != null ? int.Parse(OrganizationVersion.Split('.')[1]) : -1;
            }
        }

        /// <summary>
        /// Gets or sets the Crm Service Url
        /// </summary>
        public string OrganizationServiceUrl { get; set; }

        /// <summary>
        /// Get or set the organization name
        /// </summary>
        public string OrganizationUrlName { get; set; }

        public string OrganizationVersion { get; set; }
        public string OriginalUrl { get; set; }

        /// <summary>
        /// Gets an information if the password is empty
        /// </summary>
        public bool PasswordIsEmpty { get { return string.IsNullOrEmpty(userPassword); } }

        /// <summary>
        /// OAuth Refresh Token
        /// </summary>
        public string RefreshToken { get; set; }

        public string ReplyUrl { get; set; }

        /// <summary>
        /// Gets or sets the information if the password must be saved
        /// </summary>
        public bool SavePassword { get; set; }

        /// <summary>
        /// Get or set the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Get or set the server port
        /// </summary>
        [DefaultValue(80)]
        public int? ServerPort { get; set; }

        public CrmServiceClient ServiceClient
        {
            get { return GetCrmServiceClient(); }
            set { crmSvc = value; }
        }

        public TimeSpan Timeout { get; set; }

        public long TimeoutTicks
        {
            get { return Timeout.Ticks; }
            set { Timeout = new TimeSpan(value); }
        }

        public bool UseConnectionString { get; set; }

        /// <summary>
        /// Get or set flag to know if we use IFD
        /// </summary>
        public bool UseIfd { get; set; }

        /// <summary>
        /// Get or set flag to know if we use Multi Factor Authentication
        /// </summary>
        public bool UseMfa { get; set; }

        /// <summary>
        /// Get or set flag to know if we use CRM Online
        /// </summary>
        public bool UseOnline { get; set; }

        /// <summary>
        /// Get or set flag to know if we use Online Services
        /// </summary>
        public bool UseOsdp { get; set; }

        /// <summary>
        /// Get or set the user domain name
        /// </summary>
        public string UserDomain { get; set; }

        /// <summary>
        /// Get or set user login
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get or set the use of SSL connection
        /// </summary>
        public bool UseSsl { get; set; }

        /// <summary>
        /// Get or set the use of Service Principal
        /// </summary>
        public bool UseServicePrincipal { get; set; }

        public string WebApplicationUrl { get; set; }

        /// <summary>
        /// Client Secret used for S2S Auth
        /// </summary>
        internal string S2SClientSecret
        {
            get => clientSecret;
            set => clientSecret = value;
        }

        #endregion Propriétés

        #region Constructeur

        public ConnectionDetail(bool createNewId = false)
        {
            if (createNewId)
            {
                ConnectionId = Guid.NewGuid();
            }
        }

        #endregion Constructeur

        #region Méthodes

        public void ErasePassword()
        {
            userPassword = null;
        }

        public CrmServiceClient GetCrmServiceClient(bool forceNewService = false)
        {
            if (forceNewService == false && crmSvc != null)
            {
                return crmSvc;
            }

            if (UseConnectionString || !string.IsNullOrEmpty(ConnectionString))
            {
                var csb = new DbConnectionStringBuilder { ConnectionString = ConnectionString };
                if (csb.ContainsKey("timeout"))
                {
                    var csTimeout = TimeSpan.Parse(csb["timeout"].ToString());
                    csb.Remove("timeout");
                    CrmServiceClient.MaxConnectionTimeout = csTimeout;
                }

                var cs = csb.ToString();

                if (cs.IndexOf("RequireNewInstance=", StringComparison.Ordinal) < 0)
                {
                    if (!cs.EndsWith(";"))
                    {
                        cs += ";";
                    }
                    cs += "RequireNewInstance=True;";
                }

                crmSvc = new CrmServiceClient(cs);

                if (crmSvc.IsReady)
                {
                    OrganizationFriendlyName = crmSvc.ConnectedOrgFriendlyName;
                    OrganizationDataServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
                    OrganizationServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
                    WebApplicationUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.WebApplication];
                    Organization = crmSvc.ConnectedOrgUniqueName;
                    OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();

                    var webAppURi = new Uri(WebApplicationUrl);
                    ServerName = webAppURi.Host;
                    ServerPort = webAppURi.Port;

                    UseOnline = crmSvc.CrmConnectOrgUriActual.Host.Contains(".dynamics.com");
                    UseOsdp = crmSvc.CrmConnectOrgUriActual.Host.Contains(".dynamics.com");
                    UseSsl = crmSvc.CrmConnectOrgUriActual.AbsoluteUri.ToLower().StartsWith("https");
                    UseIfd = crmSvc.ActiveAuthenticationType == AuthenticationType.IFD;
                    
                    switch (crmSvc.ActiveAuthenticationType)
                    {
                        case AuthenticationType.AD:
                        case AuthenticationType.Claims:
                            AuthType = AuthenticationProviderType.ActiveDirectory;
                            break;

                        case AuthenticationType.IFD:
                            AuthType = AuthenticationProviderType.Federation;
                            break;

                        case AuthenticationType.Live:
                            AuthType = AuthenticationProviderType.LiveId;
                            break;

                        case AuthenticationType.OAuth:
                            // TODO add new property in ConnectionDetail class?
                            break;

                        case AuthenticationType.Office365:
                            AuthType = AuthenticationProviderType.OnlineFederation;
                            break;
                    }

                    IsCustomAuth = ConnectionString.ToLower().Contains("username=");
                }

                return crmSvc;
            }

           
           if (UseOnline)
            {
                ConnectOnline();
            }
            else if (UseIfd)
            {
                ConnectIfd();
            }
            else if (UseServicePrincipal)
            {
                ConnectServicePrincipal();
            }
            else
            {
                ConnectOnprem();
            }

            if (!crmSvc.IsReady)
            {
                var error = crmSvc.LastCrmError;
                crmSvc = null;
                throw new Exception(error);
            }

            return crmSvc;
        }

        public void SetClientSecret(string secret, bool isEncrypted = false)
        {
            if (!string.IsNullOrEmpty(secret))
            {
                if (isEncrypted)
                {
                    clientSecret = secret;
                }
                else
                {
                    clientSecret = CryptoManager.Encrypt(secret, ConnectionManager.CryptoPassPhrase,
                        ConnectionManager.CryptoSaltValue,
                        ConnectionManager.CryptoHashAlgorythm,
                        ConnectionManager.CryptoPasswordIterations,
                        ConnectionManager.CryptoInitVector,
                        ConnectionManager.CryptoKeySize);
                }
            }
        }

        public void SetPassword(string password, bool isEncrypted = false)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (isEncrypted)
                {
                    userPassword = password;
                }
                else
                {
                    userPassword = CryptoManager.Encrypt(password, ConnectionManager.CryptoPassPhrase,
                        ConnectionManager.CryptoSaltValue,
                        ConnectionManager.CryptoHashAlgorythm,
                        ConnectionManager.CryptoPasswordIterations,
                        ConnectionManager.CryptoInitVector,
                        ConnectionManager.CryptoKeySize);
                }
            }
        }

        /// <summary>
        /// Retourne le nom de la connexion
        /// </summary>
        /// <returns>Nom de la connexion</returns>
        public override string ToString()
        {
            return ConnectionName;
        }

        public void UpdateAfterEdit(ConnectionDetail editedConnection)
        {
            ConnectionName = editedConnection.ConnectionName;
            ConnectionString = editedConnection.ConnectionString;
            OrganizationServiceUrl = editedConnection.OrganizationServiceUrl;
            OrganizationDataServiceUrl = editedConnection.OrganizationDataServiceUrl;
            CrmTicket = editedConnection.CrmTicket;
            IsCustomAuth = editedConnection.IsCustomAuth;
            Organization = editedConnection.Organization;
            OrganizationFriendlyName = editedConnection.OrganizationFriendlyName;
            ServerName = editedConnection.ServerName;
            ServerPort = editedConnection.ServerPort;
            UseIfd = editedConnection.UseIfd;
            UseOnline = editedConnection.UseOnline;
            UseOsdp = editedConnection.UseOsdp;
            UserDomain = editedConnection.UserDomain;
            UserName = editedConnection.UserName;
            userPassword = editedConnection.userPassword;
            UseSsl = editedConnection.UseSsl;
            HomeRealmUrl = editedConnection.HomeRealmUrl;
            Timeout = editedConnection.Timeout;
            UseMfa = editedConnection.UseMfa;
            ReplyUrl = editedConnection.ReplyUrl;
            AzureAdAppId = editedConnection.AzureAdAppId;
            clientSecret = editedConnection.clientSecret;
            RefreshToken = editedConnection.RefreshToken;
            IsEnvironmentHighlightSet = editedConnection.IsEnvironmentHighlightSet;
            EnvironmentText = editedConnection.EnvironmentText;
            EnvironmentColor = editedConnection.EnvironmentColor;
            EnvironmentTextColor = editedConnection.EnvironmentTextColor;
        }

        private void ConnectIfd()
        {
            AuthType = AuthenticationProviderType.Federation;

            if (!IsCustomAuth)
            {
                crmSvc = new CrmServiceClient(CredentialCache.DefaultNetworkCredentials,
                    AuthenticationType.IFD,
                    ServerName,
                    ServerPort.ToString(),
                    OrganizationUrlName,
                    true,
                    UseSsl);
            }
            else
            {
                var password = CryptoManager.Decrypt(userPassword, ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);

                crmSvc = new CrmServiceClient(UserName, CrmServiceClient.MakeSecureString(password), UserDomain,
                    HomeRealmUrl,
                    ServerName,
                    ServerPort.ToString(),
                    OrganizationUrlName,
                    true,
                    UseSsl);
            }
        }

        private void ConnectOAuth()
        {
            if (!String.IsNullOrEmpty(RefreshToken))
            {
                CrmServiceClient.AuthOverrideHook = new RefreshTokenAuthOverride(this);
                crmSvc = new CrmServiceClient(new Uri($"https://{ServerName}:{ServerPort}"), true);
                CrmServiceClient.AuthOverrideHook = null;
            }
            else
            {
                var secret = CryptoManager.Decrypt(clientSecret, ConnectionManager.CryptoPassPhrase,
                     ConnectionManager.CryptoSaltValue,
                     ConnectionManager.CryptoHashAlgorythm,
                     ConnectionManager.CryptoPasswordIterations,
                     ConnectionManager.CryptoInitVector,
                     ConnectionManager.CryptoKeySize);

                var path = Path.Combine(Path.GetTempPath(), ConnectionId.Value.ToString("B"), "oauth-cache.txt");
                crmSvc = new CrmServiceClient(new Uri($"https://{ServerName}:{ServerPort}"), AzureAdAppId.ToString(), CrmServiceClient.MakeSecureString(secret), true, path);
            }
        }

        private void ConnectOnline()
        {
            AuthType = AuthenticationProviderType.OnlineFederation;

            if (string.IsNullOrEmpty(userPassword))
            {
                throw new Exception("Unable to read user password");
            }

            var password = CryptoManager.Decrypt(userPassword, ConnectionManager.CryptoPassPhrase,
                 ConnectionManager.CryptoSaltValue,
                 ConnectionManager.CryptoHashAlgorythm,
                 ConnectionManager.CryptoPasswordIterations,
                 ConnectionManager.CryptoInitVector,
                 ConnectionManager.CryptoKeySize);

            Utilities.GetOrgnameAndOnlineRegionFromServiceUri(new Uri(OriginalUrl), out var region, out var orgName, out _);

            if (UseMfa)
            {
                var path = Path.Combine(Path.GetTempPath(), ConnectionId.Value.ToString("B"), "oauth-cache.txt");

                crmSvc = new CrmServiceClient(UserName, CrmServiceClient.MakeSecureString(password),
                    region,
                    orgName,
                    false,
                    null,
                    null,
                    AzureAdAppId.ToString(),
                    new Uri(ReplyUrl),
                    path,
                    null);
            }

            crmSvc = new CrmServiceClient(UserName, CrmServiceClient.MakeSecureString(password),
                region,
                orgName,
                true,
                true,
                null,
                true);
        }

        private void ConnectOnprem()
        {
            AuthType = AuthenticationProviderType.ActiveDirectory;

            NetworkCredential credential;
            if (!IsCustomAuth)
            {
                credential = CredentialCache.DefaultNetworkCredentials;
            }
            else
            {
                var password = CryptoManager.Decrypt(userPassword, ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);

                credential = new NetworkCredential(UserName, password, UserDomain);
            }

            crmSvc = new CrmServiceClient(credential,
                AuthenticationType.AD,
                ServerName,
                ServerPort.ToString(),
                OrganizationUrlName,
                true,
                UseSsl);
        }
        private void ConnectServicePrincipal()
        {
            var tokenDirectory = Path.Combine(Environment.CurrentDirectory, "TokenCache");
            if (!Directory.Exists(tokenDirectory))
            {
                Directory.CreateDirectory(tokenDirectory);
            }
            var tokenCachePath = Path.Combine(tokenDirectory, "serviceprincipal-cache.txt");
            
            Uri instanceUrl = new Uri(WebApplicationUrl, UriKind.Absolute);
            string clientId = AzureAdAppId.ToString();
          
            crmSvc = new CrmServiceClient(instanceUrl, clientId, CrmServiceClient.MakeSecureString(clientSecret), true, tokenCachePath);

        }
        #endregion Méthodes

        public object Clone()
        {
            return new ConnectionDetail
            {
                AuthType = AuthType,
                ConnectionId = Guid.NewGuid(),
                ConnectionName = ConnectionName,
                ConnectionString = ConnectionString,
                UseConnectionString = UseConnectionString,
                CrmTicket = CrmTicket,
                HomeRealmUrl = HomeRealmUrl,
                IsCustomAuth = IsCustomAuth,
                Organization = Organization,
                OrganizationFriendlyName = OrganizationFriendlyName,
                OrganizationServiceUrl = OrganizationServiceUrl,
                OrganizationDataServiceUrl = OrganizationDataServiceUrl,
                OrganizationUrlName = OrganizationUrlName,
                OrganizationVersion = OrganizationVersion,
                SavePassword = SavePassword,
                ServerName = ServerName,
                ServerPort = ServerPort,
                TimeoutTicks = TimeoutTicks,
                UseIfd = UseIfd,
                UseOnline = UseOnline,
                UseOsdp = UseOsdp,
                UseSsl = UseSsl,
                UserDomain = UserDomain,
                UserName = UserName,
                userPassword = userPassword,
                WebApplicationUrl = WebApplicationUrl,
                OriginalUrl = OriginalUrl,
                Timeout = Timeout,
                UseMfa = UseMfa,
                AzureAdAppId = AzureAdAppId,
                ReplyUrl = ReplyUrl,
                IsEnvironmentHighlightSet = IsEnvironmentHighlightSet,
                EnvironmentText = EnvironmentText,
                EnvironmentColor = EnvironmentColor,
                EnvironmentTextColor = EnvironmentTextColor,
                RefreshToken = RefreshToken,
                S2SClientSecret = S2SClientSecret,
                IsFromSdkLoginCtrl = IsFromSdkLoginCtrl
            };
        }

        public void CopyClientSecretTo(ConnectionDetail detail)
        {
            detail.clientSecret = clientSecret;
        }

        public void CopyPasswordTo(ConnectionDetail detail)
        {
            detail.userPassword = userPassword;
        }

        public string GetConnectionString()
        {
            var csb = new DbConnectionStringBuilder();

            switch (AuthType)
            {
                default:
                    csb["AuthType"] = "AD";
                    break;

                case AuthenticationProviderType.OnlineFederation:
                    csb["AuthType"] = "Office365";
                    break;

                case AuthenticationProviderType.Federation:
                    csb["AuthType"] = "IFD";
                    break;
            }

            csb["Url"] = WebApplicationUrl;

            if (!string.IsNullOrEmpty(UserDomain))
                csb["Domain"] = UserDomain;
            csb["Username"] = UserName;
            csb["Password"] = "********";

            if (!string.IsNullOrEmpty(HomeRealmUrl))
                csb["HomeRealmUri"] = HomeRealmUrl;

            if (UseMfa)
            {
                csb["AuthType"] = "OAuth";
                csb["ClientId"] = AzureAdAppId.ToString("B");
                csb["LoginPrompt"] = "Auto";
                csb["RedirectUri"] = ReplyUrl;
                csb["TokenCacheStorePath"] = Path.Combine(Path.GetTempPath(), ConnectionId.Value.ToString("B"), "oauth-cache.txt");
            }

            return csb.ToString();
        }

        public bool IsConnectionBrokenWithUpdatedData(ConnectionDetail originalDetail)
        {
            if (originalDetail == null)
            {
                return true;
            }

            if (originalDetail.HomeRealmUrl != HomeRealmUrl
                || originalDetail.IsCustomAuth != IsCustomAuth
                || originalDetail.Organization != Organization
                || originalDetail.OrganizationUrlName != OrganizationUrlName
                || originalDetail.ServerName.ToLower() != ServerName.ToLower()
                || originalDetail.ServerPort != ServerPort
                || originalDetail.UseIfd != UseIfd
                || originalDetail.UseOnline != UseOnline
                || originalDetail.UseOsdp != UseOsdp
                || originalDetail.UseSsl != UseSsl
                || originalDetail.UseMfa != UseMfa
                || originalDetail.clientSecret != clientSecret
                || originalDetail.AzureAdAppId != AzureAdAppId
                || originalDetail.ReplyUrl != ReplyUrl
                || originalDetail.UserDomain?.ToLower() != UserDomain?.ToLower()
                || originalDetail.UserName?.ToLower() != UserName?.ToLower()
                || SavePassword && !string.IsNullOrEmpty(userPassword) && originalDetail.userPassword != userPassword)
            {
                return true;
            }

            return false;
        }

        public bool PasswordIsDifferent(string password)
        {
            return password != userPassword;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            var detail = (ConnectionDetail)obj;

            return String.Compare(ConnectionName, detail.ConnectionName, StringComparison.Ordinal);
        }

        #endregion IComparable Members

        internal XElement GetXElement()
        {
            return new XElement("ConnectionDetail",
                    new XElement("AuthType", AuthType),
                    new XElement("ConnectionId", ConnectionId),
                    new XElement("ConnectionName", ConnectionName),
                    new XElement("ConnectionString", ConnectionString),
                    new XElement("UseConnectionString", UseConnectionString),
                    new XElement("IsCustomAuth", IsCustomAuth),
                    new XElement("UseServicePrincipal", UseServicePrincipal),
                    new XElement("UseMfa", UseMfa), new XElement("UseIfd", UseIfd),
                    new XElement("UseOnline", UseOnline),
                    new XElement("UseOsdp", UseOsdp),
                    new XElement("UserDomain", UserDomain),
                    new XElement("UserName", UserName),
                    new XElement("UserPassword", SavePassword ? userPassword : string.Empty),
                    new XElement("SavePassword", SavePassword),
                    new XElement("UseSsl", UseSsl),
                    new XElement("AzureAdAppId", AzureAdAppId),
                    new XElement("ReplyUrl", ReplyUrl),
                    new XElement("UseIfd", UseIfd),
                    new XElement("ServerName", ServerName),
                    new XElement("ServerPort", ServerPort),
                    new XElement("OriginalUrl", OriginalUrl),
                    new XElement("Organization", Organization),
                    new XElement("OrganizationUrlName", OrganizationUrlName),
                    new XElement("OrganizationFriendlyName", OrganizationFriendlyName),
                    new XElement("OrganizationServiceUrl", OrganizationServiceUrl),
                    new XElement("OrganizationDataServiceUrl", OrganizationDataServiceUrl),
                    new XElement("OrganizationVersion", OrganizationVersion),
                    new XElement("HomeRealmUrl", HomeRealmUrl),
                    new XElement("Timeout", TimeoutTicks),
                    new XElement("WebApplicationUrl", WebApplicationUrl),
                    new XElement("IsEnvironmentHighlightSet", IsEnvironmentHighlightSet),
                    new XElement("EnvironmentText", EnvironmentText),
                    new XElement("EnvironmentColor", ColorTranslator.ToHtml(EnvironmentColor ?? Color.FromArgb(255, 255, 0, 255))),
                    new XElement("EnvironmentTextColor", ColorTranslator.ToHtml(EnvironmentTextColor ?? Color.FromArgb(255, 255, 255, 255))),
                    new XElement("IsFromSdkLoginCtrl", IsFromSdkLoginCtrl),
                    new XElement("LastUsedOn", LastUsedOn.ToString(CultureInfo.InvariantCulture.DateTimeFormat)),
                    new XElement("RefreshToken", RefreshToken),
                    new XElement("S2SClientSecret", S2SClientSecret),
                    GetCustomInfoXElement());
        }

        private XElement GetCustomInfoXElement()
        {
            if (CustomInformation == null)
            {
                return null;
            }
            return new XElement("CustomInformation", CustomInformation.Select(i => new XElement(i.Key, i.Value)));
        }
    }
}