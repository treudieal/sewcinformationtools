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
using System.Collections;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Tables;
using IdioSoft.Site.DB.Tables.SEWC;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.IssueRepairOrder
{
    /// <summary>
    /// Summary description for IssueRepairOrderOperation
    /// </summary>
    public class IssueRepairOrderOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");

            switch (OperationType.ToString().Trim().ToLower())
            {
                case "selectwarranty":
                    subDB_SelectWarranty(context);
                    break;
                case "save":
                    subDB_Save(context);
                    break;
                case "chkquotation":
                    subDB_chkQuotation(context);
                    break;
                case "sendmail":
                    subDB_SendMail(context);
                    break;
                case "sendtest":
                    subDB_SendTest(context);
                    break;
                case "sendcancelmail":
                    subDB_SendCancelMail(context);
                    break;
            }
        }

        private void subDB_SelectWarranty(HttpContext context)
        {
            subQuotation_Table(context);
        }

        private void subDB_Save(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            SEWC_IssueRepairOrder_Info objTableSave = new SEWC_IssueRepairOrder_Info();
            ITable objTable = new CTable(objTableSave);

            objTableSave.uRequestID.FieldValue = Guid.Parse(context.funString_RequestFormValue("sID"));
            objTable.RecordExistWhere = "uRequestID = '" + objTableSave.uRequestID.FieldValue + "'";
            objTableSave.Warranty.FieldValue = context.funString_RequestFormValue("Warranty");
            objTableSave.ReveiveBankReceipt.FieldValue = context.funString_RequestFormValue("ReveiveBankReceipt").funBoolean_StringToBoolean();
            objTableSave.IsGoodWill.FieldValue = context.funString_RequestFormValue("IsGoodWill").funBoolean_StringToBoolean();
            objTableSave.GoodWillNo.FieldValue = context.funString_RequestFormValue("GoodWillNo");
            objTableSave.CancelDate.FieldValue = context.funString_RequestFormValue("CancelDate").funDateTime_StringToDatetimeAllowNull();
            objTableSave.CancelReason.FieldValue = context.funString_RequestFormValue("CancelReason");
            objTableSave.IssueRepairOrderDate.FieldValue = context.funString_RequestFormValue("IssueRepairOrderDate").funDateTime_StringToDatetimeAllowNull();
            objTableSave.CustomerConfirmDate.FieldValue = context.funString_RequestFormValue("CustomerConfirmDate").funDateTime_StringToDatetimeAllowNull();
            objTableSave.Repairble.FieldValue = context.funString_RequestFormValue("Repairble");
            objTableSave.isSubmit.FieldValue = context.funString_RequestFormValue("isSubmit").funBoolean_StringToBoolean();
            objTableSave.OrderType.FieldValue = context.funString_RequestFormValue("OrderType");
            objTableSave.MLFB.FieldValue = context.funString_RequestFormValue("MLFB");
            objTableSave.SerialNo.FieldValue = context.funString_RequestFormValue("SerialNo");
            objTableSave.Qty.FieldValue = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);
            objTableSave.ProductDate.FieldValue = ClassLibrary.SEWC.Util.funString_ProductDate(objTableSave.SerialNo.FieldValue);
            objTableSave.FactoryOforigin.FieldValue = ClassLibrary.SEWC.Util.funString_FactoryOforigin(objTableSave.SerialNo.FieldValue);
            objTableSave.FixPrice.FieldValue = context.funString_RequestFormValue("FixPrice").funBoolean_StringToBoolean();
            objTableSave.TotalPrice.FieldValue = context.funString_RequestFormValue("TotalPrice").funDec_StringToDecimal(0);
            strError = objTable.Save();

            //            sID = context.funString_RequestFormValue("sID");
            //            string ServiceType = context.funString_RequestFormValue("ServiceType");
            //            string Warranty = context.funString_RequestFormValue("Warranty");
            //            int ReveiveBankReceipt = context.funString_RequestFormValue("ReveiveBankReceipt").funInt_BoolToString();
            //            int IsGoodWill = context.funString_RequestFormValue("IsGoodWill").funInt_BoolToString();
            //            string GoodWillNo = context.funString_RequestFormValue("GoodWillNo");
            //            string CancelDate = context.funString_RequestFormValue("CancelDate").funString_StringToDBDate();
            //            string CancelReason = context.funString_RequestFormValue("CancelReason");
            //            string IssueRepairOrderDate = context.funString_RequestFormValue("IssueRepairOrderDate").funString_StringToDBDate();
            //            string CustomerConfirmDate = context.funString_RequestFormValue("CustomerConfirmDate").funString_StringToDBDate();
            //            string Repairble = context.funString_RequestFormValue("Repairble");

            //            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            //            string OrderType = context.funString_RequestFormValue("OrderType");
            //            string MLFB = context.funString_RequestFormValue("MLFB");
            //            string SerialNo = context.funString_RequestFormValue("SerialNo");
            //            int Qty = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);

            //            strSQL = "select count(*) from SEWC_IssueRepairOrder_Info where uRequestID = '" + sID + "'";
            //            int intCount = 0;
            //            intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            //            if (intCount > 0)
            //            {
            //                strSQL = "update SEWC_IssueRepairOrder_Info set MLFB='" + MLFB + "',SerialNo='" + SerialNo + "',Qty=" + Qty + ", Warranty = '" + Warranty 
            //                            + "', ReveiveBankReceipt = " + ReveiveBankReceipt + ",IsGoodWill = " + IsGoodWill;
            //                strSQL += ", GoodWillNo = '" + GoodWillNo + "',CustomerConfirmDate=" + CustomerConfirmDate + ",CancelDate = " + CancelDate + ", CancelReason = '" + CancelReason;
            //                strSQL += "',ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',ModifyUser = '" + objUserInfo.UserID;
            //                strSQL += "',IssueRepairOrderDate = " + IssueRepairOrderDate + ",Repairble = '" + Repairble 
            //                    + "',isSubmit=" + isSubmit + ",OrderType='" + OrderType + "' where uRequestID = '" + sID + "'";
            //            }
            //            else
            //            {
            //                strSQL = @"insert into SEWC_IssueRepairOrder_Info(uRequestID, MLFB, SerialNo, Qty, Warranty, ReveiveBankReceipt, IsGoodWill, GoodWillNo,CancelReason, CancelDate, 
            //                        CreateDate, CreateUser, IssueRepairOrderDate, Repairble,isSubmit,CustomerConfirmDate,OrderType) values(";
            //                strSQL += "'" + sID + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + Warranty;
            //                strSQL += "'," + ReveiveBankReceipt + "," + IsGoodWill + ",'" + GoodWillNo + "','" + CancelReason + "'," + CancelDate + ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //                strSQL += "','" + objUserInfo.UserID + "'," + IssueRepairOrderDate + ",'" + Repairble + "'," + isSubmit + "," + CustomerConfirmDate + ",'" + OrderType + "')";
            //            }

            //strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            if (strError == "")
            {
                string ServiceType = context.funString_RequestFormValue("ServiceType");
                if (objTableSave.Repairble.FieldValue.ToLower() == "n")
                {
                    strSQL = "update webInfo_serviceRequest_Info set MLFBNo='" + objTableSave.MLFB.FieldValue + "',SerialNo='" + objTableSave.SerialNo.FieldValue + "', serviceType='" + ServiceType + "', warranty='" + objTableSave.Warranty.FieldValue + "',isCancel=1 where ID='" + objTableSave.uRequestID.FieldValue + "'";
                }
                else
                {
                    strSQL = "update webInfo_serviceRequest_Info set MLFBNo='" + objTableSave.MLFB.FieldValue + "',SerialNo='" + objTableSave.SerialNo.FieldValue + "',serviceType='" + ServiceType + "', warranty='" + objTableSave.Warranty.FieldValue + "' where ID='" + objTableSave.uRequestID.FieldValue + "'";
                }
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                strSQL = "update webinfo_serviceRequest_Material_Info set MLFB='" + objTableSave.MLFB.FieldValue + "',SerialNo='" + objTableSave.SerialNo.FieldValue + "',Quantity=" + objTableSave.Qty.FieldValue + " where uRequestID='" + objTableSave.uRequestID.FieldValue + "'";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_Save_SNC_Time(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("uRequestID");

            string MLFB = "";
            string SerialNo = "";
            int Qty = 0;
            string Warranty = "";
            string ReceiveDefectiveDate = "NULL";
            string RMHandleDate = "NULL";
            string DeliveryDate = "NULL";
            int isReject = 0;
            string RejectReason = "";
            string Comments = "";
            int isScrap = 0;
            string QuotationDate = "NULL";
            string CustomerConfirmDate = "NULL";
            string Attachment = "";
            string SNCNotificationNo = "";
            string transportationNo = "";
            string CancelReason = "";
            string ModifyDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ModifyUser = objUserInfo.EnUserName;

            strSQL = "select SEWCNotificationNo from  SEWC_GoodsReceipt_Info where uRequestID = '" + sID + "'";
            SNCNotificationNo = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);

            strSQL = @"SELECT i.MLFB, i.SerialNo, i.Qty, i.Warranty, g.[ReceiveDefectiveDateT3], i.QuotationDate, i.CustomerConfirmDate, i.CancelReason, s.RequestID
                      FROM dbo.SEWC_IssueRepairOrder_Info AS i INNER JOIN
                      dbo.SEWC_GoodsReceipt_Info AS g ON i.uRequestID = g.uRequestID INNER JOIN
                      dbo.webInfo_ServiceRequest_Info AS s ON i.uRequestID = s.ID where s.ID = '" + sID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                MLFB = ds.Tables[0].Rows[0]["MLFB"].ToString();
                SerialNo = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                Qty = ds.Tables[0].Rows[0]["Qty"].ToString().funInt_StringToInt(0);
                Warranty = ds.Tables[0].Rows[0]["Warranty"].ToString();
                ReceiveDefectiveDate = ds.Tables[0].Rows[0]["ReceiveDefectiveDateT3"].ToString().funString_StringToDBDate();
                QuotationDate = ds.Tables[0].Rows[0]["QuotationDate"].ToString().funString_StringToDBDate();
                CustomerConfirmDate = ds.Tables[0].Rows[0]["CustomerConfirmDate"].ToString().funString_StringToDBDate();
                CancelReason = ds.Tables[0].Rows[0]["CancelReason"].ToString();
            }

            if (Warranty.ToString().Trim().ToLower() == "out warranty" || Warranty.ToString().Trim().ToLower() == "iw change to ow")
            {
                strSQL = "select count(*) from CallCenter_SNC_Time_Info where uRequestID = '" + sID + "'";
                int intCount = 0;
                intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

                if (intCount > 0)
                {
                    strSQL = @"update CallCenter_SNC_Time_Info set MLFB = '" + MLFB + "',SerialNo = '" + SerialNo + "',Qty = " + Qty + ",Warranty = '" + Warranty;
                    strSQL += "',AcceptDate = " + ReceiveDefectiveDate + ",RMHandleDate = " + RMHandleDate + ",DeliveryDate = " + DeliveryDate + ",isReject = " + isReject;
                    strSQL += ",RejectReason = '" + RejectReason + "',Comments = '" + Comments + "',isScrap = " + isScrap + ",QuotationDate = " + QuotationDate;
                    strSQL += ",CustomerConfirmDate = " + CustomerConfirmDate + ",Attachment='" + Attachment + "',SNCNotificationNo='" + SNCNotificationNo;
                    strSQL += "',transportationNo='" + transportationNo + "',ModifyDate='" + ModifyDate + "',ModifyUser='" + ModifyUser + "',CancelReason='" + CancelReason;
                    strSQL += "',IsSendMail=1,SendMailDate = " + QuotationDate + " where uRequestID = '" + sID + "'";
                }
                else
                {
                    strSQL = @"Insert into CallCenter_SNC_Time_Info(uRequestID, MLFB, SerialNo, Qty,Warranty, AcceptDate, RMHandleDate, DeliveryDate, isReject, RejectReason, 
                            Comments,isScrap,QuotationDate,CustomerConfirmDate,Attachment,SNCNotificationNo,transportationNo,CancelReason,IsSendMail,SendMailDate) values(";
                    strSQL += "'" + sID + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + Warranty + "'," + ReceiveDefectiveDate + "," + RMHandleDate;
                    strSQL += "," + DeliveryDate + "," + isReject + ",'" + RejectReason + "','" + Comments + "'," + isScrap + "," + QuotationDate + "," + CustomerConfirmDate;
                    strSQL += ",'" + Attachment + "','" + SNCNotificationNo + "','" + transportationNo + "','" + CancelReason + "',1," + QuotationDate + ")";
                }
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }



        }

        private void subQuotation_Table(HttpContext context)
        {
            string Warranty = context.funString_RequestFormValue("Warranty");
            if (Warranty.ToString().Trim().ToLower() == "out warranty" || Warranty.ToString().Trim().ToLower() == "iw change to ow")
            {
                string MLFB = context.funString_RequestFormValue("MLFB");
                string uRequestID = context.funString_RequestFormValue("uRequestID");

                string strSQL = "SELECT ProductType, MLFB, Component,orderno FROM SEWC_Basic_Quotation_Info where MLFB = '" + MLFB + "'  group by orderno,ProductType, MLFB, Component order by  orderno,ProductType, MLFB, Component";
                DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                HtmlTable objTable = new HtmlTable();
                objTable.Border = 1;
                objTable.Attributes.Add("bordercolordark", "#CCCCCC");
                objTable.Attributes.Add("bordercolorlight", "#FFFFFF");
                objTable.CellPadding = 2;
                objTable.CellSpacing = 0;
                HtmlTableRow objRow;
                HtmlTableCell objCell;
                HtmlInputText objText;
                CheckBox objChk;
                StringBuilder sb = new StringBuilder();

                string strProductType = "";
                string strMLFB = "";
                DataView dv;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objRow = new HtmlTableRow();

                    if (strProductType != ds.Tables[0].Rows[i]["ProductType"].ToString())
                    {
                        objCell = new HtmlTableCell();
                        objCell.InnerText = ds.Tables[0].Rows[i]["ProductType"].ToString();
                        dv = new DataView(ds.Tables[0]);
                        dv.RowFilter = "ProductType='" + ds.Tables[0].Rows[i]["ProductType"].ToString() + "'";
                        objCell.RowSpan = dv.Count;
                        objRow.Cells.Add(objCell);
                    }
                    if (strMLFB != ds.Tables[0].Rows[i]["MLFB"].ToString())
                    {
                        objCell = new HtmlTableCell();
                        objCell.InnerText = ds.Tables[0].Rows[i]["MLFB"].ToString();

                        dv = new DataView(ds.Tables[0]);
                        dv.RowFilter = "ProductType='" + ds.Tables[0].Rows[i]["ProductType"].ToString() + "' and MLFB='" + ds.Tables[0].Rows[i]["MLFB"].ToString() + "'";
                        objCell.RowSpan = dv.Count;

                        objRow.Cells.Add(objCell);
                    }
                    strMLFB = ds.Tables[0].Rows[i]["MLFB"].ToString();
                    objCell = new HtmlTableCell();
                    objCell.InnerText = ds.Tables[0].Rows[i]["Component"].ToString();
                    objRow.Cells.Add(objCell);

                    objCell = new HtmlTableCell();
                    objText = new HtmlInputText();
                    objText.ID = "txtValue" + i.ToString();
                    //objText.Attributes.Add("Class", "clstxtValue");
                    objText.Disabled = true;

                    objText.Value = funString_Amount(ds.Tables[0].Rows[i]["ProductType"].ToString(), ds.Tables[0].Rows[i]["MLFB"].ToString(), ds.Tables[0].Rows[i]["Component"].ToString(), uRequestID);

                    objCell.Controls.Add(objText);
                    objRow.Cells.Add(objCell);

                    objCell = new HtmlTableCell();
                    objChk = new CheckBox();
                    objChk.ID = "chk" + i.ToString();
                    objChk.Attributes.Add("ProductType", ds.Tables[0].Rows[i]["ProductType"].ToString());
                    objChk.Attributes.Add("MLFB", ds.Tables[0].Rows[i]["MLFB"].ToString());
                    objChk.Attributes.Add("Component", ds.Tables[0].Rows[i]["Component"].ToString());
        
                    if (objText.Value != "")
                    {
                        objChk.Checked = true;
                    }
                    else
                    {
                        objChk.Checked = false;
                    }
                    objChk.CssClass = "clschkQuotation";

                    objCell.Controls.Add(objChk);
                    objRow.Cells.Add(objCell);

                    strProductType = ds.Tables[0].Rows[i]["ProductType"].ToString();

                    objTable.Rows.Add(objRow);
                }
                StringWriter s = new StringWriter();
                HtmlTextWriter d = new HtmlTextWriter(s);
                objTable.RenderControl(d);

                context.Response.Write(s.ToString());
                context.Response.End();
            }
        }

        private string funString_Amount(string ProductType, string MLFB, string Component, string PuRequestIDs)
        {
            string strSQL = "";
            strSQL = "select Amount from SEWC_Quotation_Info where ProductType = '" + ProductType + "' and MLFB = '" + MLFB + "' and Component = '" + Component + "' and uRequestID='" + PuRequestIDs + "'";
            string Amount = "";
            Amount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            return Amount;
        }

        private void subDB_chkQuotation(HttpContext context)
        {
            string PuRequestIDs = "";
            string ProductType = "";
            string MLFB = "";
            string Component = "";
            string QuotationChecked = "";
            string strReturn = "";

            PuRequestIDs = context.funString_RequestFormValue("uRequestID");
            ProductType = context.funString_RequestFormValue("ProductType");
            MLFB = context.funString_RequestFormValue("MLFB");
            Component = context.funString_RequestFormValue("Component");
            QuotationChecked = context.funString_RequestFormValue("QuotationChecked");

            string strSQL = "";
            strSQL = "select Amount,MaterialAmount from SEWC_Basic_Quotation_Info where ProductType = '" + ProductType + "' and MLFB = '" + MLFB + "' and Component = '" + Component + "'";
            string Amount = "";
            string MaterialAmount = "";
            DataSet dsAmount = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (dsAmount != null && dsAmount.Tables[0].Rows.Count > 0)
            {
                Amount = dsAmount.Tables[0].Rows[0]["Amount"].ToString();
                MaterialAmount = dsAmount.Tables[0].Rows[0]["MaterialAmount"].ToString();
            }
            //((HtmlInputText)(o.Parent.Parent.FindControl("txtValue" + o.ID.Replace("chk", "")))).Value = Amount;
            strReturn = Amount;

            if (QuotationChecked == "true")
            {
                strSQL = "select ID from SEWC_Quotation_Info where uRequestID = '" + PuRequestIDs + "' and ProductType = '" + ProductType + "' and MLFB = '" + MLFB + "' and Component = '" + Component + "'";
                string strID = "";
                strID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                decimal dlAmount = 0;
                decimal dlMaterialAmount = 0;
                if (Amount.ToString().Trim() != "")
                {
                    dlAmount = Amount.funDec_StringToDecimal(0);
                }
                if (MaterialAmount.ToString().Trim() != "")
                {
                    dlMaterialAmount = MaterialAmount.funDec_StringToDecimal(0);
                }
                if (strID.ToString().Trim() == "")
                {
                    strSQL = "insert into SEWC_Quotation_Info(uRequestID,ProductType,MLFB,Component,Amount,MaterialAmount) values('" + PuRequestIDs + "','" + ProductType + "','" + MLFB + "','" + Component + "'," + dlAmount + "," + dlMaterialAmount + ")";
                }
                else
                {
                    strSQL = "update SEWC_Quotation_Info set ProductType = '" + ProductType + "',MLFB = '" + MLFB + "',Component = '" + Component + "',Amount = " + dlAmount + ",MaterialAmount=" + dlMaterialAmount + " where ID = '" + dlAmount + "'";
                }
                string strError = "";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            else
            {
                //((HtmlInputText)(o.Parent.Parent.FindControl("txtValue" + o.ID.Replace("chk", "")))).Value = "";
                strReturn = "";
                strSQL = "delete SEWC_Quotation_Info where uRequestID = '" + PuRequestIDs + "' and ProductType = '" + ProductType + "' and MLFB = '" + MLFB + "' and Component = '" + Component + "'";

                string strError = "";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }

            context.Response.Write(strReturn + ":" + funDec_TotalAmount(PuRequestIDs));
            context.Response.End();
        }

        private decimal funDec_TotalAmount(string uRequestID)
        {
            decimal mTotal = 0;
            string strSQL = "";
            strSQL = @"SELECT  sum(MaterialAmount)
FROM            SEWC_Quotation_Info where uRequestID='" + uRequestID + "'";
            mTotal = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funDec_StringToDecimal(0);
            decimal decT = ((mTotal * 1.1m + 248.31m) * 1.2m * 1.05m + 100.8m) * 1.17m;
            return decT;
        }

        private void subDB_Save_SendMail(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("uRequestID");
            string Warranty = context.funString_RequestFormValue("Warranty");
            int ReveiveBankReceipt = context.funString_RequestFormValue("ReveiveBankReceipt").funInt_BoolToString();
            int IsGoodWill = context.funString_RequestFormValue("IsGoodWill").funInt_BoolToString();
            string GoodWillNo = context.funString_RequestFormValue("GoodWillNo");
            string CancelDate = context.funString_RequestFormValue("CancelDate").funString_StringToDBDate();
            string CancelReason = context.funString_RequestFormValue("CancelReason");
            string IssueRepairOrderDate = context.funString_RequestFormValue("IssueRepairOrderDate").funString_StringToDBDate();
            string CustomerConfirmDate = context.funString_RequestFormValue("CustomerConfirmDate").funString_StringToDBDate();
            string Repairble = context.funString_RequestFormValue("Repairble");
            string ServiceType = context.funString_RequestFormValue("ServiceType");
            int isSubmit = context.funString_RequestFormValue("isSubmit").funInt_StringToInt(0);
            string OrderType = context.funString_RequestFormValue("OrderType");
            string MLFB = context.funString_RequestFormValue("MLFB");
            string SerialNo = context.funString_RequestFormValue("SerialNo");
            int Qty = context.funString_RequestFormValue("Qty").funInt_StringToInt(0);

            strSQL = "select count(*) from SEWC_IssueRepairOrder_Info where uRequestID = '" + sID + "'";
            int intCount = 0;
            intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);

            if (intCount > 0)
            {
                strSQL = "update SEWC_IssueRepairOrder_Info set   MLFB='" + MLFB + "',SerialNo='" + SerialNo + "',Qty=" + Qty + ", Warranty = '" + Warranty
                            + "', ReveiveBankReceipt = " + ReveiveBankReceipt + ",IsGoodWill = " + IsGoodWill;
                strSQL += ", GoodWillNo = '" + GoodWillNo + "',CustomerConfirmDate=" + CustomerConfirmDate + ",CancelDate = " + CancelDate + ", CancelReason = '" + CancelReason;
                strSQL += "',ModifyDate = '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',ModifyUser = '" + objUserInfo.UserID;
                strSQL += "',IssueRepairOrderDate = " + IssueRepairOrderDate + ",Repairble = '" + Repairble
                    + "',isSubmit=" + isSubmit + ",OrderType='" + OrderType + "' where uRequestID = '" + sID + "'";
            }
            else
            {
                strSQL = @"insert into SEWC_IssueRepairOrder_Info(uRequestID, MLFB, SerialNo, Qty, Warranty, ReveiveBankReceipt, IsGoodWill, GoodWillNo,CancelReason, CancelDate, 
                        CreateDate, CreateUser,IssueRepairOrderDate, Repairble,isSubmit,CustomerConfirmDate,OrderType) values(";
                strSQL += "'" + sID + "','" + MLFB + "','" + SerialNo + "'," + Qty + ",'" + Warranty;
                strSQL += "'," + ReveiveBankReceipt + "," + IsGoodWill + ",'" + GoodWillNo + "','" + CancelReason + "'," + CancelDate + ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                strSQL += "','" + objUserInfo.UserID + "'," + IssueRepairOrderDate + ",'" + Repairble + "'," + isSubmit + "," + CustomerConfirmDate + ",'" + OrderType + "')";
            }

            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            if (strError == "")
            {
                if (Repairble.ToLower() == "n")
                {
                    strSQL = "update webInfo_serviceRequest_Info set serviceType='" + ServiceType + "', warranty='" + Warranty + "',isCancel=1 where ID='" + sID + "'";
                }
                else
                {
                    strSQL = "update webInfo_serviceRequest_Info set serviceType='" + ServiceType + "', warranty='" + Warranty + "' where ID='" + sID + "'";
                }
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
        }

        private void subDB_SendMail(HttpContext context)
        {
            string strSQL = "";
            string strError = "";

            string QuotationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string uRequestID = context.funString_RequestFormValue("uRequestID");

            subDB_Save_SendMail(context);

            strSQL = "update SEWC_IssueRepairOrder_Info set QuotationDate = '" + QuotationDate + "' where uRequestID = '" + uRequestID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            string Warranty = context.funString_RequestFormValue("Warranty");
            if (Warranty.ToString().Trim().ToLower() == "out warranty" || Warranty.ToString().Trim().ToLower() == "iw change to ow")
            {
                subDB_Save_SNC_Time(context);
            }

            string strTmp;
            List<string> aryAttachment = new List<string>();
            string strPath = "";
            if (strPath != "")
            {
                aryAttachment.Add(strPath);
            }

            ArrayList aryLst = new ArrayList();
            aryLst = funArrayList_SenderInfo();

            string strRequestID = "";
            strRequestID = funString_RequestID(uRequestID);

            string strEmail = "";
            strEmail = funString_CallCenterEMail();

            strTmp = Function.funString_SendMailByWebMail(aryLst[0].ToString(), aryLst[1].ToString(), aryLst[2].ToString(), "SEWC服务" + strRequestID + "请报维修价格", aryLst[3].ToString(), strEmail, "SEWC服务" + strRequestID + "请报维修价格", null, false, null, aryAttachment);

            if (strTmp == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_SendCancelMail(HttpContext context)
        {
            string strSQL = "";
            string strError = "";

            string uRequestID = context.funString_RequestFormValue("uRequestID");

            string strTmp;
            List<string> aryAttachment = new List<string>();
            string strPath = "";
            if (strPath != "")
            {
                aryAttachment.Add(strPath);
            }

            ArrayList aryLst = new ArrayList();
            aryLst = funArrayList_SenderInfo();

            string strRequestID = "";
            strRequestID = funString_RequestID(uRequestID);

            string strEmail = "";
            strEmail = funString_CallCenterEMail();

            strTmp =  Function.funString_SendMailByWebMail(aryLst[0].ToString(), aryLst[1].ToString(), aryLst[2].ToString(), "SEWC服务" + strRequestID + "服务已取消!", aryLst[3].ToString(), strEmail, "SEWC服务" + strRequestID + "服务已取消", null, false, null, aryAttachment);

            if (strTmp == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_SendTest(HttpContext context)
        {
            string strSQL = "";
            string strError = "";

            string QuotationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string uRequestID = context.funString_RequestFormValue("uRequestID");

            subDB_Save_SendMail(context);

            strSQL = "update SEWC_IssueRepairOrder_Info set QuotationDate = '" + QuotationDate + "' where uRequestID = '" + uRequestID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            string Warranty = context.funString_RequestFormValue("Warranty");
            if (Warranty.ToString().Trim().ToLower() == "out warranty" || Warranty.ToString().Trim().ToLower() == "iw change to ow")
            {
                subDB_Save_SNC_Time(context);
            }

            string strTmp;
            List<string> aryAttachment = new List<string>();
            string strPath = "";
            if (strPath != "")
            {
                aryAttachment.Add(strPath);
            }

            ArrayList aryLst = new ArrayList();
            aryLst = funArrayList_SenderInfo();

            string strRequestID = "";
            strRequestID = funString_RequestID(uRequestID);

            string strEmail = "";
            strEmail = funString_CallCenterEMail();

            strTmp = Function.funString_SendMailByWebMail(aryLst[0].ToString(), aryLst[1].ToString(), aryLst[2].ToString(), "SEWC服务" + strRequestID + "请报检测价格", aryLst[3].ToString(), strEmail, "SEWC服务" + strRequestID + "请报检测价格", null, false, null, aryAttachment);

            if (strTmp == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        //取得发件人的基本信息
        public ArrayList funArrayList_SenderInfo()
        {
            string strSQL = "select Email,EmailName,Password,SmtpServer from Public_Basic_SendEmail_Info";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

            string strAddress = ds.Tables[0].Rows[0]["Email"].ToString();
            string strName = ds.Tables[0].Rows[0]["EmailName"].ToString();
            string strPassword = ds.Tables[0].Rows[0]["Password"].ToString();
            string strSmtp = ds.Tables[0].Rows[0]["SmtpServer"].ToString();

            ArrayList aryLst = new ArrayList();
            aryLst.Add(strAddress);
            aryLst.Add(strName);
            aryLst.Add(strPassword);
            aryLst.Add(strSmtp);
            return aryLst;
        }

        //获得RequestID
        private string funString_RequestID(string uRequestID)
        {
            string strSQL = "";
            strSQL = "select RequestID from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";
            string strRequestID = "";
            strRequestID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            return strRequestID;
        }

        //获得CallCenterEMail
        private string funString_CallCenterEMail()
        {
            string strSQL = "";
            strSQL = "select CallCenterEMail from CallCenter_Basic_CallCenterEMail_Info where Type='sewc'";

            string strEmail = "";
            strEmail = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            return strEmail;
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