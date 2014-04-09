using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace IdioSoft.Common.Method
{
    /// <summary>
    /// ���ݿ������
    /// </summary>
    public class DbSQLAccess
    {
        private SqlConnection conn = new SqlConnection();
        private string strConn = "";
        /// <summary>
        /// ��ʹ����
        /// </summary>
        public DbSQLAccess()
        {
            try
            {
                this.strConn = ConfigurationManager.ConnectionStrings["DataConnString"].ToString();
                this.conn = new SqlConnection();
                //ȫ����������
                this.conn.ConnectionString = this.strConn;
            }
            catch
            {

            }
        }
        /// <summary>
        /// �Զ������ݿ�����
        /// </summary>
        /// <param name="ConfingKey"></param>
        public DbSQLAccess(string ConfingKey)
        {
            try
            {
                this.strConn = ConfigurationManager.ConnectionStrings[ConfingKey].ToString();
                this.conn = new SqlConnection();
                //ȫ����������
                this.conn.ConnectionString = this.strConn;
            }
            catch
            {

            }
        }

        #region "���ݿ����ӿ��ز���"
        //Open���ݿ�
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
        //Close ���ݿ�����
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
        #region "SQL������ݿ����"
        /// <summary>   
        /// ����һ��DataSet
        /// </summary>   
        /// <param name="strSQL">SQL���</param>
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
        /// ����һ��DataSet
        /// </summary>   
        /// <param name="strSQL">SQL���</param>
        public DataSet funDataset_SQLExecuteNonQuery(string strSQL,string TableName)
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
        /// ����һ��DataSet
        /// </summary>   
        /// <param name="strSQL">SQL���</param>
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
        /// ����һ��DataSet
        /// </summary>
        /// <param name="strSQL">SQL���</param>
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
        /// ����һ��DataSet
        /// </summary>
        /// <param name="strSQL">SQL���</param>
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
        /// ����һ��DataSet
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="intStartRow">Start RowIndex</param>
        /// <param name="intMaxCount">PageSize</param>
        /// <returns></returns>
        public DataSet funDataset_SQLExecuteNonQuery(ref int TotalRow, string strSQL, int intStartRow, int intMaxCount,string TmpDtname)
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
        /// �޷���ִ��SQL,������ز�Ϊ��,��Ϊ�д�
        /// </summary>   
        /// <param name="strSQL">SQL���</param>
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
        /// ����һ����һ��ֵ
        /// </summary>   
        /// <param name="strSQL">SQL���</param>
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
        #region "�ô洢���̿���"
        /// <summary>   
        /// �޷��ش洢����,��ɷ�������,���ؿ�ʱΪ����.
        /// </summary>   
        /// <param name="ls">�����б�</param>
        /// <param name="spName">�洢������</param>
        public string funString_SPExecuteNonQuery(List<object> ls, string spName)
        {
            string strReturn = "";
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //��ʹ������
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
        /// ����һ����������
        /// </summary>   
        /// <param name="ls">�����б�</param>
        /// <param name="spName">�洢������</param>
        public string funString_SPExecuteScalar(List<object> ls, string spName)
        {
            string strReturn = "";
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //��ʹ������
            SqlCommandBuilder.DeriveParameters(sqlcom);
            for (int i = 0; i < ls.Count; i++)
            {
                sqlcom.Parameters[i + 1].Value = (ls[i] == null) ? DBNull.Value : ls[i];
            }
            try
            {
                //����һ������ֵ
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
        /// ����һ��DataTable
        /// </summary>   
        /// <param name="ls">�����б�</param>
        /// <param name="spName">�洢������</param>
        public DataTable funDataTable_SPExecuteNonQuery(List<object> ls, string spName)
        {
            DataTable dt = new DataTable();
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //��ʹ������
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
                //����һ��DataTable
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
        /// ����һ��DataTable
        /// </summary>   
        /// <param name="ls">�����б�</param>
        /// <param name="spName">�洢������</param>
        public DataTable funDataTable_SPExecuteNonQuery(List<object> ls, string spName,string ReturnName, ref object ReturnValue)
        {
            DataTable dt = new DataTable();
            this.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Connection = conn;
            sqlcom.CommandText = spName;
            //��ʹ������
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
                //����һ��DataTable
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