using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class C2SFramePacket
    {
        [ProtoMember(1)]
        public virtual int roleId { get; set; }

        [ProtoMember(2)]
        public virtual long frameCount { get; set; }    

        [ProtoMember(3)]
        public Dictionary<string, byte[]> cmdDict { get; set; }
    }
}
