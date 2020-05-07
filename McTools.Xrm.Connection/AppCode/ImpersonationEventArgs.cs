using System;

namespace McTools.Xrm.Connection.AppCode
{
    public class ImpersonationEventArgs : EventArgs
    {
        public ImpersonationEventArgs(Guid userId, string username = null)
        {
            UserId = userId;
            UserName = username;
        }

        public Guid UserId { get; }

        public string UserName { get; }
    }
}