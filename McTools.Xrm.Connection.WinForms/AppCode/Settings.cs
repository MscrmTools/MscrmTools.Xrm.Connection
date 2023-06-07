using System;
using System.IO;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    public class Settings : IConnectionControlSettings
    {
        private const string settingsFilePath = "McTools.Xrm.Connection.Settings.xml";

        private int displaySizeFactor = 4;
        private int numberOfRecentConnectionsToDisplay = 10;
        private bool showMostRecentConnections;
        private bool showSearchBarInCompactSelector;
        private bool useDetailsViewForConnectionManager;
        private bool useDetailsViewForConnectionSelector;

        public int DisplaySizeFactor
        {
            get
            {
                return displaySizeFactor;
            }
            set
            {
                displaySizeFactor = value;
                Save();
            }
        }

        public int NumberOfRecentConnectionsToDisplay
        {
            get
            {
                return numberOfRecentConnectionsToDisplay;
            }
            set
            {
                numberOfRecentConnectionsToDisplay = value;
                Save();
            }
        }

        public bool ShowMostRecentConnections
        {
            get
            {
                return showMostRecentConnections;
            }
            set
            {
                showMostRecentConnections = value;
                Save();
            }
        }

        public bool ShowSearchBarInCompactSelector
        {
            get
            {
                return showSearchBarInCompactSelector;
            }
            set
            {
                showSearchBarInCompactSelector = value;
                Save();
            }
        }

        public bool UseDetailsViewForConnectionManager
        {
            get
            {
                return useDetailsViewForConnectionManager;
            }
            set
            {
                useDetailsViewForConnectionManager = value;
                Save();
            }
        }

        public bool UseDetailsViewForConnectionSelector
        {
            get
            {
                return useDetailsViewForConnectionSelector;
            }
            set
            {
                useDetailsViewForConnectionSelector = value;
                Save();
            }
        }

        public static Settings Load()
        {
            if (!File.Exists(settingsFilePath))
            {
                return new Settings();
            }

            var bytes = File.ReadAllBytes(settingsFilePath);

            using (var reader = new MemoryStream(bytes))
            {
                return (Settings)XmlSerializerHelper.Deserialize(reader, typeof(Settings));
            }
        }

        public void Save()
        {
            XmlSerializerHelper.SerializeToFile(this, settingsFilePath);
        }
    }
}