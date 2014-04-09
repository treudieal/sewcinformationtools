using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.ClassLibrary
{
    public class SQLInfo
    {
        public List<Object> lst { get; set; }
        public string SPName { get; set; }
    }
    public enum ExportSQlInfoKey
    {
        SEWC_Request = 1,
        SEWC_GoodsReceipt = 2,
        SEWC_IssueRepairOrder = 3,
        SEWC_Repair = 4,
        SEWC_Delivery = 5,
        SEWC_Finish = 6,
        SEWC_Reject = 7,
        SEWC_All = 8,
        User = 99
    }
}