using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{

    [ProtoContract]
    public class ClientConfigPacket
    {
        [ProtoMember(1)]
        public virtual string ip { get; set; }

        [ProtoMember(2)]
        public virtual int roleId { get; set; }

        [ProtoMember(3)]
        public virtual int pitch { get; set; }

        [ProtoMember(4)]
        public virtual int rotate { get; set; }

        [ProtoMember(5)]
        public virtual int roll { get; set; }

        [ProtoMember(6)]
        public virtual int limitGpuUsage { get; set; }

        [ProtoMember(7)]
        public virtual int limitGpuSleepTime { get; set; }
    }
}
