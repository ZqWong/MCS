using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PacketCommon;

namespace MIServer.Handler
{
    public class ClientConfigPacket : BasePacketHandler
    {
        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);

            server.Logger.Debug("收到clientcoinfigPacket");

            string _ip = session.RemoteEndPoint.Address.ToString();

            // todo 需测试同一个client两个进程访问是否会有default
            int singleClientConnectCounts = 0;

            foreach (var iSession in server.GetAllSessions())
            {
                if (iSession.RemoteEndPoint.Address.ToString() == session.RemoteEndPoint.Address.ToString())
                {
                    
                    singleClientConnectCounts += 1;
                }
            }

            if (singleClientConnectCounts > 1)
            {
                _ip = "default";
            }

            ClientInfo _clientInfo = new ClientInfo();
            if (server.mClientDict.TryGetValue(_ip, out _clientInfo))
            {

            }
            else
            {
                server.mClientDict.TryGetValue("default", out _clientInfo);
            }

            PacketCommon.ClientConfigPacket sendData = new PacketCommon.ClientConfigPacket();
            sendData.roleId = _clientInfo.mId;
            sendData.pitch = _clientInfo.mPitch;
            sendData.roll = _clientInfo.mRoll;
            sendData.rotate = _clientInfo.mRotate;
            sendData.limitGpuUsage = server.limitGpuUsage;
            sendData.limitGpuSleepTime = server.limitGpuSleepTime;

            SendProtobuf(sendData, session);

            session.RoleId = _clientInfo.mId;

            // 服务端添加连接同步命令，用来确保新连接的客户端可以和其他客户端同步
            if (server.mCurrentFrame > 0)
            {
                //添加同步command
                CmdConnectSyncRequestPacket cmd = new CmdConnectSyncRequestPacket();

                if (sendData.roleId == 0)
                {
                    foreach (var _session in server.GetAllSessions())
                    {
                        string session_ip = _session.RemoteEndPoint.Address.ToString();

                        if (server.mClientDict.TryGetValue(session_ip, out _clientInfo))
                        {
                            cmd.receive_roleId = _clientInfo.mId;
                            break;
                        }
                    }
                }
                else
                {
                    cmd.receive_roleId = 0;
                }

                server.serverCommandDict.Add("CmdConnectSyncRequestPacket", packetSerialiser.SerialisePure(cmd));
                 
                //if (server.controlCmd != null)
                //{
                //    //如果服务器帧数不是0，则将现有服务端的控制位置信息发送的客户端
                //    GMCommand gmcmd = ProtoTransfer.Get(server.controlCmd);
                //    sendData.command.Clear();
                //    sendData.command.Add(gmcmd);
                //}
            }

            //Interlocked.Increment(ref server.serverSessionCount);

        }
    }
}
