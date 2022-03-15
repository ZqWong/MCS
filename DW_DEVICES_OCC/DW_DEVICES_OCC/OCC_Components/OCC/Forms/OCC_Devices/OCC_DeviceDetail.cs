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
    public partial class OCC_DeviceDetail : UIEditForm
    {
        private bool isEdit = false;
        private DeviceDataModel deviceData;
        public DeviceDataModel DeviceData
        {
            get
            {
                if (null == deviceData)
                {
                    deviceData = new DeviceDataModel();
                    deviceData.Id = Guid.NewGuid().ToString();
                    deviceData.Name = TextBoxDeviceName.Text;
                    deviceData.IP = TextBoxIP.Text;
                    deviceData.MAC = TextBoxMAC.Text;
                    deviceData.Remark = TextBoxRemark.Text;
                    deviceData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                    deviceData.CreateTime = DataBaseManager.Instance.DB.GetDate();
                    DeviceData.DelFlag = "0";
                }
                isEdit = false;
                return deviceData;
            }
            set
            {
                if (null == deviceData)
                {
                    deviceData = new DeviceDataModel();
                }
                isEdit = true;
                deviceData.Id = value.Id;
                deviceData.Name = value.Name;
                deviceData.MAC = value.MAC;
                deviceData.IP = value.IP;
                deviceData.Remark = value.Remark;
                deviceData.DeviceType = value.DeviceType;
                deviceData.Updateby = value.Updateby;
                deviceData.UpdateTime = value.UpdateTime;
                deviceData.CreateBy = value.CreateBy;
                deviceData.CreateTime = value.CreateTime;
                deviceData.DelFlag = value.DelFlag;

                ViewUIIfHasData();
            }

        }

        /// <summary>
        /// 字段检测
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            return CheckEmpty(TextBoxDeviceName, "请输入设备名")
                && CheckEmpty(TextBoxIP, "请输入设备IP")
                && CheckEmpty(ComboBoxDeviceType, "请选择有效设备类型");
        }


        public OCC_DeviceDetail()
        {
            InitializeComponent();
  
            foreach (var item in DataManager.Instance.DeviceTypeCollection)
            {
                ComboBoxDeviceType.Items.Add(item.Name);
            }

            ComboBoxDeviceType.SelectedIndex = 0;

            ButtonOkClick += ButtonOkClickHandler;            
        }

        /// <summary>
        /// 如果以后数据则直接刷新在UI上
        /// </summary>
        private void ViewUIIfHasData()
        {
            var deviceType = DataManager.Instance.DeviceTypeCollection.FirstOrDefault(t => t.Id.Equals(deviceData.DeviceType));
            ComboBoxDeviceType.SelectedItem = deviceType.Name;
            TextBoxRemark.Text = deviceData.Remark;
            TextBoxDeviceName.Text = deviceData.Name;
            TextBoxIP.Text = deviceData.IP;
            TextBoxMAC.Text = deviceData.MAC;
        }


        /// <summary>
        /// 新建设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOkClickHandler(object sender, EventArgs e)
        {
            var deviceType = DataManager.Instance.DeviceTypeCollection.FirstOrDefault(t => t.Name.Equals(ComboBoxDeviceType.SelectedItem));
            if (null == deviceType)
            {
                ShowWarningDialog("请选择正确的设备类型", false);
                return;
            }
            if (!isEdit)
            {
                DeviceData.Id = Guid.NewGuid().ToString();
            }            
            DeviceData.Name = TextBoxDeviceName.Text;
            DeviceData.DeviceType = deviceType.Id;
            DeviceData.IP = TextBoxIP.Text;
            DeviceData.MAC = TextBoxMAC.Text;
            DeviceData.Remark = TextBoxRemark.Text;
            if (!isEdit)
            {
                DeviceData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                DeviceData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            }
            DeviceData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            DeviceData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            DeviceData.DelFlag = "0";
            try
            {
                if (!DataBaseCRUDManager.Instance.TryCreateOrUpdateDeviceInfo(DeviceData))
                {
                    Debug.Info($"Create a new user {DeviceData}");
                }
                
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog();
                msg.Message = $"创建新设备失败(ex: {ex})";
                msg.ShowDialog();
                return;                
            }

            var owner = Owner as OCC_Device;
            owner.DeviceListInitialize();
            Close();
        }

        private void TextBoxIP_Leave(object sender, EventArgs e)
        {
            var mac = NetworkHelper.GetMacAddress(TextBoxIP.Text);
            DeviceData.MAC = mac;
            TextBoxMAC.Text = mac;
        }
    }
}
