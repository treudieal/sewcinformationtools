using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using IdioSoft.Business.Method;
namespace IdioSoft.Site.InterfaceLibrary.SEWC.Delivery
{
    /// <summary>
    /// Summary description for DeliveryOperation
    /// </summary>
    public class DeliveryOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            subDB_Save(context);
        }

        public void subDB_Save(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("sID");

            string Warranty = context.funString_RequestFormValue("Warranty");
            string issueDNDate = context.funString_RequestFormValue("issueDNDate").funString_StringToDBDate();

            string DeliveryDate = context.funString_RequestFormValue("DeliveryDate").funString_StringToDBDate();

            string TrackingNo = context.funString_RequestFormValue("TrackingNo");
            string Weight = context.funString_RequestFormValue("Weight");
            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            string ReceiveCompany = context.funString_RequestFormValue("ReceiveCompany").funString_SQLToString();
            string Receiver = context.funString_RequestFormValue("Receiver").funString_SQLToString();
            string ReceiverTel = context.funString_RequestFormValue("ReceiverTel").funString_SQLToString();
            string ReceiverAddress = context.funString_RequestFormValue("ReceiverAddress").funString_SQLToString();

            string NewMLFB = context.funString_RequestFormValue("NewMLFB");
            string NewSerialNo = context.funString_RequestFormValue("NewSerialNo");

            string MLFB = context.funString_RequestFormValue("MLFB");
            string SerialNo = context.funString_RequestFormValue("SerialNo");
            int Qty = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);


            strSQL = "select count(*) from  SEWC_Delivery_Info where uRequestID = '" + uRequestID + "'";
            int intCount = 0;
            intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            if (intCount > 0)
            {
                strSQL = @"update  SEWC_Delivery_Info set Warranty = '" + Warranty + "',issueDNDate = " + issueDNDate + ",DeliveryDate = " + DeliveryDate;
                strSQL += ",TrackingNo = '" + TrackingNo + "',[WeightUnit] = '" + Weight + "',ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                strSQL += "',ReceiveCompany='" + ReceiveCompany + "',Receiver='" + Receiver + "',ReceiverTel='" + ReceiverTel + "',ReceiverAddress='" + ReceiverAddress;
                strSQL += "',ModifyUser = '" + objUserInfo.UserID + "',isSubmit = " + isSubmit + ",NewMLFB='" + NewMLFB + "',NewSerialNo='" + NewSerialNo + "' where uRequestID = '" + uRequestID + "'";
            }
            else
            {

                strSQL = @"insert into SEWC_Delivery_Info(uRequestID, MLFB, SerialNo, Qty, [WeightUnit], Warranty
                            , DeliveryDate, TrackingNo, CreateDate, CreateUser,isSubmit,ReceiveCompany,Receiver,ReceiverTel,ReceiverAddress,NewMLFB,NewSerialNo,issueDNDate) values(";
                strSQL += "'" + uRequestID + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + Weight + "','" + Warranty + "";
                strSQL += "'," + DeliveryDate + ",'" + TrackingNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                strSQL += "','" + objUserInfo.UserID + "'," + isSubmit + ",'" + ReceiveCompany + "','" + Receiver + "','" + ReceiverTel + "','" + ReceiverAddress + "','" + NewMLFB + "','" + NewSerialNo + "'," + issueDNDate + ")";
            }
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            if (strError == "")
            {
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
    }
}