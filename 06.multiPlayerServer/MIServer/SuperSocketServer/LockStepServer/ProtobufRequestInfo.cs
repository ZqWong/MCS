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
    public class ProtobufRequestInfo : IRequestInfo
    {
        public string Key { get; set; }

        public byte[] messageBuffer { get; set; }

        public ProtobufRequestInfo(string key, byte[] message)
        {
            Key = key;
            messageBuffer = message;
        }

        /*
        // Other properties
        */
    }
}
