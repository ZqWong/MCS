using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MCS.Common;

namespace DeviceControl
{
    public class DeviceControlClass
    {
        public delegate void DataReceiveNet(object msg, string name);

        public delegate void DataReceiveSerial(string msg,  SerialPort serialPort);

        public event DataReceiveNet OnReceiveNet;
        public event DataReceiveNet OnReceiveNetOnErr;
        public event DataReceiveNet OnReceiveNetOnServerDown;

        public event DataReceiveSerial OnReceiveSerial;

        // 设备信息列表 key:设备名称  value:设备信息对象
        // 必须有，串口初始化和网口保存连接状态需要
        public Dictionary<string, DeviceStruct> deviceDict = new Dictionary<string, DeviceStruct>();
        // 控制码列表  
        // 为了管理控制码，如果控制流程并不复杂，可以不用
        public List<CodeStruct> codeList = new List<CodeStruct>();

        // 网络控制连接管理
        private Dictionary<string, LinkConnection> linkConnectionDict = new Dictionary<string, LinkConnection>();
        // 串口连接管理
        private Dictionary<string, SerialPort> serialDict = new Dictionary<string, SerialPort>();
        // 串口接收消息线程
        private Thread _threadReceiveSerial;

        // 消息队列处理消息
        private Thread _threadMessageQueue;
        ConcurrentQueue<KeyValuePair<string, string>> eventDelayQueue = new ConcurrentQueue<KeyValuePair<string, string>>();
        ConcurrentQueue<KeyValuePair<string, string>> eventQueue = new ConcurrentQueue<KeyValuePair<string, string>>();


        // 自动定时执行的设备控制的定时器
        private System.Timers.Timer _autoExecDeviceControlTimer;
        private long secondCount = 0;

        // 单例
        private static DeviceControlClass _instance;
        private static readonly object syslock = new object();

        public static DeviceControlClass GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new DeviceControlClass();
                    }
                }
            }

            return _instance;
        }

        private DeviceControlClass()
        {
            _threadMessageQueue = new Thread(ExecDeviceQueue);
            _threadMessageQueue.Start();
            _threadMessageQueue.IsBackground = true;

            _autoExecDeviceControlTimer = new System.Timers.Timer();
            _autoExecDeviceControlTimer.Elapsed += AutoExexDeviceControl;

            _autoExecDeviceControlTimer.AutoReset = true;
            _autoExecDeviceControlTimer.Interval = 1000;
            _autoExecDeviceControlTimer.Enabled = true;

        }

        /// <summary>
        /// 自动固定间隔执行控制码。比如查询状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoExexDeviceControl(object sender, System.Timers.ElapsedEventArgs e)
        {
            secondCount += 1;
            if (secondCount > 2147483646)
            {
                secondCount = 0;
            }

            List<CodeStruct> autoDeviceList = codeList.Where(item => item.autoExecInterval > 0.000001).ToList();

            foreach (var codeItem in autoDeviceList)
            {
                if (secondCount % (int)codeItem.autoExecInterval == 0)
                {
                    Dictionary<string, DeviceStruct> deviceDictTemp = deviceDict.Where((item) => item.Value.deviceClassName == codeItem.className).ToDictionary(i => i.Key, i => i.Value); ;

                    foreach (var deviceItem in deviceDictTemp)
                    {
                        DeviceControl(deviceItem.Value.deviceName, codeItem.codeName);
                    }
                }
            }
        }

        private void ExecDeviceQueue()
        {
            KeyValuePair<string, string> eventTemp;

            while (true)
            {
                while (eventDelayQueue.TryDequeue(out eventTemp))
                {
                    ControlByCodeName(eventTemp.Key, eventTemp.Value);
                }

                while (eventQueue.TryDequeue(out eventTemp))
                {
                    ControlByCodeName(eventTemp.Key, eventTemp.Value);
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 初始化串口连接等,串口连接需要在serialDict赋值完成之后进行初始化
        /// </summary>
        public void SerialInit()
        {

            foreach (var name in deviceDict.Keys)
            {
                SerialPort serialComm;
                if (deviceDict[name].controlType == 1)
                {
                    try
                    {
                        serialComm = new SerialPort(deviceDict[name].serialPort);

                        if (serialComm.IsOpen)
                            serialComm.Close();

                        serialComm.BaudRate = deviceDict[name].buad;
                        // serialComm.DataReceived += new SerialDataReceivedEventHandler(OnReceiveSerial);


                        if (serialComm.IsOpen == false)
                        {
                            serialComm.Open();
                            if (serialDict.ContainsKey(name) == false)
                            {
                                serialDict.Add(name, serialComm);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            _threadReceiveSerial = new Thread(ReceiveSeriel);
            _threadReceiveSerial.Start();
            _threadReceiveSerial.IsBackground = true;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceName">设备名称</param>
        /// <param name="code">控制码</param>
        /// <returns>返回错误代码，返回为0：没错误， 1：没找到输入的设备名称， 2：改设备的设备类型没有对应的控制码</returns>
        public void Control(string deviceName, string code)
        {
            // todo 添加控制后延迟时间  添加接收

            if (deviceDict.ContainsKey(deviceName))
            {

                byte[] cmdBytes;
                cmdBytes = System.Text.Encoding.Default.GetBytes(code); 

                if (deviceDict[deviceName].controlType == 0)
                {
                    // 网口
                    LinkConnection c;

                    if (linkConnectionDict.ContainsKey(deviceName))
                    {
                        c = linkConnectionDict[deviceName];
                    }
                    else
                    {
                        c = new LinkConnection(deviceDict[deviceName].ip, int.Parse(deviceDict[deviceName].port), deviceName);
                        linkConnectionDict[deviceName] = c;
                        c.OnReceive += new DelegateMsg(ReceiveNet);
                        c.OnErr += new DelegateMsg(ReceiveNetOnErr);
                        c.OnServerDown += new DelegateMsg(ReceiveNetOnServerDown);
                    }

                    if (c.sendBytes(cmdBytes))
                    {
                        // 发送比较频繁、关闭此log
                        // NlogHandler.GetSingleton().Info(string.Format("网口控制设备 {0} {1}, ip：{2}", name, controlCode, ip));
                    }
                    else
                    {
                        // 发送比较频繁、关闭此log
                        // NlogHandler.GetSingleton().Info(string.Format("网口控制设备 {0} {1} 异常, ip：{2}", name, controlCode, ip));
                    }

                }
                else if (deviceDict[deviceName].controlType == 1)
                {
                    // 串口
                    if (serialDict.ContainsKey(deviceName))
                    {
                        // 串口控制
                        serialDict[deviceName].Write(cmdBytes, 0, cmdBytes.Length);
                    }
                }
            }
        }

        /// <summary>
        /// 设备控制
        /// </summary>
        /// <param name="deviceName">设备名称</param>
        /// <param name="codeName">控制码名称</param>
        public void DeviceControl(string deviceName, string codeName)
        {
            List<CodeStruct> codeListTemp = codeList.Where(
                item => item.codeName == codeName && item.className == deviceDict[deviceName].deviceClassName).ToList();

            if (codeListTemp.Count != 1)
            {
                return;
            }

            if (codeListTemp[0].delay > 0.0000001)
            {
                eventDelayQueue.Enqueue(new KeyValuePair<string, string>(deviceName, codeName));
            }
            else
            {
                eventQueue.Enqueue(new KeyValuePair<string, string>(deviceName, codeName));
            }
        }

        /// <summary>
        /// 通过控制码名称控制设备
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="codeName">控制码名称</param>
        private void ControlByCodeName(string deviceName, string codeName)
        {
            List<CodeStruct> codeListTemp = codeList.Where(
                item => item.codeName == codeName && item.className == deviceDict[deviceName].deviceClassName).ToList();

            if (codeListTemp.Count != 1)
            {
                return;
            }


            Control(deviceName, codeListTemp[0].code);

            Thread.Sleep((int)codeListTemp[0].delay);

        }

        /// <summary>
        /// 处理网络返回
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        private void ReceiveNet(object msg, string name)
        {
            if (OnReceiveNet != null)
            {
                OnReceiveNet(msg, name);
            }
        }

        /// <summary>
        /// 处理网络错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        private void ReceiveNetOnErr(object msg, string name)
        {
            if (OnReceiveNetOnErr != null)
            {
                OnReceiveNetOnErr(msg, name);
            }

        }

        /// <summary>
        /// 处理服务器错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        private void ReceiveNetOnServerDown(object msg, string name)
        {
            if (OnReceiveNetOnServerDown != null)
            {
                OnReceiveNetOnServerDown(msg, name);
            }
        }

        /// <summary>
        /// 串口接收
        /// </summary>
        private void ReceiveSeriel()
        {
            try
            {
                //定义一个字段，来保存串口传来的信息。
                string returnCode = "";

                Byte[] readBuffer = new Byte[256];
                int offsetCount = 0;

                while (true)
                {
                    foreach (SerialPort serialPort in serialDict.Values)
                    {
                        if (!serialPort.IsOpen)
                            return;

                        if (serialPort.BytesToRead > 0)
                        {
                            while (serialPort.BytesToRead > 0)
                            {
                                int len = serialPort.BytesToRead;
                                serialPort.Read(readBuffer, offsetCount, len);
                                offsetCount += len;
                                Thread.Sleep(1);
                            }

                            string receiveStr = System.Text.Encoding.UTF8.GetString(readBuffer).Replace("\0", string.Empty);

                            if (receiveStr == "")
                            {
                                continue;
                            }

                            offsetCount = 0;

                            if (OnReceiveSerial != null)
                            {
                                OnReceiveSerial(receiveStr, serialPort);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception exception)
            {
                return;
            }
        }


        /// <summary>
        /// string 转 16进制，有些时候需要将控制码转为16进制(XX XX XX XX)发送出去
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StringToHex(string input)
        {
            string hexOutput = "";

            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                hexOutput += String.Format("{0:X2}", value) + " ";
            }

            //hexOutput += "0d";

            return hexOutput;
        }

        /**/
        /// <summary>
        /// 16进制字符串转换为二进制数组。16进制特殊的格式(XX XX XX XX)
        /// 功能等同于hex先转为string，然后在转为byte[]
        /// </summary>
        /// <param name="hexstring">用空格切割字符串</param>
        /// <returns>返回一个二进制字符串</returns>
        public static byte[] HexStringToBinary(string s)
        {
            if (s.Length == 0)
                throw new Exception("将16进制字符串百转换成字节度数组时出错，错误信息：被知转换的字符串长度为0。道");
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                // sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                sb.AppendFormat("{0:x2} ", b);
            }

            string res = sb.ToString().ToUpper();
            res = res.Substring(0, res.Length - 1);

            return res;
        }

        public static void ReceiveSerial(Object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort serialPort = sender as SerialPort;

                if (!serialPort.IsOpen)
                    return;

                //定义一个字段，来保存串口传来的信息。
                string returnCode = "";

                int len = serialPort.BytesToRead;
                Byte[] readBuffer = new Byte[len];
                serialPort.Read(readBuffer, 0, len);
                returnCode = DeviceControlClass.ByteArrayToHexString(readBuffer);
                Console.WriteLine(string.Format("receive data from serial:{0}, serial:{1}", returnCode,
                    serialPort.PortName));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

    }



}
