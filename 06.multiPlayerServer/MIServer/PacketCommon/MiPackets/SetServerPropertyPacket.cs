using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class SetServerPropertyPacket : BasePacket
    {
        [ProtoMember(1)]
        public virtual string key { get; set; }

        [ProtoMember(2)]
        public virtual string value { get; set; }

    }
}
