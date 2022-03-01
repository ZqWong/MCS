using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MainTrain.Tools;
using SqlSugar;
using Utilities;

namespace MCS
{

    public partial class 播放列表 : Form
    {
        public 播放列表()
        {
            if (!DBConnect.GetSingleton().db.DbMaintenance.IsAnyTable("T_PLAYLIST_INFO"))
            {
                DBConnect.GetSingleton().db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(T_PLAYLIST_INFO));//这样一个表就能成功创建了
            }

            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataError += dataGridViewDateErrorCallBack;
        }

        private void 播放列表_Load(object sender, EventArgs e)
        {
            List<string> playNameList = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Select(it => it.PlayListName).Distinct().ToList();

            playNameList.Sort((x, y) => x.CompareTo(y));

            foreach (var playName in playNameList)
            {
                int rowIndex = this.dataGridView_playlistName.Rows.Add();

                this.dataGridView_playlistName.Rows[rowIndex].Cells["Column_plName"].Value = playName;
            }
        }

        private void dataGridViewDateErrorCallBack(object sender, EventArgs e)
        {
            MessageBox.Show("当前播放列表中的应用名称并未包含在应用列表中。请重新给播放列表选择应用，并保存。");
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            // 保存dataGridView_playlistName的内容
            List<string> playListInDB = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Select(it => it.PlayListName).Distinct().ToList();

            List<string> playListInDGR = new List<string>();
            foreach (DataGridViewRow dgr in this.dataGridView_playlistName.Rows)
            {
                if (dgr.Cells["Column_plName"].Value != null)
                {
                    if (playListInDGR.Contains(dgr.Cells["Column_plName"].Value.ToString()))
                    {
                        MessageBox.Show("播放列表名称重复  请更改");
                    }
                    else
                    {
                        playListInDGR.Add(dgr.Cells["Column_plName"].Value.ToString());
                    }
                }
            }

            List<string> exceptLs = playListInDB.Except(playListInDGR).ToList();
            DBConnect.GetSingleton().db.Deleteable<T_PLAYLIST_INFO>()
                .Where(it => exceptLs.Contains(it.PlayListName)).ExecuteCommand();


            // 保存dataGridView1的内容
            List<T_PLAYLIST_INFO> playList = new List<T_PLAYLIST_INFO>();

            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (dgr.Cells["Column_index"].Value == null || dgr.Cells["Column_appName"].Value == null)
                {
                    break;
                }

                T_PLAYLIST_INFO playInfo = new T_PLAYLIST_INFO();

                if (dgr.Cells["Column_ID"].Value == null)
                {
                    playInfo.ID = 0;
                    playInfo.PlayListName = this.dataGridView_playlistName.SelectedCells[0].Value.ToString();
                }
                else
                {
                    playInfo.ID = dgr.Cells["Column_ID"].Value.ObjToInt();
                    playInfo.PlayListName = dgr.Cells["Column_playListName"].Value.ToString();
                }

                playInfo.No = dgr.Cells["Column_index"].Value.ObjToInt();
                playInfo.VideoName = dgr.Cells["Column_appName"].Value.ToString();
                playInfo.Time = float.Parse(dgr.Cells["Column_time"].Value.ToString());

                playList.Add(playInfo);
            }

            if (playList.Count > 0)
            {
                if (this.dataGridView_playlistName.Columns[this.dataGridView_playlistName.SelectedCells[0].ColumnIndex]
                    .Name == "Column_plName")
                {
                    string plName = this.dataGridView_playlistName.SelectedCells[0].Value.ToString();

                    if (DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>().Where(it =>
                            it.PlayListName == plName).Any())
                    {
                        DBConnect.GetSingleton().db.Deleteable<T_PLAYLIST_INFO>().Where(it => it.PlayListName == plName).ExecuteCommand();
                    }
                    DBConnect.GetSingleton().db.Saveable<T_PLAYLIST_INFO>(playList).ExecuteCommand();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                DataGridViewColumn column = this.dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[e.RowIndex]);

                    ReNoDataGridView();
                }
            }
        }


        private void ReNoDataGridView()
        {
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["Column_appName"].Value == null)
                    continue;

                this.dataGridView1.Rows[i].Cells["Column_index"].Value = (i + 1).ObjToInt();
            }
        }

        private void dataGridView_playlistName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = this.dataGridView_playlistName.Columns[e.ColumnIndex];

                if (column.Name == "Column_plName" )
                {
                    this.dataGridView1.Rows.Clear();

                    if (this.dataGridView_playlistName.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        return;
                    }

                    string selectPlayListName = this.dataGridView_playlistName.Rows[e.RowIndex].Cells[e.ColumnIndex]
                        .Value.ToString();

                    List<T_PLAYLIST_INFO> playListInfo = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                        .Where(it => it.PlayListName == selectPlayListName).ToList();

                    playListInfo.Sort((x, y) => x.No.CompareTo(y.No));

                    foreach (var palyinfo in playListInfo)
                    {
                        int rowIndex = this.dataGridView1.Rows.Add();

                        this.dataGridView1.Rows[rowIndex].Cells["Column_index"].Value = palyinfo.No.ToString();
                        this.dataGridView1.Rows[rowIndex].Cells["Column_appName"].Value = palyinfo.VideoName.ToString();
                        this.dataGridView1.Rows[rowIndex].Cells["Column_time"].Value = palyinfo.Time.ToString();
                        this.dataGridView1.Rows[rowIndex].Cells["Column_ID"].Value = palyinfo.ID.ToString();
                        this.dataGridView1.Rows[rowIndex].Cells["Column_playListName"].Value = palyinfo.PlayListName.ToString();
                    }


                    try
                    {
                        this.Column_appName.DataSource = DBConnect.GetSingleton().db.Queryable<t_process_control_info>()
                            .Select(it => it.AppName).Distinct().ToList().ConvertAll(s => (object)s);
                        this.Column_appName.FlatStyle = FlatStyle.Flat;

                    }
                    catch (Exception exception)
                    {
                        NlogHandler.GetSingleton().Error("播放列表异常： " + exception.Message.ToString());
                    }
                }
                else if (column.Name == "Column_plDelete")
                {
                    this.dataGridView_playlistName.Rows.Remove(this.dataGridView_playlistName.Rows[e.RowIndex]);
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class T_PLAYLIST_INFO
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        public int ID { get; set; }
        public float Time { get; set; }
        public string PlayListName { get; set; }
        public string VideoName { get; set; }
        public int No { get; set; }
    }


    public class t_process_control_info
    {
        [SugarColumn(IsPrimaryKey = true)]//主键并且自增 （string不能设置自增）
        public int ID { get; set; }
        public string IP { get; set; }
        public string FilePath { get; set; }
        public string AppName { get; set; }
    }
}
