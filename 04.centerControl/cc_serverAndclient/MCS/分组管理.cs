using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Common.Model;
using CommonTools.tools;
using MCS.DB.BLL;

namespace MCS
{
    public partial class 分组管理 : Form
    {
        // 分组信息
        public Dictionary<string, List<string>> groupDirt = new Dictionary<string, List<string>>();

        ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();
        DeviceControlInfoBLL _GetDeviceInfoBLL = new DeviceControlInfoBLL();

        // 当前选择分组
        private string _currentSelectGroup;

        public 分组管理()
        {
            InitializeComponent();

            GetGroupInfoFormXml();
        }

        private void 分组管理_Load(object sender, EventArgs e)
        {
            // 下拉列表添加
            this.comboBox_Group.Items.Clear();

            foreach (var group in groupDirt)
            {
                this.comboBox_Group.Items.Add(group.Key);
            }
        }

        /// <summary>
        /// 从xml文件中读取分组信息到内存中
        /// </summary>
        public void GetGroupInfoFormXml()
        {
            groupDirt.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            for (int i = 0; i < groupNodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(groupNodes[i], "name", "");

                if (!groupDirt.ContainsKey(groupName))
                    groupDirt.Add(groupName, new List<string>());

                List<XmlNode> childNodes = XmlUtil.GetChildNodes(groupNodes[i], "", "");

                for (int j = 0; j < childNodes.Count; j++)
                {
                    //string type = XmlUtil.GetAttribute(childNodes[j], "type", "");

                    string deviceName = XmlUtil.GetAttribute(childNodes[j], "name", "");

                    if (!groupDirt[groupName].Contains(deviceName))
                        groupDirt[groupName].Add(deviceName);
                }
            }

        }

        private void comboBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清空checkboxlist
            this.checkedListBox_Group.Items.Clear();

            _currentSelectGroup = this.comboBox_Group.SelectedItem.ToString();

            // 添加到左面的信息列表
            foreach (var deviceInfo in groupDirt[_currentSelectGroup])
            {
                this.checkedListBox_Group.Items.Add(deviceInfo);
            }

            updateCheckBoxAll();
        }

        /// <summary>
        /// 根据checkedListBox_Group的信息更新checkedListBox_All
        /// </summary>
        private void updateCheckBoxAll()
        {
            this.checkedListBox_All.Items.Clear();

            // 添加到右边的全部信息列表
            DataSet ds_pc_info = _ExaminationPCBLL.GetAllExaminationPCInfo();
            DataSet ds_pdevice_info = _GetDeviceInfoBLL.GetDeviceInfo();

            foreach (DataRow row in ds_pc_info.Tables[0].Rows)
            {
                string pcName = row[ExaminationPCModel.ColumnName_ExamPCName].ToString();

                int index = this.checkedListBox_Group.FindString(pcName);

                if (index >= 0)
                {
                }
                else
                {
                    this.checkedListBox_All.Items.Add(row[ExaminationPCModel.ColumnName_ExamPCName].ToString());
                }
            }

            foreach (DataRow row in ds_pdevice_info.Tables[0].Rows)
            {
                string deviceName = row[DeviceControlModel.DB_Name].ToString();

                int index = this.checkedListBox_Group.FindString(deviceName);

                if (index >= 0)
                {
                }
                else
                {
                    this.checkedListBox_All.Items.Add(row[DeviceControlModel.DB_Name].ToString());
                }
            }

            // 将分组信息中包含的设备但是已不再最新设备清单上的变灰
            for (int i = 0; i < this.checkedListBox_Group.Items.Count; i++)
            {
                string item = this.checkedListBox_Group.Items[i].ToString();

                if (ds_pc_info.Tables[0].Select(string.Format("{0} = '{1}'", ExaminationPCModel.ColumnName_ExamPCName, item)).Length > 0
                    || ds_pdevice_info.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_Name, item)).Length > 0)
                {

                }
                else
                {
                    this.checkedListBox_Group.SetItemCheckState(i, CheckState.Indeterminate);
                }
            }
        }

        private void checkedListBox_Group_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (e.CurrentValue == CheckState.Indeterminate)
            //{
            //    e.NewValue = CheckState.Unchecked;
            //    e.NewValue = CheckState.Indeterminate;
            //}
        }

        /// <summary>
        /// 点击后删除现有group并更新all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_right_Click(object sender, EventArgs e)
        {
            List<string> removeList = new List<string>();

            foreach (int index in this.checkedListBox_Group.CheckedIndices)
            {
                if (this.checkedListBox_Group.GetItemCheckState(index) == CheckState.Indeterminate)
                {
                }
                else
                {
                    removeList.Add(this.checkedListBox_Group.Items[index].ToString());
                }
            }

            if (removeList.Count > 0)
            {
                foreach (string name in removeList)
                {
                    this.checkedListBox_Group.Items.Remove(name);
                }
            }

            updateCheckBoxAll();
        }

        /// <summary>
        /// 点击后删除现有all并更新group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_left_Click(object sender, EventArgs e)
        {

            foreach (string item in this.checkedListBox_All.CheckedItems)
            {
                this.checkedListBox_Group.Items.Add(item);
            }

            updateCheckBoxAll();
        }

        /// <summary>
        /// 创建分组按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_Click(object sender, EventArgs e)
        {
            string newGroupName = this.comboBox_Group.Text;

            if (newGroupName == "")
            {
                if (e != null)
                    MessageBox.Show("请输入要创建分组的名称");

                return;
            }

            if (this.comboBox_Group.FindString(newGroupName) >= 0)
            {
                if (e != null)
                    MessageBox.Show("分组名称已经存在");

                return;
            }

            var xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            XmlNode node = xmlDoc.SelectSingleNode(selectNode);

            XmlNode newNode = XmlUtil.AppendElement(node,"Group", "");

            XmlUtil.SetAttribute(newNode,"name", newGroupName);

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        /// <summary>
        /// 保存分组信息到配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            // 在xml中查找是否包含节点，不包含就创建

            // 该组名不是新建组
            // button_create_Click(null,null);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            int i = 0;

            for (i = 0; i < groupNodes.Count; i++)
            {
                string groupName = XmlUtil.GetAttribute(groupNodes[i], "name", "");

                string groupNewName = this.comboBox_Group.Text;

                if (groupName == _currentSelectGroup)
                {
                    // 删除节点
                    groupNodes[i].RemoveAll();
                    XmlUtil.SetAttribute(groupNodes[i], "name", groupNewName);

                    foreach (string deviceItem in this.checkedListBox_Group.Items)
                    {
                        XmlNode newNode = XmlUtil.AppendElement(groupNodes[i], "Device", "");

                        XmlUtil.SetAttribute(newNode, "name", deviceItem);
                    }

                    break;
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            button_refresh_Click(null, null);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_refresh_Click(object sender, EventArgs e)
        {
            GetGroupInfoFormXml();

            分组管理_Load(null, null);
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除分组？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            XmlNode startUpGroupNode = xmlDoc.SelectSingleNode(selectNode);

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            int i = 0;

            for (i = 0; i < groupNodes.Count; i++)
            {
                string groupName = XmlUtil.GetAttribute(groupNodes[i], "name", "");

                if (groupName == this.comboBox_Group.Text)
                {
                    startUpGroupNode.RemoveChild(groupNodes[i]);

                    break;
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            button_refresh_Click(null, null);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
