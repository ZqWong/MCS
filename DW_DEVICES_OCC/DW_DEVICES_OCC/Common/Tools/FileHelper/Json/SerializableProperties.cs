using LitJson;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SerializableProperties
{

    private Dictionary<string, object> m_table = new Dictionary<string, object>();

    /// <summary>
    /// 针对单一列表格式的Json进行序列化
    /// </summary>
    /// <param name="filePath"></param>
    public void SerializeToJSON(string filePath)
    {
        try
        {
            string userDataText = LitJson.JsonMapper.ToJson(m_table);
            FileUtils.DeleteFileIfExists(filePath);
            System.IO.File.WriteAllText(filePath, userDataText);
        }
        catch (System.Exception ex)
        {
            Debug.Error("Failed writing user data to: " + filePath + "\nerror: " + ex.ToString());
        }
    }

    public void DeserializeJSON(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            try
            {
                string jsonText = System.IO.File.ReadAllText(filePath);
                m_table = JsonMapper.ToObject<Dictionary<string, object>>(jsonText);
            }
            catch (System.Exception ex)
            {
                Debug.Error("Failed reading user data from: " + filePath + "\nerror: " + ex.ToString());
            }
        }
    }

    public bool RemoveField(string key)
    {
        return m_table.Remove(key);
    }

    public bool HasInt(string key)
    {
        var value = GetValue(key);
        return (null != value) && (value is int);
    }

    public int GetInt(string key, int defaultValue = 0)
    {
        var value = GetValue(key);
        return ((null != value) && (value is int)) ? ((int)value) : defaultValue;
    }

    public void SetInt(string key, int value)
    {
        SetValue(key, value);
    }

    public bool HasFloat(string key)
    {
        var value = GetValue(key);
        return (null != value) && (value is float);
    }

    public float GetFloat(string key, float defaultValue = 0f)
    {
        var value = GetValue(key);
        return ((null != value) && (value is float)) ? ((float)value) : defaultValue;
    }

    public void SetFloat(string key, float value)
    {
        SetValue(key, value);
    }

    public bool HasString(string key)
    {
        var value = GetValue(key);
        return (null != value) && (value is string);
    }

    public string GetString(string key, string defaultValue = default(string))
    {
        var value = GetValue(key);
        return ((null != value) && (value is string)) ? ((string)value) : defaultValue;
    }

    public void SetString(string key, string value)
    {
        SetValue(key, value);
    }

    public bool HasBool(string key)
    {
        var value = GetValue(key);
        return (null != value) && (value is bool);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        var value = GetValue(key);
        return ((null != value) && (value is bool)) ? ((bool)value) : defaultValue;
    }

    public void SetBool(string key, bool value)
    {
        SetValue(key, value);
    }

    private object GetValue(string key)
    {
        object value = null;
        m_table.TryGetValue(key, out value);
        return value;
    }

    private void SetValue(string key, object value)
    {
        if (m_table.ContainsKey(key))
        {
            m_table[key] = value;
        }
        else
        {
            m_table.Add(key, value);
        }
    }
}
