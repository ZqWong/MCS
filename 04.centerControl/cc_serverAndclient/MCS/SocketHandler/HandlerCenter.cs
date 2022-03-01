using ServerFrame;
using Common;
using MCS.Common;
using MCS.SocketHandler.LogicHandlers;

namespace MCS.SocketHandler
{
    public class HandlerCenter : AbsHandleCenter
    {
        HandlerInterface _SystemHandler;
        HandlerInterface _ExamHandler;
        public HandlerCenter()
        {
            _SystemHandler = new SystemHandler();
            _ExamHandler = new ExamHandler();
        }

        public override void ClientConnect(UserToken userToken)
        {
            string clientKey = userToken.ClientSocket.RemoteEndPoint.ToString();

            LogHelper.WriteLog("客户端连接成功！" + clientKey);

            bool result = GlobalClass.Instance.AddClientToClientDic(clientKey, userToken);

            if (result)
            {
                LogHelper.WriteLog("客户端数：" + GlobalClass.Instance.ShowClientCount());
            }
            else
            {
                LogHelper.WriteErrorLog("添加失败！原因：要添加的客户端(" + clientKey + ")已存在！");
            }

        }

        /// <summary>
        /// 消息接收、分发处理
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="message"></param>
        public override void MessageReceive(UserToken userToken, object message)
        {
            SocketModel model = message as SocketModel;

            //LogHelper.WriteLog("收到客户端(" + clientKey + ")发来的消息。消息内容：" + "Type:" + model.Type + "，" + "Area:" + model.Area + "，" + "Command:" + model.Command + "，" + "Message:" + model.Message + "。");

            // 消息分发处理
            switch (model.Type)
            {
                case (byte)Protocol.Type.SYSTEM:

                    _SystemHandler.MessageReceive(userToken, model);

                    break;

                case (byte)Protocol.Type.EXAM:

                    _ExamHandler.MessageReceive(userToken, model);

                    break;

                case (byte)Protocol.Type.HEART_CHECK:

                    //_ExamHandler.MessageReceive(userToken, model);

                    //主界面._MainForm.ShowMessage();

                    break;


            }
        }

        /// <summary>
        /// 客户端关闭
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="error"></param>
        public override void ClientClose(UserToken userToken, string error)
        {
            string clientKey = userToken.ClientSocket.RemoteEndPoint.ToString();

            LogHelper.WriteLog("客户端关闭！" + error);

            bool result = GlobalClass.Instance.RemoveClientFromClientDic(clientKey);

            if (result)
            {
                LogHelper.WriteLog("客户端数：" + GlobalClass.Instance.ShowClientCount());
            }
            else
            {
                LogHelper.WriteErrorLog("移除失败！原因：要移除的客户端(" + clientKey + ")不存在！");
            }
        }
    }
}
