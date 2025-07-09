using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace McTools.Xrm.Connection
{
    /// <summary>
    /// Class that stores all <see cref="ConnectionFile"/> items
    /// </summary>
    public class ConnectionsList
    {
        private static ConnectionsList _instance;

        private ConnectionsList()
        {
            Files = new List<ConnectionFile>();
        }

        public static string ConnectionsListFilePath { get; set; } = "MscrmTools.ConnectionsList.xml";

        public static ConnectionsList Instance
        {
            get
            {
                if (_instance == null)
                {
                    var filename = Path.IsPathRooted(ConnectionsListFilePath) ? ConnectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                        ConnectionsListFilePath);

                    if (File.Exists(filename))
                    {
                        using (var sr = new StreamReader(filename))
                        {
                            _instance = (ConnectionsList)XmlSerializerHelper.Deserialize(sr.ReadToEnd(), typeof(ConnectionsList));
                        }
                    }
                    else
                    {
                        var directory = new FileInfo(filename).DirectoryName;

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        var defaultFilePath = Path.Combine(directory, "ConnectionsList.Default.xml");

                        var cc = new CrmConnections("Default") { UseInternetExplorerProxy = true };
                        cc.SerializeToFile(defaultFilePath);

                        _instance = new ConnectionsList();
                        _instance.Files.Add(new ConnectionFile(cc) { Path = defaultFilePath });
                        _instance.Save();
                    }
                }

                return _instance;
            }
        }

        public List<ConnectionFile> Files { get; set; }

        public void Save()
        {
            var filename = Path.IsPathRooted(ConnectionsListFilePath) ? ConnectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                       ConnectionsListFilePath);

            XmlSerializerHelper.SerializeToFile(_instance, filename);
        }
    }
}