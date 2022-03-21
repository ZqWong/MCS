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
    public partial class OCC_GroupDetail : UIEditForm
    {
        private bool isEdit = false;
        
        private GroupDataModel groupData;

        public GroupDataModel GroupData
        {
            get
            {
                if (null == groupData)
                {
                    groupData = new GroupDataModel();
                    groupData.CompanyId = DataManager.Instance.GetCompanyIdByName(ComboBoxGroupCompany.SelectedText);
                    groupData.Name = TextBoxGroupName.Text;
                    groupData.Remark = TextBoxRemark.Text;
                    groupData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                    groupData.CreateTime = DataBaseManager.Instance.DB.GetDate();
                    groupData.DelFlag = "0";
                }
                isEdit = false;
                return groupData;
            }
            set
            {
                if (null == groupData)
                {
                    groupData = new GroupDataModel();
                }
                isEdit = true;

                groupData.Id = value.Id;
                groupData.CompanyId = value.CompanyId;
                groupData.Name = value.Name;
                groupData.Remark = value.Remark;
                groupData.Updateby = value.Updateby;
                groupData.UpdateTime = value.UpdateTime;
                groupData.CreateBy = value.CreateBy;
                groupData.CreateTime = value.CreateTime;
                groupData.DelFlag = value.DelFlag;

                ViewUIIfHasData();
            }

        }

        private void ViewUIIfHasData()
        {
            ComboBoxGroupCompany.SelectedItem = DataManager.Instance.GetCompanyNameById(groupData.CompanyId);
            TextBoxGroupName.Text = groupData.Name;
            TextBoxRemark.Text = groupData.Remark;
        }

        public OCC_GroupDetail()
        {
            InitializeComponent();

            foreach (var company in DataManager.Instance.CompanyDatas)
            {
                ComboBoxGroupCompany.Items.Add(company.Name);
            }        
            ButtonOkClick += ButtonOkClickHandler;
        }

        private void ButtonOkClickHandler(object sender, EventArgs e)
        {
            var company = DataManager.Instance.CompanyDatas.FirstOrDefault(t => t.Name.Equals(ComboBoxGroupCompany.SelectedItem));
            if (null == company)
            {
                ShowWarningDialog("请选择正确的所属公司", false);
                return;
            }
            if (!isEdit)
            {
                GroupData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                GroupData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            }

            GroupData.Name = TextBoxGroupName.Text;
            GroupData.Remark = TextBoxRemark.Text;
            GroupData.CompanyId = company.Id;

            GroupData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            GroupData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            GroupData.DelFlag = "0";
            try
            {
                if (isEdit)
                {
                    try
                    {
                        DataBaseCRUDManager.Instance.TryUpdateGroupInfoById(GroupData);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    try
                    {
                        DataBaseCRUDManager.Instance.TryCreateGroupInfo(GroupData);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }                                      
                }                
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog();
                msg.Message = $"创建新设备失败(ex: {ex})";
                msg.ShowDialog();
                return;
            }

            var owner = Owner as OCC_Group;
            owner.RefreshDataModel();
            //owner.DeviceListInitialize();
            Close();
        }
    }
}
