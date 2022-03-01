using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PacketCommon;
using MIServer.Tools;

namespace MIServer.Handler
{
    public class SaveToServerPacket : BasePacketHandler
    {
        private object mMyLock = new Object();
        private string sectionName = "Serial";

        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);

            lock (mMyLock)
            {
                PacketCommon.SaveToServerPacket recvData = packetSerialiser.Deserialise<PacketCommon.SaveToServerPacket>(requestInfo.messageBuffer);

                // server.Logger.Debug("收到SaveToServerPacket" + recvData.message);

                string path = AppDomain.CurrentDomain.BaseDirectory + "SerialAtServer.ini";

                INIClass iniClass = new INIClass(path);

                if (iniClass.ExistINIFile() == false)
                {
                    FileStream fs = new FileStream(path, FileMode.CreateNew);
                    fs.Close();
                }

                PacketCommon.GetFromServerPacket sendData = new PacketCommon.GetFromServerPacket();

                try
                {
                    iniClass.IniWriteValue(sectionName, recvData.key, recvData.message);

                    // 设置之后立刻返回,并且群发
                    sendData.key = recvData.key;
                    sendData.message = recvData.message;

                    foreach (var iSession in server.GetAllSessions())
                    {
                        SendProtobuf(sendData, iSession);
                    }
                }
                catch (Exception e)
                {
                    server.Logger.Error("收到SaveToServerPacket 记录异常" + e.Message.ToString());
                }
                
            }
        }
    }
}
