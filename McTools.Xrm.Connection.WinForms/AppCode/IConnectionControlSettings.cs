namespace McTools.Xrm.Connection.WinForms.AppCode
{
    public interface IConnectionControlSettings
    {
        int DisplaySizeFactor { get; set; }
        int NumberOfRecentConnectionsToDisplay { get; set; }

        bool ShowMostRecentConnections { get; set; }
        bool ShowSearchBarInCompactSelector { get; set; }
        bool UseDetailsViewForConnectionManager { get; set; }
        bool UseDetailsViewForConnectionSelector { get; set; }
    }

    public interface IConnectionControlSettings2 : IConnectionControlSettings
    {
        bool UseFilterForAdditionalConnection { get; set; }
    }
}