using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace IdioSoft.Business.Method
{
    public class LogHelper
    {
        public string LogPath { get; set; }

        private static LogHelper instance;

        public static LogHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new LogHelper();
            }
            return instance;
        }

        public static LogHelper GetInstance(string LogPath)
        {
            if (instance == null)
            {
                instance = new LogHelper(LogPath);
            }
            return instance;
        }

        public LogHelper()
        {

        }


        public LogHelper(string LogPath)
        {
            this.LogPath = LogPath;
        }



        public void Save(string Log)
        {
            try
            {
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                string LogFile = LogPath  + DateTime.Now.ToString("yyyyMMdd") + ".log";
                File.AppendAllText(LogFile, Log + "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")" + System.Environment.NewLine + "******************" + System.Environment.NewLine);
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
        public void InsertSQLLog(string OperationSQL, string OperationDescription, string OperationUserID, string OperationUserName)
        {
            try
            {
                IdioSoft.Business.Method.SQLDbHelper objSQLDbHelper = new SQLDbHelper();
                string strSQL = "INSERT INTO WMS_System_SQLLog(SQLText, OperDesc, CreateDate, CreateUserID, CreateUser) VALUES ('";
                strSQL = strSQL + OperationSQL.funString_SQLToString() + "','" + OperationDescription.funString_SQLToString() + "',";
                strSQL = strSQL + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + OperationUserID + "', '" + OperationUserName + "')";
                objSQLDbHelper.funString_SQLExecuteNonQuery(strSQL);
            }
            catch
            {

            }
        }
    }
}
