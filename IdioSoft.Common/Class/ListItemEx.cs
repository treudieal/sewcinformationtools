using System;
using System.Collections.Generic;
using System.Text;


namespace IdioSoft.Common.Class
{
   public class ListItemEx
    {
       string _Text = "";
       string _Value = "";
       string _Key = "";
       /// <summary>
       /// Item��Text
       /// </summary>
       public string Text
       {
           get
           {
               return _Text;
           }
           set
           {
               _Text = value;
           }
       }
       /// <summary>
       /// Item��Value
       /// </summary>
       public string Value
       {
           get
           {
               return _Value;
           }
           set
           {
               _Value = value;
           }
       }
       /// <summary>
       /// �󶨵�Key,������Կ����ڸ��������Ҫ��
       /// </summary>
       public string Key
       {
           get
           {
               return _Key;
           }
           set
           {
               _Key = value;
           }
       }
       string _DataType = "";
       public string DataType
       {
           get
           {
               return _DataType;
           }
           set
           {
               _DataType = value;
           }
       }
       /// <summary>
       /// ��дToString
       /// </summary>
       /// <returns></returns>
       public override string ToString()
       {
           return Text.ToString();
       }
       public ListItemEx()
       {
       }
       public ListItemEx(string strText,string strValue)
       {
           Text = strText;
           Value = strValue;
       }
       public ListItemEx(string strText, string strValue, string strKey)
       {
           Text = strText;
           Value = strValue;
           Key = strKey;
       }
       public ListItemEx(string strText, string strValue, string strKey,string strDataType)
       {
           Text = strText;
           Value = strValue;
           Key = strKey;
           DataType = strDataType;
       }
    }
}
