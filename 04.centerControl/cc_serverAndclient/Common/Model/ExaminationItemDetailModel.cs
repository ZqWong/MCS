/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExaminationChildSubjectModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/
namespace Common.Model
{
    public class ExaminationItemDetailModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_subject_item_detail_info";
        /// <summary>
        /// 列名：编号
        /// </summary>
        public static string ColumnName_ID = "ID";
        /// <summary>
        /// 列名：操作内容步骤详情
        /// </summary>
        public static string ColumnName_ContentOrStepDetail = "ContentOrStepDetail";
        /// <summary>
        /// 列名：考试项目编号
        /// </summary>
        public static string ColumnName_ExaminationItemID = "ExaminationItemID";

        // ---------------------------------------------------------------------------------------

        /// <summary>
        /// 参数名：编号
        /// </summary>
        public static string ParamName_ID = "_ID";
        /// <summary>
        /// 参数名：操作内容步骤详情
        /// </summary>
        public static string ParamName_ContentOrStepDetail = "_ContentOrStepDetail";
        /// <summary>
        /// 参数名：考试项目编号
        /// </summary>
        public static string ParamName_ExaminationItemID = "_ExaminationItemID";


        private string id;
        private string contentOrStepDetail;
        private string examinationItemID;

        /// <summary>
        /// 编号
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 操作内容步骤详情
        /// </summary>
        public string ContentOrStepDetail
        {
            get
            {
                return contentOrStepDetail;
            }

            set
            {
                contentOrStepDetail = value;
            }
        }

        /// <summary>
        /// 考试项目编号
        /// </summary>
        public string ExaminationItemID
        {
            get
            {
                return examinationItemID;
            }

            set
            {
                examinationItemID = value;
            }
        }
    }
}
