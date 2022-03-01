using Common;
using Common.Model;
using System;
using Utilities;

namespace MCS.Common
{
    public class MyTool
    {
        /// <summary>
        /// 名称组合
        /// </summary>
        /// <param name="ecsm"></param>
        /// <returns></returns>
        public static string ComboName(ExaminationChildSubjectModel ecsm)
        {
            string newName = ecsm.ExaminationChildSubjectName;

            if (!string.IsNullOrEmpty(ecsm.ExaminationChildSubjectShortName))
            {
                newName = newName + "（简称：" + ecsm.ExaminationChildSubjectShortName + "）";
            }

            return newName;
        }

        /// <summary>
        /// 名称拆分
        /// </summary>
        public static ExaminationChildSubjectModel SplitName(string name)
        {
            ExaminationChildSubjectModel ecsm = new ExaminationChildSubjectModel();
            ecsm.ExaminationChildSubjectName = "";
            ecsm.ExaminationChildSubjectShortName = "";

            if (name.IndexOf("（简称：") == -1)
            {
                ecsm.ExaminationChildSubjectName = name;

                return ecsm;
            }

            string examinationChildSubjectName = name.Substring(0, name.LastIndexOf("（简称："));

            string ExaminationChildSubjectShortName = name.Substring(name.LastIndexOf("：") + 1, name.Length - examinationChildSubjectName.Length - 5);


            ecsm.ExaminationChildSubjectName = examinationChildSubjectName;
            ecsm.ExaminationChildSubjectShortName = ExaminationChildSubjectShortName;

            return ecsm;
        }

        /// <summary>
        /// 远程打开计算机
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        public static void WakeUpComputer(string mac)
        {
            WakeOnLAN(mac.Replace("-", ""));
        }

        /// <summary>
        /// 远程关闭计算机（需要设计Guest用户）
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool ShutDownComputer(string ip)
        {
            bool ret = false;

            string tmpCmd = "shutdown -s -m \\\\" + ip + " -t 1";
            string[] cmd = new string[]
            {
               tmpCmd
            };
            int exitCode = LibUtilities.RunCmd(cmd);
            if (exitCode == 0)
            {
                ret = true;
            }
            else
            {
                //// add by wuxin at 2020/01/06 - start
                //Alert.errorMsg("远程关闭计算机" + ip + " 出现异常：" + exitCode.ToString());
                //// add by wuxin at 2020/01/06 - end
                ///
                
                NlogHandler.GetSingleton().Error("远程关闭计算机" + ip + " 出现异常：" + exitCode.ToString());

                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// 远程重启计算机（需要设计Guest用户）
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool RestartComputer(string ip)
        {
            bool ret = false;

            string tmpCmd = "shutdown -r -m \\\\" + ip + " -t 1";

            string[] cmd = new string[]
            {
                tmpCmd
            };
            int exitCode = LibUtilities.RunCmd(cmd);
            if (exitCode == 0)
            {
                ret = true;
            }
            else
            {
                string str2Log = "远程重启计算机" + ip + " 出现异常：";
                if (exitCode == 5)
                {
                    str2Log += "目标计算机拒绝访问,请检查是否正确设置了Guest账户！";
                }
                else if (exitCode == 53)
                {
                    str2Log += "输入的计算机名无效，或者目标计算机不支持远程关闭。请检查名称然后再试一次，或者与您的系统管理员联系。";
                }
                str2Log += "(错误码：" + exitCode.ToString() + ")";

                // add by wuxin at 2020/01/06 - start
                Alert.errorMsg(str2Log);
                // add by wuxin at 2020/01/06 - end

                LogHelper.WriteErrorLog(str2Log);
                ret = false;
            }

            return ret;
        }

        //now use this class
        //MAC_ADDRESS should  look like '013FA049'
        public static void WakeOnLAN(string MAC_ADDRESS)
        {
            try
            {
                WOLClass client = new WOLClass();
                client.Connect(new System.Net.IPAddress(0xffffffff),  //255.255.255.255  i.e broadcast
                   0x2fff); // port=12287 let's use this one 
                client.SetClientToBrodcastMode();
                //set sending bites
                int counter = 0;
                //buffer to be send
                byte[] bytes = new byte[1024];   // more than enough :-)
                                                 //first 6 bytes should be 0xFF
                for (int y = 0; y < 6; y++)
                    bytes[counter++] = 0xFF;
                //now repeate MAC 16 times
                for (int y = 0; y < 16; y++)
                {
                    int i = 0;
                    for (int z = 0; z < 6; z++)
                    {
                        bytes[counter++] =
                            byte.Parse(MAC_ADDRESS.Substring(i, 2),
                            System.Globalization.NumberStyles.HexNumber);
                        i += 2;
                    }
                }

                //now send wake up packet
                int reterned_value = client.Send(bytes, 1024);
            }
            catch (Exception e)
            {
                // add by wuxin at 2020/01/06 - start
                Alert.errorMsg("远程唤醒计算机" + MAC_ADDRESS + " 出现异常：" + e.ToString());
                // add by wuxin at 2020/01/06 - end
            }
        }
    }
}
