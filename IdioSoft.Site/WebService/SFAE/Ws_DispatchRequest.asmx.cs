using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Web.Services;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views;
using System.Reflection;
using IdioSoft.Site.DB.Views.SEWC;
using System.Text;
using IdioSoft.Business.Class;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.WebService.SFAE
{
    /// <summary>
    /// Summary description for Ws_DispatchRequest
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_DispatchRequest : System.Web.Services.WebService
    {

        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();

        #region "用户信息"
        public int fuInt_getUserID(string DomainInfo)
        {
            string strSQL = "";
            strSQL = "SELECT ID FROM webInfo_loginInfo where DomainInfo='" + DomainInfo + "'";
            int UserID = 0;
            UserID = Function.funInt_StringToInt(objDbSQLAccess.funString_SQLExecuteScalar(strSQL), 0);
            return UserID;
        }

        [WebMethod]
        public void funDataSet_SfaeUserInfo(string DomainInfo, ref string Email, ref string UserName)
        {
            try
            {
                string strSQL = "";
                strSQL = "SELECT   Url FROM SFAE_Other_SiteUrlInfo";
                string Url = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                if (Url != "")
                {
                    IdioSoft.Business.Class.ServiceAgentHelper objws = new ServiceAgentHelper(Url);
                    object p = DomainInfo;
                    DataSet ds = (DataSet)objws.Invoke("GetUserInfo", p);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        UserName = ds.Tables[0].Rows[0]["enames"].ToString();
                        Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public int funInt_AddUser(string DomainInfo)
        {
            int UserID = 0;
            string strSQL = "";
            string EnUserName = "";
            string Email = "";
            funDataSet_SfaeUserInfo(DomainInfo, ref Email, ref EnUserName);
            strSQL = "select id from webInfo_loginInfo where email='" + Email + "' and isdel=0 and Email<>''";
            int loginID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            if (loginID == 0)
            {
                strSQL = "select id from webInfo_loginInfo where DomainInfo='" + DomainInfo + "' and isdel=0 and DomainInfo<>''";
                loginID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            }
            if (loginID > 0)
            {
                strSQL = "update webInfo_loginInfo set DomainInfo='" + DomainInfo + "' where ID=" + loginID + "";
            }
            else
            {
                strSQL = "INSERT INTO webInfo_loginInfo (DomainInfo,EnUserName,Email,serviceProvider) VALUES ('" + DomainInfo + "','" + EnUserName + "','" + Email + "','sfae')";
            }
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError == "")
            {
                strSQL = "update webInfo_loginInfo set serviceProvider='SFAE' where DomainInfo='" + DomainInfo + "'";
                objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                strSQL = "select id from webInfo_loginInfo where DomainInfo='" + DomainInfo + "'";
                UserID = Function.funInt_StringToInt(objDbSQLAccess.funString_SQLExecuteScalar(strSQL), 0);
            }
            return UserID;
        }
        #endregion

        #region "Request Save"
        [WebMethod]
        public string funString_DeleteAttachment(string FID)
        {
            string strSQL = "";
            strSQL = "delete SFAE_Other_DispatchRequest_AttrachmentInfo where ID='" + FID + "'";
            return objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_AttachmentList(string DispatchID)
        {
            string strSQL = "";
            strSQL = "select ID,FileName from SFAE_Other_DispatchRequest_AttrachmentInfo where DispatchID='" + DispatchID + "' order by createdate desc";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public string funString_SaveAttachment(string FileName, string DomainInfo, string DispatchID)
        {
            DomainInfo = DomainInfo.Substring(DomainInfo.IndexOf("\\") + 1);
            int CreateUser = funInt_AddUser(DomainInfo);
            if (CreateUser == 0)
            {
                CreateUser = funInt_AddUser(DomainInfo);
            }
            string FID = Guid.NewGuid().ToString();
            string strSQL = "";
            strSQL = @"INSERT  INTO SFAE_Other_DispatchRequest_AttrachmentInfo(ID,DispatchID, FileName, CreateUserID) VALUES (";
            strSQL += "'" + FID + "','" + DispatchID + "','" + FileName + "'," + CreateUser + ")";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError == "")
            {
                return FID;
            }
            return "";
        }
        /// <summary>
        /// 保存一个Request
        /// </summary>
        /// <param name="DispatchID">DispatchID,新增时传入Guid.NewGuid().ToString(),修改时传入修改发货单ID</param>
        /// <param name="CostNoType">Sales Order No,WBS Element No,Cost Center几个类型</param>
        /// <param name="BookNo">String</param>
        /// <param name="ServiceOrderNo">String</param>
        /// <param name="s4000No">String</param>
        /// <param name="ConsignorKind">One-way Delivery 单程发货,Pickup Delivery 发货并取旧件,One-way pickup 单程取件</param>
        /// <param name="CustomerName">发货用户</param>
        /// <param name="Address">发货用户地址</param>
        /// <param name="Zip">发货用户邮编</param>
        /// <param name="Contact">发货用户联系人</param>
        /// <param name="Tel">发货用户联系人电话</param>
        /// <param name="Fax">发货用户联系人传真</param>
        /// <param name="DevDate">String(24,48,96数字类型)</param>
        /// <param name="ReturnDate">String</param>
        /// <param name="Comments">String</param>
        /// <param name="DomainInfo">用户Ad账号</param>
        /// <param name="CustomerName1">取件用户</param>
        /// <param name="Address1">取件用户地址</param>
        /// <param name="Zip1">取件用户邮编</param>
        /// <param name="Contact1">取件用户联系人</param>
        /// <param name="Tel1">取件用户联系人电话</param>
        /// <param name="Fax1">取件用户联系人传真</param>
        /// <param name="OutAddress">出库地</param>
        /// <param name="Province">省</param>
        /// <param name="City">市</param>
        /// <param name="ContractNo">合同号</param>
        /// <param name="ServiceType">服务类型</param>
        /// <param name="Dept">部门CAB,SS1,SS2,SS3,SS4,SER</param>
        /// <param name="isSubmit">int是否是提交</param>
        /// <param name="LogCost">物流成本</param>
        /// <param name="Mobile">发货用户联系人手机</param>
        /// <param name="Email">发货用户联系人邮箱</param>
        /// <param name="isSendMail">0</param>
        /// <param name="Customer2">返件公司</param>
        /// <param name="Address2">返件地址</param>
        /// <param name="Zip2">返件邮编</param>
        /// <param name="Contact2">返件联系人</param>
        /// <param name="Tel2">返件电话</param>
        /// <param name="Fax2">返件传真</param>
        /// <returns></returns>
        [WebMethod]
        public string funString_SaveRequest(string DispatchID, string CostNoType, string BookNo, string ServiceOrderNo, string s4000No, string ConsignorKind, string CustomerName, string Address, string Zip,
          string Contact, string Tel, string Fax, string DevDate, string ReturnDate, string Comments, string DomainInfo,
          string CustomerName1, string Address1, string Zip1, string Contact1, string Tel1, string Fax1, string OutAddress, string Province,
            string City, string ContractNo, string ServiceType, string Dept, int isSubmit, decimal LogCost, string Mobile, string Email, int isSendMail, string Customer2, string Address2, string Zip2, string Contact2, string Tel2, string Fax2
            )
        {
            DomainInfo = DomainInfo.Substring(DomainInfo.IndexOf("\\") + 1);
            string strSQL = "";
            bool isFind = funBoolean_DispatchExist(DispatchID);
            int CreateUser = funInt_AddUser(DomainInfo);
            if (CreateUser == 0)
            {
                CreateUser = funInt_AddUser(DomainInfo);
            }
            ConsignorKind = Server.UrlDecode(ConsignorKind);
            CustomerName = Server.UrlDecode(CustomerName);
            CostNoType = Server.UrlDecode(CostNoType);
            BookNo = Server.UrlDecode(BookNo);
            Address = Server.UrlDecode(Address);
            Zip = Server.UrlDecode(Zip);
            Contact = Server.UrlDecode(Contact);
            Tel = Server.UrlDecode(Tel);
            Fax = Server.UrlDecode(Fax);
            DevDate = Server.UrlDecode(DevDate);


            TimeSpan ts1 = new TimeSpan(DevDate.funDateTime_StringToDatetime().Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int DevHours = ts.Hours;

            //DevDate = DateTime.Now.AddHours(DevHours).ToString("yyyy-MM-dd HH:mm:ss");

            ReturnDate = Server.UrlDecode(ReturnDate);
            Comments = Server.UrlDecode(Comments);
            CustomerName1 = Server.UrlDecode(CustomerName1);
            Address1 = Server.UrlDecode(Address1);
            Zip1 = Server.UrlDecode(Zip1);
            Contact1 = Server.UrlDecode(Contact1);
            Fax1 = Server.UrlDecode(Fax1);
            OutAddress = Server.UrlDecode(OutAddress);
            Province = Server.UrlDecode(Province);
            City = Server.UrlDecode(City);
            ContractNo = Server.UrlDecode(ContractNo);
            ServiceType = Server.UrlDecode(ServiceType);
            Dept = Server.UrlDecode(Dept);
            int intSendMail = isSendMail.ToString().funInt_BoolToString();

            Customer2 = Server.UrlDecode(Customer2);
            Address2 = Server.UrlDecode(Address2);
            Zip2 = Server.UrlDecode(Zip2);
            Contact2 = Server.UrlDecode(Contact2);
            Tel2 = Server.UrlDecode(Tel2);
            Fax2 = Server.UrlDecode(Fax2);


            string SalesOrderNo = "";
            string WBSNo = "";
            string CostCenter = "";
            string RepairOrderNo = "";

            switch (CostNoType.ToLower())
            {
                case "sales order no":
                    SalesOrderNo = BookNo;
                    break;
                case "wbs element no":
                    WBSNo = BookNo;
                    break;
                case "cost center":
                    CostCenter = BookNo;
                    break;
                case "fs no":
                    ServiceOrderNo = BookNo;
                    break;
                case "repair no":
                    RepairOrderNo = BookNo;
                    break;
            }
            if (isFind)
            {
                strSQL = @"UPDATE SFAE_Other_DispatchRequestInfo
                         SET CostNoType ='" + CostNoType + "', SalesOrderNo ='" + SalesOrderNo + "', ServiceOrderNo ='" + ServiceOrderNo + "', WBSNo ='" + WBSNo + "', RepairOrderNo ='" + RepairOrderNo + "', s4000No ='" + s4000No + "', CostCenter ='" + CostCenter + "', ConsignorKind ='" + ConsignorKind + "',";
                strSQL += "CustomerName ='" + CustomerName + "', Address ='" + Address + "', Zip ='" + Zip + "', Contact ='" + Contact + "', Tel ='" + Tel + "', Fax ='" + Fax + "',";
                strSQL += "DevHours =" + DevHours + ", DevDate =" + Function.funString_StringToDBDate(DevDate.ToString()) + ", ReturnDate =" + Function.funString_StringToDBDate(ReturnDate.ToString());
                strSQL += ", Comments ='" + Comments + "',  CustomerName1 ='" + CustomerName1 + "',Address1 ='" + Address1 + "', Zip1 ='" + Zip1 + "', Contact1 ='" + Contact1 + "', Tel1 ='" + Tel1 + "', Fax1 ='" + Fax1 + "',  Province ='" + Province + "', City ='" + City + "',ContractNo='" + ContractNo + "',ServiceType='" + ServiceType + "',Dept='" + Dept + "',isSubmit=" + isSubmit + ",LogCost=" + LogCost + ",Mobile='" + Mobile + "',Email='" + Email + "',isSendMail=" + intSendMail + ",Customer2='" + Customer2 + "',Address2='" + Address2 + "',Zip2='" + Zip2 + "',Contact2='" + Contact2 + "',Tel2='" + Tel2 + "',Fax2='" + Fax2 + "',isLogReject=0 where ID='" + DispatchID + "'";
            }
            else
            {
                strSQL = @"insert INTO SFAE_Other_DispatchRequestInfo(ID, CostNoType, SalesOrderNo, ServiceOrderNo, WBSNo, RepairOrderNo, s4000No, CostCenter, 
                         ConsignorKind, CustomerName, Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, CreateUser,  
                         CustomerName1, Address1, Zip1, 
                         Contact1, Tel1, Fax1, OutAddress, Province, City,ContractNo,ServiceType,Dept,isSubmit,LogCost,Mobile,Customer2, Address2, Zip2, Contact2, Tel2, Fax2)
                         VALUES (";
                strSQL += "'" + DispatchID + "','" + CostNoType + "','" + SalesOrderNo + "','" + ServiceOrderNo + "','" + WBSNo + "','" + RepairOrderNo + "','" + s4000No + "','" + CostCenter + "'";
                strSQL += ",'" + ConsignorKind + "','" + CustomerName + "','" + Address + "','" + Zip + "','" + Contact + "','" + Tel + "','" + Fax + "'," + DevHours + "," + Function.funString_StringToDBDate(DevDate.ToString());
                strSQL += "," + Function.funString_StringToDBDate(ReturnDate.ToString()) + ",'" + Comments + "'," + CreateUser + ",'" + CustomerName1 + "','" + Address1 + "','" + Zip1 + "','" + Contact1 + "','" + Tel1 + "'";
                strSQL += ",'" + Fax1 + "','" + OutAddress + "','" + Province + "','" + City + "','" + ContractNo + "','" + ServiceType + "','" + Dept + "'," + isSubmit + "," + LogCost + ",'" + Mobile + "','" + Customer2 + "','" + Address2 + "','" + Zip2 + "','" + Contact2 + "','" + Tel2 + "','" + Fax2 + "')";
            }
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError != "")
            {
                DispatchID = "";
            }
            return DispatchID;
        }
        private bool funBoolean_DispatchExist(string DispatchID)
        {
            string strSQL = "";
            strSQL = "select count(*) from SFAE_Other_DispatchRequestInfo where ID='" + DispatchID + "'";
            return Function.funInt_StringToInt(objDbSQLAccess.funString_SQLExecuteScalar(strSQL), 0) > 0;
        }
        /// <summary>
        /// 删除发货单下所有物料
        /// </summary>
        /// <param name="DispatchID"></param>
        /// <returns></returns>
        [WebMethod]
        public bool funBoolean_DeleteItems(string DispatchID)
        {
            string strSQL = "";
            strSQL = "delete SFAE_Other_DispatchRequest_MaterialInfo where DispatchID='" + DispatchID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            return strError == "";
        }
        /// <summary>
        /// 物料项保存
        /// </summary>
        /// <param name="DispatchID">发货单ID</param>
        /// <param name="MLFB">MLFB</param>
        /// <param name="SerialNo">SerialNo</param>
        /// <param name="Quantity">Quantity</param>
        /// <returns></returns>
        [WebMethod]
        public bool funBoolean_SaveItems(string DispatchID, string MLFB, string SerialNo, int Quantity, string MaterialNo, string Batch, string SLocNo, string REM)
        {
            string strSQL = "";
            strSQL = @"INSERT INTO SFAE_Other_DispatchRequest_MaterialInfo(DispatchID, MLFB, SerialNo,Quantity,MaterialNo,Batch,SLocNo,REM) VALUES (";
            strSQL += "'" + DispatchID + "','" + MLFB + "','" + SerialNo + "'," + Quantity + ",'" + MaterialNo + "','" + Batch + "','" + SLocNo + "','" + REM + "')";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            return strError == "";
        }
        #endregion

        #region "Request Info"
        [WebMethod]
        public DataSet funDataset_MyRequestInfo(string DomainInfo)
        {
            DomainInfo = DomainInfo.Substring(DomainInfo.IndexOf("\\") + 1);
            DataSet ds = null;
            int CreateUser = funInt_AddUser(DomainInfo);
            if (CreateUser == 0)
            {
                CreateUser = funInt_AddUser(DomainInfo);
            }
            string strSQL = "";
            strSQL = @"SELECT        ID, DispatchType, ConsignmentDate, PickUpType, OperationCategory, ExpressNo, MainNo, AssistNo, RequestArriveDate, ActualArriveDate, SignUser, Status, 
                         RecordDate, Timelimit, ConsignorKind, TypeOfShipping, PickupAddress, DestinationAddress, CompanyName, CompanyAddress, CompanyConsignee, 
                         CompanyTel1, Qty, ActualWeight, CostWeight, UnitPrice, TransCost, TranCity, Kil, MorelongCost, PackCost, OtherCost, AddCost, PackMaterial, storeKeeper, 
                         OrderApplicant, forwardingAgents, sfaeComments
FROM            View_SFAE_LogisticSearchPlatForm_List where CreateUser=" + CreateUser;
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            return ds;
        }
        [WebMethod]
        public DataSet funDataset_MyRequestItemList(string DispatchID)
        {
            string strSQL = "";
            strSQL = @"SELECT   ID, DispatchID, MaterialNo, MLFB, SerialNo, Quantity, Batch, SLocNo, REM, CreateDate FROM SFAE_Other_DispatchRequest_MaterialInfo where DispatchID='" + DispatchID + "' order by CreateDate";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            return ds;
        }


        #endregion

        #region "Request List"
        [WebMethod]
        public string funString_RequestList(string args, string AdUser)
        {
            AdUser = AdUser.Substring(AdUser.IndexOf("\\") + 1);
            //_search=false&nd=1382607111049&rows=30&page=1&sidx=RequestID&sord=desc
            Type type = HttpContext.Current.Request.Form.GetType();
            type.GetMethod("MakeReadWrite", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(HttpContext.Current.Request.Form, null);
            int OrderApplicantID = 0;
            if (AdUser != "")
            {
                OrderApplicantID = fuInt_getUserID(AdUser);
                if (OrderApplicantID == 0)
                {
                    OrderApplicantID = funInt_AddUser(AdUser);
                }
            }

            string[] ary = args.Split('&');
            for (int i = 0; i < ary.Length; i++)
            {
                string[] aryitem = ary[i].Split('=');
                HttpContext.Current.Request.Form.Add(aryitem[0], aryitem[1]);
            }

            string SearchPeriod = HttpContext.Current.funString_RequestFormValue("SearchPeriod");
            if (SearchPeriod == "")
            {
                SearchPeriod = "12";
            }
            string SearchField = HttpContext.Current.funString_RequestFormValue("SearchField");
            if (SearchField == "")
            {
                SearchField = "All";
            }
            string SearchValue = HttpContext.Current.funString_RequestFormValue("SearchValue");
            string strReturn = "";
            IVList vlst = new CVList(new View_SFAE_LogisticSearchPlatForm_List(), HttpContext.Current
                         , @"ID,DispatchType, ConsignmentDate, PickUpType, OperationCategory, ExpressNo, MainNo, AssistNo, ContractNo,RequestArriveDate, ActualArriveDate, SignUser, Status, 
                         RecordDate, Timelimit, ConsignorKind, TypeOfShipping, PickupAddress, DestinationAddress, CompanyName, CompanyAddress, CompanyConsignee, 
                         CompanyTel1, Qty, ActualWeight, CostWeight, UnitPrice, TransCost, TranCity, Kil, MorelongCost, PackCost, OtherCost, AddCost, PackMaterial, storeKeeper, 
                         OrderApplicant, forwardingAgents, sfaeComments,SupplierCode");
            string strPeriodSQL = "(CreateDate>= DATEADD(MM,-" + SearchPeriod + ", GETDATE()))";
            string strFieldSQL = "";
            if (SearchField == "All")
            {
                strFieldSQL = "((ExpressNo like '%" + SearchValue + "%') or (MainNo like '%" + SearchValue + "%')  or (ContractNo like '%" + SearchValue + "%') or (AssistNo like '%" + SearchValue + "%') or (CompanyName like '%" + SearchValue + "%') or (CompanyAddress like '%" + SearchValue + "%'))";
            }
            else
            {
                strFieldSQL = "((" + SearchField + " like '%" + SearchValue + "%'))";
            }
            if (OrderApplicantID == 0)
            {
                vlst.ExtendCondition = strPeriodSQL + " and " + strFieldSQL;
            }
            else
            {
                vlst.ExtendCondition = strPeriodSQL + " and " + strFieldSQL + " and (OrderApplicantID=" + OrderApplicantID + ")";
            }
            strReturn = vlst.getData();
            return strReturn;
        }
        #endregion

        #region "Dispatch Basic info"
        [WebMethod]
        public DataSet funDataSet_CostNoType()
        {
            string strSQL = "SELECT CostNoType FROM SFAE_Other_Basic_CostNoTypeInfo";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_ServiceType()
        {
            string strSQL = "SELECT  ServiceType, ServiceType+':'+ServiceTypeDesc FROM SFAE_Logistic_Basic_ServiceType_Info";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_ConsignorKind()
        {
            string strSQL = "select ConsignorKind from webInfo_Basic_Sfae_Exch_ConsignorKind_Info where sType like '%,Other,%'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_OutAddress()
        {
            string strSQL = "select Address from webInfo_Basic_Sfae_Exch_OutAddress_Info";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_Province(string P)
        {
            string strSQL = @"SELECT ID, StructureName FROM Public_Basic_CountryStructureInfo WHERE (Type = 2) and StructureName like '%" + P + "%'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_City(string Province, string City)
        {
            string strSQL = @"SELECT        c.ID, c.StructureName, c1.StructureName AS Province
FROM            dbo.Public_Basic_CountryStructureInfo AS c INNER JOIN
                         dbo.Public_Basic_CountryStructureInfo AS c1 ON c.ParentID = c1.ID
WHERE        (c.Type = 3) and c1.StructureName='" + Province + "'";// and StructureName like '%" + City + "%'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_Dept()
        {
            string strSQL = @"SELECT Dept FROM SFAE_Other_Basic_DeptInfo order by Dept";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }

        [WebMethod]
        public DataSet funDataSet_DispatchInfoEx(string DispatchID)
        {
            string strSQL = "";
            strSQL = @"SELECT        d.CostNoType, d.SalesOrderNo, d.ServiceOrderNo, d.ContractNo, d.WBSNo, d.RepairOrderNo, d.s4000No, d.CostCenter, d.ConsignorKind, d.CustomerName, d.Address, d.Zip, d.Contact, d.Tel, d.Fax, d.DevHours, 
                         d.DevDate, d.ReturnDate, d.Comments, d.CreateDate, d.islogSee, d.isSendSpare, d.reDevdate, d.oldSpareReturnRemark, d.SendSpareTime, d.SpareType, d.isLogReject, d.LogRejectComments, 
                         d.CustomerName1, d.Address1, d.Zip1, d.Contact1, d.Tel1, d.Fax1, d.OtherMaterialList, d.OutAddress, d.isAppend, d.isActOut, d.serviceType, d.Province, d.City, d.LogCost, d.iscancel, d.Dept, d.Mobile, 
                         d.Customer2, d.Address2, d.Zip2, d.Contact2, d.Tel2, d.Fax2, l.EnUserName AS CreateUser
FROM            dbo.SFAE_Other_DispatchRequestInfo AS d LEFT OUTER JOIN
                         dbo.webInfo_loginInfo AS l ON d.CreateUser = l.ID where d.ID='" + DispatchID + "'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        /// <summary>
        /// 取得发货单信息
        /// </summary>
        /// <param name="DispatchID">发货单ID</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet funDataSet_DispatchInfo(string DispatchID)
        {
            string strSQL = "";
            strSQL = @"SELECT  CostNoType, SalesOrderNo, ServiceOrderNo, ContractNo, WBSNo, RepairOrderNo, s4000No, CostCenter, ConsignorKind, 
                         CustomerName, Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, CreateDate, CreateUser, islogSee, isSendSpare, reDevdate, 
                         oldSpareReturnRemark, SendSpareTime, SpareType, isLogReject, LogRejectComments, CustomerName1, Address1, Zip1, Contact1, Tel1, Fax1, 
                         OtherMaterialList, OutAddress, isAppend, isActOut, serviceType, Province, City, LogCost, iscancel,dept,Mobile,Customer2, Address2, Zip2, Contact2, Tel2, Fax2
                        FROM SFAE_Other_DispatchRequestInfo where ID='" + DispatchID + "'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataset_LastDispatch(string AdUser)
        {
            AdUser = AdUser.Substring(AdUser.IndexOf("\\") + 1);
            int OrderApplicantID = 0;
            if (AdUser != "")
            {
                OrderApplicantID = fuInt_getUserID(AdUser);
                if (OrderApplicantID == 0)
                {
                    OrderApplicantID = funInt_AddUser(AdUser);
                }
            }
            string strSQL = @"SELECT top 1  CostNoType, SalesOrderNo, ServiceOrderNo, ContractNo, WBSNo, RepairOrderNo, s4000No, CostCenter, ConsignorKind, 
                         CustomerName, Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, CreateDate, CreateUser, islogSee, isSendSpare, reDevdate, 
                         oldSpareReturnRemark, SendSpareTime, SpareType, isLogReject, LogRejectComments, CustomerName1, Address1, Zip1, Contact1, Tel1, Fax1, 
                         OtherMaterialList, OutAddress, isAppend, isActOut, serviceType, Province, City, LogCost, iscancel,dept,Mobile
                        FROM SFAE_Other_DispatchRequestInfo where CreateUser=" + OrderApplicantID + " order by createdate desc";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataSet_ExpressPriceList(string Province, string City)
        {
            string strSQL = "";
            if (City == "")
            {
                strSQL = @"SELECT   ID, OrderNo, Region, Province, City, TimeLimit, KG, LimitKG, UnPrice, LowPrice, CreateDate
FROM            SFAE_Other_Basic_ExpressPriceInfo where Province like '%" + Province + "%' and UnPrice>0";
            }
            else
            {
                strSQL = @"SELECT   ID, OrderNo, Region, Province, City, TimeLimit, KG, LimitKG, UnPrice, LowPrice, CreateDate
FROM            SFAE_Other_Basic_ExpressPriceInfo where Province like '%" + Province + "%' and charindex(City,'" + City + "')>0 and UnPrice>0";
            }
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

        }
        #endregion

        #region "DispatchList"
        [WebMethod]
        public int funInt_DispatchStatus(string DispatchID)
        {
            string strSQL = "";
            strSQL = @"SELECT    isLogReject FROM SFAE_Other_DispatchRequestInfo where ID='" + DispatchID + "'";
            bool isReject = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funBoolean_StringToBoolean();
            if (!isReject)
            {
                strSQL = "select status from View_SFAE_LogisticSearchPlatForm_DispatchList where ID='" + DispatchID + "'";
                return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            }
            else
            {
                return 9;
            }
        }
        [WebMethod]
        public DataSet funDataset_RequestInfo(string ID)
        {
            string strSQL = @"SELECT  DispatchType, ConsignmentDate, PickUpType, OperationCategory, ExpressNo, MainNo, AssistNo, RequestArriveDate, ActualArriveDate, 
                         SignUser, Status, RecordDate, Timelimit, ConsignorKind, TypeOfShipping, PickupAddress, DestinationAddress, CompanyName, CompanyAddress, 
                         CompanyConsignee, CompanyTel1,CompanyTel2,CompanyTel3, Qty, ActualWeight, CostWeight, UnitPrice, TransCost, TranCity, Kil, MorelongCost, PackCost, OtherCost, AddCost, 
                         PackMaterial, OrderApplicant, forwardingAgents, sfaeComments, CreateDate, OrderApplicantID, storeKeeper, DispatchID,SupplierCode,Hotline
                        FROM View_SFAE_LogisticSearchPlatForm_List where ID='" + ID + "'";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public DataSet funDataset_TimeInfo(string DispatchID)
        {
            string strSQL = @"SELECT   ID, MainID, RecordDate, IsCurrent, Status, CreateDate FROM SFAE_Logistic_Main_StatusInfo where MainID='" + DispatchID + "' order by RecordDate";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        [WebMethod]
        public string funString_DispatchList(string args, string AdUser)
        {
            AdUser = AdUser.Substring(AdUser.IndexOf("\\") + 1);
            //_search=false&nd=1382607111049&rows=30&page=1&sidx=RequestID&sord=desc
            Type type = HttpContext.Current.Request.Form.GetType();
            type.GetMethod("MakeReadWrite", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(HttpContext.Current.Request.Form, null);
            int OrderApplicantID = 0;
            if (AdUser != "")
            {
                OrderApplicantID = fuInt_getUserID(AdUser);
                if (OrderApplicantID == 0)
                {
                    OrderApplicantID = funInt_AddUser(AdUser);
                }
            }

            string[] ary = args.Split('&');
            for (int i = 0; i < ary.Length; i++)
            {
                string[] aryitem = ary[i].Split('=');
                HttpContext.Current.Request.Form.Add(aryitem[0], aryitem[1]);
            }

            string SearchPeriod = HttpContext.Current.funString_RequestFormValue("SearchPeriod");
            if (SearchPeriod == "")
            {
                SearchPeriod = "12";
            }
            string SearchField = HttpContext.Current.funString_RequestFormValue("SearchField");
            if (SearchField == "")
            {
                SearchField = "All";
            }
            string SearchValue = HttpContext.Current.funString_RequestFormValue("SearchValue");
            string strReturn = "";
            IVList vlst = new CVList(new View_SFAE_LogisticSearchPlatForm_DispatchList(), HttpContext.Current
                         , @" ID, RequestID, SalesOrderNo, ServiceOrderNo, ContractNo, WBSNo, RepairOrderNo, s4000No, CostCenter, ConsignorKind, CustomerName, 
                         Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, CreateDate, CreateUser, CustomerName1, Address1, Zip1, Contact1, Tel1, Fax1, 
                         OtherMaterialList, OutAddress, serviceType, Province, City,Status");
            string strPeriodSQL = "(CreateDate>= DATEADD(MM,-" + SearchPeriod + ", GETDATE()))";
            string strFieldSQL = "";
            if (SearchField == "All")
            {
                strFieldSQL = "((SalesOrderNo like '%" + SearchValue + "%') or (ContractNo like '%" + SearchValue + "%') or (ServiceOrderNo like '%" + SearchValue + "%') or (s4000No like '%" + SearchValue + "%') or (CustomerName like '%" + SearchValue + "%') or (CustomerName1 like '%" + SearchValue + "%'))";
            }
            else
            {
                strFieldSQL = "((" + SearchField + " like '%" + SearchValue + "%'))";
            }
            if (OrderApplicantID == 0)
            {
                vlst.ExtendCondition = strPeriodSQL + " and " + strFieldSQL;
            }
            else
            {
                vlst.ExtendCondition = strPeriodSQL + " and " + strFieldSQL + " and (CreateUser=" + OrderApplicantID + ")";
            }
            strReturn = vlst.getData();
            return strReturn;
        }

        [WebMethod]
        public DataSet funDataSet_SendMailInfo()
        {
            string strSQL = "SELECT top 1 sendMail, UserName, UserPwd, SmtpServer, getMail FROM webInfo_Basic_SfaeExch_Log_Mail_Info";
            return objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
        }
        #endregion

        #region "Copy Case"
        [WebMethod]
        public string funString_CopyCase(string DispatchID)
        {
            string strSQL = "";
            string NID = Guid.NewGuid().ToString();
            strSQL = @"INSERT INTO SFAE_Other_DispatchRequestInfo
                         (ID, RequestID, CostNoType, SalesOrderNo, ServiceOrderNo, ContractNo, WBSNo, RepairOrderNo, s4000No, CostCenter, ConsignorKind, CustomerName, 
                         Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, CreateDate, CreateUser, reDevdate, 
                         CustomerName1, Address1, Zip1, Contact1, Tel1, Fax1, 
                         OtherMaterialList, OutAddress,serviceType, Province, City, LogCost, Dept, isSubmit,Mobile, Email, Customer2, Address2, Zip2, Contact2, Tel2, Fax2)";
            strSQL += @"SELECT '" + NID + "', RequestID, CostNoType, SalesOrderNo, ServiceOrderNo, ContractNo, WBSNo, RepairOrderNo, s4000No, CostCenter, ConsignorKind, ";
            strSQL += @"CustomerName, Address, Zip, Contact, Tel, Fax, DevHours, DevDate, ReturnDate, Comments, getdate(), CreateUser, reDevdate, 
                         CustomerName1, Address1, Zip1, Contact1, Tel1, Fax1, 
                         OtherMaterialList, OutAddress, serviceType, Province, City, 0, Dept, 0,Mobile, Email, Customer2, Address2, Zip2, Contact2, Tel2, Fax2
                    FROM SFAE_Other_DispatchRequestInfo AS SFAE_Other_DispatchRequestInfo_1 where ID='" + DispatchID + "'";
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError == "")
            {
                return NID;
            }
            return "";

        }
        #endregion

        #region "删除记录"
        [WebMethod]
        public string funString_DeleteCase(string DispatchID)
        {
            string strSQL = "select isSendSpare from SFAE_Other_DispatchRequestInfo where ID='" + DispatchID + "'";
            bool isSubmit = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funBoolean_StringToBoolean();
            if (isSubmit)
            {
                return "1";
            }
            strSQL = "delete SFAE_Other_DispatchRequestInfo where ID='" + DispatchID + "'";
            return objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
        }
        #endregion
        #region "SFAE_Other_Basic_EmailLog"
        [WebMethod]
        public void subUpdate_EmailInfo(string Email, string AdName)
        {
            string strSQL = "";
            strSQL = "select id from SFAE_Other_Basic_EmailLog where Email='" + Email + "' and AdName='" + AdName + "'";
            string LogID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            if (LogID == "")
            {
                strSQL = @"INSERT INTO SFAE_Other_Basic_EmailLog(Email, AdName) VALUES (";
                strSQL += "'" + Email + "','" + AdName + "')";
                objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
        }
        [WebMethod]
        public string funString_EmailLog(string AdName)
        {
            string strSQL = @"SELECT Email FROM SFAE_Other_Basic_EmailLog where AdName='" + AdName + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.AppendLine(ds.Tables[0].Rows[i]["Email"].ToString());
                }
            }
            return sb.ToString();
        }
        #endregion

    }
}
