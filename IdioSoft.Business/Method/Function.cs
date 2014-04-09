using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mail;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;

namespace IdioSoft.Business.Method
{
    public static class Function
    {
        public enum SelectAdapterType
        {
            Value = 0,
            Text = 1
        }

        #region "droplist operation"
        /// <summary>
        /// 返回ComboBox选中Item的Text
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        [Obsolete("用funComboBox_SelectItemValue替换")]
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
        [Obsolete("用funComboBox_SelectItemValue替换")]
        public static string funComboBox_SelectedText(this DropDownList cboBox)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                strText = cboBox.Items[cboBox.SelectedIndex].Text;
            }
            return strText;
        }

        [Obsolete("用subComboBox_SelectItem替换")]
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
        [Obsolete("用subComboBox_SelectItem替换")]
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
        public static void subComboBox_LoadItems(this HtmlSelect cboBox, string strSearchSQL, int intSelectIndex, ListItem ItemDefault)
        {
            cboBox.Items.Clear();
            ListItem item;
            string strSQL;
            strSQL = strSearchSQL;
 
            DataSet ds = new DataSet();
            ds = SQLDbHelper.GetInstance().funDataset_SQLExecuteNonQuery(strSearchSQL);

            int intCount = -1;
            intCount = ds.Tables[0].Rows.Count;
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            int intColumnsCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                if (intColumnsCount > 1)
                {
                    item.Text = ds.Tables[0].Rows[i][1].ToString();
                }
                else
                {
                    item.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                item.Value = ds.Tables[0].Rows[i][0].ToString();
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = intSelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// 载入ComboBox的Item项,如果列数大于1,将0列为Value,1列为Text
        /// </summary>   
        /// <param name="cboBox">cboBox</param>
        /// <param name="strSearchSQL">操作的SQL</param>
        /// <param name="intSelectIndex">默认选中的Index</param>
        /// <param name="ItemDefault">如果为空，则不指定默认Item项，否则ItemDefault为默认项</param>
        public static void subComboBox_LoadItems(this DropDownList cboBox, string strSearchSQL, int intSelectIndex, ListItem ItemDefault)
        {
            cboBox.Items.Clear();
            ListItem item;
            string strSQL;
            strSQL = strSearchSQL;
             DataSet ds = new DataSet();
             ds = SQLDbHelper.GetInstance().funDataset_SQLExecuteNonQuery(strSearchSQL);

            int intCount = -1;
            intCount = ds.Tables[0].Rows.Count;
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            int intColumnsCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                if (intColumnsCount > 1)
                {
                    item.Text = ds.Tables[0].Rows[i][1].ToString();
                }
                else
                {
                    item.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                item.Value = ds.Tables[0].Rows[i][0].ToString();
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = intSelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load drop list
        /// </summary>
        /// <param name="cboBox">DropList</param>
        /// <param name="ds">DataSet</param>
        /// <param name="SelectIndex">Select item index</param>
        /// <param name="ItemDefault">Default item</param>
        public static void subComboBox_LoadItems(this HtmlSelect cboBox, DataSet ds, int intSelectIndex, ListItem ItemDefault)
        {
            cboBox.Items.Clear();
            ListItem item;
            int intCount = -1;
            intCount = ds.Tables[0].Rows.Count;
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            int intColumnsCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                if (intColumnsCount > 1)
                {
                    item.Text = ds.Tables[0].Rows[i][1].ToString();
                }
                else
                {
                    item.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                item.Value = ds.Tables[0].Rows[i][0].ToString();
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = intSelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// Load drop list
        /// </summary>
        /// <param name="cboBox">DropList</param>
        /// <param name="ds">DataSet</param>
        /// <param name="SelectIndex">Select item index</param>
        /// <param name="ItemDefault">Default item</param>
        public static void subComboBox_LoadItems(this DropDownList cboBox, DataSet ds, int intSelectIndex, ListItem ItemDefault)
        {
            cboBox.Items.Clear();
            ListItem item;
            int intCount = -1;
            intCount = ds.Tables[0].Rows.Count;
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            int intColumnsCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                if (intColumnsCount > 1)
                {
                    item.Text = ds.Tables[0].Rows[i][1].ToString();
                }
                else
                {
                    item.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                item.Value = ds.Tables[0].Rows[i][0].ToString();
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = intSelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load drop list
        /// </summary>
        /// <param name="cboBox">DropList</param>
        /// <param name="lst">List<Object></param>
        /// <param name="SelectIndex">Select item index</param>
        /// <param name="ItemDefault">Default item</param>
        /// <param name="args">colums name,0 is value,1 is text</param>
        public static void subComboBox_LoadItems(this HtmlSelect cboBox, List<Object> lst, int SelectIndex, ListItem ItemDefault, params string[] args)
        {
            cboBox.Items.Clear();
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            ListItem item;
            for (int i = 0; i < lst.Count; i++)
            {
                item = new ListItem();
                object o = lst[i];

                item.Value = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();

                if (args.Length > 1)
                {
                    item.Text = o.GetType().GetProperty(args[1]).GetValue(o, null).ToString();
                }
                else
                {
                    item.Text = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();
                }
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = SelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// Load drop list
        /// </summary>
        /// <param name="cboBox">DropList</param>
        /// <param name="ObjectUnit">DbUnit</param>
        /// <param name="SelectIndex">Select item index</param>
        /// <param name="ItemDefault">Default item</param>
        /// <param name="args">colums name</param>
        public static void subComboBox_LoadItems(this DropDownList cboBox, Object ObjectUnit, int SelectIndex, ListItem ItemDefault, params string[] args)
        {
            cboBox.Items.Clear();
            ListItem item;
            int intCount = -1;
            intCount = ((Columns)ObjectUnit).Count;
            if (ItemDefault != null)
            {
                cboBox.Items.Add(ItemDefault);
            }
            int intColumnsCount = args.Length;
            IDBUnit objView = new CView(ObjectUnit);
            List<Object> lst = objView.getDatas("");
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                object o = lst[i];

                item.Value = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();

                if (args.Length > 1)
                {
                    item.Text = o.GetType().GetProperty(args[1]).GetValue(o, null).ToString();
                }
                else
                {
                    item.Text = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();
                }
                cboBox.Items.Add(item);
            }
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = SelectIndex;
            }
            else
            {
                cboBox.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// Load Item by Value or Text
        /// </summary>
        /// <param name="cboBox">Drop list</param>
        /// <param name="Value">Select Item Value</param>
        /// <param name="sAType">Value or Text</param>
        public static void subComboBox_SelectItem(this HtmlSelect cboBox, string Value, SelectAdapterType sAType)
        {
            int intCount;
            intCount = cboBox.Items.Count;
            switch (sAType)
            {
                case SelectAdapterType.Value:
                    for (int i = 0; i < intCount; i++)
                    {
                        if (cboBox.Items[i].Value.ToLower().Trim() == Value.ToLower().Trim())
                        {
                            cboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                case SelectAdapterType.Text:
                    for (int i = 0; i < intCount; i++)
                    {
                        if (cboBox.Items[i].Text.ToLower().Trim() == Value.ToLower().Trim())
                        {
                            cboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Load Item by Value or Text
        /// </summary>
        /// <param name="cboBox">Drop list</param>
        /// <param name="Value">Select Item Value</param>
        /// <param name="sAType">Value or Text</param>
        public static void subComboBox_SelectItem(this DropDownList cboBox, string Value, SelectAdapterType sAType)
        {
            int intCount;
            intCount = cboBox.Items.Count;
            switch (sAType)
            {
                case SelectAdapterType.Value:
                    for (int i = 0; i < intCount; i++)
                    {
                        if (cboBox.Items[i].Value.ToLower().Trim() == Value.ToLower().Trim())
                        {
                            cboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                case SelectAdapterType.Text:
                    for (int i = 0; i < intCount; i++)
                    {
                        if (cboBox.Items[i].Text.ToLower().Trim() == Value.ToLower().Trim())
                        {
                            cboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// get drop list select item text or value
        /// </summary>
        /// <param name="cboBox">drop list</param>
        /// <param name="sAType">Value or Text</param>
        /// <returns>text</returns>
        public static string funComboBox_SelectItemValue(this HtmlSelect cboBox, SelectAdapterType sAType)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                if (sAType == SelectAdapterType.Text)
                {
                    strText = cboBox.Items[cboBox.SelectedIndex].Text;
                }
                else
                {
                    strText = cboBox.Items[cboBox.SelectedIndex].Value;
                }
            }
            return strText;
        }
        /// <summary>
        /// get drop list select item text or value
        /// </summary>
        /// <param name="cboBox">drop list</param>
        /// <param name="sAType">Value or Text</param>
        /// <returns>text</returns>
        public static string funComboBox_SelectItemValue(this DropDownList cboBox, SelectAdapterType sAType)
        {
            string strText = "";
            if (cboBox.Items.Count > 0)
            {
                if (sAType == SelectAdapterType.Text)
                {
                    strText = cboBox.Items[cboBox.SelectedIndex].Text;
                }
                else
                {
                    strText = cboBox.Items[cboBox.SelectedIndex].Value;
                }
            }
            return strText;
        }
        #endregion
        #region "checklist operation"
        /// <summary>
        /// load checkboxlist
        /// </summary>
        /// <param name="chklst">Checkboxlist</param>
        /// <param name="ObjectUnit">DbUnit</param>
        /// <param name="args">colums name,0 is value,1 is text</param>
        public static void subCheckListBox_LoadItems(this CheckBoxList chklst, Object ObjectUnit, params string[] args)
        {
            chklst.Items.Clear();
            ListItem item;
            int intCount = -1;
            intCount = ((Columns)ObjectUnit).Count;
            int intColumnsCount = args.Length;
            IDBUnit objView = new CView(ObjectUnit);
            List<Object> lst = objView.getDatas("");
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                object o = lst[i];

                item.Value = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();

                if (args.Length > 1)
                {
                    item.Text = o.GetType().GetProperty(args[1]).GetValue(o, null).ToString();
                }
                else
                {
                    item.Text = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();
                }
                chklst.Items.Add(item);
            }
        }
        /// <summary>
        /// get checkboxlist item to list
        /// </summary>
        /// <param name="chklst">CheckBoxList</param>
        /// <param name="sAType">Value or Text</param>
        public static List<string> funCheckListBox_SelectList(this CheckBoxList chklst, SelectAdapterType sAType)
        {
            List<string> lst = new List<string>();
            string strTmp = "";
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.Items[i].Selected)
                {
                    if (sAType == SelectAdapterType.Value)
                    {
                        strTmp = chklst.Items[i].Value;
                    }
                    else
                    {
                        strTmp = chklst.Items[i].Text;
                    }
                    lst.Add(strTmp);
                }
            }
            return lst;
        }
        /// <summary>
        /// get checklistbox select values split
        /// </summary>
        /// <param name="chklst">Checkboxlist</param>
        /// <param name="sAType">Value or Text</param>
        /// <returns></returns>
        public static string funCheckListBox_SelectValues(this CheckBoxList chklst, SelectAdapterType sAType, string Separate = ",")
        {
            StringBuilder sb = new StringBuilder();
            string strTmp = "";
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.Items[i].Selected)
                {
                    if (sAType == SelectAdapterType.Value)
                    {
                        strTmp = chklst.Items[i].Value;
                    }
                    else
                    {
                        strTmp = chklst.Items[i].Text;
                    }
                    sb.Append(strTmp + Separate);
                }
            }
            strTmp = sb.ToString();
            if (strTmp != "")
            {
                strTmp = strTmp.Substring(0, strTmp.Length - Separate.Length);
            }
            return strTmp;
        }
        /// <summary>
        /// set items checked by value or text
        /// </summary>
        /// <param name="chklst">CheckBoxList</param>
        /// <param name="lstValue">List<string></param>
        /// <param name="sAType">Value or Text</param>
        public static void subCheckListBox_Selectitems(this CheckBoxList chklst, List<string> lstValue, SelectAdapterType sAType)
        {
            string strTmp = "";
            List<string> lstTmp = new List<string>();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (sAType == SelectAdapterType.Text)
                {
                    strTmp = chklst.Items[i].Text;
                }
                else
                {
                    strTmp = chklst.Items[i].Value;
                }
                if (lstValue.Contains(strTmp))
                {
                    chklst.Items[i].Selected = true;
                }
            }
        }
        /// <summary>
        /// set items checked by value or text
        /// </summary>
        /// <param name="chklst">CheckBoxList</param>
        /// <param name="Values">Values</param>
        /// <param name="sAType">Value or Text</param>
        /// <param name="Separate">default is ,</param>
        public static void subCheckListBox_Selectitems(this CheckBoxList chklst, string Values, SelectAdapterType sAType, string Separate = ",")
        {
            string strTmp = "";
            Values = Separate + Values + Separate;
            List<string> lstTmp = new List<string>();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (sAType == SelectAdapterType.Text)
                {
                    strTmp = chklst.Items[i].Text.Trim().ToLower();
                }
                else
                {
                    strTmp = chklst.Items[i].Value.Trim().ToLower();
                }
                if (Values.ToLower().IndexOf(Separate + strTmp + Separate) >= 0)
                {
                    chklst.Items[i].Selected = true;
                }
            }
        }
        #endregion
        #region "radiolist operation"
        /// <summary>
        /// load RadioButtonList
        /// </summary>
        /// <param name="chklst">RadioButtonList</param>
        /// <param name="ObjectUnit">DbUnit</param>
        /// <param name="args">colums name,0 is value,1 is text</param>
        public static void subRadioButtonList_LoadItems(this RadioButtonList rdolst, Object ObjectUnit, params string[] args)
        {
            rdolst.Items.Clear();
            ListItem item;
            int intCount = -1;
            intCount = ((Columns)ObjectUnit).Count;
            int intColumnsCount = args.Length;
            IDBUnit objView = new CView(ObjectUnit);
            List<Object> lst = objView.getDatas("");
            for (int i = 0; i < intCount; i++)
            {
                item = new ListItem();
                object o = lst[i];

                item.Value = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();

                if (args.Length > 1)
                {
                    item.Text = o.GetType().GetProperty(args[1]).GetValue(o, null).ToString();
                }
                else
                {
                    item.Text = o.GetType().GetProperty(args[0]).GetValue(o, null).ToString();
                }
                rdolst.Items.Add(item);
            }
        }
        /// <summary>
        /// get RadioButtonList item value
        /// </summary>
        /// <param name="rdolst">RadioButtonList</param>
        /// <param name="sAType">Value or Text</param>
        /// <returns></returns>
        public static string funRadioButtonList_SelectValue(this RadioButtonList rdolst, SelectAdapterType sAType)
        {
            StringBuilder sb = new StringBuilder();
            string strTmp = "";
            for (int i = 0; i < rdolst.Items.Count; i++)
            {
                if (rdolst.Items[i].Selected)
                {
                    if (sAType == SelectAdapterType.Value)
                    {
                        strTmp = rdolst.Items[i].Value;
                    }
                    else
                    {
                        strTmp = rdolst.Items[i].Text;
                    }
                }
            }
            return strTmp;
        }
        /// <summary>
        /// set RadioButtonList selected item
        /// </summary>
        /// <param name="rdolst">RadioButtonList</param>
        /// <param name="Value">Value</param>
        /// <param name="sAType">Value or Text</param>
        public static void subRadioButtonList_Selectitems(this RadioButtonList rdolst, string Value, SelectAdapterType sAType)
        {
            string strTmp = "";
            List<string> lstTmp = new List<string>();
            for (int i = 0; i < rdolst.Items.Count; i++)
            {
                if (sAType == SelectAdapterType.Text)
                {
                    strTmp = rdolst.Items[i].Text;
                }
                else
                {
                    strTmp = rdolst.Items[i].Value;
                }
                if (Value.ToLower().Trim() == strTmp.ToLower().Trim())
                {
                    rdolst.Items[i].Selected = true;
                }
            }
        }
        #endregion

        #region "format string"
        /// <summary>
        /// Format string to alert js
        /// </summary>
        /// <param name="strValue">Value</param>
        /// <returns></returns>
        public static string funString_JsToString(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp != string.Empty) && (strTmp != ""))
            {
                strTmp = strTmp.Replace("'", "’");
                strTmp = strTmp.Replace("\"", "＂");
                strTmp = strTmp.Replace(System.Environment.NewLine, "");
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// Format SQL String to Save SQL
        /// </summary>   
        /// <param name="strValue">Value</param>
        public static string funString_SQLToString(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("'", "’");
                strTmp = strTmp.Replace("\"", "&quot;");
                strTmp = strTmp.Replace("<", "&lt;");
                strTmp = strTmp.Replace(">", "&gt;");
                strTmp = strTmp.Replace("\n", "<br>");
                return strTmp;
            }
            else
            {
                strTmp = "";
            }
            return strTmp;
        }
        /// <summary>   
        /// Load Save SQL
        /// </summary>   
        /// <param name="strValue">Value</param>
        public static string funString_StringToSQL(this string strValue)
        {
            string strTmp;
            strTmp = strValue;
            if ((strTmp == string.Empty) || (strTmp != ""))
            {
                strTmp = strTmp.Replace("’", "'");
                strTmp = strTmp.Replace("&quot;", "\"");
                strTmp = strTmp.Replace("&lt;", "<");
                strTmp = strTmp.Replace("&gt;", ">");
                strTmp = strTmp.Replace("<br>", "\n");
                return strTmp;
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
        public static Boolean funBoolean_StringToBoolean(this string strContent)
        {
            if (strContent.ToLower() == "true")
            {
                return true;
            }
            if (strContent.ToLower() == "false")
            {
                return false;
            }
            int intContent = funInt_StringToInt(strContent, 0);
            if (intContent > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>   
        /// 验证是否是数字,如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="intDefault">默认值</param>
        public static int funInt_StringToInt(this string strValue, int intDefault)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
            {
                try
                {

                    return (int)(strValue.funDec_StringToDecimal(0));
                }
                catch
                {
                    return intDefault;
                }
            }
            else
            {
                return intDefault;
            }
        }
        public static long funInt_StringToLong(this string strValue, long intDefault)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
            {
                try
                {

                    return (long)(strValue.funDec_StringToDecimal(0));
                }
                catch
                {
                    return intDefault;
                }
            }
            else
            {
                return intDefault;
            }
        }
        public static DateTime funDateTime_StringToDatetime(this string strValue)
        {
            if (Microsoft.VisualBasic.Information.IsDate(strValue))
            {
                return DateTime.Parse(strValue);
            }
            else
            {
                return DateTime.Parse("1900-01-01");
            }
        }
        public static string funString_StringToDatetimeBlank(this string strValue,string Formater)
        {
            if (Microsoft.VisualBasic.Information.IsDate(strValue))
            {
                return DateTime.Parse(strValue).ToString(Formater);
            }
            else
            {
                return "";
            }
        }
        public static string funString_StringToDatetime(this DateTime dt)
        {
            if (dt.Year == 1900)
            {
                return null;
            }
            else
            {
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public static string funString_StringToDatetime(this DateTime? dt)
        {
            if (dt == null)
            {
                return null;
            }
            DateTime d1 = (DateTime)dt;
            if (d1.Year == 1900)
            {
                return null;
            }
            else
            {
                return d1.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 允许为空的日期
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static DateTime? funDateTime_StringToDatetimeAllowNull(this string strValue)
        {
            if (strValue.Trim() == "")
            {
                return null;
            }
            if (Microsoft.VisualBasic.Information.IsDate(strValue))
            {
                return DateTime.Parse(strValue);
            }
            else
            {
                return null;
            }
        }
        /// <summary>   
        /// 验证是否是数字,如果true,再判断是否在intMin与intMax之间,如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="intMin">区间的最小允许值</param>
        /// <param name="intMax">区间的最大允许值</param>
        /// <param name="intDefault">默认值</param>
        public static int funInt_StringToInt(this string strValue, int intMin, int intMax, int intDefault)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
            {
                int intValue;
                intValue = int.Parse(strValue);
                if (intMin <= intValue && intValue <= intMax)
                {
                    return intValue;
                }
                else
                {
                    return intDefault;
                }
            }
            else
            {
                return intDefault;
            }
        }
        /// <summary>   
        /// 验证是否是数字,并且返回Double(带小数点类型),如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="dblDefault">默认值</param>
        public static double funDbl_StringToDouble(this string strValue, double dblDefault)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
            {
                return double.Parse(strValue);
            }
            else
            {
                return dblDefault;
            }
        }
        /// <summary>   
        /// 验证是否是数字,并且返回decimal(带小数点类型),如果true返回strValue,false返回intDefault
        /// </summary>   
        /// <param name="strValue">字符串</param>
        /// <param name="decDefault">默认值</param>
        public static decimal funDec_StringToDecimal(this string strValue, decimal decDefault)
        {
            if (Microsoft.VisualBasic.Information.IsNumeric(strValue))
            {
                return decimal.Parse(strValue);
            }
            else
            {
                return decDefault;
            }
        }
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
        public static int funInt_StringOrBooleanToInt(this string strValue)
        {
            if (strValue.Trim().ToLower() == "true")
            {
                return 1;
            }
            if (strValue.Trim().ToLower() == "false")
            {
                return 0;
            }
            return strValue.funInt_StringToInt(0);
        }
        /// <summary>   
        /// 将Bool字符串转化为0,1
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static int funInt_BoolToString(this string strValue)
        {
            return (strValue.Trim().ToLower() == "true") ? 1 : 0;
        }
        /// <summary>   
        /// 验证是否是时间，并且返回数据库操作的字符：如果是''，那么返回null；否则，返回'+date+'
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static string funString_StringToDBDate(this string strValue)
        {
            if (strValue == null)
            {
                return "NULL";
            }
            if (strValue == "")
            {
                return "NULL";
            }
            else
            {
                if (funBoolean_ValidDate(strValue))
                {
                    return "'" + strValue + "'";
                }
                else
                {
                    return "NULL";
                }
            }
        }
        /// <summary>   
        /// 验证是否是时间，并且返回数据库操作的字符：如果是''，那么返回null；否则，返回'+date+'
        /// </summary>   
        /// <param name="strValue">字符串</param>
        public static string funString_StringToDBDate(this string strValue, string DefaultValue, string CustomFormat)
        {
            if (strValue == null)
            {
                return DefaultValue;
            }
            if (strValue == "")
            {
                return DefaultValue;
            }
            else
            {
                if (funBoolean_ValidDate(strValue))
                {
                    return "" + strValue.funDateTime_StringToDatetime().ToString(CustomFormat) + "";
                }
                else
                {
                    return DefaultValue;
                }
            }
        }
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

        #region"发送Email"
        /// <summary>
        /// 用webMail方式发送Mail,成功返回"",失败返回错误代码
        /// </summary>
        /// <param name="strSendMail">发送人的Mail</param>
        /// <param name="strSendUserName">发送人的用户名</param>
        /// <param name="strSendUserPassword">发送人的密码</param>
        /// <param name="strBody">发送内容</param>
        /// <param name="strSmtp">Smtp Server</param>
        /// <param name="strToMail">接收人的Mail</param>
        /// <param name="strSubject">发送主题</param>
        /// <param name="strCc">抄送人的Mail</param>
        /// <param name="isDellAttachment">发送后是否删除附件</param>
        /// <param name="strBcc">暗送人的Mail</param>
        /// <param name="aryAttachment">附件列表</param>
        /// <returns></returns>
        public static string funString_SendMailByWebMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, List<string> lstAttachment)
        {
            string strReturn = "";
            System.Web.Mail.MailMessage objMailMessage = new System.Web.Mail.MailMessage();
            objMailMessage.From = strSendMail;
            objMailMessage.To = strToMail;
            objMailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
            //Cc
            if (strCc != "")
            {
                objMailMessage.Cc = strCc;
            }
            //Bcc
            if (strBcc != "")
            {
                objMailMessage.Bcc = strBcc;
            }
            objMailMessage.Subject = strSubject;
            objMailMessage.Body = strBody;
            objMailMessage.BodyFormat = System.Web.Mail.MailFormat.Html;
            System.Web.Mail.SmtpMail.SmtpServer = strSmtp;
            //附件
            if (lstAttachment != null)
            {
                if (lstAttachment.Count > 0)
                {
                    FileInfo objFile;
                    for (int i = 0; i < lstAttachment.Count; i++)
                    {
                        objFile = new FileInfo(lstAttachment[i].ToString());
                        if (objFile.Exists)
                        {
                            System.Web.Mail.MailAttachment objAttachment = new System.Web.Mail.MailAttachment(lstAttachment[i].ToString());
                            objMailMessage.Attachments.Add(objAttachment);
                        }
                    }
                }
            }
            //验证
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", strSendUserName); //set your username here 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", strSendUserPassword); //set your password here 
            //发送
            try
            {
                System.Web.Mail.SmtpMail.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                strReturn = ex.Source + "\n" + ex.Message;
            }
            //删除文件
            try
            {
                //删除文件
                if (isDellAttachment)
                {
                    for (int i = 0; i < lstAttachment.Count; i++)
                    {
                        File.Delete(lstAttachment[i].ToString());
                    }
                }
            }
            catch
            {
            }
            return strReturn;
        }
        /// <summary>
        /// 用NetMail方式发送Mail,成功返回"",失败返回错误代码
        /// </summary>
        /// <param name="strSendMail">发送人的Mail</param>
        /// <param name="strSendUserName">发送人的用户名</param>
        /// <param name="strSendUserPassword">发送人的密码</param>
        /// <param name="strBody">发送内容</param>
        /// <param name="strSmtp">Smtp Server</param>
        /// <param name="strToMail">接收人的Mail</param>
        /// <param name="strSubject">发送主题</param>
        /// <param name="strCc">抄送人的Mail</param>
        /// <param name="isDellAttachment">发送后是否删除附件</param>
        /// <param name="strBcc">暗送人的Mail</param>
        /// <param name="aryAttachment">附件列表</param>
        /// <returns></returns>
        public static string funString_SendMailByNetMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, List<string> lstAttachment)
        {
            string strReturn = "";
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
            //设置信件的基本信息
            objMailMessage.Subject = strSubject;
            objMailMessage.Body = strBody;
            objMailMessage.IsBodyHtml = true;
            objMailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
            //设置发件人
            System.Net.Mail.MailAddress objMailAddress = new System.Net.Mail.MailAddress(strSendMail);
            objMailMessage.From = objMailAddress;

            //设置收件人
            string[] aryToMail = strToMail.Split(';');
            for (int i = 0; i < aryToMail.Length; i++)
            {
                objMailMessage.To.Add(aryToMail[i].ToString());
            }
            //设置CC
            if (strCc != "")
            {
                string[] aryCCMail = strCc.Split(';');
                for (int i = 0; i < aryCCMail.Length; i++)
                {
                    objMailMessage.To.Add(aryCCMail[i].ToString());
                }
            }
            //设置BCC
            if (strBcc != "")
            {
                string[] aryBCCMail = strCc.Split(';');
                for (int i = 0; i < aryBCCMail.Length; i++)
                {
                    objMailMessage.Bcc.Add(aryBCCMail[i].ToString());
                }
            }
            //附件
            if (lstAttachment != null)
            {
                if (lstAttachment.Count > 0)
                {
                    FileInfo objFile;
                    for (int i = 0; i < lstAttachment.Count; i++)
                    {
                        objFile = new FileInfo(lstAttachment[i].ToString());
                        if (objFile.Exists)
                        {
                            System.Net.Mail.Attachment objAttachment = new System.Net.Mail.Attachment(lstAttachment[i].ToString());
                            objMailMessage.Attachments.Add(objAttachment);
                        }
                    }
                }
            }
            //发送
            try
            {

                System.Net.Mail.SmtpClient objSmtpClient = new System.Net.Mail.SmtpClient();
                objSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                System.Net.CredentialCache objCache = new System.Net.CredentialCache();
                objCache.Add(strSmtp, 25, "NTLM", new System.Net.NetworkCredential(strSendUserName, strSendUserPassword));//NTLM//Basic
                objSmtpClient.Credentials = objCache;
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                strReturn = ex.Source + "\n" + ex.Message;
            }
            try
            {
                //删除文件
                if (isDellAttachment)
                {
                    for (int i = 0; i < lstAttachment.Count; i++)
                    {
                        File.Delete(lstAttachment[i].ToString());
                    }
                }
            }
            catch
            {
            }
            return strReturn;
        }

        /// <summary>
        /// 发送匿名Email
        /// </summary>
        /// <param name="strSendMail"></param>
        /// <param name="strSendUserName"></param>
        /// <param name="strSendUserPassword"></param>
        /// <param name="strBody"></param>
        /// <param name="strSmtp"></param>
        /// <param name="strToMail"></param>
        /// <param name="strSubject"></param>
        /// <param name="strCc"></param>
        /// <param name="isDellAttachment"></param>
        /// <param name="strBcc"></param>
        /// <param name="aryAttachment"></param>
        /// <returns></returns>
        public static string funString_SendNoMailByWebMail(this string strSendMail, string strSendUserName, string strSendUserPassword, string strBody, string strSmtp, string strToMail, string strSubject, string strCc, bool isDellAttachment, string strBcc, List<string> aryAttachment)
        {
            System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
            myMail.From = strSendMail;
            myMail.To = strToMail;
            myMail.Cc = strCc;
            myMail.Bcc = strBcc;
            myMail.Subject = strSubject;
            myMail.BodyEncoding = Encoding.GetEncoding("GB2312");
            myMail.Priority = System.Web.Mail.MailPriority.High;
            myMail.BodyFormat = MailFormat.Html;
            myMail.Body = strBody;
            string strMessage = "";
            //附件
            if (aryAttachment != null)
            {
                if (aryAttachment.Count > 0)
                {
                    FileInfo objFile;
                    for (int i = 0; i < aryAttachment.Count; i++)
                    {
                        if (aryAttachment[i].ToString() == "")
                        {
                            continue;
                        }
                        try
                        {
                            objFile = new FileInfo(aryAttachment[i].ToString());
                            if (objFile.Exists)
                            {
                                System.Web.Mail.MailAttachment objAttachment = new MailAttachment(aryAttachment[i].ToString());
                                myMail.Attachments.Add(objAttachment);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            SmtpMail.SmtpServer = strSmtp; //your smtp server here
            try
            {
                SmtpMail.Send(myMail);
            }
            catch (Exception ex)
            {
                strMessage = ex.Source + "\n" + ex.Message;
            }
            return strMessage;
        }
        #endregion

        #region "当前财年"
        /// <summary>
        /// 财年中的前一位年
        /// </summary>
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
        /// <summary>
        /// 财年中的第二位年
        /// </summary>
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

        #region"Request字符读取"
        /// <summary>
        /// HttpContext中取得信息
        /// </summary>
        /// <param name="IContent"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string funString_RequestFormValue(this HttpContext IContent, string strName)
        {
            string strValue = "";
            try
            {
                strValue = Uri.UnescapeDataString(IContent.Request[strName]);// IContent.Server.UrlDecode(IContent.Request[strName]);
            }
            catch (System.Exception ex)
            {

            }
            if (strValue == null)
            {
                strValue = "";
            }
            return strValue;
        }
        /// <summary>
        /// HttpRequest中取得信息
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string funString_RequestFormValue(this HttpRequest Request, string strName)
        {
            string strValue = "";
            try
            {
                strValue = Uri.UnescapeDataString(Request[strName]); //HttpUtility.UrlDecode(Request[strName]);
            }
            catch (System.Exception ex)
            {

            }
            if (strValue == null)
            {
                strValue = "";
            }
            return strValue;
        }
        /// <summary>
        /// 直接转换参数 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string funString_RequestFormValue(this string strValue)
        {
            try
            {
                strValue = Uri.UnescapeDataString(strValue);
            }
            catch (System.Exception ex)
            {

            }
            if (strValue == null)
            {
                strValue = "";
            }
            return strValue;
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
    }
}
