using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


public class PowerOnHelper : UdpClient
{
    public PowerOnHelper() : base() { }

    //this is needed to send broadcast packet
    public void SetClientToBrodcastMode()
    {
        if (this.Active)
            this.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
    }
}

