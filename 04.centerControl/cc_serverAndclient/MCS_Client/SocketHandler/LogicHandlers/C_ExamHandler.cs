using Common;
using Common.Model;
using Common.XML;
using MCS_Client.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCS_Client.SocketHandler.LogicHandlers
{
    public class C_ExamHandler : C_HandlerInterface
    {
        public static string _UnityClientConfigFilePath = "";
        public static string _UnityClientName = "";
        public static string _UnityClientPath = "";

        public void MessageReceive(SocketModel message)
        {
            // 根据Command分别进行处理
            switch (message.Command)
            {
                case (byte)Protocol.Command.StartExam:

                    ClientForm.Form.ShowMessage("服务器请求打开VR考试系统。");

                    ExaminationPCModel model = (ExaminationPCModel)message.Message;

                    // 打开VR考试系统
                    ExcuteStartExamCommand(model);

                    break;

                case (byte)Protocol.Command.Recycle:

                    ClientForm.Form.ShowMessage("服务器请求关闭VR考试系统。");

                    ExaminationPCModel model2 = (ExaminationPCModel)message.Message;

                    // 关闭VR考试系统
                    ExcuteRecycleCommand(model2);

                    break;
            }
        }

        #region 消息分发执行
        /// <summary>
        /// 开始考试
        /// </summary>
        /// <param name="model"></param>
        private void ExcuteStartExamCommand(ExaminationPCModel model)
        {
            // 1.将关键信息（类型、考试编号、考试科目编号、考生编号、考试状态存入VR考试系统配置文件中）

            // add by wuxin at 2018/10/14 - start
            string strType = model.Type;
            // add by wuxin at 2018/10/14 - end

            string strExaminationID = model.ExaminationID;
            string strExaminationSubjectIDs = model.ExaminationSubjectIDs;
            string strExamineeID = model.ExamineeID;
            EnumExamState enumExamState = model.ExamState;
            string strExaminationResultID = model.ExaminationResultID;

            List<XmlModel> xmlList = new List<XmlModel>();

            // add by wuxin at 2018/10/14 - start
            XmlModel xmlModel0 = new XmlModel();
            xmlModel0.ElementName = XmlModel.ElementName_Type;
            xmlModel0.InnerText = strType;
            // add by wuxin at 2018/10/14 - end

            XmlModel xmlModel1 = new XmlModel();
            xmlModel1.ElementName = XmlModel.ElementName_ExaminationID;
            xmlModel1.InnerText = strExaminationID;

            XmlModel xmlModel2 = new XmlModel();
            xmlModel2.ElementName = XmlModel.ElementName_ExaminationnSubjectID;
            xmlModel2.InnerText = strExaminationSubjectIDs;

            XmlModel xmlModel3 = new XmlModel();
            xmlModel3.ElementName = XmlModel.ElementName_ExamineeID;
            xmlModel3.InnerText = strExamineeID;

            XmlModel xmlModel4 = new XmlModel();
            xmlModel4.ElementName = XmlModel.ElementName_ExamState;
            xmlModel4.InnerText = enumExamState.ToString();

            XmlModel xmlModel5 = new XmlModel();
            xmlModel5.ElementName = XmlModel.ElementName_ExaminationResultID;
            xmlModel5.InnerText = strExaminationResultID;

            // add by wuxin at 2018/10/14 - start
            xmlList.Add(xmlModel0);
            // add by wuxin at 2018/10/14 - end

            xmlList.Add(xmlModel1);
            xmlList.Add(xmlModel2);
            xmlList.Add(xmlModel3);
            xmlList.Add(xmlModel4);
            xmlList.Add(xmlModel5);

            // add by wuxin at 2019/12/10 - start
            _UnityClientConfigFilePath = "";
            _UnityClientName = "";
            _UnityClientPath = "";

            // 一期
            if (strExaminationID == "1" || strExaminationID == "2")
            {
                _UnityClientConfigFilePath = Const.L1UnityClientConfigFilePath;
                _UnityClientName = Const.L1UnityClientName;
                _UnityClientPath = Const.L1UnityClientPath;
            }
            // 二期
            else if (strExaminationID == "3")
            {
                _UnityClientConfigFilePath = Const.L2UnityClientConfigFilePath;
                _UnityClientName = Const.L2UnityClientName;
                _UnityClientPath = Const.L2UnityClientPath;
            }


            ClientForm._UnityClientConfigFilePath = _UnityClientConfigFilePath;
            ClientForm._UnityClientName = _UnityClientName;
            ClientForm._UnityClientPath = _UnityClientPath;

            // add by wuxin at 2019/12/10 - end

            // upd by wuxin at 2019/12/10 - start
            XmlManager.IsUpdating = true;
            bool result = XmlManager.UpdateXml(_UnityClientConfigFilePath, xmlList);
            XmlManager.IsUpdating = true;

            if (result)
            {
                // 2.打开考试软件
                int count = LibUtilities.GetPidByProcessName(_UnityClientName);

                if (count == 0)
                {

                    // 创建进程
                    Process instanceProcess = Process.Start(_UnityClientPath);

                    HandleRunningInstance(instanceProcess);
                }
                else
                {
                    LibUtilities.KillProcess(_UnityClientName);

                    // 创建进程
                    Process instanceProcess = Process.Start(_UnityClientPath);

                    HandleRunningInstance(instanceProcess);
                }

                ClientForm.Form._StopWatchingUnityClientConfigChange = false;
            }
            else
            {
                MessageBox.Show("VR考试系统启动失败！请确认系统路径是否正确！\n_UnityClientConfigFilePath:" + _UnityClientConfigFilePath + ",\n_UnityClientName:" + _UnityClientName + ",\n_UnityClientPath:" + _UnityClientPath, "异常");
            }

            // upd by wuxin at 2019/12/10 - end
        }


        // 3.已经有了就把它激活，并将其窗口放置最前端
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, 1); // 调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle);// 将窗口放置最前端
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);


        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="model"></param>
        private void ExcuteRecycleCommand(ExaminationPCModel model)
        {
            // upd by wuxin at 2019/12/10 - start
            // 1.关闭VR考试系统进程
            LibUtilities.KillProcess(_UnityClientName);
            // upd by wuxin at 2019/12/10 - end

            // 2.重置VR考试系统配置文件

            // add by wuxin at 2018/10/14 - start
            string strType = model.Type;
            // add by wuxin at 2018/10/14 - end

            string strExaminationID = model.ExaminationID;
            string strExaminationSubjectIDs = model.ExaminationSubjectIDs;
            string strExamineeID = model.ExamineeID;
            EnumExamState enumExamState = model.ExamState;
            string strExaminationResultID = model.ExaminationResultID;

            List<XmlModel> xmlList = new List<XmlModel>();

            // add by wuxin at 2018/10/14 - start
            XmlModel xmlModel0 = new XmlModel();
            xmlModel0.ElementName = XmlModel.ElementName_Type;
            xmlModel0.InnerText = strType;
            // add by wuxin at 2018/10/14 - end

            XmlModel xmlModel1 = new XmlModel();
            xmlModel1.ElementName = XmlModel.ElementName_ExaminationID;
            xmlModel1.InnerText = strExaminationID;

            XmlModel xmlModel2 = new XmlModel();
            xmlModel2.ElementName = XmlModel.ElementName_ExaminationnSubjectID;
            xmlModel2.InnerText = strExaminationSubjectIDs;

            XmlModel xmlModel3 = new XmlModel();
            xmlModel3.ElementName = XmlModel.ElementName_ExamineeID;
            xmlModel3.InnerText = strExamineeID;

            XmlModel xmlModel4 = new XmlModel();
            xmlModel4.ElementName = XmlModel.ElementName_ExamState;
            xmlModel4.InnerText = enumExamState.ToString();

            XmlModel xmlModel5 = new XmlModel();
            xmlModel5.ElementName = XmlModel.ElementName_ExaminationResultID;
            xmlModel5.InnerText = strExaminationResultID;

            // add by wuxin at 2018/10/14 - start
            xmlList.Add(xmlModel0);
            // add by wuxin at 2018/10/14 - end

            xmlList.Add(xmlModel1);
            xmlList.Add(xmlModel2);
            xmlList.Add(xmlModel3);
            xmlList.Add(xmlModel4);
            xmlList.Add(xmlModel5);

            XmlManager.IsUpdating = true;
            // upd by wuxin at 2019/12/10 - start
            bool result = XmlManager.UpdateXml(_UnityClientConfigFilePath, xmlList);
            // upd by wuxin at 2019/12/10 - end
            XmlManager.IsUpdating = false;

            if (!result)
            {
                MessageBox.Show("VR考试系统配置文件写入异常！请确认配置文件路径是否正确！\n_UnityClientConfigFilePath:" + _UnityClientConfigFilePath + ",\n_UnityClientName:" + _UnityClientName + ",\n_UnityClientPath:" + _UnityClientPath + " ", "异常");
            }

            ClientForm.Form._StopWatchingUnityClientConfigChange = true;
        }

        #endregion
    }
}
