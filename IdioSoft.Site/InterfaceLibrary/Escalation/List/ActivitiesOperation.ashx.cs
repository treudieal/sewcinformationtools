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
    /// Summary description for ActivitiesOperation
    /// </summary>
    public class ActivitiesOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            IVList vlst = new CVList(new View_Escalation_Activity_List(), context
, "ActivityID,CreateUser,CreatedDate, CurrentStatus, NextStep ");

            string EscalationID = context.funString_RequestFormValue("EscalationID");
            if (EscalationID != "")
            {
                vlst.ExtendCondition = "EscalationID='" + EscalationID + "'";
            }
            string strReturn = vlst.getData();

            context.Response.Write(strReturn);
        }
    }
}