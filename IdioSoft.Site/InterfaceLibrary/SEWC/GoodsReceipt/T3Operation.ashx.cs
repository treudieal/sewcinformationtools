using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using IdioSoft.Site.DB.Tables;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views;
using IdioSoft.Site.DB.Tables.SEWC;
using IdioSoft.Site.DB.Views.SEWC;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.GoodsReceipt
{
    /// <summary>
    /// Summary description for T3Operation
    /// </summary>
    public class T3Operation : ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("uRequestID");
            string[] lst = sID.Split(',');

            string ReceiveDefectiveDate = context.funString_RequestFormValue("ReceiveDefectiveDate");

            SEWC_GoodsReceipt_Info objTableInfo = new SEWC_GoodsReceipt_Info();
            for (int i = 0; i < lst.Length; i++)
            {
                //strSQL = "select count(*) from SEWC_GoodsReceipt_Info where uRequestID = '" + lst[i].ToString() + "'";
                //int intCount = 0;
                //intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);\

                objTableInfo = new SEWC_GoodsReceipt_Info();
                ITable objTable = new CTable(objTableInfo);
                objTable.RecordExistWhere = "uRequestID = '" + lst[i].ToString() + "'";

                if (objTable.isRecordExist())
                {
                    objTableInfo.ReceiveDefectiveDateT3.FieldValue = ReceiveDefectiveDate.funDateTime_StringToDatetime();
                    strError=objTable.Save();
                    //strSQL = "update SEWC_GoodsReceipt_Info set [ReceiveDefectiveDateT3] = " + ReceiveDefectiveDate + " where uRequestID = '" + lst[i].ToString() + "'";
                }
                else
                {
                    //strSQL = "select ID, RequestID, Warranty,ProductDesc,ProductName from webInfo_ServiceRequest_Info where ID = '" + lst[i].ToString() + "'";
                    //DataSet dsMain = new DataSet();
                    //dsMain = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                    //if (dsMain != null && dsMain.Tables[0].Rows.Count > 0)
                    //{
                    //    string RequestID = dsMain.Tables[0].Rows[0]["RequestID"].ToString();
                    //    string ProductDesc = dsMain.Tables[0].Rows[0]["ProductDesc"].ToString();
                    //    string ProductName = dsMain.Tables[0].Rows[0]["ProductName"].ToString();
                    //    string Warranty = dsMain.Tables[0].Rows[0]["Warranty"].ToString();

                    //    strSQL = "select top 1 MLFB,SerialNo, Quantity from webInfo_Servicerequest_Material_Info where uRequestID = '" + lst[i].ToString() + "'";
                    //    DataSet dsItem = new DataSet();
                    //    dsItem = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                    //    string MLFB = "";
                    //    string SerialNo = "";
                    //    int Qty = 0;

                    //    if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
                    //    {
                    //        MLFB = dsItem.Tables[0].Rows[0]["MLFB"].ToString();
                    //        SerialNo = dsItem.Tables[0].Rows[0]["SerialNo"].ToString();
                    //        Qty = dsItem.Tables[0].Rows[0]["Quantity"].ToString().funInt_StringToInt(0);
                    //    }

                    //    strSQL = "insert into SEWC_GoodsReceipt_Info(uRequestID,ProductName, ProductDesc, MLFB, SerialNo, Qty,[ReceiveDefectiveDateT3],CreateDate, CreateUser,Warranty) values(";
                    //    strSQL += "'" + lst[i].ToString() + "','" + ProductName+"','" + ProductDesc + "','" + MLFB + "','" + SerialNo;
                    //    strSQL += "'," + Qty + "," + ReceiveDefectiveDate + ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //    strSQL += "','" + objUserInfo.UserID + "','" + Warranty + "')";
                    //}
                    View_SEWC_GoodsReceipt_Detail objViewDetail = new View_SEWC_GoodsReceipt_Detail();
                    IDBUnit objView = new CView(objViewDetail);
                    objView.getData("ID = '" + lst[i].ToString() + "'");

                    objTableInfo.ID.FieldValue = Guid.NewGuid();
                    objTableInfo.uRequestID.FieldValue = objViewDetail.ID.FieldValue;
                    objTableInfo.ProductName.FieldValue = objViewDetail.ProductName.FieldValue;
                    objTableInfo.ProductDesc.FieldValue = objViewDetail.ProductDesc.FieldValue;
                    objTableInfo.Warranty.FieldValue = objViewDetail.Warranty.FieldValue;
                    objTableInfo.MLFB.FieldValue = objViewDetail.MLFB.FieldValue;
                    objTableInfo.SerialNo.FieldValue = objViewDetail.SerialNo.FieldValue;
                    objTableInfo.Qty.FieldValue = objViewDetail.Qty.FieldValue;
                    objTableInfo.ReceiveDefectiveDateT3.FieldValue = ReceiveDefectiveDate.funDateTime_StringToDatetime();
                    objTableInfo.CreateDate.FieldValue = DateTime.Now;
                    objTableInfo.CreateUser.FieldValue = objUserInfo.UserID;
                    strError = objTable.Save();
                }
            }
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