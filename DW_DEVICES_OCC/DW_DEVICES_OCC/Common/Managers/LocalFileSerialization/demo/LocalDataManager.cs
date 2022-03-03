//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Managers;
//using Tools;
//using UnityEngine;
//using LitJson;
//using UnityEngine.Networking;


//public class LocalDataManager : SingletonMonoBehaviourClass<LocalDataManager>
//{
//    public Action OnInitialized;


//    private const string SYSTEM_CONFIG_FILE_NAME = "SystemConfig.json";
//    private const string CHARACTER_CONFIG_FILE_NAME = "CharacterConfig.json";
//    private const string PROTOCOL_CONFIG_FILE_NAME = "ProtocolConfig.json";

//    public DataManagerBase<SystemConfigDataModel> SystemConfig { get; private set; }
//    public DataManagerBase<CharacterConfigDataModel> CharacterConfig { get; private set; }
//    public DataManagerBase<ProtocolConfigDataModel> ProtocolConfig { get; private set; }


//    private bool m_initialized = false;

//    // profile data module

//    public LocalDataManager()
//    {
//        SystemConfig = new DataManagerBase<SystemConfigDataModel>(/*this,*/ new SystemConfigDataModel());
//        CharacterConfig = new DataManagerBase<CharacterConfigDataModel>(/*this,*/ new CharacterConfigDataModel());
//        ProtocolConfig = new DataManagerBase<ProtocolConfigDataModel>(/*this,*/ new ProtocolConfigDataModel());
//    }

//    public IEnumerator Initialize()
//    {
//#if UNITY_ANDROID || UNITY_IOS
//        yield return StartCoroutine(CopyConfigFile(SYSTEM_CONFIG_FILE_NAME));
//        yield return StartCoroutine(CopyConfigFile(CHARACTER_CONFIG_FILE_NAME));
//        yield return StartCoroutine(CopyConfigFile(PROTOCOL_CONFIG_FILE_NAME));
//#endif

//        //#if STANDALONE_VERSION

//        if (!Directory.Exists($"{Application.persistentDataPath}/LevelConfig"))
//        {
//            Directory.CreateDirectory($"{Application.persistentDataPath}/LevelConfig");
//        }


//        if (!File.Exists($"{Application.persistentDataPath}/LevelConfig/LevelSelect.json"))
//        {
//            yield return StartCoroutine(
//                CopyFile(
//                    $"{Application.streamingAssetsPath}/LevelConfig",
//                    $"{Application.persistentDataPath}/LevelConfig",
//                    "LevelSelect.json"));
//        }


//#if UNITY_ANDROID
//        yield return JsonTool.GetJsonDataForAndroid($"file:///{Application.persistentDataPath}/LevelConfig/LevelSelect.json", (jsonData, error, msg) =>
//        {
//            var dataModel = JsonMapper.ToObject<List<LevelBasicsDataModel>>(jsonData.ToJson());
//            DataManager.Instance.UpdateLoggedUserLevelsBasicsData(dataModel);
//        });
//#elif UNITY_IOS
//        yield return JsonTool.GetJsonDataForIOS($"{Application.persistentDataPath}/LevelConfig/LevelSelect.json", (jsonData, error, msg) =>
//        {
//            var dataModel = JsonMapper.ToObject<List<LevelBasicsDataModel>>(jsonData.ToJson());
//            DataManager.Instance.UpdateLoggedUserLevelsBasicsData(dataModel);
//        });
//#elif UNITY_EDITOR
//        JsonData json =
//                JsonTool.GetJsonDataForPC($"{Application.persistentDataPath}/LevelConfig/LevelSelect.json");
//        var dataModel = JsonMapper.ToObject<List<LevelBasicsDataModel>>(json.ToJson());
//        DataManager.Instance.UpdateLoggedUserLevelsBasicsData(dataModel);
//#endif
//        //#endif

//        SystemConfig.Initialize(Path.Combine(PathManager.Instance.LocalWritableConfigurationPath, SYSTEM_CONFIG_FILE_NAME), true);
//        CharacterConfig.Initialize(Path.Combine(PathManager.Instance.LocalWritableConfigurationPath, CHARACTER_CONFIG_FILE_NAME), true);
//        ProtocolConfig.Initialize(Path.Combine(PathManager.Instance.LocalWritableConfigurationPath, PROTOCOL_CONFIG_FILE_NAME), false);

//        OnInitialized?.Invoke();
//        m_initialized = true;
//        yield break;
//    }


//    private IEnumerator CopyConfigFile(string configFile)
//    {
//        if (!File.Exists($"{PathManager.Instance.LocalWritableConfigurationPath}/{configFile}"))
//        {
//            string srcFileName = PathManager.Instance.LocalConfigurationPath;
//            string destFileName = PathManager.Instance.LocalWritableConfigurationPath;
//            yield return StartCoroutine(CopyConfigFileToWriteablePath(srcFileName, destFileName, configFile));
//        }
//    }

//    public IEnumerator CopyConfigFileToWriteablePath(string srcFileName, string destFileName, string fileName)
//    {

//        //#if UNITY_ANDROID || UNITY_STANDALONE_OSX

//        //#else
//        //        destFileName = @"file://" + destFileName;
//        //#endif
//        StartCoroutine(CopyFile(srcFileName, destFileName, fileName));
//        yield return null;
//    }


//    private IEnumerator CopyFile(string srcPath, string tarPath, string fileName)
//    {
//#if !UNITY_ANDROID
//        Debug.Log($"{File.Exists($"{tarPath}/{fileName}")} -> {tarPath}/{fileName}");
//        if (!File.Exists($"{tarPath}/{fileName}"))
//        {
//            Directory.CreateDirectory(PathManager.Instance.LocalWritableConfigurationPath);
//            File.Copy($"{srcPath}/{fileName}", $"{tarPath}/{fileName}", true);
//        }
//        yield return null;
//#else
//        Debug.Log($"{File.Exists($"{tarPath}/{fileName}")} -> {tarPath}/{fileName}");

//        UnityWebRequest unityWebRequest = new UnityWebRequest($"{srcPath}/{fileName}", UnityWebRequest.kHttpVerbGET);
//        unityWebRequest.downloadHandler = new DownloadHandlerFile($"{tarPath}/{fileName}");
//        yield return unityWebRequest.SendWebRequest();
//#endif
//    }
//}