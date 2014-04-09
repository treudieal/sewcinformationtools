using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Business.Frames
{
    /// <summary>
    /// 用户操作界面接口
    /// </summary>
    public interface IPForm
    {
        /// <summary>
        /// 操作KeyID
        /// </summary>
        string OperID { get; set; }
        /// <summary>
        /// 载入详细信息
        /// </summary>
        void subDB_Detail();
        
    }
}
 