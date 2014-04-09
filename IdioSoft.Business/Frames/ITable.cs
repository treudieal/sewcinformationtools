using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Business.Frames
{
    public interface ITable : IDBUnit
    {


        string RecordExistWhere { get; set; }

        string RecordUpdateWhere { get; set; }

        string RecordDeleteWhere { get; set; }

        /// <summary>
        /// 保存写入数据库
        /// </summary>
        string Save();

        /// <summary>
        /// 保存任意的参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Save(params Object[] args);
 
        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <returns></returns>
        bool isRecordExist();

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        string Delete();

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        string Delete(string Where);

        /// <summary>
        /// 自动赋值
        /// </summary>
        /// <param name="dic"></param>
        void SetValues(Dictionary<string, string> dic);
    }
}
