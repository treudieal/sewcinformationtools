using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.Text;
using System.IO;
using IdioSoft.Business.Class;
using IdioSoft.Business.Method;
namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for RequestSendFax
    /// </summary>
    public class RequestSendFax : ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string ErrorMsg = "";
            string strSQL = "";
            string strReturn = "";
            IdioSoft.Site.ClassLibrary.Control.ClassSendFaxListTable objSendFaxListTable = new ClassLibrary.Control.ClassSendFaxListTable();
            IdioSoft.Site.ClassLibrary.Control.SendFaxListRow objSendFaxListRow = new ClassLibrary.Control.SendFaxListRow();

            string TempText = context.Server.UrlDecode(context.funString_RequestFormValue("TempText"));
            string TempValue = context.Server.UrlDecode(context.funString_RequestFormValue("TempValue"));
            string uRequestID = context.Server.UrlDecode(context.funString_RequestFormValue("uRequestID"));
            string Subject = context.Server.UrlDecode(context.funString_RequestFormValue("Subject"));
            string FaxNumber = context.Server.UrlDecode(context.funString_RequestFormValue("FaxNumber"));
            string Receiver = context.Server.UrlDecode(context.funString_RequestFormValue("Receiver"));
            string ReceiverCompany = context.Server.UrlDecode(context.funString_RequestFormValue("ReceiverCompany"));
            string ReceiverTel = context.Server.UrlDecode(context.funString_RequestFormValue("ReceiverTel"));

            objSendFaxListRow.Message = "1";
            objSendFaxListRow.Priority = 1;
            objSendFaxListRow.ScheduledDateTime = DateTime.Now.ToString();
            objSendFaxListRow.SendFaxDateTime = DateTime.Now.ToString();
            objSendFaxListRow.Subject = Subject;

            IdioSoft.Site.ClassLibrary.Control.SubSendFaxListTable objSubSendFaxListTable = new ClassLibrary.Control.SubSendFaxListTable();
            IdioSoft.Site.ClassLibrary.Control.SubSendFaxListRow objSubSendFaxListRow = new ClassLibrary.Control.SubSendFaxListRow();

            objSubSendFaxListRow.FaxNumber = FaxNumber;
            objSubSendFaxListRow.Receiver = Receiver;
            objSubSendFaxListRow.ReceiverCompany = ReceiverCompany;
            objSubSendFaxListRow.FaxType = "0";

            objSubSendFaxListTable.SubSendFaxListRow = objSubSendFaxListRow;
            objSendFaxListRow.SubSendFaxListTable = objSubSendFaxListTable;

            IdioSoft.Site.ClassLibrary.Control.FaxFileTable objFaxFileTable = new ClassLibrary.Control.FaxFileTable();
            IdioSoft.Site.ClassLibrary.Control.FaxFileRow objFaxFileRow = new ClassLibrary.Control.FaxFileRow();

            StringBuilder strBWord = new StringBuilder();
            strBWord = subCreateWord(TempValue,TempText,uRequestID);

            if (strBWord.ToString().Trim() != "")
            {
                UTF8Encoding encodeing = new UTF8Encoding();
                byte[] b = encodeing.GetBytes(strBWord.ToString());
                string strB = Convert.ToBase64String(b);

                string time = DateTime.Now.ToString("yyyyMMddHHmmss");

                objFaxFileRow.FaxFile = strB;
                objFaxFileRow.FaxFileName = time + ".doc";
                objFaxFileRow.FaxFileSize = strB.Length.ToString();
                objFaxFileRow.FaxFileType = "application/octet-stream";
                objFaxFileTable.FaxFileRow = objFaxFileRow;

                objSendFaxListRow.FaxFileTable = objFaxFileTable;
                objSendFaxListTable.SendFaxListRow = objSendFaxListRow;

                string strDirPath = HttpContext.Current.Server.MapPath("../../../temp") + "\\" + time + ".doc";
                objSendFaxListTable.Save(strDirPath);

                string strXMl = "";
                try
                {
                    strXMl = File.ReadAllText(strDirPath, System.Text.Encoding.UTF8);
                    strXMl = strXMl.Substring(23);
                }
                catch
                {
                    ErrorMsg = "1Xml Error" + strXMl + "<br>";
                    return;
                }
                string strFind = "";
                strFind = " xmlns:";
                int intFind;
                intFind = strXMl.IndexOf(strFind);

                try
                {
                    strXMl = strXMl.Remove(intFind, 99);
                }
                catch
                {
                    ErrorMsg = "2Xml Error" + strXMl + "<br>";
                    return;
                }

                IdioSoft.Site.ClassLibrary.Control.classBasicFaxInfo objclassBasicFaxInfo = new ClassLibrary.Control.classBasicFaxInfo();
                objclassBasicFaxInfo = funclassBasicFaxInfo();
                IdioSoft.Business.Class.ServiceAgentHelper agent = new ServiceAgentHelper(objclassBasicFaxInfo.strWebUrl);
                string tokenid = "";
                object[] Par = new object[3];
                Par[0] = objclassBasicFaxInfo.username;
                Par[1] = objclassBasicFaxInfo.password;
                Par[2] = false;
                try
                {
                    tokenid = agent.Invoke("Login", Par).ToString();
                    ErrorMsg = tokenid + "tokenid ok<br>";
                    return;
                }
                catch
                {
                    ErrorMsg = "tokenid error<br>";
                    return;
                }
                object[] objSend = new object[2];
                objSend[0] = tokenid;
                objSend[1] = strXMl;
                try
                {
                    strReturn = agent.Invoke("SendFax", objSend).ToString();
                    strReturn = strReturn.Replace("<SubSendFaxListTable><SubSendFaxListIDRow><SubSendFaxListID>", "");
                    strReturn = strReturn.Replace("</SubSendFaxListID></SubSendFaxListIDRow></SubSendFaxListTable>", "");
                    ErrorMsg = strReturn + "send fax OK";
                    return;
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Source.ToString() + "<br>" + ex.Message.ToString() + "<br>";
                    return;
                }
            }

            int intSuccee = 0;
            try
            {
                if (int.Parse(strReturn) > 0)
                {
                    intSuccee = 1;
                }
            }
            catch
            {
                intSuccee = 0;
            }
            string strFaxFile = "";
            try
            {
                strFaxFile = TempText.ToString().Trim();
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Source.ToString() + "<br>" + ex.Message.ToString() + "xmlerror<br>";
                return;
            }

            if (FaxNumber.ToString().Trim() != "")
            {
                strSQL = "INSERT INTO webInfo_ServiceRequest_Fax_Send_List (Sender, Receiver,ReceiverFax,SenderTime,isSuccee,SendID,ReceiverTel,FaxFile) VALUES (";
                strSQL = strSQL + objUserInfo.UserID + ",'" + Receiver.funString_SQLToString() + "','" + FaxNumber.funString_SQLToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + intSuccee + ",'" + strReturn.funString_SQLToString() + "','" + ReceiverTel.funString_SQLToString() + "','" + strFaxFile + "')";
                string strLog = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }

            if (ErrorMsg == "")
            {
                context.Response.Write("ok!");//成功
            }
            else
            {
                context.Response.Write("");//失败
            }
            context.Response.End();
        }

        #region "获得发送的配置信息"
        private IdioSoft.Site.ClassLibrary.Control.classBasicFaxInfo funclassBasicFaxInfo()
        {
            string strSQL = "";
            strSQL = "SELECT WebServiceUrl, UserName, Password FROM webInfo_Basic_ServiceRequest_Fax_Info";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            IdioSoft.Site.ClassLibrary.Control.classBasicFaxInfo objclassBasicFaxInfo = new ClassLibrary.Control.classBasicFaxInfo();
            try
            {
                objclassBasicFaxInfo.strWebUrl = ds.Tables[0].Rows[0]["WebServiceUrl"].ToString();
                objclassBasicFaxInfo.username = ds.Tables[0].Rows[0]["UserName"].ToString();
                objclassBasicFaxInfo.password = ds.Tables[0].Rows[0]["Password"].ToString();
            }
            catch
            {
            }
            return objclassBasicFaxInfo;
        }
        #endregion

        #region "建立Word文件"
        private StringBuilder subCreateWord(string strTemplateName, string TempText,string uRequestID)
        {
            StringBuilder strBWord = new StringBuilder();

            //打开模版文件
            string strDocument = TempText;
            strBWord = Function.funStringBuilder_WordXMLToStringBuilder(strTemplateName);
            //
            if (strBWord.ToString().Trim() != "")
            {
                //开始做查找
                string strSQL = "";
                strSQL = "SELECT RequestID,NotificationNo, MLFBNo, SerialNo, TroubleDesc, AppCompanyName, AppContactName, AppTel, AppMobile, AppFax, EnduserCompanyName,EnduserContactName, EnduserTel, EnduserMobile, EnduserFax, AppAddress, AppPostCode FROM webInfo_ServiceRequest_Info where ID='" + uRequestID + "'";
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
                try
                {
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
                    }
                }
                catch
                {
                }
                finally
                {
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
                string strMaterial = "";
                switch (strDocument)
                {
                    case "低压产品（3VT系列）服务登记表.xml":
                        strMaterial = funMaterial(TroubleDesc,TempText,uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "低压产品服务登记表SEAL.xml":
                        strMaterial = funMaterial(TroubleDesc, TempText, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "自控产品服务登记表（上海）.xml":
                        strMaterial = funMaterial(TroubleDesc, TempText, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    case "自控产品服务登记表（北京）.xml":
                        strMaterial = funMaterial(TroubleDesc, TempText, uRequestID);
                        strBWord.Replace("!Material!", strMaterial);
                        break;
                    default:
                        strBWord.Replace("!MLFBNo!", MLFBNo);
                        strBWord.Replace("!SerialNo!", SerialNo);
                        strBWord.Replace("!Trouble!", TroubleDesc);
                        break;
                }
                return strBWord;
            }
            else
            {
                return strBWord;
            }
        }

        #region "获得Material"
        private string funMaterial(string strTrouble, string TempText,string uRequestID)
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
                            //strPart = "<w:tr wsp:rsidR='00513EA3'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:pStyle w:val='Header'/><w:tabs><w:tab w:val='clear' w:pos='8640'/><w:tab w:val='right' w:pos='9781'/></w:tabs><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:rFonts w:cs='Arial'/><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "自控产品服务登记表（上海）.xml":
                            strPart = "<w:tr wsp:rsidR='007C4862'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRDefault='007C4862' wsp:rsidP='007839FE'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/><w:lang w:fareast='EN-US'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                            break;
                        case "自控产品服务登记表（北京）.xml":
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
                        //strPart = "<w:tr wsp:rsidR='00513EA3'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:pStyle w:val='Header'/><w:tabs><w:tab w:val='clear' w:pos='8640'/><w:tab w:val='right' w:pos='9781'/></w:tabs><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial' w:cs='Arial'/><wx:font wx:val='Arial'/><w:b-cs/><w:sz w:val='22'/><w:lang w:fareast='ZH-CN'/></w:rPr><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00513EA3' wsp:rsidRDefault='005C01D4'><w:pPr><w:rPr><w:rFonts w:cs='Arial'/><w:b-cs/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "自控产品服务登记表（上海）.xml":
                        strPart = "<w:tr wsp:rsidR='007C4862'><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRDefault='007C4862' wsp:rsidP='007839FE'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='007C4862' wsp:rsidRPr='002F0735' wsp:rsidRDefault='000349F2' wsp:rsidP='007839FE'><w:pPr><w:rPr><w:rFonts w:fareast='新宋体'/><w:b/><w:sz-cs w:val='22'/><w:lang w:fareast='EN-US'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                    case "自控产品服务登记表（北京）.xml":
                        strPart = "<w:tr wsp:rsidR='00D9627B'><w:tblPrEx><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/></w:tblCellMar></w:tblPrEx><w:trPr><w:cantSplit/><w:trHeight w:val='397'/></w:trPr><w:tc><w:tcPr><w:tcW w:w='376' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00D9627B' wsp:rsidP='00150866'><w:r><w:t>!Count!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3602' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!MLFBNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='3042' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:rFonts w:hint='fareast'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!SerialNo!</w:t></w:r></w:p></w:tc><w:tc><w:tcPr><w:tcW w:w='2864' w:type='dxa'/><w:vAlign w:val='center'/></w:tcPr><w:p wsp:rsidR='00D9627B' wsp:rsidRDefault='00952E2D' wsp:rsidP='00150866'><w:pPr><w:rPr><w:sz-cs w:val='22'/></w:rPr></w:pPr><w:r><w:rPr><w:rFonts w:ascii='新宋体' w:fareast='新宋体' w:h-ansi='Times New Roman'/><wx:font wx:val='新宋体'/><w:sz-cs w:val='22'/></w:rPr><w:t>!Trouble!</w:t></w:r></w:p></w:tc></w:tr>";
                        break;
                }
                for (int i = 0; i < 4; i++)
                {
                    strPart = strPart.Replace("!Count!", " ");
                    strPart = strPart.Replace("!MLFBNo!", " ");
                    strPart = strPart.Replace("!SerialNo!", " ");
                    strPart = strPart.Replace("!Trouble!", " ");
                    strPart = strPart.Replace("!Qty!", "");
                    strAll = strAll + strPart;
                }
            }
            return strAll;
        }
        #endregion

        private StringBuilder subAccountCreateWord(string strTemplateName,string uRequestID)
        {
            StringBuilder strBWord = new StringBuilder();

            strBWord = Function.funStringBuilder_WordXMLToStringBuilder(strTemplateName);

            if (strBWord.ToString().Trim() != "")
            {
                if (uRequestID != "")
                {
                    //开始做查找
                    string strSQL = "";
                    strSQL = "SELECT CompanyName FROM view_Account_Contact_List where ID='" + uRequestID + "'";
                    try
                    {
                        strBWord.Replace("!CompanyName!", objDbSQLAccess.funString_SQLExecuteScalar(strSQL));
                    }
                    catch
                    {
                    }
                    finally
                    {
                    }
                }
                else
                {
                    strBWord.Replace("!CompanyName!", " ");
                }

                //if (Request.QueryString["contactID"].ToString() != "")
                //{
                //    string strSQLs = "";
                //    strSQLs = "SELECT ContactName, Tel, Mobile, Fax, Address, PostCode FROM Webinfo_Account_Contact_info where ID='" + contactID + "'";
                //    DataSet ds = new DataSet();
                //    ds = objClassDbAccess.funDataset_SQLExecuteNonQuery(strSQLs);
                //    try
                //    {
                //        if (ds != null)
                //        {
                //            strBWord.Replace("!contactUser!", Function.funString_StringToXML(ds.Tables[0].Rows[0]["ContactName"].ToString()));
                //            strBWord.Replace("!Tel!", ds.Tables[0].Rows[0]["Tel"].ToString());
                //            strBWord.Replace("!mobile!", ds.Tables[0].Rows[0]["Mobile"].ToString());
                //            strBWord.Replace("!Fax!", ds.Tables[0].Rows[0]["Fax"].ToString());
                //            strBWord.Replace("!Address!", Function.funString_StringToXML(ds.Tables[0].Rows[0]["Address"].ToString()));
                //            strBWord.Replace("!PostCode!", (ds.Tables[0].Rows[0]["PostCode"].ToString()));
                //        }
                //    }
                //    catch
                //    {
                //    }
                //    finally
                //    {

                //    }
                //}
                //else
                //{
                //    strBWord.Replace("!contactUser!", " ");
                //    //AppTel
                //    strBWord.Replace("!Tel!", " ");
                //    //AppMobile
                //    strBWord.Replace("!mobile!", " ");
                //    //AppFax
                //    strBWord.Replace("!Fax!", " ");
                //    //AppAddress
                //    strBWord.Replace("!Address!", " ");
                //    //AppPostCode
                //    strBWord.Replace("!PostCode!", " ");
                //}
                strBWord.Replace("!Notification!", " ");
                //MLFBNo
                strBWord.Replace("!MLFBNo!", " ");
                //SerialNo
                strBWord.Replace("!SerialNo!", " ");
                //TroubleDesc
                strBWord.Replace("!Trouble!", " ");
                //EnduserCompanyName

                strBWord.Replace("!finallyCompanyName!", " ");

                //EndcontactUser

                strBWord.Replace("!finallycontactUser!", " ");

                //EnduserTel

                strBWord.Replace("!finallyTel!", " ");

                //EnduserMobile

                strBWord.Replace("!finallyMobile!", " ");

                //EnduserFax

                strBWord.Replace("!finallyFax!", " ");

                //Replace(strBWord);
                return strBWord;
            }
            else
            {
                return strBWord;
            }
        }
        #endregion
    }
}