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

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Delivery
{
    /// <summary>
    /// Summary description for T6Operation
    /// </summary>
    public class T6Operation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("uRequestID");
            string[] lst = sID.Split(',');

            string DeliveryDate = context.funString_RequestFormValue("DeliveryDate").funString_StringToDBDate();

            for (int i = 0; i < lst.Length; i++)
            {
                strSQL = "select count(*) from SEWC_Delivery_Info where uRequestID = '" + lst[i].ToString() + "'";
                int intCount = 0;
                intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

                if (intCount > 0)
                {
                    strSQL = "update SEWC_Delivery_Info set DeliveryDate = " + DeliveryDate + " where uRequestID = '" + lst[i].ToString() + "'";
                }
                else
                {
                    strSQL = "select ID, RequestID, Warranty,ProductDesc,ProductName,ReceiveCompany, DeliveryType, Receiver, ReceiverTel, ReceiverAddress  from webInfo_ServiceRequest_Info where ID = '" + lst[i].ToString() + "'";
                    DataSet dsMain = new DataSet();
                    dsMain = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                    if (dsMain != null && dsMain.Tables[0].Rows.Count > 0)
                    {
                        string RequestID = dsMain.Tables[0].Rows[0]["RequestID"].ToString();
                        string ProductDesc = dsMain.Tables[0].Rows[0]["ProductDesc"].ToString();
                        string ProductName = dsMain.Tables[0].Rows[0]["ProductName"].ToString();
                        string Warranty = dsMain.Tables[0].Rows[0]["Warranty"].ToString();
                        string DeliveryType = dsMain.Tables[0].Rows[0]["DeliveryType"].ToString();
                        string Receiver = dsMain.Tables[0].Rows[0]["Receiver"].ToString();
                        string ReceiverTel = dsMain.Tables[0].Rows[0]["ReceiverTel"].ToString();
                        string ReceiverAddress = dsMain.Tables[0].Rows[0]["ReceiverAddress"].ToString();
                        string ReceiveCompany = dsMain.Tables[0].Rows[0]["ReceiveCompany"].ToString();

                        strSQL = "select top 1 MLFB,SerialNo, Quantity from webInfo_Servicerequest_Material_Info where uRequestID = '" + lst[i].ToString() + "'";
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

                        strSQL = @"insert into SEWC_Delivery_Info(uRequestID, MLFB, SerialNo, Qty, [WeightUnit], Warranty
                            , DeliveryDate, TrackingNo, CreateDate, CreateUser,isSubmit,ReceiveCompany,Receiver,ReceiverTel,ReceiverAddress,NewMLFB,NewSerialNo,issueDNDate) values(";
                        strSQL += "'" + lst[i].ToString() + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + "" + "','" + Warranty + "";
                        strSQL += "'," + DeliveryDate + ",'" + "" + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        strSQL += "','" + objUserInfo.UserID + "'," + 0 + ",'" + ReceiveCompany + "','" + Receiver + "','" + ReceiverTel + "','" + ReceiverAddress + "','" + MLFB + "','" + "" + "'," + "null" + ")";

                    }
                }
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
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