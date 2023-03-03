using System;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    public class Settings : IConnectionControlSettings
    {
        public int NumberOfRecentConnectionsToDisplay { get; set; } = 10;
        public bool ShowMostRecentConnections { get; set; }
        public bool ShowSearchBarInCompactSelector { get; set; }
        public bool UseDetailsViewForConnectionManager { get; set; }
        public bool UseDetailsViewForConnectionSelector { get; set; }
    }
}