using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using OCC.Forms.OCC_Controls;

namespace OCC.Core
{
    public class DataManager : LockedSingletonClass<DataManager>
    {

        #region UserData

        public UserDataModel CurrentLoginUserData;


        public UserTypeDataModel CurrentUserAuthData;




        #endregion

        #region Commom Info

        public List<CompanyDataModel> CompanyDatas;

        public List<UserTypeDataModel> UserTypeDatas;

        public void GetCommonInfos()
        {
            CompanyDatas = new List<CompanyDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllCompanyInfo(out CompanyDatas))
            {

            }

            UserTypeDatas = new List<UserTypeDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllUserTypeInfo(out UserTypeDatas))
            {

            }            
        }



        
      
        #endregion

    }
}
