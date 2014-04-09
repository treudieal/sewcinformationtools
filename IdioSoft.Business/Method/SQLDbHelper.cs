﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IdioSoft.Business.Method
{
    public class SQLDbHelper
    {
        private SqlConnection conn = new SqlConnection();
        private string strConn = "";

        private static SQLDbHelper instance;
        public static SQLDbHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new SQLDbHelper();
            }
            return instance;
        }

        public static SQLDbHelper GetInstance(string ConfingKey)
        {
            if (instance == null)
            {
                instance = new SQLDbHelper(ConfingKey);
            }
            return instance;
        }

        /// <summary>
        /// 初使化类
        /// </summary>
        public SQLDbHelper()
        {
            try
            {
                this.strConn = ConfigurationManager.ConnectionStrings["DataConnString"].ToString();
                this.conn = new SqlConnection();
                //全局数据连接
                this.conn.ConnectionString = this.strConn;
            }
            catch
            {

            }
        }
        /// <summary>
        /// 自定义数据库连接
        /// </summary>
        /// <param name="ConfingKey"></param>
        public SQLDbHelper(string ConfingKey)
        {
            try
            {
                this.strConn = ConfigurationManager.ConnectionStrings[ConfingKey].ToString();
                this.conn = new SqlConnection();
                //全局数据连接
                this.conn.ConnectionString = this.strConn;
            }
            catch
            {

            }
        }

        #region "数据库连接开关操作"
        //Open数据库
        private void Open()
        {
            if ((conn.State == System.Data.ConnectionState.Closed) || (conn.State == ConnectionState.Broken))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                }
            }
        }
        //Close 数据库连接
        private void Close()
        {
            try
            {
                conn.Close();
            }
            catch
            {
            }
        }
        #endregion
        #region "SQL语句数据库操作"
        /// <summary>   
        /// 返回一个DataSet
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>
        public DataSet funDataset_SQLExecuteNonQuery(string strSQL)
        {
            DataSet dsMain = new DataSet();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                daMain.Fill(dsMain);
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }


        /// <summary>   
        /// 返回一个DataSet
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>
        public DataSet funDataset_SQLExecuteNonQuery(string strSQL, string TableName)
        {
            DataSet dsMain = new DataSet();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                daMain.Fill(dsMain, TableName);
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }


        /// <summary>   
        /// 返回一个DataSet
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>
        public DataSet funDataset_SQLExecuteNonQuery(string strSQL, string TableName, ref DataSet dsMain)
        {
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                daMain.Fill(dsMain, TableName);
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }

        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="intStartRow">Start RowIndex</param>
        /// <param name="intMaxCount">PageSize</param>
        /// <returns></returns>
        public DataSet funDataset_SQLExecuteNonQuery(string strSQL, int intStartRow, int intMaxCount)
        {
            DataSet dsMain = new DataSet();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                daMain.Fill(dsMain, intStartRow, intMaxCount, "TempTable");
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }

        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="intStartRow">Start RowIndex</param>
        /// <param name="intMaxCount">PageSize</param>
        /// <returns></returns>
        public DataSet funDataset_SQLExecuteNonQuery(ref int TotalRow, string strSQL, int intStartRow, int intMaxCount)
        {
            DataSet dsMain = new DataSet();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                DataSet ds1 = new DataSet();
                daMain.Fill(ds1);
                TotalRow = ds1.Tables[0].Rows.Count;
                daMain.Fill(dsMain, intStartRow, intMaxCount, "TempTable");
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }


        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="intStartRow">Start RowIndex</param>
        /// <param name="intMaxCount">PageSize</param>
        /// <returns></returns>
        public DataSet funDataset_SQLExecuteNonQuery(ref int TotalRow, string strSQL, int intStartRow, int intMaxCount, string TmpDtname)
        {
            DataSet dsMain = new DataSet();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                sqlcom.ExecuteNonQuery();
                DataSet ds1 = new DataSet();
                daMain.Fill(ds1);
                TotalRow = ds1.Tables[0].Rows.Count;
                daMain.Fill(dsMain, intStartRow, intMaxCount, TmpDtname);
            }
            catch
            {
                dsMain = null;
            }
            finally
            {
                this.Close();
            }
            return dsMain;
        }

        /// <summary>   
        /// 无返回执行SQL,如果返回不为空,则为有错
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>
        public string funString_SQLExecuteNonQuery(string strSQL)
        {
            string strError = "";
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.CommandType = CommandType.Text;
                sqlcom.CommandTimeout = 600;
                sqlcom.Connection = conn;
                sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strError = ex.Message + "\n" + strSQL;
            }
            finally
            {
                this.Close();
            }
            return strError;
        }
        /// <summary>   
        /// 返回一个单一的值
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>
        public string funString_SQLExecuteScalar(string strSQL)
        {
            string strReturn = "";
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                this.Open();
                sqlcom.CommandText = strSQL;
                sqlcom.Connection = conn;
                sqlcom.CommandTimeout = 600;
                strReturn = sqlcom.ExecuteScalar().ToString();
            }
            catch
            {
                strReturn = "";
            }
            finally
            {
                this.Close();
            }
            return strReturn;
        }
        #endregion
        #region "用存储过程开发"
        /// <summary>   
        /// 无返回存储过程,这可返回行数,返回空时为出错.
        /// </summary>   
        /// <param name="ls">参数列表</param>
        /// <param name="spName">存储过程名</param>
        public string funString_SPExecuteNonQuery(List<object> ls, string spName)
        {
            string strReturn = "";
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //初使化参数
            SqlCommandBuilder.DeriveParameters(sqlcom);
            for (int i = 0; i < ls.Count; i++)
            {
                sqlcom.Parameters[i + 1].Value = (ls[i] == null) ? DBNull.Value : ls[i];
            }
            try
            {
                sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strReturn = ex.Message + "\n" + spName;
            }
            finally
            {
                this.Close();
            }
            return strReturn;
        }
        /// <summary>   
        /// 返回一个数据内容
        /// </summary>   
        /// <param name="ls">参数列表</param>
        /// <param name="spName">存储过程名</param>
        public string funString_SPExecuteScalar(List<object> ls, string spName)
        {
            string strReturn = "";
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //初使化参数
            SqlCommandBuilder.DeriveParameters(sqlcom);
            for (int i = 0; i < ls.Count; i++)
            {
                sqlcom.Parameters[i + 1].Value = (ls[i] == null) ? DBNull.Value : ls[i];
            }
            try
            {
                //返回一个数据值
                strReturn = sqlcom.ExecuteScalar().ToString();
            }
            catch
            {
                strReturn = "";
            }
            finally
            {
                this.Close();
            }
            return strReturn;
        }

        /// <summary>   
        /// 返回一个DataTable
        /// </summary>   
        /// <param name="ls">参数列表</param>
        /// <param name="spName">存储过程名</param>
        public DataTable funDataTable_SPExecuteNonQuery(List<object> ls, string spName)
        {
            DataTable dt = new DataTable();
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //初使化参数
            SqlCommandBuilder.DeriveParameters(sqlcom);
            for (int i = 0; i < ls.Count; i++)
            {
                sqlcom.Parameters[i + 1].Value = (ls[i] == null) ? DBNull.Value : ls[i];
            }
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                //返回一个DataTable
                sqlcom.ExecuteNonQuery();
                daMain.Fill(ds);
                dt = ds.Tables[0];
                //string name = sqlcom.Parameters["@TotalCount"].Value.ToString();
            }
            catch
            {
                dt = null;
            }
            finally
            {
                this.Close();
            }
            return dt;
        }


        /// <summary>   
        /// 返回一个DataTable
        /// </summary>   
        /// <param name="ls">参数列表</param>
        /// <param name="spName">存储过程名</param>
        public DataTable funDataTable_SPExecuteNonQuery(List<object> ls, string spName, string ReturnName, ref object ReturnValue)
        {
            DataTable dt = new DataTable();
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //初使化参数
            SqlCommandBuilder.DeriveParameters(sqlcom);
            for (int i = 0; i < ls.Count; i++)
            {
                sqlcom.Parameters[i + 1].Value = (ls[i] == null) ? DBNull.Value : ls[i];
            }
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter daMain = new SqlDataAdapter();
                daMain.SelectCommand = sqlcom;
                //返回一个DataTable
                sqlcom.ExecuteNonQuery();
                daMain.Fill(ds);
                dt = ds.Tables[0];
                ReturnValue = sqlcom.Parameters["@" + ReturnName].Value.ToString();
            }
            catch
            {
                dt = null;
            }
            finally
            {
                this.Close();
            }
            return dt;
        }

        #endregion
    }
}
