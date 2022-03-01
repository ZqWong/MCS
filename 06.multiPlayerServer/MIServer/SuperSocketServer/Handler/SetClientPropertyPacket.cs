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
    public class SetClientPropertyPacket : BasePacketHandler
    {
        
        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            try
            {
                base.ExecuteCommand(session, requestInfo);

                PacketCommon.SetClientPropertyPacket recvData = packetSerialiser.Deserialise<PacketCommon.SetClientPropertyPacket>(requestInfo.messageBuffer);

                if (recvData.senderID == "")
                {
                    return; 
                }

                if (!server.clientPropertyDict.ContainsKey(recvData.senderID))
                {
                    var temp = new ConcurrentDictionary<string, string>();
                    temp.TryAdd(recvData.key, recvData.value);
                    server.clientPropertyDict.TryAdd(recvData.senderID, temp);

                    server.connectedClientDict[session] = recvData.senderID;
                }
                else
                {
                    server.clientPropertyDict[recvData.senderID]
                        .AddOrUpdate(recvData.key, recvData.value, (key, oldValue) => recvData.value);
                }

                server.Logger.Warn(string.Format("更新数据+++"));

                PacketCommon.SetClientPropertyPacket sendData = new PacketCommon.SetClientPropertyPacket();
                sendData.senderID = recvData.senderID;
                sendData.key = recvData.key;
                sendData.value = recvData.value;

                if (recvData.receiveIDList == null || recvData.receiveIDList.Count == 0)
                {
                    BroadCastProtobuf(sendData, server.connectedClientDict);
                }
                else
                {
                    BroadCastProtobuf(sendData,
                        server.connectedClientDict.Where(it => recvData.receiveIDList.Contains(it.Value)).Select(it => it.Key).ToList());
                }
            }
            catch (Exception e)
            {
                server.Logger.Error(e.Message);
            }

        }
    }
}
