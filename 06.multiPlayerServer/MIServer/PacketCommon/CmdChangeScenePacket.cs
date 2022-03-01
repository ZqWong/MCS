using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CmdChangeScenePacket : CommandBase
    {
        [ProtoMember(1)]
        public string SceneName { get; set; }

        [ProtoMember(2)]
        public _Vector3 PlayerPosition { get; set; }

        [ProtoMember(3)]
        public _Vector3 PlayerDirection { get; set; }


    }
}
