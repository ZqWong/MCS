using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CommandAnimationListPacket : CommandBase
    {
        [ProtoMember(1)]
        public List<CommandAnimationPacket> CommandAnimationList { get; set; }

    }
}
