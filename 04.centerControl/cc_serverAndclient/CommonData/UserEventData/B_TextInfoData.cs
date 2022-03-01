using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    public class B_TextInfoData
    {
        public string Name;
        public string Value;

        public B_TextInfoData()
        {
        }

        public B_TextInfoData(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
