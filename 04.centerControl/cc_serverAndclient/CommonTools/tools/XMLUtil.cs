using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonTools.tools
{
    /// <summary>
    /// Xml 操作工具类
    /// </summary>
    public sealed class XmlUtil
    {
        private XmlUtil() { }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElementName"></param>
        /// <returns></returns>
        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElementName"></param>
        /// <param name="innerValue"></param>
        /// <returns></returns>
        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode oNode;
            if (node is XmlDocument)
            {
                oNode = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            }
            else
            {
                oNode = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));
            }

            if (innerValue != null)
            {
                oNode.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));
            }
            return oNode;
        }

        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute oAtt = xmlDocument.CreateAttribute(name);
            oAtt.Value = value;
            return oAtt;
        }

        /// <summary>
        /// 设置属性的值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
            else
            {
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
            }
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetAttribute(XmlNode node, string attributeName, string defaultValue)
        {
            XmlAttribute att = node.Attributes[attributeName];
            if (att != null)
            {
                return att.Value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取某个节点的值
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeXPath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode parentNode, string nodeXPath, string defaultValue)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeXPath);
            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            else if (node != null)
            {
                return node.Value;
            }
            else
            {
                return defaultValue;
            }
        }


        /// <summary>
        /// 获取节点的子节点
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeXPath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static List<XmlNode> GetChildNodes(XmlNode parentNode, string nodeXPath, string defaultValue)
        {
            XmlNode node;

            if (nodeXPath != "")
            {
                node = parentNode.SelectSingleNode(nodeXPath);
            }
            else
            {
                node = parentNode;
            }
            

            List<XmlNode> resultList = new List<XmlNode>();

            if (node.HasChildNodes)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    resultList.Add(node.ChildNodes[i]);
                }
            }

            return resultList;
        }
    }
}
