using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.IO;
using OfficeOpenXml;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Delivery
{
    /// <summary>
    /// Summary description for DeliveryReport
    /// </summary>
    public class DeliveryReport : ICHttpHandler
    {

        public void subDB_Save(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");

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
            }
        }

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");

            if (OperationType.ToLower() == "operation")
            {
                subDB_Save(context);
            }

            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("uRequestID");
            string[] lst = sID.Split(',');
            string AllIDs = "'" + sID.Replace(",", "','") + "'";

            strSQL = "select count(*) from SEWC_Delivery_Info where uRequestID in (" + AllIDs + ")";
            int intDeliveryCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            strSQL = "SELECT distinct ReceiveCompany FROM SEWC_Delivery_Info where uRequestID in (" + AllIDs + ")";
            int intCompany = 0;
            DataSet dsRece = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (dsRece != null && dsRece.Tables[0].Rows.Count > 0)
            {
                intCompany = dsRece.Tables[0].Rows.Count;
            }

            if (lst.Length > intDeliveryCount)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("10001");//ReceiveCompany不相同
                context.Response.End();
            }

            if (intCompany > 1)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("10001");//ReceiveCompany不相同
                context.Response.End();
            }


            string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/DeliveryTemplate.xlsx");
            string xfileName = "SEWC_Delivery" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
            FileInfo newFile = new FileInfo(newFileName);
            FileInfo template = new FileInfo(strTemplateName);
            string CreateUser = "";
            string CreateUserTel = "";
            string DeliveryDate = "";
            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["DN"];

                strSQL = @"SELECT     d.TrackingNo, d.DeliveryDate, CASE WHEN l.id IS NULL THEN s.ReceiveCompany ELSE d .ReceiveCompany END AS ReceiveCompany, CASE WHEN l.id IS NULL 
                      THEN d .Receiver ELSE s.Receiver END AS Receiver, CASE WHEN l.id IS NULL THEN d .ReceiverTel ELSE s.ReceiverTel END AS ReceiverTel, CASE WHEN l.id IS NULL 
                      THEN d .ReceiverAddress ELSE s.ReceiverAddress END AS REceiverAddress, l.EnUserName AS CreateUser, l.Tel, s.ID,d.issueDNDate
FROM         dbo.SEWC_Delivery_Info AS d RIGHT OUTER JOIN
                      dbo.webInfo_ServiceRequest_Info AS s ON d.uRequestID = s.ID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS l ON d.CreateUser = l.ID
WHERE     (s.ServiceProvider = N'sewc') AND (s.isSubmit = 1) AND (s.isDel = 0) AND (s.isCancel = 0) and s.ID='" + lst[0].ToString() + "'";
                DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    worksheet.Cell(8, 4).Value = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
                    worksheet.Cell(8, 8).Value = ds.Tables[0].Rows[0]["TrackingNo"].ToString();
                    worksheet.Cell(10, 3).Value = ds.Tables[0].Rows[0]["ReceiveCompany"].ToString();
                    worksheet.Cell(11, 3).Value = ds.Tables[0].Rows[0]["ReceiverAddress"].ToString();
                    worksheet.Cell(12, 3).Value = ds.Tables[0].Rows[0]["Receiver"].ToString();
                    worksheet.Cell(13, 3).Value = ds.Tables[0].Rows[0]["ReceiverTel"].ToString();
                    worksheet.Cell(14, 3).Value = ds.Tables[0].Rows[0]["ReceiverTel"].ToString();
                    CreateUser = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                    DeliveryDate = ds.Tables[0].Rows[0]["issueDNDate"].ToString();
                    CreateUserTel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }

                strSQL = @"SELECT     d.ReceiveCompany, d.Receiver, d.ReceiverTel, d.ReceiverAddress, CASE WHEN s.serviceType = 'exch' THEN '' ELSE m.SerialNo END AS SerialNo, s.ServiceType, d.Warranty, d.[WeightUnit], 
                      g.SEWCNotificationNo, s.RequestID, m.MLFB, m.Quantity AS Qty, s.ID
FROM         dbo.SEWC_Delivery_Info AS d RIGHT OUTER JOIN
                      dbo.webInfo_Servicerequest_Material_Info AS m INNER JOIN
                      dbo.webInfo_ServiceRequest_Info AS s ON m.uRequestID = s.ID LEFT OUTER JOIN
                      dbo.SEWC_GoodsReceipt_Info AS g ON s.ID = g.uRequestID ON d.uRequestID = s.ID
WHERE     (s.ServiceProvider = N'sewc') AND (s.isSubmit = 1) AND (s.isDel = 0)  AND (s.isCancel = 0) and s.ID in (" + AllIDs + ")";
                DataSet dsItem = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        worksheet.Cell(18 + i, 1).Value = dsItem.Tables[0].Rows[i]["MLFB"].ToString();
                        worksheet.Cell(18 + i, 2).Value = dsItem.Tables[0].Rows[i]["SerialNo"].ToString();
                        worksheet.Cell(18 + i, 3).Value = dsItem.Tables[0].Rows[i]["RequestID"].ToString();
                        worksheet.Cell(18 + i, 4).Value = dsItem.Tables[0].Rows[i]["SEWCNotificationNo"].ToString();
                        worksheet.Cell(18 + i, 5).Value = dsItem.Tables[0].Rows[i]["ServiceType"].ToString();
                        worksheet.Cell(18 + i, 6).Value = dsItem.Tables[0].Rows[i]["Warranty"].ToString();
                        worksheet.Cell(18 + i, 7).Value = dsItem.Tables[0].Rows[i]["Qty"].ToString();
                        worksheet.Cell(18 + i, 8).Value = dsItem.Tables[0].Rows[i]["WeightUnit"].ToString();
                    }
                }
                worksheet.Cell(27, 2).Value = CreateUser;

                ExcelWorksheet PackingList = xlPackage.Workbook.Worksheets["Packing List"];
                PackingList.Cell(2, 7).Value = CreateUser;
                PackingList.Cell(3, 7).Value = CreateUserTel;

                if (DeliveryDate != "")
                {
                    DeliveryDate = DeliveryDate.funDateTime_StringToDatetime().ToShortDateString();
                }
                PackingList.Cell(4, 7).Value = DeliveryDate;

                if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        PackingList.Cell(7 + i, 1).Value = DeliveryDate;
                        PackingList.Cell(7 + i, 2).Value = dsItem.Tables[0].Rows[i]["MLFB"].ToString();
                        PackingList.Cell(7 + i, 3).Value = dsItem.Tables[0].Rows[i]["SerialNo"].ToString();
                        PackingList.Cell(7 + i, 4).Value = dsItem.Tables[0].Rows[i]["RequestID"].ToString();
                        PackingList.Cell(7 + i, 5).Value = dsItem.Tables[0].Rows[i]["Qty"].ToString();
                        if (dsItem.Tables[0].Rows[0]["MLFB"].ToString() != "")
                        {
                            PackingList.Cell(7 + i, 7).Value = "N";
                            PackingList.Cell(7 + i, 8).Value = "N";
                        }
                    }
                }

                xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                xlPackage.Save();
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(xfileName);
            context.Response.End();
        }

    }
}