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
    /// <summary>
    /// 考试子科目
    /// </summary>
    public class ExaminationChildSubjectModel
    {
        // 考试子科目编号
        private string examinationChildSubjectID;
        // 考试子科目名称
        private string examinationChildSubjectName;
        // 考试子科目简称
        private string examinationChildSubjectShortName;

        /// <summary>
        /// 考试子科目编号
        /// </summary>
        public string ExaminationChildSubjectID
        {
            get
            {
                return examinationChildSubjectID;
            }

            set
            {
                examinationChildSubjectID = value;
            }
        }

        /// <summary>
        /// 考试子科目名称
        /// </summary>
        public string ExaminationChildSubjectName
        {
            get
            {
                return examinationChildSubjectName;
            }

            set
            {
                examinationChildSubjectName = value;
            }
        }

        /// <summary>
        /// 考试子科目简称
        /// </summary>
        public string ExaminationChildSubjectShortName
        {
            get
            {
                return examinationChildSubjectShortName;
            }

            set
            {
                examinationChildSubjectShortName = value;
            }
        }
    }
}
