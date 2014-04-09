using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.SEWC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Delivery
{
    /// <summary>
    /// Summary description for ws_Delivery
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ws_Delivery : IWebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public void subLoadGridList()
        {
            HttpContext context = HttpContext.Current;
            IVList vlst = new CVList(new View_SEWC_Delivery_Info(), context
, "uRequestID, RequestID,AppCompanyName,EnduserCompanyName,DeliveryCustomer,MLFB, SerialNo,ProductGroup,ProductDesc,SEWCNotificationNo,ServiceType,Warranty, CreateUser, CaseTime");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_Delivery);

            context.Response.Clear();
            context.Response.Write(strReturn);
            context.Response.End();
        }


        [WebMethod]
        public string funissueDNDateImage(string uRequestID)
        {
            string strimg = "<img src='../../Style/images/black.png' />";
            string strSQL = "";
            strSQL = "select count(*) from View_SEWC_Reject_Info where [uRequestID]='" + uRequestID + "'";
            int intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            if (intCount > 0)
            {
                return "<img src='../../Style/images/red.png' />";
            }

            strSQL = @"SELECT issueDNDate FROM SEWC_Delivery_Info where uRequestID='" + uRequestID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string issueDNDate = ds.Tables[0].Rows[0]["issueDNDate"].ToString();
                if (issueDNDate.ToLower() == "")
                {
                    strimg = "<img src='../../Style/images/black.png' />";
                }
                else
                {
                    strimg = "<img src='../../Style/images/green.png' />";
                }
            }
            return strimg;
        }

        [WebMethod(EnableSession = true)]
        public string funSaveT6(string DeliveryDate, string uRequestIDs)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = uRequestIDs;
            string[] lst = sID.Split(',');

            DeliveryDate = DeliveryDate.funString_StringToDBDate();

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
                return "0";//成功
            }
            else
            {
                return "1";//失败
            }
        }

    }
}
