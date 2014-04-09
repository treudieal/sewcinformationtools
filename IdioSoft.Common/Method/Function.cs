using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Web.UI;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mail;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
 

namespace IdioSoft.Common.Method
{
    public static class Function
    {
        public enum SelectAdapterType
        {
            Value = 0,
            Text = 1
        }

        #region "�����˵�"
         
        #endregion

        /// <summary>
        /// ���ò�����
        /// </summary>
        #region "����ת������"
        /// <summary>
        /// ����ʽJs��Alert��ʾ���ַ���
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string funString_JsToString(this string strValue)
        {

            string strTmp;
            strTmp = strValue;

            if ((strTmp != string.Empty) && (strTmp != ""))
            {
                strTmp = strTmp.Replace("'", "��");
                strTmp = strTmp.Replace("\"", "��");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// ���ַ�����ʽ��Ϊ����SQL���ַ���
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        //public static string funString_SQLToString(this string strValue)
        //{
        //    string strTmp;
        //    strTmp = strValue;
        //    if ((strTmp == string.Empty) || (strTmp != ""))
        //    {
        //        strTmp = strTmp.Replace("'", "��");
        //        strTmp = strTmp.Replace("%", "��");
        //    }
        //    else
        //    {

        //        strTmp = "";
        //    }
        //    return strTmp;
        //}
        //public static DateTime funDateTime_StringToDatetime(this string strValue)
        //{
        //    if (Microsoft.VisualBasic.Information.IsDate(strValue))
        //    {
        //        return DateTime.Parse(strValue);
        //    }
        //    else
        //    {
        //        return DateTime.Parse("1900-01-01");
        //    }
        //}
        ///// <summary>
        ///// ����Ϊ�յ�����
        ///// </summary>
        ///// <param name="strValue"></param>
        ///// <returns></returns>
        //public static DateTime? funDateTime_StringToDatetimeAllowNull(this string strValue)
        //{
        //    if (strValue.Trim() == "")
        //    {
        //        return null;
        //    }
        //    if (Microsoft.VisualBasic.Information.IsDate(strValue))
        //    {
        //        return DateTime.Parse(strValue);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public static string funString_StringToDatetime(this DateTime dt)
        //{
        //    if (dt.Year == 1900)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return dt.ToString("yyyy-MM-dd HH:mm:ss");
        //    }
        //}

        //public static string funString_StringToDatetime(this DateTime? dt)
        //{
        //    if (dt == null)
        //    {
        //        return null;
        //    }
        //    DateTime d1 = (DateTime)dt;
        //    if (d1.Year == 1900)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return d1.ToString("yyyy-MM-dd HH:mm:ss");
        //    }
        //}

        public static string funString_FileNameFormat(this string strName)
        {
            strName = strName.Replace("\\", "");
            strName = strName.Replace(" ", "");
            strName = strName.Replace(".", "");
            strName = strName.Replace("/", "");
            return strName;
        }
        /// <summary>   
        /// ������ʽ������SQL���ַ���ת��Ϊ����SQL���
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        public static string funString_StringToSQL(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("��", "'");
                strTmp = strTmp.Replace("��", "%");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// ��ʽ����URL��ת���ַ���������URL��ֵ���ַ���
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        public static string funString_RequestToString(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("?", "��");
                strTmp = strTmp.Replace("&", "��");
                strTmp = strTmp.Replace("=", "��");
                strTmp = strTmp.Replace("/", "��");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// ������ʽ������URL���ַ���ת��Ϊ����URL���
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        public static string funString_StringToRequest(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("��", "?");
                strTmp = strTmp.Replace("��", "&");
                strTmp = strTmp.Replace("��", "=");
                strTmp = strTmp.Replace("��", "/");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>
        /// ���ַ�����ʽ����XML,��Ҫ�ǽ������ַ�ת��ΪXML�����ַ�
        /// </summary>
        /// <param name="strContent">�ַ���</param>
        /// <returns></returns>
        public static string funString_StringToXML(this string strContent)
        {
            string strTemp = "";
            if (strContent == "")
            {
                return strTemp;
            }
            else
            {
                strContent = strContent.Replace("<", "&lt;");
                strContent = strContent.Replace(">", "&gt;");
                strContent = strContent.Replace("&", "&amp;");
                strContent = strContent.Replace("'", "&apos;");
                strContent = strContent.Replace("\"", "&quot;");
                return strContent;
            }
        }
        /// <summary>   
        /// ������ת����Ӣ����д����Jan.,Feb.��
        /// </summary>   
        /// <param name="intMonth">����1��12������</param>
        public static string funString_NumMonthToEnglishAbb(this int intMonth)
        {
            string[] aryMonthAbb = { "Jan.", "Feb.", "Mar.", "Arp.", "May.", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec." };
            return aryMonthAbb[intMonth - 1];
        }
        /// <summary>
        /// ���ַ�ת��ΪAscw��ʽ
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string funString_AscW(this string strContent)
        {
            return Microsoft.VisualBasic.Strings.AscW(strContent).ToString();
        }
        /// <summary>
        /// ���ַ�ת��ΪbooleanŪ��������true��Ϊtrue,�����0��Ϊfalse����0����1
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        //public static Boolean funBoolean_StringToBoolean(this string strContent)
        //{
        //    if (strContent.ToLower() == "true")
        //    {
        //        return true;
        //    }
        //    if (strContent.ToLower() == "false")
        //    {
        //        return false;
        //    }
        //    int intContent = funInt_StringToInt(strContent, 0);
        //    if (intContent > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion
        #region "���ڲ���"
        /// <summary>   
        /// �õ���ʼʱ�䵽����ʱ���м����ʱ����
        /// </summary>   
        /// <param name="strInterval">���yyyy��,q��,m��,yһ�������,d��,wһ�ܵ�����,ww��,hʱ,n����,s��</param>
        /// <param name="dtStartDate">��ʼ����</param>
        /// <param name="dtEndDate">��������</param>
        public static int funInt_DateInterval(this string strInterval, DateTime dtStartDate, DateTime dtEndDate)
        {
            return (int)Microsoft.VisualBasic.DateAndTime.DateDiff(strInterval, dtStartDate, dtEndDate, 0, 0);
        }
        /// <summary>   
        /// �õ��������ܼ�,��������,����:0Ϊ������.
        /// </summary>   
        /// <param name="dtCurrentDate">����</param>
        public static int ReturnWeekDayNumeric(this DateTime dtCurrentDate)
        {

            int intWeekDay = 0;

            switch (dtCurrentDate.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    intWeekDay = 5;
                    break;
                case DayOfWeek.Monday:
                    intWeekDay = 1;
                    break;
                case DayOfWeek.Saturday:
                    intWeekDay = 6;
                    break;
                case DayOfWeek.Sunday:
                    intWeekDay = 7;
                    break;
                case DayOfWeek.Thursday:
                    intWeekDay = 4;
                    break;
                case DayOfWeek.Tuesday:
                    intWeekDay = 2;
                    break;
                case DayOfWeek.Wednesday:
                    intWeekDay = 3;
                    break;
                default:
                    intWeekDay = 0;
                    break;
            }
            return intWeekDay;
        }
        #endregion
        #region"��֤����"
        /// <summary>   
        /// ��֤�Ƿ�������,����Ƿ���true,����false
        /// </summary>   
        /// <param name="intYear">���</param>
        public static bool funBoolean_LeapYear(this int intYear)
        {
            if (intYear % 400 == 0 || ((intYear % 4 == 0) && (intYear % 100 != 0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽ�绰����,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strTel">�绰����</param>
        public static Boolean funBoolean_ValidTel(this string strTel)
        {
            return Regex.IsMatch(strTel, @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?");
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽ�ֻ�����,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strMobile">�ֻ�����</param>
        public static Boolean funBoolean_ValidMobile(this string strMobile)
        {
            return Regex.IsMatch(strMobile, @"\d{11}");
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽ��������,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strPostCode">��������</param>
        public static Boolean funBoolean_ValidPostcode(this string strPostCode)
        {
            return Regex.IsMatch(strPostCode, @"\d{6}");
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽEmail,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strEmail">Email</param>
        public static bool funBoolean_ValidEmail(this string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽ����ʱ��,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strDate">���ڸ�ʽ</param>
        public static bool funBoolean_ValidDate(this string strDate)
        {
            if (Microsoft.VisualBasic.Information.IsDate(strDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>   
        /// ��֤�Ƿ�����ȷ��ʽ����,����Ƿ���true,����false
        /// </summary>   
        /// <param name="strNum">Email</param>
        public static bool funBoolean_ValidNumeric(this string strNum)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strNum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region "������֤���������ҷ���ֵ"
        /// <summary>   
        /// ��֤�Ƿ�������,���true����strValue,false����intDefault
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        /// <param name="intDefault">Ĭ��ֵ</param>
        //public static int funInt_StringToInt(this string strValue, int intDefault)
        //{
        //    if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
        //    {
        //        try
        //        {

        //            return (int)(strValue.funDec_StringToDecimal(0));
        //        }
        //        catch
        //        {
        //            return intDefault;
        //        }
        //    }
        //    else
        //    {
        //        return intDefault;
        //    }
        //}
        //public static long funInt_StringToLong(this string strValue, long intDefault)
        //{
        //    if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
        //    {
        //        try
        //        {

        //            return (long)(strValue.funDec_StringToDecimal(0));
        //        }
        //        catch
        //        {
        //            return intDefault;
        //        }
        //    }
        //    else
        //    {
        //        return intDefault;
        //    }
        //}

        /// <summary>   
        /// ��֤�Ƿ�������,���true,���ж��Ƿ���intMin��intMax֮��,���true����strValue,false����intDefault
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        /// <param name="intMin">�������С����ֵ</param>
        /// <param name="intMax">������������ֵ</param>
        /// <param name="intDefault">Ĭ��ֵ</param>
        //public static int funInt_StringToInt(this string strValue, int intMin, int intMax, int intDefault)
        //{
        //    if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
        //    {
        //        int intValue;
        //        intValue = int.Parse(strValue);
        //        if (intMin <= intValue && intValue <= intMax)
        //        {
        //            return intValue;
        //        }
        //        else
        //        {
        //            return intDefault;
        //        }
        //    }
        //    else
        //    {
        //        return intDefault;
        //    }
        //}
        /// <summary>   
        /// ��֤�Ƿ�������,���ҷ���decimal(��С��������),���true����strValue,false����intDefault
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        /// <param name="decDefault">Ĭ��ֵ</param>
        //public static decimal funDec_StringToDecimal(this string strValue, decimal decDefault)
        //{
        //    if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
        //    {
        //        return decimal.Parse(strValue);
        //    }
        //    else
        //    {
        //        return decDefault;
        //    }
        //}
        /// <summary>   
        /// ��֤�Ƿ���Uniqueidentifier��ʽ,���ҷ���string,���true����strValue,false����strDefault
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        /// <param name="strDefault">Ĭ��ֵ</param>
        public static string funUuid_StringToUniqueidentifier(this string strValue, string strDefault)
        {
            if (strValue == null || strValue == "")
            {
                return strDefault;
            }
            else
            {
                return strValue;
            }
        }

        /// <summary>
        /// ����GUID,��Ϊ��
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static Guid? funGuid_StringToGuid(this string strValue)
        {
            Guid? gid = null;
            try
            {
                gid = new Guid(strValue);
            }
            catch (Exception)
            {
  
            }
            return gid;
        }

        /// <summary>
        /// ��boolean���ַ�ת��Ϊint
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        //public static int funInt_StringOrBooleanToInt(this string strValue)
        //{
        //    if (strValue.Trim().ToLower() == "true")
        //    {
        //        return 1;
        //    }
        //    if (strValue.Trim().ToLower() == "false")
        //    {
        //        return 0;
        //    }
        //    return strValue.funInt_StringToInt(0);
        //}
        /// <summary>   
        /// ��Bool�ַ���ת��Ϊ0,1
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        //public static int funInt_BoolToString(this string strValue)
        //{
        //    return (strValue.Trim().ToLower() == "true") ? 1 : 0;
        //}
        /// <summary>   
        /// ��֤�Ƿ���ʱ�䣬���ҷ������ݿ�������ַ��������''����ô����null�����򣬷���'+date+'
        /// </summary>   
        /// <param name="strValue">�ַ���</param>
        //public static string funString_StringToDBDate(this string strValue)
        //{
        //    if (strValue == null)
        //    {
        //        return "NULL";
        //    }
        //    if (strValue == "")
        //    {
        //        return "NULL";
        //    }
        //    else
        //    {
        //        if (funBoolean_ValidDate(strValue))
        //        {
        //            return "'" + strValue + "'";
        //        }
        //        else
        //        {
        //            return "NULL";
        //        }
        //    }
        //}
        ///// <summary>   
        ///// ��֤�Ƿ���ʱ�䣬���ҷ������ݿ�������ַ��������''����ô����null�����򣬷���'+date+'
        ///// </summary>   
        ///// <param name="strValue">�ַ���</param>
        //public static string funString_StringToDBDate(this string strValue, string DefaultValue, string CustomFormat)
        //{
        //    if (strValue == null)
        //    {
        //        return DefaultValue;
        //    }
        //    if (strValue == "")
        //    {
        //        return DefaultValue;
        //    }
        //    else
        //    {
        //        if (funBoolean_ValidDate(strValue))
        //        {
        //            return "" + strValue.funDateTime_StringToDatetime().ToString(CustomFormat) + "";
        //        }
        //        else
        //        {
        //            return DefaultValue;
        //        }
        //    }
        //}
        /// <summary>
        /// ʱ��תΪ��
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string funString_StringToSITDate(this string strValue)
        {
            if (strValue == null)
            {
                return "";
            }
            if (strValue == "")
            {
                return "";
            }
            else
            {
                if (funBoolean_ValidDate(strValue))
                {
                    return strValue;
                }
                else
                {
                    return "";
                }
            }
        }


        #endregion
        #region "�ļ�������غ���"
        /// <summary>
        /// ��֤ѡ���ϴ����ļ��Ƿ���������ļ���
        /// </summary>
        /// <param name="fileAttachmentName">�ϴ��ļ��ؼ�</param>
        /// <param name="blnAllowNull">�Ƿ�������ļ���TrueΪ����FalseΪ������</param>
        /// <param name="blnFilter">������strFilter���͵��ļ��ϴ����ǲ�����strFilter���͵��ļ��ϴ���TrueΪ������FalseΪ����</param>
        /// <param name="strFilter">����ʲô�����ļ�Ϊ�����ϴ�,���Ϊfalse,ֻ����Filter�е��ļ�����,trueΪ����ΪFilter�е��ļ�����|.asp|.exe|.htm|.html|.aspx|.cs|.vb|.js|</param>
        /// <returns></returns>
        public static string funString_FileUploadFormat(this FileUpload fileAttachmentName, bool blnAllowNull, bool blnFilter, string strFilter)
        {
            if (fileAttachmentName.HasFile)
            {
                string strFileName = "c:\\" + fileAttachmentName.FileName;
                FileInfo f = new FileInfo(strFileName);
                string strDocExtension = f.Extension.ToLower();
                if (!blnFilter)
                {
                    if (strFilter.IndexOf(strDocExtension) < 0)
                    {
                        return "�������ϴ�" + strFilter + "�Ⱥ�׺��������ļ���";
                    }
                }
                else
                {
                    if (strFilter.IndexOf(strDocExtension) >= 0)
                    {
                        return "�������ϴ�" + strFilter + "�Ⱥ�׺�����ļ���";
                    }
                }
            }
            else
            {
                if (!blnAllowNull)
                {
                    return "��ѡ����ظ�����";
                }
            }
            return "";
        }


        /// <summary>   
        /// �õ��ϴ��ĸ�����ʽ��������һ���ʽΪyyyyMMddhhmmss
        /// </summary>   
        /// <param name="strAttachmentName">�����ļ���</param>
        public static string funString_FormatAttachmentName(this string strAttachmentName)
        {
            //�ļ���Ӧ�ý�ȡ��ֻ��260λ,��Ϊ���ݿ���ֻ������260λ�ĳ���
            string strFileName;
            strFileName = strAttachmentName;
            int intLen;
            intLen = strFileName.Length;
            if (intLen > 245)
            {
                intLen = 245;
            }
            strFileName = System.DateTime.Now.ToString("yyyyMMddhhmmss") + strFileName.Substring(0, intLen);

            return strFileName;
        }
        /// <summary>   
        /// �ϴ��ļ�����,�������ļ���,����û���ָ���ļ���,�ļ�������ʽΪyyyyMMddhhmmss
        /// </summary>   
        /// <param name="strFileName">�ļ���</param>
        /// <param name="strDirPath">�����ļ�Ŀ¼��</param>
        /// <param name="fileAttachmentName">�ϴ��ļ��ؼ�</param>
        public static string funString_FileUpLoadAttachment(this string strFileName, string strDirPath, FileUpload fileAttachmentName)
        {
            FileUpload fileAttachment;
            fileAttachment = fileAttachmentName;
            strFileName = (strFileName == "") ? funString_FormatAttachmentName(fileAttachmentName.FileName) : strFileName;
            if (fileAttachment.HasFile)
            {
                string SaveAddPath = "";
                SaveAddPath = System.Web.HttpContext.Current.Server.MapPath(strDirPath);
                if (!Directory.Exists(SaveAddPath))
                {
                    Directory.CreateDirectory(SaveAddPath);
                }
                SaveAddPath += strFileName;
                fileAttachment.SaveAs(SaveAddPath);
            }
            return strFileName;
        }
        /// <summary>   
        /// �ϴ��ļ�����,�������ļ���,����û���ָ���ļ���,�ļ�������ʽΪyyyyMMddhhmmss
        /// </summary>   
        /// <param name="strFileName">�ļ���</param>
        /// <param name="strDirPath">�����ļ�Ŀ¼��</param>
        /// <param name="fileAttachmentName">�ϴ��ļ��ؼ�</param>
        public static string funString_FileUpLoadAttachment(this string strFileName, string strDirPath, FileUpload fileAttachmentName, string strDir)
        {
            FileUpload fileAttachment;
            fileAttachment = fileAttachmentName;
            strFileName = (strFileName == "") ? funString_FormatAttachmentName(fileAttachmentName.FileName) : strFileName;
            if (fileAttachment.HasFile)
            {
                string SaveAddPath = "";
                SaveAddPath = System.Web.HttpContext.Current.Server.MapPath(strDirPath) + "\\" + strDir;
                if (!Directory.Exists(SaveAddPath))
                {
                    Directory.CreateDirectory(SaveAddPath);
                }
                SaveAddPath += strFileName;
                fileAttachment.SaveAs(SaveAddPath);
            }
            return strFileName;
        }
        /// <summary>
        /// ��ȡ�ļ�������
        /// </summary>
        /// <param name="strRelativePath">�ļ������·��</param>
        /// <param name="objEncoding">�����ʽ</param>
        /// <returns></returns>
        public static string funString_FileContent(this string strRelativePath, Encoding objEncoding)
        {
            string strAbsolutePath = System.Web.HttpContext.Current.Server.MapPath(strRelativePath);
            if (!File.Exists(strAbsolutePath))
            {
                return "";
            }
            FileStream objFileStream = new FileStream(strAbsolutePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader objStreamReader = new StreamReader(objFileStream, objEncoding);
            string strConent = "";
            strConent = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            objFileStream.Close();
            return strConent;
        }
        #endregion
        #region "ComboBox,CheckBoxList,RadioButtonList����"
        /// <summary>   
        /// ����Value����ѡ��ComboBox��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        public static void subComboBox_SelectItemByValue(this HtmlSelect cboName, string SelectedValue)
        {
            int intCount;
            intCount = cboName.Items.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Value.ToLower().Trim() == SelectedValue.ToLower().Trim())
                {
                    cboName.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>   
        /// ����Value����ѡ��ComboBox��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        public static void subComboBox_SelectItemByValue(this DropDownList cboName, string SelectedValue)
        {
            int intCount;
            intCount = cboName.Items.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Value.ToLower().Trim() == SelectedValue.ToLower().Trim())
                {
                    cboName.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>   
        /// ����Value����ѡ��Item�����û��ѡ����Ӧѡ���ô��ѡ��Ĭ��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        /// <param name="DefaultValue">Ĭ��ѡ���Value</param>
        public static void subComboBox_SelectItemByValue(this HtmlSelect cboName, string SelectedValue, string DefaultValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            bool blnSelected = false;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Value == SelectedValue)
                {
                    cboName.SelectedIndex = i;
                    blnSelected = true;
                    break;
                }
            }
            if (blnSelected == false)
            {
                string strItemValue;
                for (i = 0; i < intCount; i++)
                {
                    strItemValue = cboName.Items[i].Value.ToLower();
                    if (strItemValue == DefaultValue)
                    {
                        cboName.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        /// <summary>   
        /// ����Value����ѡ��Item�����û��ѡ����Ӧѡ���ô��ѡ��Ĭ��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        /// <param name="DefaultValue">Ĭ��ѡ���Value</param>
        public static void subComboBox_SelectItemByValue(this DropDownList cboName, string SelectedValue, string DefaultValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            bool blnSelected = false;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Value == SelectedValue)
                {
                    cboName.SelectedIndex = i;
                    blnSelected = true;
                    break;
                }
            }
            if (blnSelected == false)
            {
                string strItemValue;
                for (i = 0; i < intCount; i++)
                {
                    strItemValue = cboName.Items[i].Value.ToLower();
                    if (strItemValue == DefaultValue)
                    {
                        cboName.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        /// <summary>   
        /// ����ѡ��CheckBoxList��ѡ��
        /// </summary>   
        /// <param name="chklstName">CheckBoxList</param>
        /// <param name="SelectedValues">Ҫѡ�е�Item��ֵ�б�</param>
        /// <param name="strSplitChar">SelectedValues�еķָ��</param>
        public static void subCheckBoxList_SelectItemByValue(this CheckBoxList chklstName, string SelectedValues, string strSplitChar)
        {
            int intCount;
            intCount = chklstName.Items.Count;
            string strSelectedValues = "";
            strSelectedValues = strSplitChar + SelectedValues.ToLower() + strSplitChar;
            for (int i = 0; i < intCount; i++)
            {
                if (strSelectedValues.IndexOf(strSplitChar + chklstName.Items[i].Value.ToString().ToLower() + strSplitChar) >= 0)
                {
                    chklstName.Items[i].Selected = true;
                }
                else
                {
                    chklstName.Items[i].Selected = false;
                }
            }
        }
        /// <summary>   
        /// ����Text����ѡ��ComboBox��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        public static void subComboBox_SelectItemByText(this HtmlSelect cboName, string SelectedValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Text.ToLower() == SelectedValue.ToLower())
                {
                    //cboName.Items[i].Selected = true;
                    cboName.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>   
        /// ����Text����ѡ��ComboBox��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        public static void subComboBox_SelectItemByText(this DropDownList cboName, string SelectedValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Text.ToLower() == SelectedValue.ToLower())
                {
                    //cboName.Items[i].Selected = true;
                    cboName.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>   
        /// ����Text����ѡ��Item�����û��ѡ����Ӧѡ���ô��ѡ��Ĭ��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        /// <param name="DefaultValue">Ĭ��ѡ���Text</param>
        public static void subComboBox_SelectItemByText(this HtmlSelect cboName, string SelectedValue, string DefaultValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            bool blnSelected = false;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Text == SelectedValue)
                {
                    cboName.SelectedIndex = i;
                    blnSelected = true;
                    break;
                }
            }
            if (blnSelected == false)
            {
                string strItemText;
                for (i = 0; i < intCount; i++)
                {
                    strItemText = cboName.Items[i].Text.ToLower();
                    if (strItemText == DefaultValue)
                    {
                        cboName.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        /// <summary>   
        /// ����Text����ѡ��Item�����û��ѡ����Ӧѡ���ô��ѡ��Ĭ��ѡ��
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">Ҫѡ�е�Item��ֵ</param>
        /// <param name="DefaultValue">Ĭ��ѡ���Text</param>
        public static void subComboBox_SelectItemByText(this DropDownList cboName, string SelectedValue, string DefaultValue)
        {
            int i;
            int intCount;
            intCount = cboName.Items.Count;
            bool blnSelected = false;
            for (i = 0; i < intCount; i++)
            {
                if (cboName.Items[i].Text == SelectedValue)
                {
                    cboName.SelectedIndex = i;
                    blnSelected = true;
                    break;
                }
            }
            if (blnSelected == false)
            {
                string strItemText;
                for (i = 0; i < intCount; i++)
                {
                    strItemText = cboName.Items[i].Text.ToLower();
                    if (strItemText == DefaultValue)
                    {
                        cboName.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        /// <summary>   
        /// ���������е�ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">ȡֵ��SQL</param>
        /// <param name="IsDisplayDefaultText">�Ƿ���ʾĬ�ϵ�ѡ��</param>
        public static void subComboBox_LoadItemsByDBColumnName(this HtmlSelect cboName, string strSearchSQL, bool IsDisplayDefaultText)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----ѡ�����м�¼-----";
                cboName.Items.Add(item);
            }

            string strSQL;
            strSQL = strSearchSQL;

            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

            int intCount = -1;
            intCount = ds.Tables[0].Columns.Count;

            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                item.Text = ds.Tables[0].Columns[i].ColumnName;
                item.Value = ds.Tables[0].Columns[i].ColumnName;
                cboName.Items.Add(item);
            }
            cboName.SelectedIndex = 0;
        }
        /// <summary>   
        /// ���������е�ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">ȡֵ��SQL</param>
        /// <param name="IsDisplayDefaultText">�Ƿ���ʾĬ�ϵ�ѡ��</param>
        /// <param name="isType">�Ƿ��������</param>
        public static void subComboBox_LoadItemsByDBColumnName(this DropDownList cboName, string strSearchSQL, bool IsDisplayDefaultText, bool isType)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----ѡ�����м�¼-----";
                item.Attributes.Add("DataType", "");
                cboName.Items.Add(item);
            }
            string strSQL;
            strSQL = strSearchSQL;
            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

            int intCount = -1;
            intCount = ds.Tables[0].Columns.Count;

            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                item.Text = ds.Tables[0].Columns[i].ColumnName;
                item.Value = ds.Tables[0].Columns[i].ColumnName;
                item.Attributes.Add("DataType", ds.Tables[0].Columns[i].DataType.ToString().Replace("System.", ""));
                cboName.Items.Add(item);
            }
            cboName.SelectedIndex = 0;
        }

        /// <summary>   
        /// ���������е�ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">ȡֵ��SQL</param>
        /// <param name="IsDisplayDefaultText">�Ƿ���ʾĬ�ϵ�ѡ��</param>
        /// <param name="DefaultField">Ĭ�ϵ�ѡ��</param>
        public static void subComboBox_LoadItemsByDBColumnName(this DropDownList cboName, string strSearchSQL, bool IsDisplayDefaultText, string DefaultField)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----ѡ�����м�¼-----";
                cboName.Items.Add(item);
            }
            string strSQL;
            strSQL = strSearchSQL;
            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

            if (ds != null)
            {
                int intCount = -1;
                intCount = ds.Tables[0].Columns.Count;

                for (int i = 0; i < intCount; i++)
                {
                    item = new ListItem();
                    item.Text = ds.Tables[0].Columns[i].ColumnName;
                    item.Value = ds.Tables[0].Columns[i].ColumnName;
                    cboName.Items.Add(item);
                }
                if (DefaultField == "")
                {
                    cboName.SelectedIndex = 0;
                }
                else
                {
                    subComboBox_SelectItemByValue(cboName, DefaultField);
                }
            }
        }
        /// <summary>   
        /// ���������е�ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">ȡֵ��SQL</param>
        /// <param name="IsDisplayDefaultText">�Ƿ���ʾĬ�ϵ�ѡ��</param>
        ///  <param name="strSearchSQL">Ĭ�ϵ�ѡ��</param>
        public static void subComboBox_LoadItemsByDBColumnName(this HtmlSelect cboName, string strSearchSQL, bool IsDisplayDefaultText, string DefaultField)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----ѡ�����м�¼-----";
                cboName.Items.Add(item);
            }
            string strSQL;
            strSQL = strSearchSQL;
            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

            int intCount = -1;
            intCount = ds.Tables[0].Columns.Count;

            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                item.Text = ds.Tables[0].Columns[i].ColumnName;
                item.Value = ds.Tables[0].Columns[i].ColumnName;
                cboName.Items.Add(item);
            }
            if (DefaultField == "")
            {
                cboName.SelectedIndex = 0;
            }
            else
            {
                subComboBox_SelectItemByValue(cboName, DefaultField);
            }
        }
        /// <summary>
        /// ����RadioButtonList�Ƿ���ѡ����,���ѡ�е�ItemֵΪ1�ͷ���1,���򷵻�0,����SelectedIndexΪ0����null,���������Ҫ�������ݿ��RadioButtonListֵ��.
        /// </summary>   
        /// <param name="rdoButtonlist">RadioButtonList</param>
        public static string funBoolean_RadioButtonListCheck(this RadioButtonList rdoButtonlist)
        {
            string strCheck = "";
            for (int i = 0; i < rdoButtonlist.Items.Count; i++)
            {
                if (rdoButtonlist.Items[i].Selected)
                {
                    if (rdoButtonlist.Items[i].Value == "1")
                    {
                        strCheck = "1";
                        break;
                    }
                    else
                    {
                        strCheck = "0";
                    }
                }
            }
            if (rdoButtonlist.SelectedIndex < 0)
            {
                strCheck = "null";
            }
            return strCheck;
        }
        /// <summary>
        /// ����RadioButtonList��ѡ�е���
        /// </summary>   
        /// <param name="rdoButtonlist">RadioButtonList</param>
        /// <param name="itemValue">��Ҫ��ѡ�е�Item���ֵ</param>
        public static void subRadioButtonList_CheckItem(this RadioButtonList rdoButtonlist, string itemValue)
        {
            string strTmp = "";
            strTmp = "";
            if (itemValue.ToLower() == "false")
            {
                strTmp = "0";
            }
            if (itemValue.ToLower() == "true")
            {
                strTmp = "1";
            }
            if (strTmp == "")
            {
                return;
            }
            for (int i = 0; i < rdoButtonlist.Items.Count; i++)
            {
                if (rdoButtonlist.Items[i].Value.ToString() == strTmp)
                {
                    rdoButtonlist.Items[i].Selected = true;
                    break;
                }
            }
        }
        /// <summary>
        /// ����ComboBoxѡ��Item��Text
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        public static string funComboBox_SelectedText(this HtmlSelect cboBox)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                strText = cboBox.Items[cboBox.SelectedIndex].Text;
            }
            return strText;
        }
        /// <summary>
        /// ����ComboBoxѡ��Item��Text
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        public static string funComboBox_SelectedText(this DropDownList cboBox)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                strText = cboBox.Items[cboBox.SelectedIndex].Text;
            }
            return strText;
        }
        /// <summary>
        /// ����ComboBoxѡ��Item��Value
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        public static string funComboBox_SelectedValue(this HtmlSelect cboBox)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                strText = cboBox.Items[cboBox.SelectedIndex].Value;
            }
            return strText;
        }
        /// <summary>
        /// ����ComboBoxѡ��Item��Value
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        public static string funComboBox_SelectedValue(this DropDownList cboBox)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                strText = cboBox.Items[cboBox.SelectedIndex].Value;
            }
            return strText;
        }
        /// <summary>
        /// ����ComboBox��Item��,�����������1,��0��ΪValue,1��ΪText
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        /// <param name="strSearchSQL">������SQL</param>
        /// <param name="intSelectIndex">Ĭ��ѡ�е�Index</param>
        /// <param name="ItemDefault">���Ϊ�գ���ָ��Ĭ��Item�����ItemDefaultΪĬ����</param>
        //public static void subComboBox_LoadItems(this HtmlSelect cboBox, string strSearchSQL, int intSelectIndex, ListItem ItemDefault)
        //{
        //    cboBox.Items.Clear();
        //    ListItem item;
        //    string strSQL;
        //    strSQL = strSearchSQL;
        //    IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
        //    DataSet ds = new DataSet();
        //    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

        //    int intCount = -1;
        //    intCount = ds.Tables[0].Rows.Count;
        //    if (ItemDefault != null)
        //    {
        //        cboBox.Items.Add(ItemDefault);
        //    }
        //    int intColumnsCount = ds.Tables[0].Columns.Count;
        //    for (int i = 0; i < intCount; i++)
        //    {
        //        item = new ListItem();
        //        if (intColumnsCount > 1)
        //        {
        //            item.Text = ds.Tables[0].Rows[i][1].ToString();
        //        }
        //        else
        //        {
        //            item.Text = ds.Tables[0].Rows[i][0].ToString();
        //        }
        //        item.Value = ds.Tables[0].Rows[i][0].ToString();
        //        cboBox.Items.Add(item);
        //    }
        //    if (cboBox.Items.Count > 0)
        //    {
        //        cboBox.SelectedIndex = intSelectIndex;
        //    }
        //    else
        //    {
        //        cboBox.SelectedIndex = -1;
        //    }
        //}
        ///// <summary>
        ///// ����ComboBox��Item��,�����������1,��0��ΪValue,1��ΪText
        ///// </summary>   
        ///// <param name="cboBox">cboBox</param>
        ///// <param name="strSearchSQL">������SQL</param>
        ///// <param name="intSelectIndex">Ĭ��ѡ�е�Index</param>
        ///// <param name="ItemDefault">���Ϊ�գ���ָ��Ĭ��Item�����ItemDefaultΪĬ����</param>
        //public static void subComboBox_LoadItems(this DropDownList cboBox, string strSearchSQL, int intSelectIndex, ListItem ItemDefault)
        //{
        //    cboBox.Items.Clear();
        //    ListItem item;
        //    string strSQL;
        //    strSQL = strSearchSQL;
        //    IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
        //    DataSet ds = new DataSet();
        //    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);

        //    int intCount = -1;
        //    intCount = ds.Tables[0].Rows.Count;
        //    if (ItemDefault != null)
        //    {
        //        cboBox.Items.Add(ItemDefault);
        //    }
        //    int intColumnsCount = ds.Tables[0].Columns.Count;
        //    for (int i = 0; i < intCount; i++)
        //    {
        //        item = new ListItem();
        //        if (intColumnsCount > 1)
        //        {
        //            item.Text = ds.Tables[0].Rows[i][1].ToString();
        //        }
        //        else
        //        {
        //            item.Text = ds.Tables[0].Rows[i][0].ToString();
        //        }
        //        item.Value = ds.Tables[0].Rows[i][0].ToString();
        //        cboBox.Items.Add(item);
        //    }
        //    if (cboBox.Items.Count > 0)
        //    {
        //        cboBox.SelectedIndex = intSelectIndex;
        //    }
        //    else
        //    {
        //        cboBox.SelectedIndex = -1;
        //    }
        //}
        /// <summary>
        /// ����ѡ�е�RadionButtonList��ֵ
        /// </summary>
        /// <param name="rdoButtonlist"></param>
        /// <returns></returns>
        public static string funString_RadioButtonList(this RadioButtonList rdoButtonlist)
        {
            string strCheck = "";
            bool blnNull = false;
            for (int i = 0; i < rdoButtonlist.Items.Count; i++)
            {
                if (rdoButtonlist.Items[i].Selected == true)
                {
                    if (rdoButtonlist.Items[i].Value == "1")
                    {
                        strCheck = "1";
                        break;
                    }
                    else
                    {
                        strCheck = "0";
                    }
                }
            }
            if (rdoButtonlist.SelectedIndex < 0)
            {
                strCheck = "null";
            }
            return strCheck;
        }
        /// <summary>
        /// ����CheckBox״̬,��0,1����,0Ϊûѡ��,1Ϊѡ��
        /// </summary>
        /// <param name="chkBox"></param>
        /// <returns></returns>
        public static int funInt_CheckBoxStatus(this HtmlInputCheckBox chkBox)
        {
            if (chkBox.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// ����CheckBox״̬,��0,1����,0Ϊûѡ��,1Ϊѡ��
        /// </summary>
        /// <param name="chkBox"></param>
        /// <returns></returns>
        public static int funInt_CheckBoxStatus(this CheckBox chkBox)
        {
            if (chkBox.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        //#region"����Email"
        ///// <summary>
        ///// ��webMail��ʽ����Mail,�ɹ�����"",ʧ�ܷ��ش������
        ///// </summary>
        ///// <param name="strSendMail">�����˵�Mail</param>
        ///// <param name="strSendUserName">�����˵��û���</param>
        ///// <param name="strSendUserPassword">�����˵�����</param>
        ///// <param name="strBody">��������</param>
        ///// <param name="strSmtp">Smtp Server</param>
        ///// <param name="strToMail">�����˵�Mail</param>
        ///// <param name="strSubject">��������</param>
        ///// <param name="strCc">�����˵�Mail</param>
        ///// <param name="isDellAttachment">���ͺ��Ƿ�ɾ������</param>
        ///// <param name="strBcc">�����˵�Mail</param>
        ///// <param name="aryAttachment">�����б�</param>
        ///// <returns></returns>
        //public static string funString_SendMailByWebMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, ArrayList aryAttachment)
        //{
        //    string strReturn = "";
        //    System.Web.Mail.MailMessage objMailMessage = new System.Web.Mail.MailMessage();
        //    objMailMessage.From = strSendMail;
        //    objMailMessage.To = strToMail;
        //    objMailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
        //    //Cc
        //    if (strCc != "")
        //    {
        //        objMailMessage.Cc = strCc;
        //    }
        //    //Bcc
        //    if (strBcc != "")
        //    {
        //        objMailMessage.Bcc = strBcc;
        //    }
        //    objMailMessage.Subject = strSubject;
        //    objMailMessage.Body = strBody;
        //    objMailMessage.BodyFormat = System.Web.Mail.MailFormat.Html;
        //    System.Web.Mail.SmtpMail.SmtpServer = strSmtp;
        //    //����
        //    if (aryAttachment != null)
        //    {
        //        if (aryAttachment.Count > 0)
        //        {
        //            FileInfo objFile;
        //            for (int i = 0; i < aryAttachment.Count; i++)
        //            {
        //                objFile = new FileInfo(aryAttachment[i].ToString());
        //                if (objFile.Exists)
        //                {
        //                    System.Web.Mail.MailAttachment objAttachment = new System.Web.Mail.MailAttachment(aryAttachment[i].ToString());
        //                    objMailMessage.Attachments.Add(objAttachment);
        //                }
        //            }
        //        }
        //    }
        //    //��֤
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", strSendUserName); //set your username here 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", strSendUserPassword); //set your password here 
        //    //����
        //    try
        //    {
        //        System.Web.Mail.SmtpMail.Send(objMailMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        strReturn = ex.Source + "\n" + ex.Message;
        //    }
        //    //ɾ���ļ�
        //    try
        //    {
        //        //ɾ���ļ�
        //        if (isDellAttachment)
        //        {
        //            for (int i = 0; i < aryAttachment.Count; i++)
        //            {
        //                File.Delete(aryAttachment[i].ToString());
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return strReturn;
        //}
        ///// <summary>
        ///// ��NetMail��ʽ����Mail,�ɹ�����"",ʧ�ܷ��ش������
        ///// </summary>
        ///// <param name="strSendMail">�����˵�Mail</param>
        ///// <param name="strSendUserName">�����˵��û���</param>
        ///// <param name="strSendUserPassword">�����˵�����</param>
        ///// <param name="strBody">��������</param>
        ///// <param name="strSmtp">Smtp Server</param>
        ///// <param name="strToMail">�����˵�Mail</param>
        ///// <param name="strSubject">��������</param>
        ///// <param name="strCc">�����˵�Mail</param>
        ///// <param name="isDellAttachment">���ͺ��Ƿ�ɾ������</param>
        ///// <param name="strBcc">�����˵�Mail</param>
        ///// <param name="aryAttachment">�����б�</param>
        ///// <returns></returns>
        //public static string funString_SendMailByNetMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, ArrayList aryAttachment)
        //{
        //    string strReturn = "";
        //    System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
        //    //�����ż��Ļ�����Ϣ
        //    objMailMessage.Subject = strSubject;
        //    objMailMessage.Body = strBody;
        //    objMailMessage.IsBodyHtml = true;
        //    objMailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
        //    //���÷�����
        //    System.Net.Mail.MailAddress objMailAddress = new System.Net.Mail.MailAddress(strSendMail);
        //    objMailMessage.From = objMailAddress;

        //    //�����ռ���
        //    string[] aryToMail = strToMail.Split(';');
        //    for (int i = 0; i < aryToMail.Length; i++)
        //    {
        //        objMailMessage.To.Add(aryToMail[i].ToString());
        //    }
        //    //����CC
        //    if (strCc != "")
        //    {
        //        string[] aryCCMail = strCc.Split(';');
        //        for (int i = 0; i < aryCCMail.Length; i++)
        //        {
        //            objMailMessage.To.Add(aryCCMail[i].ToString());
        //        }
        //    }
        //    //����BCC
        //    if (strBcc != "")
        //    {
        //        string[] aryBCCMail = strCc.Split(';');
        //        for (int i = 0; i < aryBCCMail.Length; i++)
        //        {
        //            objMailMessage.Bcc.Add(aryBCCMail[i].ToString());
        //        }
        //    }
        //    //����
        //    if (aryAttachment != null)
        //    {
        //        if (aryAttachment.Count > 0)
        //        {
        //            FileInfo objFile;
        //            for (int i = 0; i < aryAttachment.Count; i++)
        //            {
        //                objFile = new FileInfo(aryAttachment[i].ToString());
        //                if (objFile.Exists)
        //                {
        //                    System.Net.Mail.Attachment objAttachment = new System.Net.Mail.Attachment(aryAttachment[i].ToString());
        //                    objMailMessage.Attachments.Add(objAttachment);
        //                }
        //            }
        //        }
        //    }
        //    //����
        //    try
        //    {

        //        System.Net.Mail.SmtpClient objSmtpClient = new System.Net.Mail.SmtpClient();
        //        objSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        System.Net.CredentialCache objCache = new System.Net.CredentialCache();
        //        objCache.Add(strSmtp, 25, "NTLM", new System.Net.NetworkCredential(strSendUserName, strSendUserPassword));//NTLM//Basic
        //        objSmtpClient.Credentials = objCache;
        //        objSmtpClient.Send(objMailMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        strReturn = ex.Source + "\n" + ex.Message;
        //    }
        //    try
        //    {
        //        //ɾ���ļ�
        //        if (isDellAttachment)
        //        {
        //            for (int i = 0; i < aryAttachment.Count; i++)
        //            {
        //                File.Delete(aryAttachment[i].ToString());
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return strReturn;
        //}

        ///// <summary>
        ///// ��������Email
        ///// </summary>
        ///// <param name="strSendMail"></param>
        ///// <param name="strSendUserName"></param>
        ///// <param name="strSendUserPassword"></param>
        ///// <param name="strBody"></param>
        ///// <param name="strSmtp"></param>
        ///// <param name="strToMail"></param>
        ///// <param name="strSubject"></param>
        ///// <param name="strCc"></param>
        ///// <param name="isDellAttachment"></param>
        ///// <param name="strBcc"></param>
        ///// <param name="aryAttachment"></param>
        ///// <returns></returns>
        //public static string funString_SendNoMailByWebMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, List<string> aryAttachment)
        //{
        //    System.Web.Mail.MailMessage myMail = new MailMessage();
        //    myMail.From = strSendMail;
        //    myMail.To = strToMail;
        //    myMail.Cc = strCc;
        //    myMail.Bcc = strBcc;
        //    myMail.Subject = strSubject;
        //    myMail.BodyEncoding = Encoding.GetEncoding("GB2312");
        //    myMail.Priority = MailPriority.High;
        //    myMail.BodyFormat = MailFormat.Html;
        //    myMail.Body = strBody;
        //    string strMessage = "";
        //    //����
        //    if (aryAttachment != null)
        //    {
        //        if (aryAttachment.Count > 0)
        //        {
        //            FileInfo objFile;
        //            for (int i = 0; i < aryAttachment.Count; i++)
        //            {
        //                if (aryAttachment[i].ToString() == "")
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    objFile = new FileInfo(aryAttachment[i].ToString());
        //                    if (objFile.Exists)
        //                    {
        //                        System.Web.Mail.MailAttachment objAttachment = new MailAttachment(aryAttachment[i].ToString());
        //                        myMail.Attachments.Add(objAttachment);
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //            }
        //        }
        //    }
        //    SmtpMail.SmtpServer = strSmtp; //your smtp server here
        //    try
        //    {
        //        SmtpMail.Send(myMail);
        //    }
        //    catch (Exception ex)
        //    {
        //        strMessage = ex.Source + "\n" + ex.Message;
        //    }
        //    return strMessage;
        //}
        //#endregion
        #region"�жϽ�������ʱ�䣬�ҳ���Ӧ�Ľ��̲�ɱ������"
        /// <summary>
        /// �жϽ�������ʱ�䣬�ҳ���Ӧ�Ľ��̲�ɱ������
        /// </summary>   
        /// <param name="dtStartDate">�������ÿ�ʼʱ��</param>
        /// <param name="dtEndDate">�������ý���ʱ��</param>
        /// <param name="strProcessName">ɱ���Ľ�����</param>
        public static void subProcess_Kill(this DateTime dtStartDate, DateTime dtEndDate, string strProcessName)
        {
            Process[] myProcesses;
            DateTime startTime;
            myProcesses = Process.GetProcessesByName(strProcessName);
            foreach (Process myProcess in myProcesses)
            {
                try
                {
                    startTime = myProcess.StartTime;
                    if (startTime > dtStartDate && startTime < dtEndDate)
                    {
                        try
                        {
                            myProcess.Kill();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

            }
        }
        #endregion
        #region "��ȡһ��word��XMLģ���ļ�"
        /// <summary>
        /// ��ȡһ��word��XMLģ���ļ�
        /// </summary>   
        /// <param name="strTemplateAbsolutePath">ģ���������ַ</param>
        public static StringBuilder funStringBuilder_WordXMLToStringBuilder(this string strTemplateAbsolutePath)
        {
            StringBuilder strBWord = new StringBuilder();
            FileStream fsWord = new FileStream(strTemplateAbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sRword = new StreamReader(fsWord, Encoding.UTF8);
            strBWord.Append(sRword.ReadToEnd());
            fsWord.Close();
            return strBWord;
        }
        #endregion
        #region "����->UTF8 CODE"
        /// <summary>
        /// ����->UTF8 CODE
        /// </summary>   
        /// <param name="strContent">�ַ���</param>
        public static string funString_ChinesetoUTF8Code(this string strContent)
        {
            string strTemp = "";
            if (strContent == "")
            {
                return strTemp;
            }
            for (int i = 0; i < strContent.ToString().Length; i++)
            {
                strTemp = strTemp + "&#" + Microsoft.VisualBasic.Strings.AscW(strContent.ToString().Substring(i, 1));
            }
            return strTemp;
        }
        #endregion
        //#region"Request�ַ���ȡ"
        //public static string funString_RequestFormValue(this HttpContext IContent, string strName)
        //{
        //    string strValue = "";
        //    try
        //    {
        //        strValue = Uri.UnescapeDataString(IContent.Request[strName]);// IContent.Server.UrlDecode(IContent.Request[strName]);
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    if (strValue == null)
        //    {
        //        strValue = "";
        //    }
        //    return strValue;
        //}
        //public static string funString_RequestFormValue(this HttpRequest Request, string strName)
        //{
        //    string strValue = "";
        //    try
        //    {
        //        strValue = Uri.UnescapeDataString(Request[strName]); //HttpUtility.UrlDecode(Request[strName]);
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    if (strValue == null)
        //    {
        //        strValue = "";
        //    }
        //    return strValue;
        //}
        //#endregion
        /// <summary>
        /// ���CheckListBox
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <param name="strSearchSQL">��һλΪID,�ڶ�λΪText</param>
        public static void subCheckListBox_Load(this CheckBoxList chklstName, string strSearchSQL)
        {
            chklstName.Items.Clear();
            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);
            ListItem item;
            if (ds == null)
            {
                return;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                item = new ListItem();
                if (ds.Tables[0].Columns.Count > 1)
                {
                    item.Text = ds.Tables[0].Rows[i][1].ToString();
                    item.Value = ds.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    item.Text = ds.Tables[0].Rows[i][0].ToString();
                    item.Value = ds.Tables[0].Rows[i][0].ToString();
                }
                chklstName.Items.Add(item);
            }
        }
        /// <summary>
        /// ����Value��ѡCheckListBox
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <param name="strValues"></param>
        public static void subCheckListBox_CheckByValues(this CheckBoxList chklstName, string strValues)
        {
            strValues = "," + strValues + ",";
            for (int i = 0; i < chklstName.Items.Count; i++)
            {
                if (strValues.IndexOf("," + ((ListItem)chklstName.Items[i]).Value) >= 0)
                {
                    chklstName.Items[i].Selected = true;
                }
                else
                {
                    chklstName.Items[i].Selected = false;
                }
            }
        }
        /// <summary>
        /// ����CheckListBox��ѡ�е�ֵ
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <returns></returns>
        public static string funCheckListBox_SelectValue(this CheckBoxList chklstName)
        {
            string strValues = "";
            for (int i = 0; i < chklstName.Items.Count; i++)
            {
                if (chklstName.Items[i].Selected)
                {
                    strValues += ((ListItem)chklstName.Items[i]).Value + ",";
                }
            }
            if (strValues != "")
            {
                strValues = strValues.Substring(0, strValues.Length - 1);
            }
            return strValues;
        }
        public static void subControl_Enable(this System.Web.UI.Control objCon, bool blnEnable)
        {

            System.Web.UI.Control oc;
            if (objCon != null)
            {
                for (int i = 0; i < objCon.Controls.Count; i++)
                {
                    oc = objCon.Controls[i];
                    if (oc.Controls.Count <= 0)
                    {
                        try
                        {
                            ((WebControl)(oc)).Enabled = blnEnable;
                        }
                        catch
                        {
                        }
                        try
                        {
                            ((HtmlControl)(oc)).Disabled = !blnEnable;
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        subControl_Enable(oc, blnEnable);
                    }
                }
            }
        }
        #region "�����ؼ�FindControl������չ"
        /// <summary>
        /// �õݹ�����
        /// </summary>
        /// <param name="o">һ����Ĵ�ֵ</param>
        /// <param name="id"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static System.Web.UI.Control FindControlEx(this System.Web.UI.Control o, string id, ControlCollection controls)
        {
            int i;
            System.Web.UI.Control reControl = null;
            for (i = 0; i < controls.Count; i++)
            {
                if (controls[i].ID == id)
                {
                    reControl = controls[i];
                    break;
                }
                if (controls[i].Controls.Count > 0)
                {
                    reControl = FindControlEx(o, id, controls[i].Controls);
                    if (reControl != null)
                    {
                        break;
                    }
                }
            }

            return reControl;
        }
        #endregion
        #region "��ǰ����"
        public static string CurrentFY_Year1
        {
            get
            {
                string strCurrentFY = "";
                if (DateTime.Now.Month >= 10)
                {
                    strCurrentFY = DateTime.Now.AddYears(0).ToString("yyyy");
                }
                else
                {
                    strCurrentFY = DateTime.Now.AddYears(-1).ToString("yyyy");
                }
                return strCurrentFY;
            }

        }
        public static string CurrentFY_Year2
        {
            get
            {
                string strCurrentFY = "";
                if (DateTime.Now.Month >= 10)
                {
                    strCurrentFY = DateTime.Now.AddYears(1).ToString("yyyy");
                }
                else
                {
                    strCurrentFY = DateTime.Now.AddYears(0).ToString("yyyy");
                }
                return strCurrentFY;
            }

        }
        #endregion
        /// <summary>
        /// ���������˵����
        /// </summary>
        /// <param name="cboBox"></param>
        /// <param name="blnCategory"></param>
        public static void subComboBox_LoadItems(this  HtmlSelect cboBox, bool blnCategory)
        {
            if (blnCategory)
            {
                cboBox.Items.Clear();
                ListItem item;
                item = new ListItem("True", "1");
                cboBox.Items.Add(item);
                item = new ListItem("False", "0");
                cboBox.Items.Add(item);
                cboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// ���CheckBoxList
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <param name="strSearchSQL">��һλΪID,�ڶ�λΪText</param>
        public static void subCheckBoxList_Load(this CheckBoxList chklstName, string strSearchSQL)
        {
            IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess();
            chklstName.Items.Clear();
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSearchSQL);
            ListItem item;
            if (ds == null)
            {
                return;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                item = new ListItem();
                switch (ds.Tables[0].Columns.Count)
                {
                    case 1:
                        item.Text = ds.Tables[0].Rows[i][0].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        break;
                    case 2:
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        break;
                    case 3:
                        item.Attributes.Add("Title", ds.Tables[0].Rows[i][2].ToString());
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        break;
                    default:
                        item.Text = ds.Tables[0].Rows[i][0].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        break;
                }
                chklstName.Items.Add(item);
            }
        }
        /// <summary>
        /// ���ַ�ת��Ϊboolean��������true��Ϊtrue,�����0��Ϊfalse����0����1
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        //public static bool funBool_StringToBool(this string strContent)
        //{
        //    if (strContent.ToLower() == "true")
        //    {
        //        return true;
        //    }
        //    if (strContent.ToLower() == "false")
        //    {
        //        return false;
        //    }
        //    int intContent = funInt_StringToInt(strContent, 0);
        //    if (intContent > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// �ϴ��ļ�����,�������ļ���,����û���ָ���ļ���,�ļ�������ʽΪyyyyMMddhhmmss
        /// </summary>
        /// <param name="fileAttachmentName">�ϴ��ļ��ؼ�</param>
        /// <param name="strFileName">���ļ���</param>
        /// <param name="FileNameLength">�����ָ���ļ�������ô�ļ�������󳤶�</param>
        /// <param name="strDirPath">�����ļ�Ŀ¼����ʹ��/��β</param>
        /// <returns></returns>
        public static string funString_FileUpLoadAttachment(this FileUpload fileAttachmentName, string strFileName, int FileNameLength, string strDirPath)
        {
            FileUpload fileAttachment;
            fileAttachment = fileAttachmentName;
            strFileName = (strFileName == "") ? funString_FormatAttachmentName(fileAttachmentName.FileName, FileNameLength) : strFileName;
            if (fileAttachment.HasFile)
            {
                string SaveAddPath = "";
                SaveAddPath = System.Web.HttpContext.Current.Server.MapPath(strDirPath);
                if (!Directory.Exists(SaveAddPath))
                {
                    Directory.CreateDirectory(SaveAddPath);
                }
                //SaveAddPath=SaveAddPath+"\\";
                SaveAddPath += strFileName;
                fileAttachment.SaveAs(SaveAddPath);
            }
            else
            {
                strFileName = "";
            }
            return strFileName;
        }

        /// <summary>
        /// �õ��ϴ��ĸ�����ʽ��������һ���ʽΪyyyyMMddHHmmss
        /// </summary>
        /// <param name="strAttachmentName">�����ļ���</param>
        /// <param name="FileNameLength">���ļ����ĳ���</param>
        /// <returns></returns>
        public static string funString_FormatAttachmentName(this string strAttachmentName, int FileNameLength)
        {
            //�õ��ļ���
            string strFileName;
            strFileName = strAttachmentName;
            if (strFileName == "")
            {
                return "";
            }

            //�õ�ԭ�ļ��ĺ�׺��(����.��)
            int intSuffix = strFileName.LastIndexOf(".");
            string strSuffix = "";
            if (intSuffix < 0)
            {
                intSuffix = 0;
                strSuffix = "";
            }
            else
            {
                strSuffix = strFileName.Substring(intSuffix, strFileName.Length - intSuffix);
                intSuffix = strFileName.Length - intSuffix;
            }

            //�õ�����ʱ���ʽ����ļ�ʵ�ʳ���
            int intLen;
            intLen = strFileName.Length + 14;//14��ʱ���ַ����ĳ���

            //������ʵ�ʳ��ȳ������õ��ļ�������
            if (intLen > FileNameLength)
            {
                intLen = FileNameLength;
            }
            //���ļ������ȼ���Ĭ�ϵ�ʱ��ĳ��Ⱥͺ�׺����������Ҫʹ�õ��ļ����Ƴ���
            intLen = intLen - 14 - intSuffix;
            //�ļ���=ʱ���ʽ+�ļ���+��׺
            strFileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + strFileName.Substring(0, intLen) + strSuffix;

            return strFileName;
        }

        #region "��ȡһ��HTML�ļ�"
        public static string funString_GetHtmlFile(this string strFullFileName)
        {
            string strText = "";
            FileStream fs = new FileStream(strFullFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("gb2312"));
            strText = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return strText;
        }
        #endregion
        #region "ɾ��HTML���"
        public static string funString_RemoveHtml(this string Htmlstring)  //�滻HTML���
        {
            //ɾ���ű�
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //ɾ��HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion


       






    }
}
