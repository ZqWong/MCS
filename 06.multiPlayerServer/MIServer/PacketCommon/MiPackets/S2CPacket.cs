using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class S2CPacket
    {
        [ProtoMember(1)] public virtual string senderID { get; set; }

        [ProtoMember(2)] public Dictionary<string, Dictionary<string, byte[]>> cmdDict { get; set; }

    }
}
