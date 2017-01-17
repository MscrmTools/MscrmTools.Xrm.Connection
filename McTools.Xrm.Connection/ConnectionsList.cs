using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace McTools.Xrm.Connection
{
    public class ConnectionFile
    {
        public string  Name { get; set; }

        public ConnectionFile(){}

        public ConnectionFile(string name)
        {
            Name = name;
        }
        public ConnectionFile(CrmConnections Connections)
        {
            Name = Connections.Name;
        }

        public DateTime LastUsed { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ConnectionsList
    {
        private static ConnectionsList instance;
        private static string connectionsListFilePath = "MscrmTools.ConnectionsList.xml";

        private ConnectionsList()
        {
            Files = new List<ConnectionFile>();
        }

        public static string ConnectionsListFilePath
        {
            get { return connectionsListFilePath; }
            set { connectionsListFilePath = value; }
        }

        public static ConnectionsList Instance
        {
            get
            {
                if (instance == null)
                {
                    var filename = Path.IsPathRooted(connectionsListFilePath) ? connectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                        connectionsListFilePath);

                    if (File.Exists(filename))
                    {
                        using (var sr = new StreamReader(filename))
                        {
                            instance = (ConnectionsList)XmlSerializerHelper.Deserialize(sr.ReadToEnd(), typeof(ConnectionsList));
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

                        CrmConnections cc = new CrmConnections("Default");
                        cc.SerializeToFile(defaultFilePath);

                        instance = new ConnectionsList();
                        instance.Files.Add(new ConnectionFile(cc) { Path = defaultFilePath });
                        instance.Save();
                    }
                }

                return instance;
            }
        }

        public List<ConnectionFile> Files { get; set; }

        public void Save()
        {
            var filename = Path.IsPathRooted(connectionsListFilePath) ? connectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                       connectionsListFilePath);

            XmlSerializerHelper.SerializeToFile(instance, filename);
        }
    }
}