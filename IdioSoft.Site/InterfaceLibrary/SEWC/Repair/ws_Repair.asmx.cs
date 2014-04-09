using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using IdioSoft.Site.ClassLibrary;

using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Repair
{
    /// <summary>
    /// Summary description for ws_Repair
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ws_Repair : System.Web.Services.WebService
    {
        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession=true)]
        public string funString_UploadFile()
        {
            string uRequestID="";
            HttpContext context = HttpContext.Current;
            try
            {
                uRequestID = context.Request["uRequestID"].ToString();
            }
            catch (Exception)
            {

            }

            StringBuilder sbReturn = new StringBuilder();
            if (uRequestID == "")
            {
                context.Response.Clear();
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.Write(sbReturn.ToString());
                context.Response.Flush();
                context.Response.End();
                return "";
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
                return "";
            }
            context.Request.Files[0].SaveAs(strSaveLocation);
            string strSQL = "";
            string RepairResult = context.Request["RepairResult"].ToString();
            UserInfo objUserInfo = (UserInfo)HttpContext.Current.Session["UserInfo"];
            //做业务
            if (fullFileName != "")
            {
                strSQL = @"SELECT     s.AppCompanyName, s.EnduserCompanyName, s.RequestID, s.MLFBNo, s.SerialNo, s.ServiceType, 
                s.ProductName, s.ProductDesc, s.Warranty, g.[FuntinalStateoriginal], g.[Firmwareoriginal], 
                      l.EnUserName, s.CreateUser
                        FROM dbo.webInfo_ServiceRequest_Info AS s INNER JOIN
                      dbo.SEWC_GoodsReceipt_Info AS g ON s.ID = g.uRequestID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS l ON s.CreateUser = l.ID
                        where s.ID = '" + uRequestID + "'";
                DataSet dsMain = new DataSet();
                dsMain = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                if (dsMain != null && dsMain.Tables[0].Rows.Count > 0)
                {
                    string Warranty = dsMain.Tables[0].Rows[0]["Warranty"].ToString();
                    string FuntinalStateo = dsMain.Tables[0].Rows[0]["FuntinalStateoriginal"].ToString();
                    string Firmwareo = dsMain.Tables[0].Rows[0]["Firmwareoriginal"].ToString();
                    string Engineer = objUserInfo.EnUserName;

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

                    strSQL = "select count(*) from SEWC_Repair_Info where uRequestID = '" + uRequestID + "'";
                    int intCount = 0;
                    intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
                    if (intCount > 0)
                    {
                        strSQL = @"update SEWC_Repair_Info set RejectFile = '" + fullFileName + "',ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        strSQL += "',ModifyUser = " + objUserInfo.UserID + " where uRequestID = '" + uRequestID + "'";
                    }
                    else
                    {
                        strSQL = @"insert into SEWC_Repair_Info(uRequestID, MLFB, SerialNo, Qty,Warranty,RepairResult,RejectFile,CreateDate, CreateUser) values(";
                        strSQL += "'" + uRequestID + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + Warranty + "','" + RepairResult + "','" + fullFileName;
                        strSQL += "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + objUserInfo.UserID + ")";
                    }
                    string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }
 

            sbReturn.Append("{");
            sbReturn.Append("\"fileName\":\"" + fullFileName + "\",\"iserror\":false,\"sfile\":\"" + fullFileName + "\"");
            sbReturn.Append("}");

            context.Response.Write(sbReturn);
            context.Response.End();
            return "";
        }


        [WebMethod]
        public string funStringImgStatus(string uRequestID)
        {
            string strimg = "";
            string strSQL = "";
            strSQL = @"SELECT ConfirmCompleteDate
                         FROM SEWC_Repair_Info where uRequestID='"+uRequestID+"'";
            string ConfirmCompleteDate = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            if (ConfirmCompleteDate.ToLower() == "")
            {
                strimg = "<img src='../../Style/images/black.png' />";
            }
            else
            {
                strimg = "<img src='../../Style/images/yellow.png' />";
            }
            return strimg;
        }
    }
}
