using System;
using System.Net.Sockets;
using Networker.Common.Abstractions;

namespace Networker.Client.Abstractions
{
    public interface IClient
    {
        /// <summary>
        /// 连接成功后的回调函数
        /// </summary>
        EventHandler<Socket> Connected { get; set; }
        /// <summary>
        /// 断开连接后的回调函数
        /// </summary>
        EventHandler<Socket> Disconnected { get; set; }

        /// <summary>
        /// TCP发送数据
        /// </summary>
        /// <typeparam name="T">自定义的消息类型</typeparam>
        /// <param name="packet"></param>
        void Send<T>(T packet);
        // void Send(byte[] packet);

        /// <summary>
        /// UDP发送数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="packet"></param>
        void SendUdp<T>(T packet);
        void SendUdp(byte[] packet);

        /// <summary>
        /// 手动阻塞接收。仅在UseSync(True)的同步阻塞模式下手动调用并阻塞线程。UseSync(False)的异步模式下自动接收，不阻塞线程。
        /// </summary>
        void ReceiveSyncTcp();

        long Ping(int timeout = 10000);

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        ConnectResult Connect();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Stop();

        /// <summary>
        /// 获取序列化接口。大部分情况下不需要调用此函数，因为序列化部分已经自动执行。
        /// </summary>
        /// <returns></returns>
        IPacketSerialiser GetPacketSerialiser();
    }
}
