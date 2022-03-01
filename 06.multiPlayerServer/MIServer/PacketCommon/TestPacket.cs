using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class TestPacket
    {
        [ProtoMember(1)]
        public virtual string name { get; set; }

        [ProtoMember(2)]
        public virtual string message { get; set; }
    }
}
