using System.Net.Sockets;

//we derive our class from a standart one
public class WOLClass : UdpClient
{
    public WOLClass() : base()
    {

    }

    //this is needed to send broadcast packet

    public void SetClientToBrodcastMode()
    {
        if (this.Active)
            this.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
    }
}
