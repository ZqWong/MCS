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

        public OCC_APPDetail()
        {
            InitializeComponent();
        }

        public AppDataModel AppData
        {
            get
            {
                if (null == appData)
                {
                   appData = new AppDataModel();
                   appData.Id = Guid.NewGuid().ToString();
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



    }
}
