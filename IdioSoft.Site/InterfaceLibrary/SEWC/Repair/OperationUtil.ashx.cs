using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Text;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Repair
{
    /// <summary>
    /// Summary description for OperationUtil
    /// </summary>
    public class OperationUtil : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string sType = context.funString_RequestFormValue("Type");
            switch (sType)
            {
                case "PCBA5ENo":
                    subPCBA5ENo(context);
                    break;
                case "RepairedComponent":
                    subRepairedComponent(context);
                    break;
                case "FailureType":
                    subFailureType(context);
                    break;
                case "FailureKind":
                    subFailureCode(context);
                    break;
                default:
                    break;
            }
        }


        #region "PCBA5ENo"
        private void subPCBA5ENo(HttpContext context)
        {
            string strSQL = "";
            string q = context.funString_RequestFormValue("q");
            strSQL = @"SELECT    PCBA5ENo FROM SEWC_Basic_PCBA5ENo_Info where PCBA5ENo like '%"+q+"%' order by PCBA5ENo";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append(ds.Tables[0].Rows[i]["PCBA5ENo"].ToString() + "\n");
                }
            }

            string strReturn = sb.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            context.Response.Write(strReturn);
            context.Response.End();
        }
        #endregion

        #region "RepairedComponent"
        private void subRepairedComponent(HttpContext context)
        {
            string strSQL = "";
            string q = context.funString_RequestFormValue("q");
            strSQL = @"SELECT   RepairedComponentA5E FROM         SEWC_Basic_RepairedComponentA5E_Info where RepairedComponentA5E like '%" + q + "%' order by RepairedComponentA5E";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append(ds.Tables[0].Rows[i]["RepairedComponentA5E"].ToString() + "\n");
                }
            }

            string strReturn = sb.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            context.Response.Write(strReturn);
            context.Response.End();
        }
        #endregion

        #region "FailureType"
        private void subFailureType(HttpContext context)
        {
            string FailureType = context.funString_RequestFormValue("FailureType");
            string strSQL = @"SELECT FailureKind  FROM SEWC_Basic_FailureCode_Info where  Type='"+FailureType+"' and isdel=0 group by FailureKind order by FailureKind";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sbReturn = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["FailureKind"].ToString() + "\",");
                }
            }
            string strReturn = sbReturn.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            strReturn = "[" + strReturn + "]";
            context.Response.ContentType = "text/plain";
            context.Response.Write(strReturn);
        }
        #endregion

        #region "FailureCode"
        private void subFailureCode(HttpContext context)
        {
            string FailureType = context.funString_RequestFormValue("FailureType");
            string FailureKind = context.funString_RequestFormValue("FailureKind");
            string strSQL = @"SELECT FCode  FROM SEWC_Basic_FailureCode_Info where isdel=0 and Type='" + FailureType + "' and FailureKind='" + FailureKind+"'";
            string FCode = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            context.Response.ContentType = "text/plain";
            context.Response.Write(FCode);
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}