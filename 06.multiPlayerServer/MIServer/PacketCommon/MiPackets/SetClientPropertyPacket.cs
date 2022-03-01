using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class SetClientPropertyPacket : BasePacket
    {
        [ProtoMember(1)]
        public virtual string key { get; set; }

        [ProtoMember(2)]
        public virtual string value { get; set; }

        [ProtoMember(3)]
        public virtual List<string> receiveIDList { get; set; }
    }
}
