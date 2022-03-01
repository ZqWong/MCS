using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    [ProtoContract]
    public class CmdConnectSyncRequestPacket : CommandBase
    {
        // receive_roleId是接收处理请求的roleid
        [ProtoMember(1)]
        public int receive_roleId { get; set; }


        //[ProtoMember(1)]
        //public _Vector3 position { get; set; }

        //[ProtoMember(2)]
        //public _Vector3 direction { get; set; }

        // 还要包括当前场景和动画

    }
}
