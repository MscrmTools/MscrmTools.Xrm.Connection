using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace McTools.Xrm.Connection
{
    public class ConnectionFile
    {
        public ConnectionFile()
        {
        }

        public ConnectionFile(string name)
        {
            Name = name;
        }

        public ConnectionFile(CrmConnections connections)
        {
            Name = connections.Name;
        }

        public DateTime LastUsed { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            var fileName = System.IO.Path.GetFileName(Path);
            var fileNameParts = fileName.Split('.');
            if (fileNameParts.Length > 1)
            {
                fileName = string.Join(".", fileNameParts.Take(fileNameParts.Length - 1));
            }

            return Name?.Length > 0 ? Name : fileName;
        }
    }

    public class ConnectionsList
    {
        private static string _connectionsListFilePath = "MscrmTools.ConnectionsList.xml";
        private static ConnectionsList _instance;

        private ConnectionsList()
        {
            Files = new List<ConnectionFile>();
        }

        public static string ConnectionsListFilePath
        {
            get => _connectionsListFilePath;
            set => _connectionsListFilePath = value;
        }

        public static ConnectionsList Instance
        {
            get
            {
                if (_instance == null)
                {
                    var filename = Path.IsPathRooted(_connectionsListFilePath) ? _connectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                        _connectionsListFilePath);

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

                        CrmConnections cc = new CrmConnections("Default");
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
            var filename = Path.IsPathRooted(_connectionsListFilePath) ? _connectionsListFilePath : Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                       _connectionsListFilePath);

            XmlSerializerHelper.SerializeToFile(_instance, filename);
        }
    }
}