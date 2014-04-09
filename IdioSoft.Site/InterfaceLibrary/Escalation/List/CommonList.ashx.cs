using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.Escalation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.Escalation.List
{
    /// <summary>
    /// Summary description for CommonList
    /// </summary>
    public class CommonList : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string status = context.funString_RequestFormValue("Status");

            IVList vlst = new CVList(new View_Escalation_List(), context
, "EscalationID, ERNo, SRNo, AppCompany, EndUser, Contact, OC, ProductDesc, MLFB, SN, Abstract, Remark, Status, Type, Priority, EscalationBy, Owner, CreatedDate");

            switch (status)
            {
                case "Open":
                    vlst.ExtendCondition = "Status='" + "Open" + "'";
                    break;
                case "InProcess":
                    vlst.ExtendCondition = "Status='" + "InProcess" + "'";
                    break;
                case "Pending":
                    vlst.ExtendCondition = "Status='" + "Pending" + "'";
                    break;
                case "Finish":
                    vlst.ExtendCondition = "Status='" + "Finish" + "'";
                    break;
                case "All":
                    break;
                default:
                    break;
            }

            string strReturn = vlst.getData();

            context.Response.Write(strReturn);

        }

 
    }
}