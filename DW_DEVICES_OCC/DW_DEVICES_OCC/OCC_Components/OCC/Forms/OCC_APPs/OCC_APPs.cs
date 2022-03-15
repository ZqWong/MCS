using DataModel;
using OCC.Core;
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

namespace OCC.Forms.OCC_APPs
{
    public partial class OCC_APPs : Form
    {
        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        #region 单例
        private static OCC_APPs s_instance = null;
        private static readonly object syslock = new object();
        public static OCC_APPs Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC_APPs();
                        }
                    }
                }
                return s_instance;
            }
        }

        #endregion


        public OCC_APPs()
        {
            InitializeComponent();

            RefreshDataModel();
        }


        public void RefreshDataModel()
        {
            DataManager.Instance.GetAppData();
            DataGridViewInitialize();
        }


        private void DataGridViewInitialize()
        {
            DataGridViewApp.Rows.Clear();
            DataGridViewApp.Rows.Add(DataManager.Instance.AppDeviceBindedCollection.Count);

            if (DataManager.Instance.AppDeviceBindedCollection.Count > 0)
            {
                for (int i = 0; i < DataManager.Instance.AppDeviceBindedCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.AppDeviceBindedCollection[i].AppData.AppName}");
                    DataGridViewApp.Rows[i].Tag = DataManager.Instance.AppDeviceBindedCollection[i];
                    DataGridViewApp.Rows[i].Cells["AppName"].Value = DataManager.Instance.AppDeviceBindedCollection[i].AppData.AppName;
                    DataGridViewApp.Rows[i].Cells["Remark"].Value = DataManager.Instance.AppDeviceBindedCollection[i].AppData.Remark;                   
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
    }
}
