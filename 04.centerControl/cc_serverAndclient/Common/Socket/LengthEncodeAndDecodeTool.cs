using System;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    /// <summary>
    /// 长度编码解码工具
    /// </summary>
    public class LengthEncodeAndDecodeTool
    {
        /// <summary>
        /// 粘包长度编码
        /// </summary>
        /// <param name="data">粘包长度编码前的数据</param>
        /// <returns>粘包长度编码后的数据</returns>
        public static byte[] LengthEncode(byte[] buffer)
        {
            // 创建内存流对象（创建存储区为内存的流）
            MemoryStream ms = new MemoryStream();
            // 写入二进制对象流
            BinaryWriter bw = new BinaryWriter(ms);

            // 写入消息长度
            bw.Write(buffer.Length);
            // 写入消息体
            bw.Write(buffer);

            byte[] result = new byte[ms.Length];

            Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);

            bw.Close();
            ms.Close();

            return result;
        }


        /// <summary>
        /// 粘包长度解码
        /// </summary>
        /// <param name="unHandleDataList">待处理的数据（消息）集合</param>
        /// <returns>粘包长度解码后的数据</returns>
        public static byte[] LengthDecode(ref List<byte> unHandleDataList)
        {
            // 连消息体长度识别数据都不够，说明肯定没有数据
            if (unHandleDataList.Count < 4) return null;

            // 创建内存流对象，并将缓存数据写入进去
            MemoryStream ms = new MemoryStream(unHandleDataList.ToArray());

            // 二进制读取流
            BinaryReader br = new BinaryReader(ms);

            //// 测试用
            //Console.WriteLine(ms.Position); // 0

            // 从缓存中读取int型消息体长度
            int length = br.ReadInt32();

            //// 测试用
            //Console.WriteLine(ms.Position); // 4， Position 0 1 2 3 4 ，首先读取出一个Int32类型的数字，一个Int32类型的数字占4个Byte，之后的位置就应该是ms.Position = 4了

            // 如果消息体长度 大于缓存中数据长度 说明消息没有读取完 等待下次消息到达后再次处理
            if (length > ms.Length - ms.Position)
            {
                br.Close();
                ms.Close();

                return null;
            }

            // 读取正确长度的数据（粘包长度解码后的数据）
            byte[] result = br.ReadBytes(length);

            // 清空缓存
            unHandleDataList.Clear();

            // 将读取后的剩余数据写入待处理的缓存队列
            unHandleDataList.AddRange(br.ReadBytes((int)(ms.Length - ms.Position)));

            br.Close();
            ms.Close();

            return result;
        }

    }
}
