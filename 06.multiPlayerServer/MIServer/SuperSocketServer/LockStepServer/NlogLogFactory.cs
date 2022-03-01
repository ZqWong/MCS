using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.SocketBase.Logging
{
    /// <summary>
    /// LogFactory Interface
    /// </summary>

    public class NlogLogFactory : ILogFactory
    {

        /// <summary>
        /// Gets the log by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ILog GetLog(string name)
        {
            return new Nloglog(name);
        }
    }
}
