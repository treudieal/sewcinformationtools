using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using IdioSoft.Common.Method;
using IdioSoft.Site.ClassLibrary;
using System.Collections;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.GoodsReceipt
{
    /// <summary>
    /// Summary description for UpLoadFile
    /// </summary>
    public class UpLoadFile : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            StringBuilder sbReturn = new StringBuilder();
            //context.Response.ContentType = "text/plain";
            if (context.Request.ServerVariables["HTTP_REFERER"] == null)
            {
                context.Response.Write("不要这样访问");
                context.Response.End();
            }

            string uRequestID = "";
            try
            {
                uRequestID = context.Request["uRequestID"].ToString();
            }
            catch (Exception)
            {

            }
            if (uRequestID == "")
            {
                context.Response.Clear();
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.Write(sbReturn.ToString());
                context.Response.Flush();
                context.Response.End();
                return;
            }
            string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
            string sName = Path.GetFileNameWithoutExtension(context.Request.Files[0].FileName);
            string fullFileName = sName + strExtension;
            string dir = context.Server.MapPath("../../../Attachment/SEWC/");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string strSaveLocation = dir + fullFileName;
            if (File.Exists(strSaveLocation))
            {
                try
                {
                    File.Delete(strSaveLocation);
                }
                catch (Exception)
                {

                }
            }
            if (context.Request.Files[0].ContentLength <= 0)
            {
                context.Response.Clear();
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.Write(sbReturn.ToString());
                context.Response.Flush();
                context.Response.End();
                return;
            }
            context.Request.Files[0].SaveAs(strSaveLocation);
            string strSQL = "";
            string Reason = context.Request["Reason"].ToString();
            //做业务
            if (fullFileName != "")
            {
                strSQL = "select RequestID, Warranty,ProductDesc,ProductName from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";
                DataSet dsMain = new DataSet();
                dsMain = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                if (dsMain != null && dsMain.Tables[0].Rows.Count > 0)
                {
                    string RequestID = dsMain.Tables[0].Rows[0]["RequestID"].ToString();
                    string ProductName = dsMain.Tables[0].Rows[0]["ProductName"].ToString();
                    string ProductDesc = dsMain.Tables[0].Rows[0]["ProductDesc"].ToString();

                    strSQL = "select top 1 MLFB,SerialNo, Quantity from webInfo_Servicerequest_Material_Info where uRequestID = '" + uRequestID + "'";
                    DataSet dsItem = new DataSet();
                    dsItem = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                    string MLFB = "";
                    string SerialNo = "";
                    int Qty = 0;

                    if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
                    {
                        MLFB = dsItem.Tables[0].Rows[0]["MLFB"].ToString();
                        SerialNo = dsItem.Tables[0].Rows[0]["SerialNo"].ToString();
                        Qty = dsItem.Tables[0].Rows[0]["Quantity"].ToString().funInt_StringToInt(0);
                    }

                    strSQL = "select count(*) from SEWC_GoodsReceipt_Info where uRequestID = '" + uRequestID + "'";
                    int intCount = 0;
                    intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
                    if (intCount > 0)
                    {
                        strSQL = @"update SEWC_GoodsReceipt_Info set RejectReason = '" + Reason + "',RejectFile = '" + fullFileName + "',ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        strSQL += "',ModifyUser = " + objUserInfo.UserID + " where uRequestID = '" + uRequestID + "'";
                    }
                    else
                    {
                        strSQL = @"insert into SEWC_GoodsReceipt_Info(uRequestID,RequestID,ProductName,ProductDesc, MLFB, SerialNo, Qty,IsReject,RejectReason,RejectFile,CreateDate, CreateUser) values(";
                        strSQL += "'" + uRequestID + "','" + RequestID + "','" + ProductName+"','" + ProductDesc + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",0,'" + Reason + "','" + fullFileName;
                        strSQL += "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + objUserInfo.UserID + ")";
                    }
                    string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }
            ArrayList ary = new ArrayList();
            ary.Add(strSaveLocation);
            context.Response.Clear();

            sbReturn.Append("{");
            sbReturn.Append("\"fileName\":\"" + fullFileName + "\",\"iserror\":false,\"sfile\":\"" + fullFileName + "\"");
            sbReturn.Append("}");

            context.Response.Write(sbReturn.ToString());
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}