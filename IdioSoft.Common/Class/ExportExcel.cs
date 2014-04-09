using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using OfficeOpenXml;
using System.Web;

namespace IdioSoft.Common.Class
{
    public class ExportExcel
    {
        public enum ExcelType
        {
            CSV = 1,
            HTML = 2,
            Excel = 3
        }
        #region"用csv方式导出Excel,没有好看的样式"
        /// <summary>
        /// 用csv方式导出Excel,没有好看的样式
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="fileName">文件名</param>
        private void ExcelExportCsv(DataTable dt, string fileName)
        {
            StringBuilder swExcel = new StringBuilder();
            //写列头
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                swExcel.Append(funString_Excel(dt.Columns[i].ToString()).ToLower() + "\t");
            }
            swExcel.Append("\r\n");
            //写内容
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    if (dt.Rows[i].IsNull(j) == false)
                    {
                        swExcel.Append(funString_Excel(dt.Rows[i][j].ToString()) + "\t");
                    }
                    else
                    {
                        swExcel.Append("_" + "\t");
                    }
                }
                swExcel.Append("\r\n");
            }
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
            sw.Write(swExcel.ToString());
            fs.Close();
            sw.Close();
        }
        //这个过过程是为了防止导出数据中有","为分割
        private string funString_Excel(string strContent)
        {
            if (strContent != "")
            {
                strContent = strContent.Replace("\r\n", "");
                strContent = strContent.Replace("\t", " ");
            }
            if (strContent != "")
            {
                strContent = strContent.Replace(",", "，");
            }
            if (strContent != "")
            {
                strContent = strContent.Replace("\"", "");
            }
            return strContent;
        }
        #endregion
        #region "用html方式导出Excel"
        /// <summary>
        /// 用html方式导出Excel
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="fileName">文件名</param>
        private void ExcelExportHtml(DataTable dt, string fileName)
        {
            StringBuilder sbContent = new StringBuilder();

            //data += tb.TableName + "\n";
            sbContent.Append("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">");
            //写出列名
            sbContent.Append("<tr style=\"font-weight: bold; white-space: nowrap;\">");
            foreach (DataColumn column in dt.Columns)
            {
                sbContent.Append("<td>" + column.ColumnName + "</td>");
            }
            sbContent.Append("</tr>");

            //写出数据
            foreach (DataRow row in dt.Rows)
            {
                sbContent.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    switch (column.DataType.ToString().ToLower())
                    {
                        case "system.string":
                            sbContent.Append("<td>" + row[column].ToString() + "</td>");
                            break;
                        case "system.guid":
                            sbContent.Append("<td>" + row[column].ToString() + "</td>");
                            break;
                        case "system.datetime":
                            sbContent.Append("<td>" + row[column].ToString() + "</td>");
                            break;
                        case "system.decimal":
                            sbContent.Append("<td style=\"vnd.ms-excel.numberformat:@\">" + row[column].ToString() + "</td>");
                            break;
                        default:
                            sbContent.Append("<td>" + row[column].ToString() + "</td>");
                            break;
                    }
                }
                sbContent.Append("</tr>");
            }
            sbContent.Append("</table>");

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
            sw.Write(sbContent.ToString());
            fs.Close();
            sw.Close();
        }
        #endregion
        #region "导出真正的Excel"
        /// <summary>
        /// 导出真正的Excel
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strFileName">文件名</param>
        private void ExcelExportXls(DataTable dtSource, string strFileName)
        {
            HSSFWorkbook workbook;
            workbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet();

            //填充表头   
            NPOI.SS.UserModel.IRow dataRow = sheet.CreateRow(0);
            foreach (DataColumn column in dtSource.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }

            //填充内容   
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                }
            }
            if (File.Exists(strFileName))
            {
                try
                {
                    File.Delete(strFileName);
                }
                catch (Exception)
                {
                }
            }
            //保存   
            using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
            workbook.Dispose();
        }
        #endregion
        #region "导出成2007格式"
        public string ExcelExportXlsx(DataTable dtSource)
        {
            string xfileName = "" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string newFileName = HttpContext.Current.Server.MapPath("../../temp/" + xfileName);
            FileInfo newFile = new FileInfo(newFileName);

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Sheet1");

                //填充表头  
                for (int i = 0; i < dtSource.Columns.Count; i++) 
                {
                    worksheet.Cell(1, i + 1).Value = dtSource.Columns[i].Caption;
                }
                //填充内容   
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        worksheet.Cell(2 + i, j + 1).Value = dtSource.Rows[i][j].ToString();
                    }
                }
                
                xlPackage.Save();
            }
            return xfileName;
        }
        #endregion
        #region "保存文件"
        public string funString_SaveFile(string fileName, DataTable dt, ExcelType exType)
        {
            try
            {
                switch (exType)
                {
                    case ExcelType.CSV:
                        ExcelExportCsv(dt, fileName);
                        break;
                    case ExcelType.HTML:
                        ExcelExportHtml(dt, fileName);
                        break;
                    case ExcelType.Excel:
                        ExcelExportXls(dt, fileName);
                        break;
                }

            }
            catch
            {
                return "Error";
            }
            return "";
        }
        #endregion
    }
}
