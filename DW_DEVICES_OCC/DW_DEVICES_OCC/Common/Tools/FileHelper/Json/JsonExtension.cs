using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class JsonExtension
{
    public static bool HasKey(this LitJson.JsonData jData, string targetKey)
    {
        var result = jData.Keys.FirstOrDefault(key => key == targetKey);
        if (result != null)
        {
            return true;
        }
        return false;
    }

    public static bool IsNull(this LitJson.JsonData jData)
    {
        if (jData != null)
        {
            if (jData.IsString)
            {
                return String.IsNullOrEmpty(jData.ToString());
            }

            if (jData.IsArray)
            {
                return jData.Count == 0;
            }
            return false;
        }

        return true;
    }

    public static int ToInt(this LitJson.JsonData jData)
    {
        if (jData != null && jData.IsInt || jData.IsLong) return Int32.Parse(jData.ToString());
        return 0;
    }

    public static double ToDouble(this LitJson.JsonData jData)
    {
        if (jData != null && jData.IsDouble) return Double.Parse(jData.ToString());
        return 0d;
    }

    public static float ToFloat(this LitJson.JsonData jData)
    {
        if (jData != null && jData.IsDouble) return Convert.ToSingle(jData.ToString());
        return 0f;
    }

    public static bool ToBoolean(this LitJson.JsonData jData)
    {
        if (jData != null && jData.IsBoolean) return Boolean.Parse(jData.ToString());
        return false;
    }


}
