using Common;
using MCS_Client.SocketHandler.LogicHandlers;

namespace MCS_Client.SocketHandler
{
    public class C_HandlerCenter
    {
        C_HandlerInterface _C_ExamHandler;
        C_HandlerInterface _C_SendFileHandler;

        public C_HandlerCenter()
        {
            _C_ExamHandler = new C_ExamHandler();
            _C_SendFileHandler = new C_SendFileHandler();
        }

        /// <summary>
        /// 消息接收、分发处理
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="message"></param>
        public void MessageReceive(SocketModel message)
        {
            // 消息分发处理
            switch (message.Type)
            {
                case (byte)Protocol.Type.EXAM:

                    _C_ExamHandler.MessageReceive(message);

                    break;

                case (byte)Protocol.Type.SendFiles:

                    _C_SendFileHandler.MessageReceive(message);

                    break;
            }
        }
    }

}
