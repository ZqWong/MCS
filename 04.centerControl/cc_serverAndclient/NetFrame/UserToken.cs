using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Common;
using System.IO;
using ServerFrame;

namespace ServerFrame
{
    /// <summary>
    /// 客户端连接对象
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// 用户Socket
        /// </summary>
        public Socket ClientSocket { get; set; }

        /// <summary>
        /// 用户异步接受网络数据对象
        /// </summary>
        public SocketAsyncEventArgs ReceiveSAEA { get; set; }

        /// <summary>
        /// 用户异步发送网络数据对象
        /// </summary>
        public SocketAsyncEventArgs SendSAEA { get; set; }

        public AbsHandleCenter _Center;

        /// <summary>
        /// 处理的数据（消息）集合
        /// </summary>
        List<byte> _UnHandleDataList = new List<byte>();

        /// <summary>
        /// 是否正在读取
        /// </summary>
        public bool _IsReading = false;

        /// <summary>
        /// 是否正在写入
        /// </summary>
        public bool _IsWriting = false;

        /// <summary>
        /// 长度编码委托
        /// </summary>
        public LengthEncodeDelegate _LengthEncodeDelegate;

        /// <summary>
        /// 长度解码委托
        /// </summary>
        public LengthDecodeDelegate _LengthDecodeDelegate;

        /// <summary>
        /// 消息编码委托
        /// </summary>
        public MessageEncodeDelegate _MessageEncodeDelegate;

        /// <summary>
        /// 消息解码委托
        /// </summary>
        public MessageDecodeDelegate _MessageDecodeDelegate;

        /// <summary>
        /// 发送队列
        /// </summary>
        Queue<byte[]> _SendQueue = new Queue<byte[]>();

        /// <summary>
        /// 处理发送
        /// </summary>
        public ProcessSendDelegate _ProcessSendDelegate;

        ///// <summary>
        ///// 处理接收
        ///// </summary>
        //public ProcessReceiveDelegate _ProcessReceiveDelegate;

        /// <summary>
        /// 处理客户端关闭
        /// </summary>
        public ProcessClientCloseDelegate _ProcessClientCloseDelegate;

        public UserToken()
        {
            ReceiveSAEA = new SocketAsyncEventArgs();
            SendSAEA = new SocketAsyncEventArgs();

            ReceiveSAEA.UserToken = this;
            SendSAEA.UserToken = this;

            // 设置接收对象的缓冲区大小
            ReceiveSAEA.SetBuffer(new byte[1024], 0, 1024);
            //SendSAEA.SetBuffer(new byte[1024], 0, 1024);
        }

        /// <summary>
        /// 1.接收
        /// </summary>
        /// <param name="buffer"></param>
        public void Receive(Byte[] buffer)
        {
            // 将消息写入缓存

            _UnHandleDataList.AddRange(buffer);

            if (!_IsReading)
            {
                _IsReading = true;

                ProcessReceive();
            }
        }

        /// <summary>
        /// 2.处理接受
        /// </summary>
        void ProcessReceive()
        {
            // 解码消息存储对象
            byte[] buffer = null;

            // 当长度（粘包）解码器不为空的时候，进行粘包处理（不是每一个项目都需要粘包处理） 
            if (_LengthDecodeDelegate != null)
            {
                buffer = _LengthDecodeDelegate(ref _UnHandleDataList);

                // 消息没有到达完成
                if (buffer == null)
                {
                    _IsReading = false;
                    return;
                }
            }
            else
            {
                // 缓存区中没有数据，直接跳出数据处理，等待下次消息到达
                if (_UnHandleDataList.Count == 0)
                {
                    _IsReading = false;
                    return;
                }

                buffer = _UnHandleDataList.ToArray();
                _UnHandleDataList.Clear();
            }

            // 是否有消息解码器
            if (_MessageDecodeDelegate == null)
            {
                throw new Exception("消息解码器为空！");
            }

            // 消息解码
            object message = _MessageDecodeDelegate(buffer);

            // 通知应用层有消息到达
            _Center.MessageReceive(this, message);

            if (_UnHandleDataList.Count > 0)
            {
                // 防止在消息处理过程中有消息到达，而没有经过处理
                ProcessReceive();
            }
            else
            {
                _IsReading = false;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="value"></param>
        public bool Send(byte[] buffer)
        {
            if (ClientSocket == null)
            {
                // 此连接已经断开了
                _ProcessClientCloseDelegate(this, "调用已经断开的连接！");

                return false;
            }

            // 加入队列
            _SendQueue.Enqueue(buffer);

            if (!_IsWriting)
            {
                _IsWriting = true;

                ProcessSend();
            }

            return true;
        }

        ///// <summary>
        ///// 同步发送消息
        ///// </summary>
        ///// <param name="sendData"></param>
        ///// <param name="offset"></param>
        ///// <param name="Size"></param>
        ///// <returns></returns>
        //public int SendSync(byte[] sendData, int offset, int Size)
        //{
        //    int count = ClientSocket.Send(sendData, offset, Size, SocketFlags.None);

        //    return count;
        //}

        /// <summary>
        /// 处理发送
        /// </summary>
        public void ProcessSend()
        {
            // 判断发送消息队列是否有消息
            if (_SendQueue.Count == 0)
            {
                _IsWriting = false;
                return;
            }

            // 取出第一条待发消息
            byte[] buffer = _SendQueue.Dequeue();

            // 设置消息发送异步对象的发送数据缓冲区数据
            SendSAEA.SetBuffer(buffer, 0, buffer.Length);

            /*
             * 报错：现在已经正在使用此 SocketAsyncEventArgs 实例进行异步套接字操作
              这个错误是由于SAEA对象在一个时刻中只能处于StartAccept、StartReceive、StartSend状态中的一种，
              试想，当Socket服务器处于高压力情形下，一条Socket连接在很短的时间内要发送大量数据，
              当Socket处于StartSend状态下尚未触发回调函数时，又一次调用此Socket的StartSend方法，便会抛出该异常。
              这也有改进方案：记录Socket的当前状态，并存储在Socket的UserToken对象下，当要执行StartSend时，判断状态。
              不过这样效率会很慢，远远低于同步发送的效率，当高并发时，还要用大量的锁机制来维护线程的同步，得不偿失。

              SocketAsyncEventArgs如何实现双工传输？
             */

            // 开启异步发送
            bool result = ClientSocket.SendAsync(SendSAEA);

            // 是否挂起
            if (!result)
            {
                _ProcessSendDelegate(SendSAEA);
            }

            //// 开启同步发送
            //SendSync(buffer, 0, buffer.Length);

            if (_SendQueue.Count > 0)
            {
                ProcessSend();
            }
            else
            {
                _IsReading = false;
            }
        }

        /// <summary>
        /// 发送信息成功回调
        /// </summary>
        public void SendOK()
        {
            // 尾递归
            ProcessSend();
        }

        /// <summary>
        /// 关闭客户端
        /// </summary>
        public void Close()
        {
            try
            {
                _SendQueue.Clear();
                _UnHandleDataList.Clear();

                _IsReading = false;
                _IsWriting = false;

                // 进行客户端Socket的接收和发送功能
                ClientSocket.Shutdown(SocketShutdown.Both);
                // 关闭客户端Socket连接并释放所有关联的资源
                ClientSocket.Close();

                ClientSocket = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
