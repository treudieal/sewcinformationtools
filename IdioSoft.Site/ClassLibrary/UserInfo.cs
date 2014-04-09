using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.ClassLibrary
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        public string EnUserName { get; set; }
        public string CnUserName { get; set; }
        public string Region { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string ServiceProvider { get; set; }
        public string SysLimited { get; set; }
        public string SysLimiteds { get; set; }
        public string DutyLimited { get; set; }
        public int PageSize { get; set; }
        public Boolean isEngineer = false;
        public string Distributors { get; set; }
        public string DefaultPage { get; set; }
        public string strExcelSql { get; set; }
        public string strAdSearch { get; set; }
        public string strReturnAdSearch { get; set; }
        public string SIASRepairCategory { get; set; }
        public int UserScreenHeight;
        public int UserScreenWidth;
        public string ModuleSelectedName { get; set; }
        public string ModuleLimited { get; set; }
        public string StockNo { get; set; }
        public bool IsReDoOnLoadRequest = false;//这个防止Request中的Cuotomer重载产生多于的空Request
        public string strFromProvider { get; set; }
        public string strFromProviderServiceType { get; set; }
        public string strSurveyServiceType { get; set; }
        public string strSurveyMonth { get; set; }
        public string OpenWindowWith { get; set; }
        public string TmpID { get; set; }
        public string strSNCSEALStatusType = "Open";
        public string BUs { get; set; }
        public string SEALLimiteds { get; set; }
        public string CSSNCLimiteds { get; set; }
        public string SSCLLimiteds { get; set; }
        public string ProductLimited { get; set; }
        public string GoodWillLimiteds { get; set; }
        public string SFAEMType { get; set; }
        public bool IsFollowCallcenter = false;
        public bool IsSA = false;
        public string SEWCLimiteds { get; set; }
        public string EscLimiteds { get; set; }

        public bool funBln_Limited(string LimitID)
        {
            if (SysLimited.IndexOf("" + LimitID + "") >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getProductLimited()
        {
            string strTMp = ProductLimited;
            if (strTMp == "'" || strTMp == "")
            {
                return "''";
            }
            strTMp = strTMp.Substring(1, strTMp.Length - 2).Trim();
            strTMp = strTMp.Replace(",", "','");
            strTMp = "'" + strTMp + "'";
            return strTMp;
        }

        public int GoodWillOptionTabIndex = 0;

        private Dictionary<ExportSQlInfoKey, SQLInfo> _ExportSQLInfo = new Dictionary<ExportSQlInfoKey, SQLInfo>();
        public Dictionary<ExportSQlInfoKey, SQLInfo> ExportSQLInfo
        {
            get
            {
                return _ExportSQLInfo;
            }
            set
            {
                _ExportSQLInfo = value;
            }
        }

        public void UpdateExportSQLInfo(SQLInfo ExportSQLInfo, ExportSQlInfoKey KeyID)
        {
            var p = this.ExportSQLInfo.Where(q => q.Key == KeyID);
            if (p.Count() > 0)
            {
                this.ExportSQLInfo[KeyID] = ExportSQLInfo;
            }
            else
            {
                this.ExportSQLInfo.Add(KeyID, ExportSQLInfo);
            }
        }
    }
}