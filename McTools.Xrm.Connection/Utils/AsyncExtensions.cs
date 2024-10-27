using System.Threading.Tasks;

namespace McTools.Xrm.Connection.Utils
{
    static class AsyncExtensions
    {
        public static T ExecuteSync<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}