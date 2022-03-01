using ServerFrame;
using Common;

namespace MCS.SocketHandler
{
    public interface HandlerInterface
    {
        void ClientConnect(UserToken token);

        void MessageReceive(UserToken token, SocketModel message);

        void ClientClose(UserToken token, string error);
    }
}
