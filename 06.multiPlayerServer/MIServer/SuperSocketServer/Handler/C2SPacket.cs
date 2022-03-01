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
    public class C2SPacket : BasePacketHandler
    {
        private object mMyLock = new Object();

        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            lock (mMyLock)
            {
                base.ExecuteCommand(session, requestInfo);

                // server.Logger.Warn(string.Format("收到数据"));

                PacketCommon.C2SPacket recvData = packetSerialiser.Deserialise<PacketCommon.C2SPacket>(requestInfo.messageBuffer);

                if (recvData.cmdDict.ContainsKey("AltEnterPacket"))
                {
                    server.Logger.Warn(string.Format("收到数据"));
                }

                PacketCommon.S2CPacket sendData = new PacketCommon.S2CPacket();

                sendData.cmdDict = new Dictionary<string, Dictionary<string, byte[]>>();

                sendData.cmdDict.Add(recvData.roleId, recvData.cmdDict);


                SendTest(sendData);
            }
        }
    }
}
