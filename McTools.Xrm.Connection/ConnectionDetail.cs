using McTools.Xrm.Connection.AppCode;
using McTools.Xrm.Connection.Forms;
using McTools.Xrm.Connection.Utils;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using AuthenticationType = Microsoft.Xrm.Tooling.Connector.AuthenticationType;
using Label = Microsoft.Xrm.Sdk.Label;

namespace McTools.Xrm.Connection
{
    public enum SensitiveDataNotFoundReason
    {
        NotAllowedByUser,
        NotAccessible,
        None
    }

    public class CertificateInfo
    {
        public string Issuer { get; set; }
        public string Name { get; set; }
        public string Thumbprint { get; set; }
    }

    /// <summary>
    /// Stores data regarding a specific connection to Crm server
    /// </summary>
    [XmlInclude(typeof(CertificateInfo))]
    [XmlInclude(typeof(EnvironmentHighlighting))]
    public class ConnectionDetail : IComparable, ICloneable
    {
        private string clientSecret;
        private Guid impersonatedUserId;
        private string impersonatedUserName;
        private string userPassword;

        #region Constructeur

        public ConnectionDetail()
        {
        }

        public ConnectionDetail(bool createNewId = false)
        {
            if (createNewId)
            {
                ConnectionId = Guid.NewGuid();
            }
        }

        #endregion Constructeur

        #region Propriétés

        private MetadataCache _metadataCache;

        [XmlIgnore]
        private CrmServiceClient crmSvc;

        [XmlIgnore]
        public bool AllowPasswordSharing { get; set; }

        public AuthenticationProviderType AuthType { get; set; }

        public Guid AzureAdAppId { get; set; }

        [XmlIgnore]
        public bool CanImpersonate { get; private set; }

        [XmlElement("CertificateInfo")]
        public CertificateInfo Certificate { get; set; }

        [XmlElement("ClientSecret")]
        public string ClientSecretEncrypted
        {
            get => clientSecret;
            set => clientSecret = value;
        }

        [XmlIgnore]
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

        [XmlIgnore]
        public Color? EnvironmentColor { get; set; }

        ///// <summary>
        ///// Gets or sets custom information for use by consuming application
        ///// </summary>
        //public Dictionary<string, string> CustomInformation { get; set; }
        public EnvironmentHighlighting EnvironmentHighlightingInfo { get; set; }

        public string EnvironmentId { get; set; }

        [XmlIgnore]
        public string EnvironmentText { get; set; }

        [XmlIgnore]
        public Color? EnvironmentTextColor { get; set; }

        /// <summary>
        /// Gets or sets the Home realm url for ADFS authentication
        /// </summary>
        public string HomeRealmUrl { get; set; }

        [XmlIgnore]
        public Guid ImpersonatedUserId => impersonatedUserId;

        [XmlIgnore]
        public string ImpersonatedUserName => impersonatedUserName;

        /// <summary>
        /// Get or set flag to know if custom authentication
        /// </summary>
        public bool IsCustomAuth { get; set; }

        [XmlIgnore] public bool IsEnvironmentHighlightSet => EnvironmentHighlightingInfo != null;
        public bool IsFromSdkLoginCtrl { get; set; }

        [XmlIgnore]
        public DateTime LastUsedOn { get; set; }

        [XmlElement("LastUsedOn")]
        public string LastUsedOnString
        {
            get => LastUsedOn.ToString("yyyy-MM-dd HH:mm:ss");
            set
            {
                //if (DateTime.TryParse(value, CultureInfo.CurrentUICulture, DateTimeStyles.AssumeLocal, out DateTime parsed))
                if (DateTime.TryParseExact(value, "MM/dd/yyyy HH:mm:ss", CultureInfo.CurrentUICulture, DateTimeStyles.AssumeLocal, out DateTime parsed))
                {
                    LastUsedOn = parsed;
                }
                else
                {
                    LastUsedOn = DateTime.Parse(value);
                }
            }
        }

        /// <summary>
        /// Returns a cached version of the metadata for this connection.
        /// </summary>
        /// <remarks>
        /// This cache is updated at the start of each connection, or by calling <see cref="UpdateMetadataCache(bool)"/>
        /// </remarks>
        [XmlIgnore]
        public EntityMetadata[] MetadataCache => _metadataCache.EntityMetadata;

        /// <summary>
        /// Returns a task that provides access to the <see cref="MetadataCache"/> once it has finished loading
        /// </summary>
        [XmlIgnore]
        public Task<MetadataCache> MetadataCacheLoader { get; private set; } = Task.FromResult<MetadataCache>(null);

        public AuthenticationType NewAuthType { get; set; }

        /// <summary>
        /// Get or set the organization name
        /// </summary>
        public string Organization { get; set; }

        public string OrganizationDataServiceUrl { get; set; }

        /// <summary>
        /// Get or set the organization friendly name
        /// </summary>
        public string OrganizationFriendlyName { get; set; }

        public int OrganizationMajorVersion => OrganizationVersion != null ? int.Parse(OrganizationVersion.Split('.')[0]) : -1;
        public int OrganizationMinorVersion => OrganizationVersion != null ? int.Parse(OrganizationVersion.Split('.')[1]) : -1;

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
        public bool PasswordIsEmpty => string.IsNullOrEmpty(userPassword);

        /// <summary>
        /// OAuth Refresh Token
        /// </summary>
        public string RefreshToken { get; set; }

        public string ReplyUrl { get; set; }

        /// <summary>
        /// Client Secret used for S2S Auth
        /// </summary>
        public string S2SClientSecret
        {
            get => clientSecret;
            set => clientSecret = value;
        }

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
        [XmlIgnore]
        public int? ServerPort { get; set; }

        [XmlElement("ServerPort")]
        public string ServerPortString
        {
            get => ServerPort.ToString();
            set => ServerPort = string.IsNullOrEmpty(value) ? 80 : int.Parse(value);
        }

        [XmlIgnore]
        public CrmServiceClient ServiceClient
        {
            get => GetCrmServiceClient();
            set
            {
                crmSvc = value;
                SetImpersonationCapability();
            }
        }

        public Guid TenantId { get; set; }
        public TimeSpan Timeout { get; set; }

        public long TimeoutTicks
        {
            get { return Timeout.Ticks; }
            set { Timeout = new TimeSpan(value); }
        }

        [XmlIgnore]
        public bool UseConnectionString => !string.IsNullOrEmpty(ConnectionString);

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
        [XmlIgnore]
        public bool UseOnline => OriginalUrl.IndexOf(".dynamics.com", StringComparison.InvariantCultureIgnoreCase) > 0;

        /// <summary>
        /// Get or set the user domain name
        /// </summary>
        public string UserDomain { get; set; }

        /// <summary>
        /// Get or set flag to know if we use Online Services
        /// </summary>
        //public bool UseOsdp { get; set; }
        /// <summary>
        /// Get or set user login
        /// </summary>
        public string UserName { get; set; }

        [XmlElement("UserPassword")]
        public string UserPasswordEncrypted
        {
            get => userPassword;
            set => userPassword = value;
        }

        /// <summary>
        /// Get or set the use of SSL connection
        /// </summary>
        [XmlIgnore]
        public bool UseSsl => WebApplicationUrl?.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ?? OriginalUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase);

        public string WebApplicationUrl { get; set; }

        #endregion Propriétés

        #region Méthodes

        public void ErasePassword()
        {
            userPassword = null;
            clientSecret = null;
        }

        public CrmServiceClient GetCrmServiceClient(bool forceNewService = false)
        {
            if (forceNewService == false && crmSvc != null)
            {
                SetImpersonationCapability();

                return crmSvc;
            }
            if (Timeout.Ticks == 0)
            {
                Timeout = new TimeSpan(0, 2, 0);
            }
            CrmServiceClient.MaxConnectionTimeout = Timeout;

            if (Certificate != null)
            {
                var cs = HandleConnectionString($"AuthType=Certificate;url={OriginalUrl};thumbprint={Certificate.Thumbprint};ClientId={AzureAdAppId};");
                crmSvc = new CrmServiceClient(cs);
            }
            else if (!string.IsNullOrEmpty(ConnectionString))
            {
                var cs = HandleConnectionString(ConnectionString);
                crmSvc = new CrmServiceClient(cs);
            }
            else if (NewAuthType == AuthenticationType.ClientSecret)
            {
                var cs = HandleConnectionString($"AuthType=ClientSecret;url={OriginalUrl};ClientId={AzureAdAppId};ClientSecret={clientSecret}");
                crmSvc = new CrmServiceClient(cs);
            }
            else if (NewAuthType == AuthenticationType.OAuth && UseMfa)
            {
                var path = Path.Combine(Path.GetTempPath(), ConnectionId.Value.ToString("B"));

                var cs = HandleConnectionString($"AuthType=OAuth;Username={UserName};Url={OriginalUrl};AppId={AzureAdAppId};RedirectUri={ReplyUrl};TokenCacheStorePath={path};LoginPrompt=Auto");
                crmSvc = new CrmServiceClient(cs);
            }
            else if (!string.IsNullOrEmpty(clientSecret))
            {
                ConnectOAuth();
            }
            else if (UseOnline)
            {
                ConnectOnline();
            }
            else if (UseIfd)
            {
                ConnectIfd();
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

            SetImpersonationCapability();

            OrganizationFriendlyName = crmSvc.ConnectedOrgFriendlyName;
            OrganizationDataServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationDataService];
            OrganizationServiceUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.OrganizationService];
            WebApplicationUrl = crmSvc.ConnectedOrgPublishedEndpoints[EndpointType.WebApplication];
            Organization = crmSvc.ConnectedOrgUniqueName;
            OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();
            TenantId = crmSvc.TenantId;
            EnvironmentId = crmSvc.EnvironmentId;

            var webAppURi = new Uri(WebApplicationUrl);
            ServerName = webAppURi.Host;
            ServerPort = webAppURi.Port;

            //UseIfd = crmSvc.ActiveAuthenticationType == AuthenticationType.IFD;

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

        public void SetConnectionString(string connectionString)
        {
            var csb = new DbConnectionStringBuilder { ConnectionString = connectionString };

            OriginalUrl = (csb.ContainsKey("ServiceUri") ? csb["ServiceUri"] :
                csb.ContainsKey("Service Uri") ? csb["Service Uri"] :
                csb.ContainsKey("Url") ? csb["Url"] :
                csb.ContainsKey("Server") ? csb["Server"] : "").ToString();

            if (csb.ContainsKey("Password"))
            {
                csb["Password"] = CryptoManager.Encrypt(csb["Password"].ToString(), ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);
            }
            if (csb.ContainsKey("ClientSecret"))
            {
                csb["ClientSecret"] = CryptoManager.Encrypt(csb["ClientSecret"].ToString(), ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);
            }

            ConnectionString = csb.ToString();
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

        public bool TryRequestClientSecret(Control parent, string secretUsageDescription, out string secret, out SensitiveDataNotFoundReason notFoundReason)
        {
            var prd = new PasswordRequestDialog(secretUsageDescription, this, "client secret");
            if (AllowPasswordSharing || prd.ShowDialog(parent) == DialogResult.OK && prd.Accepted)
            {
                if (string.IsNullOrEmpty(clientSecret))
                {
                    secret = string.Empty;
                    notFoundReason = SensitiveDataNotFoundReason.NotAccessible;
                    return false;
                }

                secret = CryptoManager.Decrypt(clientSecret, ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);

                notFoundReason = SensitiveDataNotFoundReason.None;
                return true;
            }

            notFoundReason = SensitiveDataNotFoundReason.NotAllowedByUser;
            secret = string.Empty;
            return false;
        }

        public bool TryRequestPassword(Control parent, string passwordUsageDescription, out string password, out SensitiveDataNotFoundReason notFoundReason)
        {
            var prd = new PasswordRequestDialog(passwordUsageDescription, this, "password");
            if (AllowPasswordSharing || prd.ShowDialog(parent) == DialogResult.OK && prd.Accepted)
            {
                if (string.IsNullOrEmpty(userPassword))
                {
                    password = string.Empty;
                    notFoundReason = SensitiveDataNotFoundReason.NotAccessible;
                    return false;
                }

                password = CryptoManager.Decrypt(userPassword, ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);

                notFoundReason = SensitiveDataNotFoundReason.None;
                return true;
            }

            notFoundReason = SensitiveDataNotFoundReason.NotAllowedByUser;
            password = string.Empty;
            return false;
        }

        public void UpdateAfterEdit(ConnectionDetail editedConnection)
        {
            ConnectionName = editedConnection.ConnectionName;
            ConnectionString = editedConnection.ConnectionString;
            OrganizationServiceUrl = editedConnection.OrganizationServiceUrl;
            OrganizationDataServiceUrl = editedConnection.OrganizationDataServiceUrl;
            Organization = editedConnection.Organization;
            OrganizationFriendlyName = editedConnection.OrganizationFriendlyName;
            ServerName = editedConnection.ServerName;
            ServerPort = editedConnection.ServerPort;
            UseIfd = editedConnection.UseIfd;
            UserDomain = editedConnection.UserDomain;
            UserName = editedConnection.UserName;
            userPassword = editedConnection.userPassword;
            HomeRealmUrl = editedConnection.HomeRealmUrl;
            Timeout = editedConnection.Timeout;
            UseMfa = editedConnection.UseMfa;
            ReplyUrl = editedConnection.ReplyUrl;
            AzureAdAppId = editedConnection.AzureAdAppId;
            clientSecret = editedConnection.clientSecret;
            RefreshToken = editedConnection.RefreshToken;
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
            if (!string.IsNullOrEmpty(RefreshToken))
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
            else
            {
                crmSvc = new CrmServiceClient(UserName, CrmServiceClient.MakeSecureString(password),
                    region,
                    orgName,
                    true,
                    true,
                    null,
                    true);
            }
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

        private string HandleConnectionString(string connectionString)
        {
            var csb = new DbConnectionStringBuilder { ConnectionString = connectionString };
            if (csb.ContainsKey("timeout"))
            {
                var csTimeout = TimeSpan.Parse(csb["timeout"].ToString());
                csb.Remove("timeout");
                CrmServiceClient.MaxConnectionTimeout = csTimeout;
            }

            OriginalUrl = csb["Url"].ToString();
            UserName = csb.ContainsKey("username") ? csb["username"].ToString() :
                csb.ContainsKey("clientid") ? csb["clientid"].ToString() : null;

            if (csb.ContainsKey("Password"))
            {
                csb["Password"] = CryptoManager.Decrypt(csb["Password"].ToString(), ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);
            }
            if (csb.ContainsKey("ClientSecret"))
            {
                csb["ClientSecret"] = CryptoManager.Decrypt(csb["ClientSecret"].ToString(), ConnectionManager.CryptoPassPhrase,
                    ConnectionManager.CryptoSaltValue,
                    ConnectionManager.CryptoHashAlgorythm,
                    ConnectionManager.CryptoPasswordIterations,
                    ConnectionManager.CryptoInitVector,
                    ConnectionManager.CryptoKeySize);
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

            return cs;
        }

        private void SetImpersonationCapability()
        {
            var query = new QueryExpression("systemuserroles")
            {
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("systemuserid", ConditionOperator.EqualUserId)
                    }
                },
                LinkEntities =
                {
                    new LinkEntity
                    {
                        LinkFromEntityName = "systemuserroles",
                        LinkFromAttributeName = "roleid",
                        LinkToAttributeName = "roleid",
                        LinkToEntityName = "role",

                        LinkEntities =
                        {
                            new LinkEntity
                            {
                                LinkFromEntityName = "role",
                                LinkFromAttributeName = "roleid",
                                LinkToAttributeName = "roleid",
                                LinkToEntityName = "roleprivileges",
                                EntityAlias = "priv",
                                Columns = new ColumnSet("privilegedepthmask"),
                                LinkEntities =
                                {
                                    new LinkEntity
                                    {
                                        LinkFromEntityName = "roleprivileges",
                                        LinkFromAttributeName = "privilegeid",
                                        LinkToAttributeName = "privilegeid",
                                        LinkToEntityName = "privilege", LinkCriteria = new FilterExpression
                                        {
                                            Conditions =
                                            {
                                                new ConditionExpression("name", ConditionOperator.Equal, "prvActOnBehalfOfAnotherUser"),
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var privileges = crmSvc.RetrieveMultiple(query).Entities;

            CanImpersonate = privileges.Any(p =>
                (int)p.GetAttributeValue<AliasedValue>("priv.privilegedepthmask").Value == 8);
        }

        #endregion Méthodes

        public object Clone()
        {
            var cd = new ConnectionDetail
            {
                AuthType = AuthType,
                ConnectionId = Guid.NewGuid(),
                ConnectionName = ConnectionName,
                ConnectionString = ConnectionString,
                HomeRealmUrl = HomeRealmUrl,
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
                UserDomain = UserDomain,
                UserName = UserName,
                userPassword = userPassword,
                WebApplicationUrl = WebApplicationUrl,
                OriginalUrl = OriginalUrl,
                Timeout = Timeout,
                UseMfa = UseMfa,
                AzureAdAppId = AzureAdAppId,
                ReplyUrl = ReplyUrl,
                EnvironmentText = EnvironmentText,
                EnvironmentColor = EnvironmentColor,
                EnvironmentTextColor = EnvironmentTextColor,
                RefreshToken = RefreshToken,
                S2SClientSecret = S2SClientSecret,
                IsFromSdkLoginCtrl = IsFromSdkLoginCtrl,
            };

            if (Certificate != null)
            {
                cd.Certificate = new CertificateInfo
                {
                    Issuer = Certificate.Issuer,
                    Thumbprint = Certificate.Thumbprint,
                    Name = Certificate.Name
                };
            }

            return cd;
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

            if (Certificate != null)
            {
                csb["AuthType"] = "Certificate";
                csb["ClientId"] = AzureAdAppId;
                csb["Thumbprint"] = Certificate.Thumbprint;

                return csb.ToString();
            }

            if (!string.IsNullOrEmpty(clientSecret))
            {
                csb["AuthType"] = "ClientSecret";
                csb["ClientId"] = AzureAdAppId.ToString("B");
                csb["ClientSecret"] = "*************";

                return csb.ToString();
            }

            if (UseMfa)
            {
                csb["Username"] = UserName;
                csb["AuthType"] = "OAuth";
                csb["ClientId"] = AzureAdAppId.ToString("B");
                csb["LoginPrompt"] = "Auto";
                csb["RedirectUri"] = ReplyUrl;
                csb["TokenCacheStorePath"] = Path.Combine(Path.GetTempPath(), ConnectionId.Value.ToString("B"), "oauth-cache.txt");

                return csb.ToString();
            }

            if (!string.IsNullOrEmpty(UserDomain))
                csb["Domain"] = UserDomain;
            csb["Username"] = UserName;
            csb["Password"] = "********";

            if (!string.IsNullOrEmpty(HomeRealmUrl))
                csb["HomeRealmUri"] = HomeRealmUrl;

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
                || originalDetail.UseSsl != UseSsl
                || originalDetail.UseMfa != UseMfa
                || originalDetail.clientSecret != clientSecret
                || originalDetail.AzureAdAppId != AzureAdAppId
                || originalDetail.ReplyUrl != ReplyUrl
                || originalDetail.UserDomain?.ToLower() != UserDomain?.ToLower()
                || originalDetail.UserName?.ToLower() != UserName?.ToLower()
                || SavePassword && !string.IsNullOrEmpty(userPassword) && originalDetail.userPassword != userPassword
                || SavePassword && !string.IsNullOrEmpty(clientSecret) && originalDetail.clientSecret != clientSecret
                || originalDetail.Certificate.Thumbprint != Certificate.Thumbprint)
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

        #region Impersonation methods

        public event EventHandler<ImpersonationEventArgs> OnImpersonate;

        public void Impersonate(Guid userId, string username = null)
        {
            impersonatedUserId = userId;
            impersonatedUserName = username;

            ServiceClient.CallerId = userId;

            OnImpersonate?.Invoke(this, new ImpersonationEventArgs(impersonatedUserId, impersonatedUserName));
        }

        public void RemoveImpersonation()
        {
            impersonatedUserId = Guid.Empty;
            impersonatedUserName = null;

            ServiceClient.CallerId = Guid.Empty;

            OnImpersonate?.Invoke(this, new ImpersonationEventArgs(impersonatedUserId, impersonatedUserName));
        }

        #endregion Impersonation methods

        #region Metadata Cache methods

        /// <summary>
        /// Updates the <see cref="MetadataCache"/>
        /// </summary>
        /// <param name="flush">Indicates if the existing cache should be flushed and a full new copy of the metadata should be retrieved</param>
        public Task UpdateMetadataCache(bool flush)
        {
            if (OrganizationMajorVersion < 8)
                throw new NotSupportedException("Metadata cache is only supported on Dynamics CRM 2016 or later");

            // If there's already an update in progress, don't start a new one
            if (!MetadataCacheLoader.IsCompleted)
                return MetadataCacheLoader;

            // Load the metadata in a background task
            var task = new Task<MetadataCache>(() =>
            {
                // Load & update metadata cache
                var metadataCachePath = Path.Combine(Path.GetDirectoryName(ConnectionsList.ConnectionsListFilePath), "..", "Metadata", ConnectionId + ".xml.gz");
                metadataCachePath = Path.IsPathRooted(metadataCachePath) ? metadataCachePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, metadataCachePath);

                var metadataSerializer = new DataContractSerializer(typeof(MetadataCache));
                var metadataCache = _metadataCache;

                if (metadataCache == null && File.Exists(metadataCachePath) && !flush)
                {
                    using (var stream = File.OpenRead(metadataCachePath))
                    using (var gz = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        metadataCache = (MetadataCache)metadataSerializer.ReadObject(gz);
                    }
                }

                // Get all the metadata that's changed since the last connection
                // If this query changes, increment the version number to ensure any previously cached versions are flushed
                const int queryVersion = 1;

                var metadataQuery = new RetrieveMetadataChangesRequest
                {
                    ClientVersionStamp = !flush && metadataCache?.MetadataQueryVersion == queryVersion ? metadataCache?.ClientVersionStamp : null,
                    Query = new EntityQueryExpression
                    {
                        Properties = new MetadataPropertiesExpression { AllProperties = true },
                        AttributeQuery = new AttributeQueryExpression
                        {
                            Properties = new MetadataPropertiesExpression { AllProperties = true }
                        },
                        RelationshipQuery = new RelationshipQueryExpression
                        {
                            Properties = new MetadataPropertiesExpression { AllProperties = true }
                        }
                    },
                    DeletedMetadataFilters = DeletedMetadataFilters.All
                };

                RetrieveMetadataChangesResponse metadataUpdate;

                try
                {
                    metadataUpdate = (RetrieveMetadataChangesResponse)ServiceClient.Execute(metadataQuery);
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    // If the last connection was too long ago, we need to request all the metadata, not just the changes
                    if (ex.Detail.ErrorCode == unchecked((int)0x80044352))
                    {
                        _metadataCache = null;
                        metadataQuery.ClientVersionStamp = null;
                        metadataUpdate = (RetrieveMetadataChangesResponse)ServiceClient.Execute(metadataQuery);
                    }
                    else
                    {
                        throw;
                    }
                }

                if (metadataCache == null || flush)
                {
                    // If we didn't have a previous cache, just start a fresh one
                    metadataCache = new MetadataCache();
                    metadataCache.EntityMetadata = metadataUpdate.EntityMetadata.ToArray();
                    metadataCache.MetadataQueryVersion = queryVersion;
                }
                else
                {
                    // We had a cached version of the metadata before, so now we need to merge in the changes
                    var deletedIds = metadataUpdate.DeletedMetadata == null ? new List<Guid>() : metadataUpdate.DeletedMetadata.SelectMany(kvp => kvp.Value).Distinct().ToList();

                    CopyChanges(metadataCache, typeof(MetadataCache).GetProperty(nameof(Connection.MetadataCache.EntityMetadata)), metadataUpdate.EntityMetadata.ToArray(), deletedIds);
                }

                _metadataCache = metadataCache;

                // Save the latest metadata cache
                if (metadataCache.ClientVersionStamp != metadataUpdate.ServerVersionStamp ||
                    metadataCache.MetadataQueryVersion != queryVersion)
                {
                    metadataCache.ClientVersionStamp = metadataUpdate.ServerVersionStamp;
                    metadataCache.MetadataQueryVersion = queryVersion;

                    Directory.CreateDirectory(Path.GetDirectoryName(metadataCachePath));

                    using (var stream = File.Create(metadataCachePath))
                    using (var gz = new GZipStream(stream, CompressionLevel.Optimal))
                    {
                        metadataSerializer.WriteObject(gz, metadataCache);
                    }
                }

                return metadataCache;
            });
            task.ConfigureAwait(false);

            // Store the current metadata loading task and run it
            MetadataCacheLoader = task;
            task.Start();
            return task;
        }

        private void CopyChanges(object source, PropertyInfo sourceProperty, MetadataBase[] newArray, List<Guid> deletedIds)
        {
            var existingArray = (MetadataBase[])sourceProperty.GetValue(source);
            var existingList = new List<MetadataBase>(existingArray);

            // Add any new items and update any modified ones
            foreach (var newItem in newArray)
            {
                var existingItem = existingList.SingleOrDefault(e => e.MetadataId == newItem.MetadataId);

                if (existingItem == null)
                    existingList.Add(newItem);
                else
                    CopyChanges(existingItem, newItem, deletedIds);
            }

            // Remove any deleted items
            existingList.RemoveAll(e => deletedIds.Contains(e.MetadataId.Value));

            // Store the new array
            var updatedArray = Array.CreateInstance(sourceProperty.PropertyType.GetElementType(), existingList.Count);

            for (var i = 0; i < existingList.Count; i++)
                updatedArray.SetValue(existingList[i], i);

            sourceProperty.SetValue(source, updatedArray);
        }

        private void CopyChanges(MetadataBase existingItem, MetadataBase newItem, List<Guid> deletedIds)
        {
            foreach (var prop in existingItem.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!Attribute.IsDefined(prop, typeof(DataMemberAttribute)))
                    continue;

                var newValue = prop.GetValue(newItem);
                var existingValue = prop.GetValue(existingItem) as MetadataBase;
                var type = prop.PropertyType;

                if (type.IsArray)
                    type = type.GetElementType();

                if (!typeof(MetadataBase).IsAssignableFrom(type) && !typeof(Label).IsAssignableFrom(type))
                {
                    prop.SetValue(existingItem, newValue);
                }
                else if (typeof(Label).IsAssignableFrom(type))
                {
                    CopyChanges((Label)prop.GetValue(existingItem), (Label)newValue, deletedIds);
                }
                else if (newValue != null)
                {
                    if (prop.PropertyType.IsArray)
                    {
                        CopyChanges(existingItem, prop, (MetadataBase[])newValue, deletedIds);
                    }
                    else
                    {
                        if (existingValue.MetadataId == ((MetadataBase)newValue).MetadataId)
                            CopyChanges(existingValue, (MetadataBase)newValue, deletedIds);
                        else
                            prop.SetValue(existingItem, newValue);
                    }
                }
                else if (existingValue != null && deletedIds.Contains(existingValue.MetadataId.Value))
                {
                    prop.SetValue(existingItem, null);
                }
            }
        }

        private void CopyChanges(Label existingLabel, Label newLabel, List<Guid> deletedIds)
        {
            if (newLabel == null)
                return;

            foreach (var localizedLabel in newLabel.LocalizedLabels)
            {
                var existingLocalizedLabel = existingLabel.LocalizedLabels.SingleOrDefault(ll => ll.MetadataId == localizedLabel.MetadataId);

                if (existingLocalizedLabel == null)
                    existingLabel.LocalizedLabels.Add(localizedLabel);
                else
                    CopyChanges(existingLocalizedLabel, localizedLabel, deletedIds);
            }

            for (var i = existingLabel.LocalizedLabels.Count - 1; i >= 0; i--)
            {
                if (deletedIds.Contains(existingLabel.LocalizedLabels[i].MetadataId.Value))
                    existingLabel.LocalizedLabels.RemoveAt(i);
            }

            if (newLabel.UserLocalizedLabel != null)
                CopyChanges(existingLabel.UserLocalizedLabel, newLabel.UserLocalizedLabel, deletedIds);
        }

        #endregion Metadata Cache methods
    }

    public class EnvironmentHighlighting
    {
        [XmlIgnore]
        public Color? Color { get; set; }

        [XmlElement("Color")]
        public string ColorString
        {
            get => ColorTranslator.ToHtml(Color ?? System.Drawing.Color.Black);
            set => Color = ColorTranslator.FromHtml(value);
        }

        public string Text { get; set; }

        [XmlIgnore]
        public Color? TextColor { get; set; }

        [XmlElement("TextColor")]
        public string TextColorString
        {
            get => ColorTranslator.ToHtml(TextColor ?? System.Drawing.Color.Black);
            set => TextColor = ColorTranslator.FromHtml(value);
        }
    }
}