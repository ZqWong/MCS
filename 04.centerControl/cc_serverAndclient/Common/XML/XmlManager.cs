/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:     XmlManager.cs
 *Author:       wuxin  e-mail:wuxin8761@126.com
 *Version:      1.0
 *UnityVersion：5.4.6f3
 *Date:         2018-04-15
 *Description:   XML管理工具（更新、查询）
 *History:  
**********************************************************************************/
using System.IO;
using System.Xml;
using System.Collections.Generic;
using Common.XML;
using System;

//public class ElementName
//{
//    public const string ExaminationID = "ExaminationID";
//    public const string ExaminationnSubjectID = "ExaminationnSubjectID";
//    public const string ExamineeID = "ExamineeID";
//    public const string ExamState = "ExamState";
//    public const string ExaminationResultID = "ExaminationResultID";
//}

public class XmlManager
{
    public static bool IsUpdating = false;

    /// <summary>
    ///  更新XML
    /// </summary>
    /// <param name="xmlModels"></param>
    public static bool UpdateXml(string path, List<XmlModel> xmlModels)
    {
        bool result = false;

        // 继续判断当前路径下是否有该文件
        if (File.Exists(path))
        {
            //try // 避免异常：文件“D:\Test\Config\Config.xml”正由另一进程使用，因此该进程无法访问此文件。
            //{
            //System.IO.FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write);

            XmlDocument xmlDoc = new XmlDocument();

            // 根据路径将XML读取出来
            xmlDoc.Load(path);

            // 得到SystemSettings下的所有子节点
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Examination").ChildNodes;

            foreach (XmlModel xmlModel in xmlModels)
            {
                // 遍历所有子节点
                foreach (XmlElement xe in nodeList)
                {
                    if (xe.Name == xmlModel.ElementName)
                    {
                        xe.InnerText = xmlModel.InnerText;
                    }
                }
            }

            xmlDoc.Save(path);

            result = true;

            //// 关闭文件流
            //fs.Close();

            //Debug.Log("UpdateXml OK!");
            //}
            //catch (Exception e)
            //{
            //    result = false;
            //}

        }
        else
        {
            result = false;
            //Debug.Log("XML不存在！");
        }

        return result;
    }

    /// <summary>
    /// 获取XML
    /// </summary>
    /// <param name="elementName"></param>
    /// <returns></returns>
    public static string GetInnerTextByElementNameFromXml(string path, string elementName)
    {
        //if (!IsUpdating)
        //{
            string innerText = "";

            if (File.Exists(path))
            {
                try // 避免异常：文件“D:\Test\Config\Config.xml”正由另一进程使用，因此该进程无法访问此文件。
                {
                    System.IO.FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.Load(fs);

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("Examination").ChildNodes;

                    // 遍历节点
                    foreach (XmlElement xe in nodeList)
                    {
                        if (xe.Name == elementName)
                        {
                            innerText = xe.InnerText;
                        }
                    }

                    // 关闭文件流
                    fs.Close();

                }
                catch (Exception e)
                {

                }
            }
            else
            {
                // Debug.Log("XML不存在！");
            }

            return innerText;
        //}
        //else
        //{
        //    return "";
        //}
        
    }
}
