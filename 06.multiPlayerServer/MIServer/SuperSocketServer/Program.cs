using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;

namespace MIServer
{
    class Program
    {

        public void BootByConfig()
        {

            var bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize())
            {
                Console.WriteLine("Failed to initialize!");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();

            Console.WriteLine("Start result: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            //Stop the appServer
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        static ILog Logger = log4net.LogManager.GetLogger("debugAppender");

        static void appServer_NewSessionConnected(LockStepServerSession session)
        {

            Console.WriteLine("Client connected!");
        }

        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirs"></param>
        /// <param name="fileInfos"></param>
        /// <param name="retLen"></param>
        public static void GetFilesLenInFolderRescusively(DirectoryInfo[] dirs, FileInfo[] fileInfos, ref long retLen)
        {
            int nFiles = fileInfos.Length;
            for (int i = 0; i < nFiles; i++)
            {
                retLen += fileInfos[i].Length;
            }

            int nFolders = dirs.Length;
            for (int i = 0; i < nFolders; i++)
            {
                DirectoryInfo[] subDirs = dirs[i].GetDirectories();
                FileInfo[] subFileInfos = dirs[i].GetFiles();
                GetFilesLenInFolderRescusively(subDirs, subFileInfos, ref retLen);
            }
        }

        /// <summary>
        /// 自动删除日志
        /// </summary>
        public static void AutoDeleteLog()
        {

            string fileDir = AppDomain.CurrentDomain.BaseDirectory + @"\" + "Logs";

            long length = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(fileDir);
            GetFilesLenInFolderRescusively(directoryInfo.GetDirectories(), directoryInfo.GetFiles(), ref length);

            // 大于100M就清理
            if (length / Math.Pow(1024, 2) < 100)
            {
                return;
            }

            // 清空文件夹
            foreach (string d in Directory.GetFileSystemEntries(fileDir))
            {
                if (System.IO.File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    System.IO.File.Delete(d);//直接删除其中的文件    
                }
                if (System.IO.Directory.Exists(d))
                {
                    Directory.Delete(d, true);
                }
            }

            Logger.Info(string.Format("clear log"));
        }

        static void Main(string[] args)
        {
            Program progress = new Program();

            progress.BootByConfig();

            
        }
    }
}
