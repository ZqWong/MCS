using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ServerFrame
{
    public delegate byte[] LengthEncodeDelegate(byte[] value);

    public delegate byte[] LengthDecodeDelegate(ref List<byte> value);

    public delegate byte[] MessageEncodeDelegate(object value);

    public delegate object MessageDecodeDelegate(byte[] value);

    public delegate void ProcessSendDelegate(SocketAsyncEventArgs e);

    public delegate void ProcessReceiveDelegate(SocketAsyncEventArgs e);

    public delegate void ProcessClientCloseDelegate(UserToken token, string message);
}
