namespace MCS.DB
{
    public class StoredProcedureName
    {
        // 考试信息相关存储过程名
        public const string GetAllExaminationInfo = "GetAllExaminationInfo";
        public const string GetExaminationInfoByExaminationID = "GetExaminationInfoByExaminationID";
        // add by wuxin at 2019/12/03 - start
        public const string GetLatestExaminationID = "GetLatestExaminationID";
        public const string AddExaminationInfo = "AddExaminationInfo";
        public const string UpdExaminationInfo = "UpdExaminationInfo";
        public const string DelExaminationInfo = "DelExaminationInfo";
        // add by wuxin at 2019/12/03 -end

        // 考生所属公司信息相关存储过程名
        public const string AddExamineeCompanyInfo = "AddExamineeCompanyInfo";
        public const string GetAllExamineeCompanyInfo = "GetAllExamineeCompanyInfo";
        public const string UpdExamineeCompanyInfo = "UpdExamineeCompanyInfo";
        public const string DelExamineeCompanyInfo = "DelExamineeCompanyInfo";
        // add by wuxin at 2018/5/31 - start
        public const string GetExamineeCompanyIDByExamineeCompanyName = "GetExamineeCompanyIDByExamineeCompanyName";
        // add by wuxin at 2018/5/31 - end
        // add by wuxin at 2020/1/7 - start
        public const string GetExamineeCompanyNameByExamineeCompanyID = "GetExamineeCompanyNameByExamineeCompanyID";
        // add by wuxin at 2020/1/7 - end


        // 考生信息相关存储过程名
        // del by wuxin at 2018/5/30 - start
        //public const string GetNewIDFromExamineeInfoTable = "GetNewIDFromExamineeInfoTable";
        // del by wuxin at 2018/5/30 - end
        // add by wuxin at 2018/5/30 - start
        public const string GetLastExamineeID = "GetLastExamineeID";
        // add by wuxin at 2018/5/30 - end

        public const string AddExamineeInfo = "AddExamineeInfo";
        public const string GetAllExamineeInfo = "GetAllExamineeInfo";
        public const string DelExamineeInfo = "DelExamineeInfo";
        public const string UpdExamineeInfo = "UpdExamineeInfo";
        public const string GetExamineeInfoByExamineeID = "GetExamineeInfoByExamineeID";
        // add by wuxin at 2018/6/2 - start
        public const string GetExamineeInfoByIDCardNum = "GetExamineeInfoByIDCardNum";
        // add by wuxin at 2018/6/2 - end

        // 考试科目信息相关存储过程名
        public const string GetExaminationSubjectInfoByExamineeSubjectID = "GetExaminationSubjectInfoByExamineeSubjectID";
        public const string GetAllExaminationSubjectInfo = "GetAllExaminationSubjectInfo";
        public const string GetAllExaminationSubjectInfoByExaminationID = "GetAllExaminationSubjectInfoByExaminationID";
        // add by wuxin at 2019/12/04 - start
        public const string AddExaminationSubjectInfo = "AddExaminationSubjectInfo";
        public const string DelExaminationSubjectInfo = "DelExaminationSubjectInfo";
        // add by wuxin at 2019/12/04 - end

        // add by wuxin at 2019/12/06 - start
        // 考试项目信息相关存储过程名
        public const string AddExaminationItemInfo = "AddExaminationItemInfo";
        public const string AddExaminationItemDetailInfo = "AddExaminationItemDetailInfo";
        public const string GetLatestExaminationItemID = "GetLatestExaminationItemID";
        public const string GetExaminationItemInfoByExaminationItemID = "GetExaminationItemInfoByExaminationItemID";
        public const string GetExaminationItemInfoByExaminationSubjectID = "GetExaminationItemInfoByExaminationSubjectID";
        public const string GetExaminationItemDetailInfoByExaminationItemID = "GetExaminationItemDetailInfoByExaminationItemID";
        public const string DelExaminationItemInfo = "DelExaminationItemInfo";

        // add by wuxin at 2019/12/06 - end


        // 考试结果信息相关存储过程名
        public const string GetExamResultDetailByExamResultID = "GetExamResultDetailByExamResultID";
        public const string GetExamResultDetailByExamResultIDAndExamSubjectID = "GetExamResultDetailByExamResultIDAndExamSubjectID";
        // add by wuxin at 2019/12/02 - start
        public const string GetData = "GetData";
        // add by wuxin at 2019/12/02 - end

        // del by wuxin at 2018/5/30 - start
        //public const string GetNewExaminationResultID = "GetNewExaminationResultID";
        // del by wuxin at 2018/5/30 - end
        public const string AddExaminationResultInfo = "AddExaminationResultInfo";

        // add by wuxin at 2018/5/30 - start
        public const string GetLastExaminationResultID = "GetLastExaminationResultID";
        // add by wuxin at 2018/5/30 - end

        // add by wuxin at 2018/10/14 - start
        public const string DelExaminationResultInfo = "DelExaminationResultInfo";
        // add by wuxin at 2018/10/14 - end

        // 考试机信息相关存储过程名
        public const string AddExaminationPCInfo = "AddExaminationPCInfo";
        public const string GetAllExaminationPCInfo = "GetAllExaminationPCInfo";
        public const string UpdExaminationPCInfo = "UpdExaminationPCInfo";
        public const string DelExaminationPCInfo = "DelExaminationPCInfo";

        // 用户相关存储过程名
        public const string AddUserInfo = "AddUserInfo";
        public const string GetAllUserInfo = "GetAllUserInfo";
        public const string GetAllUserInfoByID = "GetAllUserInfoByID";
        public const string IsUserExist = "IsUserExist";
        public const string UpdUserInfo = "UpdUserInfo";
        public const string DelUserInfo = "DelUserInfo";
        public const string GetUserLevelByUserName = "GetUserLevelByUserName";
        public const string IsUserNameExist = "IsUserNameExist";

        // 分页用
        public const string GetDataWithPage = "GetDataWithPage";

        // add by wuxin at 2018/09/10 - start
        public const string GetAllSystemInfo = "GetAllSystemInfo";
        public const string UpdSystemInfo = "UpdSystemInfo";
        // add by wuxin at 2018/09/10 - end

        // 获取控制进程的信息
        public const string GetAllAppInfo = "GetProcessControlAppInfo";
        public const string GetAllAppInfoByName = "GetProcessControlInfoByName";
        public const string AddOrUpdateProcessControlInfo = "AddOrUpdateProcessControlInfo";
        public const string GetProcessControlAppName = "GetProcessControlAppName";
        public const string DelProcessControlInfoByAppName = "DelProcessControlInfoByAppName";

        // 其他设备控制
        public const string GetDeviceInfo = "GetDeviceInfo";
        public const string GetDeviceClassNameInfo = "GetDeviceClassNameInfo";
        public const string GetDeviceIPInfo = "GetDeviceIPInfo";
        public const string GetDeviceSerialInfo = "GetDeviceSerialInfo";
        public const string GetDeviceBaudInfo = "GetDeviceBaudInfo";
        public const string GetDeviceUseSerialInfo = "GetDeviceUseSerialInfo";
        public const string AddOrUpdateDeviceInfo = "AddOrUpdateDeviceInfo";
        public const string DelDeviceInfoByClassName = "DelDeviceInfoByClassName";

        // 服务端
        public const string AddOrUpdateServerInfo = "AddOrUpdateServerInfo";
        public const string GetServerInfo = "GetServerInfo";

        // 获取文件
        public const string GetFileAppInfo = "GetFileAppInfo";
        public const string GetFileAppinfoByName = "GetFileAppinfoByName";
        public const string GetFileAppName = "GetFileAppName";
        public const string AddOrUpdateFileInfo = "AddOrUpdateFileInfo";
        public const string DeleteFileInfo = "DeleteFileInfo";

        // 更新客户端
        public const string AddOrUpdateUpdateClientInfo = "AddOrUpdateUpdateClientInfo";
        public const string GetUpdateClientInfo = "GetUpdateClientInfo";





    }
}
