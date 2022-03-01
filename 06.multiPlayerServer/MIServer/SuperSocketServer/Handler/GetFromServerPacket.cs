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
    public class GetFromServerPacket : BasePacketHandler
    {
        private object mMyLock = new Object();
        private string sectionName = "Serial";

        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);

            lock (mMyLock)
            {
                PacketCommon.GetFromServerPacket recvData = packetSerialiser.Deserialise<PacketCommon.GetFromServerPacket>(requestInfo.messageBuffer);

                // server.Logger.Debug("收到GetFromServerPacket" + recvData.key);

                string path = AppDomain.CurrentDomain.BaseDirectory + "SerialAtServer.ini";

                INIClass iniClass = new INIClass(path);

                if (iniClass.ExistINIFile() == false)
                {
                    FileStream fs = new FileStream(path, FileMode.CreateNew);
                    fs.Close();

                    server.Logger.Error(string.Format("没有数据保存在SerialAtServer.ini"));

                    return;
                }

                PacketCommon.GetFromServerPacket sendData = new PacketCommon.GetFromServerPacket();

                try
                {
                    sendData.key = recvData.key;
                    sendData.message = iniClass.IniReadValue(sectionName, recvData.key);
                }
                catch (Exception e)
                {
                    server.Logger.Error("收到GetFromServerPacket 读取异常" + e.Message.ToString());
                }

                foreach (var iSession in server.GetAllSessions())
                {
                    SendProtobuf(sendData, iSession);
                }
            }
        }
    }
}
