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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms
{
    public partial class OCC_APPDetail : UIEditForm
    {
        private bool isEdit = false;
        private AppDataModel appData;

        public AppDataModel AppData
        {
            get
            {
                if (null == appData)
                {
                   appData = new AppDataModel();
                   //appData.Id = Guid.NewGuid().ToString();
                   appData.AppName = TextBoxAppName.Text;
                   appData.Remark = TextBoxRemark.Text;
                   appData.CreateBy = Core.DataManager.Instance.CurrentLoginUserData.UserName;
                   appData.CreateTime = DataBaseManager.Instance.DB.GetDate();
                   appData.DelFlag = "0";
                }
                isEdit = false;
                return appData;
            }
            set
            {
                if (null == appData)
                {
                    appData = new AppDataModel();
                }
                isEdit = true;
                appData.Id = value.Id;
                appData.AppName = value.AppName;
                appData.Remark = value.Remark;
                appData.Updateby = value.Updateby;
                appData.UpdateTime = value.UpdateTime;
                appData.CreateBy = value.CreateBy;
                appData.CreateTime = value.CreateTime;
                appData.DelFlag = value.DelFlag;

                ViewUIIfHasData();
            }
        }


        /// <summary>
        /// 如果以后数据则直接刷新在UI上
        /// </summary>
        private void ViewUIIfHasData()
        {
            TextBoxAppName.Text = appData.AppName;
            TextBoxRemark.Text = appData.Remark;

            //DataManager.Instance.DeviceInfoCollection.All(d => d.DataModel.DeviceType.Equals())
        }

        public OCC_APPDetail()
        {
            InitializeComponent();

            ButtonOkClick += ButtonOkClickHandler;


            CheckBoxGroupDeviceUIInitialize();
           
        }

        private void CheckBoxGroupDeviceUIInitialize()
        {
            var windowsDevices = DataManager.Instance.DeviceInfoCollection.FindAll(d => d.DataModel.DeviceType.Equals(1));

            if (windowsDevices.Count > 0)
            {
                DataGridViewDeviceBind.Rows.Add(windowsDevices.Count);

                for (int i = 0; i < windowsDevices.Count; i++)
                {
                    DataGridViewDeviceBind.Rows[i].Tag = windowsDevices[i];
                    DataGridViewDeviceBind.Rows[i].Cells["DeviceName"].Value = windowsDevices[i].DataModel.Name;
                }
            }
        }

        private void ButtonOkClickHandler(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                //AppData.Id = Guid.NewGuid().ToString();
                AppData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                AppData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            }

            var defaultPath = TextBoxPath.Text;

            AppData.AppName = TextBoxAppName.Text;
            AppData.Remark = TextBoxRemark.Text;
            AppData.AppPath = defaultPath;
            AppData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            AppData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            AppData.DelFlag = "0";
         
            try
            {
                var newApp = DataBaseCRUDManager.Instance.TryCreateOrUpdateAppInfo(AppData);

                if (null != newApp)
                {
                    List<AppDeviceBindDataModel> appDeviceBindCollection = new List<AppDeviceBindDataModel>();

                    for (int i = 0; i < DataGridViewDeviceBind.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(DataGridViewDeviceBind.Rows[i].Cells["Selected"].Value) == true)
                        {
                            var deviceData = DataGridViewDeviceBind.Rows[i].Tag as DeviceStatusCache;
                            Debug.Info($"DataGridViewDeviceBind.Rows {deviceData.DataModel.Name}");
                            AppDeviceBindDataModel appDeviceBind = new AppDeviceBindDataModel();

                            appDeviceBind.AppId = newApp.Id;
                            appDeviceBind.DeviceId = deviceData.DataModel.Id;
                            appDeviceBind.Path = defaultPath;

                            appDeviceBind.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                            appDeviceBind.CreateTime = DataBaseManager.Instance.DB.GetDate();
                            appDeviceBind.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
                            appDeviceBind.UpdateTime = DataBaseManager.Instance.DB.GetDate();
                            appDeviceBind.DelFlag = "0";

                            appDeviceBindCollection.Add(appDeviceBind);
                        }
                    }
                    try
                    {
                        Debug.Info($"appDeviceBindCollection {appDeviceBindCollection.Count}");
                        DataBaseCRUDManager.Instance.TryCreateAppAndDeviceBindInfo(appDeviceBindCollection);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorNotifier($"创建系统设备绑定数据失败: \n{ex}");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorNotifier($"创建系统设备绑定数据失败: \n{ex}");
                return;
            }

            ShowSuccessNotifier($"添加系统信息成功 \n{AppData.AppName}");

            var occApp = Owner as OCC_APP;
            occApp.RefreshDataModel();
            Close();
        }
    }
}
