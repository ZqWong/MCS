using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    [ProtoInclude(500, typeof(SetClientPropertyPacket))]
    [ProtoInclude(501, typeof(GetClientPropertyPacket))]
    [ProtoInclude(502, typeof(SetServerPropertyPacket))]
    [ProtoInclude(503, typeof(GetServerPropertyPacket))]
    public class BasePacket
    {
        [ProtoMember(1)]
        public virtual string senderID { get; set; }

    }
}
