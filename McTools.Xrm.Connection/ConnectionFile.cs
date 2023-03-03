using System;
using System.Linq;

namespace McTools.Xrm.Connection
{
    /// <summary>
    /// Class that references a file that contains connections to Dataverse environments
    /// </summary>
    public class ConnectionFile
    {
        private CrmConnections _connections;

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

        public string Base64Image => Connections.Base64Image;

        public CrmConnections Connections
        {
            get
            {
                if (_connections == null)
                {
                    Reload();
                }

                return _connections;
            }
            set
            {
                _connections = value;
            }
        }

        public DateTime LastUsed { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public void ApplyLinkWithConnectionDetails()
        {
            if (_connections == null) return;
            foreach (var c in _connections.Connections)
            {
                c.ParentConnectionFile = this;
            }
        }

        public void Reload()
        {
            _connections = CrmConnections.LoadFromFile(Path);

            ApplyLinkWithConnectionDetails();
        }

        public void Save()
        {
            Connections.SerializeToFile(Path);
        }

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
}