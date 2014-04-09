using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using OfficeOpenXml;

using System.Xml;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Report
{
    /// <summary>
    /// Summary description for wsReport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsReport : System.Web.Services.WebService
    {
        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string doLUReport(string StartDate, string EndDate)
        {
            string strSQL = @"SELECT d.DeliveryDate, d.issueDNDate, s.ProductDesc, s.ServiceType, d.MLFB, d.SerialNo, d.NewSerialNo, d.Qty, d.TrackingNo, d.Warranty, s.RequestID
FROM            dbo.SEWC_Delivery_Info AS d INNER JOIN
                         dbo.webInfo_ServiceRequest_Info AS s ON d.uRequestID = s.ID where  d.DeliveryDate>='" + StartDate + "' and   d.DeliveryDate<='" + EndDate + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            string xfileName = "";
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    xfileName = "LUreport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/LUreportTemplate.xlsx");
                    string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
                    FileInfo newFile = new FileInfo(newFileName);
                    FileInfo template = new FileInfo(strTemplateName);
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Sheet1"];
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            worksheet.Cell(3 + i, 1).Value = (i + 1).ToString();
                            worksheet.Cell(3 + i, 2).Value = ds.Tables[0].Rows[i]["RequestID"].ToString();
                            worksheet.Cell(3 + i, 3).Value = ds.Tables[0].Rows[i]["DeliveryDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cell(3 + i, 4).Value = ds.Tables[0].Rows[i]["issueDNDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");  
                            worksheet.Cell(3 + i, 5).Value = ds.Tables[0].Rows[i]["ProductDesc"].ToString();
                            worksheet.Cell(3 + i, 6).Value = ds.Tables[0].Rows[i]["ServiceType"].ToString();
                            worksheet.Cell(3 + i, 7).Value = ds.Tables[0].Rows[i]["MLFB"].ToString();
                            worksheet.Cell(3 + i, 8).Value = ds.Tables[0].Rows[i]["SerialNo"].ToString();
                            worksheet.Cell(3 + i, 9).Value = ds.Tables[0].Rows[i]["NewSerialNo"].ToString();
                            worksheet.Cell(3 + i, 10).Value = ds.Tables[0].Rows[i]["Qty"].ToString();
                            worksheet.Cell(3 + i, 11).Value = ds.Tables[0].Rows[i]["TrackingNo"].ToString()+" ";
                            worksheet.Cell(3 + i, 12).Value = ds.Tables[0].Rows[i]["Warranty"].ToString();
                        }

                        xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                        xlPackage.Save();
                    }
                }
                catch
                {
                    xfileName = "";
                }
            }
            return xfileName;
        }

        [WebMethod]
        public string doPUReport(string StartDate, string EndDate)
        {
            string strSQL = @"SELECT        TOP (100) PERCENT s.RequestID, s.ProductDesc, s.MLFBNo, s.SerialNo, s.TroubleDesc, iu.ProductDate, s.CaseTime, r.FailureCasedType, ri.ComponentLocation, ri.PCBA5ENo, ri.FCode, ri.RepairAction, 
                         iu.IssueRepairOrderDate, r.EndRepairDate, r.Engineer, r.WorkStationCode, g.SEWCNotificationNo, s.ServiceType, s.Warranty, s.AppCompanyName, iu.OrderType, r.RepairResult, r.LaborCost, 
                         ri.RepairedComponentA5E
FROM            dbo.webInfo_ServiceRequest_Info AS s INNER JOIN
                         dbo.SEWC_IssueRepairOrder_Info AS iu ON s.ID = iu.uRequestID INNER JOIN
                         dbo.SEWC_Repair_Info AS r ON s.ID = r.uRequestID INNER JOIN
                         dbo.SEWC_Delivery_Info AS d ON s.ID = d.uRequestID LEFT OUTER JOIN
                         dbo.SEWC_GoodsReceipt_Info AS g ON s.ID = g.uRequestID LEFT OUTER JOIN
                         dbo.SEWC_RepairItem_Info AS ri ON s.ID = ri.uRequestID 
 where  d.DeliveryDate>='" + StartDate + "' and   d.DeliveryDate<='" + EndDate + "' ORDER BY  d.DeliveryDate, ri.rowIndex ";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            string xfileName = "";
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    xfileName = "PUreport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/PUReportTemplate.xlsx");
                    string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
                    FileInfo newFile = new FileInfo(newFileName);
                    FileInfo template = new FileInfo(strTemplateName);
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                    {
                        string RequestID = "";
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Sheet1"];
                        int intRow = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (RequestID != ds.Tables[0].Rows[i]["RequestID"].ToString())
                            {
                                worksheet.Cell(2 + i, 1).Value = (++intRow).ToString();
                                worksheet.Cell(2 + i, 2).Value = ds.Tables[0].Rows[i]["RequestID"].ToString();
                                worksheet.Cell(2 + i, 3).Value = ds.Tables[0].Rows[i]["ProductDesc"].ToString();
                                worksheet.Cell(2 + i, 4).Value = ds.Tables[0].Rows[i]["MLFBNo"].ToString();
                                worksheet.Cell(2 + i, 5).Value = ds.Tables[0].Rows[i]["SerialNo"].ToString();
                                worksheet.Cell(2 + i, 6).Value = ds.Tables[0].Rows[i]["TroubleDesc"].ToString();
                                worksheet.Cell(2 + i, 7).Value = ds.Tables[0].Rows[i]["ProductDate"].ToString();
                                worksheet.Cell(2 + i, 8).Value = ds.Tables[0].Rows[i]["CaseTime"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 

                            }

                            worksheet.Cell(2 + i, 9).Value = ds.Tables[0].Rows[i]["FailureCasedType"].ToString();
                            worksheet.Cell(2 + i, 10).Value = ds.Tables[0].Rows[i]["PCBA5ENo"].ToString();
                            worksheet.Cell(2 + i, 11).Value = ds.Tables[0].Rows[i]["ComponentLocation"].ToString();
                            worksheet.Cell(2 + i, 12).Value = ds.Tables[0].Rows[i]["RepairedComponentA5E"].ToString();
                            worksheet.Cell(2 + i, 13).Value = ds.Tables[0].Rows[i]["FCode"].ToString();
                            worksheet.Cell(2 + i, 14).Value = ds.Tables[0].Rows[i]["RepairAction"].ToString();

                            if (RequestID != ds.Tables[0].Rows[i]["RequestID"].ToString())
                            {
                                worksheet.Cell(2 + i, 15).Value = ds.Tables[0].Rows[i]["IssueRepairOrderDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(2 + i, 16).Value = ds.Tables[0].Rows[i]["EndRepairDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                                worksheet.Cell(2 + i, 17).Value = ds.Tables[0].Rows[i]["Engineer"].ToString();
                                worksheet.Cell(2 + i, 18).Value = ds.Tables[0].Rows[i]["WorkStationCode"].ToString();
                                worksheet.Cell(2 + i, 19).Value = ds.Tables[0].Rows[i]["SEWCNotificationNo"].ToString();
                                worksheet.Cell(2 + i, 20).Value = ds.Tables[0].Rows[i]["ServiceType"].ToString();
                                worksheet.Cell(2 + i, 21).Value = ds.Tables[0].Rows[i]["Warranty"].ToString();
                                worksheet.Cell(2 + i, 22).Value = ds.Tables[0].Rows[i]["AppCompanyName"].ToString();
                                worksheet.Cell(2 + i, 23).Value = ds.Tables[0].Rows[i]["OrderType"].ToString();
                                worksheet.Cell(2 + i, 24).Value = ds.Tables[0].Rows[i]["RepairResult"].ToString();
                                worksheet.Cell(2 + i, 25).Value = ds.Tables[0].Rows[i]["LaborCost"].ToString();
                            }
                            RequestID = ds.Tables[0].Rows[i]["RequestID"].ToString();
                        }

                        xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                        xlPackage.Save();
                    }
                }
                catch
                {
                    xfileName = "";
                }
            }
            return xfileName;
        }

        [WebMethod]
        public string doQAFMSReport(string StartDate, string EndDate)
        {
            List<object> lst = new List<object>();
            lst.Add(StartDate);
            lst.Add(EndDate);
            DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, "sp_Sewc_QAFMS_Report");
            string xfileName = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    xfileName = "QAFMSReport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/QAFMSreportTemplate.xlsx");
                    string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
                    FileInfo newFile = new FileInfo(newFileName);
                    FileInfo template = new FileInfo(strTemplateName);
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["explain"];
                        int intRow = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ++intRow;
                            worksheet.Cell(2 + i, 1).Value = dt.Rows[i]["FactoryOforigin"].ToString();
                            worksheet.Cell(2 + i, 2).Value = dt.Rows[i]["RequestID"].ToString();
                            worksheet.Cell(2 + i, 3).Value = "1";
                            worksheet.Cell(2 + i, 4).Value = dt.Rows[i]["Qty"].ToString();
                            worksheet.Cell(2 + i, 5).Value = dt.Rows[i]["t3"].ToString().funString_StringToDatetimeBlank("dd.MM.yyyy") + " ";

                            worksheet.Cell(2 + i, 6).Value = dt.Rows[i]["ProductDesc"].ToString();
                            worksheet.Cell(2 + i, 7).Value = dt.Rows[i]["MLFB"].ToString();
                            worksheet.Cell(2 + i, 8).Value = dt.Rows[i]["FuntinalStateOriginal"].ToString();
                            worksheet.Cell(2 + i, 9).Value = dt.Rows[i]["SerialNo"].ToString();
                            worksheet.Cell(2 + i, 10).Value = dt.Rows[i]["ProductDate"].ToString();

                            worksheet.Cell(2 + i, 11).Value = dt.Rows[i]["FailureCasedType"].ToString();
                            worksheet.Cell(2 + i, 12).Value = dt.Rows[i]["Fcode1"].ToString();
                            worksheet.Cell(2 + i, 13).Value = dt.Rows[i]["Fcode2"].ToString();
                            worksheet.Cell(2 + i, 14).Value = dt.Rows[i]["FailureKind"].ToString();
                            worksheet.Cell(2 + i, 15).Value = dt.Rows[i]["ComponentLocation1"].ToString();
                            worksheet.Cell(2 + i, 16).Value = dt.Rows[i]["ComponentLocation2"].ToString();

                            worksheet.Cell(2 + i, 17).Value = dt.Rows[i]["Warranty"].ToString();
                            worksheet.Cell(2 + i, 18).Value = dt.Rows[i]["RepairResult"].ToString();
                            worksheet.Cell(2 + i, 19).Value = dt.Rows[i]["CustomerName"].ToString();
                            worksheet.Cell(2 + i, 20).Value = dt.Rows[i]["Country"].ToString();
                            worksheet.Cell(2 + i, 21).Value = dt.Rows[i]["Remarks"].ToString();
                            worksheet.Cell(2 + i, 22).Value = dt.Rows[i]["RepairCounts"].ToString();

                        }

                        xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                        xlPackage.Save();
                    }
                }
                catch
                {
                    xfileName = "";
                }
            }
            return xfileName;

        }


        [WebMethod]
        public string doQAKPIInvoiceReport(string StartDate, string EndDate)
        {
            string xfileName = "";
            try
            {
                xfileName = "QAKPIInvociereport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/QAKPIInvociereportTemplate.xlsx");
                string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
                FileInfo newFile = new FileInfo(newFileName);
                FileInfo template = new FileInfo(strTemplateName);
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    List<object> lst = new List<object>();
                    lst.Add(StartDate);
                    lst.Add(EndDate);
                    DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, "sp_Sewc_QAKPI_SummaryReport");
                    string RequestID = "";
                    ExcelWorksheet worksheet = null;
                    int intRow = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        worksheet = xlPackage.Workbook.Worksheets["Summary"];
                        #region "Summary"
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (RequestID != dt.Rows[i]["RequestID"].ToString())
                            {
                                worksheet.Cell(2 + i, 1).Value = (++intRow).ToString();
                                worksheet.Cell(2 + i, 2).Value = dt.Rows[i]["FactoryOforigin"].ToString();
                                worksheet.Cell(2 + i, 3).Value = dt.Rows[i]["RequestID"].ToString();
                                worksheet.Cell(2 + i, 4).Value = dt.Rows[i]["ServiceType"].ToString();
                                worksheet.Cell(2 + i, 5).Value = dt.Rows[i]["Area"].ToString();
                                worksheet.Cell(2 + i, 6).Value = dt.Rows[i]["Warranty"].ToString();
                                worksheet.Cell(2 + i, 7).Value = dt.Rows[i]["IsRepeat"].ToString();
                                worksheet.Cell(2 + i, 8).Value = dt.Rows[i]["MLFB"].ToString();
                                worksheet.Cell(2 + i, 9).Value = dt.Rows[i]["SerialNo"].ToString();
                                worksheet.Cell(2 + i, 10).Value = dt.Rows[i]["ProductDesc"].ToString();
                                worksheet.Cell(2 + i, 11).Value = dt.Rows[i]["Qty"].ToString();
                                worksheet.Cell(2 + i, 12).Value = dt.Rows[i]["TroubleDesc"].ToString();
                                worksheet.Cell(2 + i, 13).Value = dt.Rows[i]["appcompanyname"].ToString();

                                worksheet.Cell(2 + i, 14).Value = dt.Rows[i]["Country"].ToString();
                                worksheet.Cell(2 + i, 15).Value = dt.Rows[i]["ReceiveCompany"].ToString();
                                worksheet.Cell(2 + i, 16).Value = dt.Rows[i]["CaseTime"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(2 + i, 17).Value = dt.Rows[i]["T3"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                                worksheet.Cell(2 + i, 18).Value = dt.Rows[i]["FuntinalStateOriginal"].ToString();
                                worksheet.Cell(2 + i, 19).Value = dt.Rows[i]["SEWCNotificationNo"].ToString();
                                worksheet.Cell(2 + i, 20).Value = dt.Rows[i]["IsGoodWill"].ToString();
                                worksheet.Cell(2 + i, 21).Value = dt.Rows[i]["GoodWillNo"].ToString();
                                worksheet.Cell(2 + i, 22).Value = dt.Rows[i]["CustomerConfirmDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(2 + i, 23).Value = dt.Rows[i]["IssueRepairOrderDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(2 + i, 24).Value = dt.Rows[i]["OrderType"].ToString();
                                worksheet.Cell(2 + i, 25).Value = dt.Rows[i]["WorkStationCode"].ToString();

                                worksheet.Cell(2 + i, 26).Value = dt.Rows[i]["FuntinalStatelatest"].ToString();
                                worksheet.Cell(2 + i, 27).Value = dt.Rows[i]["ConfirmCompleteDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(2 + i, 28).Value = dt.Rows[i]["EndRepairDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                                worksheet.Cell(2 + i, 29).Value = dt.Rows[i]["ProductDate"].ToString();
                                worksheet.Cell(2 + i, 30).Value = dt.Rows[i]["Engineer"].ToString();
                                worksheet.Cell(2 + i, 31).Value = dt.Rows[i]["FailureCasedType"].ToString();
                                worksheet.Cell(2 + i, 32).Value = dt.Rows[i]["RepairResult"].ToString();
                            }
                            worksheet.Cell(2 + i, 33).Value = dt.Rows[i]["PCBA5ENo"].ToString();

                            worksheet.Cell(2 + i, 34).Value = dt.Rows[i]["ComponentLocation"].ToString();
                            worksheet.Cell(2 + i, 35).Value = dt.Rows[i]["RepairedComponentA5E"].ToString();
                            worksheet.Cell(2 + i, 36).Value = dt.Rows[i]["FCode"].ToString();
                            worksheet.Cell(2 + i, 37).Value = dt.Rows[i]["RepairAction"].ToString();

                            if (RequestID != dt.Rows[i]["RequestID"].ToString())
                            {
                                worksheet.Cell(2 + i, 38).Value = dt.Rows[i]["issueDNDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); ;
                                worksheet.Cell(2 + i, 39).Value = dt.Rows[i]["TrackingNo"].ToString() + " ";
                                worksheet.Cell(2 + i, 20).Value = dt.Rows[i]["WeightUnit"].ToString();
                                worksheet.Cell(2 + i, 41).Value = dt.Rows[i]["DeliveryDate"].ToString();
                                worksheet.Cell(2 + i, 42).Value = dt.Rows[i]["LaborCost"].ToString();
                            }
                            RequestID = dt.Rows[i]["RequestID"].ToString();
                        }
                        #endregion
                    }
                    #region "OW repair price"
                    intRow = 0;
                    dt = null;
                    worksheet = xlPackage.Workbook.Worksheets["OW repair price"];
                    lst = new List<object>();
                    lst.Add(StartDate);
                    lst.Add(EndDate);
                    dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, "sp_Sewc_QAKPI_OWrepairpriceRepor");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            worksheet.Cell(3 + i, 1).Value = (++intRow).ToString();
                            worksheet.Cell(3 + i, 2).Value = dt.Rows[i]["ProductDesc"].ToString();
                            worksheet.Cell(3 + i, 3).Value = dt.Rows[i]["RequestID"].ToString();
                            worksheet.Cell(3 + i, 4).Value = dt.Rows[i]["AppCompanyName"].ToString();
                            worksheet.Cell(3 + i, 5).Value = dt.Rows[i]["T3"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(3 + i, 6).Value = dt.Rows[i]["MLFB"].ToString();
                            worksheet.Cell(3 + i, 7).Value = dt.Rows[i]["Qty"].ToString();
                            worksheet.Cell(3 + i, 8).Value = dt.Rows[i]["SerialNo"].ToString();
                            worksheet.Cell(3 + i, 9).Value = dt.Rows[i]["DeliveryDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(3 + i, 10).Value = dt.Rows[i]["Repairprice"].ToString();
                            worksheet.Cell(3 + i, 11).Value = dt.Rows[i]["Warranty"].ToString();
                        }
                    }
                    #endregion

                    #region "IW handling fee"
                    intRow = 0;
                    dt = null;
                    worksheet = xlPackage.Workbook.Worksheets["IW handling fee"];
                    lst = new List<object>();
                    lst.Add(StartDate);
                    lst.Add(EndDate);
                    dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, "sp_sewc_QAKPI_IWhandlingfee");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            worksheet.Cell(3 + i, 1).Value = (++intRow).ToString();
                            worksheet.Cell(3 + i, 2).Value = dt.Rows[i]["ProductDesc"].ToString();
                            worksheet.Cell(3 + i, 3).Value = dt.Rows[i]["RequestID"].ToString();
                            worksheet.Cell(3 + i, 4).Value = dt.Rows[i]["AppCompanyName"].ToString();
                            worksheet.Cell(3 + i, 5).Value = dt.Rows[i]["CaseTime"].ToString();
                            worksheet.Cell(3 + i, 6).Value = dt.Rows[i]["T3"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(3 + i, 7).Value = dt.Rows[i]["MLFB"].ToString();
                            worksheet.Cell(3 + i, 8).Value = dt.Rows[i]["Qty"].ToString();
                            worksheet.Cell(3 + i, 9).Value = dt.Rows[i]["SerialNo"].ToString();
                            worksheet.Cell(3 + i, 10).Value = dt.Rows[i]["DeliveryDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(3 + i, 11).Value = dt.Rows[i]["Warranty"].ToString();
                            worksheet.Cell(3 + i, 12).Value = dt.Rows[i]["GoodWillNo"].ToString();
                        }
                    }
                    #endregion

                    #region "KPI report"
                    intRow = 0;
                    dt = null;
                    worksheet = xlPackage.Workbook.Worksheets["KPI report"];
                    lst = new List<object>();
                    lst.Add(StartDate);
                    lst.Add(EndDate);
                    dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, "sp_Sewc_QAKPI_KPIreport");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            worksheet.Cell(2 + i, 1).Value = (++intRow).ToString();
                            worksheet.Cell(2 + i, 2).Value = dt.Rows[i]["FactoryOforigin"].ToString();
                            worksheet.Cell(2 + i, 3).Value = dt.Rows[i]["NotificationNo"].ToString();
                            worksheet.Cell(2 + i, 4).Value = dt.Rows[i]["ServiceType"].ToString();
                            worksheet.Cell(2 + i, 5).Value = dt.Rows[i]["Area"].ToString();
                            worksheet.Cell(2 + i, 6).Value = dt.Rows[i]["Warranty"].ToString();
                            worksheet.Cell(2 + i, 7).Value = dt.Rows[i]["IsRepeat"].ToString();
                            worksheet.Cell(2 + i, 8).Value = dt.Rows[i]["MLFB"].ToString();
                            worksheet.Cell(2 + i, 9).Value = dt.Rows[i]["SerialNo"].ToString();
                            worksheet.Cell(2 + i, 10).Value = dt.Rows[i]["ProductDesc"].ToString();
                            worksheet.Cell(2 + i, 11).Value = dt.Rows[i]["Qty"].ToString();
                            worksheet.Cell(2 + i, 12).Value = dt.Rows[i]["CaseTime"].ToString().funDateTime_StringToDatetime().ToString("yyyy-MM-dd HH:mm:ss");

                            worksheet.Cell(2 + i, 13).Value = dt.Rows[i]["T3"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(2 + i, 14).Value = dt.Rows[i]["SEWCNotificationNo"].ToString();
                            worksheet.Cell(2 + i, 15).Value = dt.Rows[i]["IsGoodWill"].ToString();
                            worksheet.Cell(2 + i, 16).Value = dt.Rows[i]["GoodWillNo"].ToString();
                            worksheet.Cell(2 + i, 17).Value = dt.Rows[i]["CustomerConfirmDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cell(2 + i, 18).Value = dt.Rows[i]["IssueRepairOrderDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 
                            worksheet.Cell(2 + i, 19).Value = dt.Rows[i]["OrderType"].ToString();
                            worksheet.Cell(2 + i, 20).Value = dt.Rows[i]["ConfirmCompleteDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cell(2 + i, 21).Value = dt.Rows[i]["EndRepairDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 

                            worksheet.Cell(2 + i, 22).Value = dt.Rows[i]["FailureCasedType"].ToString();
                            worksheet.Cell(2 + i, 23).Value = dt.Rows[i]["RepairResult"].ToString();
                            worksheet.Cell(2 + i, 24).Value = dt.Rows[i]["issueDNDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cell(2 + i, 25).Value = dt.Rows[i]["DeliveryDate"].ToString().funString_StringToDatetimeBlank("yyyy-MM-dd HH:mm:ss"); 

                        }
                    }
                    #endregion
                    xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                    xlPackage.Save();
                }
            }
            catch
            {
                xfileName = "";
            }

            return xfileName;
        }
        [WebMethod]
        public string doGoodwillReport(string StartDate, string EndDate)
        {
            string xfileName = "";
            try
            {
                xfileName = "GoodWill_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/GoodWillTemplate.xlsx");
                string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
                FileInfo newFile = new FileInfo(newFileName);
                FileInfo template = new FileInfo(strTemplateName);
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    string strSQL = @"SELECT g.GWGTNo, g.BUContactPerson, g.SRNo, g.CompanyName, g.AppCompanyName, g.ConfirmDate, g.GBK, g.BUCoversGuarantees, g.ConfirmReason, 
                         g.Decision, l.EnUserName
FROM            dbo.GoodWill_MainInfo AS g INNER JOIN
                         dbo.webInfo_ServiceRequest_Info AS s ON g.uRequestID = s.ID INNER JOIN
                         dbo.webInfo_loginInfo AS l ON g.CreateUserID = l.ID
WHERE        (s.ServiceProvider = N'sewc') AND (g.Decision = N'confirm') and g.ConfirmDate>='" + StartDate + "' and  g.ConfirmDate<='" + EndDate + "'";
                    DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                    ExcelWorksheet worksheet = null;
                    int intRow = 0;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        worksheet = xlPackage.Workbook.Worksheets["Sheet1"];
                        #region "Goodwill"
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            worksheet.Cell(2 + i, 1).Value = (intRow++).ToString();
                            worksheet.Cell(2 + i, 2).Value = ds.Tables[0].Rows[i]["EnUserName"].ToString();
                            worksheet.Cell(2 + i, 3).Value = ds.Tables[0].Rows[i]["GWGTNo"].ToString();
                            worksheet.Cell(2 + i, 4).Value = ds.Tables[0].Rows[i]["SRNo"].ToString();
                            worksheet.Cell(2 + i, 5).Value = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                            worksheet.Cell(2 + i, 6).Value = ds.Tables[0].Rows[i]["AppCompanyName"].ToString();
                            worksheet.Cell(2 + i, 7).Value = ds.Tables[0].Rows[i]["ConfirmReason"].ToString();
                            worksheet.Cell(2 + i, 8).Value = ds.Tables[0].Rows[i]["EnUserName"].ToString();
                            worksheet.Cell(2 + i, 9).Value = ds.Tables[0].Rows[i]["BUContactPerson"].ToString();
                            worksheet.Cell(2 + i, 10).Value = ds.Tables[0].Rows[i]["ConfirmDate"].ToString();
                            worksheet.Cell(2 + i, 11).Value = ds.Tables[0].Rows[i]["GBK"].ToString();
                            worksheet.Cell(2 + i, 12).Value = ds.Tables[0].Rows[i]["BUCoversGuarantees"].ToString();
                        }
                        #endregion
                    }
                    xlPackage.Workbook.CalcMode = ExcelCalcMode.Automatic;
                    xlPackage.Save();
                }
            }
            catch
            {
                xfileName = "";
            }

            return xfileName;
        }
    }
}
