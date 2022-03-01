using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MIServer
{
    public class ProtobufReceiveFilterFactory : IReceiveFilterFactory<ProtobufRequestInfo>
    {
        public IReceiveFilter<ProtobufRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            ProtobufReceiveFilter protobufReceiveFilter = new ProtobufReceiveFilter();
            return protobufReceiveFilter;
        }
    }
}
