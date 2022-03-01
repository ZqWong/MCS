/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:     XmlManager.cs
 *Author:       wuxin  e-mail:wuxin8761@126.com
 *Version:      1.0
 *UnityVersion：5.4.6f3
 *Date:         2018-04-15
 *Description:   XML实体类
 *History:  
**********************************************************************************/
namespace Common.XML
{
    public class XmlModel
    {
        // add by wuxin at 2018/10/14 - start
        // 练习0，考试1
        public const string ElementName_Type = "Type";
        // add by wuxin at 2018/10/14 - end
        public const string ElementName_ExaminationID = "ExaminationID";
        public const string ElementName_ExaminationnSubjectID = "ExaminationSubjectID";
        public const string ElementName_ExamineeID = "ExamineeID";
        public const string ElementName_ExamState = "ExamState";
        public const string ElementName_ExaminationResultID = "ExaminationResultID";
        
        private string elementName;

        private string innerText;

        public string ElementName
        {
            get
            {
                return elementName;
            }

            set
            {
                elementName = value;
            }
        }

        public string InnerText
        {
            get
            {
                return innerText;
            }

            set
            {
                innerText = value;
            }
        }
    }

}

