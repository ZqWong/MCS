using Common;
using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MCS
{
    public partial class 回收分配界面 : Form
    {
        // del by wuxin at 2018/6/2 - start
        //private string _ReadID = "";
        //Thread _ThreadForWatchingIDReader;
        // del by wuxin at 2018/6/2 - end

        ExamineeBLL _ExamineeBLL = new ExamineeBLL();
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();
        ExaminationResultBLL _ExaminationResultBLL = new ExaminationResultBLL();
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        ExaminationPCModel _ExaminationPCModel = new ExaminationPCModel();


        // 是否已经回收
        private bool _IsAlreadyRecycled = false;
        // 是否需要回收
        private bool _IsNeedRecycle = false;

        string _AppStartPath = Application.StartupPath; // 获取相对路径

        // add by wuxin at 2018/6/2 - start
        private Thread _WatchingReadingCardThread = null;
        // add by wuxin at 2018/6/2 - end

        public 回收分配界面()
        {
            // 表示不对错误线程的调用进行捕获
            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            // del by wuxin at 2018/6/2 - start
            //if (this.cbReadCard.Checked)
            //{
            //    _ThreadForWatchingIDReader = new Thread(new ThreadStart(WatchingIDReader));
            //    _ThreadForWatchingIDReader.IsBackground = true;
            //    _ThreadForWatchingIDReader.Start();
            //}
            //else
            //{
            //    if (_ThreadForWatchingIDReader != null)
            //    {
            //        _ThreadForWatchingIDReader.Abort();
            //    }
            //}
            // del by wuxin at 2018/6/2 - end

            // 加载考试信息
            LoadExaminationInfo();

            // add by wuxin at 2018/6/2 - start
            // 身份证阅读器相关
            // 初始化端口
            bool result = IDCardReader.InitializePort();

            // 初始化成功
            if (result)
            {
                _WatchingReadingCardThread = new Thread(new ThreadStart(ReadingCard));
                _WatchingReadingCardThread.IsBackground = true;
                _WatchingReadingCardThread.Name = "_WatchingReadingCardThread";
                _WatchingReadingCardThread.Start();

                LogHelper.WriteLog("服务器线程开启：监视身份证阅读器线程已开启。");
            }
            else
            {
                Alert.errorMsg("身份证阅读器初始化失败！");

                LogHelper.WriteErrorLog("身份证阅读器初始化失败！");
            }
            // add by wuxin at 2018/6/2 - end
        }

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 读卡中……
        /// </summary>
        public void ReadingCard()
        {
            while (true)
            {
                // 读卡中
                ExamineeModel em = IDCardReader.ReadingCard();

                if (em != null)
                {
                    //// 姓名
                    //this.txtExamineeName.Text = em.ExamineeName;
                    //// 身份证号码
                    //this.txtIDCardNum.Text = em.IDCardNum;

                    // 根据身份证号获取学生信息
                    DataSet ds = _ExamineeBLL.GetExamineeInfoByIDCardNum(em.IDCardNum);

                    int count = ds.Tables[0].Rows.Count;

                    if (count > 0)
                    {
                        // 考生编号
                        this.txtExamineeID.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeID].ToString();
                        // 考生姓名
                        this.txtExamineeName.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeName].ToString();
                        // 身份证号
                        this.txtIDCardNum.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_IDCardNum].ToString();
                        // 所属公司
                        this.txtExamineeCompanyName.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();
                    }
                    else
                    {
                        Alert.alert("数据库中不存在该考生信息，请先将该考生信息添加到数据库中。");
                    }

                    Thread.Sleep(500);
                }
            }
        }
        // add by wuxin at 2018/6/2 - end



        public 回收分配界面(ExaminationPCModel model)
        {
            _ExaminationPCModel = model;

            // 表示不对错误线程的调用进行捕获
            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            // del by wuxin at 2018/6/2 - start
            //if (this.cbReadCard.Checked)
            //{
            //    _ThreadForWatchingIDReader = new Thread(new ThreadStart(WatchingIDReader));
            //    _ThreadForWatchingIDReader.IsBackground = true;
            //    _ThreadForWatchingIDReader.Start();
            //}
            //else
            //{
            //    if (_ThreadForWatchingIDReader != null)
            //    {
            //        _ThreadForWatchingIDReader.Abort();
            //    }
            //}
            // del by wuxin at 2018/6/2 - end

            // 加载考试信息
            LoadExaminationInfo();

            // 设置窗体信息
            SetFormInfo(model);

            // add by wuxin at 2018/6/2 - start
            // 身份证阅读器相关
            // 初始化端口
            bool result = IDCardReader.InitializePort();

            // 初始化成功
            if (result)
            {
                _WatchingReadingCardThread = new Thread(new ThreadStart(ReadingCard));
                _WatchingReadingCardThread.IsBackground = true;
                _WatchingReadingCardThread.Name = "_WatchingReadingCardThread";
                _WatchingReadingCardThread.Start();

                LogHelper.WriteLog("服务器线程开启：监视身份证阅读器线程已开启。");
            }
            else
            {
                Alert.errorMsg("身份证阅读器初始化失败！");

                LogHelper.WriteErrorLog("身份证阅读器初始化失败！");
            }
            // add by wuxin at 2018/6/2 - end

        }

        private string _ExaminationPCType;

        /// <summary>
        /// 设置窗体信息
        /// </summary>
        /// <param name="model"></param>
        private void SetFormInfo(ExaminationPCModel model)
        {
            _ExaminationPCType = model.Type;

            // add by wuxin at 2018/10/14 - start
            if (_ExaminationPCType == "1")
            {
                this.lblExamOrPrac.Text = "考试";
            }
            else if (_ExaminationPCType == "0")
            {
                this.lblExamOrPrac.Text = "练习";
            }
            // add by wuxin at 2018/10/14 - end

            // 无考试信息
            if (string.IsNullOrEmpty(model.ExaminationID))
            {
                // del by wuxin at 2018/6/2 - start
                //this.cbReadCard.Enabled = true;
                // del by wuxin at 2018/6/2 - end

                this.btnChoiceExaminee.Enabled = true;

                this.cbExaminationName.Enabled = true;

                // 失效：回收按钮
                this.btnRecycleExam.Enabled = false;

                // add by wuxin at 2018/10/14 - start
                // 失效：重考按钮
                this.btnReExam.Enabled = false;
                // add by wuxin at 2018/10/14 - end

                // 生效：分配按钮
                this.btnAllotExam.Enabled = true;

                _IsNeedRecycle = false;
            }
            else
            {
                // del by wuxin at 2018/6/2 - start
                //this.cbReadCard.Enabled = false;
                // del by wuxin at 2018/6/2 - start

                this.cbExaminationName.Enabled = false;

                this.btnChoiceExaminee.Enabled = false;

                // 生效 ：回收按钮
                this.btnRecycleExam.Enabled = true;

                // add by wuxin at 2018/10/14 - start
                // 失效：重考按钮
                this.btnReExam.Enabled = true;
                // add by wuxin at 2018/10/14 - end

                // 生效：分配按钮
                this.btnAllotExam.Enabled = false;

                _IsNeedRecycle = true;

                // 考生姓名
                string examineeID = model.ExamineeID;

                DataSet dsExaminee = _ExamineeBLL.GetExamineeInfoByExamineeID(examineeID);

                if (dsExaminee.Tables[0].Rows.Count > 0)
                {
                    // 考生编号
                    this.txtExamineeID.Text = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeID].ToString();
                    // 考生姓名
                    this.txtExamineeName.Text = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeName].ToString();
                    // add by wuxin at 2018/3/2 - start
                    // 身份证号
                    this.txtIDCardNum.Text = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_IDCardNum].ToString();
                    // add by wuxin at 2018/3/2 - end
                    // 所属公司
                    this.txtExamineeCompanyName.Text = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();
                }

                // 考试内容
                string examinationID = model.ExaminationID;

                this.cbExaminationName.SelectedValue = examinationID;
            }

            // 考试状态
            EnumExamState enumExamState = model.ExamState;

            // 无
            if (enumExamState == EnumExamState.Empty)
            {
                this.imgExamState.Image = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
            }
            // 未开始
            else if (enumExamState == EnumExamState.NoStart)
            {
                this.imgExamState.Image = Image.FromFile(_AppStartPath + Const.ExamState_NoStart_PicRPath);
            }
            // 已开始
            else if (enumExamState == EnumExamState.Start)
            {
                this.imgExamState.Image = Image.FromFile(_AppStartPath + Const.ExamState_Start_PicRPath);
            }
            // 已结束
            else if (enumExamState == EnumExamState.Over)
            {
                this.imgExamState.Image = Image.FromFile(_AppStartPath + Const.ExamState_Over_PicRPath);
            }

            // 考试机名称
            this.txtExamPCName.Text = model.ExamPCName;

            // 考试机状态
            EnumExamPCState enumExamPCState = model.ExamPCState;

            if (enumExamPCState == EnumExamPCState.Idle)
            {
                this.txtExamPCState.Text = "空闲";
                this.txtExamPCState.ForeColor = Color.Green;
            }
            else if (enumExamPCState == EnumExamPCState.Busy)
            {
                this.txtExamPCState.Text = "占用";
                this.txtExamPCState.ForeColor = Color.Red;
            }
        }

        // del by wuxin at 2018/6/2 - start
        //private void WatchingIDReader()
        //{
        //    while (true)
        //    {
        //        if (!_IsNeedRecycle || (_IsNeedRecycle && _IsAlreadyRecycled))
        //        {
        //            if (this.cbReadCard.Checked)
        //            {
        //                string[] message = ICCardWriterAndReader.Read();

        //                if (message != null)
        //                {
        //                    string id = message[0].Replace("F", string.Empty);

        //                    if (_ReadID != id)
        //                    {
        //                        _ReadID = id;
        //                        //MessageBox.Show(message[0] + "," + message[1]);
        //                        //MessageBox.Show("[" + _ReadID + "]");

        //                        DataSet ds = _ExamineeBLL.GetExamineeInfoByExamineeID(_ReadID);

        //                        int count = ds.Tables[0].Rows.Count;

        //                        if (count > 0)
        //                        {
        //                            // 考生编号
        //                            this.txtExamineeID.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeID].ToString();
        //                            // 考生姓名
        //                            this.txtExamineeName.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeName].ToString();
        //                            // 所属公司
        //                            this.txtExamineeCompanyName.Text = ds.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        // del by wuxin at 2018/6/2 - end

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // del by wuxin at 2018/6/2 - start
            //if (_ThreadForWatchingIDReader != null)
            //{
            //    try
            //    {
            //        _ThreadForWatchingIDReader.Abort();
            //    }
            //    catch
            //    {

            //    }

            //}
            // del by wuxin at 2018/6/2 - end

            this.Close();
        }

        private void 回收分配界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            // del by wuxin at 2018/6/2 - start
            //if (_ThreadForWatchingIDReader != null)
            //{
            //    try
            //    {
            //        _ThreadForWatchingIDReader.Abort();
            //    }
            //    catch
            //    {

            //    }

            //}

            // add by wuxin at 2018/6/2 - start
            if (_WatchingReadingCardThread != null)
            {
                _WatchingReadingCardThread.Abort();

                LogHelper.WriteLog("服务器线程关闭：监视身份证阅读器线程已关闭。");
            }

            // 关闭端口
            IDCardReader.ClosePort();
            // add by wuxin at 2018/6/2 - end
        }

        /// <summary>
        /// 加载考试信息
        /// </summary>
        private void LoadExaminationInfo()
        {
            DataSet ds = _ExaminationBLL.GetAllExaminationInfo();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                //this.cbExaminationInfo.DataSource = ds.Tables[0];
                //this.cbExaminationInfo.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                //this.cbExaminationInfo.ValueMember = ExaminationModel.ColumnName_ExaminationID;

                ArrayList list = new ArrayList();

                ExaminationModel defaultEm = new ExaminationModel();
                defaultEm.ExaminationID = "-1";
                defaultEm.ExaminationName = "请选择！";

                list.Add(defaultEm);

                for (int i = 0; i < count; i++)
                {
                    string examinationID = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationID].ToString();
                    string examinationName = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationName].ToString();

                    ExaminationModel em = new ExaminationModel();
                    em.ExaminationID = examinationID;
                    em.ExaminationName = examinationName;

                    list.Add(em);
                }

                this.cbExaminationName.DataSource = list;
                this.cbExaminationName.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                this.cbExaminationName.ValueMember = ExaminationModel.ColumnName_ExaminationID;
            }
        }

        /// <summary>
        /// 分配考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllotExam_Click(object sender, EventArgs e)
        {
            if (_IsNeedRecycle)
            {
                if (_IsAlreadyRecycled)
                {
                    AllotExam();
                }
                else
                {
                    Alert.alert("请先回收考试机！");
                }
            }
            else
            {
                AllotExam();
            }
        }

        /// <summary>
        /// 分配考试
        /// </summary>
        private void AllotExam()
        {
            // 考试专用
            if (_ExaminationPCType == "1")
            {
                if (string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()))
                {
                    Alert.alert("请刷卡或手动选择考生！");
                    return;
                }

                if (this.cbExaminationName.Text == "请选择！")
                {
                    Alert.alert("请选择考试内容！");
                    return;
                }

                // 考生ID（添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExamineeID = this.txtExamineeID.Text;

                // 考试ID（添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExaminationID = this.cbExaminationName.SelectedValue.ToString();

                // 考试科目ID集合（添加到DB，需要发送给客户端）
                string strExaminationSubjectIDs = _ExaminationResultBLL.GetExaminationSubjectIDs(_ExaminationPCModel.ExaminationID);

                // 无法组成试卷的情况
                if (strExaminationSubjectIDs == null)
                {
                    Alert.errorMsg("随机科目数不足，组卷失败！");
                    return;
                }

                _ExaminationPCModel.ExaminationSubjectIDs = strExaminationSubjectIDs;

                // del by wuxin at 2018/5/30 - start
                //// 考试结果编号（不添加到DB，需要发送给客户端）
                //int newExaminationResultID = _ExaminationResultBLL.GetNewExaminationResultID();
                //_ExaminationPCModel.ExaminationResultID = newExaminationResultID.ToString();
                // del by wuxin at 2018/5/30 - end

                // 考试状态（不添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExamState = EnumExamState.NoStart;

                ExaminationResultModel model = new ExaminationResultModel();
                model.ExamineeID = _ExaminationPCModel.ExamineeID;
                model.ExaminationID = _ExaminationPCModel.ExaminationID;
                model.ExaminationSubjectIDs = _ExaminationPCModel.ExaminationSubjectIDs;
                model.ExaminationDate = DateTime.Now.ToString(Const.DATE_FORMART_YYYY_MM_DD);

                int count = _ExaminationResultBLL.AddExaminationResultInfo(model);

                // 添加DB成功
                if (count > 0)
                {
                    // add by wuxin at 2018/5/30 - start
                    // 考试结果编号（不添加到DB，需要发送给客户端）
                    int newExaminationResultID = _ExaminationResultBLL.GetLastExaminationResultID();
                    _ExaminationPCModel.ExaminationResultID = newExaminationResultID.ToString();
                    // add by wuxin at 2018/5/30 - end

                    string clientIPAddress = GlobalClass.Instance.GetClientIPAddressByIP(_ExaminationPCModel.IP);

                    // ------------------------------------------------------------
                    ByteArray ba = new ByteArray();

                    ba.write((byte)Protocol.Type.EXAM); // 必须进行转化否则出错，正常是不应该的
                    ba.write(0);
                    ba.write((int)Protocol.Command.StartExam);

                    object message = _ExaminationPCModel;

                    // 判断消息体是否为空  不为空则序列化后写入
                    if (message != null)
                    {
                        ba.write(SerializeAndDeserializeTool.Serialize((object)message));
                    }

                    // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
                    ByteArray resultByteArray = new ByteArray();
                    resultByteArray.write(ba.Length);
                    resultByteArray.write(ba.GetBuffer());

                    try
                    {
                        // 发客户端发送信息
                        GlobalClass.Instance._ClientDic[clientIPAddress].Send(resultByteArray.GetBuffer());
                    }
                    catch (Exception e)
                    {
                        Alert.errorMsg("分配考试机失败！请检查以下内容：\n" + "1、检查网络状况。\n" + "2、检查C#Client软件是否启动，如未启动，请手动启动。\n" + "3、联系软件提供商。\n" + "Exception信息：" + e);
                        return;
                    }

                    Alert.noteMsg("分配成功！请通知考生到" + _ExaminationPCModel.ExamPCName + "开始考试！");

                    主界面 form = (主界面)this.Owner;
                    form.ChildFormClose(_ExaminationPCModel);

                    this.Close();

                    // ------------------------------------------------------------
                }
            }
            // add by wuxin at 2018/10/14 - start
            // 练习专用
            else if (_ExaminationPCType == "0")
            {
                if (string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()))
                {
                    Alert.alert("请刷卡或手动选择考生！");
                    return;
                }

                if (this.cbExaminationName.Text == "请选择！")
                {
                    Alert.alert("请选择考试内容！");
                    return;
                }

                // 考生ID（添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExamineeID = this.txtExamineeID.Text;

                // 考试ID（添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExaminationID = this.cbExaminationName.SelectedValue.ToString();

                // 考试科目ID集合（添加到DB，需要发送给客户端）
                string strExaminationSubjectIDs = _ExaminationResultBLL.GetExaminationSubjectIDs(_ExaminationPCModel.ExaminationID);

                // 无法组成试卷的情况
                if (strExaminationSubjectIDs == null)
                {
                    Alert.errorMsg("随机科目数不足，组卷失败！");
                    return;
                }
                _ExaminationPCModel.ExaminationSubjectIDs = strExaminationSubjectIDs;

                // del by wuxin at 2018/5/30 - start
                //// 考试结果编号（不添加到DB，需要发送给客户端）
                //int newExaminationResultID = _ExaminationResultBLL.GetNewExaminationResultID();
                //_ExaminationPCModel.ExaminationResultID = newExaminationResultID.ToString();
                // del by wuxin at 2018/5/30 - end

                // 考试状态（不添加到DB，需要发送给客户端）
                _ExaminationPCModel.ExamState = EnumExamState.NoStart;

                string clientIPAddress = GlobalClass.Instance.GetClientIPAddressByIP(_ExaminationPCModel.IP);

                // ------------------------------------------------------------
                ByteArray ba = new ByteArray();

                ba.write((byte)Protocol.Type.EXAM); // 必须进行转化否则出错，正常是不应该的
                ba.write(0);
                ba.write((int)Protocol.Command.StartExam);

                object message = _ExaminationPCModel;

                // 判断消息体是否为空  不为空则序列化后写入
                if (message != null)
                {
                    ba.write(SerializeAndDeserializeTool.Serialize((object)message));
                }

                // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
                ByteArray resultByteArray = new ByteArray();
                resultByteArray.write(ba.Length);
                resultByteArray.write(ba.GetBuffer());

                try
                {
                    // 发客户端发送信息
                    GlobalClass.Instance._ClientDic[clientIPAddress].Send(resultByteArray.GetBuffer());
                }
                catch (Exception e)
                {
                    Alert.errorMsg("分配考试机失败，请检查以下内容：\n" + "1、检查网络状况。\n" + "2、检查C#Client软件是否启动，如未启动，请手动启动。\n" + "3、联系软件提供商。\n" + "Exception信息：" + e);
                    return;
                }

                Alert.noteMsg("分配成功！请通知考生到" + _ExaminationPCModel.ExamPCName + "开始练习！");

                主界面 form = (主界面)this.Owner;
                form.ChildFormClose(_ExaminationPCModel);

                this.Close();

            }
            // add by wuxin at 2018/10/14 - end

        }

        /// <summary>
        /// 回收考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecycleExam_Click(object sender, EventArgs e)
        {
            // del by wuxin at 2018/6/2 - start
            //_ReadID = "";
            // del by wuxin at 2018/6/2 - end

            //ExaminationPCModel model = new ExaminationPCModel();

            _ExaminationPCModel.ExaminationID = "";
            _ExaminationPCModel.ExamineeID = "";
            _ExaminationPCModel.ExaminationSubjectIDs = "";
            _ExaminationPCModel.ExamState = EnumExamState.Empty;
            _ExaminationPCModel.ExaminationResultID = "";

            string clientIPAddress = GlobalClass.Instance.GetClientIPAddressByIP(_ExaminationPCModel.IP);
            // ------------------------------------------------------------
            ByteArray ba = new ByteArray();

            ba.write((byte)Protocol.Type.EXAM); // 必须进行转化否则出错，正常是不应该的
            ba.write(0);
            ba.write((int)Protocol.Command.Recycle);

            object message = _ExaminationPCModel;

            // 判断消息体是否为空  不为空则序列化后写入
            if (message != null)
            {
                ba.write(SerializeAndDeserializeTool.Serialize((object)message));
            }

            // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
            ByteArray resultByteArray = new ByteArray();
            resultByteArray.write(ba.Length);
            resultByteArray.write(ba.GetBuffer());

            try
            {
                // 发客户端发送信息
                GlobalClass.Instance._ClientDic[clientIPAddress].Send(resultByteArray.GetBuffer());
            }
            catch (Exception ex)
            {
                Alert.errorMsg("回收考试机失败，请检查以下内容：\n" + "1、检查网络状况。\n" + "2、检查C#Client软件是否启动，如未启动，请手动启动。\n" + "3、联系软件提供商。\n" + "Exception信息：" + ex);
                return;
            }

            _IsAlreadyRecycled = true;

            // 按钮生效/失效
            this.btnRecycleExam.Enabled = false;

            // add by wuxin at 2018/10/14 - start
            this.btnReExam.Enabled = false;
            // add by wuxin at 2018/10/14 - end

            this.btnAllotExam.Enabled = true;

            // del by wuxin at 2018/6/2 - start
            //this.cbReadCard.Enabled = true;
            // del by wuxin at 2018/6/2 - end

            this.btnChoiceExaminee.Enabled = true;
            this.cbExaminationName.Enabled = true;

            // 清空
            this.txtExamineeID.Text = "";
            this.txtExamineeName.Text = "";
            // add by wuxin at 2018/6/2 - start
            this.txtIDCardNum.Text = "";
            // add by wuxin at 2018/6/2 - end
            this.txtExamineeCompanyName.Text = "";
            this.cbExaminationName.SelectedIndex = 0;

            // add by wuxin at 2020/1/8 - start
            this.txtClassType.Text = "";
            // add by wuxin at 2020/1/8 - end

            // del by wuxin at 2018/10/14 - start
            //// 失效：回收按钮
            //this.btnRecycleExam.Enabled = false;
            //// 生效：分配按钮
            //this.btnAllotExam.Enabled = true;
            // del by wuxin at 2018/10/14 - end

            // 考试状态
            this.imgExamState.Image = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);

            // 考试机状态
            this.txtExamPCState.Text = "空闲";
            this.txtExamPCState.ForeColor = Color.Green;

            Alert.noteMsg("回收成功！");

            主界面 form = (主界面)this.Owner;
            form.ChildFormClose(_ExaminationPCModel);

            //this.Close();
        }

        // add by wuxin at 2018/6/5 - start
        /// <summary>
        /// 选择考生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoiceExaminee_Click(object sender, EventArgs e)
        {
            选择考生界面 form = new 选择考生界面();
            form.ShowDialog(this);
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        public void ChildFormClose(ExamineeModel em)
        {
            this.txtExamineeID.Text = em.ExamineeID;
            this.txtExamineeName.Text = em.ExamineeName;
            this.txtIDCardNum.Text = em.IDCardNum;
            this.txtExamineeCompanyName.Text = em.ExamineeCompanyName;
            // add by wuxin at 2020/1/8 - start
            this.txtClassType.Text = em.ClassType;
            // add by wuxin at 2020/1/8 - end
        }

        // add by wuxin at 2018/10/14 - start
        /// <summary>
        /// 重考
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReExam_Click(object sender, EventArgs e)
        {
            if (Alert.confirm("是否确认重新考试？"))
            {
                // 1、删除ExaminationResultID
                int result = _ExaminationResultBLL.DelExaminationResultInfo(_ExaminationPCModel.ExaminationResultID);

                if (result == 1)
                {
                    // 2、分配考试按钮可用
                    this.btnAllotExam.Enabled = true;

                    this.btnRecycleExam.Enabled = false;

                    this.btnReExam.Enabled = false;

                    this.btnChoiceExaminee.Enabled = true;

                    this.cbExaminationName.Enabled = true;

                    _IsAlreadyRecycled = true;

                    Alert.noteMsg("请重新分配考试！");

                }
                else
                {
                    Alert.errorMsg("重考失败！请联系管理员处理。");
                }
            }
        }
        // add by wuxin at 2018/10/14 - end

        // add by wuxin at 2018/6/5 - end
    }
}
