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

        #region "下拉菜单"
         
        #endregion

        /// <summary>
        /// 公用操作类
        /// </summary>
        #region "数据转换函数"
        /// <summary>
        /// 将格式Js中Alert显示的字符串
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string funString_JsToString(this string strValue)
        {

            string strTmp;
            strTmp = strValue;

            if ((strTmp != string.Empty) && (strTmp != ""))
            {
                strTmp = strTmp.Replace("'", "’");
                strTmp = strTmp.Replace("\"", "＂");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// 将字符串格式化为存入SQL的字符串
        /// </summary>   
        /// <param name="strValue">字符串</param>
        //public static string funString_SQLToString(this string strValue)
        //{
        //    string strTmp;
        //    strTmp = strValue;
        //    if ((strTmp == string.Empty) || (strTmp != ""))
        //    {
        //        strTmp = strTmp.Replace("'", "’");
        //        strTmp = strTmp.Replace("%", "％");
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
        ///// 允许为空的日期
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
        /// 将被格式化过的SQL的字符串转换为正常SQL语句
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static string funString_StringToSQL(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("’", "'");
                strTmp = strTmp.Replace("％", "%");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// 格式化做URL跳转的字符串到可做URL传值的字符串
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static string funString_RequestToString(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("?", "？");
                strTmp = strTmp.Replace("&", "＆");
                strTmp = strTmp.Replace("=", "＝");
                strTmp = strTmp.Replace("/", "／");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// 将被格式化过的URL的字符串转换为正常URL语句
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static string funString_StringToRequest(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("？", "?");
                strTmp = strTmp.Replace("＆", "&");
                strTmp = strTmp.Replace("＝", "=");
                strTmp = strTmp.Replace("／", "/");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>
        /// 将字符串格式化成XML,主要是将特殊字符转换为XML可用字符
        /// </summary>
        /// <param name="strContent">字符串</param>
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
        /// 数字月转换成英文缩写月如Jan.,Feb.等
        /// </summary>   
        /// <param name="intMonth">传入1到12个数字</param>
        public static string funString_NumMonthToEnglishAbb(this int intMonth)
        {
            string[] aryMonthAbb = { "Jan.", "Feb.", "Mar.", "Arp.", "May.", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec." };
            return aryMonthAbb[intMonth - 1];
        }
        /// <summary>
        /// 将字符转换为Ascw格式
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string funString_AscW(this string strContent)
        {
            return Microsoft.VisualBasic.Strings.AscW(strContent).ToString();
        }
        /// <summary>
        /// 将字符转换为boolean弄，如是是true就为true,如果是0就为false，非0都变1
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
        #region "日期操作"
        /// <summary>   
        /// 得到开始时间到结束时间中间隔的时间数
        /// </summary>   
        /// <param name="strInterval">年份yyyy年,q季,m月,y一年的日数,d日,w一周的日数,ww周,h时,n分钟,s秒</param>
        /// <param name="dtStartDate">开始日期</param>
        /// <param name="dtEndDate">结束日期</param>
        public static int funInt_DateInterval(this string strInterval, DateTime dtStartDate, DateTime dtEndDate)
        {
            return (int)Microsoft.VisualBasic.DateAndTime.DateDiff(strInterval, dtStartDate, dtEndDate, 0, 0);
        }
        /// <summary>   
        /// 得到日期是周几,返回数字,例如:0为星期日.
        /// </summary>   
        /// <param name="dtCurrentDate">日期</param>
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
        #region"验证函数"
        /// <summary>   
        /// 验证是否是闰年,如果是返回true,否则false
        /// </summary>   
        /// <param name="intYear">年份</param>
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
        /// 验证是否是正确格式电话号码,如果是返回true,否则false
        /// </summary>   
        /// <param name="strTel">电话号码</param>
        public static Boolean funBoolean_ValidTel(this string strTel)
        {
            return Regex.IsMatch(strTel, @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?");
        }
        /// <summary>   
        /// 验证是否是正确格式手机号码,如果是返回true,否则false
        /// </summary>   
        /// <param name="strMobile">手机号码</param>
        public static Boolean funBoolean_ValidMobile(this string strMobile)
        {
            return Regex.IsMatch(strMobile, @"\d{11}");
        }
        /// <summary>   
        /// 验证是否是正确格式邮政编码,如果是返回true,否则false
        /// </summary>   
        /// <param name="strPostCode">邮政编码</param>
        public static Boolean funBoolean_ValidPostcode(this string strPostCode)
        {
            return Regex.IsMatch(strPostCode, @"\d{6}");
        }
        /// <summary>   
        /// 验证是否是正确格式Email,如果是返回true,否则false
        /// </summary>   
        /// <param name="strEmail">Email</param>
        public static bool funBoolean_ValidEmail(this string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>   
        /// 验证是否是正确格式日期时间,如果是返回true,否则false
        /// </summary>   
        /// <param name="strDate">日期格式</param>
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
        /// 验证是否是正确格式数字,如果是返回true,否则false
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
        #region "数据验证函数，并且返回值"
        /// <summary>   
        /// 验证是否是数字,如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="intDefault">默认值</param>
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
        /// 验证是否是数字,如果true,再判断是否在intMin与intMax之间,如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="intMin">区间的最小允许值</param>
        /// <param name="intMax">区间的最大允许值</param>
        /// <param name="intDefault">默认值</param>
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
        /// 验证是否是数字,并且返回decimal(带小数点类型),如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="decDefault">默认值</param>
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
        /// 验证是否是Uniqueidentifier格式,并且返回string,如果true返回strValue,false返回strDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="strDefault">默认值</param>
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
        /// 返回GUID,可为空
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
        /// 将boolean或字符转换为int
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
        /// 将Bool字符串转化为0,1
        /// </summary>   
        /// <param name="strValue">字符串</param>
        //public static int funInt_BoolToString(this string strValue)
        //{
        //    return (strValue.Trim().ToLower() == "true") ? 1 : 0;
        //}
        /// <summary>   
        /// 验证是否是时间，并且返回数据库操作的字符：如果是''，那么返回null；否则，返回'+date+'
        /// </summary>   
        /// <param name="strValue">字符串</param>
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
        ///// 验证是否是时间，并且返回数据库操作的字符：如果是''，那么返回null；否则，返回'+date+'
        ///// </summary>   
        ///// <param name="strValue">字符串</param>
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
        /// 时间转为空
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
        #region "文件操作相关函数"
        /// <summary>
        /// 验证选择上传的文件是否在允许的文件内
        /// </summary>
        /// <param name="fileAttachmentName">上传文件控件</param>
        /// <param name="blnAllowNull">是否允许空文件：True为允许；False为不允许</param>
        /// <param name="blnFilter">是允许strFilter类型的文件上传还是不允许strFilter类型的文件上传：True为不允许；False为允许</param>
        /// <param name="strFilter">定义什么类型文件为才能上传,如果为false,只能是Filter中的文件类型,true为不能为Filter中的文件类型|.asp|.exe|.htm|.html|.aspx|.cs|.vb|.js|</param>
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
                        return "不允许上传" + strFilter + "等后缀名以外的文件！";
                    }
                }
                else
                {
                    if (strFilter.IndexOf(strDocExtension) >= 0)
                    {
                        return "不允许上传" + strFilter + "等后缀名的文件！";
                    }
                }
            }
            else
            {
                if (!blnAllowNull)
                {
                    return "请选择相关附件！";
                }
            }
            return "";
        }


        /// <summary>   
        /// 得到上传的附件格式化的名字一般格式为yyyyMMddhhmmss
        /// </summary>   
        /// <param name="strAttachmentName">完整文件名</param>
        public static string funString_FormatAttachmentName(this string strAttachmentName)
        {
            //文件名应该截取到只有260位,因为数据库中只定义了260位的长度
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
        /// 上传文件附件,并返回文件名,如果用户不指定文件名,文件名将格式为yyyyMMddhhmmss
        /// </summary>   
        /// <param name="strFileName">文件名</param>
        /// <param name="strDirPath">保存文件目录名</param>
        /// <param name="fileAttachmentName">上传文件控件</param>
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
        /// 上传文件附件,并返回文件名,如果用户不指定文件名,文件名将格式为yyyyMMddhhmmss
        /// </summary>   
        /// <param name="strFileName">文件名</param>
        /// <param name="strDirPath">保存文件目录名</param>
        /// <param name="fileAttachmentName">上传文件控件</param>
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
        /// 读取文件的内容
        /// </summary>
        /// <param name="strRelativePath">文件的相对路径</param>
        /// <param name="objEncoding">编码格式</param>
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
        #region "ComboBox,CheckBoxList,RadioButtonList函数"
        /// <summary>   
        /// 根据Value设置选中ComboBox的选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
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
        /// 根据Value设置选中ComboBox的选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
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
        /// 根据Value内容选择Item，如果没有选择相应选项，那么就选择默认选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
        /// <param name="DefaultValue">默认选项的Value</param>
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
        /// 根据Value内容选择Item，如果没有选择相应选项，那么就选择默认选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
        /// <param name="DefaultValue">默认选项的Value</param>
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
        /// 设置选中CheckBoxList的选项
        /// </summary>   
        /// <param name="chklstName">CheckBoxList</param>
        /// <param name="SelectedValues">要选中的Item的值列表</param>
        /// <param name="strSplitChar">SelectedValues中的分割符</param>
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
        /// 根据Text设置选中ComboBox的选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
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
        /// 根据Text设置选中ComboBox的选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
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
        /// 根据Text内容选择Item，如果没有选择相应选项，那么就选择默认选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
        /// <param name="DefaultValue">默认选项的Text</param>
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
        /// 根据Text内容选择Item，如果没有选择相应选项，那么就选择默认选项
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="SelectedValue">要选中的Item的值</param>
        /// <param name="DefaultValue">默认选项的Text</param>
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
        /// 载入数据列到ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">取值的SQL</param>
        /// <param name="IsDisplayDefaultText">是否显示默认的选项</param>
        public static void subComboBox_LoadItemsByDBColumnName(this HtmlSelect cboName, string strSearchSQL, bool IsDisplayDefaultText)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----选择所有记录-----";
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
        /// 载入数据列到ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">取值的SQL</param>
        /// <param name="IsDisplayDefaultText">是否显示默认的选项</param>
        /// <param name="isType">是否带上类型</param>
        public static void subComboBox_LoadItemsByDBColumnName(this DropDownList cboName, string strSearchSQL, bool IsDisplayDefaultText, bool isType)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----选择所有记录-----";
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
        /// 载入数据列到ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">取值的SQL</param>
        /// <param name="IsDisplayDefaultText">是否显示默认的选项</param>
        /// <param name="DefaultField">默认的选项</param>
        public static void subComboBox_LoadItemsByDBColumnName(this DropDownList cboName, string strSearchSQL, bool IsDisplayDefaultText, string DefaultField)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----选择所有记录-----";
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
        /// 载入数据列到ComboBox
        /// </summary>   
        /// <param name="cboName">ComboBox</param>
        /// <param name="strSearchSQL">取值的SQL</param>
        /// <param name="IsDisplayDefaultText">是否显示默认的选项</param>
        ///  <param name="strSearchSQL">默认的选项</param>
        public static void subComboBox_LoadItemsByDBColumnName(this HtmlSelect cboName, string strSearchSQL, bool IsDisplayDefaultText, string DefaultField)
        {
            cboName.Items.Clear();
            ListItem item;
            if (IsDisplayDefaultText)
            {
                item = new ListItem();
                item.Value = "SelectAll";
                item.Text = "-----选择所有记录-----";
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
        /// 返回RadioButtonList是否有选中项,如果选中的Item值为1就返回1,否则返回0,如是SelectedIndex为0返回null,这个函数主要用于数据库存RadioButtonList值用.
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
        /// 设置RadioButtonList被选中的项
        /// </summary>   
        /// <param name="rdoButtonlist">RadioButtonList</param>
        /// <param name="itemValue">需要被选中的Item项的值</param>
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
        /// 返回ComboBox选中Item的Text
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
        /// 返回ComboBox选中Item的Text
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
        /// 返回ComboBox选中Item的Value
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
        /// 返回ComboBox选中Item的Value
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
        /// 载入ComboBox的Item项,如果列数大于1,将0列为Value,1列为Text
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        /// <param name="strSearchSQL">操作的SQL</param>
        /// <param name="intSelectIndex">默认选中的Index</param>
        /// <param name="ItemDefault">如果为空，则不指定默认Item项，否则ItemDefault为默认项</param>
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
        ///// 载入ComboBox的Item项,如果列数大于1,将0列为Value,1列为Text
        ///// </summary>   
        ///// <param name="cboBox">cboBox</param>
        ///// <param name="strSearchSQL">操作的SQL</param>
        ///// <param name="intSelectIndex">默认选中的Index</param>
        ///// <param name="ItemDefault">如果为空，则不指定默认Item项，否则ItemDefault为默认项</param>
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
        /// 返回选中的RadionButtonList的值
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
        /// 返回CheckBox状态,用0,1返回,0为没选中,1为选中
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
        /// 返回CheckBox状态,用0,1返回,0为没选中,1为选中
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
        //#region"发送Email"
        ///// <summary>
        ///// 用webMail方式发送Mail,成功返回"",失败返回错误代码
        ///// </summary>
        ///// <param name="strSendMail">发送人的Mail</param>
        ///// <param name="strSendUserName">发送人的用户名</param>
        ///// <param name="strSendUserPassword">发送人的密码</param>
        ///// <param name="strBody">发送内容</param>
        ///// <param name="strSmtp">Smtp Server</param>
        ///// <param name="strToMail">接收人的Mail</param>
        ///// <param name="strSubject">发送主题</param>
        ///// <param name="strCc">抄送人的Mail</param>
        ///// <param name="isDellAttachment">发送后是否删除附件</param>
        ///// <param name="strBcc">暗送人的Mail</param>
        ///// <param name="aryAttachment">附件列表</param>
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
        //    //附件
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
        //    //验证
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", strSendUserName); //set your username here 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", strSendUserPassword); //set your password here 
        //    //发送
        //    try
        //    {
        //        System.Web.Mail.SmtpMail.Send(objMailMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        strReturn = ex.Source + "\n" + ex.Message;
        //    }
        //    //删除文件
        //    try
        //    {
        //        //删除文件
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
        ///// 用NetMail方式发送Mail,成功返回"",失败返回错误代码
        ///// </summary>
        ///// <param name="strSendMail">发送人的Mail</param>
        ///// <param name="strSendUserName">发送人的用户名</param>
        ///// <param name="strSendUserPassword">发送人的密码</param>
        ///// <param name="strBody">发送内容</param>
        ///// <param name="strSmtp">Smtp Server</param>
        ///// <param name="strToMail">接收人的Mail</param>
        ///// <param name="strSubject">发送主题</param>
        ///// <param name="strCc">抄送人的Mail</param>
        ///// <param name="isDellAttachment">发送后是否删除附件</param>
        ///// <param name="strBcc">暗送人的Mail</param>
        ///// <param name="aryAttachment">附件列表</param>
        ///// <returns></returns>
        //public static string funString_SendMailByNetMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, ArrayList aryAttachment)
        //{
        //    string strReturn = "";
        //    System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
        //    //设置信件的基本信息
        //    objMailMessage.Subject = strSubject;
        //    objMailMessage.Body = strBody;
        //    objMailMessage.IsBodyHtml = true;
        //    objMailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
        //    //设置发件人
        //    System.Net.Mail.MailAddress objMailAddress = new System.Net.Mail.MailAddress(strSendMail);
        //    objMailMessage.From = objMailAddress;

        //    //设置收件人
        //    string[] aryToMail = strToMail.Split(';');
        //    for (int i = 0; i < aryToMail.Length; i++)
        //    {
        //        objMailMessage.To.Add(aryToMail[i].ToString());
        //    }
        //    //设置CC
        //    if (strCc != "")
        //    {
        //        string[] aryCCMail = strCc.Split(';');
        //        for (int i = 0; i < aryCCMail.Length; i++)
        //        {
        //            objMailMessage.To.Add(aryCCMail[i].ToString());
        //        }
        //    }
        //    //设置BCC
        //    if (strBcc != "")
        //    {
        //        string[] aryBCCMail = strCc.Split(';');
        //        for (int i = 0; i < aryBCCMail.Length; i++)
        //        {
        //            objMailMessage.Bcc.Add(aryBCCMail[i].ToString());
        //        }
        //    }
        //    //附件
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
        //    //发送
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
        //        //删除文件
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
        ///// 发送匿名Email
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
        //    //附件
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
        #region"判断进程启动时间，找出相应的进程并杀死进程"
        /// <summary>
        /// 判断进程启动时间，找出相应的进程并杀死进程
        /// </summary>   
        /// <param name="dtStartDate">进程启用开始时间</param>
        /// <param name="dtEndDate">进程启用结束时间</param>
        /// <param name="strProcessName">杀死的进程名</param>
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
        #region "读取一个word的XML模板文件"
        /// <summary>
        /// 读取一个word的XML模板文件
        /// </summary>   
        /// <param name="strTemplateAbsolutePath">模板的完整地址</param>
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
        #region "中文->UTF8 CODE"
        /// <summary>
        /// 中文->UTF8 CODE
        /// </summary>   
        /// <param name="strContent">字符串</param>
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
        //#region"Request字符读取"
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
        /// 填充CheckListBox
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <param name="strSearchSQL">第一位为ID,第二位为Text</param>
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
        /// 根据Value勾选CheckListBox
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
        /// 返回CheckListBox勾选中的值
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
        #region "搜索控件FindControl功能扩展"
        /// <summary>
        /// 用递规搜索
        /// </summary>
        /// <param name="o">一个虚的传值</param>
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
        #region "当前财年"
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
        /// 载入下拉菜单真假
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
        /// 填充CheckBoxList
        /// </summary>
        /// <param name="objchkListBox"></param>
        /// <param name="strSearchSQL">第一位为ID,第二位为Text</param>
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
        /// 将字符转换为boolean，如是是true就为true,如果是0就为false，非0都变1
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
        /// 上传文件附件,并返回文件名,如果用户不指定文件名,文件名将格式为yyyyMMddhhmmss
        /// </summary>
        /// <param name="fileAttachmentName">上传文件控件</param>
        /// <param name="strFileName">新文件名</param>
        /// <param name="FileNameLength">如果不指定文件名，那么文件名称最大长度</param>
        /// <param name="strDirPath">保存文件目录名，使用/结尾</param>
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
        /// 得到上传的附件格式化的名字一般格式为yyyyMMddHHmmss
        /// </summary>
        /// <param name="strAttachmentName">完整文件名</param>
        /// <param name="FileNameLength">新文件名的长度</param>
        /// <returns></returns>
        public static string funString_FormatAttachmentName(this string strAttachmentName, int FileNameLength)
        {
            //得到文件名
            string strFileName;
            strFileName = strAttachmentName;
            if (strFileName == "")
            {
                return "";
            }

            //得到原文件的后缀名(包括.号)
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

            //得到加上时间格式后的文件实际长度
            int intLen;
            intLen = strFileName.Length + 14;//14是时间字符串的长度

            //不允许实际长度超过设置的文件名长度
            if (intLen > FileNameLength)
            {
                intLen = FileNameLength;
            }
            //将文件名长度减掉默认的时间的长度和后缀，就是我们要使用的文件名称长度
            intLen = intLen - 14 - intSuffix;
            //文件名=时间格式+文件名+后缀
            strFileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + strFileName.Substring(0, intLen) + strSuffix;

            return strFileName;
        }

        #region "读取一个HTML文件"
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
        #region "删除HTML标记"
        public static string funString_RemoveHtml(this string Htmlstring)  //替换HTML标记
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
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
