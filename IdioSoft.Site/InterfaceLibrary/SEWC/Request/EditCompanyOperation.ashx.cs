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
    /// Summary description for EditCompanyOperation
    /// </summary>
    public class EditCompanyOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");
            switch (OperationType.ToString().Trim().ToLower())
            {
                case "addnew":
                case "modify":
                    subDB_EditCompany(context);
                    break;
                case "delete":
                    subDB_Delete(context);
                    break;
            }
        }

        public void subDB_EditCompany(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string CustomerID = context.funString_RequestFormValue("CustomerID");
            string CompanyName = context.funString_RequestFormValue("CompanyName");
            string SubOffice = context.funString_RequestFormValue("SubOffice");
            string Province = context.funString_RequestFormValue("Province");
            string City = context.funString_RequestFormValue("City");
            string CustomerType = context.funString_RequestFormValue("CustomerType");
            string CompanyAddress = context.funString_RequestFormValue("CompanyAddress");
            string PostAddress = context.funString_RequestFormValue("PostAddress");
            string RegAddress = context.funString_RequestFormValue("RegAddress");
            string ConsignorAddress = context.funString_RequestFormValue("ConsignorAddress");
            string TaxCode = context.funString_RequestFormValue("TaxCode");
            string AccountCode = context.funString_RequestFormValue("AccountCode");
            string BankName = context.funString_RequestFormValue("BankName");
            string PostCode = context.funString_RequestFormValue("PostCode");
            string FinanceTel = context.funString_RequestFormValue("FinanceTel");
            string Country = context.funString_RequestFormValue("Country");
            string Branch = context.funString_RequestFormValue("Branch");
            string VipID = context.funString_RequestFormValue("VipID");
            string VIPCompanyENName = context.funString_RequestFormValue("VIPCompanyENName");
            string VIPCompanyCNName = context.funString_RequestFormValue("VIPCompanyCNName");
            int IsGroupDamex = context.funString_RequestFormValue("IsGroupDamex").funInt_StringToInt(0);
            string BeiDeVIP = context.funString_RequestFormValue("BeiDeVIP");
            string CompanyKeyWords = context.funString_RequestFormValue("CompanyKeyWords");

            string OperationType = context.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
            string CreateDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (OperationType == "addnew")
            {
                strSQL = @"INSERT INTO Webinfo_Account_Info
                        (CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, 
                        TaxCode, AccountCode, BankName, PostCode, FinanceTel, Country, Branch, CreateUser, CreateDate,VipID,VIPCompanyENName,VIPCompanyCNName,IsGroupDamex,BeiDeVIP,CompanyKeyWords) VALUES (";
                strSQL = strSQL + "'" + CustomerID + "','" + CompanyName + "','" + SubOffice + "','" + Province + "','" + City + "','" + CustomerType + "'";
                strSQL = strSQL + ",'" + CompanyAddress + "','" + PostAddress + "','" + RegAddress + "','" + ConsignorAddress + "'";
                strSQL = strSQL + ",'" + TaxCode + "','" + AccountCode + "','" + BankName + "','" + PostCode + "','" + FinanceTel + "','" + Country + "','" + Branch + "'";
                strSQL = strSQL + "," + objUserInfo.UserID + ",'" + CreateDate + "','" + VipID + "','" + VIPCompanyENName + "','" + VIPCompanyCNName + "'," + IsGroupDamex + ",'" + BeiDeVIP + "','" + CompanyKeyWords + "')";
            }
            if (OperationType == "modify")
            {
                string AccountID = context.funString_RequestFormValue("AccountID");
                strSQL = @"UPDATE    Webinfo_Account_Info SET  CustomerID ='" + CustomerID + "', CompanyName ='" + CompanyName + "', SubOffice ='" + SubOffice + "',";
                strSQL = strSQL + "Province ='" + Province + "', City ='" + City + "', CustomerType ='" + CustomerType + "',CompanyAddress ='" + CompanyAddress + "', PostAddress ='" + PostAddress + "',";
                strSQL = strSQL + "RegAddress ='" + RegAddress + "',ConsignorAddress ='" + ConsignorAddress + "', TaxCode ='" + TaxCode + "', AccountCode ='" + AccountCode + "',";
                strSQL = strSQL + "BankName ='" + BankName + "', PostCode ='" + PostCode + "',FinanceTel ='" + FinanceTel + "', Country ='" + Country + "',";
                strSQL = strSQL + "Branch ='" + Branch + "',VipID='" + VipID + "',VIPCompanyCNName='" + VIPCompanyCNName + "',VIPCompanyENName='" + VIPCompanyENName + "',";
                strSQL = strSQL + "IsGroupDamex = " + IsGroupDamex + ",BeiDeVIP = '" + BeiDeVIP + "',CompanyKeyWords='" + CompanyKeyWords + "' where ID='" + AccountID + "'";
            }
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

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

        public void subDB_Delete(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string AccountID = context.funString_RequestFormValue("AccountID");
            strSQL = "delete from Webinfo_Account_Info where ID='" + AccountID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}