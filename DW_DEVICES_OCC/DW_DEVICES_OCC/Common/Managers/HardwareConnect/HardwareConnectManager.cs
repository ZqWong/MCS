using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HardwareConnectManager
{
    /// <summary>
    /// 创建串口连接
    /// </summary>
    /// <param name="serialPort">串口</param>
    /// <param name="Buad">波特率</param>
    /// <returns></returns>
    public static bool SerialPortConnect(string serialPort, int Buad, out SerialPort serial)
    {
        bool ret = false;
        serial = new SerialPort(serialPort);
        try
        {         
            if (serial.IsOpen)
                serial.Close();

            serial.BaudRate = Buad;

            if (!serial.IsOpen)
            {
                serial.Open();
            }
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"串口连接失败 {ex}");
            throw ex;
        }        
        return ret;
    }

    /// <summary>
    /// 网口连接
    /// </summary>
    public static void NetPortConnect()
    {

    }

}

