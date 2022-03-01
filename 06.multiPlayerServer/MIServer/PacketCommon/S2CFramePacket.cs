using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class S2CFramePacket
    {
        [ProtoMember(1)]
        public virtual long frameCount { get; set; }

        [ProtoMember(2)]
        public Dictionary<int, Dictionary<string, byte[]>>  cmdDict { get; set; }

    }
}
