using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using IdioSoft.Business.Method;
namespace IdioSoft.Site.InterfaceLibrary.SEWC.Repair
{
    /// <summary>
    /// Summary description for RepairOperation
    /// </summary>
    public class RepairOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");
            switch (OperationType.ToString().Trim().ToLower())
            {
                case "save":
                    subDB_Save(context);
                    break;
                case "deletefile":
                    subDB_DeleteFile(context);
                    break;
            }


        }

        public void subDB_DeleteFile(HttpContext context)
        {
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            strSQL = "update SEWC_Repair_Info set RejectFile='' where uRequestID='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL, "Delete Goods Receipt File", objUserInfo.UserID.ToString(), objUserInfo.EnUserName);

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

        private void subDB_Save(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string uRequestID = "";
            uRequestID = context.funString_RequestFormValue("uRequestID");

            string WorkStationCode = context.funString_RequestFormValue("WorkStationCode");
            string FuntinalStateoriginal = context.funString_RequestFormValue("FuntinalStateoriginal");
            string FuntinalStatelatest = context.funString_RequestFormValue("FuntinalStatelatest");
            string Firmwareoriginal = context.funString_RequestFormValue("Firmwareoriginal");
            string Firmwarelatest = context.funString_RequestFormValue("Firmwarelatest");
            string Warranty = context.funString_RequestFormValue("Warranty");
            string ConfirmCompleteDate = context.funString_RequestFormValue("ConfirmCompleteDate").funString_StringToDBDate();

            string FailureCasedType = context.funString_RequestFormValue("FailureCasedType");

            string ServiceType = context.funString_RequestFormValue("ServiceType");
            string Engineer = context.funString_RequestFormValue("Engineer");

            string EndRepairDate = context.funString_RequestFormValue("EndRepairDate").funString_StringToDBDate();

            string RepairResult = context.funString_RequestFormValue("RepairResult");
            string Remarks = context.funString_RequestFormValue("Remarks");
            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);

            strSQL = "select count(*) from SEWC_Repair_Info where uRequestID = '" + uRequestID + "'";
            int intCount = 0;
            intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            string MLFB = context.funString_RequestFormValue("MLFB");
            string SerialNo = context.funString_RequestFormValue("SerialNo");
            int Qty = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);

            decimal LaborCost = context.funString_RequestFormValue("LaborCost").funDec_StringToDecimal(0);

            if (intCount > 0)
            {
                strSQL = @"update SEWC_Repair_Info set WorkStationCode = '" + WorkStationCode + "',[FuntinalStateoriginal]='" + FuntinalStateoriginal;
                strSQL += "',[FuntinalStatelatest] = '" + FuntinalStatelatest + "',[Firmwareoriginal] = '" + Firmwareoriginal + "',[Firmwarelatest] = '" + Firmwarelatest;
                strSQL += "',Warranty = '" + Warranty + "',ConfirmCompleteDate = " + ConfirmCompleteDate + ",Engineer = '" + Engineer + "',LaborCost=" + LaborCost;
                strSQL += ",EndRepairDate = " + EndRepairDate + ",RepairResult = '" + RepairResult + "',Remarks = '" + Remarks;
                strSQL += "',isSubmit = " + isSubmit + ",FailureCasedType='" + FailureCasedType + "' where uRequestID = '" + uRequestID + "'";
            }
            else
            {
                strSQL = @"insert into SEWC_Repair_Info(uRequestID, WorkStationCode, MLFB, SerialNo, Qty, [FuntinalStateoriginal], [FuntinalStatelatest], [Firmwareoriginal], 
                      [Firmwarelatest], Warranty, ConfirmCompleteDate, EndRepairDate, Engineer, RepairResult, Remarks, CreateDate, CreateUser,isSubmit,FailureCasedType,LaborCost) values(";
                strSQL += "'" + uRequestID + "','" + WorkStationCode + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + FuntinalStateoriginal;
                strSQL += "','" + FuntinalStatelatest + "','" + Firmwareoriginal + "','" + Firmwarelatest + "','" + Warranty + "'," + ConfirmCompleteDate;
                strSQL += "," + EndRepairDate + ",'" + Engineer + "','" + RepairResult + "','" + Remarks + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                strSQL += "','" + objUserInfo.UserID + "'," + isSubmit + ",'" + FailureCasedType + "'," + LaborCost + ")";
            }
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            if (strError == "")
            {
                subDB_SaveItem(context);
                strSQL = "update webInfo_serviceRequest_Info set warranty='" + Warranty + "' where ID='" + uRequestID + "'";
                objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_SaveItem(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string sID = context.funString_RequestFormValue("uRequestID");
            string strRepairItems = context.funString_RequestFormValue("Items");
            string[] strAll = strRepairItems.Split('[');

            strSQL = "delete SEWC_RepairItem_Info where uRequestID = '" + sID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            for (int i = 1; i < strAll.Length; i++)
            {
                if (strAll[i].ToString().Trim() != "")
                {
                    System.Text.RegularExpressions.Regex rng = new System.Text.RegularExpressions.Regex("\\$\\$\\$");
                    string[] strItems = rng.Split(strAll[i].ToString());

                    string PCBA5ENo = strItems[0].ToString().funString_SQLToString();
                    string ComponentLocation = strItems[1].ToString().funString_SQLToString();
                    string RepairedComponentA5E = strItems[2].ToString().funString_SQLToString();
                    string Type = strItems[3].ToString().Replace("undefined", "").funString_SQLToString();
                    string FailureKind = strItems[4].ToString().Replace("undefined", "").funString_SQLToString();
                    string FCode = strItems[5].ToString().Replace("undefined", "").funString_SQLToString();
                    //string FailureCasedType = strItems[6].ToString().funString_SQLToString();
                    string RepairAction = strItems[6].ToString().Replace("undefined", "").funString_SQLToString();
                    int rowIndex = strItems[7].ToString().Replace("]", "").funInt_StringToInt(0);

                    strSQL = @"insert into SEWC_RepairItem_Info(uRequestID, PCBA5ENo, ComponentLocation, RepairedComponentA5E, Type, FailureKind, FCode, RepairAction,rowIndex) values(";
                    strSQL += "'" + sID + "','" + PCBA5ENo + "','" + ComponentLocation + "','" + RepairedComponentA5E + "','" + Type + "','" + FailureKind;
                    strSQL += "','" + FCode + "','" + RepairAction + "'," + rowIndex + ")";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
            }
        }

    }
}