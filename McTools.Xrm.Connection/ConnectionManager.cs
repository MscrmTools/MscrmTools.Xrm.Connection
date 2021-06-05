using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EndpointCollection = Microsoft.Xrm.Sdk.Organization.EndpointCollection;

namespace McTools.Xrm.Connection
{
    #region Event Args Class Definition

    public class ConnectionFailedEventArgs : EventArgs
    {
        public ConnectionDetail ConnectionDetail { get; set; }
        public string FailureReason { get; set; }
        public int NumberOfConnectionsRequested { get; set; }
        public object Parameter { get; set; }
    }

    public class ConnectionSucceedEventArgs : EventArgs
    {
        public ConnectionDetail ConnectionDetail { get; set; }
        public int NumberOfConnectionsRequested { get; set; }
        public IOrganizationService OrganizationService { get; set; }
        public object Parameter { get; set; }
    }

    public class DeleteConnectionEventArgs : EventArgs
    {
    }

    public class EditConnectEventArgs : EventArgs
    {
    }

    public class RequestPasswordEventArgs : EventArgs
    {
        public RequestPasswordEventArgs(ConnectionDetail connectionDetail)
        {
            ConnectionDetail = connectionDetail;
        }

        public ConnectionDetail ConnectionDetail { get; set; }
    }

    public class StepChangedEventArgs : EventArgs
    {
        public string CurrentStep { get; set; }
    }

    public class UseProxyEventArgs : EventArgs
    {
        public IWebProxy Proxy { get; set; }
    }

    #endregion Event Args Class Definition

    /// <summary>
    /// Manager that handles all connection operations
    /// </summary>
    public class ConnectionManager
    {
        #region Delegates

        public delegate void ConnectionFailedEventHandler(object sender, ConnectionFailedEventArgs e);

        public delegate void ConnectionListUpdatedEventHandler(object sender, EventArgs e);

        public delegate void ConnectionSucceedEventHandler(object sender, ConnectionSucceedEventArgs e);

        public delegate bool RequestPasswordEventHandler(object sender, RequestPasswordEventArgs e);

        public delegate void StepChangedEventHandler(object sender, StepChangedEventArgs e);

        public delegate void UseProxyEventHandler(object sender, UseProxyEventArgs e);

        #endregion Delegates

        #region Event Handlers

        public event ConnectionFailedEventHandler ConnectionFailed;

        public event ConnectionListUpdatedEventHandler ConnectionListUpdated;

        public event ConnectionSucceedEventHandler ConnectionSucceed;

        public event RequestPasswordEventHandler RequestPassword;

        public event StepChangedEventHandler StepChanged;

        public event UseProxyEventHandler UseProxy;

        #endregion Event Handlers

        #region Constants

        internal const string CryptoHashAlgorythm = "SHA1";
        internal const string CryptoInitVector = "ahC3@bCa2Didfc3d";
        internal const int CryptoKeySize = 256;
        internal const string CryptoPassPhrase = "MsCrmTools";
        internal const int CryptoPasswordIterations = 2;
        internal const string CryptoSaltValue = "Tanguy 92*";
        private const string DefaultConfigFileName = "mscrmtools2011.config";

        #endregion Constants

        private static string configfile;
        private static Lazy<ConnectionManager> instance = new Lazy<ConnectionManager>(() => new ConnectionManager());
        private Dictionary<Guid, CrmServiceClient> crmServices;
        private FileSystemWatcher fsw;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class ConnectionManager
        /// </summary>
        private ConnectionManager()
        {
            crmServices = new Dictionary<Guid, CrmServiceClient>();
            ConnectionsList = LoadConnectionsList();
            SetupFileSystemWatcher();
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }

        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(
        object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors policyErrors
        )
        {
            return true;
        }

        private void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                ConnectionsList = LoadConnectionsList();
            }
        }

        private void SetupFileSystemWatcher()
        {
            if (fsw != null)
            {   // If it was already watching something, stop that!
                fsw.EnableRaisingEvents = false;
                fsw.Changed -= fsw_Changed;
                fsw.Dispose();
            }

            if (Uri.IsWellFormedUriString(ConfigurationFile, UriKind.Absolute))
                return;

            var path = new FileInfo(ConfigurationFile).Directory.FullName;

            if (Directory.Exists(path))
            {
                fsw = new FileSystemWatcher(path, Path.GetFileName(ConfigurationFile))
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
                    EnableRaisingEvents = true
                };
                fsw.Changed += fsw_Changed;
            }
        }

        #endregion Constructor

        #region Properties

        public static string ConfigurationFile
        {
            get
            {
                if (string.IsNullOrEmpty(configfile))
                {
                    var lastUsedFile = Connection.ConnectionsList.Instance.Files.OrderByDescending(f => f.LastUsed).FirstOrDefault();
                    if (lastUsedFile != null)
                    {
                        return lastUsedFile.Path;
                    }
                }

                return string.IsNullOrEmpty(configfile) ? DefaultConfigFileName : configfile;
            }
            set
            {
                configfile = value;
                if (instance != null)
                {
                    var existingFile = Connection.ConnectionsList.Instance.Files.FirstOrDefault(f => f.Path == value);
                    if (existingFile == null)
                    {
                        CrmConnections newCc = CrmConnections.LoadFromFile(value);

                        Connection.ConnectionsList.Instance.Files.Add(new ConnectionFile(newCc) { Path = configfile, LastUsed = DateTime.Now });
                        Connection.ConnectionsList.Instance.Save();
                    }

                    Instance.ConnectionsList = Instance.LoadConnectionsList();
                    Instance.SetupFileSystemWatcher();
                    Instance.ConnectionListUpdated?.Invoke(null, new EventArgs());
                }
            }
        }

        public static ConnectionManager Instance
        {
            get =>
                instance.Value;
        }

        /// <summary>
        /// List of Crm connections
        /// </summary>
        public CrmConnections ConnectionsList
        {
            get;
            set;
        }

        public bool FromXrmToolBox
        {
            get;
            set;
        }

        public bool ReuseConnections
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks if a configuration file exists
        /// </summary>
        /// <param name="path">The file to check for</param>
        /// <returns><c>true</c> if the <paramref name="path"/> exists, or <c>false</c> otherwise</returns>
        public static bool FileExists(string path)
        {
            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                try
                {
                    var req = WebRequest.Create(path);
                    req.Credentials = CredentialCache.DefaultCredentials;
                    using (req.GetResponse())
                    {
                        return true;
                    }
                }
                catch (WebException)
                {
                    return false;
                }
            }

            return File.Exists(path);
        }

        /// <summary>
        /// Launch the Crm connection process
        /// </summary>
        /// <param name="details">Details of the Crm connection</param>
        /// <param name="connectionParameter">A parameter to retrieve after connection</param>
        public void ConnectToServer(List<ConnectionDetail> details, object connectionParameter)
        {
            foreach (var detail in details)
            {
                var parameters = new List<object> { detail, connectionParameter, details.Count };

                // Runs the connection asynchronously
                var worker = new BackgroundWorker();
                worker.DoWork += WorkerDoWork;
                worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
                worker.RunWorkerAsync(parameters);
            }
        }

        /// <summary>
        /// Launch the Crm connection process
        /// </summary>
        /// <param name="details">Details of the Crm connection</param>
        public void ConnectToServer(List<ConnectionDetail> details) =>
            ConnectToServer(details, null);

        /// <summary>
        /// Restore Crm connections list from the file
        /// </summary>
        /// <returns>List of Crm connections</returns>
        public CrmConnections LoadConnectionsList()
        {
            try
            {
                CrmConnections crmConnections;
                if (FileExists(ConfigurationFile))
                {
                    crmConnections = CrmConnections.LoadFromFile(ConfigurationFile);

                    if (!string.IsNullOrEmpty(crmConnections.Password))
                    {
                        crmConnections.Password = CryptoManager.Decrypt(crmConnections.Password,
                        CryptoPassPhrase,
                        CryptoSaltValue,
                        CryptoHashAlgorythm,
                        CryptoPasswordIterations,
                        CryptoInitVector,
                        CryptoKeySize);
                    }

                    foreach (var detail in crmConnections.Connections)
                    {
                        // Fix for new connection code
                        if (string.IsNullOrEmpty(detail.OrganizationUrlName))
                        {
                            if (detail.UseIfd || detail.UseOnline)
                            {
                                var uri = new Uri(detail.OrganizationServiceUrl);
                                detail.OrganizationUrlName = uri.Host.Split('.')[0];
                            }
                            else
                            {
                                detail.OrganizationUrlName = detail.Organization;
                            }
                        }

                        // Fix old connection for TimeOut
                        if (detail.Timeout == TimeSpan.Zero)
                        {
                            detail.Timeout = new TimeSpan(1200000000);
                        }
                    }
                }
                else
                {
                    crmConnections = new CrmConnections("Default")
                    {
                        Connections = new List<ConnectionDetail>()
                    };
                }

                return crmConnections;
            }
            catch (Exception error)
            {
                var appLocation = Assembly.GetExecutingAssembly().Location;
                var fi = new FileInfo(appLocation);

                using (var writer = new StreamWriter(Path.Combine(fi.DirectoryName, "connection_debug.log"), true))
                {
                    writer.WriteLine($"{DateTime.Now}\tLoadConnectionsList\t{error.Message}");
                }

                throw new Exception("Error while deserializing configuration file. Details: " + error.Message);
            }
        }

        /// <summary>
        /// Saves Crm connections list to file
        /// </summary>
        public void SaveConnectionsFile()
        {
            if (!string.IsNullOrEmpty(ConnectionsList.Password))
            {
                ConnectionsList.Password = CryptoManager.Encrypt(ConnectionsList.Password,
                    CryptoPassPhrase,
                    CryptoSaltValue,
                    CryptoHashAlgorythm,
                    CryptoPasswordIterations,
                    CryptoInitVector,
                    CryptoKeySize);
            }

            ConnectionsList.SerializeToFile(ConfigurationFile);
        }

        /// <summary>
        /// Tests the specified connection
        /// </summary>
        /// <param name="service">Organization service</param>
        public void TestConnection(IOrganizationService service)
        {
            try
            {
                SendStepChange("Testing connection...");

                var request = new WhoAmIRequest();
                service.Execute(request);
            }
            catch (Exception error)
            {
                throw new Exception("Test connection failed: " + CrmExceptionHelper.GetErrorMessage(error, false));
            }
        }

        /// <summary>
        /// Connects to a Crm server
        /// </summary>
        /// <param name="parameters">List of parameters</param>
        /// <returns>An exception or an IOrganizationService</returns>
        private object Connect(List<object> parameters)
        {
            if (WebRequest.DefaultWebProxy == null)
                WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();

            //Use default credentials if no proxy credentials
            if (WebRequest.DefaultWebProxy.Credentials == null)
                WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;

            var detail = (ConnectionDetail)parameters[0];

            if (ReuseConnections && crmServices.ContainsKey(detail.ConnectionId ?? Guid.Empty))
            {
                var service = crmServices[detail.ConnectionId ?? Guid.Empty];
                if (service.IsReady)
                {
                    detail.LastUsedOn = DateTime.Now;
                    SaveConnectionsFile();
                    return service;
                }
            }

            SendStepChange("Creating Organization service proxy...");

            // Connecting to Crm server
            try
            {
                var service = detail.GetCrmServiceClient();

                // The connection did not succeeded
                if (!service.IsReady)
                {
                    // If the connection really failed, the service has no endpoints
                    if (service.ConnectedOrgPublishedEndpoints == null)
                    {
                        throw new Exception(service.LastCrmError);
                    }

                    // When the configuration seems to be wrong, endpoints are available
                    // so we can check if there is a difference between what the user
                    // specified for connection.
                    var returnedWebAppUrl = service.ConnectedOrgPublishedEndpoints[Microsoft.Xrm.Sdk.Discovery.EndpointType.WebApplication];
                    if (detail.OriginalUrl.ToLower().IndexOf(returnedWebAppUrl.ToLower(), StringComparison.Ordinal) < 0)
                    {
                        string message =
                            "It seems that the connection information your provided are different from the one configured in your CRM deployment. Please review your connection information or contact your system administrator to ensure Microsoft Dynamics CRM is properly configured";

                        throw new Exception(string.Format("{0}{1}{1}{2}", service.LastCrmError, Environment.NewLine, message));
                    }
                }

                var endpoints = service.ConnectedOrgPublishedEndpoints != null ? EndpointCollection.FromDiscovery(service.ConnectedOrgPublishedEndpoints) : null;

                if (endpoints == null)
                {
                    // Some connection methods do not automatically retrieve the endpoints - get them now
                    var orgDetails = (RetrieveCurrentOrganizationResponse)service.Execute(new RetrieveCurrentOrganizationRequest());
                    endpoints = orgDetails.Detail.Endpoints;
                }

                detail.WebApplicationUrl = endpoints[EndpointType.WebApplication];
                detail.OrganizationDataServiceUrl = endpoints[EndpointType.OrganizationDataService];
                detail.OrganizationVersion = service.ConnectedOrgVersion.ToString();

                var currentConnection = ConnectionsList.Connections.FirstOrDefault(x => x.ConnectionId == detail.ConnectionId);
                if (currentConnection != null)
                {
                    currentConnection.WebApplicationUrl = detail.WebApplicationUrl;
                    currentConnection.OrganizationDataServiceUrl = detail.OrganizationDataServiceUrl;
                    currentConnection.OrganizationVersion = detail.OrganizationVersion;
                    currentConnection.SavePassword = detail.SavePassword;
                    detail.CopyPasswordTo(currentConnection);
                    detail.CopyClientSecretTo(currentConnection);
                }

                if (detail.OrganizationMajorVersion >= 8)
                {
                    UpdateMetadataCache(detail);
                }
                detail.LastUsedOn = DateTime.Now;

                SaveConnectionsFile();

                if (ReuseConnections && !crmServices.ContainsKey(detail.ConnectionId ?? Guid.Empty))
                {
                    crmServices.Add(detail.ConnectionId ?? Guid.Empty, service);
                }

                return service;
            }
            catch (Exception error)
            {
                return error;
            }
        }

        private void UpdateMetadataCache(ConnectionDetail detail)
        {
            SendStepChange("Updating Metadata Cache...");

            var task = detail.UpdateMetadataCache(false);
            task.ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                    SendStepChange("Metadata Cache Updated");
                else
                    SendStepChange("Metadata Cache Update Failed: " + t.Exception.InnerException.Message);
            });
        }

        /// <summary>
        /// Working process
        /// </summary>
        /// <param name="sender">BackgroundWorker object</param>
        /// <param name="e">BackgroundWorker object parameters</param>
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            object result = Connect((List<object>)e.Argument);
            e.Result = e.Argument;
            ((List<object>)e.Result).Add(result);
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var parameters = (List<object>)e.Result;

            if (parameters.Count == 4)
            {
                if (parameters[3] is Exception error)
                {
                    SendFailureMessage(parameters, CrmExceptionHelper.GetErrorMessage(error, false));
                }
                else
                {
                    if (parameters[3] is CrmServiceClient service)
                    {
                        SendSuccessMessage(service, parameters);
                    }
                }
            }
        }

        #endregion Methods

        #region Send Events

        /// <summary>
        /// Sends a connection failure message
        /// </summary>
        /// <param name="failureReason">Reason of the failure</param>
        /// <param name="parameters">Connection returned parameters</param>
        private void SendFailureMessage(List<object> parameters, string failureReason)
        {
            if (ConnectionFailed != null)
            {
                var args = new ConnectionFailedEventArgs
                {
                    FailureReason = failureReason,
                    ConnectionDetail = (ConnectionDetail)parameters[0],
                    Parameter = parameters[1],
                    NumberOfConnectionsRequested = (int)parameters[2]
                };

                ConnectionFailed(this, args);
            }
        }

        /// <summary>
        /// Sends a step change message
        /// </summary>
        /// <param name="step">New step</param>
        private void SendStepChange(string step)
        {
            var args = new StepChangedEventArgs
            {
                CurrentStep = step
            };

            StepChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Sends a connection success message
        /// </summary>
        /// <param name="service">IOrganizationService generated</param>
        /// <param name="parameters">List of parameters</param>
        private void SendSuccessMessage(IOrganizationService service, List<object> parameters)
        {
            if (ConnectionSucceed != null)
            {
                var args = new ConnectionSucceedEventArgs
                {
                    OrganizationService = service,
                    ConnectionDetail = (ConnectionDetail)parameters[0],
                    Parameter = parameters[1],
                    NumberOfConnectionsRequested = (int)parameters[2]
                };

                ConnectionSucceed(this, args);
            }
        }

        #endregion Send Events

        public void ConnectToServerWithSdkLoginCtrl(ConnectionDetail detail, CrmServiceClient crmSvc, object connectionParameter)
        {
            detail.ServiceClient = crmSvc;

            var parameters = new List<object> { detail, connectionParameter, 1 };

            if (crmSvc == null) return;

            detail.OrganizationVersion = crmSvc.ConnectedOrgVersion.ToString();

            if (detail.OrganizationMajorVersion >= 8)
            {
                UpdateMetadataCache(detail);
            }

            if (crmSvc.IsReady)
            {
                SendSuccessMessage(crmSvc, parameters);
            }
            else
            {
                SendFailureMessage(parameters, crmSvc.LastCrmError);
            }
        }
    }
}