using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGroup
{
    public class S_PluginEventData : EventData
    {
        public string routingKeys;
        public IDictionary<string, object> headers;

    }
}
