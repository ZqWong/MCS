using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace PacketCommon
{
    enum protocols
    {
        BROADCASTING_ALL,                   // 广播
        BROADCASTING_EXCEPT_SELF,           // 广播除了自己
        SPECIFIED_ID,                       // 指定发送到某个ID
        MULTIPLE_ID,                        // 指定发送到ID 列表
        SELF,                               // 自己接收
    }

    [ProtoContract]
    public class C2SPacket
    {
        [ProtoMember(1)]
        public virtual string roleId { get; set; }

        [ProtoMember(2)]
        public virtual int protocol { get; set; }    

        [ProtoMember(3)]
        public Dictionary<string, byte[]> cmdDict { get; set; }

        // 仅当protocol = MULTIPLE_ID时，该变量才有用。表示要发送到的目标ID
        [ProtoMember(4)]
        public List<int> multipleIdList { get; set; }
    }
}
