using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Common.Method
{
 /// <summary>
    /// 日志操作类
    /// </summary>
    public static class OperationLog
    {
        /// <summary>   
        /// 将操作日志文件写入数据库(Text)
        /// </summary>   
        /// <param name="OperationDescription">操作描述</param>
        /// <param name="OperationUserID">操作人的ID</param>
        /// <param name="OperationUserName">操作人姓名</param>
        public static void InsertTextLog(this string OperationDescription, string OperationUserID, string OperationUserName)
        {
            try
            {
                IdioSoft.Common.Method.DbSQLAccess objDbAccess = new DbSQLAccess();
                string strSQL = "INSERT INTO WMS_System_TextLog(OperDesc, CreateDate, CreateUserID, CreateUser) VALUES ('";
                strSQL = strSQL + OperationDescription + "'," + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + OperationUserID + "', '" + OperationUserName + "')";
                objDbAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            catch
            {

            }
        }

        /// <summary>   
        /// 将操作日志文件写入数据库(SQL)
        /// </summary>   
        /// <param name="OperationSQL">操作的SQL语句或存储过程名</param>
        /// <param name="OperationDescription">操作描述</param>
        /// <param name="OperationUserID">操作人的ID</param>
        public static void InsertSQLLog(this string OperationSQL, string OperationDescription, string OperationUserID, string OperationUserName)
        {
            try
            {
                IdioSoft.Common.Method.DbSQLAccess objDbAccess = new DbSQLAccess();
                string strSQL = "INSERT INTO WMS_System_SQLLog(SQLText, OperDesc, CreateDate, CreateUserID, CreateUser) VALUES ('";
                strSQL = strSQL + OperationSQL.funString_SQLToString() + "','" + OperationDescription.funString_SQLToString() + "',";
                strSQL = strSQL + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + OperationUserID + "', '" + OperationUserName + "')";
                objDbAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            catch
            {

            }
        }
    }
}
