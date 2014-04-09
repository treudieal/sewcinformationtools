using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for SEWCRequestOperation
    /// </summary>
    public class SEWCRequestOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");
            switch (OperationType.ToString().Trim().ToLower()) 
            { 
                case "addnew":
                case "save":
                    string uRequestID = context.funString_RequestFormValue("uRequestID");
                    string strSQL = "select count(*) from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";
                    int intCount = 0;
                    intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
                    if (intCount > 0)
                    {
                        subDB_Modify(context);
                    }
                    else
                    {
                        subDB_AddNew(context);
                    }
                    break;
                case "delete":
                    subDB_Delete(context);
                    break;
                case "cancel":
                    subDB_Cancel(context);
                    break;
                case "copy":
                    subDB_Copy(context);
                    break;
                case "deletefile":
                    subDB_DeleteFile(context);
                    break;
                case "clearendUser":
                    subDB_ClearEndUser(context);
                    break;
            }
        }

        public void subDB_AddNew(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string NotificationNo = context.funString_RequestFormValue("NotificationNo").funString_SQLToString();
            //string MLFBNo = context.funString_RequestFormValue("MLFBNo").funString_SQLToString();
            //string SerialNo = context.funString_RequestFormValue("SerialNo").funString_SQLToString();
            string ServiceType = context.funString_RequestFormValue("ServiceType").funString_SQLToString();
            string ProductName = context.funString_RequestFormValue("ProductName").funString_SQLToString();
            string ProductDesc = context.funString_RequestFormValue("ProductDesc").funString_SQLToString();
            string Area = context.funString_RequestFormValue("Area").funString_SQLToString();
            string ServiceProvider = context.funString_RequestFormValue("ServiceProvider").funString_SQLToString();
            string CaseProperty = context.funString_RequestFormValue("CaseProperty").funString_SQLToString();
            string Sirot = context.funString_RequestFormValue("Sirot").funString_SQLToString();
            string TroubleDesc = context.funString_RequestFormValue("TroubleDesc").funString_SQLToString();

            string AppCompanyName = context.funString_RequestFormValue("AppCompanyName").funString_SQLToString();
            string AppSubOffice = context.funString_RequestFormValue("AppSubOffice").funString_SQLToString();
            string AppCustomerID = context.funString_RequestFormValue("AppCustomerID").funString_SQLToString();
            string AppProvince = context.funString_RequestFormValue("AppProvince").funString_SQLToString();
            string AppCity = context.funString_RequestFormValue("AppCity").funString_SQLToString();
            string AppCustomerType = context.funString_RequestFormValue("AppCustomerType").funString_SQLToString();
            string AppContactName = context.funString_RequestFormValue("AppContactName").funString_SQLToString();
            string AppTel = context.funString_RequestFormValue("AppTel").funString_SQLToString();
            string AppMobile = context.funString_RequestFormValue("AppMobile").funString_SQLToString();
            string AppFax = context.funString_RequestFormValue("AppFax").funString_SQLToString();
            string AppAddress = context.funString_RequestFormValue("AppAddress").funString_SQLToString();
            string AppPostCode = context.funString_RequestFormValue("AppPostCode").funString_SQLToString();
            string AppEmail = context.funString_RequestFormValue("AppEmail").funString_SQLToString();

            string EnduserCompanyName = context.funString_RequestFormValue("EnduserCompanyName").funString_SQLToString();
            string EnduserSubOffice = context.funString_RequestFormValue("EnduserSubOffice").funString_SQLToString();
            string EnduserCustomerID = context.funString_RequestFormValue("EnduserCustomerID").funString_SQLToString();
            string EnduserProvince = context.funString_RequestFormValue("EnduserProvince").funString_SQLToString();
            string EnduserCity = context.funString_RequestFormValue("EnduserCity").funString_SQLToString();
            string EnduserCustomerType = context.funString_RequestFormValue("EnduserCustomerType").funString_SQLToString();
            string EnduserContactName = context.funString_RequestFormValue("EnduserContactName").funString_SQLToString();
            string EnduserTel = context.funString_RequestFormValue("EnduserTel").funString_SQLToString();
            string EnduserMobile = context.funString_RequestFormValue("EnduserMobile").funString_SQLToString();
            string EnduserFax = context.funString_RequestFormValue("EnduserFax").funString_SQLToString();
            string EnduserAddress = context.funString_RequestFormValue("EnduserAddress").funString_SQLToString();
            string EnduserPostCode = context.funString_RequestFormValue("EnduserPostCode").funString_SQLToString();
            string EnduserEmail = context.funString_RequestFormValue("EnduserEmail").funString_SQLToString();

            string CaseTime = context.funString_RequestFormValue("CaseTime").funString_SQLToString();
            if (CaseTime.ToString().Trim() != "")
            {
                CaseTime = "'" + CaseTime + "'";
            }
            else
            {
                CaseTime = "NULL";
            }
            string Text = context.funString_RequestFormValue("Text").funString_SQLToString();
            string CallagentComments = context.funString_RequestFormValue("CallagentComments").funString_SQLToString();
            int DutyID = context.funString_RequestFormValue("DutyID").funInt_StringToInt(0);
            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            //int TransferUser = context.funString_RequestFormValue("TransferUser").funInt_StringToInt(0);

            string AppCountry = context.funString_RequestFormValue("AppCountry").funString_SQLToString();
            string AppBranch = context.funString_RequestFormValue("AppBranch").funString_SQLToString();
            string EnduserCountry = context.funString_RequestFormValue("EnduserCountry").funString_SQLToString();
            string EnduserBranch = context.funString_RequestFormValue("EnduserBranch").funString_SQLToString();
            string Status = context.funString_RequestFormValue("Status").funString_SQLToString();
            string Warranty = context.funString_RequestFormValue("Warranty").funString_SQLToString();

            if (Warranty == "")
            {
                context.Response.Write("2");//Warranty不能为空
                context.Response.End();
            }

            string AppVIPID = context.funString_RequestFormValue("AppVIPID").funString_SQLToString();
            string AppAccountID = context.funString_RequestFormValue("AppAccountID").funString_SQLToString();
            if (AppAccountID.ToString().Trim() != "")
            {
                AppAccountID = "'" + AppAccountID + "'";
            }
            else
            {
                AppAccountID = "NULL";
            }
            string AppContactID = context.funString_RequestFormValue("AppContactID").funString_SQLToString();
            if (AppContactID.ToString().Trim() != "")
            {
                AppContactID = "'" + AppContactID + "'";
            }
            else
            {
                AppContactID = "NULL";
            }
            string EnduserVIPID = context.funString_RequestFormValue("EnduserVIPID").funString_SQLToString();
            string EnduserAccountID = context.funString_RequestFormValue("EnduserAccountID").funString_SQLToString();
            if (EnduserAccountID.ToString().Trim() != "")
            {
                EnduserAccountID = "'" + EnduserAccountID + "'";
            }
            else
            {
                EnduserAccountID = "NULL";
            }
            string EnduserContactID = context.funString_RequestFormValue("EnduserContactID").funString_SQLToString();
            if (EnduserContactID.ToString().Trim() != "")
            {
                EnduserContactID = "'" + EnduserContactID + "'";
            }
            else
            {
                EnduserContactID = "NULL";
            }
            string ExchExpendProjectName = context.funString_RequestFormValue("ExchExpendProjectName").funString_SQLToString();
            string ExchExpendProjectNO = context.funString_RequestFormValue("ExchExpendProjectNO").funString_SQLToString();
            int ExchExpendSelectCompany = context.funString_RequestFormValue("ExchExpendSelectCompany").funInt_StringToInt(0);
            string ExchExpendFSPostAddress = context.funString_RequestFormValue("ExchExpendFSPostAddress").funString_SQLToString();
            string OrderType = context.funString_RequestFormValue("OrderType").funString_SQLToString();
            string RSVNO = context.funString_RequestFormValue("RSVNO").funString_SQLToString();
            string MachineManufacturer = context.funString_RequestFormValue("MachineManufacturer").funString_SQLToString();
            string TypeOfMachine = context.funString_RequestFormValue("TypeOfMachine").funString_SQLToString();
            string MachineSerialNo = context.funString_RequestFormValue("MachineSerialNo").funString_SQLToString();
            string ControllerType = context.funString_RequestFormValue("ControllerType").funString_SQLToString();
            string DriverType = context.funString_RequestFormValue("DriverType").funString_SQLToString();
            string SoftwareVersion = context.funString_RequestFormValue("SoftwareVersion").funString_SQLToString();
            int AppIsGroupDamex = context.funString_RequestFormValue("AppIsGroupDamex").funInt_StringToInt(0);
            int EnduserIsGroupDamex = context.funString_RequestFormValue("EnduserIsGroupDamex").funInt_StringToInt(0);
            string ProcessingTechnology = context.funString_RequestFormValue("ProcessingTechnology").funString_SQLToString();
            int IfDown = context.funString_RequestFormValue("IfDown").funInt_StringToInt(0);
            string RSCNo = context.funString_RequestFormValue("RSCNo").funString_SQLToString();
            string LocalRSCNo = context.funString_RequestFormValue("LocalRSCNo").funString_SQLToString();
            string OriCase = context.funString_RequestFormValue("OriCase").funString_SQLToString();

            int isRepeat = context.funString_RequestFormValue("isRepeat").funInt_BoolToString();
            int isRepair = context.funString_RequestFormValue("isRepair").funInt_BoolToString();

            string SFAEVIPID = context.funString_RequestFormValue("SFAEVIPID").funString_SQLToString();
            string CaseVIP = context.funString_RequestFormValue("CaseVIP").funString_SQLToString();
            string VIPSalesEmail = context.funString_RequestFormValue("VIPSalesEmail").funString_SQLToString();

            string DeliveryType = context.funString_RequestFormValue("DeliveryType").funString_SQLToString();
            string ReceiveCompany = context.funString_RequestFormValue("ReceiveCompany").funString_SQLToString();
            string Receiver = context.funString_RequestFormValue("Receiver").funString_SQLToString();
            string ReceiverTel = context.funString_RequestFormValue("ReceiverTel").funString_SQLToString();
            string ReceiverAddress = context.funString_RequestFormValue("ReceiverAddress").funString_SQLToString();

            string strRequestItems = context.funString_RequestFormValue("Items");
            string[] strAll = strRequestItems.Split('[');

            for (int i = 1; i < strAll.Length; i++)
            {
                if (strAll[i].ToString().Trim() != "")
                {
                    string RequestID = funString_RequestCode();
                    string NewID = Guid.NewGuid().ToString();

                    System.Text.RegularExpressions.Regex rng = new System.Text.RegularExpressions.Regex("\\$\\$\\$");
                    string[] strItems = rng.Split(strAll[i].ToString());

                    string MLFBNo = strItems[0].ToString().funString_SQLToString();
                    string SerialNo = strItems[1].ToString().funString_SQLToString();
                    string MaterialProductName = strItems[2].ToString().funString_SQLToString();
                    string MaterialProducDesc = strItems[3].ToString().funString_SQLToString();
                    string MaterialFault = strItems[4].ToString().funString_SQLToString();
                    int Quantity = strItems[5].ToString().funString_SQLToString().funInt_StringToInt(0);
                    int TransferUser = strItems[6].ToString().Replace("]", "").funInt_StringToInt(0);

                    strSQL = @"INSERT INTO webInfo_Servicerequest_Material_Info   (uRequestID, MLFB, SerialNo, Quantity,MaterialProductName,MaterialProductDesc,MaterialFault) VALUES  (";
                    strSQL += "'" + NewID + "','" + MLFBNo + "','" + SerialNo + "'," + Quantity + ",N'" + MaterialProductName + "',N'" + MaterialProducDesc + "',N'" + MaterialFault + "')";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                    if (NotificationNo == "")
                    {
                        NotificationNo = RequestID;
                    }
                    strSQL = @"insert into webInfo_ServiceRequest_Info(ID,NotificationNo,MLFBNo,SerialNo,ServiceType,ProductName,ProductDesc,Area,ServiceProvider,
                        CaseProperty,Sirot,TroubleDesc,AppCompanyName,AppSubOffice,AppCustomerID,AppProvince,
                        AppCity,AppCustomerType,AppContactName,AppTel,AppMobile,AppFax,AppAddress,
                        AppPostCode,AppEmail,EnduserCompanyName,EnduserSubOffice,EnduserCustomerID,
                        EnduserProvince,EnduserCity,EnduserCustomerType,EnduserContactName,EnduserTel,EnduserMobile,
                        EnduserFax,EnduserAddress,EnduserPostCode,EnduserEmail,CaseTime,Text,CallagentComments,
                        DutyID,isSubmit,TransferUser,AppCountry,AppBranch,EnduserCountry,EnduserBranch,
                        Status,SFAEIHR_Warranty,Warranty,AppVIPID,AppAccountID,AppContactID,EnduserVIPID,
                        EnduserAccountID,EnduserContactID,ExchExpendProjectName,ExchExpendProjectNO,ExchExpendSelectCompany,
                        ExchExpendFSPostAddress,OrderType,RSVNO,MachineManufacturer,TypeOfMachine,MachineSerialNo,
                        ControllerType,DriverType,SoftwareVersion,AppIsGroupDamex,EnduserIsGroupDamex,ProcessingTechnology,
                        IfDown,RSCNo,LocalRSCNo,OriCase,isRepeat,isRepair,SFAEVIPID,CaseVIP,VIPSalesEmail,
                        DeliveryType,ReceiveCompany,Receiver,ReceiverTel,ReceiverAddress,
                        RequestID,CreateDate,CreateUser) values(";
                    strSQL += "'" + NewID + "','" + NotificationNo + "','" + MLFBNo + "','" + SerialNo + "','" + ServiceType + "',N'" + MaterialProductName + "',N'" + MaterialProducDesc + "',N'" + Area + "',N'" + ServiceProvider;
                    strSQL += "',N'" + CaseProperty + "',N'" + Sirot + "',N'" + TroubleDesc + "',N'" + AppCompanyName + "',N'" + AppSubOffice + "','" + AppCustomerID + "',N'" + AppProvince;
                    strSQL += "',N'" + AppCity + "',N'" + AppCustomerType + "',N'" + AppContactName + "',N'" + AppTel + "',N'" + AppMobile + "',N'" + AppFax + "',N'" + AppAddress;
                    strSQL += "',N'" + AppPostCode + "',N'" + AppEmail + "',N'" + EnduserCompanyName + "',N'" + EnduserSubOffice + "','" + EnduserCustomerID;
                    strSQL += "',N'" + EnduserProvince + "',N'" + EnduserCity + "',N'" + EnduserCustomerType + "',N'" + EnduserContactName + "',N'" + EnduserTel + "',N'" + EnduserMobile;
                    strSQL += "',N'" + EnduserFax + "',N'" + EnduserAddress + "',N'" + EnduserPostCode + "',N'" + EnduserEmail + "'," + CaseTime + ",N'" + Text + "',N'" + CallagentComments;
                    strSQL += "'," + DutyID + "," + isSubmit + "," + TransferUser + ",N'" + AppCountry + "',N'" + AppBranch + "',N'" + EnduserCountry + "',N'" + EnduserBranch;
                    strSQL += "',N'" + Status + "',N'" + Warranty + "',N'" + Warranty + "','" + AppVIPID + "'," + AppAccountID + "," + AppContactID + ",'" + EnduserVIPID;
                    strSQL += "'," + EnduserAccountID + "," + EnduserContactID + ",N'" + ExchExpendProjectName + "',N'" + ExchExpendProjectNO + "'," + ExchExpendSelectCompany;
                    strSQL += ",N'" + ExchExpendFSPostAddress + "',N'" + OrderType + "',N'" + RSVNO + "',N'" + MachineManufacturer + "',N'" + TypeOfMachine + "',N'" + MachineSerialNo;
                    strSQL += "',N'" + ControllerType + "',N'" + DriverType + "',N'" + SoftwareVersion + "'," + AppIsGroupDamex + "," + EnduserIsGroupDamex + ",N'" + ProcessingTechnology;
                    strSQL += "'," + IfDown + ",N'" + RSCNo + "',N'" + LocalRSCNo + "',N'" + OriCase + "'," + isRepeat + "," + isRepair + ",N'" + SFAEVIPID + "',N'" + CaseVIP + "',N'" + VIPSalesEmail;
                    strSQL += "',N'" + DeliveryType + "',N'" + ReceiveCompany + "',N'" + Receiver + "',N'" + ReceiverTel + "',N'" + ReceiverAddress;
                    strSQL += "','" + RequestID + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + objUserInfo.UserID + ")";

                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }

            if (strError == "")
            {
                //subDB_SaveItem(context, NewID);
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        public void subDB_Modify(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string uRequestID = context.funString_RequestFormValue("uRequestID");

            string NotificationNo = context.funString_RequestFormValue("NotificationNo").funString_SQLToString();
            //string MLFBNo = context.funString_RequestFormValue("MLFBNo").funString_SQLToString();
            //string SerialNo = context.funString_RequestFormValue("SerialNo").funString_SQLToString();
            string ServiceType = context.funString_RequestFormValue("ServiceType").funString_SQLToString();
            string ProductName = context.funString_RequestFormValue("ProductName").funString_SQLToString();
            string ProductDesc = context.funString_RequestFormValue("ProductDesc").funString_SQLToString();
            string Area = context.funString_RequestFormValue("Area").funString_SQLToString();
            string ServiceProvider = context.funString_RequestFormValue("ServiceProvider").funString_SQLToString();
            string CaseProperty = context.funString_RequestFormValue("CaseProperty").funString_SQLToString();
            string Sirot = context.funString_RequestFormValue("Sirot").funString_SQLToString();
            string TroubleDesc = context.funString_RequestFormValue("TroubleDesc").funString_SQLToString();

            string AppCompanyName = context.funString_RequestFormValue("AppCompanyName").funString_SQLToString();
            string AppSubOffice = context.funString_RequestFormValue("AppSubOffice").funString_SQLToString();
            string AppCustomerID = context.funString_RequestFormValue("AppCustomerID").funString_SQLToString();
            string AppProvince = context.funString_RequestFormValue("AppProvince").funString_SQLToString();
            string AppCity = context.funString_RequestFormValue("AppCity").funString_SQLToString();
            string AppCustomerType = context.funString_RequestFormValue("AppCustomerType").funString_SQLToString();
            string AppContactName = context.funString_RequestFormValue("AppContactName").funString_SQLToString();
            string AppTel = context.funString_RequestFormValue("AppTel").funString_SQLToString();
            string AppMobile = context.funString_RequestFormValue("AppMobile").funString_SQLToString();
            string AppFax = context.funString_RequestFormValue("AppFax").funString_SQLToString();
            string AppAddress = context.funString_RequestFormValue("AppAddress").funString_SQLToString();
            string AppPostCode = context.funString_RequestFormValue("AppPostCode").funString_SQLToString();
            string AppEmail = context.funString_RequestFormValue("AppEmail").funString_SQLToString();

            string EnduserCompanyName = context.funString_RequestFormValue("EnduserCompanyName").funString_SQLToString();
            string EnduserSubOffice = context.funString_RequestFormValue("EnduserSubOffice").funString_SQLToString();
            string EnduserCustomerID = context.funString_RequestFormValue("EnduserCustomerID").funString_SQLToString();
            string EnduserProvince = context.funString_RequestFormValue("EnduserProvince").funString_SQLToString();
            string EnduserCity = context.funString_RequestFormValue("EnduserCity").funString_SQLToString();
            string EnduserCustomerType = context.funString_RequestFormValue("EnduserCustomerType").funString_SQLToString();
            string EnduserContactName = context.funString_RequestFormValue("EnduserContactName").funString_SQLToString();
            string EnduserTel = context.funString_RequestFormValue("EnduserTel").funString_SQLToString();
            string EnduserMobile = context.funString_RequestFormValue("EnduserMobile").funString_SQLToString();
            string EnduserFax = context.funString_RequestFormValue("EnduserFax").funString_SQLToString();
            string EnduserAddress = context.funString_RequestFormValue("EnduserAddress").funString_SQLToString();
            string EnduserPostCode = context.funString_RequestFormValue("EnduserPostCode").funString_SQLToString();
            string EnduserEmail = context.funString_RequestFormValue("EnduserEmail").funString_SQLToString();

            string CaseTime = context.funString_RequestFormValue("CaseTime").funString_SQLToString();
            if (CaseTime.ToString().Trim() != "")
            {
                CaseTime = "'" + CaseTime + "'";
            }
            else
            {
                CaseTime = "NULL";
            }
            string Text = context.funString_RequestFormValue("Text").funString_SQLToString();
            string CallagentComments = context.funString_RequestFormValue("CallagentComments").funString_SQLToString();
            int DutyID = context.funString_RequestFormValue("DutyID").funInt_StringToInt(0);
            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            //int TransferUser = context.funString_RequestFormValue("TransferUser").funInt_StringToInt(0);

            string AppCountry = context.funString_RequestFormValue("AppCountry").funString_SQLToString();
            string AppBranch = context.funString_RequestFormValue("AppBranch").funString_SQLToString();
            string EnduserCountry = context.funString_RequestFormValue("EnduserCountry").funString_SQLToString();
            string EnduserBranch = context.funString_RequestFormValue("EnduserBranch").funString_SQLToString();
            string Status = context.funString_RequestFormValue("Status").funString_SQLToString();
            string Warranty = context.funString_RequestFormValue("Warranty").funString_SQLToString();

            if (Warranty == "")
            {
                context.Response.Write("2");//Warranty不能为空
                context.Response.End();
            }

            string AppVIPID = context.funString_RequestFormValue("AppVIPID").funString_SQLToString();
            string AppAccountID = context.funString_RequestFormValue("AppAccountID").funString_SQLToString();
            if (AppAccountID.ToString().Trim() != "")
            {
                AppAccountID = "'" + AppAccountID + "'";
            }
            else
            {
                AppAccountID = "NULL";
            }
            string AppContactID = context.funString_RequestFormValue("AppContactID").funString_SQLToString();
            if (AppContactID.ToString().Trim() != "")
            {
                AppContactID = "'" + AppContactID + "'";
            }
            else
            {
                AppContactID = "NULL";
            }
            string EnduserVIPID = context.funString_RequestFormValue("EnduserVIPID").funString_SQLToString();
            string EnduserAccountID = context.funString_RequestFormValue("EnduserAccountID").funString_SQLToString();
            if (EnduserAccountID.ToString().Trim() != "")
            {
                EnduserAccountID = "'" + EnduserAccountID + "'";
            }
            else
            {
                EnduserAccountID = "NULL";
            }
            string EnduserContactID = context.funString_RequestFormValue("EnduserContactID").funString_SQLToString();
            if (EnduserContactID.ToString().Trim() != "")
            {
                EnduserContactID = "'" + EnduserContactID + "'";
            }
            else
            {
                EnduserContactID = "NULL";
            }
            string ExchExpendProjectName = context.funString_RequestFormValue("ExchExpendProjectName").funString_SQLToString();
            string ExchExpendProjectNO = context.funString_RequestFormValue("ExchExpendProjectNO").funString_SQLToString();
            int ExchExpendSelectCompany = context.funString_RequestFormValue("ExchExpendSelectCompany").funInt_StringToInt(0);
            string ExchExpendFSPostAddress = context.funString_RequestFormValue("ExchExpendFSPostAddress").funString_SQLToString();
            string OrderType = context.funString_RequestFormValue("OrderType").funString_SQLToString();
            string RSVNO = context.funString_RequestFormValue("RSVNO").funString_SQLToString();
            string MachineManufacturer = context.funString_RequestFormValue("MachineManufacturer").funString_SQLToString();
            string TypeOfMachine = context.funString_RequestFormValue("TypeOfMachine").funString_SQLToString();
            string MachineSerialNo = context.funString_RequestFormValue("MachineSerialNo").funString_SQLToString();
            string ControllerType = context.funString_RequestFormValue("ControllerType").funString_SQLToString();
            string DriverType = context.funString_RequestFormValue("DriverType").funString_SQLToString();
            string SoftwareVersion = context.funString_RequestFormValue("SoftwareVersion").funString_SQLToString();
            int AppIsGroupDamex = context.funString_RequestFormValue("AppIsGroupDamex").funInt_StringToInt(0);
            int EnduserIsGroupDamex = context.funString_RequestFormValue("EnduserIsGroupDamex").funInt_StringToInt(0);
            string ProcessingTechnology = context.funString_RequestFormValue("ProcessingTechnology").funString_SQLToString();
            int IfDown = context.funString_RequestFormValue("IfDown").funInt_StringToInt(0);
            string RSCNo = context.funString_RequestFormValue("RSCNo").funString_SQLToString();
            string LocalRSCNo = context.funString_RequestFormValue("LocalRSCNo").funString_SQLToString();
            string OriCase = context.funString_RequestFormValue("OriCase").funString_SQLToString();
            int isRepeat = context.funString_RequestFormValue("isRepeat").funInt_BoolToString();
            int isRepair = context.funString_RequestFormValue("isRepair").funInt_BoolToString();
            string SFAEVIPID = context.funString_RequestFormValue("SFAEVIPID").funString_SQLToString();
            string CaseVIP = context.funString_RequestFormValue("CaseVIP").funString_SQLToString();
            string VIPSalesEmail = context.funString_RequestFormValue("VIPSalesEmail").funString_SQLToString();

            string DeliveryType = context.funString_RequestFormValue("DeliveryType").funString_SQLToString();
            string ReceiveCompany = context.funString_RequestFormValue("ReceiveCompany").funString_SQLToString();
            string Receiver = context.funString_RequestFormValue("Receiver").funString_SQLToString();
            string ReceiverTel = context.funString_RequestFormValue("ReceiverTel").funString_SQLToString();
            string ReceiverAddress = context.funString_RequestFormValue("ReceiverAddress").funString_SQLToString();

            string strRequestItems = context.funString_RequestFormValue("Items");
            string[] strAll = strRequestItems.Split('[');

            strSQL = "delete webInfo_Servicerequest_Material_Info where uRequestID = '" + uRequestID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            for (int i = 1; i < strAll.Length; i++)
            {
                if (strAll[i].ToString().Trim() != "")
                {
                    System.Text.RegularExpressions.Regex rng = new System.Text.RegularExpressions.Regex("\\$\\$\\$");
                    string[] strItems = rng.Split(strAll[i].ToString());

                    string MLFBNo = strItems[0].ToString().funString_SQLToString();
                    string SerialNo = strItems[1].ToString().funString_SQLToString();
                    string MaterialProductName = strItems[2].ToString().funString_SQLToString();
                    string MaterialProducDesc = strItems[3].ToString().funString_SQLToString();
                    string MaterialFault = strItems[4].ToString().funString_SQLToString();
                    int Quantity = strItems[5].ToString().funString_SQLToString().funInt_StringToInt(0);
                    int TransferUser = strItems[6].ToString().Replace("]", "").funInt_StringToInt(0);

                    strSQL = @"INSERT INTO webInfo_Servicerequest_Material_Info   (uRequestID, MLFB, SerialNo, Quantity,MaterialProductName,MaterialProductDesc,MaterialFault) VALUES  (";
                    strSQL += "'" + uRequestID + "','" + MLFBNo + "','" + SerialNo + "'," + Quantity + ",N'" + MaterialProductName + "',N'" + MaterialProducDesc + "',N'" + MaterialFault + "')";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                    strSQL = @"update webInfo_ServiceRequest_Info set NotificationNo='" + NotificationNo + "',MLFBNo='" + MLFBNo + "',SerialNo='" + SerialNo;
                    strSQL = strSQL + "',ServiceType='" + ServiceType + "',ProductName=N'" + MaterialProductName;
                    strSQL = strSQL + "',ProductDesc=N'" + MaterialProducDesc + "',isRepair=" + isRepair + ",Area=N'" + Area;
                    strSQL = strSQL + "',ServiceProvider=N'" + ServiceProvider + "',CaseProperty=N'" + CaseProperty;
                    strSQL = strSQL + "',Sirot=N'" + Sirot + "',TroubleDesc=N'" + TroubleDesc + "',AppCompanyName=N'" + AppCompanyName;
                    strSQL = strSQL + "',AppSubOffice=N'" + AppSubOffice + "',AppCustomerID='" + AppCustomerID + "',AppProvince=N'" + AppProvince;
                    strSQL = strSQL + "',AppCity=N'" + AppCity + "',AppCustomerType=N'" + AppCustomerType;

                    strSQL = strSQL + "',AppContactName=N'" + AppContactName + "',AppTel=N'" + AppTel + "',AppMobile=N'" + AppMobile;
                    strSQL = strSQL + "',AppFax=N'" + AppFax + "',AppAddress=N'" + AppAddress + "',AppPostCode=N'" + AppPostCode;
                    strSQL = strSQL + "',AppEmail=N'" + AppEmail + "',EnduserCompanyName=N'" + EnduserCompanyName + "',EnduserSubOffice=N'" + EnduserSubOffice;

                    strSQL = strSQL + "',EnduserCustomerID='" + EnduserCustomerID + "',EnduserProvince=N'" + EnduserProvince;
                    strSQL = strSQL + "',EnduserCity=N'" + EnduserCity + "',EnduserCustomerType=N'" + EnduserCustomerType;
                    strSQL = strSQL + "',EnduserContactName=N'" + EnduserContactName + "',EnduserTel=N'" + EnduserTel + "',EnduserMobile=N'" + EnduserMobile;

                    strSQL = strSQL + "',EnduserFax=N'" + EnduserFax + "',EnduserAddress=N'" + EnduserAddress + "',EnduserPostCode=N'" + EnduserPostCode + "',EnduserEmail=N'" + EnduserEmail;

                    strSQL = strSQL + "',CaseTime=" + CaseTime + ",Text=N'" + Text + "',callagentComments=N'" + CallagentComments;
                    strSQL = strSQL + "',DutyID=" + DutyID + ",isSubmit=" + isSubmit + ",isDel=0,TransferUser=" + TransferUser;
                    strSQL = strSQL + ",AppCountry=N'" + AppCountry + "', AppBranch=N'" + AppBranch + "', EnduserCountry=N'" + EnduserCountry + "', EnduserBranch=N'" + EnduserBranch;

                    strSQL = strSQL + "',status=N'" + Status + "',SFAEIHR_Warranty=N'" + Warranty + "',Warranty=N'" + Warranty + "',ModifyUser=" + objUserInfo.UserID + ",ModifyDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    strSQL = strSQL + "',AppVIPID = '" + AppVIPID + "',AppAccountID = " + AppAccountID + ",AppContactID = " + AppContactID;
                    strSQL = strSQL + ",EnduserVIPID = '" + EnduserVIPID + "',EnduserAccountID = " + EnduserAccountID + ",EnduserContactID = " + EnduserContactID + " ";
                    strSQL = strSQL + ",ExchExpendProjectName = N'" + ExchExpendProjectName + "',ExchExpendProjectNO = N'" + ExchExpendProjectNO + "',ExchExpendSelectCompany = " + ExchExpendSelectCompany + ",ExchExpendFSPostAddress = '" + ExchExpendFSPostAddress;
                    strSQL = strSQL + "',OrderType = '" + OrderType + "',RSVNO = N'" + RSVNO + "',MachineManufacturer = N'" + MachineManufacturer + "',TypeOfMachine = N'" + TypeOfMachine;
                    strSQL = strSQL + "',MachineSerialNo = N'" + MachineSerialNo + "',ControllerType = N'" + ControllerType + "',DriverType = N'" + DriverType + "',SoftwareVersion = N'" + SoftwareVersion + "',AppIsGroupDamex = " + AppIsGroupDamex + ",EnduserIsGroupDamex = " + EnduserIsGroupDamex + ",ProcessingTechnology = '" + ProcessingTechnology + "',IfDown = " + IfDown + ",isFromSFAE=0,RSCNo='" + RSCNo + "',LocalRSCNo='" + LocalRSCNo;

                    strSQL = strSQL + "',OriCase = '" + OriCase + "',isRepeat = " + isRepeat + ",SFAEVIPID='" + SFAEVIPID + "',CaseVIP='" + CaseVIP + "',VIPSalesEmail='" + VIPSalesEmail;

                    strSQL = strSQL + "',DeliveryType = N'" + DeliveryType + "',ReceiveCompany =N'" + ReceiveCompany + "',Receiver=N'" + Receiver + "',ReceiverTel=N'" + ReceiverTel + "',ReceiverAddress=N'" + ReceiverAddress + "'";

                    strSQL += " where ID='" + uRequestID + "'";

                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }

            if (strError == "")
            {
                //subDB_SaveItem(context, uRequestID);
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        public void subDB_Delete(HttpContext context)
        {
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            strSQL = "update webInfo_ServiceRequest_Info set isDel=1 where id='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            
            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Delete Service Request",objUserInfo.UserID.ToString(),objUserInfo.EnUserName);

            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        public void subDB_Cancel(HttpContext context)
        {
            string strSQL;
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            strSQL = "update webInfo_ServiceRequest_Info set isCancel=1,Status='Cancel',CancelReason='服务取消',CancelDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Cancel Service Request",objUserInfo.UserID.ToString(),objUserInfo.EnUserName);

            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        public void subDB_Copy(HttpContext context)
        {
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            string strNewID = IdioSoft.Site.ClassLibrary.Control.ClassRequestCopy.funString_Insert_CopyRequest(uRequestID);

            if (strNewID != "")
            {
                context.Response.Write(strNewID);//成功
            }
            else
            {
                context.Response.Write("");//失败
            }
            context.Response.End();
        }

        public void subDB_DeleteFile(HttpContext context)
        {
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            strSQL = "update webInfo_ServiceRequest_Info set RequestDocument='' where id='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Delete Service Request File", objUserInfo.UserID.ToString(), objUserInfo.EnUserName);

            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        public void subDB_ClearEndUser(HttpContext context)
        {
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            string strSQL = @"UPDATE    webInfo_ServiceRequest_Info SET EnduserCompanyName ='', EnduserSubOffice ='', EnduserCustomerID ='', EnduserProvince ='', EnduserCity ='', EnduserCustomerType ='', 
                      EnduserContactName ='', EnduserTel ='', EnduserMobile ='', EnduserFax ='', EnduserAddress ='', EnduserPostCode ='', EnduserCountry ='', EnduserBranch ='', 
                      EnduserEmail ='', EnduserMainOffice ='', EnduserVIPID ='' where ID='" + uRequestID;
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Clear EndUserCompanyName Service Request",objUserInfo.UserID.ToString(),objUserInfo.EnUserName);

            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_SaveItem(HttpContext context,string uRequestID)
        {
            string strError = "";
            string strSQL = "";

            string strRequestItems = context.funString_RequestFormValue("Items");
            string[] strAll = strRequestItems.Split('[');

            strSQL = "delete webInfo_Servicerequest_Material_Info where uRequestID = '" + uRequestID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            for (int i = 1; i < strAll.Length; i++)
            {
                if (strAll[i].ToString().Trim() != "")
                {
                    System.Text.RegularExpressions.Regex rng = new System.Text.RegularExpressions.Regex("\\$\\$\\$");
                    string[] strItems = rng.Split(strAll[i].ToString());

                    string MLFBNo = strItems[0].ToString().funString_SQLToString();
                    string SerialNo = strItems[1].ToString().funString_SQLToString();
                    string MaterialProductName = strItems[2].ToString().funString_SQLToString();
                    string MaterialProducDesc = strItems[3].ToString().funString_SQLToString();
                    string MaterialFault = strItems[4].ToString().funString_SQLToString();
                    int Quantity = strItems[5].ToString().funString_SQLToString().funInt_StringToInt(0);
                    int TransferUser = strItems[6].ToString().Replace("]", "").funInt_StringToInt(0);

                    strSQL = @"INSERT INTO webInfo_Servicerequest_Material_Info   (uRequestID, MLFB, SerialNo, Quantity,MaterialProductName,MaterialProductDesc,MaterialFault) VALUES  (";
                    strSQL += "'" + uRequestID + "','" + MLFBNo + "','" + SerialNo + "'," + Quantity + ",N'" + MaterialProductName + "',N'" + MaterialProducDesc + "',N'" + MaterialFault + "')";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }
        }

        #region "RequestID编码yyyyMM0001"
        public string funString_RequestCode()
        {
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}