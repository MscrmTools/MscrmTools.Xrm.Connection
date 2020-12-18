using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace McTools.Xrm.Connection
{
    /// <summary>
    /// Stores the list of Crm connections
    /// </summary>
    public class CrmConnections
    {
        #region Variables

        private static readonly object _fileAccess = new object();

        #endregion Variables

        public CrmConnections(string name)
        {
            Connections = new List<ConnectionDetail>();
            Name = name;
        }

        public CrmConnections()
        {
        }

        #region Propriétés

        public bool ByPassProxyOnLocal { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des connexions
        /// </summary>
        public List<ConnectionDetail> Connections { get; set; }

        /// <summary>
        /// Indicates if this connection list can be updated
        /// </summary>
        public bool IsReadOnly { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ProxyAddress { get; set; }

        public bool UseCustomProxy { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public bool UseInternetExplorerProxy { get; set; }

        public bool UseMruDisplay { get; set; }

        public string UserName { get; set; }

        #endregion Propriétés

        #region methods

        public static CrmConnections LoadFromFile(string filePath)
        {
            var crmConnections = new CrmConnections("Default");

            if (!Uri.IsWellFormedUriString(filePath, UriKind.Absolute) && !File.Exists(filePath))
            {
                return crmConnections;
            }

            using (var fStream = OpenStream(filePath))
            {
                if (!fStream.CanSeek || fStream.Length > 0)
                {
                    return (CrmConnections)XmlSerializerHelper.Deserialize(fStream, typeof(CrmConnections), typeof(ConnectionDetail));
                }
            }

            Thread.Sleep(1000);
            // try again
            using (var fStream = OpenStream(filePath))
            {
                return (CrmConnections)XmlSerializerHelper.Deserialize(fStream, typeof(CrmConnections), typeof(ConnectionDetail));
            }
        }

        public ConnectionDetail CloneConnection(ConnectionDetail detail)
        {
            var newDetail = (ConnectionDetail)detail.Clone();
            newDetail.ConnectionId = Guid.NewGuid();

            int cloneId = 0;
            string newName;
            do
            {
                cloneId++;
                newName = string.Format("{0} ({1})", newDetail.ConnectionName, cloneId);
            } while (Connections.Any(c => c.ConnectionName == newName));

            newDetail.ConnectionName = newName;

            Connections.Add(newDetail);

            return newDetail;
        }

        public void SerializeToFile(string filePath)
        {
            if (Uri.IsWellFormedUriString(filePath, UriKind.Absolute))
                return;

            var passwords = new Dictionary<Guid, string>();
            var secrets = new Dictionary<Guid, string>();
            foreach (var connection in Connections)
            {
                if (!connection.SavePassword)
                {
                    if (!connection.PasswordIsEmpty)
                    {
                        passwords.Add(connection.ConnectionId ?? Guid.Empty, connection.UserPasswordEncrypted);
                        connection.ErasePassword();
                    }
                    if (!connection.ClientSecretIsEmpty)
                    {
                        secrets.Add(connection.ConnectionId ?? Guid.Empty, connection.S2SClientSecret);
                        connection.ErasePassword();
                    }
                }
            }

            lock (_fileAccess)
            {
                XmlSerializerHelper.SerializeToFile(this, filePath, typeof(ConnectionDetail));
            }

            foreach (var connection in Connections)
            {
                if (passwords.ContainsKey(connection.ConnectionId ?? Guid.Empty))
                {
                    connection.SetPassword(passwords[connection.ConnectionId ?? Guid.Empty], true);
                }
                if (secrets.ContainsKey(connection.ConnectionId ?? Guid.Empty))
                {
                    connection.SetClientSecret(secrets[connection.ConnectionId ?? Guid.Empty], true);
                }
            }

            passwords.Clear();
            secrets.Clear();
        }

        public override string ToString()
        {
            return Name;
        }

        private static Stream OpenStream(string filePath)
        {
            if (Uri.IsWellFormedUriString(filePath, UriKind.Absolute))
            {
                var req = WebRequest.Create(filePath);
                req.Credentials = CredentialCache.DefaultCredentials;
                var resp = req.GetResponse();
                return resp.GetResponseStream();
            }

            return File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        #endregion methods
    }
}