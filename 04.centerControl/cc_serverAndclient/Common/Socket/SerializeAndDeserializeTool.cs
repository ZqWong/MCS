using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    /// <summary>
    /// 序列化与反序列化工具
    /// </summary>
    public class SerializeAndDeserializeTool
    {

        /// <summary>
        /// 将obj对象序列化为二进制数组
        /// obj → byte[]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            // 创建编码解码的内存流对象
            MemoryStream ms = new MemoryStream();

            // 创建二进制流序列化对象
            BinaryFormatter bf = new BinaryFormatter();

            // 将obj对象序列化成二进制数据写入到内存流
            bf.Serialize(ms, obj);

            byte[] result = new byte[ms.Length];

            // 将流数据Copy到结果数组
            Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);

            // 关闭内存流
            ms.Close();

            return result;
        }

        /// <summary>
        /// 将二进制数组反序列化为obj对象
        /// byte[] → obj
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] buffer)
        {
            // 创建编码解码的内存流对象，并将需要反序列化的数据写入其中
            MemoryStream ms = new MemoryStream(buffer);

            // 创建二进制流序列化对象
            BinaryFormatter bf = new BinaryFormatter();

            // 将流数据反序列化为obj对象
            object result = bf.Deserialize(ms);

            // 关闭内存流
            ms.Close();

            return result;
        }

    }
}
