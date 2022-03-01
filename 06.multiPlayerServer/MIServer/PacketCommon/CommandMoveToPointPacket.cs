using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CommandMoveToPointPacket : CommandBase
    {
        [ProtoMember(1)]
        public _Vector3 position { get; set; }

        [ProtoMember(2)]
        public _Vector3 direction { get; set; }

        [ProtoMember(3)]
        public Dictionary<string, int> testDict { get; set; }

    }
}
