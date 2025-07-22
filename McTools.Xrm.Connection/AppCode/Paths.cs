using System.IO;
using System.Reflection;

namespace McTools.Xrm.Connection.AppCode
{
    public static class Paths
    {
        public static string LogsPath { get; set; } = Path.Combine(Assembly.GetExecutingAssembly().Location, "Logs");
    }
}