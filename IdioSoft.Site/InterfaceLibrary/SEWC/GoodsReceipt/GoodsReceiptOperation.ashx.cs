using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Common.Method;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using IdioSoft.Business.Frames;
using IdioSoft.Site.Business.Tables;
using IdioSoft.Site.Business.Tables.SEWC;


namespace IdioSoft.Site.InterfaceLibrary.SEWC.GoodsReceipt
{
    /// <summary>
    /// Summary description for GoodsReceiptOperation
    /// </summary>
    public class GoodsReceiptOperation : ICHttpHandler,IDForm
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

            //IdioSoft.Common.Frames.Forms.ISave isave = new IdioSoft.Business.SEWC.GoodsReceipt.GoodsReceiptSave(objUserInfo.UserID.ToString());
            //isave.subDB_Save(context);
            //Subject sub = new ProxySubject(new RealSubject());
        }

        public void subDB_Save(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            //string sID = "";
            //sID = context.funString_RequestFormValue("uRequestID");

            //string SEWCNotificationNo = context.funString_RequestFormValue("SEWCNotificationNo");
            //string Warranty = context.funString_RequestFormValue("Warranty");
            //string ReceiveDefectiveDate = context.funString_RequestFormValue("ReceiveDefectiveDate");
            //if (ReceiveDefectiveDate.ToString().Trim() == "")
            //{
            //    ReceiveDefectiveDate = "NULL";
            //}
            //else
            //{
            //    ReceiveDefectiveDate = "'" + ReceiveDefectiveDate + "'";
            //}
            //int IsReject = context.funString_RequestFormValue("IsReject").funInt_BoolToString();
            //string RejectReason = context.funString_RequestFormValue("RejectReason");
            //int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            //string FuntinalStateoriginal = context.funString_RequestFormValue("FuntinalStateoriginal");
            //string Firmwareoriginal = context.funString_RequestFormValue("Firmwareoriginal");
            //string ProductName = context.funString_RequestFormValue("ProductName");
            //string ProductDesc = context.funString_RequestFormValue("ProductDesc");
            //string MLFB = context.funString_RequestFormValue("MLFB");
            //string SerialNo = context.funString_RequestFormValue("SerialNo");
            //int Qty = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);

            SEWC_GoodsReceipt_Info objTableSave = new SEWC_GoodsReceipt_Info();
            ITable objTable = new CTable(objTableSave);
          
            objTableSave.uRequestID.FieldValue = Guid.Parse(context.funString_RequestFormValue("uRequestID"));

            objTable.RecordExistWhere = "uRequestID = '" + objTableSave.uRequestID.FieldValue + "'";

            objTableSave.SEWCNotificationNo.FieldValue = context.funString_RequestFormValue("SEWCNotificationNo");
            objTableSave.Warranty.FieldValue = context.funString_RequestFormValue("Warranty");
            objTableSave.ReceiveDefectiveDateT3.FieldValue = context.funString_RequestFormValue("ReceiveDefectiveDate").funDateTime_StringToDatetimeAllowNull();
            objTableSave.IsReject.FieldValue = context.funString_RequestFormValue("IsReject").funBool_StringToBool();
            objTableSave.RejectReason.FieldValue = context.funString_RequestFormValue("RejectReason");
            objTableSave.isSubmit.FieldValue = context.funString_RequestFormValue("isSubmit").funBool_StringToBool();
            objTableSave.FuntinalStateOriginal.FieldValue = context.funString_RequestFormValue("FuntinalStateoriginal");
            objTableSave.FirmwareOriginal.FieldValue = context.funString_RequestFormValue("Firmwareoriginal");
            objTableSave.ProductName.FieldValue = context.funString_RequestFormValue("ProductName");
            objTableSave.ProductDesc.FieldValue = context.funString_RequestFormValue("ProductDesc");
            objTableSave.MLFB.FieldValue = context.funString_RequestFormValue("MLFB");
            objTableSave.SerialNo.FieldValue = context.funString_RequestFormValue("SerialNo");
            objTableSave.Qty.FieldValue = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);
            objTableSave.ModifyDate.FieldValue = DateTime.Now;
            objTableSave.CreateUser.FieldValue = objUserInfo.UserID;
            //objTableSave.ModifyUser.FieldValue = objUserInfo.UserID;

           strError= objTable.Save();

            //            strSQL = "select count(*) from SEWC_GoodsReceipt_Info where uRequestID = '" + sID + "'";
            //            int intCount = 0;
            //            intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            //            if (intCount > 0)
            //            {
            //                strSQL = @"update SEWC_GoodsReceipt_Info set SEWCNotificationNo = '" + SEWCNotificationNo + "', Warranty = '" + Warranty + "', [ReceiveDefectiveDateT3] = " + ReceiveDefectiveDate;
            //                strSQL += ", IsReject = " + IsReject + ",ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',[FuntinalStateoriginal]='" + FuntinalStateoriginal;
            //                strSQL += "',ProductName = '" + ProductName + "',[Firmwareoriginal] = '" + Firmwareoriginal + "',ProductDesc = '" + ProductDesc;
            //                strSQL += "',MLFB='" + MLFB + "',SerialNo='" + SerialNo + "',Qty=" + Qty;
            //                strSQL += ",ModifyUser = '" + objUserInfo.UserID + "',isSubmit = " + isSubmit + ",RejectReason='" + RejectReason + "' where uRequestID = '" + sID + "'";
            //            }
            //            else
            //            {
            //                strSQL = @"insert into SEWC_GoodsReceipt_Info(uRequestID, SEWCNotificationNo, ProductDesc, MLFB, SerialNo, Qty, Warranty,
            //                            [ReceiveDefectiveDateT3], IsReject, RejectReason,CreateDate, CreateUser,isSubmit,[FuntinalStateoriginal], [Firmwareoriginal],ProductName) values(";
            //                strSQL += "'" + sID + "','" + SEWCNotificationNo + "','" + ProductDesc + "','" + MLFB + "','" + SerialNo;
            //                strSQL += "'," + Qty + ",'" + Warranty + "'," + ReceiveDefectiveDate + "," + IsReject + ",'" + RejectReason + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //                strSQL += "','" + objUserInfo.UserID + "'," + isSubmit + ",'" + FuntinalStateoriginal + "','" + Firmwareoriginal + "','" + ProductName + "')";
            //            }
            //            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            if (strError == "")
            {
                if (objTableSave.IsReject.FieldValue)
                {
                    strSQL = "update webinfo_serviceRequest_Info set isCancel=1 where ID='" + objTableSave.uRequestID.FieldValue + "'";
                    strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                }
                subDB_SaveRequest(objTableSave.uRequestID.FieldValue.ToString(), objTableSave.ProductName.FieldValue,
                    objTableSave.ProductDesc.FieldValue, objTableSave.MLFB.FieldValue, objTableSave.SerialNo.FieldValue, (Int32)objTableSave.Qty.FieldValue, objTableSave.Warranty.FieldValue);
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();


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


        public void subDB_DeleteFile(HttpContext context)
        {
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            strSQL = "update SEWC_GoodsReceipt_Info set RejectFile='' where uRequestID='" + uRequestID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            strSQL.InsertSQLLog("Delete Goods Receipt File", objUserInfo.UserID.ToString(), objUserInfo.EnUserName);

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


    }
}