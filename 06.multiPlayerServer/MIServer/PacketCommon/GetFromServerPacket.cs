using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class GetFromServerPacket
    {
        [ProtoMember(1)]
        public virtual string key { get; set; }

        [ProtoMember(2)]
        public virtual string message { get; set; }
    }
}
