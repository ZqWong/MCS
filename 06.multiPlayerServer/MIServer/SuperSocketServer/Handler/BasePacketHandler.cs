using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Networker.Extensions.ProtobufNet;
using SuperSocket.SocketBase.Command;

namespace MIServer.Handler
{
    public class BasePacketHandler : CommandBase<LockStepServerSession, ProtobufRequestInfo>
    {
        protected static LockStepServer server = null;

        protected readonly ProtoBufNetSerialiser packetSerialiser = new ProtoBufNetSerialiser();
        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            if (server == null)
                server = (LockStepServer)session.AppServer;

            //todo 用log库的异步方式输出的控制台
            //Console.WriteLine(string.Format("receive : {0}", requestInfo.messageBuffer.id().ToString()));

            //session.Logger.Debug(string.Format(" receive id:{0} ,session id:{1}", requestInfo.messageBuffer.id().ToString(),session.RoleId));
        }

        public void SendProtobuf<T>(T t, LockStepServerSession session) where T : class
        {
            var packet = packetSerialiser.Serialise(t);
            session.Send(packet,0,packet.Length);

            //byte[] data = ProtoTransfer.SerializeProtoBuf<T>(t);
            //MessageBuffer message = new MessageBuffer((int)messageId, data, session.RoleId);
            //session.Send(message.buffer, 0, message.buffer.Length);
        }

        public void BroadCastProtobuf<T>(T t, ConcurrentBag<LockStepServerSession> sessionBag) where T : class
        {
            if (server == null)
                return;

            ConcurrentBag<LockStepServerSession> tempSessionBag = new ConcurrentBag<LockStepServerSession>(sessionBag);

            LockStepServerSession someItem;
            while (!sessionBag.IsEmpty)
            {
                sessionBag.TryTake(out someItem);
            }

            foreach (LockStepServerSession session in tempSessionBag)
            {
                SendProtobuf(t, session);
            }

        }

        /// <summary>
        /// 广播
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sessionConDict"></param>
        /// <param name="sender"></param>
        public void BroadCastProtobuf<T>(T t, ConcurrentDictionary<LockStepServerSession, string> sessionConDict, LockStepServerSession sender=null) where T : class
        {
            if (server == null)
                return;

            foreach (LockStepServerSession session in sessionConDict.Keys)
            {
                if (session == sender)
                    continue;

                SendProtobuf(t, session);
            }
        }

        public void BroadCastProtobuf<T>(T t, List<LockStepServerSession> sessionConnectList, LockStepServerSession sender = null) where T : class
        {
            if (server == null)
                return;

            foreach (LockStepServerSession session in sessionConnectList)
            {
                if (session == sender)
                    continue;

                SendProtobuf(t, session);
            }
        }


        public void SendTest<T>(T t) where T : class
        {
            foreach (var iSession in server.GetAllSessions())
            {
                SendProtobuf(t, iSession);
            }
        }
    }
}
