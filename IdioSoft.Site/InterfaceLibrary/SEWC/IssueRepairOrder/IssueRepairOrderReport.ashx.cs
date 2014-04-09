using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.IO;
using OfficeOpenXml;
using IdioSoft.Business.Method;
namespace IdioSoft.Site.InterfaceLibrary.SEWC.IssueRepairOrder
{
    /// <summary>
    /// Summary description for IssueRepairOrderReport
    /// </summary>
    public class IssueRepairOrderReport : ICHttpHandler
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
                strSQL = @"select RequestID,MLFB,SerialNo,Warranty,SEWCNotificationNo,TroubleDesc,[FuntinalStateoriginal],[Firmwareoriginal],OrderType from View_SEWC_IssueRepairOrder_Info where uRequestID = '" + uRequestID + "'";
                DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    worksheet.Cell(4, 3).Value = ds.Tables[0].Rows[0]["RequestID"].ToString();

                    worksheet.Cell(5, 3).Value = ds.Tables[0].Rows[0]["SEWCNotificationNo"].ToString();

                    worksheet.Cell(5, 6).Value = ds.Tables[0].Rows[0]["OrderType"].ToString();


                    worksheet.Cell(8, 3).Value = ds.Tables[0].Rows[0]["MLFB"].ToString();

                    worksheet.Cell(9, 3).Value = ds.Tables[0].Rows[0]["SerialNo"].ToString();


                    worksheet.Cell(8,6).Value = ds.Tables[0].Rows[0]["FuntinalStateoriginal"].ToString();

                    worksheet.Cell(9,6).Value = ds.Tables[0].Rows[0]["Firmwareoriginal"].ToString();

                    worksheet.Cell(10, 3).Value = ds.Tables[0].Rows[0]["TroubleDesc"].ToString();

                    worksheet.Cell(13, 3).Value = ds.Tables[0].Rows[0]["Warranty"].ToString();
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