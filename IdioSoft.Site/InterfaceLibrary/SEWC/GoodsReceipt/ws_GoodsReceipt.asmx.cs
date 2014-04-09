using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using IdioSoft.Site.DB.Tables.SEWC;
using System.Text;
using System.IO;
using System.Data;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.GoodsReceipt
{
    /// <summary>
    /// Summary description for ws_GoodsReceipt
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ws_GoodsReceipt : IWebService
    {
 
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public string subDB_Save(Dictionary<string, string>[] ParamsList)
        {
            string strReturn = "";
            string strError;
            string strSQL = "";
            //SEWC_GoodsReceipt_Info objTableSave = new SEWC_GoodsReceipt_Info();
            ITable objTable = new CTable(SEWC_GoodsReceipt_Info.GetInstance());
            objTable.SetValues(ParamsList[0]);
            objTable.RecordExistWhere = "uRequestID = '" + SEWC_GoodsReceipt_Info.GetInstance().uRequestID.FieldValue + "'";
            SEWC_GoodsReceipt_Info.GetInstance().ModifyDate.FieldValue = DateTime.Now;
            SEWC_GoodsReceipt_Info.GetInstance().CreateUser.FieldValue = ((IdioSoft.Site.ClassLibrary.UserInfo)Session["UserInfo"]).UserID;

            strError = objTable.Save();
            if (strError == "")
            {
                if (SEWC_GoodsReceipt_Info.GetInstance().IsReject.FieldValue.ToString().funBoolean_StringToBoolean())
                {
                    strSQL = "update webinfo_serviceRequest_Info set isCancel=1 where ID='" + SEWC_GoodsReceipt_Info.GetInstance().uRequestID.FieldValue + "'";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
                subDB_SaveRequest(SEWC_GoodsReceipt_Info.GetInstance().uRequestID.FieldValue.ToString(), SEWC_GoodsReceipt_Info.GetInstance().ProductName.FieldValue,
                    SEWC_GoodsReceipt_Info.GetInstance().ProductDesc.FieldValue, SEWC_GoodsReceipt_Info.GetInstance().MLFB.FieldValue, 
                    SEWC_GoodsReceipt_Info.GetInstance().SerialNo.FieldValue, (Int32)SEWC_GoodsReceipt_Info.GetInstance().Qty.FieldValue, SEWC_GoodsReceipt_Info.GetInstance().Warranty.FieldValue);
                strReturn = "";
            }
            else
            {
                strReturn = "error";//失败
            }
            return strReturn;
        }

        public void subDB_SaveRequest(string uRequestID, string ProductName, string ProdutDesc, string MLFB, string SerialNo, int Qty, string Warranty)
        {
            string strSQL = "";
            strSQL = "update webinfo_serviceRequest_Info set ProductName='" + ProductName + "',ProductDesc='" + ProdutDesc + "',MLFBNo='" + MLFB + "',SerialNo='" + SerialNo + "',Warranty='" + Warranty + "' where ID='" + uRequestID + "'";
            strSQL += "\n update webInfo_Servicerequest_Material_Info set MLFB='" + MLFB + "',SerialNo='" + SerialNo + "',Quantity=" + Qty + " where uRequestID='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            strSQL = "update webinfo_serviceRequest_Material_Info set MLFB='" + MLFB + "',SerialNo='" + SerialNo + "',Quantity=" + Qty + " where uRequestID='" + uRequestID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
        }

        [WebMethod(EnableSession = true)]
        public string subDB_DeleteFile(string uRequestID)
        {
            string strSQL = "";
            strSQL = "update SEWC_GoodsReceipt_Info set RejectFile='' where uRequestID='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            IdioSoft.Site.ClassLibrary.UserInfo objUserInfo = ((IdioSoft.Site.ClassLibrary.UserInfo)Session["UserInfo"]);
            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Delete Goods Receipt File", objUserInfo.UserID.ToString(), objUserInfo.EnUserName);
            if (strError == "")
            {
                return "";
            }
            else
            {
                return "error";
            }
        }

        [WebMethod(EnableSession = true)]
        public void subUploadFile()
        {
            HttpContext context = HttpContext.Current;
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
                return ;
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
                return ;
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
                        strSQL += "'" + uRequestID + "','" + RequestID + "','" + ProductName + "','" + ProductDesc + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",0,'" + Reason + "','" + fullFileName;
                        strSQL += "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + objUserInfo.UserID + ")";
                    }
                    string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }
 
            context.Response.Clear();

            sbReturn.Append("{");
            sbReturn.Append("\"fileName\":\"" + fullFileName + "\",\"iserror\":false,\"sfile\":\"" + fullFileName + "\"");
            sbReturn.Append("}");

            context.Response.Write(sbReturn.ToString());
            context.Response.Flush();
            context.Response.End();
        }
    }
}
