﻿using System;
using System.IO;


[Serializable]
public class DataManagerBase<T> : IDataManager where T : DataModelBase
{

    /// <summary>
    /// 内容是否需要加密
    /// </summary>
    public bool IsContentNeedEncrypt = false;

    public bool Initialized { get; private set; }

    protected string FilePath { get; private set; }
    //protected LocalDataManager Manager { get; set; }

    protected T m_dataModel;

    public T DataModel
    {
        get { return m_dataModel; }
        set { m_dataModel = value; }
    }

    public DataManagerBase( /*LocalDataManager manager,*/ DataModelBase dataModel)
    {
        //Debug.Assert(null != manager, "Unexpected null manager");
        //Manager = manager;
        m_dataModel = dataModel as T;
    }

    public virtual void Initialize(string filePath, bool useConstantKey = false)
    {
        Debug.Warn($"{!Initialized} Invalid {GetType().Name} control flow");
        Debug.Warn($"{!string.IsNullOrEmpty(filePath)} && {Directory.Exists(Path.GetDirectoryName(filePath))} Directory doesn't exist: {filePath}");
        FilePath = filePath;
        InitializeData();
        LoadDataFromFile(useConstantKey);
        Initialized = true;
    }

    public virtual void DeInitialize(bool useConstantKey = false)
    {
        if (Initialized)
        {
            SaveDataToFile(useConstantKey);
            ClearData();
            FilePath = null;
            Initialized = false;
        }
    }

    public virtual void InitializeData()
    {
    }

    public virtual void ClearData()
    {
    }

    public virtual void LoadDataFromFile(bool useConstantKey = false)
    {
        var dataFromFile = FileUtils.DecryptJSONDataFromFile<T>(FilePath, IsContentNeedEncrypt, useConstantKey);
        if (null != dataFromFile)
        {
            m_dataModel = dataFromFile;
        }
    }

    public virtual void SaveDataToFile(bool useConstantKey = false)
    {
        Debug.Info($"SaveDataToFile data:{m_dataModel.ToString()} path:{FilePath}");
        FileUtils.EncryptJSONDataInFile<T>(m_dataModel, FilePath, IsContentNeedEncrypt, useConstantKey);
    }

    public virtual void DeleteJsonFile()
    {
        var dataFromFile = FileUtils.DecryptJSONDataFromFile<T>(FilePath, IsContentNeedEncrypt);
        if (null != dataFromFile)
        {
            File.Delete(FilePath);
        }
    }

    public virtual bool GetFileExist()
    {
        var dataFromFile = FileUtils.DecryptJSONDataFromFile<T>(FilePath, IsContentNeedEncrypt);
        return dataFromFile != null ? true : false;
    }

}
