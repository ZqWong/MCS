using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.tools;
using Utilities;

namespace cc_client_update
{
    class Update
    {
        private string _oldFolder;
        private string _newFolder;
        private string _updateClientFullName;
        private string _clientFullName;

        public Update(string oldFolder, string newFolder ,string clientFullName, string updateClientFullName)
        {
            this._oldFolder = oldFolder;
            this._newFolder = newFolder;
            this._clientFullName = clientFullName;
            this._updateClientFullName = updateClientFullName;
        }

        private void StopProcess()
        {
            string processName = _clientFullName.Substring(_clientFullName.LastIndexOf(@"\") + 1,
                _clientFullName.Length - _clientFullName.LastIndexOf(@"\") - 1);

            processName = processName.Replace(".exe", "");

            NlogHandler.GetSingleton().Info(string.Format("要关闭的进程名称： {0}", processName));

            Process[] processes = Process.GetProcessesByName(processName);

            NlogHandler.GetSingleton().Info(string.Format("processes count is ： {0}", processes.Length));

            foreach (Process p in processes)
            {
                string FilePathName = ComFunc.GetSingleton().GetMainModuleFilepath(p.Id);

                NlogHandler.GetSingleton().Info(string.Format("{0}  ， {1}", FilePathName, _clientFullName));

                if (_clientFullName == FilePathName)
                {
                    p.Kill();
                    p.Close();

                    NlogHandler.GetSingleton().Info(string.Format("成功关闭客户端进程"));
                }
            }

            Thread.Sleep(3000);

        }

        private bool StartProcess()
        {
            if (File.Exists(_clientFullName))
            {

                string path = _clientFullName.Substring(0, _clientFullName.LastIndexOf('\\'));

                Directory.SetCurrentDirectory(path);
                Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = _clientFullName;
                process.StartInfo.Arguments = "";//-s -t 可以用来关机、开机或重启
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.RedirectStandardInput = false;  //true
                process.StartInfo.RedirectStandardOutput = false;  //true
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                return true;
            }

            return false;
        }

        public void DeleteAndUpdate()
        {
            
            // 判断newfolder中是否包含运行文件
            string processName = _clientFullName.Substring(_clientFullName.LastIndexOf(@"\") + 1,
                _clientFullName.Length - _clientFullName.LastIndexOf(@"\") - 1);

            string newFolderClientFullName = _newFolder + @"\" + processName;

            

            if (File.Exists(newFolderClientFullName))
            {

            }
            else
            {
                NlogHandler.GetSingleton().Info(string.Format("新版本客户端执行路径: {0}, 不存在可执行文件", newFolderClientFullName));
                return;
            }
            

            StopProcess();

            NlogHandler.GetSingleton().Info(string.Format("关闭客户端进程"));

            string oldClientPath = _clientFullName.Substring(0, _clientFullName.LastIndexOf('\\'));

            string oldParentPath = oldClientPath.Substring(0, oldClientPath.LastIndexOf('\\'));

            List<string> exceptPath = new List<string>();

            exceptPath.Add(oldClientPath + @"\updateProgress");
            // 判断newFolder是不是oldFolder的子目录
            if (_newFolder.Contains(oldClientPath))
            {
                // 是子目录
                //string newFolderPath = oldParentPath + @"\update";

                //Directory.Move(_newFolder, newFolderPath);
                //_newFolder = newFolderPath + @"\" + _newFolder.Substring(_newFolder.LastIndexOf(@"\") + 1,
                //                 _newFolder.Length - _newFolder.LastIndexOf(@"\") - 1);

                
                exceptPath.Add(_newFolder);

                //ComFunc.GetSingleton().DeleteFolder(oldClientPath, exceptPath);
                try
                {
                    ComFunc.GetSingleton().DeleteFolder(oldClientPath, exceptPath);
                }
                catch (Exception e)
                {
                    NlogHandler.GetSingleton().Error(string.Format(e.Message.ToString()));
                    Console.WriteLine(e.Message.ToString());
                }

            }
            else
            {
                // 不是子目录
                ComFunc.GetSingleton().DeleteFolder(oldClientPath, exceptPath);
            }

            // 复制文件
            ComFunc.GetSingleton().directoryCopy(_newFolder, oldClientPath);

            // 删除更新文件
            ComFunc.GetSingleton().DeleteFolder(_newFolder);

            StartProcess();
        }


    }
}
