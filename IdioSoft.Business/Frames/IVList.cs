using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IdioSoft.Business.Frames
{
    public interface IVList
    {
        /// <summary>
        /// 需要显示的列
        /// </summary>
        string showColumns { get; set; }
        /// <summary>
        /// 操作的视图对象
        /// </summary>
        object objectView { get; set; }
        HttpContext context { get; set; }
        /// <summary>
        /// 取得JSON数据
        /// </summary>
        /// <returns></returns>
        string getData();
        //返回存储过程列表，用于导出
        List<object> SPList { get; set; }
        /// <summary>
        /// 扩展搜索条件
        /// </summary>
        string ExtendCondition { get; set; }
    }
}
