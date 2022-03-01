using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CmdPlayParticleSystemPacket : CommandBase
    {
        [ProtoMember(1)]
        public bool isPlay { get; set; }

        [ProtoMember(2)]
        public float simulateTime { get; set; }

    }
}
