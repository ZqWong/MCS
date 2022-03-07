using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public enum UserAuthEnum
{
    MAIN_MENU = 1,                  // 主界面
    DEVICE_MENU = 2,                // 设备管理界面
    APP_MENU = 4,                   // App管理界面
    USERS_MENU = 8,                 // 用户管理界面
    DEVICE_GROUP_MENU = 16,         // 分组管理界面
    LOG_MENU = 32                   // 日志管理界面
}

