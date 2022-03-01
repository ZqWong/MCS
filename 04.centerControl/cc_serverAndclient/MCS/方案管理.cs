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

namespace MCS
{
    public partial class 方案管理 : Form
    {
        public 方案管理()
        {
            InitializeComponent();
        }

        private void 方案管理_Load(object sender, EventArgs e)
        {
            // 添加已有的控制plan
            AddComboboxCommon(this.comboBox_plan, "/configuration/DevicePlan", "name");
            // 给DataGridView中的comboxplan添加信息
            AddDataGridViewComboboxCommon(this.GroupName, "/configuration/StartUpGroup", "name");
            // 给DataGridView中的DeviceClass添加信息
            AddDataGridViewComboboxCommon(this.DeviceClass, "/configuration/DeviceControl", "name");

        }

        /// <summary>
        /// 向DataGridView中添加combox的通用方法
        /// selectChildNodeName:如果不为空，则表示查找selectNode的属性name为selectChildNodeName的子节点。相当于多向下查找一级。
        /// </summary>
        private void AddDataGridViewComboboxCommon(DataGridViewComboBoxColumn combox, string selectNode, string attrName, string selectChildNodeName = "")
        {
            combox.Items.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            List<XmlNode> nodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            combox.Items.Add("");

            for (int i = 0; i < nodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(nodes[i], attrName, "");

                if (selectChildNodeName == "")
                {
                    combox.Items.Add(groupName);
                }
                else if (groupName == selectChildNodeName)
                {
                    List<XmlNode> childNodes = XmlUtil.GetChildNodes(nodes[i], "", "");

                    for (int j = 0; j < childNodes.Count; j++)
                    {
                        String clildName = XmlUtil.GetAttribute(childNodes[j], attrName, "");

                        if (childNodes.Count > 0)
                        {
                            combox.Items.Add(clildName);
                        }
                    }
                }
            }
        }


        private void AddDataGridViewComboboxCommon(DataGridViewComboBoxCell combox, string selectNode, string attrName, string selectChildNodeName = "")
        {
            combox.Items.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            List<XmlNode> nodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            combox.Items.Add("");

            for (int i = 0; i < nodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(nodes[i], attrName, "");

                if (selectChildNodeName == "")
                {
                    combox.Items.Add(groupName);
                }
                else if (groupName == selectChildNodeName)
                {
                    List<XmlNode> childNodes = XmlUtil.GetChildNodes(nodes[i], "", "");

                    for (int j = 0; j < childNodes.Count; j++)
                    {
                        String clildName = XmlUtil.GetAttribute(childNodes[j], attrName, "");

                        if (childNodes.Count > 0)
                        {
                            combox.Items.Add(clildName);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 向combobox中添加item的通用方法
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="selectNode"></param>
        /// <param name="attrName"></param>
        private void AddComboboxCommon(ComboBox combox, string selectNode, string attrName)
        {
            combox.Items.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            combox.Items.Add("");

            for (int i = 0; i < groupNodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(groupNodes[i], attrName, "");

                combox.Items.Add(groupName);
            }
        }


        /// <summary>
        /// 给DataGridView添加信息
        /// </summary>
        private void LoadDataGridView(string planName)
        {
            dataGridView1.Rows.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            List<XmlNode> nodes = XmlUtil.GetChildNodes(xmlDoc, "/configuration/DevicePlan", "");

            for (int i = 0; i < nodes.Count; i++)
            {
                String _planName = XmlUtil.GetAttribute(nodes[i], "name", "");

                if (_planName == planName)
                {
                    List<XmlNode> childNodes = XmlUtil.GetChildNodes(nodes[i], "", "");

                    if (childNodes.Count <= 0)
                    {
                        break;
                    }

                    this.dataGridView1.Rows.Add(childNodes.Count);

                    for (int j = 0; j < childNodes.Count; j++)
                    {
                        String groupName = XmlUtil.GetAttribute(childNodes[j], "GroupName", "");
                        String DeviceClass = XmlUtil.GetAttribute(childNodes[j], "DeviceClass", "");
                        String ControlCodeName = XmlUtil.GetAttribute(childNodes[j], "ControlCodeName", "");
                        String Delay = XmlUtil.GetAttribute(childNodes[j], "Delay", "");

                        // 添加ControlCodeName的combobox，否则可能会爆出combobox错误
                        AddDataGridViewComboboxCommon((DataGridViewComboBoxCell)this.dataGridView1.Rows[j].Cells[DevicePlanModel.ColumnName_DeviceControlName], "/configuration/DeviceControl", "name", DeviceClass);

                        this.dataGridView1.Rows[j].Cells[DevicePlanModel.ColumnName_GroupName].Value = groupName;
                        this.dataGridView1.Rows[j].Cells[DevicePlanModel.ColumnName_DeviceClass].Value = DeviceClass;
                        this.dataGridView1.Rows[j].Cells[DevicePlanModel.ColumnName_DeviceControlName].Value = ControlCodeName;
                        this.dataGridView1.Rows[j].Cells[DevicePlanModel.ColumnName_Delay].Value = Delay;

                    }

                    break;
                }
            }
        }

        /// <summary>
        /// 根据DeviceClass 来添加控制码的combobox，完成了AddDataGridViewComboboxDeviceControlName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;

            //var columnList = dataGridView1.Columns.Cast<DataGridViewColumn>().ToList();
            //int index = columnList.FindIndex(c => c.Name == "DeviceControlName");

            //if (e.ColumnIndex == index)
            //{
            //    var deviceClass = dataGridView1.Rows[e.RowIndex].Cells["DeviceClass"].Value;
            //    if (deviceClass != null)
            //    {
            //        string deviceClassName = deviceClass.ToString();
                    
            //        AddDataGridViewComboboxCommon((DataGridViewComboBoxCell)this.dataGridView1.Rows[e.RowIndex].Cells[index], "/configuration/DeviceControl", "name", deviceClassName);
            //    }
            //}
        }

        private void comboBox_plan_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadDataGridView(this.comboBox_plan.Text);
        }

        private void 保存数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在xml中查找是否包含节点，不包含就创建

            // 该组名不是新建组
            // button_create_Click(null,null);

            if (this.comboBox_plan.Text == "")
            {
                return;
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/DevicePlan";

            List<XmlNode> planNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            int i = 0;

            for (i = 0; i < planNodes.Count; i++)
            {
                string planName = XmlUtil.GetAttribute(planNodes[i], "name", "");

                string curPlanName = this.comboBox_plan.Text;

                if (planName == curPlanName)
                {
                    // 删除节点
                    planNodes[i].RemoveAll();
                    XmlUtil.SetAttribute(planNodes[i], "name", curPlanName);

                    int row = dataGridView1.Rows.Count; //得到总行数  

                    for (int j = 0; j < row-1; j++)
                    {
                        XmlNode newNode = XmlUtil.AppendElement(planNodes[i], "PlanDetail", "");

                        string groupName = GetDataGridViewCellValue(this.dataGridView1, j, DevicePlanModel.ColumnName_GroupName);
                        string deviceClass = GetDataGridViewCellValue(this.dataGridView1, j, DevicePlanModel.ColumnName_DeviceClass);
                        string controlCodeName = GetDataGridViewCellValue(this.dataGridView1, j, DevicePlanModel.ColumnName_DeviceControlName);
                        string delay = GetDataGridViewCellValue(this.dataGridView1, j, DevicePlanModel.ColumnName_Delay);

                        if (groupName == "" || deviceClass == "" || controlCodeName == "")
                        {
                            MessageBox.Show("不能有空");
                            return;
                        }

                        XmlUtil.SetAttribute(newNode, "GroupName", groupName);
                        XmlUtil.SetAttribute(newNode, "DeviceClass", deviceClass);
                        XmlUtil.SetAttribute(newNode, "ControlCodeName", controlCodeName);
                        XmlUtil.SetAttribute(newNode, "Delay", delay);

                    }
                    break;
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            刷新数据ToolStripMenuItem_Click(null, null);
        }

        private string GetDataGridViewCellValue(DataGridView dgv, int row, string columnName)
        {
            if (dgv.Rows[row].Cells[columnName].Value != null)
            {
                return dgv.Rows[row].Cells[columnName].Value.ToString();
            }
            else
            {
                return "";
            }
        }

        private void 刷新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            方案管理_Load(null, null);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == DevicePlanModel.ColumnName_DeviceClass)
            {
                ((ComboBox)e.Control).SelectedIndexChanged +=
                    new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == DevicePlanModel.ColumnName_DeviceClass)
            {
                string deviceClass = ((ComboBox)sender).Text.ToString();
                if (deviceClass != null)
                {
                    string deviceClassName = deviceClass.ToString();

                    var columnList = dataGridView1.Columns.Cast<DataGridViewColumn>().ToList();
                    int index = columnList.FindIndex(c => c.Name == "DeviceControlName");

                    this.dataGridView1.CurrentRow.Cells[index].Value = "";
                    AddDataGridViewComboboxCommon((DataGridViewComboBoxCell)this.dataGridView1.CurrentRow.Cells[index], "/configuration/DeviceControl", "name", deviceClassName);
                }

            }
        }

        private void 新建方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            输入信息 inputDialog = new 输入信息();
            inputDialog.Title = "请输入新方案的名称";
            inputDialog.AllowEmpty = false;
            //inputDialog.Result = "新方案";
            inputDialog.SelectionStart = 0;
            //int length = currentName.LastIndexOf('.');
            //inputDialog.SelectionLength = length > 0 ? length : currentName.Length;
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string planName = inputDialog.Result;

                if (planName == "")
                {
                    return;
                }

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                string selectNode = "/configuration/DevicePlan";

                XmlNode node = xmlDoc.SelectSingleNode(selectNode);

                XmlNode newNode = XmlUtil.AppendElement(node, "Plan", "");

                XmlUtil.SetAttribute(newNode, "name", planName);

                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            }

        }
    }
}
