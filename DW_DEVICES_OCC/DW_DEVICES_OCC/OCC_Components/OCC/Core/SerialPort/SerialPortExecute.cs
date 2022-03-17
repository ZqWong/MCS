using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCC.Core
{
    public class SerialPortExecute
    {
        /// <summary>
        /// 创建串口连接，并绑定消息接收事件
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="serialPort"></param>
        /// <param name="baud"></param>
        /// <param name="receivedEventHandler"></param>
        /// <param name="serial"></param>
        /// <returns></returns>
        public static bool CreateSerialConnect(string ip, string serialPort, int baud , SerialDataReceivedEventHandler receivedEventHandler, out SerialPort serial)
        {
            bool ret = false;
            try
            {
                serial = new SerialPort(serialPort);
                serial.BaudRate = baud;
                serial.DataReceived += receivedEventHandler;

                if (!serial.IsOpen)
                {
                    serial.Open();
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"创建串口连接失败 {ex}");

                throw ex;
              
            }
            return ret;
        }
    }
}
