using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// 将数据写入成二进制
/// </summary>
public class ByteArray
{
    MemoryStream ms = new MemoryStream();
    BinaryWriter bw;
    BinaryReader br;

    /// <summary>
    /// 默认构造
    /// </summary>
    public ByteArray()
    {
        br = new BinaryReader(ms);
        bw = new BinaryWriter(ms);
    }

    /// <summary>
    /// 支持传入初始数据的构造
    /// </summary>
    /// <param name="buff"></param>
    public ByteArray(byte[] buffer)
    {
        ms = new MemoryStream(buffer); // 实例化顺序不可变
        br = new BinaryReader(ms);
        bw = new BinaryWriter(ms);
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Close()
    {
        br.Close();
        bw.Close();
        ms.Close();
    }

    #region read

    public void read(out int value)
    {
        value = br.ReadInt32();
    }

    public void read(out byte value)
    {
        value = br.ReadByte();
    }

    public void read(out bool value)
    {
        value = br.ReadBoolean();
    }

    public void read(out string value)
    {
        value = br.ReadString();
    }

    public void read(out double value)
    {
        value = br.ReadDouble();
    }

    public void read(out float value)
    {
        value = br.ReadSingle();
    }

    public void read(out long value)
    {
        value = br.ReadInt64();
    }

    public void read(out byte[] value, int length)
    {
        value = br.ReadBytes(length);
    }

    #endregion

    #region write
    public void write(int value)
    {
        bw.Write(value);
    }

    public void write(byte value)
    {
        bw.Write(value);
    }

    public void write(bool value)
    {
        bw.Write(value);
    }
    public void write(string value)
    {
        bw.Write(value);
    }

    public void write(double value)
    {
        bw.Write(value);
    }

    public void write(float value)
    {
        bw.Write(value);
    }

    public void write(long value)
    {
        bw.Write(value);
    }

    public void write(byte[] value)
    {
        bw.Write(value);
    }

    #endregion

    /// <summary>
    /// 重置读取下标
    /// </summary>
    public void ResetPosition()
    {
        ms.Position = 0;
    }

    /// <summary>
    /// 获取当前数据 读取到的下标位置
    /// </summary>
    public int Position
    {
        get { return (int)ms.Position; }
    }

    /// <summary>
    /// 获取当前数据长度
    /// </summary>
    public int Length
    {
        get { return (int)ms.Length; }
    }

    /// <summary>
    /// 当前是否还有数据可以读取
    /// </summary>
    public bool IsHasBufferCanRead
    {
        get { return ms.Length > ms.Position; }
    }

    /// <summary>
    /// 获取数据
    /// </summary>
    /// <returns></returns>
    public byte[] GetBuffer()
    {
        byte[] tempBuffer = new byte[ms.Length];
        Buffer.BlockCopy(ms.GetBuffer(), 0, tempBuffer, 0, (int)ms.Length);

        return tempBuffer;
    }
}