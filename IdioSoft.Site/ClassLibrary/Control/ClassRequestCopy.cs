using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.ClassLibrary.Control
{
    public static class ClassRequestCopy
    {
        #region "RequestID编码yyyyMM0001"
        public static string funString_RequestCode()
        {
            IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
            string strSQL;

            strSQL = "SELECT   max(case when ISNUMERIC(RequestID)=0 then 0 else CONVERT(decimal,RequestID) end)  as MaxID FROM webInfo_ServiceRequest_Info where  substring(requestid,1,1)=2";//year(createdate)=" + DateTime.Now.Year.ToString() +" and

            string strID = "";
            try
            {
                strID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                if (strID == "")
                {
                    strID = DateTime.Now.ToString("yyyyMM0001");
                }
                else
                {
                    string sYear = DateTime.Now.Year.ToString();
                    string strTmp = strID.Substring(0, 4);
                    if (strTmp != sYear)
                    {
                        strID = DateTime.Now.ToString("yyyyMM0001");
                    }
                    else
                    {
                        strID = (Int64.Parse(strID) + 1).ToString();
                    }
                }
            }
            catch
            {
                strID = DateTime.Now.ToString("yyyyMM0001");
            }
            return strID;
        }
        #endregion
        #region "Copy公司记录"
        public static string funString_Insert_CopyRequest(string strID)
        {
            IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
            string strSQL = "";
            string strCreateDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int intCreateUser = ((IdioSoft.Site.ClassLibrary.UserInfo)(HttpContext.Current.Session["UserInfo"])).UserID;
            strSQL = @"INSERT INTO webInfo_ServiceRequest_Info
                      (NotificationNo, MLFBNo, SerialNo, ServiceType, ProductName, ProductDesc, Area, ServiceProvider, CaseProperty, Sirot, TroubleDesc, 
                      AppCompanyName, AppSubOffice, AppCustomerID, AppProvince, AppCity, AppCustomerType, AppContactName, AppTel, AppMobile, AppFax, 
                      AppAddress, AppPostCode, AppEmail, AppCountry, AppBranch, EnduserCompanyName, EnduserSubOffice, EnduserCustomerID, EnduserProvince, 
                      EnduserCity, EnduserCustomerType, EnduserContactName, EnduserTel, EnduserMobile, EnduserFax, EnduserAddress, EnduserPostCode, 
                      EnduserCountry, EnduserBranch, EnduserEmail, EnduserMainOffice, DutyID, TransferUser, isRepair, isSubmit, 
                      isDel,CaseTime, CreateDate, CreateUser,RequestID,
                      AppVIPID, EnduserVIPID, AppAccountID, AppContactID, EnduserAccountID, EnduserContactID,Warranty,MachineManufacturer,TypeOfMachine,MachineSerialNo,ControllerType,DriverType,SoftwareVersion)
SELECT     NotificationNo, MLFBNo, SerialNo, ServiceType, ProductName, ProductDesc, Area, ServiceProvider, CaseProperty, Sirot, TroubleDesc, 
                      AppCompanyName, AppSubOffice, AppCustomerID, AppProvince, AppCity, AppCustomerType, AppContactName, AppTel, AppMobile, AppFax, 
                      AppAddress, AppPostCode, AppEmail, AppCountry, AppBranch, EnduserCompanyName, EnduserSubOffice, EnduserCustomerID, EnduserProvince, 
                      EnduserCity, EnduserCustomerType, EnduserContactName, EnduserTel, EnduserMobile, EnduserFax, EnduserAddress, EnduserPostCode,
                      EnduserCountry, EnduserBranch, EnduserEmail, EnduserMainOffice, DutyID, TransferUser, isRepair, isSubmit,";
            strSQL = strSQL + "0,'" + strCreateDate + "','" + strCreateDate + "', " + intCreateUser + ",'" + funString_RequestCode() + "',";
            string strTmp = @"AppVIPID, EnduserVIPID, AppAccountID, AppContactID, EnduserAccountID, EnduserContactID, Warranty,MachineManufacturer,TypeOfMachine,MachineSerialNo,ControllerType,DriverType,SoftwareVersion  
FROM         webInfo_ServiceRequest_Info AS webInfo_ServiceRequest_Info_1";
            strSQL = strSQL + strTmp + " WHERE (ID = '" + strID + "')";
            string strError = "";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            string strNewID = "";
            if (strError.Trim() == "")
            {
                strSQL = "select ID from webInfo_ServiceRequest_Info where CreateDate = '" + strCreateDate + "' and CreateUser = " + intCreateUser + "";

                strNewID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);

                strSQL = "update webInfo_ServiceRequest_Info set RequestID = '" + funString_RequestCode() + "' where ID = '" + strNewID + "'";
                string strErr = "";
                strErr = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            return strNewID;
        }
        #endregion
        #region "Copy物料记录"
        private static void subDBInsert_CopyMaterial(string strOlduRequestID, string strNewuRequestID, string strCreateDate, int intCreateUser)
        {
            IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
            string strSQL = "";

            string strSQLs = "select ID from webInfo_Servicerequest_Material_Info where uRequestID = '" + strOlduRequestID + "'";
            DataSet das = new DataSet();
            das = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQLs);
            for (int i = 0; i < das.Tables[0].Rows.Count; i++)
            {
                strSQL = @"INSERT INTO webInfo_Servicerequest_Material_Info
                      (uRequestID, MLFB, SerialNo, Quantity,CreateUser, CreateDate, SPASProductName, SPASProductGroup, SPASPIPAGroup, SSCLProductName, 
                      SSCLProductGroup, SSCLPIPAGroup, SMDT_ProductDesc, SMDT_ProductName, SMDT_ActualFault, SMDT_subActualFault)
                SELECT     uRequestID, MLFB, SerialNo, Quantity,";
                strSQL = strSQL + "" + intCreateUser + ",'" + strCreateDate + "',";
                string strTmp = @"SPASProductName, SPASProductGroup, SPASPIPAGroup, SSCLProductName, 
                      SSCLProductGroup, SSCLPIPAGroup, SMDT_ProductDesc, SMDT_ProductName, SMDT_ActualFault, SMDT_subActualFault
                FROM         webInfo_Servicerequest_Material_Info AS webInfo_Servicerequest_Material_Info_1";
                strSQL = strSQL + strTmp + " WHERE (ID = '" + das.Tables[0].Rows[i]["ID"].ToString() + "')";

                string strError = "";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                if (strError.Trim() == "")
                {
                    strSQL = "select ID from webInfo_Servicerequest_Material_Info where CreateDate = '" + strCreateDate + "' and CreateUser = " + intCreateUser + "";
                    DataSet ds = new DataSet();
                    ArrayList arylist = new ArrayList();
                    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        string str = "update webInfo_Servicerequest_Material_Info set uRequestID = '" + strNewuRequestID + "' where ID = '" + ds.Tables[0].Rows[j]["ID"].ToString() + "'";
                        string strErr = "";
                        strErr = objDbSQLAccess.funString_SQLExecuteNonQuery(str);
                    }
                }
            }
        }
        #endregion

        #region "Copy公司记录"
        public static string funString_Insert_SalesCopyRequest(string strID)
        {
            IdioSoft.Business.Method.SQLDbHelper objClassDbAccess = new SQLDbHelper();
            string strSQL = "";
            string strCreateDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strNewID = Guid.NewGuid().ToString();
            int intCreateUser = ((IdioSoft.Site.ClassLibrary.UserInfo)(HttpContext.Current.Session["UserInfo"])).UserID;
            strSQL = @"insert into webInfo_SfaeSpare_request_Info (ID,isurgent, CaseTime, CustomerType, ServerType, ServerProvider, BU, Area, DeliverDate, AppCompanyName, AppSubOffice, AppCustomerID, 
                      AppProvince, AppCity, AppCustomerType, AppContactName, AppTel, AppMobile, AppFax, AppAddress, AppPostCode, AppEmail, PostAddress, 
                      RegAddress, ConsignorAddress, TaxCode, AccountCode, BankName, DiscType, dutyID, isDel, CreateDate, CreateUser, FinanceTel, isSpareSalesDo, 
                      s39NO, issubmit, Source, isLock, ModifyUser, ModifyDate, salesid, isCancel, serviceorderno, SalesType, Comments, smdt_SalesNo, VIPID, 
                      Callbackdate, transferuser, SMDTPaintingJudge, ProductDesc)   (";
            strSQL = strSQL + "SELECT '" + strNewID + "', isurgent, CaseTime, CustomerType, ServerType, ServerProvider, BU, Area, DeliverDate, AppCompanyName, AppSubOffice, AppCustomerID, ";
            strSQL = strSQL + "AppProvince, AppCity, AppCustomerType, AppContactName, AppTel, AppMobile, AppFax, AppAddress, AppPostCode, AppEmail, PostAddress,";
            strSQL = strSQL + " RegAddress, ConsignorAddress, TaxCode, AccountCode, BankName, DiscType, dutyID, isDel, '" + strCreateDate + "', " + intCreateUser + ", FinanceTel, isSpareSalesDo,";
            strSQL = strSQL + @"s39NO, issubmit, Source, isLock, ModifyUser, ModifyDate, '" + subDB_GetsalesID() + "', isCancel, serviceorderno, SalesType, Comments, smdt_SalesNo, VIPID,";
            strSQL = strSQL + " Callbackdate, transferuser, SMDTPaintingJudge, ProductDesc FROM webInfo_SfaeSpare_request_Info where ID='" + strID + "')";
            string strError = "";
            strError = objClassDbAccess.funString_SQLExecuteNonQuery(strSQL);
            return strNewID;
        }
        #endregion
        #region 获得最大的salesID
        private static string subDB_GetsalesID()
        {
            IdioSoft.Business.Method.SQLDbHelper objClassDbAccess = new SQLDbHelper();
            string strSelectSql = "select MAX(salesID) from webInfo_SfaeSpare_request_Info WHERE salesID like '%SPS" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "%'";
            string strI = objClassDbAccess.funString_SQLExecuteScalar(strSelectSql);
            if (strI != "")
            {
                Int32 intMax = Int32.Parse(strI.Substring(3)) + 1;
                strI = "SPS" + intMax.ToString();
            }
            if (strI == "")
            {
                strI = "SPS" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "0001";
            }

            return strI;
        }
        #endregion
    }
}