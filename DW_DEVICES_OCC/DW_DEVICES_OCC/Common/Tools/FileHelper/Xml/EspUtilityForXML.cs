using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


public class EspXmlSerializer
{
    /// <summary>
    /// 保存XML文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sourceObj"></param>
    /// <param name="type"></param>
    public static void SaveToXml(string filePath, object sourceObj, Type type)
    {
        if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
        {
            type = type != null ? type : sourceObj.GetType();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer =
                    new System.Xml.Serialization.XmlSerializer(type);
                xmlSerializer.Serialize(writer, sourceObj);
            }
        }
    }

    /// <summary>
    /// 加载XML文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static object LoadFromXml(string filePath, Type type)
    {
        filePath = filePath.Replace(@"\", @"/");
        object result = null;

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
                catch (Exception e)
                {
                    Debug.Error("LoadFromXml-----------------------" + e.Message);
                }
            }
        }

        return result;
    }

}
