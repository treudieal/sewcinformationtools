using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.ClassLibrary.Control
{
    public class ClassSMS
    {
        IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();

        //插入一条短信
        public Boolean subDoSendMessage(int ExpressLevel, string Sender, string ReceiverMobileNo, string Msg, string SendTime, int IsChinese, int CommPort, int NeedReport)
        {
            string strError = "";
            string strSQL = "";
            ArrayList ary = new ArrayList();
            ary = aryContent(Msg);
            for (int i = 0; i <= ary.Count - 1; i++)
            {
                strSQL = "";
                strSQL = "INSERT INTO outbox(ExpressLevel, Sender, ReceiverMobileNo, Msg, SendTime, IsChinese, CommPort, NeedReport) VALUES (";
                strSQL = strSQL + ExpressLevel + ",'" + Sender + "','" + ReceiverMobileNo + "','" + ary[i].ToString() + "','" + SendTime + "'," + IsChinese + "," + CommPort + "," + NeedReport + ")";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            if (strError == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //返回一个Array用于判断是内容多于70个字
        private ArrayList aryContent(string strContent)
        {
            ArrayList ary = new ArrayList();
            int intLen = 0;
            int intMultiples = 0;
            intLen = strContent.Length;
            //当小于70直接返回
            if (intLen < 70)
            {
                ary.Add(strContent);
                return ary;
            }
            intMultiples = intLen / 69;
            for (int i = 0; i <= intMultiples; i++)
            {
                string strTmp = "";
                if (strContent.Substring(i * 69).Length >= 69)
                {
                    strTmp = strContent.Substring(i * 69, 69);
                }
                else
                {
                    strTmp = strContent.Substring(i * 69);
                }
                ary.Add(strTmp);
            }
            return ary;
        }
    }
}