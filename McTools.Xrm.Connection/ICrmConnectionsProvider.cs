using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTools.Xrm.Connection
{
    public interface ICrmConnectionsProvider
    {
        CrmConnections LoadCrmConnections();
    }
}
