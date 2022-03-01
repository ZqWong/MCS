using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS
{
    
    public partial class 配置文件 : Form
    {
        private const string col_name = "Client_Name";
        private const string col_id = "ID";
        private const string col_pitch = "Pitch";
        private const string col_rotate = "Rotate";
        private const string col_roll = "Roll";

        private const string xml_id = "id";
        private const string xml_pitch = "pitch";
        private const string xml_rotate = "rotate";
        private const string xml_roll = "roll";

        private DataSet ds;

        private string XMLFilePath = @"C:\Users\DuoWei\Desktop\xml\config.xml";

        public 配置文件()
        {
            InitializeComponent();
        }

        private void xml_Load(object sender, EventArgs e)
        {
            this.dataGridView_client.Rows.Clear();

            ds = new DataSet();
            // 读取数据
            ds.ReadXml(XMLFilePath);

            // 读入到dataset中的xml，会被分为不同的table
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].TableName.Contains("client"))
                {
                    this.dataGridView_client.Rows.Add(1);
                    int cur_row_count = dataGridView_client.RowCount - 1;

                    this.dataGridView_client.Rows[cur_row_count].Cells[col_name].Value = ds.Tables[i].TableName;
                    this.dataGridView_client.Rows[cur_row_count].Cells[col_id].Value = ds.Tables[i].Rows[0][xml_id].ToString();
                    this.dataGridView_client.Rows[cur_row_count].Cells[col_pitch].Value = ds.Tables[i].Rows[0][xml_pitch].ToString();
                    this.dataGridView_client.Rows[cur_row_count].Cells[col_rotate].Value = ds.Tables[i].Rows[0][xml_rotate].ToString();
                    this.dataGridView_client.Rows[cur_row_count].Cells[col_roll].Value = ds.Tables[i].Rows[0][xml_roll].ToString();

                    if (cur_row_count % 2 != 0)
                    {
                        this.dataGridView_client.Rows[cur_row_count].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dataGridView_client.Rows[cur_row_count].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                }
            }


        }

        private DataTable _get_table_by_name(string tableName, DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].TableName == tableName)
                {
                    return ds.Tables[i];
                }
                else
                {
                    continue;
                }
            }

            return null;
        }


        private void button_save_Click(object sender, EventArgs e)
        {
            int count = dataGridView_client.Rows.Count; //得到总行数  

            for (int i = 0; i < count; i++) //得到总行数并在之内循环  
            {
                string tableName = this.dataGridView_client.Rows[i].Cells[col_name].Value.ToString();

                DataTable tmp_dt = _get_table_by_name(tableName, ds);

                DataRow tmp_row;

                if (tmp_dt != null)
                {
                    tmp_row = tmp_dt.Rows[0];
                }
                else
                {
                    ds.Tables.Add(tmp_dt);
                    tmp_row = tmp_dt.NewRow();
                }

                tmp_row[xml_id] = this.dataGridView_client.Rows[i].Cells[col_id].Value.ToString();
                tmp_row[xml_pitch] = this.dataGridView_client.Rows[i].Cells[col_pitch].Value.ToString();
                tmp_row[xml_rotate] = this.dataGridView_client.Rows[i].Cells[col_rotate].Value.ToString();
                tmp_row[xml_roll] = this.dataGridView_client.Rows[i].Cells[col_roll].Value.ToString();

            }

            ds.WriteXml(XMLFilePath);
        }
    }
}
