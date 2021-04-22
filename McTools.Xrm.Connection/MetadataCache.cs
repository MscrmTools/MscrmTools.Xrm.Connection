using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Metadata;

namespace McTools.Xrm.Connection
{
    [DataContract(Name = "MetadataCache", Namespace = "https://www.xrmtoolbox.com")]
    public class MetadataCache
    {
        [DataMember]
        public int MetadataQueryVersion { get; set; }

        [DataMember]
        public string ClientVersionStamp { get; set; }

        [DataMember]
        public EntityMetadata[] EntityMetadata { get; set; } 
    }
}
