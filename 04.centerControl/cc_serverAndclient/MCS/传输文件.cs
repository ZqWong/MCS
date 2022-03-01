using Common;
using MCS.Common;
using ServerFrame;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Common.Model;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MCS.DB.BLL;
using UserEventData;

namespace MCS
{
    public partial class 传输文件 : Form
    {
        private static readonly object syslock = new object();

        private static 传输文件 _instance;
        private static SynchronizationContext _uiContext;

        private TreeNode currentNode;

        private string mCurrentDirectory = "";
        private string mBrowserClientIP = "";
        List<string> checkList = new List<string>();
        List<string> checkAndConnectList = new List<string>();

        public static 传输文件 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new 传输文件();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return _uiContext;
        }


        ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();

        List<string> mListFilePaths = new List<string>();
        List<string> mListFolderPaths = new List<string>();

        string mSaveFolder;

        ProgressControls _ProgressControl = new ProgressControls();

        SynchronizationContext uiContext = SynchronizationContext.Current;

        public 传输文件()
        {
            _uiContext = SynchronizationContext.Current;
            InitializeComponent();

            //load_directory();
        }


        /// <summary>
        /// 文件在列表中是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool FileExists(string filePath)
        {
            int n = mListFilePaths.Count;
            for (int i = 0; i < n; i++)
            {
                if (mListFilePaths[i].Equals(filePath))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 文件夹在列表中是否存在
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        private bool FolderExists(string folderPath)
        {
            int n = mListFolderPaths.Count;
            for (int i = 0; i < n; i++)
            {
                if (mListFolderPaths[i].Equals(folderPath))
                {
                    return true;
                }
            }

            return false;
        }

        private delegate void EnableContextMenuButtonDelegate(bool enable);

        private void EnableContextMenuButton(bool enable)
        {
            if (this.mContextMenu.InvokeRequired)
            {
                EnableContextMenuButtonDelegate delegateFun = new EnableContextMenuButtonDelegate(EnableContextMenuButton);
                this.mContextMenu.Invoke(delegateFun, enable);
            }
            else
            {
                this.mContextMenu.Enabled = enable;
            }
        }


        // 发送文件的时候禁用其他线程中对socket(?)进行读写操作_socketServerTool.EnableDetectionPackage(false);
        private void btnSend_Click(object sender, EventArgs e)
        {
            dataGridView_clientList.EndEdit();

            // 清空进度列表
            int row = dataGridView_clientList.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                dataGridView_clientList.Rows[i].Cells["progress"].Value = "";
            }


            this.Cursor = Cursors.WaitCursor;
            Thread fileSenderThread = new Thread(new ThreadStart(StartSendFileThread));
            fileSenderThread.Name = "FileSenderThread";
            fileSenderThread.IsBackground = true;
            fileSenderThread.Start();
        }

        long _TotalFileLen = 0;

        private void StartSendFileThread()
        {
            try
            {
                EnableContextMenuButton(false);

                //获取所有文件（夹）的大小
                _ProgressControl._LblCur = this.lblProgressCur;
                //_ProgressControl._LblTitle = this.lblProgressTitle;

                // 所有文件的长度，用于计算总进度条
                _ProgressControl._TotalFileLen = GetAllFileLength();
                _TotalFileLen = GetAllFileLength();

                // 进度条控件
                _ProgressControl._TotoalProBar = this.progressBarTotal;
                // 当前发送的长度
                _ProgressControl._CurSentLen = 0;

                SetProgressbarValue(1, 100, "文件开始传输...");
                ShowProgressControls(true);

                // 用户选取了源文件并且指定了目标机器存储的路径
                if ((mListFilePaths.Count > 0 || mListFolderPaths.Count > 0) && mSaveFolder != "")
                {
                    bool result = true;

                    if (mListFilePaths.Count > 0)
                    {
                        //result = result & SendFiles2AllClients(mListFilePaths.ToArray(), mSaveFolder);

                        foreach (string filePath in mListFilePaths)
                        {

                            SendFile(filePath, mSaveFolder);
                        }

                    }

                    if (mListFolderPaths.Count > 0) //发送文件夹
                    {
                        List<string> fileList = new List<string>();

                        foreach (string folderPath in mListFolderPaths)
                        {
                            fileList.Clear();
                            GetAllFiles(fileList, new System.IO.DirectoryInfo(folderPath));
                            foreach (string filePath in fileList)
                            {

                                string relative_path = filePath.Substring(folderPath.LastIndexOf(@"\"),
                                    filePath.LastIndexOf(@"\") - folderPath.LastIndexOf(@"\"));

                                SendFile(filePath, mSaveFolder + relative_path);
                            }
                        }
                    }

                    SetProgressbarValue(100, 100, "发送完毕!");

                    SetFormCursor(Cursors.Arrow);

                    if (result)
                    {
                        // MessageBox.Show("发送成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("发送失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    ShowProgressControls(false);
                }

                EnableContextMenuButton(true);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有文件的长度
        /// </summary>
        /// <returns></returns>
        private long GetAllFileLength()
        {
            long retLen = 0;
            // 文件
            int nFiles = mListFilePaths.Count;
            for (int i = 0; i < nFiles; i++)
            {
                FileInfo fileInfo = new FileInfo(mListFilePaths[i]);
                retLen += fileInfo.Length;
            }

            // 文件夹
            int nFolders = mListFolderPaths.Count;
            for (int i = 0; i < nFolders; i++)
            {
                DirectoryInfo rootDirInfo = new DirectoryInfo(mListFolderPaths[i]);
                DirectoryInfo[] subDirInfos = rootDirInfo.GetDirectories();
                GetFilesLenInFolderRescusively(subDirInfos, rootDirInfo.GetFiles(), ref retLen);
            }

            return retLen;
        }

        public void GetFilesLenInFolderRescusively(DirectoryInfo[] dirs, FileInfo[] fileInfos, ref long retLen)
        {
            #region //文件

            int nFiles = fileInfos.Length;
            for (int i = 0; i < nFiles; i++)
            {
                retLen += fileInfos[i].Length;
            }

            #endregion

            #region //文件夹

            int nFolders = dirs.Length;
            for (int i = 0; i < nFolders; i++)
            {
                DirectoryInfo[] subDirs = dirs[i].GetDirectories();
                FileInfo[] subFileInfos = dirs[i].GetFiles();
                GetFilesLenInFolderRescusively(subDirs, subFileInfos, ref retLen);
            }

            #endregion
        }

        private delegate void SetProgressbarValueDelegate(int curValue, int maxValue, string strCurTxt);

        private void SetProgressbarValue(int curValue, int maxValue, string strCurTxt)
        {
            if (this.lblProgressCur.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetProgressbarValueDelegate delegateProgress = new SetProgressbarValueDelegate(SetProgressbarValue);
                this.lblProgressCur.Invoke(delegateProgress, curValue, maxValue, strCurTxt);
            }
            else
            {
                this.lblProgressCur.Text = strCurTxt;
            }

            if (this.lblProgressCur.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetProgressbarValueDelegate delegateProgress = new SetProgressbarValueDelegate(SetProgressbarValue);
                this.lblProgressCur.Invoke(delegateProgress, curValue, maxValue, strCurTxt);
            }
            else
            {
                this.progressBarTotal.Maximum = maxValue;
                this.progressBarTotal.Value = curValue;
            }
        }

        private delegate void ShowProgressControlsDelegate(bool show);

        private void ShowProgressControls(bool show)
        {
            if (this.lblProgressCur.InvokeRequired)
            {
                ShowProgressControlsDelegate delegateShow = new ShowProgressControlsDelegate(ShowProgressControls);
                this.lblProgressCur.Invoke(delegateShow, show);
            }
            else
            {
                this.lblProgressCur.Visible = show;
            }

            if (this.lblProgressCur.InvokeRequired)
            {
                ShowProgressControlsDelegate delegateShow = new ShowProgressControlsDelegate(ShowProgressControls);
                //this.lblProgressTitle.Invoke(delegateShow, show);
            }
            else
            {
                //this.lblProgressTitle.Visible = show;
            }

            if (this.progressBarTotal.InvokeRequired)
            {
                ShowProgressControlsDelegate delegateShow = new ShowProgressControlsDelegate(ShowProgressControls);
                this.progressBarTotal.Invoke(delegateShow, show);
            }
            else
            {
                this.progressBarTotal.Visible = show;
            }
        }

        private delegate void SetFormCursorDelegate(Cursor cursor);

        private void SetFormCursor(Cursor cursor)
        {
            if (this.InvokeRequired)
            {
                SetFormCursorDelegate delegateFun = new SetFormCursorDelegate(SetFormCursor);
                this.Invoke(delegateFun, cursor);
            }
            else
            {
                this.Cursor = cursor;
            }
        }



        private delegate void SetProgressbarValueDelegateWithProgress(ProgressControls proControl);

        private void SetProgressbarValue(ProgressControls proControl)
        {
            //if (proControl._LblTitle.InvokeRequired)
            //{
            //    SetProgressbarValueDelegateWithProgress delegateProgress =
            //        new SetProgressbarValueDelegateWithProgress(SetProgressbarValue);
            //    proControl._LblTitle.Invoke(delegateProgress, proControl);
            //}
            //else
            //{
            //    proControl._LblTitle.Text = proControl._strTitle + "      已发送 " +
            //                                (proControl._CurSentLen / proControl._ClientsNum / 1024 / 1024).ToString() + " 兆 / 共 " +
            //                                (proControl._TotalFileLen / 1024 / 1024).ToString() + " 兆";
            //}

            if (proControl._LblCur.InvokeRequired)
            {
                SetProgressbarValueDelegateWithProgress delegateProgress =
                    new SetProgressbarValueDelegateWithProgress(SetProgressbarValue);
                proControl._LblCur.Invoke(delegateProgress, proControl);
            }
            else
            {
                proControl._LblCur.Text = proControl._strCurTxt;
            }

            //总进度条
            if (proControl._TotoalProBar.InvokeRequired)
            {
                SetProgressbarValueDelegateWithProgress delegateProgress =
                    new SetProgressbarValueDelegateWithProgress(SetProgressbarValue);
                proControl._TotoalProBar.Invoke(delegateProgress, proControl);
            }
            else
            {
                proControl._TotoalProBar.Maximum = proControl._ProgressTotalMaxValue;
                proControl._TotoalProBar.Value = proControl._ProgressTotalCurValue;
            }
        }

        private void 传输文件_Load(object sender, EventArgs e)
        {
            checkBox_all.CheckState = CheckState.Unchecked;

            // 复位listView
            listView_content.Clear();

            DataSet ds_pc;

            ds_pc = _ExaminationPCBLL.GetAllExaminationPCInfo();

            int count = ds_pc.Tables[0].Rows.Count;

            this.dataGridView_clientList.Rows.Clear();

            if (count > 0)
            {
                this.dataGridView_clientList.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {


                    string ip = ds_pc.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    this.dataGridView_clientList.Rows[i].Cells["IP"].Value = ip;

                    this.dataGridView_clientList.Rows[i].Cells["ID"].Value = i + 1;

                    if (i % 2 != 0)
                    {
                        this.dataGridView_clientList.Rows[i].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dataGridView_clientList.Rows[i].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightCyan;
                    }

                }
            }

        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sourPath"></param> 带有名字的fullpath+name
        /// <param name="destPath"></param> 仅仅只是path，那么保存在属性中
        private void SendFile(string sourPath, string destPath)
        {
            var sendData = new R_C_FileData();
            sendData.fileMD5 = GetFileMD5Hash.GetSingleton().GetMD5HashFromFile(sourPath);

            //创建一个文件对象
            FileInfo EzoneFile = new FileInfo(sourPath);
            //打开文件流
            FileStream EzoneStream = EzoneFile.OpenRead();

            //包的大小524288
            int PacketSize = 1048576;

            //包的数量
            int PacketCount = (int) (EzoneStream.Length / ((long) PacketSize));

            //最后一个包的大小
            int LastDataPacket = (int) (EzoneStream.Length - ((long) (PacketSize * PacketCount)));

            if (LastDataPacket > 0)
            {
                PacketCount += 1;
            }


            string[] name = sourPath.Split('\\'); // 一定是单引 

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

                _sendTrigger(sendData);
            }

            //如果还有多余的数据包，则应该发送完毕！
            if (LastDataPacket != 0)
            {
                data = new byte[LastDataPacket];
                EzoneStream.Read(data, 0, data.Length);
                sendData.FileData = data;

                sendData.currentCount = PacketCount;

                _sendTrigger(sendData);

                EzoneStream.Close();

            }

            void _setProgressbar(object packageLength)
            {
                //总进度条
                _ProgressControl._CurSentLen += Convert.ToInt64(packageLength);
                _ProgressControl._ProgressTotalMaxValue = 100;
                _ProgressControl._ClientsNum = 1;
                _ProgressControl._ProgressTotalCurValue =
                    (int) ((_ProgressControl._CurSentLen * 100) / (_ProgressControl._TotalFileLen));

                SetProgressbarValue(_ProgressControl);
            }

            void _sendTrigger(R_C_FileData _sendData)
            {
                // send 同步 用 post 可能会造成线程间数据同步出现问题 比如_ProgressControl._CurSentLen
                uiContext.Send(_setProgressbar, sendData.FileData.Length);

                _sendData.totalSize = _ProgressControl._TotalFileLen;
                _sendData.alreadySendSize = _ProgressControl._CurSentLen;

                if (checkBox_all.CheckState == CheckState.Checked)
                    RabbitMQEventBus.GetSingleton().Trigger<R_C_FileData>(_sendData); //直接通过事件总线触发
                else
                {
                    int row = dataGridView_clientList.Rows.Count; //得到总行数  

                    for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                    {
                        if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value) == true)
                        {
                            string ip = this.dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();
                            RabbitMQEventBus.GetSingleton().Trigger<R_C_FileData>(ip, _sendData); //直接通过事件总线触发

                            // LogHelper.WriteLog(string.Format("发送文件 {0} 的第{1}/{2}个包 到目标计算机 {3}", _sendData.name, sendData.currentCount, sendData.totalCount, ip));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 递归获取文件夹下所有文件的fullName.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public List<string> GetAllFiles(List<string> FileList, DirectoryInfo dir)
        {

            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                FileList.Add(fi.FullName);
            }

            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAllFiles(FileList, d);
            }

            return FileList;
        }

        private void checkBox_all_CheckedChanged(object sender, EventArgs e)
        {
            int row = dataGridView_clientList.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (checkBox_all.CheckState == CheckState.Checked)
                {
                    dataGridView_clientList.Rows[i].Cells["CheckBox"].Value = true;
                }

                else if (checkBox_all.CheckState == CheckState.Unchecked)
                {
                    dataGridView_clientList.Rows[i].Cells["CheckBox"].Value = false;
                }

            }
        }

        public class client_receive_progress_Args
        {
            public string ip { get; set; }
            public long totalSize { get; set; }
            public long alreadySendSize { get; set; }
        }

        public void client_receive_progress(object state)
        {
            string ip = ((client_receive_progress_Args) state).ip;
            long totalSize = ((client_receive_progress_Args) state).totalSize;
            long alreadySendSize = ((client_receive_progress_Args) state).alreadySendSize;

            int row = dataGridView_clientList.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString() == ip)
                {
                    if (alreadySendSize == totalSize)
                    {
                        dataGridView_clientList.Rows[i].Cells["progress"].Value = string.Format("完成");
                        button_refresh_Click(null, null);
                    }
                    else
                    {
                        dataGridView_clientList.Rows[i].Cells["progress"].Value = string.Format("{0}M / {1}M",
                            alreadySendSize / 1024 / 1024, totalSize / 1024 / 1024);
                    }

                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 复选框点击后，更改了checkbox状态的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_clientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //单击复选框时
            {
                DataGridViewCell dgcell = dataGridView_clientList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool ischkBefore = (bool) dgcell.FormattedValue; //选中前
                bool ischkAfter = (bool) dgcell.EditedFormattedValue; //选中后

                // 判断当前有哪些选中，checkList
                // 选中的当中连接的 checkAndConncetList
                // 当前mCheckClientIP如果在checkAndConncetList当中，则不做处理，否则在checkAndConncetList中选一个 ，如果checkAndConncetList为0，则listview复位

                if (ischkBefore != ischkAfter)
                {
                    // 更新edit状态
                    this.dataGridView_clientList.EndEdit();

                    checkList.Clear();
                    checkAndConnectList.Clear();

                    for (int i = 0; i < this.dataGridView_clientList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(this.dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                        {
                            string ip = this.dataGridView_clientList.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                            checkList.Add(ip);
                        }
                    }

                    lock (主界面.GetSingleton().lockConnectedIp)
                    {
                        checkAndConnectList = 主界面.GetSingleton().connectedIP.Intersect(checkList).ToList();

                        if (checkAndConnectList.Count > 0)
                        {
                            if (!checkAndConnectList.Contains(mBrowserClientIP))
                            {
                                // 复位listview
                                listView_content.Clear();
                                toolStripStatusLabel_cip.Text = "";

                                // 打开指定client的ip
                                mBrowserClientIP = checkAndConnectList[0];
                                mCurrentDirectory = "";
                                SendListContentsReq();
                                toolStripStatusLabel_cip.Text = mBrowserClientIP;
                            }
                        }
                        else
                        {
                            // 复位listview
                            mBrowserClientIP = "";
                            listView_content.Clear();
                            toolStripStatusLabel_cip.Text = "";
                            comboBox_currentDirectoryEditor.Text = "";
                        }
                    }
                }
            }
        }

        private void SendListContentsReq()
        {
            //todo 是否需要判断客户端连接状态

            comboBox_currentDirectoryEditor.Text = mCurrentDirectory;

            R_C_ListContentResData sendData = new R_C_ListContentResData(mCurrentDirectory);

            RabbitMQEventBus.GetSingleton().Trigger<R_C_ListContentResData>(mBrowserClientIP, sendData); //直接通过事件总线触发
        }

        private void listView_content_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView_content.SelectedItems[0];
            if (item.ImageKey == "driver.png")
                mCurrentDirectory = item.Text;
            else if (item.ImageKey == "folder.png")
                mCurrentDirectory = Path.Combine(mCurrentDirectory, item.Text);
            else
                return;

            SendListContentsReq();
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeSendClientCheck();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择要发送的客户端的文件";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK || String.IsNullOrEmpty(dialog.FileName))
            {
                return;
            }

            mListFilePaths.Clear();
            mListFolderPaths.Clear();

            foreach (string fileName in dialog.FileNames)
            {
                mListFilePaths.Add(fileName);
            }

            mSaveFolder = mCurrentDirectory;

            btnSend_Click(null, null);

        }

        /// <summary>
        /// 在发送文件或文件夹之前提示用户，当前选中的客户端的连接状态，如果全部连接，没有反应，如果有未连接的，则提示哪些连接哪些未连接
        /// </summary>
        private void BeforeSendClientCheck()
        {
            lock (主界面.GetSingleton().lockConnectedIp)
            {
                List<string> expectedList = checkList.Except(主界面.GetSingleton().connectedIP).ToList();

                if (expectedList.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("选中但未连接的客户端：");
                    foreach (string exString in expectedList)
                    {
                        builder.AppendLine("  " + exString);
                    }
                    builder.AppendLine("选中且未连接的客户端：");
                    foreach (string hasString in checkAndConnectList)
                    {
                        builder.AppendLine("  " + hasString);
                    }

                    DialogResult dr = MessageBox.Show(builder.ToString(), "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        if (checkAndConnectList.Count > 0)
                        {
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 发送文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文件夹ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BeforeSendClientCheck();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择要发送到客户端的文件夹";
            dialog.ShowNewFolderButton = false;

            mListFolderPaths.Clear();

            if (dialog.ShowDialog() != DialogResult.OK || String.IsNullOrEmpty(dialog.SelectedPath))
            {
                return;
            }

            mListFolderPaths.Add(dialog.SelectedPath);

            mSaveFolder = mCurrentDirectory;

            btnSend_Click(null, null);

            mListFilePaths.Clear();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 发送文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择一个文件夹来保存所获取的文件";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedItem = listView_content.SelectedItems[0].Text;
            string savePath = Path.Combine(dialog.SelectedPath, selectedItem);
            string sourcePath = "";
            if (mCurrentDirectory.EndsWith(@"\"))
            {
                sourcePath = mCurrentDirectory + selectedItem;
            }
            else
            {
                sourcePath = mCurrentDirectory + @"\"+ selectedItem;
            }

            if (File.Exists(savePath) || Directory.Exists(savePath))
            {
                MessageBox.Show(selectedItem + " 已存在于 " + savePath + " 无法保存。", "文件已存在");
            }
            else
            {
                int row = dataGridView_clientList.Rows.Count; //得到总行数  

                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                    {
                        string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                        // 文件获取逻辑
                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_GetFileData
                            >(ip, new R_C_GetFileData(sourcePath, savePath)); //直接通过事件总线触发
                    }

                }
            }
        }

        private string mPasteType = "";
        private List<string> mPasteSources = new List<string>();

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPasteType = "Cut";
            mPasteSources.Clear();
            foreach (ListViewItem item in listView_content.SelectedItems)
            {
                string name = item.Text;
                string path = Path.Combine(mCurrentDirectory, name);
                mPasteSources.Add(path);
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPasteType = "Copy";
            mPasteSources.Clear();
            foreach (ListViewItem item in listView_content.SelectedItems)
            {
                string name = item.Text;
                string path = Path.Combine(mCurrentDirectory, name);
                mPasteSources.Add(path);
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView_clientList.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                {
                    string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                    RabbitMQEventBus.GetSingleton()
                        .Trigger<R_C_MoveContentData
                        >(ip, new R_C_MoveContentData(mPasteType, mPasteSources, mCurrentDirectory)); //直接通过事件总线触发
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            mCurrentDirectory = Path.GetDirectoryName(mCurrentDirectory);
            SendListContentsReq();
        }

        public void button_refresh_Click(object sender, EventArgs e)
        {
            mCurrentDirectory = comboBox_currentDirectoryEditor.Text;
            SendListContentsReq();
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentName = listView_content.SelectedItems[0].Text;
            输入信息 inputDialog = new 输入信息();
            inputDialog.Title = "请输入新的名称";
            inputDialog.AllowEmpty = false;
            inputDialog.Result = currentName;
            inputDialog.SelectionStart = 0;
            int length = currentName.LastIndexOf('.');
            inputDialog.SelectionLength = length > 0 ? length : currentName.Length;
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                if (inputDialog.Result == currentName)
                {
                    return;
                }

                int row = dataGridView_clientList.Rows.Count; //得到总行数  

                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                    {
                        string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_RenameContentData
                            >(ip, new R_C_RenameContentData(Path.Combine(mCurrentDirectory, currentName), inputDialog.Result)); //直接通过事件总线触发
                    }
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除这些项目吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                R_C_DeleteContentData sendData = new R_C_DeleteContentData();
                sendData.ContentPaths = new List<string>();
                foreach (ListViewItem item in listView_content.SelectedItems)
                {
                    string contentPath = Path.Combine(mCurrentDirectory, item.Text);
                    sendData.ContentPaths.Add(contentPath);
                }

                int row = dataGridView_clientList.Rows.Count; //得到总行数  

                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                    {
                        string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_DeleteContentData
                            >(ip, sendData); //直接通过事件总线触发
                    }
                }
            }
        }

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            输入信息 dialog = new 输入信息();
            dialog.Title = "请输入文件夹名称";
            dialog.AllowEmpty = false;
            dialog.Result = "新建文件夹";
            dialog.SelectionStart = 0;
            dialog.SelectionLength = dialog.Result.Length;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                R_C_CreateFolderContentData sendData = new R_C_CreateFolderContentData();
                sendData.Container = mCurrentDirectory;
                sendData.Name = dialog.Result;


                int row = dataGridView_clientList.Rows.Count; //得到总行数  

                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                    {
                        string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_CreateFolderContentData
                            >(ip, sendData); //直接通过事件总线触发
                    }
                }
            }
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 仅仅发送给当前显示目录的客户端，也就是 mBrowserClientIP
            string name = listView_content.SelectedItems.Count > 0 ? listView_content.SelectedItems[0].Text : mCurrentDirectory;
            string path = Path.Combine(mCurrentDirectory, name);
            R_C_GetContentInfoData sendData = new R_C_GetContentInfoData();
            sendData.ContentPath = path;

            RabbitMQEventBus.GetSingleton()
                .Trigger<R_C_GetContentInfoData
                >(mBrowserClientIP, sendData); //直接通过事件总线触发
        }

        private void 复制路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exception exception = null;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    string name = listView_content.SelectedItems[0].Text;
                    string path = Path.Combine(mCurrentDirectory, name);
                    Clipboard.SetText(path);
                    return;
                }
                catch (Exception ex)
                {
                    exception = ex;
                    Thread.Sleep(100);
                }
            }
            MessageBox.Show(exception.Message, "复制文件路径时出现问题");
        }

        private void 远程执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int row = dataGridView_clientList.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                string ip = dataGridView_clientList.Rows[i].Cells["IP"].Value.ToString();

                foreach (ListViewItem item in listView_content.SelectedItems)
                {
                    if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                    {
                        string name = item.Text;
                        string processFilePathName = Path.Combine(mCurrentDirectory, name);

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_ControlProcessData
                            >(ip, new R_C_ControlProcessData(processFilePathName, true)); //直接通过事件总线触发
                    }
                }
            }
        }

        private void 传输文件_FormClosing(object sender, FormClosingEventArgs e)
        {
            mBrowserClientIP = "";
        }

        /// <summary>
        /// 添加应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentName = listView_content.SelectedItems[0].Text;
            输入信息 inputDialog = new 输入信息();
            inputDialog.Title = "请输入应用名称";
            inputDialog.AllowEmpty = false;
            inputDialog.Result = currentName;
            inputDialog.SelectionStart = 0;
            int length = currentName.LastIndexOf('.');
            inputDialog.SelectionLength = length > 0 ? length : currentName.Length;
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // 添加应用名称到数据库
                DataSet ds_app_name = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAppName();
                DataRow[] rows = ds_app_name.Tables[0]
                    .Select(string.Format("{0} = '{1}'", ProcessControlModel.DB_Name, inputDialog.Result));

                if (rows.Length > 0)
                {
                    MessageBox.Show(string.Format("不能重复添加应用：{0} ", inputDialog.Result));
                    return;
                }
                else
                {
                    DataSet ds_pc_info = 进程管理.GetSingleton()._ExaminationPCBLL.GetAllExaminationPCInfo();

                    string path = Path.Combine(mCurrentDirectory, currentName);

                    int count = ds_pc_info.Tables[0].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView_clientList.Rows[i].Cells["CheckBox"].Value))
                        {
                            string ip = ds_pc_info.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                            ProcessControlModel model = new ProcessControlModel();
                            model.ID = null;
                            model.Path = path;
                            model.IP = ip;
                            model.AppName = inputDialog.Result;

                            进程管理.GetSingleton()._GetAllAppInfoBLL.AddOrUpdateProgressControlInfo(model);
                        }
                    }
                }
            }
        }
    }
}

