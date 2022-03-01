using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace MIServer
{
    public class LockStepServerSession : AppSession<LockStepServerSession, ProtobufRequestInfo>
    {
        public int RoleId { get; internal set; }
        public bool IsReady { get; internal set; }

        //todo 
        //添加session链接log
        protected override void OnSessionStarted()
        {
            //this.Send("Welcome to SuperSocket Telnet Server");

            Interlocked.Increment(ref ((LockStepServer)this.AppServer).serverSessionCount);

            if (!((LockStepServer) this.AppServer).connectedClientDict.ContainsKey(this))
            {
                ((LockStepServer)this.AppServer).connectedClientDict.TryAdd(this, this.SessionID);
            }

            //if (!((LockStepServer) this.AppServer).clientPropertyDict.ContainsKey(this.SessionID))
            //{
            //    ((LockStepServer)this.AppServer).clientPropertyDict.TryAdd(this.SessionID, new ConcurrentDictionary<string, string>());
            //}

            ((LockStepServer)this.AppServer).Logger.Info(string.Format("OnSessionStarted !, session count : {0} , serverSessionCount : {1} ip: {2}", ((LockStepServer)this.AppServer).SessionCount, ((LockStepServer)this.AppServer).serverSessionCount, this.RemoteEndPoint.Address.ToString()));


        }

        protected override void HandleUnknownRequest(ProtobufRequestInfo requestInfo)
        {
            //this.Send("Unknow request");
        }

        protected override void HandleException(Exception e)
        {
            //this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed
            //base.OnSessionClosed(reason);
            string temp;
            ((LockStepServer) this.AppServer).connectedClientDict.TryRemove(this,out temp);

            if (((LockStepServer)this.AppServer).serverSessionCount > 0)
            {

                Interlocked.Decrement(ref ((LockStepServer)this.AppServer).serverSessionCount);

                if (((LockStepServer)this.AppServer).mTimeStatistic.ContainsKey(RoleId))
                {
                    DateTime someItem;
                    ((LockStepServer) this.AppServer).mTimeStatistic.TryRemove(RoleId, out someItem);
                }

                // 判断当前如果连接到服务端的客户端为0，则服务端也重新归零，FrameCount重新计数，帧数据清空
                if (((LockStepServer) this.AppServer).serverSessionCount == 0)
                {
                    Interlocked.Exchange(ref ((LockStepServer) this.AppServer).mCurrentFrame, 0);
                    ((LockStepServer)this.AppServer).mFrameDic.Clear();

                    ((LockStepServer)this.AppServer).Logger.Info(string.Format("Make mCurrentFrame count to 0, and clear mFrameDic", ((LockStepServer)this.AppServer).SessionCount, ((LockStepServer)this.AppServer).serverSessionCount));

                    ((LockStepServer)this.AppServer).mTimeStatistic.Clear();

                    ((LockStepServer)this.AppServer).clientPropertyDict.Clear();
                }

                ((LockStepServer)this.AppServer).Logger.Info(string.Format("OnSessionClosed !, session count : {0} , serverSessionCount : {1} , ip:{2}", ((LockStepServer)this.AppServer).SessionCount, ((LockStepServer)this.AppServer).serverSessionCount, this.RemoteEndPoint.Address.ToString()));

            }
        }
    }
}
