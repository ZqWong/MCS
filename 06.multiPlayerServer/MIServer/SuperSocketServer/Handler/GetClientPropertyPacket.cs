using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PacketCommon;

namespace MIServer.Handler
{
    public class GetClientPropertyPacket : BasePacketHandler
    {
        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);

            PacketCommon.GetClientPropertyPacket recvData = packetSerialiser.Deserialise<PacketCommon.GetClientPropertyPacket>(requestInfo.messageBuffer);

            if (recvData.senderID == "")
            {
                return;
            }

            if (!server.clientPropertyDict.ContainsKey(recvData.senderID))
            {
                server.clientPropertyDict.TryAdd(recvData.senderID, new ConcurrentDictionary<string, string>());

                server.connectedClientDict[session] = recvData.senderID;
            }

            PacketCommon.GetClientPropertyPacket sendData = new PacketCommon.GetClientPropertyPacket();
            sendData.senderID = recvData.senderID;
            sendData.clientPropertyDict = server.clientPropertyDict;

            SendProtobuf(sendData, session);
        }
    }
}
