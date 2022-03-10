using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public enum UserAuthEnum
{
    MAIN_MENU = 1,                  // 首页
    DEVICES_MENU = 2,               // 设备管理界面
    APPS_MENU = 4,                  // （系统）App管理界面
    DATAS_MENU = 8,                 // （数据管理）用户管理界面
    GROUP_MENU = 16,                // 分组管理界面
    SYSTEM_MENU = 32                // 系统管理界面
}

