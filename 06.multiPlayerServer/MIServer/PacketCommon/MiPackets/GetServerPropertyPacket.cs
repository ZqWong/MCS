using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class GetServerPropertyPacket : BasePacket
    {
        [ProtoMember(1)]
        public virtual ConcurrentDictionary<string, ConcurrentDictionary<string, string>> serverPropertyDict { get; set; }

    }
}
