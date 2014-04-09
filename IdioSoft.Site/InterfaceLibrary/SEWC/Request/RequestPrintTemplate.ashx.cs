using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.Text;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for RequestPrintTemplate
    /// </summary>
    public class RequestPrintTemplate : ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string TempText = context.Server.UrlDecode(context.funString_RequestFormValue("TempText"));
            string TempValue = context.Server.UrlDecode(context.funString_RequestFormValue("TempValue"));
            string uRequestID = context.Server.UrlDecode(context.funString_RequestFormValue("uRequestID"));
            string strFileName;
            strFileName = subCreate_ServiceRequestWord(TempText, TempValue,uRequestID);

            if (strFileName != "")
            {
                context.Response.Write(strFileName);//成功
            }
            else
            {
                context.Response.Write("");//失败
            }
            context.Response.End();
        }

        #region "建立Internal MT SR Form Word文件"
        private string funString_MCMTWord(string strTemplateName, string strTemplateFullPath, string uRequestID)
        {
            StringBuilder strBWord = new StringBuilder();
            strBWord = Function.funStringBuilder_WordXMLToStringBuilder(strTemplateFullPath);

            if (strTemplateName.ToLower() == "Internal MT SR Form.xml".ToLower())
            {
                string strSQL = "";
                strSQL = @"select NotificationNo,AppCompanyName,AppContactName,SalesName,AppTel,AppMobile,AppFax,EnduserCompanyName,EnduserAddress,EnduserPostCode,
                        EnduserContactName,EnduserTel,EnduserMobile,EnduserFax,MachineManufacturer,manuAddress,manuZipCode,manuContactor,manuTel,manuFax,
                        TypeOfMachine,MachineSerialNo,ControllerType,DriverType,SoftwareVersion,RSVNO,Warranty,CaseTime,TroubleDesc,LocalRSCNo,ContractNo,MCMTMainMLFB,Text from webInfo_ServiceRequest_Info where ID='" + uRequestID + "'";
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                #region "获得替换的值"
                string strNotificationNo = "";
                string strAppCompanyName = "";
                string strAppContactName = "";
                string strAppTel = "";
                string strAppFax = "";
                string strEnduserCompanyName = "";
                string strEnduserAddress = "";
                string strEnduserPostCode = "";
                string strEnduserContactName = "";
                string strEnduserTel = "";
                string strEnduserFax = "";
                string strMachineManufacturer = "";
                string strmanuAddress = "";
                string strmanuZipCode = "";
                string strmanuContactor = "";
                string strmanuTel = "";
                string strmanuFax = "";
                string strTypeOfMachine = "";
                string strMachineSerialNo = "";
                string strControllerType = "";
                string strDriverType = "";
                string strSoftwareVersion = "";
                string strMLFB = "";
                string strSerialNo = "";
                string strRSCNo = "";
                string strCaseTime = "";
                string strTroubleDesc = "";
                string strLocalRSCNo = "";
                string strContractNo = "";
                string strMCMTMainMLFB = "";
                string strText = "";
                #endregion
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    strNotificationNo = ds.Tables[0].Rows[0]["NotificationNo"].ToString();
                    strNotificationNo = Function.funString_StringToXML(strNotificationNo);
                    strAppCompanyName = ds.Tables[0].Rows[0]["AppCompanyName"].ToString();
                    strAppCompanyName = Function.funString_StringToXML(strAppCompanyName);
                    if (ds.Tables[0].Rows[0]["AppContactName"].ToString().Trim() == "")
                    {
                        strAppContactName = ds.Tables[0].Rows[0]["SalesName"].ToString().Trim();
                        strAppContactName = Function.funString_StringToXML(strAppContactName);
                    }
                    if (ds.Tables[0].Rows[0]["SalesName"].ToString().Trim() == "")
                    {
                        strAppContactName = ds.Tables[0].Rows[0]["AppContactName"].ToString().Trim();
                        strAppContactName = Function.funString_StringToXML(strAppContactName);
                    }
                    if (ds.Tables[0].Rows[0]["AppContactName"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["SalesName"].ToString().Trim() != "")
                    {
                        strAppContactName = ds.Tables[0].Rows[0]["AppContactName"].ToString().Trim() + "/" + ds.Tables[0].Rows[0]["SalesName"].ToString().Trim();
                        strAppContactName = Function.funString_StringToXML(strAppContactName);
                    }
                    if (ds.Tables[0].Rows[0]["AppTel"].ToString().Trim() == "")
                    {
                        strAppTel = ds.Tables[0].Rows[0]["AppMobile"].ToString().Trim();
                        strAppTel = Function.funString_StringToXML(strAppTel);
                    }
                    if (ds.Tables[0].Rows[0]["AppMobile"].ToString().Trim() == "")
                    {
                        strAppTel = ds.Tables[0].Rows[0]["AppTel"].ToString().Trim();
                        strAppTel = Function.funString_StringToXML(strAppTel);
                    }
                    if (ds.Tables[0].Rows[0]["AppTel"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["AppMobile"].ToString().Trim() != "")
                    {
                        strAppTel = ds.Tables[0].Rows[0]["AppTel"].ToString().Trim() + "/" + ds.Tables[0].Rows[0]["AppMobile"].ToString().Trim();
                        strAppTel = Function.funString_StringToXML(strAppTel);
                    }
                    if (ds.Tables[0].Rows[0]["EnduserTel"].ToString().Trim() == "")
                    {
                        strEnduserTel = ds.Tables[0].Rows[0]["EnduserMobile"].ToString().Trim();
                        strEnduserTel = Function.funString_StringToXML(strEnduserTel);
                    }
                    if (ds.Tables[0].Rows[0]["EnduserMobile"].ToString().Trim() == "")
                    {
                        strEnduserTel = ds.Tables[0].Rows[0]["EnduserTel"].ToString().Trim();
                        strEnduserTel = Function.funString_StringToXML(strEnduserTel);
                    }
                    if (ds.Tables[0].Rows[0]["EnduserTel"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["EnduserMobile"].ToString().Trim() != "")
                    {
                        strEnduserTel = ds.Tables[0].Rows[0]["EnduserTel"].ToString().Trim() + "/" + ds.Tables[0].Rows[0]["EnduserMobile"].ToString().Trim();
                        strEnduserTel = Function.funString_StringToXML(strEnduserTel);
                    }
                    strAppFax = ds.Tables[0].Rows[0]["AppFax"].ToString();
                    strAppFax = Function.funString_StringToXML(strAppFax);
                    strEnduserCompanyName = ds.Tables[0].Rows[0]["EnduserCompanyName"].ToString();
                    strEnduserCompanyName = Function.funString_StringToXML(strEnduserCompanyName);
                    strEnduserAddress = ds.Tables[0].Rows[0]["EnduserAddress"].ToString();
                    strEnduserAddress = Function.funString_StringToXML(strEnduserAddress);
                    strEnduserPostCode = ds.Tables[0].Rows[0]["EnduserPostCode"].ToString();
                    strEnduserPostCode = Function.funString_StringToXML(strEnduserPostCode);
                    strEnduserContactName = ds.Tables[0].Rows[0]["EnduserContactName"].ToString();
                    strEnduserContactName = Function.funString_StringToXML(strEnduserContactName);
                    strEnduserFax = ds.Tables[0].Rows[0]["EnduserFax"].ToString();
                    strEnduserFax = Function.funString_StringToXML(strEnduserFax);
                    strMachineManufacturer = ds.Tables[0].Rows[0]["MachineManufacturer"].ToString();
                    strMachineManufacturer = Function.funString_StringToXML(strMachineManufacturer);
                    strmanuAddress = ds.Tables[0].Rows[0]["manuAddress"].ToString();
                    strmanuAddress = Function.funString_StringToXML(strmanuAddress);
                    strmanuZipCode = ds.Tables[0].Rows[0]["manuZipCode"].ToString();
                    strmanuZipCode = Function.funString_StringToXML(strmanuZipCode);
                    strmanuContactor = ds.Tables[0].Rows[0]["manuContactor"].ToString();
                    strmanuContactor = Function.funString_StringToXML(strmanuContactor);
                    strmanuTel = ds.Tables[0].Rows[0]["manuTel"].ToString();
                    strmanuTel = Function.funString_StringToXML(strmanuTel);
                    strmanuFax = ds.Tables[0].Rows[0]["manuFax"].ToString();
                    strmanuFax = Function.funString_StringToXML(strmanuFax);
                    strTypeOfMachine = ds.Tables[0].Rows[0]["TypeOfMachine"].ToString();
                    strTypeOfMachine = Function.funString_StringToXML(strTypeOfMachine);
                    strMachineSerialNo = ds.Tables[0].Rows[0]["MachineSerialNo"].ToString();
                    strMachineSerialNo = Function.funString_StringToXML(strMachineSerialNo);
                    strControllerType = ds.Tables[0].Rows[0]["ControllerType"].ToString();
                    strControllerType = Function.funString_StringToXML(strControllerType);
                    strDriverType = ds.Tables[0].Rows[0]["DriverType"].ToString();
                    strDriverType = Function.funString_StringToXML(strDriverType);
                    strSoftwareVersion = ds.Tables[0].Rows[0]["SoftwareVersion"].ToString();
                    strSoftwareVersion = Function.funString_StringToXML(strSoftwareVersion);
                    strRSCNo = ds.Tables[0].Rows[0]["RSVNO"].ToString();
                    strRSCNo = Function.funString_StringToXML(strRSCNo);
                    strCaseTime = ds.Tables[0].Rows[0]["CaseTime"].ToString();
                    strCaseTime = Function.funString_StringToXML(strCaseTime);
                    strTroubleDesc = ds.Tables[0].Rows[0]["TroubleDesc"].ToString();
                    strTroubleDesc = Function.funString_StringToXML(strTroubleDesc);
                    strLocalRSCNo = ds.Tables[0].Rows[0]["LocalRSCNo"].ToString();
                    strLocalRSCNo = Function.funString_StringToXML(strLocalRSCNo);
                    strContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                    strContractNo = Function.funString_StringToXML(strContractNo);
                    strMCMTMainMLFB = ds.Tables[0].Rows[0]["MCMTMainMLFB"].ToString();
                    strMCMTMainMLFB = Function.funString_StringToXML(strMCMTMainMLFB);
                    strText = ds.Tables[0].Rows[0]["Text"].ToString();
                    strText = Function.funString_StringToXML(strText);

                    DataSet dsMaterial = new DataSet();
                    dsMaterial = funDatsSet_MCMTMaterial(uRequestID);
                    if (dsMaterial != null && dsMaterial.Tables[0].Rows.Count > 0)
                    {
                        strMLFB = dsMaterial.Tables[0].Rows[0]["MLFB"].ToString();
                        strMLFB = Function.funString_StringToXML(strMLFB);
                        strSerialNo = dsMaterial.Tables[0].Rows[0]["SerialNo"].ToString();
                        strSerialNo = Function.funString_StringToXML(strSerialNo);
                    }

                    strBWord.Replace("MTnotificationno", strNotificationNo);
                    strBWord.Replace("MTDepartment", "");
                    strBWord.Replace("MTAppcompany", strAppCompanyName);
                    strBWord.Replace("MTAppcontact", strAppContactName);
                    strBWord.Replace("MTAppContactphone", strAppTel);
                    strBWord.Replace("MTAppContactFax", strAppFax);
                    strBWord.Replace("MTEnduserCompany", strEnduserCompanyName);
                    strBWord.Replace("MTEnduserAddress", strEnduserAddress);
                    strBWord.Replace("MTEnduserPost", strEnduserPostCode);
                    strBWord.Replace("MTEnduserContact", strEnduserContactName);
                    strBWord.Replace("MTEnduserPhone", strEnduserTel);
                    strBWord.Replace("MTEnduserFax", strEnduserFax);
                    strBWord.Replace("MTMachineManufacturer", strMachineManufacturer);
                    strBWord.Replace("MTmanuAddress", strmanuAddress);
                    strBWord.Replace("MTmanuZipCode", strmanuZipCode);
                    strBWord.Replace("MTmanuContactor", strmanuContactor);
                    strBWord.Replace("MTmanuTel", strmanuTel);
                    strBWord.Replace("MTmanuFax", strmanuFax);
                    strBWord.Replace("MTTypeOfMachine", strTypeOfMachine);
                    strBWord.Replace("MTMachineSerialNo", strMachineSerialNo);
                    strBWord.Replace("MTControllerType", strControllerType);
                    strBWord.Replace("MTDriverType", strDriverType);
                    strBWord.Replace("MTSoftwareVersion", strSoftwareVersion);
                    strBWord.Replace("MTMLFBNo", strMLFB);
                    strBWord.Replace("MTSerialNo", strSerialNo);
                    strBWord.Replace("MTRSVNO", strRSCNo);
                    strBWord.Replace("MTCaseTime", strCaseTime);
                    strBWord.Replace("MTFaultDescription", strTroubleDesc);
                    strBWord.Replace("MTLocalRSCNo", strLocalRSCNo);
                    strBWord.Replace("MTContractNo", strContractNo);
                    strBWord.Replace("MTMCMTMainMLFB", strMCMTMainMLFB);
                    strBWord.Replace("MTComments", strText);
                    if (ds.Tables[0].Rows[0]["Warranty"].ToString().Trim().ToLower() == "out warranty")
                    {
                        strBWord.Replace("MTAppCase", strAppCompanyName + "/" + strAppContactName + strAppTel);
                    }
                    else
                    {
                        strBWord.Replace("MTAppCase", "");
                    }
                }
                sub_EmptyPrint();
            }

            string strTmpWordFile = "";
            string strTmpFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
            strTmpWordFile = HttpContext.Current.Server.MapPath("../Temp/") + strTmpFileName;
            FileStream fs = new FileStream(strTmpWordFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(strBWord);
            sw.Close();
            fs.Close();
            return strTmpFileName;
        }
        #endregion

        #region "获得Material的MLFB,SerialNo"
        public DataSet funDatsSet_MCMTMaterial(string struRequestID)
        {
            string strSQL = "select top 1 MLFB,SerialNo from webInfo_Servicerequest_Material_Info where uRequestID = '" + struRequestID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            return ds;
        }
        #endregion

        #region "打印空模板是将变量替换为空"
        private void sub_EmptyPrint()
        {
            //strBWord.Replace("$notificationno$", "");
            //strBWord.Replace("$Department$", "");
            //strBWord.Replace("$Appcompany$", "");
            //strBWord.Replace("$Appcontact$", "");
            //strBWord.Replace("$AppContactphone$", "");
            //strBWord.Replace("$AppContactFax$", "");
            //strBWord.Replace("$EnduserCompany$", "");
            //strBWord.Replace("$EnduserCompanyAddress$", "");
            //strBWord.Replace("$EnduserContactPost$", "");
            //strBWord.Replace("$EnduserContact$", "");
            //strBWord.Replace("$EnduserContactphone$", "");
            //strBWord.Replace("$EnduserContactFax$", "");
            //strBWord.Replace("$MachineManufacturer$", "");
            //strBWord.Replace("$manuAddress$", "");
            //strBWord.Replace("$manuZipCode$", "");
            //strBWord.Replace("$manuContactor$", "");
            //strBWord.Replace("$manuTel$", "");
            //strBWord.Replace("$manuFax$", "");
            //strBWord.Replace("$TypeOfMachine$", "");
            //strBWord.Replace("$MachineSerialNo$", "");
            //strBWord.Replace("$ControllerType$", "");
            //strBWord.Replace("$DriverType$", "");
            //strBWord.Replace("$SoftwareVersion$", "");
            //strBWord.Replace("$MLFBNo$", "");
            //strBWord.Replace("$SerialNo$", "");
            //strBWord.Replace("$RSVNO$", "");
            //strBWord.Replace("$CaseTime$", "");
            //strBWord.Replace("$FaultDescription$", "");
            //strBWord.Replace("$LocalRSCNo$", "");
            //strBWord.Replace("$ContractNo$", "");
            //strBWord.Replace("$MCMTMainMLFB$", "");
            //strBWord.Replace("$Comments$", "");
            //strBWord.Replace("$AppCase$", "");
        }
        #endregion

        #region "建立Word文件"
        private string subCreate_ServiceRequestWord(string strTemplateName, string strTemplateFullPath, string uRequestID)
        {
            if (strTemplateName.ToLower() == "Internal MT SR Form.xml".ToLower())
            {
                string strFileName = funString_MCMTWord(strTemplateName, strTemplateFullPath, uRequestID);
                return strFileName;
            }

            string strDocument = strTemplateName;
            StringBuilder strBWord = new StringBuilder();
            strBWord = Function.funStringBuilder_WordXMLToStringBuilder(strTemplateFullPath);
            if (strTemplateName.Trim() != "spare parts request form.xml")
            {
                string strSQL = "";
                strSQL = "SELECT RequestID,NotificationNo, MLFBNo, SerialNo, TroubleDesc, AppCompanyName, AppContactName, AppTel, AppMobile, APPEmail,AppFax, EnduserCompanyName,EnduserContactName, EnduserTel, EnduserMobile, EnduserFax, AppAddress, AppPostCode,Text FROM webInfo_ServiceRequest_Info where ID='" + uRequestID + "'";
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                string RequestID = "";
                string NotificationNo = "";
                string MLFBNo = "";
                string SerialNo = "";
                string TroubleDesc = "";
                string AppCompanyName = "";
                string AppContactName = "";
                string AppTel = "";
                string AppMobile = "";
                string AppFax = "";
                string EnduserCompanyName = "";
                string EnduserContactName = "";
                string EnduserTel = "";
                string EnduserMobile = "";
                string EnduserFax = "";
                string AppAddress = "";
                string AppPostCode = "";
                string Text = "";
                string AppEmail = "";
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    RequestID = ds.Tables[0].Rows[0]["RequestID"].ToString();
                    RequestID = Function.funString_StringToXML(RequestID);

                    NotificationNo = ds.Tables[0].Rows[0]["NotificationNo"].ToString();
                    NotificationNo = Function.funString_StringToXML(NotificationNo);

                    MLFBNo = (ds.Tables[0].Rows[0]["MLFBNo"].ToString());
                    MLFBNo = Function.funString_StringToXML(MLFBNo);

                    SerialNo = (ds.Tables[0].Rows[0]["SerialNo"].ToString());
                    SerialNo = Function.funString_StringToXML(SerialNo);

                    TroubleDesc = (ds.Tables[0].Rows[0]["TroubleDesc"].ToString());
                    TroubleDesc = Function.funString_StringToXML(TroubleDesc);

                    AppCompanyName = (ds.Tables[0].Rows[0]["AppCompanyName"].ToString());
                    AppCompanyName = Function.funString_StringToXML(AppCompanyName);

                    AppContactName = (ds.Tables[0].Rows[0]["AppContactName"].ToString());
                    AppContactName = Function.funString_StringToXML(AppContactName);

                    AppTel = ds.Tables[0].Rows[0]["AppTel"].ToString();
                    AppTel = Function.funString_StringToXML(AppTel);

                    AppMobile = ds.Tables[0].Rows[0]["AppMobile"].ToString();
                    AppMobile = Function.funString_StringToXML(AppMobile);

                    AppFax = ds.Tables[0].Rows[0]["AppFax"].ToString();
                    AppFax = Function.funString_StringToXML(AppFax);

                    EnduserCompanyName = (ds.Tables[0].Rows[0]["EnduserCompanyName"].ToString());
                    EnduserCompanyName = Function.funString_StringToXML(EnduserCompanyName);

                    EnduserContactName = (ds.Tables[0].Rows[0]["EnduserContactName"].ToString());
                    EnduserContactName = Function.funString_StringToXML(EnduserContactName);

                    EnduserTel = ds.Tables[0].Rows[0]["EnduserTel"].ToString();
                    EnduserTel = Function.funString_StringToXML(EnduserTel);

                    EnduserMobile = ds.Tables[0].Rows[0]["EnduserMobile"].ToString();
                    EnduserMobile = Function.funString_StringToXML(EnduserMobile);

                    EnduserFax = ds.Tables[0].Rows[0]["EnduserFax"].ToString();
                    EnduserFax = Function.funString_StringToXML(EnduserFax);

                    AppAddress = (ds.Tables[0].Rows[0]["AppAddress"].ToString());
                    AppAddress = Function.funString_StringToXML(AppAddress);

                    AppPostCode = ds.Tables[0].Rows[0]["AppPostCode"].ToString();
                    AppPostCode = Function.funString_StringToXML(AppPostCode);

                    AppEmail = ds.Tables[0].Rows[0]["AppEmail"].ToString();
                    AppEmail = Function.funString_StringToXML(AppEmail);

                    Text = ds.Tables[0].Rows[0]["Text"].ToString();
                    Text = Function.funString_StringToXML(Text);
                }
                strBWord.Replace("!RequestID!", RequestID);
                strBWord.Replace("!Notification!", NotificationNo);

                strBWord.Replace("!CompanyName!", AppCompanyName);
                strBWord.Replace("!contactUser!", AppContactName);
                strBWord.Replace("!Tel!", AppTel);
                strBWord.Replace("!mobile!", AppMobile);
                strBWord.Replace("!Fax!", AppFax);
                strBWord.Replace("!finallyCompanyName!", EnduserCompanyName);
                strBWord.Replace("!finallycontactUser!", EnduserContactName);
                strBWord.Replace("!finallyTel!", EnduserTel);
                strBWord.Replace("!finallyMobile!", EnduserMobile);
                strBWord.Replace("!finallyFax!", EnduserFax);
                strBWord.Replace("!Address!", AppAddress);
                strBWord.Replace("!PostCode!", AppPostCode);
                strBWord.Replace("!Email!", AppEmail);
                string strMaterial = "";
                switch (strDocument)
                {
                    case "低压产品（3VT系列）服务登记表.xml":
                        strMaterial = funMaterial(TroubleDesc, strTemplateName,uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "低压产品服务登记表SEAL.xml":
                        strMaterial = funMaterial(TroubleDesc, strTemplateName, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "自控产品服务登记表（上海）.xml":
                        strMaterial = funMaterial(TroubleDesc, strTemplateName, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "自控产品服务登记表（北京）.xml":
                        strMaterial = funMaterial(TroubleDesc, strTemplateName, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "SNC request form.xml":
                        strMaterial = funMaterial(TroubleDesc, strTemplateName, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    default:
                        strBWord.Replace("!MLFBNo!", MLFBNo);
                        strBWord.Replace("!SerialNo!", SerialNo);
                        strBWord.Replace("!Trouble!", TroubleDesc);
                        break;
                }
            }
            string strTmpWordFile = "";
            string strTmpFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
            strTmpWordFile = HttpContext.Current.Server.MapPath("../../../temp/") + strTmpFileName;
            FileStream fs = new FileStream(strTmpWordFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(strBWord);
            sw.Close();
            fs.Close();
            return strTmpFileName;
        }
        #endregion

        #region "获得Material"
        private string funMaterial(string strTrouble, string TempText, string uRequestID)
        {
            string strAll = "";
            string strDocument = TempText;
            string strSQL = "select MLFB,SerialNo,Quantity from webInfo_Servicerequest_Material_Info where uRequestID = '" + uRequestID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int intCount = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    intCount = intCount + 1;
                    string strPart = "";
                    switch (strDocument)
                    {
                        case "低压产品（3VT系列）服务登记表.xml":
                            strPart = "<w:tr wsp:rsidR='002367DC'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:rFonts w:cs='Arial'/><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "低压产品服务登记表SEAL.xml":
                            strPart = "<w:tr><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='366' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:pStyle w:val='a3'/><w:tabs><w:tab w:val='clear' w:pos='8640'/><w:tab w:val='right' w:pos='9781'/></w:tabs><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2694' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2700' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:jc w:val='both'/><w:rPr><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:b-cs/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='1260' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr><w:t>!Qty!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2880' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:b-cs/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "自控产品服务登记表（上海）.xml":
                            strPart = "<w:tr wsp:rsidR='007C4862'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRDefault='007C4862' wsp:rsidP='007839FE'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/><w:lang w:fareast='EN-US'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "自控产品服务登记表（北京）.xml":
                            strPart = @"<w:tr wsp:rsidR='00A16C11' wsp:rsidTr='00A16C11'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00A16C11' wsp:rsidRDefault='004D4BBC' wsp:rsidP='00A16C11'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/></w:rPr><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00A16C11' wsp:rsidRDefault='004D4BBC' wsp:rsidP='00A16C11'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:proofErr w:type='spellStart'/><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00A16C11' wsp:rsidRDefault='004D4BBC' wsp:rsidP='00A16C11'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/></w:rPr><w:t>!SerialNo!</w:t></w:r><w:proofErr w:type='spellEnd'/></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00A16C11' wsp:rsidRDefault='004D4BBC' wsp:rsidP='00A16C11'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "SNC request form.xml":
                            strPart = "<w:tr wsp:rsidR='00D9627B'><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00D9627B' wsp:rsidP='00150866'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                    }

                    strPart = strPart.Replace("!Count!", intCount.ToString());
                    strPart = strPart.Replace("!MLFBNo!", Function.funString_StringToXML(ds.Tables[0].Rows[i]["MLFB"].ToString()));
                    strPart = strPart.Replace("!SerialNo!", Function.funString_StringToXML(ds.Tables[0].Rows[i]["SerialNo"].ToString()));
                    strPart = strPart.Replace("!Trouble!", Function.funString_StringToXML(strTrouble));
                    strPart = strPart.Replace("!Qty!", Function.funString_StringToXML(ds.Tables[0].Rows[i]["Quantity"].ToString()));
                    strAll = strAll + strPart;
                }
            }
            else
            {
                string strPart = "";
                switch (strDocument)
                {
                    case "低压产品（3VT系列）服务登记表.xml":
                        strPart = "<w:tr wsp:rsidR='002367DC'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='002367DC' wsp:rsidRDefault='009B6117'><w:pPr><w:rPr><w:rFonts w:cs='Arial'/><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "低压产品服务登记表SEAL.xml":
                        strPart = "<w:tr><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='366' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:pStyle w:val='a3'/><w:tabs><w:tab w:val='clear' w:pos='8640'/><w:tab w:val='right' w:pos='9781'/></w:tabs><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2694' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2700' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:jc w:val='both'/><w:rPr><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:b-cs/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='1260' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr><w:t>!Qty!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2880' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p><w:pPr><w:rPr><w:rFonts w:hint='fareast'/><w:b-cs/></w:rPr></w:pPr><w:r><w:rPr><w:b-cs/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "自控产品服务登记表（上海）.xml":
                        strPart = "<w:tr wsp:rsidR='007C4862'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRDefault='007C4862' wsp:rsidP='007839FE'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/><w:lang w:fareast='EN-US'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "自控产品服务登记表（北京）.xml":
                        strPart = "<w:tr wsp:rsidR='00D9627B'><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00D9627B' wsp:rsidP='00150866'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "SNC request form.xml":
                        strPart = "<w:tr wsp:rsidR='00D9627B'><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00D9627B' wsp:rsidP='00150866'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                }
                for (int i = 0; i < 4; i++)
                {
                    strPart = strPart.Replace("!Count!", "");
                    strPart = strPart.Replace("!MLFBNo!", "");
                    strPart = strPart.Replace("!SerialNo!", "");
                    strPart = strPart.Replace("!Trouble!", "");
                    strPart = strPart.Replace("!Qty!", "");
                    strAll = strAll + strPart;
                }
            }
            return strAll;
        }
        #endregion
    }
}