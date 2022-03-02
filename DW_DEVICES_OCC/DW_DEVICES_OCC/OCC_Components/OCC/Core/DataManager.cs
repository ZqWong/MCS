using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace OCC.Core
{
    public class DataManager : LockedSingletonClass<DataManager>
    {
        public UserDataModel CurrentLoginUserData { get; set; }




    }
}
