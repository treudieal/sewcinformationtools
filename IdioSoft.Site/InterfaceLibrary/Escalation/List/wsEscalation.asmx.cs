using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Tables.Escalation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using IdioSoft.Site.DB.Tables.SEWC;
using System.IO;
using System.Text;
using System.Data;
using IdioSoft.Site.DB.Views.Escalation;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.Escalation.List
{
    /// <summary>
    /// Summary description for wsEscalation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsEscalation : System.Web.Services.WebService
    {
        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public Escalation_MainInfo ReturnEscalationMainInfo(string EscalationID)
        {
            Escalation_MainInfo objViewDetail = new Escalation_MainInfo();
            IDBUnit objView = new CView(objViewDetail);
            objView.getData("EscalationID='" + EscalationID + "'");
            return objViewDetail;
        }

        [WebMethod(EnableSession = true)]
        public string subDB_Save(Dictionary<string, string>[] ParamsList)
        {
            string strReturn = "";
            string strError;
            string strSQL = "";
            Escalation_MainInfo objTableSave = new Escalation_MainInfo();
            ITable objTable = new CTable(objTableSave);
            objTable.SetValues(ParamsList[0]);
            objTable.RecordExistWhere = "EscalationID = '" + objTableSave.EscalationID.FieldValue + "'";

            objTableSave.CreatedUserID.FieldValue = ((IdioSoft.Site.ClassLibrary.UserInfo)Session["UserInfo"]).UserID;
            strError = objTable.Save();
            if (strError == "")
            {
                strReturn = "";
            }
            else
            {
                strReturn = "error";//失败
            }
            return strReturn;
        }
        [WebMethod]
        public string funString_MaxEscalationNo()
        {
            string strSQL = "";
            strSQL = "select max(ERNo) from Escalation_MainInfo where isdel=0 and substring(ERNo,1,8)='" + DateTime.Now.ToString("yyyyMMdd") + "'";
            string MaxErNo = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            if (MaxErNo == "")
            {
                MaxErNo = DateTime.Now.ToString("yyyyMMdd") + "01";
            }
            else
            {
                long MaxNo = MaxErNo.funInt_StringToLong(0) + 1;
                MaxErNo = MaxNo.ToString();
            }
            return MaxErNo;
        }
        [WebMethod]
        public View_Escalation_LoadRequest_List funReturn_LoadRequest(string SRID)
        {
            View_Escalation_LoadRequest_List objViewDetail = new View_Escalation_LoadRequest_List();
            IDBUnit objView = new CView(objViewDetail);
            objView.getData("NotificationNo = '" + SRID + "' or RequestID='" + SRID + "'");
            return objViewDetail;
        }
        [WebMethod(EnableSession = true)]
        public string subDB_Delete(string EscalationID)
        {
            string strReturn = "";
            string strError;
            string strSQL = "";
            Escalation_MainInfo objTableDelete = new Escalation_MainInfo();
            ITable objTable = new CTable(objTableDelete);
            objTable.Delete(EscalationID);
            objTable.RecordDeleteWhere = "EscalationID = '" + EscalationID + "'";

            strError = objTable.Delete();
            if (strError == "")
            {
                strReturn = "0";
            }
            else
            {
                strReturn = "1";//失败
            }
            return strReturn;
        }
        [WebMethod(EnableSession = true)]
        public string subDB_DeleteActivity(string ActivityID)
        {
            string strReturn = "";
            string strError;
            Escalation_ActivityInfo objTableDelete = new Escalation_ActivityInfo();
            ITable objTable = new CTable(objTableDelete);
            objTable.Delete(ActivityID);
            objTable.RecordDeleteWhere = "ActivityID = '" + ActivityID + "'";

            strError = objTable.Delete();
            if (strError == "")
            {
                strReturn = "0";
            }
            else
            {
                strReturn = "1";//失败
            }
            return strReturn;
        }
        [WebMethod]
        public Escalation_ActivityInfo ReturnActivityInfo(string ActivityID)
        {
            Escalation_ActivityInfo objViewDetail = new Escalation_ActivityInfo();
            IDBUnit objView = new CView(objViewDetail);
            objView.getData("ActivityID = '" + ActivityID + "'");
            return objViewDetail;
        }
        [WebMethod(EnableSession = true)]
        public string subDB_SaveActivity(Dictionary<string, string>[] ParamsList)
        {
            string strReturn = "";
            string strError;
            Escalation_ActivityInfo objTableSave = new Escalation_ActivityInfo();
            ITable objTable = new CTable(objTableSave);
            objTable.SetValues(ParamsList[0]);
            objTable.RecordExistWhere = "ActivityID = '" + objTableSave.ActivityID.FieldValue + "'";

            objTableSave.CreatedUserID.FieldValue = ((IdioSoft.Site.ClassLibrary.UserInfo)Session["UserInfo"]).UserID;
            strError = objTable.Save();
            if (strError == "")
            {
                strReturn = "";
            }
            else
            {
                strReturn = "error";//失败
            }
            return strReturn;
        }
        [WebMethod(EnableSession = true)]
        public string subDB_DeleteActivityFile(string ActivityFileID)
        {
            string strReturn = "";
            string strError;
            Escalation_Activity_AttachmentInfo objTableDelete = new Escalation_Activity_AttachmentInfo();
            ITable objTable = new CTable(objTableDelete);
            objTable.Delete(ActivityFileID);
            objTable.RecordDeleteWhere = "ActivityFileID = '" + ActivityFileID + "'";

            strError = objTable.Delete();
            if (strError == "")
            {
                strReturn = "0";
            }
            else
            {
                strReturn = "1";//失败
            }
            return strReturn;
        }
        [WebMethod]
        public string ReturnActivityInfoFile(string ActivityID)
        {
            ////List<Escalation_Activity_AttachmentInfo> lst = new List<Escalation_Activity_AttachmentInfo>();

            StringBuilder sb = new StringBuilder();
            string strSQL = "select ActivityFileID,DocumentName from Escalation_Activity_AttachmentInfo where ActivityID = '" + ActivityID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //sb.Append("<li><a href='../../../Temp/" + ds.Tables[0].Rows[i]["DocumentName"].ToString() + "' target='_blank'>" + ds.Tables[0].Rows[i]["DocumentName"].ToString() + "</a>  <a class='dellink' onclick='javascript:this.subDeleteAttachment(\"" + ds.Tables[0].Rows[i]["ActivityFileID"].ToString() + "\",this);'>[Delete]</a></li>");
                    sb.Append("<li><a href='../../Attachment/Escalation/" + ds.Tables[0].Rows[i]["DocumentName"].ToString() + "' target='_blank'>" + ds.Tables[0].Rows[i]["DocumentName"].ToString() + "</a>  <a class='dellink' id='dellink' href='#' KeyID='" + ds.Tables[0].Rows[i]["ActivityFileID"].ToString() + "');'>[Delete]</a></li>");
                }
            }

            //Escalation_Activity_AttachmentInfo objViewDetail = new Escalation_Activity_AttachmentInfo();
            //IView objView = new CView(objViewDetail);
            //objView.getData("ActivityID = '" + ActivityID + "'");


            return sb.ToString();
        }
    }
}
