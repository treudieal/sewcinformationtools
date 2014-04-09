using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.IO;
using OfficeOpenXml;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Repair
{
    /// <summary>
    /// Summary description for RepairReport
    /// </summary>
    public class RepairReport : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string uRequestID = "";
            uRequestID = context.funString_RequestFormValue("uRequestID");

            string strTemplateName = HttpContext.Current.Server.MapPath("../../../Template/SEWC/RepairTemplate.xlsx");
            string xfileName = "SEWC_Repair" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string newFileName = HttpContext.Current.Server.MapPath("../../../temp/" + xfileName);
            FileInfo newFile = new FileInfo(newFileName);
            FileInfo template = new FileInfo(strTemplateName);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Sheet1"];
                strSQL = @"SELECT     RequestID, MLFB, SerialNo, Warranty, WorkStationCode, SEWCNotificationNo, [FuntinalStateoriginal], [FuntinalStatelatest], [Firmwareoriginal], [Firmwarelatest], Remarks, RepairResult, 
                      ConfirmCompleteDate, TroubleDesc, EndRepairDate, OrderType, Engineer,FailureCasedType
FROM         dbo.View_SEWC_Repair_ReportInfo where uRequestID = '" + uRequestID + "'";
                DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    worksheet.Cell(4, 3).Value = ds.Tables[0].Rows[0]["RequestID"].ToString();
                    worksheet.Cell(4, 6).Value = ds.Tables[0].Rows[0]["WorkStationCode"].ToString();

                    worksheet.Cell(5, 3).Value = ds.Tables[0].Rows[0]["SEWCNotificationNo"].ToString();
                    worksheet.Cell(5, 6).Value = ds.Tables[0].Rows[0]["OrderType"].ToString();

                    worksheet.Cell(8, 3).Value = ds.Tables[0].Rows[0]["MLFB"].ToString();
                    worksheet.Cell(8, 6).Value = ds.Tables[0].Rows[0]["FuntinalStateoriginal"].ToString();
                    worksheet.Cell(8, 8).Value = ds.Tables[0].Rows[0]["FuntinalStatelatest"].ToString();

                    worksheet.Cell(9, 3).Value = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                    worksheet.Cell(9, 6).Value = ds.Tables[0].Rows[0]["Firmwareoriginal"].ToString();
                    worksheet.Cell(9, 8).Value = ds.Tables[0].Rows[0]["Firmwarelatest"].ToString();

                    worksheet.Cell(10, 3).Value = ds.Tables[0].Rows[0]["TroubleDesc"].ToString();

                    worksheet.Cell(13, 3).Value = ds.Tables[0].Rows[0]["Warranty"].ToString();
                    string ConfirmCompleteDate = "";
                    ConfirmCompleteDate = ds.Tables[0].Rows[0]["ConfirmCompleteDate"].ToString();
                    if (ConfirmCompleteDate != "")
                    {
                        ConfirmCompleteDate = ConfirmCompleteDate.funDateTime_StringToDatetime().ToShortDateString();
                    }
                    worksheet.Cell(13, 6).Value = ConfirmCompleteDate;

                    strSQL = @"SELECT ID, uRequestID, PCBA5ENo, ComponentLocation, RepairedComponentA5E, Type, FailureKind, FCode, FailureCasedType, RepairAction, rowIndex
FROM            dbo.SEWC_RepairItem_Info where uRequestID = '" + uRequestID + "' order by rowindex";
                    DataSet dsItem = new DataSet();
                    dsItem = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                        {
                            worksheet.Cell(17 + i, 2).Value = dsItem.Tables[0].Rows[i]["PCBA5ENo"].ToString();
                            worksheet.Cell(17 + i, 3).Value = dsItem.Tables[0].Rows[i]["ComponentLocation"].ToString();
                            worksheet.Cell(17 + i, 4).Value = dsItem.Tables[0].Rows[i]["RepairedComponentA5E"].ToString();
                            worksheet.Cell(17 + i, 5).Value = dsItem.Tables[0].Rows[i]["Type"].ToString();
                            worksheet.Cell(17 + i, 6).Value = dsItem.Tables[0].Rows[i]["FCode"].ToString();

                            worksheet.Cell(17 + i, 7).Value = dsItem.Tables[0].Rows[i]["FailureKind"].ToString();
                            worksheet.Cell(17 + i, 8).Value = dsItem.Tables[0].Rows[i]["RepairAction"].ToString();
 
                        }
                    }

                    worksheet.Cell(26, 3).Value = ds.Tables[0].Rows[0]["RepairResult"].ToString();

                    worksheet.Cell(26, 5).Value = ds.Tables[0].Rows[0]["FailureCasedType"].ToString();

                    worksheet.Cell(28, 2).Value = ds.Tables[0].Rows[0]["Remarks"].ToString();

                    worksheet.Cell(33, 3).Value = ds.Tables[0].Rows[0]["Engineer"].ToString();
                    string EndRepairDate = "";
                    EndRepairDate = ds.Tables[0].Rows[0]["EndRepairDate"].ToString();
                    if (EndRepairDate != "")
                    {
                        EndRepairDate = EndRepairDate.funDateTime_StringToDatetime().ToShortDateString();
                    }
                    worksheet.Cell(33, 6).Value = EndRepairDate;
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