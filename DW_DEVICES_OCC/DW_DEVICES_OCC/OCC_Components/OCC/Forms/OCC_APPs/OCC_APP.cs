using DataCache;
using DataModel;
using OCC.Core;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms
{
    public partial class OCC_APP : UIPage
    {
        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        #region 单例
        private static OCC_APP s_instance = null;
        private static readonly object syslock = new object();
        public static OCC_APP Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC_APP();
                        }
                    }
                }
                return s_instance;
            }
        }

        #endregion

        public OCC_APP()
        {
            UiContext = SynchronizationContext.Current;

            InitializeComponent();

            RefreshDataModel();
        }

        /// <summary>
        /// 刷新数据模型
        /// </summary>
        public void RefreshDataModel()
        {
            DataManager.Instance.GetAppData();
            AppDataGridViewInitialize();

            UiContext.Post(OCC_Main.Instance.ComboBoxAppInitialize, null);
        }

        /// <summary>
        /// 初始化APP列表
        /// </summary>
        private void AppDataGridViewInitialize()
        {
            DataGridViewApp.Rows.Clear();         
            if (DataManager.Instance.AppDeviceBindedCollection.Count > 0)
            {
                DataGridViewApp.Rows.Add(DataManager.Instance.AppDeviceBindedCollection.Count);
                for (int i = 0; i < DataManager.Instance.AppDeviceBindedCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.AppDeviceBindedCollection[i].AppData.AppName}");
                    DataGridViewApp.Rows[i].Tag = DataManager.Instance.AppDeviceBindedCollection[i];
                    DataGridViewApp.Rows[i].Cells["AppName"].Value = DataManager.Instance.AppDeviceBindedCollection[i].AppData.AppName;
                    DataGridViewApp.Rows[i].Cells["Remark"].Value = DataManager.Instance.AppDeviceBindedCollection[i].AppData.Remark;                   
                }

                //默认显示第一个APP所绑定的设备列表
                DeviceDataGridViewInitialize(DataManager.Instance.AppDeviceBindedCollection[0]);
            }
        }

        /// <summary>
        /// 初始化设备绑定列表
        /// </summary>
        /// <param name="data"></param>
        private void DeviceDataGridViewInitialize(AppDeviceBindedCache data)
        {
            DataGridViewDeviceBinded.Rows.Clear();
            if (data.DeviceBindData.Count > 0)
            {
                DataGridViewDeviceBinded.Rows.Add(data.DeviceBindData.Count);
                for (int i = 0; i < data.DeviceBindData.Count; i++)
                {
                    Debug.Info($" index {i} {data.DeviceBindData[i].Id} {data.DeviceBindData[i].DeviceId} {data.DeviceBindData[i].Path}");
                    var deviceData = DataManager.Instance.GetDeviceDataById(data.DeviceBindData[i].DeviceId);
                    DataGridViewDeviceBinded.Rows[i].Tag = data.DeviceBindData[i];
                    DataGridViewDeviceBinded.Rows[i].Cells["DeviceName"].Value = deviceData.DataModel.Name;
                    DataGridViewDeviceBinded.Rows[i].Cells["InstalledPath"].Value = data.DeviceBindData[i].Path;
                }
            }
        }

        #region Button Events

        /// <summary>
        /// 添加APP按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddApp_Click(object sender, EventArgs e)
        {
            OCC_APPDetail userDetailForm = new OCC_APPDetail();
            userDetailForm.Owner = this;
            userDetailForm.Text = "添加系统";
            
            userDetailForm.ShowDialogWithMask();

        }

        /// <summary>
        /// 删除APP按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteApp_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 编辑APP按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditApp_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 添加设备绑定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDeviceBind_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除设备绑定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteDeviceBind_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 编辑设备绑定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditDeviceBind_Click(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// 获取当前选择的行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Info($"Select Row {e.RowIndex}");

            if (e.RowIndex.Equals(-1))
                return;

            var appDeviceBindedCache = DataGridViewApp.Rows[e.RowIndex].Tag as AppDeviceBindedCache;

            if (null != appDeviceBindedCache)
            {
                DeviceDataGridViewInitialize(appDeviceBindedCache);
            }
        }
    }
}
