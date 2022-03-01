using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试机添加界面 : Form
    {
        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);
        [DllImport("IPHLPAPI.dll")]
        private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);

        ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();

        /// <summary>
        /// 当前逻辑
        /// </summary>
        private string _CurrentLogic = "";

        public 考试机添加界面()
        {
            InitializeComponent();
        }

        public 考试机添加界面(string todoLogic, ExaminationPCModel ePCModel)
        {
            InitializeComponent();

            if (todoLogic == "add")
            {
                this.Text = "考生机添加界面";
                this.btnAdd.Text = "添 加";
            }
            else if (todoLogic == "upd")
            {
                this.Text = "考生机修改界面";
                this.btnAdd.Text = "修 改";

                // 设置考生信息
                SetExaminationPCInfo(ePCModel);
            }

            _CurrentLogic = todoLogic;
        }

        /// <summary>
        /// 设置考生信息
        /// </summary>
        /// <param name="em"></param>
        private void SetExaminationPCInfo(ExaminationPCModel ePCModel)
        {
            this.txtName.Text = ePCModel.ExamPCName;
            this.txtIP.Text = ePCModel.IP;
            //this.txtPort.Text = ePCModel.Port;
            this.txtMac.Text = ePCModel.Mac;

            // add by wuxin at 2018/10/14 - start
            if (ePCModel.Type == Const.EXAMINATION_PC_TYPE_EXAM)
            {
                this.rdBtnExam.Checked = true;
            }
            else if (ePCModel.Type == Const.EXAMINATION_PC_TYPE_PRAC)
            {
                this.rdBtnPrac.Checked = true;
            }
            // add by wuxin at 2018/10/14 - end

            // 隐藏
            this.txtID.Text = ePCModel.ID;
        }

        /// <summary>
        /// 获取Mac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMac_Click(object sender, EventArgs e)
        {
            if (this.txtIP.Text.Trim() != "")
            {
                string mac = GetMacAddress(this.txtIP.Text.Trim());
                this.txtMac.Text = mac;
            }
            else
            {
                Alert.alert("IP为空！");
            }
        }

        /// <summary>
        /// 获取Mac地址
        /// </summary>
        /// <param name="hostip"></param>
        /// <returns></returns>
        private string GetMacAddress(string hostip)//获取远程IP（不能跨网段）的MAC地址
        {
            string Mac = "";
            try
            {
                Int32 ldest = inet_addr(hostip); //将IP地址从 点数格式转换成无符号长整型
                Int64 macinfo = new Int64();
                Int32 len = 6;
                SendARP(ldest, 0, ref macinfo, ref len);
                string TmpMac = Convert.ToString(macinfo, 16);//转换成16进制
                Mac = TmpMac.Substring(0, 2).ToUpper();
                for (int i = 2; i < TmpMac.Length; i = i + 2)
                {
                    Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
                }
            }
            catch (Exception ex)
            {
                Alert.errorMsg("获取远程主机的MAC错误，请输入正确的IP！ex:" + ex);
            }
            return Mac;
        }

        /// <summary>
        /// 查询前检查
        /// </summary>
        private bool CheckBeforeAdd()
        {
            bool checkResult = true;

            // 非空验证
            checkResult = Check.isEmpty(this.txtName, "Name");

            if (!checkResult) return checkResult;

            // 非空验证
            checkResult = Check.isEmpty(this.txtIP, "IP");

            if (!checkResult) return checkResult;

            //// 非空验证
            //checkResult = Check.isEmpty(this.txtPort, "Port");

            //if (!checkResult) return checkResult;

            // 非空验证
            checkResult = Check.isEmpty(this.txtMac, "Mac");

            if (!checkResult) return checkResult;

            return checkResult;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool checkResult = CheckBeforeAdd();

            if (checkResult)
            {
                // 执行添加操作
                if (_CurrentLogic == "add")
                {
                    string Name = this.txtName.Text.Trim();
                    string IP = this.txtIP.Text.Trim();
                    //string Port = this.txtPort.Text.Trim();
                    string Mac = this.txtMac.Text.Trim();

                    // add by wuxin at 2018/10/14 - start
                    String type = "";

                    if (this.rdBtnExam.Checked)
                    {
                        type = "1";
                    }
                    else if (this.rdBtnPrac.Checked)
                    {
                        type = "0";
                    }
                    // add by wuxin at 2018/10/14 - end

                    ExaminationPCModel ePCModel = new ExaminationPCModel();
                    ePCModel.ExamPCName = Name;
                    ePCModel.IP = IP;
                    //ePCModel.Port = Port;
                    ePCModel.Mac = Mac;

                    // add by wuxin at 2018/10/14 - start
                    ePCModel.Type = type;
                    // add by wuxin at 2018/10/14 - end

                    int count = _ExaminationPCBLL.AddExaminationPCInfo(ePCModel);

                    if (count > 0)
                    {
                        Alert.noteMsg("添加成功！");

                        考试机配置 parentForm = (考试机配置)this.Owner;

                        parentForm.ChildFormClose();

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("添加失败！");
                    }

                }
                // 执行修改操作
                else if (_CurrentLogic == "upd")
                {
                    ExaminationPCModel ePCModel = new ExaminationPCModel();
                    ePCModel.IP = this.txtIP.Text.Trim();
                    ePCModel.ExamPCName = this.txtName.Text.Trim();
                    //ePCModel.Port = this.txtPort.Text.Trim();
                    ePCModel.Mac = this.txtMac.Text.Trim();

                    // add by wuxin at 2018/10/14 - start
                    String type = "";

                    if (this.rdBtnExam.Checked)
                    {
                        type = "1";
                    }
                    else if (this.rdBtnPrac.Checked)
                    {
                        type = "0";
                    }

                    ePCModel.Type = type;

                    // add by wuxin at 2018/10/14 - end

                    ePCModel.ID = this.txtID.Text.Trim();

                    int count = _ExaminationPCBLL.UpdExaminationPCInfo(ePCModel);

                    if (count > 0)
                    {
                        Alert.noteMsg("修改成功！");

                        考试机配置 parentForm = (考试机配置)this.Owner;

                        parentForm.ChildFormClose();

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("修改失败！");
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void txtIP_TextChanged(object sender, EventArgs e)
        //{
        //    Check.CheckSpecialCharacters(this.txtIP, "IP");
        //}

        //private void txtPort_TextChanged(object sender, EventArgs e)
        //{
        //    Check.CheckSpecialCharacters(this.txtPort, "Port");
        //}

        //private void txtMac_TextChanged(object sender, EventArgs e)
        //{
        //    Check.CheckSpecialCharacters(this.txtMac, "Mac");
        //}
    }
}
