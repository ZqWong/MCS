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
    public partial class OCC_APPDeviceBind : UIEditForm
    {
        private OCC_APP parent;
        private AppDeviceBindedCache appDeviceBindedCache;

        public OCC_APPDeviceBind()
        {

            InitializeComponent();


            ButtonOkClick += OCC_APPDeviceBind_ButtonOkClick;
        }

        private void OCC_APPDeviceBind_Load(object sender, EventArgs e)
        {
            parent = Owner as OCC_APP;

            appDeviceBindedCache = parent.CurrentSelectedAppDeviceData;

            UIInitialize();
        }


        private void OCC_APPDeviceBind_ButtonOkClick(object sender, EventArgs e)
        {
            List<AppDeviceBindDataModel> deviceBindedCollection = new List<AppDeviceBindDataModel>();
            
            for (int i = 0; i < DataGridViewDeviceBinded.Rows.Count; i++)
            {
                var dataModel = DataGridViewDeviceBinded.Rows[i].Tag as AppDeviceBindDataModel;
                dataModel.Path = DataGridViewDeviceBinded.Rows[i].Cells["Path"].Value.ToString();
                if (!string.IsNullOrEmpty(dataModel.Path))
                {
                    deviceBindedCollection.Add(dataModel);
                }
            }

            try
            {
                appDeviceBindedCache.AppData.AppName = TextBoxAppName.Text;
                appDeviceBindedCache.AppData.Remark = TextBoxRemark.Text;
                if (!DataBaseCRUDManager.Instance.TryUpdateAppInfoById(appDeviceBindedCache.AppData))
                {
                    ShowErrorNotifier($"更新系统基本信息失败！");
                }
                else
                {
                    ShowSuccessNotifier($"更新系统基本信息成功！");
                }
                if(!DataBaseCRUDManager.Instance.TryCreateOrUpdateAppDeviceBindInfo(deviceBindedCollection))
                {
                    ShowErrorNotifier($"更新系统绑定信息失败！");
                }
                else
                {
                    ShowSuccessNotifier($"更新系统绑定信息成功！");
                }            
            }
            catch (Exception ex)
            {
                ShowErrorNotifier($"更新系统基本信息发生错误 {ex}");
                throw;
            }

            parent.RefreshDataModel();
            Close();
        }

        /// <summary>
        /// 表格刷新
        /// </summary>
        private void UIInitialize()
        {
            TextBoxAppName.Text = appDeviceBindedCache.AppData.AppName;
            TextBoxRemark.Text = appDeviceBindedCache.AppData.Remark;

            DataGridViewDeviceBinded.Rows.Clear();

            // 获取全部PC机
            var device = DataManager.Instance.DeviceInfoCollection.FindAll(d => d.DataModel.DeviceType.Equals(1));
            DataGridViewDeviceBinded.Rows.Add(device.Count);

            for (int i = 0; i < device.Count; i++)
            {
                DataGridViewDeviceBinded.Rows[i].Cells["DeviceName"].Value = device[i].DataModel.Name;

                var exist = appDeviceBindedCache.DeviceBindData.FirstOrDefault(ad => ad.DeviceId.Equals(device[i].DataModel.Id));
                if (null != exist)
                {
                    DataGridViewDeviceBinded.Rows[i].Cells["Path"].Value = exist.Path;
                    DataGridViewDeviceBinded.Rows[i].Tag = exist;
                }
                else
                {
                    DataGridViewDeviceBinded.Rows[i].Cells["Path"].Value = string.Empty;
                    AppDeviceBindDataModel newDeviceBind = new AppDeviceBindDataModel();
                    newDeviceBind.AppId = appDeviceBindedCache.AppData.Id;
                    newDeviceBind.DeviceId = device[i].DataModel.Id;
                    DataGridViewDeviceBinded.Rows[i].Tag = newDeviceBind;

                    newDeviceBind.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                    newDeviceBind.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
                    newDeviceBind.CreateTime = DataBaseManager.Instance.DB.GetDate();
                    newDeviceBind.UpdateTime= DataBaseManager.Instance.DB.GetDate();
                    newDeviceBind.DelFlag = "0";
                }
            }
        }

        private void DataGridViewDeviceBinded_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dataModel = DataGridViewDeviceBinded.Rows[e.RowIndex].Tag as AppDeviceBindDataModel;
            dataModel.Path = DataGridViewDeviceBinded.Rows[e.RowIndex].Cells["Path"].Value.ToString();
            DataGridViewDeviceBinded.Rows[e.RowIndex].Tag = dataModel;
        }


    }
}
