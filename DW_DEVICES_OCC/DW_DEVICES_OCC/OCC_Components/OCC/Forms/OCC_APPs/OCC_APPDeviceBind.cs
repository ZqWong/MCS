using DataModel;
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
        public OCC_APPDeviceBind()
        {


            InitializeComponent();
        }

        /// <summary>
        /// 表格刷新
        /// </summary>
        private void DataGridViewInitialize()
        {
            DataGridViewDeviceBinded.Rows.Clear();




        }



    }
}
