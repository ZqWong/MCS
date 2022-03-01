using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DeviceControl;

namespace ConsoleApp1
{
    public struct ClientInfo
    {
        public string mIp;
        public string mCode;
    };


    class Program
    {
        public Dictionary<string, ClientInfo> mClientDict = new Dictionary<string, ClientInfo>(); //读取的client配置 
        public int port;

        void ReadConfig()
        {
            //读取配置文件
            string path = "config.xml";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(path, settings);

            reader.ReadToFollowing("commonConfig");
            int.TryParse(reader.GetAttribute("tcpPort"), out port);
            //CONTROL_ID_LIST = Array.ConvertAll<string, int>(reader.GetAttribute("controlID").Split(','), s => int.Parse(s)).ToList();
            //int.TryParse(reader.GetAttribute("minClientCounts"), out mIMinClientCounts);
            //int.TryParse(reader.GetAttribute("limitGpuUsage"), out limitGpuUsage);
            //int.TryParse(reader.GetAttribute("limitGpuSleepTime"), out limitGpuSleepTime);
            //int.TryParse(reader.GetAttribute("clientWaitOutTime"), out clientWaitOutTime);
            //float.TryParse(reader.GetAttribute("sameFrameTimeDiffThreshold"), out mSameFrameTimeDiffThreshold);

            while (reader.ReadToFollowing("client"))
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.mIp = reader.GetAttribute("ip");

                if (clientInfo.mIp == null)
                    continue;

                clientInfo.mCode = reader.GetAttribute("code");

                mClientDict.Add(clientInfo.mIp, clientInfo);
            }
        }

        static void Main(string[] args)
        {
            Program test = new Program();
            test.ReadConfig();

            DeviceControlClass dc = new DeviceControlClass();

            foreach (var ip in test.mClientDict.Keys)
            {
                DeviceStruct pj = new DeviceStruct();
                pj.ip = ip; // ConfigHelper.GetSingleton().GetAppConfig("DBname");
                pj.port = test.port.ToString();
                pj.serialPort = "COM1";
                pj.buad = 9600;
                pj.controlType = 0;
                pj.deviceClassName = "Project";
                pj.deviceName = ip;

                dc.deviceDict.Add(pj.deviceName, pj);
            }

            //DeviceControlClass dc = new DeviceControlClass();
            //DeviceStruct pj = new DeviceStruct();
            //pj.ip = "192.168.0.57"; // ConfigHelper.GetSingleton().GetAppConfig("DBname");
            //pj.port = "4352";
            //pj.serialPort = "COM1";
            //pj.buad = 9600;
            //pj.controlType = 1;
            //pj.deviceClassName = "Project";
            //pj.deviceName = "project1";

            //CodeStruct tmp = new CodeStruct();
            //tmp.code = "powerOn";
            //tmp.codeName = "Open";
            //tmp.className = "Project";
            //tmp.delay = 0;
            //tmp.autoExecInterval = 0.0f;

            //dc.deviceDict.Add("project1", pj);
            //dc.codeDict.Add("Project", tmp);

            dc.OnReceiveNet += ReceiveNet;
            dc.OnReceiveNetOnErr += ReceiveNetOnErr;
            dc.OnReceiveNetOnServerDown += ReceiveNetOnServerDown;
            //dc.OnReceiveSerial += ReceiveSerial;

            //dc.SerialInit();

            // dc.Control("project1", "Open");

            foreach (var key in test.mClientDict.Keys)
            {
                dc.Control(key, test.mClientDict[key].mCode);
            }
            

            Console.ReadLine();
        }

        public static void ReceiveNet(object msg, string name)
        {
            string returnCode = msg.ToString();
            Console.WriteLine(string.Format("return from :{0}, code: {1}",name,returnCode));
        }

        public static void ReceiveNetOnErr(object msg, string name)
        {
            string returnCode = msg.ToString();
            Console.WriteLine(string.Format("err :{0}, code: {1}", name, returnCode));
        }

        public static void ReceiveNetOnServerDown(object msg, string name)
        {
            string returnCode = msg.ToString();
            Console.WriteLine(string.Format("server down :{0}, code: {1}", name, returnCode));
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
