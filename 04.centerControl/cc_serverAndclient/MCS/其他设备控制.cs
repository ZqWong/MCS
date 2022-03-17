using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Common.Model;
using CommonTools.tools;
using DW_CC_NET.tools;
using MCS.Common;
using MCS.DB.BLL;
using MCS.DeviceRespond;
using NPOI.DDF;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using Utilities;
using Timer = System.Threading.Timer;

// 不同项目码不同
// 投影网口开码 25 31 50 4f 57 52 20 31 0d
// 投影网口关码 25 31 50 4f 57 52 20 30 0d
// 时序器的额网口码和串口码相同
// 音响时序器网口开码 48 1A 00 01 02 00 00 4D
// 影响时序器网口关码 48 1A 00 01 01 00 00 4D

namespace MCS
{

    public partial class 其他设备控制 : Form
    {
        /// <summary>
        /// 获取设备信息
        /// </summary>
        public DeviceControlInfoBLL _GetDeviceInfoBLL = new DeviceControlInfoBLL();

        /// <summary>
        /// 串口信息
        /// </summary>
        public Dictionary<string, SerialPort> _serialDict = new Dictionary<string, SerialPort>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, KeyValuePair<string, string>> _ipDict = new Dictionary<string, KeyValuePair<string, string>>();

        private static readonly object syslock = new object();

        private static 其他设备控制 _instance;
        private static SynchronizationContext _uiContext;

        private string _currentClassName;
        private string _lastClassName;

        private string CONTROLTYPENET = "网口";
        private string CONTROLTYPESERIAL = "串口";

        // 设备信息列表 xml
        public Dictionary<string, DeviceStruct> deviceDict = new Dictionary<string, DeviceStruct>();
        // 分组信息
        public Dictionary<string, List<string>> groupDict = new Dictionary<string, List<string>>();
        // 方案信息
        public Dictionary<string, List<PlanStruct>> planDict = new Dictionary<string, List<PlanStruct>>();
        // 设备状态保存字典 <设备名称, <控制码名称, 返回值>
        public ConcurrentDictionary<string, ConcurrentDictionary<string, NetRecvStruct>> deviceStateDict = new ConcurrentDictionary<string, ConcurrentDictionary<string, NetRecvStruct>>();

        // 保存数据库中的所有deviceInfo
        public DataSet ds_device_all;
        /// <summary>
        /// 设备名
        /// </summary>
        public DataSet ds_device_class;

        // 保存初始的datagridview 的 columns
        private List<DataGridViewColumn> columnList;

        // 网络控制连接管理
        private Dictionary<string,LinkConnection>  linkConnectionDict = new Dictionary<string, LinkConnection>();

        // 定时器
        private System.Timers.Timer timer;

        public static 其他设备控制 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new 其他设备控制();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return _uiContext;
        }


        public 其他设备控制()
        {
            
            InitializeComponent();

            // 获取所有设备名
            ds_device_class = _GetDeviceInfoBLL.GetDeviceClassNameInfo();
            // 获取所有设备基本信息
            ds_device_all = _GetDeviceInfoBLL.GetDeviceInfo();
            // 转换成列数据
            columnList = dataGridView1.Columns.Cast<DataGridViewColumn>().ToList();

            // 根据配置文件读取设备信息
            GetDeviceInfoFormXml();

            LoadSerialData();

            // 根据配置文件读取计划方案信息
            GetDevicePlanInfo();
            // 根据配置文件读取分组信息
            LoadGroupInfo();

            // 定时器
            timer = new System.Timers.Timer();
            timer.Enabled = false;
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddComboboxSerial()
        {
            DataSet ds_device_serial;
            ds_device_serial = _GetDeviceInfoBLL.GetDeviceSerialInfo();

            // 添加当前已连接串口
            string[] PortNames = SerialPort.GetPortNames();    //获取本机串口名称，存入PortNames数组中

            for (int i = 0; i < PortNames.Count(); i++)
            {
                string input = string.Format("{0}='{1}'", DeviceControlModel.DB_SERIAL, PortNames[i]);
                if (ds_device_serial.Tables[0].Select(input).Length > 0)
                {
                }
                else
                {
                    DataRow tmp_row = ds_device_serial.Tables[0].NewRow();
                    tmp_row[DeviceControlModel.DB_SERIAL] = PortNames[i];
                    ds_device_serial.Tables[0].Rows.Add(tmp_row);
                }
            }

            SERIAL_PORT.ValueMember = DeviceControlModel.DB_SERIAL;
            SERIAL_PORT.DisplayMember = DeviceControlModel.DB_SERIAL;
            SERIAL_PORT.DataSource = ds_device_serial.Tables[0];
            SERIAL_PORT.FlatStyle = FlatStyle.Flat;
        }

        private void AddComboboxClass()
        {
            
            ds_device_class = _GetDeviceInfoBLL.GetDeviceClassNameInfo();

            category.ValueMember = DeviceControlModel.DB_CLASS;
            category.DisplayMember = DeviceControlModel.DB_CLASS;
            category.DataSource = ds_device_class.Tables[0];
            category.FlatStyle = FlatStyle.Flat;

        }

        /// <summary>
        /// 功能是载入串口信息
        /// </summary>
        private void LoadSerialData()
        {
            _ipDict.Clear();
            _serialDict.Clear();

            // 获取一行数据:  投影1   投影   192.168.0.55   COM5
            // 获取串口信息 获取选择行
            DataRow[] dr = ds_device_all.Tables[0].Select();

            for (int i = 0; i < ds_device_all.Tables[0].Rows.Count; i++)
            {
                // 设备名
                string className = dr[i][DeviceControlModel.DB_CLASS].ToString();

                if (deviceDict.ContainsKey(className))
                {
                }
                else
                {
                    NlogHandler.GetSingleton().Error(string.Format("配置文件中不存在类型:{0}, 请配置", className));
                    continue;
                }

                if (deviceDict[className].controlType == CONTROLTYPESERIAL)

                {
                    // 串口通讯
                    string serial_port = dr[i][DeviceControlModel.DB_SERIAL].ToString();

                    string id = dr[i][DeviceControlModel.DB_ID].ToString();

                    string baud_rate = deviceDict[className].buad.ToString();

                    try
                    {
                        SerialPort serialComm = new SerialPort(serial_port);

                        serialComm.BaudRate = int.Parse(baud_rate);

                        serialComm.DataReceived += new SerialDataReceivedEventHandler(DeviceSerialOnReceive);

                        if (serialComm.IsOpen == false)
                        {
                            serialComm.Open();

                            if (_serialDict.ContainsKey(id) == false)
                            {
                                _serialDict.Add(id, serialComm);
                            }
                        }
                        else
                        {
                        }
                    }
                    catch (Exception e)
                    {
                        NlogHandler.GetSingleton().Error("初始化" + e.Message);
                        // MessageBox.Show(e.Message);
                    }

                }
            }
            dataGridView1.ClearSelection();
        }

        private void 其他设备控制_Load(object sender, EventArgs e)
        {
            // 此函数会在刚刚打开其他设备控制界面时候进入两次
            // 开启定时器
            timer.Enabled = true;
            timer.Start();
            
            checkBox_all.CheckState = CheckState.Unchecked;

            // 加载类别名
            loadComboxClass();

            DataSet ds_device_all;

            ds_device_all = _GetDeviceInfoBLL.GetDeviceInfo();

            // 设置设备名
            AddComboboxClass();

            // 设置串口名
            AddComboboxSerial();

            // 加载分组信息
            LoadGroupInfo();

            // 加载其他设备控制信息
            AddDeviceControlCodeCombox();

            DataRow[] dr = ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_CLASS, _currentClassName));

            // 根据配置文件动态添加column，比如投影机的开机状态
            AddColumnsToDataGridView(_currentClassName);

            // 根据配置文件读取计划方案信息
            GetDevicePlanInfo();

            int count = dr.Length;

            this.dataGridView1.Rows.Clear();

            if (count > 0)
            {
                this.dataGridView1.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {

                    string ip = dr[i][DeviceControlModel.DB_IP].ToString();
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_IP].Value = ip;

                    string id = dr[i][DeviceControlModel.DB_ID].ToString();
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_ID].Value = id;

                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value = dr[i][DeviceControlModel.DB_Name].ToString();

                    string className = dr[i][DeviceControlModel.DB_CLASS].ToString();
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value = className;

                    string serial_port = dr[i][DeviceControlModel.DB_SERIAL].ToString();
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_SERIAL].Value = serial_port;

                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;

                    // 根据配置信息链接串口或者网口
                    if (deviceDict.ContainsKey(className))
                    {
                        if (deviceDict[className].controlType == CONTROLTYPESERIAL)
                        {
                            // 串口链接
                            try
                            {
                                SerialPort serialComm;
                                if (_serialDict.TryGetValue(id, out serialComm) == false)
                                {
                                    serialComm = new SerialPort(serial_port);
                                }


                                if (serialComm.IsOpen)
                                    serialComm.Close();

                                serialComm.BaudRate = deviceDict[className].buad;

                                if (serialComm.IsOpen == false)
                                {
                                    serialComm.Open();
                                    if (_serialDict.ContainsKey(id) == false)
                                    {
                                        _serialDict.Add(id, serialComm);
                                    }

                                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                                }
                            }
                            catch (Exception exception)
                            {
                                NlogHandler.GetSingleton().Error(exception.Message);
                                // MessageBox.Show(exceptForeColorion.Message);
                            }
                        }
                        else if (deviceDict[className].controlType == CONTROLTYPENET)
                        {
                            // 网口连接
                            lock (主界面.GetSingleton().lockPingIp)
                            {
                                if (主界面.GetSingleton().IPDict.ContainsKey(ip))
                                {
                                    if (_ipDict.ContainsKey(id) == false)
                                    {
                                        KeyValuePair<string, string> ipPortPair = new KeyValuePair<string, string>(ip, deviceDict[className].port.ToString());
                                        _ipDict.Add(id, ipPortPair);
                                    }

                                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                                }

                            }
                        }
                    }
                    else
                    {
                        NlogHandler.GetSingleton().Error(string.Format("检查配置文件中配置的设备类别，数据库中的类别：{0} 并没有在配置文件中配置", className));
                    }
                }
            }
            this.dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// 控制设备
        /// </summary>
        /// <param name="deviceList">需要控制的设备信息列表</param>
        /// <param name="controlName">进行控制的控制码</param>
        public void DeviceControl(List<string> deviceList, string controlName)
        {
            // 设备列表判断 
            if (deviceList == null)
                return;

            if (deviceList.Count == 0)
            {
                return;
            }

            string readData = "";

            DataRow[] dr;

            // 设备名组 用 , 分开的
            string deviceNames = "";

            string ControlCodeTemp = "";

            foreach (string deviceName in deviceList)
            {
                deviceNames += string.Format("'{0}',", deviceName);
            }

            // 删除最后一个逗号
            deviceNames = deviceNames.Substring(0, deviceNames.Length - 1);

            // 数据库捞数据
            /*SQL e.g.:
             
                    SELECT
	                    * 
                    FROM
	                    t_device_control_info dtci
                    WHERE
	                    dtci.`NAME` 
	                    IN
	                    ('投影1','投影2')
	                    ORDER BY dtci.`NAME` ASC

             Data e.g.:
            ID  NAME    CLASS   IP              PROT    INTERNET_ON_CODE                INTERNET_OFF_CODE            SERIAL     SERIAL_ON_CODE      SERIAL_OFF_CODE     BAUD    USER_RS232   DELAY   
            1	投影1	投影	    192.168.0.55	4352	25 31 50 4f 57 52 20 31 0d	    25 31 50 4f 57 52 20 30 0d	 COM5	    30 30 21 0D	        30 30 22 0D	        9600	是	         10
            2	投影2	投影	    192.168.0.56	4352			                                                     COM2			                                    9600	否	         3   
             
             */
            dr = ds_device_all.Tables[0].Select(string.Format("{0} in ({1})", DeviceControlModel.DB_Name, deviceNames), string.Format("{0} Asc", DeviceControlModel.DB_Name));


            if (dr.Length > 0)
            {
                // 获取设备信息
                for (int i = 0; i < dr.Length; i++)
                {

                    string className = dr[i][DeviceControlModel.DB_CLASS].ToString();
                    string ip = dr[i][DeviceControlModel.DB_IP].ToString();
                    string id = dr[i][DeviceControlModel.DB_ID].ToString();
                    string name = dr[i][DeviceControlModel.DB_Name].ToString();

                    /*                            
                         <Device name="投影" ControlType="网口" Hex="false" Buad="9600" Port="4352">
                              <ControlCode name="开启设备" Code="%1POWR 1" Delay="2" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="关闭设备" Code="%1POWR 0" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3D自动" Code="(tde 0)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3D帧连续" Code="(tde 5)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3D翻转开" Code="(tdi 1)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3D翻转关" Code="(tdi 0)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="光闸开" Code="(shu 0)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="光闸关" Code="(shu 1)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="帧延迟" Code="(fdy 60)" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3DSyncOut开" Code="7E 30 30 32 33 31 20 31 0D" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="3DSyncOut关" Code="7E 30 30 32 33 31 20 30 0D" Delay="0" AutoExecInterval="0" Show="false">
                              </ControlCode>
                              <ControlCode name="电源状态" Code="%1POWR ?" Delay="0" AutoExecInterval="5" Show="True">
                                <ReturnCode code="%1POWR=1" Text="开启">
                                </ReturnCode>
                                <ReturnCode code="%1POWR=0" Text="关闭">
                                </ReturnCode>
                              </ControlCode>
                            </Device>
                    */
                    // 从AppConfig中读取配置

                    //<DeviceControl> 字段
                    // <ControlCode name="3DSyncOut关" Code="7E 30 30 32 33 31 20 30 0D" Delay="0" AutoExecInterval="0" Show="false">
                    string controlCode = GetControlCodeByControlName(className, controlName);

                    DeviceStruct temp;
                    if (deviceDict.TryGetValue(className, out temp))
                    {
                        byte[] cmdBytes;

                        // 是否转成16进制
                        if (temp.isHex)
                        {
                            ControlCodeTemp = controlCode;
                        }
                        else
                        {
                            // 转16进制
                            ControlCodeTemp = StringToHex(controlCode);
                        }

                        // 转为二进制数组
                        cmdBytes = HexStringToBinary(ControlCodeTemp);

                        // 走网口连接
                        if (temp.controlType == CONTROLTYPENET)
                        {
                            // string ipPort = ip + ":" + temp.port;

                            LinkConnection c;

                            if (linkConnectionDict.ContainsKey(name))
                            {
                                c = linkConnectionDict[name];
                            }
                            else
                            {
                                c = new LinkConnection(ip, temp.port, name);
                                linkConnectionDict[name] = c;
                                c.OnReceive += new DelegateMsg(DeviceNetOnReceive);
                                c.OnErr += new DelegateMsg(DeviceNetOnErr);
                                c.OnServerDown += new DelegateMsg(DeviceNetOnServerDown);
                            }

                            // 网口发送
                            if (c.sendBytes(cmdBytes))
                            {
                                // 发送比较频繁、关闭此log
                                // NlogHandler.GetSingleton().Info(string.Format("网口控制设备 {0} {1}, ip：{2}", name, controlCode, ip));
                            }
                            else
                            {
                                // 发送比较频繁、关闭此log
                                // NlogHandler.GetSingleton().Info(string.Format("网口控制设备 {0} {1} 异常, ip：{2}", name, controlCode, ip));
                            }
                        }
                        // 走串口连接
                        else if (temp.controlType == CONTROLTYPESERIAL)
                        {
                            if (其他设备控制.GetSingleton()._serialDict.ContainsKey(id))
                            {
                                // 串口控制
                                其他设备控制.GetSingleton()._serialDict[id].Write(cmdBytes, 0, cmdBytes.Length);
                            }
                        }
                    }
                    else
                    {
                        NlogHandler.GetSingleton().Error(string.Format("其他设备控制的类型：{0} 并没有在配置文件中配置，检查配置文件和数据库中数据", className));
                    }

                    // delay
                    float delayTime = 0.00001f;
                    var keys = temp.controlCodeDict.Where(q => q.Value.code == controlCode).Select(q => q.Key);

                    foreach (var key in keys)
                    {
                        if (temp.controlCodeDict[key].delay > delayTime)
                        {
                            delayTime = temp.controlCodeDict[key].delay;
                        }
                    }

                    Thread.Sleep((int)(1000 * delayTime));

                    NlogHandler.GetSingleton().Debug(string.Format("执行设备控制  设备名：{0} 控制名称 {1}", name, controlName));
                }
            }
        }

        /// <summary>
        /// 处理网口设备的returnCode，保存到线程安全容器中
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        private void DeviceNetOnReceive(object msg, string name)
        {
            try
            {
                string returnCode = msg.ToString();

                NetRecvStruct dr = new NetRecvStruct();
                dr.data = returnCode;
                dr.time = DateTime.Now;

                // 根据 name 遍历配置文件中returnCode为msg的项，将其在DataGridView中的显示置为“是”
                string className = GetClassNameByDeviceName(name);

                if (deviceDict.ContainsKey(className))
                {
                    List<string> controlNames = deviceDict[className].controlCodeDict.Values
                        .Where(q => q.returnCodeStateDict.ContainsKey(returnCode)).Select(q => q.name).ToList();

                    foreach (string controlName in controlNames)
                    {
                        deviceStateDict[name][controlName] = dr;
                    }
                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("网络接收设备信息错误 {0}",e.Message.ToString()));
            }
 
        }

        private void DeviceNetOnErr(object msg, string name)
        {
            NlogHandler.GetSingleton().Error(string.Format("设备 {0} 网络错误, {1}",name, msg.ToString()));

        }

        private void DeviceNetOnServerDown(object msg, string name)
        {
            NlogHandler.GetSingleton().Error(string.Format("设备 {0} 网络断开, {1}", name, msg.ToString()));

        }

        /// <summary>
        /// 处理串口收到信息
        /// </summary>
        public void DeviceSerialOnReceive(Object sender, SerialDataReceivedEventArgs e)
        {
            
            try
            {
                SerialPort serialPort = sender as SerialPort;

                DataRow[] dr;
                dr = ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_SERIAL, serialPort.PortName));

                if (dr.Length != 1)
                {
                    NlogHandler.GetSingleton().Error(string.Format("串口号{0} 被重复使用，请检查", serialPort.PortName));
                    return;
                }

                if (!serialPort.IsOpen)
                    return;

                string className = dr[0][DeviceControlModel.DB_CLASS].ToString();
                string deviceName = dr[0][DeviceControlModel.DB_Name].ToString();
                //定义一个字段，来保存串口传来的信息。
                string returnCode = "";

                int len = serialPort.BytesToRead;
                Byte[] readBuffer = new Byte[len];
                serialPort.Read(readBuffer, 0, len);
                returnCode = ByteArrayToHexString(readBuffer);

                NetRecvStruct nrs = new NetRecvStruct();
                nrs.data = returnCode;
                nrs.time = DateTime.Now;

                if (deviceDict.ContainsKey(className))
                {
                    List<string> controlNames = deviceDict[className].controlCodeDict.Values
                        .Where(q => q.returnCodeStateDict.ContainsKey(returnCode)).Select(q => q.name).ToList();

                    if (controlNames.Count > 0)
                    {
                        foreach (string controlName in controlNames)
                        {
                            deviceStateDict[deviceName][controlName] = nrs;
                        }
                    }
                    else
                    {
                        // 判断是不是有自定义的正则表达式
                        foreach (var controlCodeItem in deviceDict[className].controlCodeDict)
                        {
                            if (controlCodeItem.Value.returnCodeStateDict.Count > 0)
                            {
                                foreach (var returnCodeItem in controlCodeItem.Value.returnCodeStateDict)
                                {
                                    List<string> resList = GetRegexStringBySerialReturnCode(returnCodeItem.Key);

                                    Regex regexTemp = new Regex(resList[0]);

                                    if (regexTemp.IsMatch(returnCode))
                                    {
                                        deviceStateDict[deviceName][controlCodeItem.Key] = nrs;
                                    }
                                }
                            }
                        }
                    }
                }


                serialPort.DiscardInBuffer();  //清空接收缓冲区   
            }
            catch (Exception ex)
            {
                NlogHandler.GetSingleton().Error(string.Format("串口读取错误 串口号：{0}， 错误 {1}",(sender as SerialPort).PortName, ex.Message.ToString()));
            }
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                // sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                sb.AppendFormat("{0:x2} ", b);
            }

            string res = sb.ToString().ToUpper();
            res = res.Substring(0, res.Length - 1);

            return res;
        }

        /// <summary>
        /// 将一条十六进制字符串转换为ASCII
        /// </summary>
        /// <param name="hexstring">一条十六进制字符串</param>
        /// <returns>返回一条ASCII码</returns>
        public static string HexStringToASCII(string hexstring)
        {
            byte[] bt = HexStringToBinary(hexstring);
            string lin = "";
            for (int i = 0; i < bt.Length; i++)
            {
                lin = lin + bt[i] + " ";
            }


            string[] ss = lin.Trim().Split(new char[] { ' ' });
            char[] c = new char[ss.Length];
            int a;
            for (int i = 0; i < c.Length; i++)
            {
                a = Convert.ToInt32(ss[i]);
                c[i] = Convert.ToChar(a);
            }

            string b = new string(c);
            return b;
        }

        /**/
                    /// <summary>
                    /// 16进制字符串转换为二进制数组
                    /// </summary>
                    /// <param name="hexstring">用空格切割字符串</param>
                    /// <returns>返回一个二进制字符串</returns>
                    public static byte[] HexStringToBinary(string s)
        {
            if (s.Length == 0)
                throw new Exception("将16进制字符串百转换成字节度数组时出错，错误信息：被知转换的字符串长度为0。道");
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// string 转 16进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StringToHex(string input)
        {
            string hexOutput = "";

            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                hexOutput += String.Format("{0:X2}", value) + " ";
            }

            //hexOutput += "0d";

            return hexOutput;
        }


        private void _checkBoxSelect(IList<string> classList, CheckBox checkBox)
        {
            int row = dataGridView1.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if(dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value == null)
                    continue;

                if (checkBox.CheckState == CheckState.Checked)
                {
                    if (classList.Contains(dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = true;
                    }
                }
                else if (checkBox.CheckState == CheckState.Unchecked)
                {
                    if (classList.Contains(dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = false;
                    }
                }
            }
        }

        private void checkBox_projector_CheckedChanged(object sender, EventArgs e)
        {
            string[] tempList = {"投影"};
            _checkBoxSelect((IList<string>) tempList, checkBox_projector);
        }

        private void checkBox_audio_CheckedChanged(object sender, EventArgs e)
        {
            string[] tempList = { "音响" };
            _checkBoxSelect((IList<string>)tempList, checkBox_audio);
        }

        private void checkBox_light_CheckedChanged(object sender, EventArgs e)
        {
            string[] tempList = { "灯光" };
            _checkBoxSelect((IList<string>)tempList, checkBox_light);
        }

        private void checkBox_all_CheckedChanged(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value == null)
                    continue;

                if (checkBox_all.CheckState == CheckState.Checked)
                {
                    dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = true;
                }
                else if (checkBox_all.CheckState == CheckState.Unchecked)
                {
                    dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = false;
                }
                
            }
        }


        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 关闭串口再刷新
            foreach (string key in _serialDict.Keys)
            {
                _serialDict[key].Close();
            }
            _serialDict.Clear();

            其他设备控制_Load(null, null);

            loadComboxClass(true);
        }

        private void 保存到数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要保存修改吗?", "保存修改", messButton);

            if (dr == DialogResult.Cancel) //如果点击“确定”按钮
            {
                return;
            }

            DeviceControlModel model = new DeviceControlModel();

            int row = dataGridView1.Rows.Count; //得到总行数  

            for (int i = 0; i < row - 1; i++) //得到总行数并在之内循环  
            {
                // todo 判断id是否为null
                if (dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_ID].Value == null)
                {
                    model.ID = null;
                }
                else
                {
                    model.ID = dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_ID].Value.ToString();
                }

                model.NAME = dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value.ToString();
                model.IP = dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_IP].Value.ToString();
                model.CLASS = dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CLASS].Value.ToString();
                model.SERIAL = dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_SERIAL].Value.ToString();

                _GetDeviceInfoBLL.AddOrUpdateDeviceInfo(model);

                // 刷新
                // button_reload_Click(null, null);

            }
        }

        private void comboBox_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastClassName = _currentClassName;
            _currentClassName = comboBox_class.SelectedValue.ToString();
            if (_lastClassName != null)
            {
                // 防止新打开窗口时，进入两次
                其他设备控制_Load(null, null);
            }
        }

        /// <summary>
        /// 加载设备类别到combox
        /// </summary>
        private void loadComboxClass(bool force=false)
        {

            if (comboBox_class.Items.Count > 0 && force == false)
            {
                return;
            }
            else
            {
                DataSet ds;

                ds = _GetDeviceInfoBLL.GetDeviceClassNameInfo();

                comboBox_class.ValueMember = DeviceControlModel.DB_CLASS;
                comboBox_class.DisplayMember = DeviceControlModel.DB_CLASS;
                comboBox_class.DataSource = ds.Tables[0];
            }
        }

        private void LoadGroupInfo()
        {
            // 加载分组信息
            this.comboBox_group.Items.Clear();

            groupDict.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            this.comboBox_group.Items.Add("");

            for (int i = 0; i < groupNodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(groupNodes[i], "name", "");

                this.comboBox_group.Items.Add(groupName);

                List<XmlNode> childNodes = XmlUtil.GetChildNodes(groupNodes[i], "", "");

                if (childNodes.Count > 0)
                {
                    List<string> deviceList = new List<string>();

                    for (int j = 0; j < childNodes.Count; j++)
                    {
                        String deviceName = XmlUtil.GetAttribute(childNodes[j], "name", "");
                        deviceList.Add(deviceName);
                    }

                    groupDict.Add(groupName, deviceList);
                }
            }
        }

        private void comboBox_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkBox_all.Checked = false;

            List<string> groupNameList = 主界面.GetSingleton().GetXmlGroupInfo(this.comboBox_group.Text);

            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value == null)
                {
                    continue;
                }

                string pjName = this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value.ToString();

                if (groupNameList.Contains(pjName))
                {
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = true;
                }
                else
                {
                    this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value = false;
                }
            }
        }

        /// <summary>
        /// 从xml中读取设备信息到内存中
        /// </summary>
        public void GetDeviceInfoFormXml()
        {
            deviceDict.Clear();
            deviceStateDict.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/DeviceControl";

            List<XmlNode> deviceNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            for (int i = 0; i < deviceNodes.Count; i++)
            {

                DeviceStruct deivceStrucTemp = new DeviceStruct();

                deivceStrucTemp.deviceClassName = XmlUtil.GetAttribute(deviceNodes[i], "name", "");
                deivceStrucTemp.controlType = XmlUtil.GetAttribute(deviceNodes[i], "ControlType", "");
                deivceStrucTemp.isHex = bool.Parse(XmlUtil.GetAttribute(deviceNodes[i], "Hex", ""));
                deivceStrucTemp.buad = int.Parse(XmlUtil.GetAttribute(deviceNodes[i], "Buad", ""));
                deivceStrucTemp.port = int.Parse(XmlUtil.GetAttribute(deviceNodes[i], "Port", ""));

                deviceDict.Add(deivceStrucTemp.deviceClassName, deivceStrucTemp);

                List<XmlNode> childNodes = XmlUtil.GetChildNodes(deviceNodes[i], "", "");

                for (int j = 0; j < childNodes.Count; j++)
                {
                    DeviceStruct.CodeStruct codeStructTemp = new DeviceStruct.CodeStruct();

                    string controlName = XmlUtil.GetAttribute(childNodes[j], "name", "");
                    codeStructTemp.name = controlName;
                    codeStructTemp.code = XmlUtil.GetAttribute(childNodes[j], "Code", "");
                    codeStructTemp.delay = float.Parse(XmlUtil.GetAttribute(childNodes[j], "Delay", ""));
                    codeStructTemp.show = bool.Parse(XmlUtil.GetAttribute(childNodes[j], "Show", ""));
                    codeStructTemp.autoExecInterval = float.Parse(XmlUtil.GetAttribute(childNodes[j], "AutoExecInterval", ""));

                    List<XmlNode> childchiildNodes = XmlUtil.GetChildNodes(childNodes[j], "", "");

                    if (childchiildNodes.Count > 0)
                    {
                        var dr = ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_CLASS, deivceStrucTemp.deviceClassName));

                        if (dr.Length > 0)
                        {
                            for (int jj = 0; jj < dr.Length; jj++)
                            {
                                string deviceName = dr[jj][DeviceControlModel.DB_Name].ToString();
                                deviceStateDict[deviceName] = new ConcurrentDictionary<string, NetRecvStruct>();
                                deviceStateDict[deviceName][controlName] = new NetRecvStruct();
                            }
                        }

                        for (int k = 0; k < childchiildNodes.Count; k++)
                        {
                            string returnCode = XmlUtil.GetAttribute(childchiildNodes[k], "code", "");
                            string text = XmlUtil.GetAttribute(childchiildNodes[k], "Text", "");

                            codeStructTemp.returnCodeStateDict[returnCode] = text;
                        }
                    }

                    deivceStrucTemp.controlCodeDict.Add(controlName, codeStructTemp);
                }
            }
        }

        /// <summary>
        /// 添加设备控制码的combox，在类别combox更改时响应
        /// </summary>
        private void AddDeviceControlCodeCombox()
        {
            comboBox_deviceControl.Items.Clear();

            foreach (var device in deviceDict.Values)
            {
                if (device.deviceClassName == _currentClassName)
                {
                    foreach (var controlInfo in device.controlCodeDict)
                    {
                        comboBox_deviceControl.Items.Add(controlInfo.Key);
                    }
                }
            }
        }

        /// <summary>
        /// 根据className添加列到Datagrideview
        /// </summary>
        /// <param name="className"></param>
        private void AddColumnsToDataGridView(string className)
        {
            List<DataGridViewColumn> needDeleteColumnList = new List<DataGridViewColumn>(); 

            int columnsCount = dataGridView1.Columns.Count;

            for (int i = 0; i < columnsCount; i++)
            {
                if (columnList.Contains(dataGridView1.Columns[i]))
                {

                }
                else
                {
                    string columnName = dataGridView1.Columns[i].Name.ToString();

                    if (dataGridView1.Columns.Contains(columnName))
                        needDeleteColumnList.Add(dataGridView1.Columns[i]);
                }
            }

            if (needDeleteColumnList.Count > 0)
            {
                foreach (var column in needDeleteColumnList)
                {
                    dataGridView1.Columns.Remove(column);
                }
            }

            if (deviceDict.ContainsKey(className))
            {
                foreach (var controlCode in deviceDict[className].controlCodeDict)
                {
                    if (controlCode.Value.show)
                    {
                        if(this.dataGridView1.Columns.Contains(controlCode.Value.name))
                        {
                            continue;
                        }
                        else
                        {
                            DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                            acCode.Name = controlCode.Value.name;
                            acCode.DataPropertyName = controlCode.Value.name;
                            acCode.HeaderText = controlCode.Value.name;
                            acCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            // acCode.SortMode = DataGridViewColumnSortMode.NotSortable;
                            this.dataGridView1.Columns.Add(acCode);
                        }
                    }
                }
            }
            else
            {
                
                NlogHandler.GetSingleton().Error(string.Format("检查类型 {0}，是否在配置文件中配置过",className));
            }
        }

        /// <summary>
        /// 点击执行对应的控制码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 执行控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要执行?", "执行", messButton);

            if (dr == DialogResult.Cancel)//如果点击“确定”按钮
            {
                return;
            }

            // 如果当前类别不为空，且控制信息不为空
            if (_currentClassName != "" && comboBox_deviceControl.Text.Trim() != "")
            {
                foreach (var device in deviceDict.Values)
                {
                    if (device.deviceClassName == _currentClassName)
                    {
                        foreach (var controlInfo in device.controlCodeDict)
                        {
                            if (controlInfo.Key == comboBox_deviceControl.Text.Trim())
                            {
                                List<string> deviceList = GetCurrentCheckedRow();
                                
                                DeviceControl(deviceList, controlInfo.Value.name);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取当前选中的行的对应的name
        /// </summary>
        /// <returns></returns>
        private List<string> GetCurrentCheckedRow()
        {
            List<string> deviceList = new List<string>();

            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_CheckBox].Value) == false)
                    continue;

                if (this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value == null)
                {
                    continue;
                }

                string name = this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value.ToString();

                deviceList.Add(name);
            }

            return deviceList;
        }

        private void 类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            类型管理 form = new 类型管理();
            form.ShowDialog();
        }

        /// <summary>
        /// 根据类型名获取控制码名称.主要是查询是否配置文件中是否包含该控制码
        /// </summary>
        /// <returns> list[0]是开启设备  list[1]是关闭设备 </returns>
        public List<string> GetPowerControlName(string className)
        {
            // todo  修改这个 用GetControlByControlName代替
            // 先根据配置文件获取控制码 
            string configPowerOn = "开启设备";
            string configPowerOff = "关闭设备";

            List<string> resultList = new List<string>();

            if (deviceDict.ContainsKey(className) == false)
            {
                NlogHandler.GetSingleton().Error(string.Format("检查类型 {0} 是否在其他设备配置文件中进行配置",className));
                return resultList;
            }

            var dictTemp = 其他设备控制.GetSingleton().deviceDict[className].controlCodeDict;

            string openCode = "";
            string closeCode = "";

            var queryOpen = dictTemp.Keys.Where(x => x.Contains(configPowerOn)).Select(x => dictTemp[x]);

            if (queryOpen.Count() != 1)
            {
                NlogHandler.GetSingleton().Error("其他设备控制中，检查开启或者关闭的配置，是否有其他控制码名称包含开启设备或关闭设备");
                return resultList;
            }
            resultList.Add(configPowerOn);

            var queryClose = dictTemp.Keys.Where(x => x.Contains(configPowerOff)).Select(x => dictTemp[x]);

            if (queryClose.Count() != 1)
            {
                NlogHandler.GetSingleton().Error("其他设备控制中，检查开启或者关闭的配置，是否有其他控制码名称包含开启或关闭");
                return resultList;
            }
            resultList.Add(configPowerOff);

            return resultList;
        }

        /// <summary>
        /// 根据控制码名称和类名称获取控制码
        /// </summary>
        /// <returns></returns>
        public string GetControlCodeByControlName(string className, string controlName)
        {
            if (deviceDict.ContainsKey(className))
            {
                if (deviceDict[className].controlCodeDict.ContainsKey(controlName))
                {
                    string code = deviceDict[className].controlCodeDict[controlName].code;
                    return code;
                }
            }
            
            NlogHandler.GetSingleton().Error(string.Format("检查类型：{0} 下的控制码 {1} 是否在配置文件中存在", className, controlName));

            return "";

        }

        /// <summary>
        /// 根据设备名称获取设备类型
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public string GetClassNameByDeviceName(string deviceName)
        {
            DataRow[] dr;
            dr = ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_Name, deviceName));

            if (dr.Length != 1)
            {
                NlogHandler.GetSingleton().Error(string.Format("检查数据库中的数据，设备名为：{0} 是否存在且唯一",deviceName));
                return "";
            }

            return dr[0][DeviceControlModel.DB_CLASS].ToString();
        }

        public List<string> GetAllClassName()
        {
            List<string> classList = new List<string>();
            DataRow[] dr;
            dr = ds_device_class.Tables[0].Select();

            if (dr.Length > 0)
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    classList.Add(dr[i][DeviceControlModel.DB_CLASS].ToString());
                }
            }

            return classList;
        }

        /// <summary>
        /// 通过类型名称控制设备电源状态
        /// </summary>
        /// <param name="className"></param>
        public void ControlDevicePowerByClassName(string className, bool isOn)
        {
            List<string> controlName = 其他设备控制.GetSingleton().GetPowerControlName(className);

            if (controlName.Count < 2)
            {
                NlogHandler.GetSingleton().Error(string.Format("检查开启或关闭设备的配置信息"));
                return;
            }

            List<string> deviceList = new List<string>();

            deviceList = 其他设备控制.GetSingleton().GetDeviceListByClassName(className);

            if (deviceList == null)
            {
                NlogHandler.GetSingleton().Error(string.Format("通过className获取devicelist错误，获取值为null， className ：{0}", className));
            }
            else
            {
                if (isOn)
                    其他设备控制.GetSingleton().DeviceControl(deviceList, controlName[0]);
                else
                {
                    其他设备控制.GetSingleton().DeviceControl(deviceList, controlName[1]);
                }
            }
        }

        /// <summary>
        /// 处理需要返回值的controlCode，比如获取开关机状态等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private long timeCount = 0;
        private void timer1_Tick(object source, ElapsedEventArgs e)
        {
            timeCount += 1;
            if (timeCount > 2147483646)
            {
                timeCount = 0;
            }

            if (_currentClassName != string.Empty && _currentClassName != null)
            {
                if (deviceDict.ContainsKey(_currentClassName))
                {
                    foreach (var deviceItem in deviceDict)
                    {
                        foreach (var controlDict in deviceDict[deviceItem.Key].controlCodeDict)
                        {
                            if (controlDict.Value.show)
                            {
                                if ((int)controlDict.Value.autoExecInterval == 0)
                                    continue;

                                if (timeCount % (int)controlDict.Value.autoExecInterval == 0)
                                {
                                    Task.Run(() => DeviceControl(GetDeviceListByClassName(deviceItem.Key), controlDict.Value.name));
                                }
                            }
                        }
                    }
                }
                else
                {
                    NlogHandler.GetSingleton().Error(string.Format("检查是否在配置文件中配置了设备类型： {0}", _currentClassName));
                }
            }
            MethodInvoker mi = new MethodInvoker(() =>
            {
                ChangeDataGridViewByReturnCode();
            });

            其他设备控制.GetSingleton().BeginInvoke(mi);

        }

        /// <summary>
        /// 根据收到的控制码，来更改动态在DataGridView中添加的列
        /// </summary>
        private void ChangeDataGridViewByReturnCode()
        {
            // NlogHandler.GetSingleton().Info("执行根据控制码修改DataGridView 当中的线程 ID  " + Thread.CurrentThread.ManagedThreadId.ToString());

            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[DeviceControlModel.ColumnName_Name].Value == null)
                {
                    continue;
                }
                else
                {
                    string deviceName = this.dataGridView1.Rows[i]
                        .Cells[DeviceControlModel.ColumnName_Name].Value.ToString();

                    string deviceClassName = this.dataGridView1.Rows[i]
                        .Cells[DeviceControlModel.ColumnName_CLASS].Value.ToString();

                    if (deviceClassName != _currentClassName)
                        return;

                    if (!deviceStateDict.ContainsKey(deviceName))
                        continue;

                    foreach (var controlDict in deviceStateDict[deviceName])
                    {
                        if (this.dataGridView1.Columns.Contains(controlDict.Key) == false)
                            continue;

                        string text = "";

                        if (controlDict.Value.data == null)
                        {
                        }
                        else
                        {
                            TimeSpan subTract = DateTime.Now.Subtract(controlDict.Value.time);

                            if (subTract.TotalSeconds > 15)
                            {
                                text = "连接断开";
                            }
                            else
                            {
                                Dictionary<string, string> returnCodeDict = deviceDict[deviceClassName]
                                    .controlCodeDict[controlDict.Key].returnCodeStateDict;

                                if (returnCodeDict.TryGetValue(controlDict.Value.data, out text))
                                {

                                }
                                // 字典中模糊查找returnCode匹配项
                                else
                                {

                                    foreach (var returnCodeitem in returnCodeDict)
                                    {
                                        List<string> resList = GetRegexStringBySerialReturnCode(returnCodeitem.Key);

                                        Regex regexSameCheck = new Regex(resList[0]);

                                        if (regexSameCheck.IsMatch(controlDict.Value.data))
                                        {
                                            // 进行与运算
                                            byte[] sour = HexStringToBinary(controlDict.Value.data);
                                            byte[] dest = HexStringToBinary(resList[1]);

                                            byte[] res = new byte[sour.Length];

                                            if (sour.Length == dest.Length)
                                            {
                                                for (int j = 0; j < sour.Length; j++)
                                                {
                                                    res[j] = Convert.ToByte(sour[j] & dest[j]);
                                                }
                                            }

                                            string afterANDHexString = ByteArrayToHexString(res);

                                            Regex regexAfterANDCheck = new Regex(resList[2]);
                                            if (regexAfterANDCheck.IsMatch(afterANDHexString))
                                            {
                                                text = returnCodeitem.Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        this.dataGridView1.Rows[i].Cells[controlDict.Key].Value = text;
                    }
                }
            }
        }

        /// <summary>
        /// 串口通讯下，用输入的自定义的特殊字符串转换为通用的正则表达式
        /// </summary>
        /// <param name="source"></param>
        /// <returns>
        /// list[0]:正则表达式查找
        /// list[1]:需要与运算的string
        /// list[2]:与运算之后匹配的string
        /// </returns>
        private List<string> GetRegexStringBySerialReturnCode(string source)
        {
            List<string> resList = new List<string>();

            string returnCodeBeforeAND = "";
            string returnCodeAfterAND = "";
            string returnCodeRegexFind = "";

            string pattern = @"&.*?&.*?&";
            Regex regexY = new Regex(pattern);

            // 先判断是否包含“&”字符，取与运算
            if (regexY.IsMatch(source))
            {
                MatchCollection matches = regexY.Matches(source);

                for (int j = 0; j < matches.Count; j++)
                {
                    string match = matches[j].Value;

                    int firIndex = GetIndexOf(match, "&", 1);
                    int senIndex = GetIndexOf(match, "&", 2);
                    int thrIndex = GetIndexOf(match, "&", 3);

                    int startIndex = GetIndexOf(source, match, 1);

                    returnCodeBeforeAND = source.Replace(match,
                        match.Substring(firIndex + 1, senIndex - firIndex - 1));
                    returnCodeAfterAND = source.Replace(match,
                        match.Substring(senIndex + 1, thrIndex - senIndex - 1));

                    string temp = "";
                    for (int k = 0; k < senIndex - firIndex - 1; k++)
                    {
                        temp += ".";
                    }

                    returnCodeRegexFind = source.Replace(match, temp);
                }
            }

            // 判断是否包含“*”，替换为“.”
            returnCodeRegexFind = returnCodeRegexFind.Replace("*", ".");
            returnCodeBeforeAND = returnCodeBeforeAND.Replace("*", "F");
            returnCodeAfterAND = returnCodeAfterAND.Replace("*", ".");

            resList.Add(returnCodeRegexFind);
            resList.Add(returnCodeBeforeAND);

            resList.Add(returnCodeAfterAND);

            return resList;
        }


        /// <summary>
        /// 获取第N个字符在source中出现的位置
        /// </summary>
        /// <param name="sourch"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private int GetIndexOf(string source, string dest,int n)
        {
            int index = 0;
            int lastIndex = 0;

            for (int i = 0; i < n; i++)
            {
                index = source.IndexOf(dest, lastIndex);

                if (index == -1)
                    return index;

                lastIndex = index + 1;
            }

            return index;
        }


        /// <summary>
        /// 根据class获取devicelist
        /// </summary>
        public List<string> GetDeviceListByClassName(string className)
        {

            List<string> deviceList = new List<string>();

            if (deviceDict.ContainsKey(className))
            {

            }
            else
            {
                NlogHandler.GetSingleton().Error(string.Format("检查配置文件中其他设备信息的类型是否与数据库中的类型匹配"));
                return null;
            }

            DataRow[] dr;

            if (className == "全部")
            {
                dr = ds_device_all.Tables[0].Select();
            }
            else
            {
                dr = ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_CLASS, className));
            }

            if (dr.Length > 0)
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    string deviceName = dr[i][DeviceControlModel.DB_Name].ToString();
                    deviceList.Add(deviceName);
                }
            }

            return deviceList;
        } 

        private void 其他设备控制_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Close();
        }

        private void 方案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            方案管理 form = new 方案管理();
            form.ShowDialog();
        }


        /// <summary>
        /// 获取方案整体执行时间
        /// </summary>
        /// <param name="planName"></param>
        /// <returns></returns>
        public float GetPlanExecTime(string planName)
        {
            float totalSecondes = 0;

            try
            {
                foreach (var planDetail in planDict[planName])
                {
                    totalSecondes += deviceDict[planDetail.deviceClass].controlCodeDict[planDetail.controlCodeName].delay;
                    totalSecondes += float.Parse(planDetail.delay);

                    if (planDetail.deviceClass == "计算机")
                    {
                        if (planDetail.controlCodeName == "开机")
                        {
                            totalSecondes += float.Parse(ConfigHelper.GetSingleton().GetAppConfig("ComputerStartDelay"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("获取方案执行时间异常 {0}", e.Message));
            }



            return totalSecondes;
        }


        /// <summary>
        /// 执行方案
        /// </summary>
        /// <param name="planName"></param>
        public void ExecPlan(string planName)
        {
            try
            {
                // 获取方案名称
                if (planDict.ContainsKey(planName))
                {
                    // 获取方案中所有设备信息
                    foreach (var planDetail in planDict[planName])
                    {
                        // 由于控制计算机启动的方法是单列出来的，需要单独处理
                        if (planDetail.deviceClass == "计算机")
                        {
                            // 根据已有的方案控制开关机
                            主界面.GetSingleton().ComboBoxGroupSelectChange(planDetail.groupName);
                            if (planDetail.controlCodeName == "开机")
                            {
                                主界面.GetSingleton().DoAction("开机");
                            }
                            else if (planDetail.controlCodeName == "关机")
                            {
                                主界面.GetSingleton().DoAction("关机");
                            }
                        }

                        NlogHandler.GetSingleton().Info(string.Format("设备控制。  分组：{0}， 类型：{1}， 控制名称：{2} 开始执行", planDetail.groupName, planDetail.deviceClass, planDetail.controlCodeName));

                        // 分组, 设备名, 操作类型
                        DeviceControl(GetDeviceListByGroupAndClass(planDetail.groupName, planDetail.deviceClass),planDetail.controlCodeName);

                        NlogHandler.GetSingleton().Info(string.Format("设备控制。  分组：{0}， 类型：{1}， 控制名称：{2} 执行完成", planDetail.groupName, planDetail.deviceClass, planDetail.controlCodeName));

                        if (int.Parse(planDetail.delay) > 0)
                        {
                            Thread.Sleep(1000 * int.Parse(planDetail.delay));
                        }
                    }
                }
                else
                {
                    NlogHandler.GetSingleton().Error(string.Format("输入的 计划方案名称 {0} 并没有在配置文件中存在，请检查", planName));
                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("方案执行出现错误。 {0}", e.Message.ToString()));
            }


        }

        /// <summary>
        /// 从xml中读取设备方案信息
        /// </summary>
        public void GetDevicePlanInfo()
        {
            planDict.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/DevicePlan";

            List<XmlNode> planNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            for (int i = 0; i < planNodes.Count; i++)
            {
                string planName = XmlUtil.GetAttribute(planNodes[i], "name", "");

                List<PlanStruct> planStructList = new List<PlanStruct>();

                List<XmlNode> childNodes = XmlUtil.GetChildNodes(planNodes[i], "", "");

                for (int j = 0; j < childNodes.Count; j++)
                {
                    PlanStruct planStructTemp = new PlanStruct();

                    planStructTemp.groupName = XmlUtil.GetAttribute(childNodes[j], "GroupName", "");
                    planStructTemp.deviceClass = XmlUtil.GetAttribute(childNodes[j], "DeviceClass", "");
                    planStructTemp.controlCodeName = XmlUtil.GetAttribute(childNodes[j], "ControlCodeName", "");
                    planStructTemp.delay = XmlUtil.GetAttribute(childNodes[j], "Delay", "");

                    planStructList.Add(planStructTemp);
                }

                planDict[planName] = planStructList;
            }
        }

        /// <summary>
        /// 根据分组信息和设备类别获取设备列表
        /// </summary>
        /// <returns></returns>
        private List<string> GetDeviceListByGroupAndClass(string groupName, string className)
        {

            if (groupDict.ContainsKey(groupName) && deviceDict.ContainsKey(className))
            {
                string deviceNames = "";

                foreach (string deviceName in groupDict[groupName])
                {
                    deviceNames += string.Format("'{0}',", deviceName);
                }

                // 删除最后一个逗号
                deviceNames = deviceNames.Substring(0, deviceNames.Length - 1);

                DataRow[] dr = ds_device_all.Tables[0]
                    .Select(string.Format("{0} in ({1}) and {2} = '{3}'", DeviceControlModel.DB_Name, deviceNames, DeviceControlModel.DB_CLASS, className));

                List<string> deviceList = new List<string>();
                for (int i = 0; i < dr.Length; i++)
                {
                    deviceList.Add(dr[i][DeviceControlModel.DB_Name].ToString());
                }

                return deviceList;
            }

            return null;
        }

        private void 输入查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            设备输入数据.GetSingleton().ShowDialog();
        }

        private void 其他设备控制_KeyDown(object sender, KeyEventArgs e)
        {
            //如果同时按下了 弹出信息框
            if (e.Alt && e.KeyCode == Keys.I)
            {
                if (ConfigHelper.GetSingleton().GetAppConfig("PCI1710Enable") == "1")
                {
                    设备输入数据.GetSingleton().ShowDialog();
                }
            }

            //如果同时按下了 ctrl键和S键，弹出4D座椅调试界面
            if (e.Alt && e.KeyCode == Keys.S)
            {
                _4D座椅 form = new _4D座椅();
                form.ShowDialog();
            }
        }

        private void d座椅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _4D座椅 form = new _4D座椅();
            form.ShowDialog();

        }
    }

    /// <summary>
    /// 设备结构体
    /// </summary>
    public class DeviceStruct
    {
        // 设备名称
        public string deviceClassName;
        // 控制类型 网口 串口
        public string controlType;
        // 是否使用16进制形式进行控制码输入
        public bool isHex;
        // 波特率
        public int buad;
        // 端口号
        public int port;
        // 控制码
        public Dictionary<string, CodeStruct> controlCodeDict = new Dictionary<string, CodeStruct>();

        // 控制码结构体
        public class CodeStruct
        {
            // 控制码名称
            public string name;
            // 控制码
            public string code;
            // 设备控制启动延迟时间
            public float delay;
            // 自动执行间隔
            public float autoExecInterval;
            // 是否显示到DataGridView
            public bool show;
            // 控制码返回值  <返回值， 显示值>
            public Dictionary<string, string> returnCodeStateDict = new Dictionary<string, string>();

        }
    }

    /// <summary>
    /// 计划方案结构体
    /// </summary>
    public class PlanStruct
    {
        public string groupName;
        public string deviceClass;
        public string controlCodeName;
        public string delay;
    }

    public class NetRecvStruct
    {
        public string data;
        public DateTime time;
    }


}
