using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDataManager
{
    void Initialize(string filePath, bool useConstantKey = false);
    void DeInitialize(bool useConstantKey = false);
    void InitializeData();
    void ClearData();
    void LoadDataFromFile(bool useConstantKey = false);
    void SaveDataToFile(bool useConstantKey = false);

}