using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCache
{
    public class GroupDataCache
    {
        public GroupDataCache() 
        {
            GroupExecuteDatas = new List<GroupDeviceExecuteDataModel>();
        }

        public GroupDataCache(int groupId) 
        {
            GroupExecuteDatas = new List<GroupDeviceExecuteDataModel>();
        }


        public int GroupId;

        public string GroupName;

        public GroupDataModel GroupData;

        public List<GroupDeviceExecuteDataModel> GroupExecuteDatas;
    }
}
