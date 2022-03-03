using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class JsonConfigFileHelper
{
    private readonly string m_configFileName;
    private SerializableProperties m_serializableProperties = new SerializableProperties();
    public JsonConfigFileHelper(string fileName)
    {
        m_configFileName = fileName;
        if (File.Exists(m_configFileName))
        {
            m_serializableProperties.DeserializeJSON(m_configFileName);
        }
        else
        {
            // Debug.LogFormat("{0} isn,t exists !", m_configFileName);
        }
    }

    public void SetValue(string key, string value, bool writeFile = true)
    {
        if (m_serializableProperties != null)
        {
            if (m_serializableProperties.GetString(key) != value)
            {
                m_serializableProperties.SetString(key, value);

                if (writeFile)
                {
                    m_serializableProperties.SerializeToJSON(m_configFileName);
                }
            }
        }
    }

    public string GetValue(string key)
    {
        return m_serializableProperties.GetString(key);
    }

}