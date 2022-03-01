﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;
using UserEventData;

namespace UserEventData
{

    public class C_FileInfoData : EventData
    {

        public List<DriveInfo> driveInfoList;

        public List<FileInfo> fileInfoList;
        public List<DirectoryInfo> directoryInfoList;

        
            

        public string nodeName;
    }



}
