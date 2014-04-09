using IdioSoft.Business.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.ClassLibrary.SEWC
{
    public class Util
    {
        public static string funString_ProductDate(string SerialNo)
        {
            string strReturn = "";
            SerialNo = SerialNo.ToLower();
            try
            {
                if (SerialNo == "")
                {
                    return "";
                }
                if (SerialNo.Length < 2)
                {
                    return "";
                }
                string sYear = "";
                string sMonth = "";

                if (SerialNo.Substring(0, 1) == "v")
                {
                    SerialNo = "s"+SerialNo;
                }

                if (SerialNo.Substring(0, 2) == "sv")
                {
                    sYear = SerialNo.Substring(3, 1);
                    sMonth = SerialNo.Substring(4, 1);
                }


                IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
                string strSQL = "select Years from SEWC_Basic_SerialNo_YearInfo where Code='" + sYear + "'";
                sYear = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                strSQL = "select Months from SEWC_Basic_SerialNo_MonthInfo where Code='" + sMonth + "'";
                sMonth = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                strReturn = sYear + "-" + sMonth;
            }
            catch (Exception)
            {

            }
            return strReturn;
        }

        public static string funString_FactoryOforigin(string SerialNo)
        {
            SerialNo = SerialNo.ToUpper();
            string strReturn = "";
            if (SerialNo == "")
            {
                return "";
            }
            if (SerialNo.Length < 2)
            {
                return "";
            }
            try
            {
                if (SerialNo.Substring(0, 1) == "S")
                {
                    SerialNo = SerialNo.Substring(1);
                }
                if (SerialNo.Substring(0, 1) == "C")
                {
                    return "EWA";
                }
                if (SerialNo.Substring(0, 1) == "V")
                {
                    return "SEWC";
                }
                if (SerialNo.Substring(0, 2) == "V")
                {
                    return "SNC";
                }
            }
            catch (Exception)
            {
  
            }

            return strReturn;
        }
    }
}