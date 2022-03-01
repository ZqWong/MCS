using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventBus.RabbitMQ;
using EventBus.tools;
using UserEventData;


/// <summary>
/// 需要安装插件：rabbitmq_event_exchange
/// </summary>
namespace cc_server
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("主线程是：{0}", Thread.CurrentThread.ManagedThreadId);

            RabbitMQEventBus.GetSingleton().RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());

            RabbitMQEventBus.GetSingleton().CreatePluginEventConsumerChannel();

            // 测试///////////////////////////////////////////////////////////////

            test();


            /////////////////////////////////////////////////////////////////////

            Console.WriteLine("***********************");
            Console.ReadLine();


            RabbitMQEventBus.GetSingleton().Dispose();


        }


        static void test()
        {
            TestSendSyncTime();

            test_sendFile();
            test_clientStartProcess();

            while (true)
            {
                test_clientState();
                Thread.Sleep(1000);
                test_clientProcess();
                Thread.Sleep(1000);

            }
        }

        static void test_clientState()
        {
            RabbitMQEventBus.GetSingleton().Trigger<R_C_CurrentStateData>(new R_C_CurrentStateData());//直接通过事件总线触发
        }


        static void test_clientProcess()
        {
            RabbitMQEventBus.GetSingleton().Trigger<R_C_ProcessStateData>(new R_C_ProcessStateData("cc_server"));//直接通过事件总线触发
        }

        static void test_clientStartProcess()
        {
            // 全部启动
            //RabbitMQEventBus.GetSingleton().Trigger<RequestClientControlProcessData>(new RequestClientControlProcessData(@"D:\Program Files\JiJiDown\JiJiDownForWPF.exe", true));//直接通过事件总线触发

            //Thread.Sleep(5000);
            // 全部关闭
            //RabbitMQEventBus.GetSingleton().Trigger<RequestClientControlProcessData>(new RequestClientControlProcessData(@"D:\Program Files\JiJiDown\JiJiDownForWPF.exe", false));//直接通过事件总线触发


            // 定向启动测试机
            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlProcessData>("192.168.0.57",new R_C_ControlProcessData(@"C:\Program Files\Git\git-bash.exe", true));


        }

        static void test_sendFile()
        {
            //SendFile(@"D:\Soft\UnitySetup64.exe", @"C:\temp");
            SendFile(@"D:\Soft\UnityDownloadAssistant-2018.4.9f1.exe", @"C:\temp");
        }

        private static void SendFile(string sourPath, string destPath)
        {
            var sendData = new S_C_FileData();
            sendData.fileMD5 = GetFileMD5Hash.GetSingleton().GetMD5HashFromFile(sourPath);

            //创建一个文件对象
            FileInfo EzoneFile = new FileInfo(sourPath);
            //打开文件流
            FileStream EzoneStream = EzoneFile.OpenRead();

            //包的大小524288
            int PacketSize = 1048576;

            //包的数量
            int PacketCount = (int)(EzoneStream.Length / ((long)PacketSize));

            //最后一个包的大小
            int LastDataPacket = (int)(EzoneStream.Length - ((long)(PacketSize * PacketCount)));

            if (LastDataPacket > 0)
            {
                PacketCount += 1;
            }


            string[] name = sourPath.Split('\\');// 一定是单引 

            sendData.destPath = destPath;
            sendData.name = name[name.Length - 1];
            sendData.totalCount = PacketCount;

            bool isCut = false;
            //数据包
            byte[] data = new byte[PacketSize];
            //开始循环发送数据包
            for (int i = 0; i < PacketCount - 1; i++)
            {
                //从文件流读取数据并填充数据包
                EzoneStream.Read(data, 0, data.Length);
                sendData.FileData = data;
                //发送数据包

                sendData.currentCount = i + 1;

                RabbitMQEventBus.GetSingleton().Trigger<S_C_FileData>(sendData);//直接通过事件总线触发
                //RabbitMQEventBus.GetSingleton().Trigger<TestFileData>("192.168.0.112",sendData);//直接通过事件总线触发
                
                Console.WriteLine("发送{0}", sendData.currentCount);
                //Thread.Sleep(100);

            }

            //如果还有多余的数据包，则应该发送完毕！
            if (LastDataPacket != 0)
            {
                data = new byte[LastDataPacket];
                EzoneStream.Read(data, 0, data.Length);
                sendData.FileData = data;

                sendData.currentCount = PacketCount;

                RabbitMQEventBus.GetSingleton().Trigger<S_C_FileData>(sendData);//直接通过事件总线触发

                Console.WriteLine("发送完毕.CurrentCount is {0}, TotalCount is {1}", sendData.currentCount , PacketCount);

            }
        }

        static void TestSendSyncTime()
        {
            System.DateTime currentTime = System.DateTime.Now;
            string strFu = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

            var sendData = new S_C_SyncSystemTimeData();
            sendData.wYear = (ushort)currentTime.Year;
            sendData.wMonth = (ushort)currentTime.Month;
            sendData.wDay = (ushort)currentTime.Day;
            sendData.wHour = (ushort)currentTime.Hour;
            sendData.wMinute = (ushort)currentTime.Minute;
            sendData.wSecond = (ushort)currentTime.Second;
            sendData.wMiliseconds = (ushort)currentTime.Millisecond;
            sendData.wDayOfWeek = (ushort)currentTime.DayOfWeek;

            RabbitMQEventBus.GetSingleton().Trigger<S_C_SyncSystemTimeData>(sendData);//直接通过事件总线触发

        }
    }
}
