using Common;
using MCS_Client.Common;
using MCS_Client.SocketHandler;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MCS_Client
{
    public class NetIO
    {
        private static NetIO _Instance;

        private Socket _ClientSocket;

        // 数据缓存区
        private byte[] _DataBufferCache = new byte[102400];

        /* 1KB=1024byte=1024*8bit
         * 一个字节是8个位，即8位的二进制
         * 一个英文字母要8位二进制表示，因此一个字母是一个字节
         * 一个汉字要16位二进制表示，因此一个汉字是两个字节
         * 因此1KB=1024个字母=512个汉字
         */

        /// <summary>
        /// 待处理的数据（消息）集合
        /// </summary>
        List<byte> _UnHandleDataList = new List<byte>();

        /// <summary>
        /// 是否正在读取
        /// </summary>
        private bool _IsReading = false;

        public List<SocketModel> _MessageList = new List<SocketModel>();

        /// <summary>
        /// 单例
        /// </summary>
        public static NetIO Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NetIO();
                }
                return _Instance;
            }
        }

        public void Connect2Server()
        {
            try
            {
                // 创建客户端连接对象
                _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 连接到服务器
                _ClientSocket.Connect(Const.ServerIPAddress, Convert.ToInt32(Const.ServerPort));

                //Console.WriteLine("服务器连接成功！");

                // 开启异步接收数据从连接Socket，消息到达后会直接写入【数据缓存缓冲区】
                // Socket.BeginReceive 方法 (Byte[], Int32, Int32, SocketFlags, AsyncCallback, Object)
                // 参数
                // byte[] buffer： 它是接收到的数据的存储位置。
                // int offset： buffer中从零开始的位置
                // int size： 要接收的字节数。
                // SocketFlags socketFlags：值的按位组合 
                // AsyncCallback callback：一个 AsyncCallback 委托，它引用操作完成时要调用的方法。
                // object state：用户定义的对象，其中包含有关接收操作的信息。 当操作完成时，此对象会被传递给 EndReceive 委托。
                _ClientSocket.BeginReceive(_DataBufferCache, 0, 102400, SocketFlags.None, ReceiveCallBack, null);

                ClientForm.Form.ShowMessage("服务器连接成功！");

            }
            catch (Exception e)
            {
                ClientForm.Form.ShowMessage($"【异常】服务器连接失败！位置：NetIO.Connect2Server()。{e}");
            }

        }

        /// <summary>
        /// 接收消息回调函数
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveCallBack(IAsyncResult result)
        {
            try
            {
                // 调用 EndReceive 方法以成功完成读取的操作，并返回读取的字节数。
                int length = _ClientSocket.EndReceive(result);

                byte[] unHandleDataByteArray = new byte[length];

                Buffer.BlockCopy(_DataBufferCache, 0, unHandleDataByteArray, 0, length);

                // 将数据缓存区中的数据存放到待处理的数据集合中
                _UnHandleDataList.AddRange(unHandleDataByteArray);

                if (!_IsReading)
                {
                    _IsReading = true;

                    // 数据处理
                    DataHandle();
                }

                // 尾递归 再次开启异步消息接收
                _ClientSocket.BeginReceive(_DataBufferCache, 0, 102400, SocketFlags.None, ReceiveCallBack, null);
            }
            catch (Exception e)
            {
                ClientForm.Form.ShowMessage("【异常】消息接收回调出现异常！位置：NetIO.ReceiveCallBack()。");

                _ClientSocket.Close();
            }

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="area"></param>
        /// <param name="command"></param>
        /// <param name="message"></param>
        public bool SendMessage2Server(byte type, int area, int command, object message)
        {
            bool result = false;

            ByteArray ba = new ByteArray();

            ba.write(type);
            ba.write(area);
            ba.write(command);

            // 判断消息体是否为空  不为空则序列化后写入
            if (message != null)
            {
                ba.write(SerializeAndDeserializeTool.Serialize(message));
            }

            // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
            ByteArray resultByteArray = new ByteArray();
            resultByteArray.write(ba.Length);
            resultByteArray.write(ba.GetBuffer());

            try
            {
                _ClientSocket.Send(resultByteArray.GetBuffer());

                result = true;
            }
            catch (Exception e)
            {
                ClientForm.Form.ShowMessage("【异常】向服务器发送消息出现异常！位置：NetIO.SendMessage2Server()。");

                result = false;
            }

            return result;
        }

        /// <summary>
        /// 处理缓存中的数据
        /// </summary>
        void DataHandle()
        {
            // 长度解码
            byte[] data = LengthEncodeAndDecodeTool.LengthDecode(ref _UnHandleDataList);

            // 长度解码返回空，说明消息不全，等待下条消息过来补全
            if (data == null)
            {
                _IsReading = false;
                return;
            }

            // 消息解码
            SocketModel message = MessageEncodeAndDecodeTool.MessageDecode(data);

            if (message == null)
            {
                _IsReading = false;
                return;
            }

            //进行消息的处理
            //_MessageList.Add(message);

            // 按业务逻辑分发处理
            C_HandlerCenter handlerCenter = new C_HandlerCenter();

            handlerCenter.MessageReceive(message);

            //handlerCenter
            //Console.WriteLine(message.Type);
            //Console.WriteLine(message.Area);
            //Console.WriteLine(message.Command);
            //Console.WriteLine(message.Message);

            // 当前消息处理完需要不需要将_IsReading设置为false？

            // 尾递归 防止在消息处理过程中 有其他消息到达而没有经过处理 - 应该就是循环处理【待处理的数据（消息）集合】中的数据（消息）
            DataHandle();
        }
    }
}
