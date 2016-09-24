using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace McTools.Xrm.Connection
{
    public class ConnectionFile
    {
        public DateTime LastUsed { get; set; }

        public string Name { get; set; }

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

                            instance = (ConnectionsList)XmlSerializerHelper.Deserialize(sr.ReadToEnd(), typeof(ConnectionsList));
                    }
                    else
                    {
                        var directory = new FileInfo(filename).DirectoryName;

                        instance = new ConnectionsList();
                        instance.Files.Add(new ConnectionFile { Name = "Default", Path = Path.Combine(directory, "mscrmtools2011.config") });
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