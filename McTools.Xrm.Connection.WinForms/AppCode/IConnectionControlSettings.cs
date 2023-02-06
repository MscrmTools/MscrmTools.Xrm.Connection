﻿using System;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    public interface IConnectionControlSettings
    {
        int NumberOfRecentConnectionsToDisplay { get; set; }
        bool UseDetailsViewForConnectionManager { get; set; }
        bool UseDetailsViewForConnectionSelector { get; set; }
    }
}