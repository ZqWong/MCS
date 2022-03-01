using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CommandAnimationPacket : CommandBase
    {
        [ProtoMember(1)]
        public string AnimationName { get; set; }

        [ProtoMember(2)]
        public int Layer { get; set; }

        [ProtoMember(3)]
        public List<_AnimatorParam>  ParaList{ get; set; }

        // hash of state name
        [ProtoMember(4)]
        public int State { get; set; }

        // speed of play animation
        [ProtoMember(5)]
        public float Speed { get; set; }

        // progress of play animation
        [ProtoMember(6)]
        public float Progress { get; set; }



    }
}
