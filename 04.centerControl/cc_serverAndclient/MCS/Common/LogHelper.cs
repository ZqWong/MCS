using System;
using System.Configuration;
using System.IO;
using System.Threading;
using DW_CC_NET.tools;
using NPOI.Util;
using Utilities;

namespace MCS.Common
{
    public class LogHelper
    {
        //#region  创建错误日志
        /////-----------------------------------------------------------------------------
        ///// <summary>创建错误日志 在c:\ErrorLog\</summary>
        ///// <param name="strFunctionName">strFunctionName,调用方法名</param>
        ///// <param name="strErrorNum">strErrorNum,错误号</param>
        ///// <param name="strErrorDescription">strErrorDescription,错误内容</param>
        ///// <returns></returns>
        ///// <history>2009-05-29 Created</history>
        /////-----------------------------------------------------------------------------
        ////举例:
        ////         try
        ////         {    要监视的代码     }
        ////      catch()
        ////            {  myErrorLog.m_CreateErrorLogTxt("myExecute(" & str执行SQL语句 & ")", Err.Number.ToString, Err.Description)  }     
        ////         finally
        ////         {            }
        //public static void m_CreateErrorLogTxt(string strFunctionName, string strErrorNum, string strErrorDescription)
        //{
        //    string strMatter; //错误内容
        //    string strPath; //错误文件的路径
        //    DateTime dt = DateTime.Now;
        //    try
        //    {
        //        //Server.MapPath("./") + "File"; 服务器端路径
        //        strPath = Directory.GetCurrentDirectory() + "\\ErrorLog";   //winform工程\bin\目录下 创建日志文件夹 
        //        //strPath = "c:" + "\\ErrorLog";//暂时放在c:下

        //        if (Directory.Exists(strPath) == false)  //工程目录下 Log目录 '目录是否存在,为true则没有此目录
        //        {
        //            Directory.CreateDirectory(strPath); //建立目录　Directory为目录对象
        //        }
        //        strPath = strPath + "\\" + dt.ToString("yyyyMM");

        //        if (Directory.Exists(strPath) == false)  //目录是否存在  '工程目录下 Log\月 目录   yyyymm
        //        {
        //            Directory.CreateDirectory(strPath);  //建立目录//日志文件，以 日 命名 
        //        }
        //        strPath = strPath + "\\" + dt.ToString("dd") + ".txt";

        //        strMatter = strFunctionName + " , " + strErrorNum + " , " + strErrorDescription;//生成错误信息

        //        StreamWriter FileWriter = new StreamWriter(strPath, true); //创建日志文件
        //        FileWriter.WriteLine("Time: " + dt.ToString("HH:mm:ss") + "  Err: " + strMatter);
        //        FileWriter.Close(); //关闭StreamWriter对象
        //    }
        //    catch (Exception ex)
        //    {
        //        //("写错误日志时出现问题，请与管理员联系！ 原错误:" + strMatter + "写日志错误:" + ex.Message.ToString());
        //        string str = ex.Message.ToString();
        //    }
        //}
        //#endregion

        #region 字段
        public static readonly object _lock = new object();
        #endregion

        #region 写文件
        /// <summary>
        /// 写文件
        /// </summary>
        public static void WriteFile(string log, string path)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(delegate (object obj)
            {
                lock (_lock)
                {
                    if (!File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create)) { }
                    }
                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            #region 日志内容
                            string value = string.Format(@"{0}----{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), obj.ToString());
                            #endregion
                            sw.WriteLine(value);
                            sw.Flush();
                        }
                    }
                }
            }));

            thread.Start(log);
        }
        #endregion

        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string log)
        {
            NlogHandler.GetSingleton().Info(log);

            //string logPath = Const.LogPath;
            //WriteFile(log, logPath);
        }
        #endregion

        #region 写错误日志
        /// <summary>
        /// 写错误日志
        /// </summary>
        public static void WriteErrorLog(string log)
        {
            NlogHandler.GetSingleton().Error("Error : " + log);

            //string logPath = Const.LogPath;
            //WriteFile("错误：" + log, logPath);
        }
        #endregion

        #region 日志清理

        public static void CleanUp()
        {
            //string fileName = NlogHandler.GetSingleton().GetFileName();
            //int index_temp = fileName.LastIndexOf("\\");
            //string fileDir = fileName.Substring(0, index_temp + 1);
            string fileDir = NlogHandler.GetSingleton().GetFolderName();

            long length = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(fileDir);
            ComFunc.GetSingleton().GetFilesLenInFolderRescusively(directoryInfo.GetDirectories(), directoryInfo.GetFiles(), ref length);

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

            LogHelper.WriteLog("========================================================");
            LogHelper.WriteLog("系统日志清理成功！");
        }


        #endregion

    }
}
