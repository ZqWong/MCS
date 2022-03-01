using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Common.Model;
using CommonTools.tools;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MCS.DeviceRespond;
using NPOI.Util;
using UserEventData;
using Utilities;

namespace MCS
{
    /// <summary>
    /// todo 配置启动这垃圾
    /// 该厂家带的sdk是一个垃圾sdk，确保通过配置文件配置，当不启动1710时，此模块的内容不加载.因为在没有安装研华runtimelibrary的机器上直接崩溃
    /// </summary>
    public partial class 设备输入数据 : Form
    {
        private static readonly object syslock = new object();

        private static 设备输入数据 _instance;
        private static SynchronizationContext _uiContext;

        private Dictionary<string, Button> btnDict = new Dictionary<string, Button>();
        private Dictionary<string, TextBox> tbxDict = new Dictionary<string, TextBox>();
        private Dictionary<string, TextBox> serialTbxDict = new Dictionary<string, TextBox>();

        public Dictionary<string, SerialHandlerStruct> serialDict = new Dictionary<string, SerialHandlerStruct>();

        public Dictionary<string, SerialPort> _serialDict = new Dictionary<string, SerialPort>();

        // 保存接收到的485传输的信息
        public Dictionary<string, int> distanceDict = new Dictionary<string, int>();
        // 保存的阈值，可以通过配置文件设置
        public int disThresholdValue = 7;
        // 接收485信息的线程锁
        public object locker = new object();
        // 当前运行状态,如果通过其他设备控制的话，需要给runState赋值
        public enum runState { Stop, Slow, Fast };

        public Dictionary<string, int> curRunStateDict = new Dictionary<string, int>();
        // 液压杆快速运行区间
        public List<int> fastRange = new List<int>(){ 0, 100, 1500, 3000 };

        public static 设备输入数据 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new 设备输入数据();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return _uiContext;
        }

        public 设备输入数据()
        {
            InitializeComponent();

            // 读取xml配置文件信息
            GetDeviceInfoFormXml();
            // 动态创建接收数据的显示控件
            DynamicInit1710();
            // 打开串口
            LoadSerialData();

            Test();
        }

        ~设备输入数据()
        {
            int a = 0;
        }

        public void ReceiceDI0(byte[] buffer)
        {
            // 仅仅处理数字信号状态改变值

            for (int i = 0; i < buffer.Length; i++)
            {

                string btnName = "";

                for (int counter = 0; counter < 8; counter++)
                {
                    int tmp = GetbitValue(buffer[i], counter);

                    btnName = 0 + "_" + (i * 8 + counter);

                    if (tmp == 0)
                    {
                        if (btnDict.ContainsKey(btnName))
                        {
                            btnDict[btnName].BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (btnDict.ContainsKey(btnName))
                        {
                            btnDict[btnName].BackColor = Color.Yellow;
                        }
                    }
                }
            }

            S_U_DeviceDIData sendData = new S_U_DeviceDIData();
            // todo 仅仅作为测试  需要以变量或者宏的形式存在
            sendData.name = "PCI-1710R,BID#0";
            sendData.DIDatas = new byte[buffer.Length];
            Array.Copy(buffer, sendData.DIDatas, buffer.Length);

            RabbitMQEventBus.GetSingleton().Trigger<S_U_DeviceDIData>(sendData);//直接通过事件总线触发

            NlogHandler.GetSingleton().Info(string.Format("pci1710 receive test :0x{0:x}  0x{1:x}", buffer[0], buffer[1]));
        }

        public void ReceiceAI0(double[] data)
        {
            // 仅仅处理数字信号状态改变值
            // 有悬浮值，需要指定获取的channel

            for (int i = 0; i < data.Length; i++)
            {

                string btnName = "";

                btnName = 0 + "_" + i;

                if (tbxDict.ContainsKey(btnName))
                {
                    tbxDict[btnName].Text = data[i].ToString();
                }
            }

            S_U_DeviceAIData sendData = new S_U_DeviceAIData();
            sendData.name = "PCI-1710R,BID#0";
            sendData.AIDatas = new Double[data.Length];
            Array.Copy(data, sendData.AIDatas, data.Length);

            RabbitMQEventBus.GetSingleton().Trigger<S_U_DeviceAIData>(sendData);//直接通过事件总线触发
        }

        private void 设备输入数据_Load(object sender, EventArgs e)
        {
            
        }

        // 动态初始化场景
        private void DynamicInit1710()
        {
            // 本次不全部动态生成，未来需要更改为使用配置文件的方式，当前信息写死
            // 现在生成两个17110采集卡，每个卡16路

            int device1710Count = 2;
            int portCount = 2;
            int portBits = 8;

            int channelCount = 16;

            int btnWidth = 40;
            int btnHeight = 30;

            
            for (int i = 0; i < device1710Count; i++)
            {
                for (int j = 0; j < portCount; j++)
                {
                    for (int k = 0; k < portBits; k++)
                    {
                        // 生成数字量输入的button
                        Button btn = new Button();
                        btn.Name = i + "_" +　(j * portBits + k);
                        btn.Text = i + "_" + (j * portBits + k);
                        btn.Width = btnWidth;
                        btn.Height = btnHeight;
                        btn.Location = new Point((int)(btnWidth/2 + k * btnWidth * 1.5), (int)(btnHeight/2 + (i * device1710Count + j) * btnHeight * 1.5));
                        this.Controls.Add(btn);
                        btnDict[btn.Name] = btn;

                    }
                }
            }

            // 生成模拟量
            for (int ii = 0; ii < device1710Count; ii++)
            {
                for (int jj = 0; jj < channelCount; jj++)
                {
                    // 生成模拟量输入的Text
                    TextBox tbx = new TextBox();
                    tbx.Name = ii + "_" + jj;
                    tbx.Width = btnWidth;
                    tbx.Height = btnHeight;
                    tbx.Location = new Point((int)(btnWidth / 2 + (jj % portBits) * btnWidth * 1.5), (int)(btnHeight / 2 + (device1710Count * portCount + ii * device1710Count + (jj / portBits)) * btnHeight * 1.5));
                    this.Controls.Add(tbx);
                    tbxDict[tbx.Name] = tbx;

                }
            }

            // 生成串口数据读取控件
            int formWidth = 816;

            int serialCount = 0;

            foreach (var serialItem in serialDict)
            {
                TextBox tbx = new TextBox();
                tbx.Name = serialItem.Value.serialName;
                tbx.Width = btnWidth;
                tbx.Height = btnHeight;
                tbx.Location = new Point(formWidth - (int)(btnWidth * 1.5), (int)(btnHeight / 2 + (serialCount * btnHeight * 1.5)));
                this.Controls.Add(tbx);
                serialTbxDict[tbx.Name] = tbx;

                serialCount += 1;
            }
        }


        public void Test()
        {
            //double[] aa = new[] {1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0};
            //ReceiceAI0(aa);


            PCI1710 deviceR = new PCI1710();
            PCI1710 deviceL = new PCI1710();
            deviceR.OnReceiveDI = new ReceiveHandlerDI(ReceiceDI0);
            //deviceL.OnReceiveDI = new ReceiveHandlerDI(ReceiceDI0);

            deviceR.OnReceiveAI = new ReceiveHandlerAI(ReceiceAI0);

            try
            {
                var a = ConfigHelper.GetSingleton().GetAppConfig("PCI1710Name");
                Task.Run(() => deviceR.InitDeviceDI(ConfigHelper.GetSingleton().GetAppConfig("PCI1710Name"), ConfigHelper.GetSingleton().GetAppConfig("PCI1710xmlName"), 0, 2, 2));
                //Task.Run(() => deviceR.InitDeviceDI("PCI-1710L,BID#0", "123.xml", 0, 2, 2));

                Task.Run(() => deviceR.InitDeviceAI(ConfigHelper.GetSingleton().GetAppConfig("PCI1710Name"), ConfigHelper.GetSingleton().GetAppConfig("PCI1710xmlName"), 0, 16, 2));
            }
            catch (Exception e)
            {
                string a = e.Message.ToString();
            }
        }

        private int GetbitValue(byte input, int index)
        {
            if (index > 8)
            {
                return -1;
            }

            int value = input >> index & 0x1;
            return value;
        }

        /// <summary>
        /// 从xml中读取需要读取数据并处理的串口信息到内存中
        /// </summary>
        public void GetDeviceInfoFormXml()
        {
            serialDict.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/SerialDataReadHandler";

            List<XmlNode> serialNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            for (int i = 0; i < serialNodes.Count; i++)
            {

                SerialHandlerStruct serialTemp = new SerialHandlerStruct();

                serialTemp.deviceName = XmlUtil.GetAttribute(serialNodes[i], "DeviceName", "");
                serialTemp.serialName = XmlUtil.GetAttribute(serialNodes[i], "SerialName", "");
                serialTemp.buad = int.Parse(XmlUtil.GetAttribute(serialNodes[i], "Buad", ""));

                serialDict.Add(serialTemp.deviceName, serialTemp);
            }
        }

        public void LoadSerialData()
        {
            foreach (var serialItem in serialDict)
            {
                try
                {
                    SerialPort serialComm = new SerialPort(serialItem.Value.serialName);

                    serialComm.BaudRate = serialItem.Value.buad;

                    // serialComm.NewLine = "\r\n";
                    // serialComm.RtsEnable = true;

                    // serialComm.ReceivedBytesThreshold = 1;

                    serialComm.DataReceived += new SerialDataReceivedEventHandler(SerialOnReceive);

                    if (serialComm.IsOpen == false)
                    {
                        serialComm.Open();

                        if (_serialDict.ContainsKey(serialComm.PortName) == false)
                        {
                            _serialDict.Add(serialComm.PortName, serialComm);
                        }

                        //string send = "qweqwe";
                        //serialComm.Write(send);
                    }
                    else
                    {
                    }
                }
                catch (Exception e)
                {
                    NlogHandler.GetSingleton().Error("读取串口并处理初始化" + e.Message);
                }
            }
        }

        // 处理接收数据
        public void SerialOnReceive(Object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (locker)
                {
                    SerialPort serialPort = sender as SerialPort;
                    string cmdBytes = "";

                    if (serialTbxDict.ContainsKey(serialPort.PortName))
                    {
                        int len = serialPort.BytesToRead;
                        Byte[] readBuffer = new Byte[len];
                        serialPort.Read(readBuffer, 0, len);

                        string readStr = System.Text.Encoding.UTF8.GetString(readBuffer);
                        // 按照换行符分割，不同的rs485发送的分割可能不一样
                        string[] ss = readStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        distanceDict[serialPort.PortName] = int.Parse(ss[ss.Length - 1]);

                        // 回到创建控件的线程来执行
                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            serialTbxDict[serialPort.PortName].Text = distanceDict[serialPort.PortName].ToString();
                        });

                        设备输入数据.GetSingleton().BeginInvoke(mi);

                        if (!curRunStateDict.ContainsKey(serialPort.PortName))
                        {
                            curRunStateDict[serialPort.PortName] = (int) runState.Fast;
                        }

                        // 判断 如果当前在快速范围内
                        for (int i = 0; i < fastRange.Count / 2; i++)
                        {
                            if (distanceDict[serialPort.PortName] > fastRange[i * 2] &&
                                distanceDict[serialPort.PortName] < fastRange[i * 2 + 1])
                            {
                                if (curRunStateDict[serialPort.PortName] == (int)runState.Fast)
                                {
                                    return;
                                }
                                else
                                {
                                    // todo 发送快速运行
                                    ChangeRunState((int)runState.Fast, serialPort);
                                }
                            }
                        }

                        int disMin = distanceDict.Values.Min();
                        int disMax = distanceDict.Values.Max();

                        // 回到创建控件的线程来执行 -- 测试
                        MethodInvoker mii = new MethodInvoker(() =>
                        {
                            textBox_distance.Text = (disMax - disMin).ToString();
                        });

                        设备输入数据.GetSingleton().BeginInvoke(mii);


                        if ((disMax - disMin) > disThresholdValue)
                        {
                            foreach (var item in distanceDict)
                            {
                                if (item.Value == disMax)
                                {
                                    // todo 发送停止指令
                                    ChangeRunState((int)runState.Stop, _serialDict[item.Key]);
                                    // NlogHandler.GetSingleton().Debug(string.Format("stop port name : {0}, disMax {1}, portName{2} : distance:{3},portName{4} : distance:{5},portName{6} : distance:{7}, ", serialPort.PortName, disMax, "COM1",distanceDict["COM1"], "COM5", distanceDict["COM5"], "COM8", distanceDict["COM8"]));
                                }
                            }
                        }
                        else
                        {
                            foreach (var runStateItem in curRunStateDict)
                            {
                                if (runStateItem.Value == (int) runState.Stop)
                                {
                                    // todo 发送慢速运行指令
                                    ChangeRunState((int)runState.Slow, _serialDict[runStateItem.Key]);
                                }
                            }
                        }
                    }

                    serialPort.DiscardInBuffer();  //清空接收缓冲区 
                }

                  
            }
            catch (Exception ex)
            {
                NlogHandler.GetSingleton().Error(string.Format("串口持续读取并处理错误  串口号：{0}， 错误 {1}", (sender as SerialPort).PortName, ex.Message.ToString()));
            }
        }

        // 更改运行状态
        public void ChangeRunState(int state, SerialPort serialPort)
        {
            if (curRunStateDict[serialPort.PortName] == state)
                return;

            string cmdBytes = "";
            switch (state)
            {
                case (int)runState.Stop:
                    cmdBytes = "stop";
                    curRunStateDict[serialPort.PortName] = (int)runState.Stop;
                    break;
                case (int)runState.Slow:
                    cmdBytes = "slow";
                    curRunStateDict[serialPort.PortName] = (int)runState.Slow;
                    break;
                case (int)runState.Fast:
                    cmdBytes = "fast";
                    curRunStateDict[serialPort.PortName] = (int)runState.Fast;
                    break;
                default:
                    break;
            }

            cmdBytes = serialPort.PortName + " " + cmdBytes + "\r\n";

            serialPort.Write(System.Text.Encoding.Default.GetBytes(cmdBytes), 0, cmdBytes.Length);
        }
    }

    /// <summary>
    /// 需要处理串口数据的串口结构体
    /// </summary>
    public class SerialHandlerStruct
    {
        // 设备名称
        public string deviceName;
        // 串口名称
        public string serialName;
        // 波特率
        public int buad;

    }
}
