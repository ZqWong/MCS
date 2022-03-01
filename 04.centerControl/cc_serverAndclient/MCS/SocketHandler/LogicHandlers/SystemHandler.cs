using System;
using ServerFrame;
using Common;
using MCS.Common;

namespace MCS.SocketHandler.LogicHandlers
{
    class SystemHandler : HandlerInterface
    {

        public void ClientClose(UserToken token, string error)
        {
            //throw new NotImplementedException();
        }

        public void ClientConnect(UserToken token)
        {
            //throw new NotImplementedException();
        }


        public void MessageReceive(UserToken userToken, SocketModel message)
        {
            //LogHelper.WriteLog("aaa");

            string clientKey = userToken.ClientSocket.RemoteEndPoint.ToString();

            string ip = clientKey.Substring(0, clientKey.IndexOf(':'));

            SocketModel model = message as SocketModel;

            // 根据Command分别进行处理
            switch (model.Command)
            {
                case (byte)Protocol.Command.ApplicationOpenState:

                    ExcuteApplicationOpenStateCommand(ip, (bool)model.Message);

                    break;
            }


            // 发送信息
            //// ------------------------------------------------------------
            //ByteArray ba = new ByteArray();

            //ba.write((byte)1); // 必须进行转化否则出错，正常是不应该的
            //ba.write((int)2);
            //ba.write((int)3);

            //// 判断消息体是否为空  不为空则序列化后写入
            //if (message != null)
            //{
            //    ba.write(SerializeAndDeserializeTool.Serialize((object)"收到服务器回复！"));
            //}

            //// 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
            //ByteArray resultByteArray = new ByteArray();
            //resultByteArray.write(ba.Length);
            //resultByteArray.write(ba.GetBuffer());

            //// ------------------------------------------------------------

            //token.Send(resultByteArray.GetBuffer());

        }

        #region 消息分发执行
        /// <summary>
        /// 
        /// </summary>
        private void ExcuteApplicationOpenStateCommand(string ip, bool isOpen)
        {
            GlobalClass.Instance.AddApplicationOpenStateDic(ip, isOpen);
        }
        #endregion
    }
}
