﻿using System;

namespace McTools.Xrm.Connection.WinForms
{
    public class BrowserProfile
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}