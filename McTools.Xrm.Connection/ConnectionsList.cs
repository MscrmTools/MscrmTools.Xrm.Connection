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

        private ConnectionsList()
        {
            Files = new List<ConnectionFile>();
        }

        public static ConnectionsList Instance
        {
            get
            {
                if (instance == null)
                {
                    var filename = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                        "MscrmTools.ConnectionsList.xml");

                    if (File.Exists(filename))
                    {
                        using (var sr = new StreamReader(filename))

                            instance = (ConnectionsList)XmlSerializerHelper.Deserialize(sr.ReadToEnd(), typeof(ConnectionsList));
                    }
                    else
                    {
                        instance = new ConnectionsList();
                        instance.Files.Add(new ConnectionFile { Name = "Default", Path = "mscrmtools2011.config" });
                        instance.Save();
                    }
                }

                return instance;
            }
        }

        public List<ConnectionFile> Files { get; set; }

        public void Save()
        {
            XmlSerializerHelper.SerializeToFile(instance, Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "MscrmTools.ConnectionsList.xml"));
        }
    }
}