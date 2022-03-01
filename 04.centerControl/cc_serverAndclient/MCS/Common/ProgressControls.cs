using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS.Common
{
    public class ProgressControls
    {
        /// <summary>
        /// 进度条控件
        /// </summary>
        public ProgressBar _TotoalProBar;
        //public Label _LblTitle;
        public Label _LblCur;
        public int _ProgressTotalMaxValue;//总进度条最大值
        public int _ProgressTotalCurValue;//总进度条当前值
        /// <summary>
        /// 所有文件的长度，用于计算总进度条
        /// </summary>
        public long _TotalFileLen;
        /// <summary>
        /// 当前发送的长度
        /// </summary>
        public long _CurSentLen;

        public string _strCurTxt;
        public string _strTitle;

        /// <summary>
        /// 客户端的个数
        /// </summary>
        public int _ClientsNum;
    }
}
