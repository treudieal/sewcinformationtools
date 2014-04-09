using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IdioSoft.Business.Frames
{
    public class Columns
    {
        /// <summary>
        /// 取得列名
        /// </summary>
        /// <returns></returns>
        public string ColumnsToString()
        {

            StringBuilder sb = new StringBuilder();
            List<string> lst = ColumsList();
            foreach (var item in lst)
            {
                sb.Append(item + ",");
            }
            string strReturn = sb.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            return strReturn;

        }

        /// <summary>
        /// 取得列List
        /// </summary>
        /// <returns></returns>
        public List<string> ColumsList()
        {

            List<string> lstColumn = new List<string>();
            Type t = this.GetType();
            foreach (var item in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (item.PropertyType.IsClass)
                {
                    lstColumn.Add(item.Name);
                }
            }
            return lstColumn;

        }

        /// <summary>
        /// 字段个数
        /// </summary>
        public int Count
        {
            get
            {
                return ColumsList().Count;
            }
        }
    }
}
