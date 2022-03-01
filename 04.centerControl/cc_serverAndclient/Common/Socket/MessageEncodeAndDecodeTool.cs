using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Common
{
    /// <summary>
    /// 消息编码解码工具
    /// </summary>
    public class MessageEncodeAndDecodeTool
    {
        /// <summary>
        /// 消息编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] MessageEncode(object obj)
        {
            SocketModel model = obj as SocketModel;

            ByteArray ba = new ByteArray();

            ba.write(model.Type);
            ba.write(model.Area);
            ba.write(model.Command);
            //ba.write(model.Message);

            // 当消息体不为空的时候
            if (model.Message != null)
            {
                ba.write(SerializeAndDeserializeTool.Serialize(model.Message));
            }

            byte[] result = ba.GetBuffer();

            ba.Close();

            return result;
        }

        /// <summary>
        /// 消息解码
        /// </summary>
        /// <param name="data"></param>
        /// <returns>消息SocketModel对象</returns>
        public static SocketModel MessageDecode(byte[] buffer)
        {
            ByteArray ba = new ByteArray(buffer);

            SocketModel model = new SocketModel();

            byte type;
            int area;
            int command;

            // 从数据中读取 三层协议  读取数据顺序必须和写入顺序保持一致
            ba.read(out type);
            ba.read(out area);
            ba.read(out command);

            model.Type = type;
            model.Area = area;
            model.Command = command;

            // 判断读取完协议后 是否还有数据需要读取 是则说明有消息体 进行消息体读取
            if (ba.IsHasBufferCanRead)
            {
                byte[] message;

                // 将剩余数据全部读取出来
                ba.read(out message, ba.Length - ba.Position);

                // 反序列化剩余数据为消息体
                model.Message = SerializeAndDeserializeTool.Deserialize(message);
            }

            ba.Close();

            return model;
        }


    }
}
