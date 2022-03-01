using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class _AnimatorParam
    {

        [ProtoMember(1)]
        public string ParaType;

        [ProtoMember(2)]
        public string Name;

        [ProtoMember(3)]
        public bool ParaBool;

        [ProtoMember(4)]
        public int ParaInt;

        [ProtoMember(5)]
        public float ParaFloat;

    }
}
