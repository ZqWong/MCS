using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MIServer
{

    public class ProtobufReceiveFilter : IReceiveFilter<ProtobufRequestInfo>
    {
        public int LeftBufferSize { get; set; }

        public IReceiveFilter<ProtobufRequestInfo> NextReceiveFilter { get; set; }

        public FilterState State { get; set; }

        public ProtobufRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            byte[] receive = new byte[length];
            Buffer.BlockCopy(readBuffer, offset, receive, 0, length);

            int currentPosition = 0;

            var packetTypeNameLength = BitConverter.ToInt32(receive, currentPosition);
            currentPosition += 4;
            var packetSize = BitConverter.ToInt32(receive, currentPosition);
            currentPosition += 4;

            var packetTypeName = "Default";

            rest = length - currentPosition;

            if (receive.Length - currentPosition < packetTypeNameLength)
            {
                return null;
            }

            packetTypeName = Encoding.ASCII.GetString(receive, currentPosition, packetTypeNameLength);
            currentPosition += packetTypeNameLength;

            if (string.IsNullOrEmpty(packetTypeName))
            {
                return null;
            }

            rest = length - currentPosition;

            if (receive.Length - currentPosition < packetSize)
            {
                return null;
            }

            rest = length - currentPosition - packetSize;

            var packetBytes = new byte[packetSize];
            Buffer.BlockCopy(receive, currentPosition, packetBytes, 0, packetSize);

            // todo 此处可以增加对象池 来减少频繁的new
            ProtobufRequestInfo protobufRequestInfo = new ProtobufRequestInfo(packetTypeName, packetBytes);
            return protobufRequestInfo;



            //// todo
            //// rest需要处理
            //// 频繁的new 效率测试

            //byte[] MessageBufferHead = new byte[MessageBuffer.MESSAGE_HEAD_SIZE];
            //Array.Copy(readBuffer, offset, MessageBufferHead, 0, MessageBuffer.MESSAGE_HEAD_SIZE);

            //rest = length - MessageBuffer.MESSAGE_HEAD_SIZE;

            //int bodySize = 0;
            //if (MessageBuffer.Decode(MessageBufferHead, MessageBuffer.MESSAGE_BODY_SIZE_OFFSET, ref bodySize) == false)
            //{
            //    return null;
            //}

            //MessageBuffer message = new MessageBuffer(MessageBuffer.MESSAGE_HEAD_SIZE + bodySize);

            //Array.Copy(readBuffer, offset, message.buffer, 0, MessageBuffer.MESSAGE_HEAD_SIZE + bodySize);

            //rest = length - (MessageBuffer.MESSAGE_HEAD_SIZE + bodySize);

            //string keyString = Enum.GetName(typeof(MessageID), message.id());
            //ProtobufRequestInfo protobufRequestInfo = new ProtobufRequestInfo(keyString, message);
            //return protobufRequestInfo;
        }

        public void Reset()
        {
        }
    }
}
