using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;


public class JsonTool
{
    private static JsonTool _inst;
    public static JsonTool getInst()
    {
        if (null == _inst)
        {
            _inst = new JsonTool();
        }
        return _inst;
    }


    /// <summary>
    /// 旧的移动设备加载本JSON接口，请使用GetJsonDataForAndroid/GetJsonDataForIOS代替。
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="retAction"> JsonData 读取成功的Json数据, 是否发生异常, 异常信息 </param>
    /// <returns></returns>
    [Obsolete]
    //public static IEnumerator GetJsonDataForMobile(string filePath, Action<JsonData, bool, string> retAction)
    //{
    //    var request = UnityWebRequest.Get(filePath);
    //    yield return request.SendWebRequest();
    //    if (request.isNetworkError || request.isNetworkError)
    //    {
    //        retAction(null, true, request.error);
    //        Debug.Log(request.error);
    //    }
    //    else
    //    {
    //        Debug.Log(request.downloadHandler.text);
    //        JsonReader jsonReader = new JsonReader(request.downloadHandler.text);
    //        if (null != retAction)
    //            retAction(JsonMapper.ToObject(jsonReader), false, "");
    //    }
    //}

    /// <summary>
    /// 安卓应用的异步加载json文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="retAction"></param>
    /// <returns></returns>
    //public static IEnumerator GetJsonDataForAndroid(string filePath, Action<JsonData, bool, string> retAction)
    //{
    //    yield return GetJsonDataForMobile(filePath, retAction);
    //}

    ///// <summary>
    ///// iOS应用的异步加载json文件
    ///// </summary>
    ///// <param name="filePath"></param>
    ///// <param name="retAction"></param>
    ///// <returns></returns>
    //public static IEnumerator GetJsonDataForIOS(string filePath, Action<JsonData, bool, string> retAction)
    //{
    //    var pathExecute = "file:///" + filePath;
    //    yield return GetJsonDataForMobile(pathExecute, retAction);
    //}

    ///// <summary>
    ///// PC（windows/macOS）应用的异步加载json文件
    ///// </summary>
    ///// <param name="filePath"></param>
    ///// <param name="retAction"></param>
    ///// <returns></returns>
    //public static IEnumerator GetJsonDataForPC(string filePath, Action<JsonData, bool, string> retAction)
    //{
    //    var pathExecute = "file:///" + filePath;
    //    yield return GetJsonDataForMobile(pathExecute, retAction);
    //}

    /// <summary>
    ///  PC（windows/macOS）应用的同步加载json文件
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public static JsonData GetJsonDataForPC(string filepath)
    {
        string json_context = File.ReadAllText(filepath);
        JsonData jd = JsonMapper.ToObject(json_context);
        return jd;
    }

}
