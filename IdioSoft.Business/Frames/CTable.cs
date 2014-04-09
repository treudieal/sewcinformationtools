using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdioSoft.Business.Method;
using System.Data;
using System.Reflection;

namespace IdioSoft.Business.Frames
{
    public class CTable : CView, ITable
    {
        public CTable()
        {

        }

        public CTable(Object ObjectUnit)
        {
            this.ObjectUnit = ObjectUnit;
        }

        #region "属性"

        private string _RecordExistWhere = "";
        /// <summary>
        /// 用于判断存在与否的where,如果RecordUpdateWhere没有设置，就用这个替代
        /// </summary>
        public string RecordExistWhere
        {
            get
            {
                return _RecordExistWhere;
            }
            set
            {
                _RecordExistWhere = value;
                if (RecordUpdateWhere == "")
                {
                    RecordUpdateWhere = value;
                }
            }
        }

        private string _RecordUpdateWhere = "";
        /// <summary>
        /// 用于做Update的操作条件
        /// </summary>
        public string RecordUpdateWhere
        {
            get
            {
                return _RecordUpdateWhere;
            }
            set
            {
                _RecordUpdateWhere = value;
            }
        }

        private string _RecordDeleteWhere = "";
        public string RecordDeleteWhere
        {
            get
            {
                return _RecordDeleteWhere;
            }
            set
            {
                _RecordDeleteWhere = value;
            }
        }
        #endregion

        #region "写入DB,返回空为正确，否则为错误"
        /// <summary>
        /// 写入DB,返回空为正确，否则为错误
        /// </summary>
        public string Save()
        {
            return this.SaveInfo(((Columns)ObjectUnit).ColumsList());
        }



        private string SaveInfo(List<String> lstColumns)
        {
            StringBuilder sb = new StringBuilder();
            Type t = ((Columns)ObjectUnit).GetType();
            bool isUpdate = isRecordExist();
            StringBuilder sbCols = new StringBuilder();
            for (int i = 0; i < lstColumns.Count; i++)
            {
                object o = t.GetProperty(lstColumns[i]).GetValue(((Columns)ObjectUnit), null);
                object v = o.GetType().GetProperty("FieldValue").GetValue(o, null);
                object ftype = o.GetType().GetProperty("FieldType").GetValue(o, null);

                bool isChange = (bool)o.GetType().GetProperty("isChange").GetValue(o, null);
                if (!isChange)
                {
                    continue;
                }
                #region "get sql string"
                switch (ftype.ToString())
                {
                    case "System.String":
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                if (v == null)
                                {
                                    sb.Append(lstColumns[i] + "=null,");
                                }
                                else
                                {
                                    sb.Append(lstColumns[i] + "='" + v.ToString() + "',");
                                }
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "null" + ",");
                            }
                            else
                            {
                                sb.Append("'" + v.ToString() + "',");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }
                        break;
                    case "System.Int32":
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                if (v == null)
                                {
                                    sb.Append(lstColumns[i] + "=null,");
                                }
                                else
                                {
                                    sb.Append(lstColumns[i] + "=" + v.ToString() + ",");
                                }
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "NULL" + ",");
                            }
                            else
                            {
                                sb.Append("" + v.ToString() + ",");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }

                        break;
                    case "System.Decimal":
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                if (v == null)
                                {
                                    sb.Append(lstColumns[i] + "=null,");
                                }
                                else
                                {
                                    sb.Append(lstColumns[i] + "=" + v.ToString() + ",");
                                }
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "NULL" + ",");
                            }
                            else
                            {
                                sb.Append("" + v.ToString() + ",");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }

                        break;
                    case "System.Guid":
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                if (v == null)
                                {
                                    sb.Append(lstColumns[i] + "=null,");
                                }
                                else
                                {
                                    sb.Append(lstColumns[i] + "='" + v.ToString() + "',");
                                }
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "NULL" + ",");
                            }
                            else
                            {
                                sb.Append("'" + v.ToString() + "',");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }
                        break;
                    case "System.DateTime":
                        string tmpDate = "";
                        if (v == null)
                        {
                            tmpDate = null;
                        }
                        else
                        {
                            tmpDate = v.ToString();
                        }
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                sb.Append(lstColumns[i] + "=" + tmpDate.funString_StringToDBDate() + ",");
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            sb.Append("" + tmpDate.funString_StringToDBDate() + ",");
                            sbCols.Append(lstColumns[i] + ",");
                        }

                        break;
                    case "System.Boolean":
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                if (v == null)
                                {
                                    sb.Append(lstColumns[i] + "=null,");
                                }
                                else
                                {
                                    sb.Append(lstColumns[i] + "=" + v.ToString().funInt_BoolToString() + ",");
                                }
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "NULL" + ",");
                            }
                            else
                            {
                                sb.Append("'" + v.ToString().funInt_BoolToString() + "',");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }

                        break;
                    default:
                        if (isUpdate)
                        {
                            if (isChange)
                            {
                                sb.Append(lstColumns[i] + "='" + v.ToString() + "',");
                                sbCols.Append(lstColumns[i] + ",");
                            }
                        }
                        else
                        {
                            if (v == null)
                            {
                                sb.Append("" + "null" + ",");
                            }
                            else
                            {
                                sb.Append("'" + v.ToString() + "',");
                            }
                            sbCols.Append(lstColumns[i] + ",");
                        }
                        break;
                }
                #endregion
            }
            string strSQL = "";
            string strError = "";
            if (sb.ToString() != "")
            {
                if (isUpdate)
                {
                    sb = sb.Insert(0, "update " + ObjectUnit.GetType().Name + " set ");
                    strSQL = sb.ToString();
                    strSQL = strSQL.Substring(0, strSQL.Length - 1) + "";
                    strSQL = strSQL + " where " + RecordUpdateWhere;
                    strError = objSQLDbHelper.funString_SQLExecuteNonQuery(strSQL);
                }
                else
                {
                    string strCols = sbCols.ToString();
                    if (strCols != "")
                    {
                        strCols = strCols.Substring(0, strCols.Length - 1);
                        sb = sb.Insert(0, "insert into " + ObjectUnit.GetType().Name + "(" + strCols + ") VALUES (");
                        strSQL = sb.ToString();
                        strSQL = strSQL.Substring(0, strSQL.Length - 1) + ")";
                        strError = objSQLDbHelper.funString_SQLExecuteNonQuery(strSQL);
                    }
                }
            }
            return strError;
        }

        /// <summary>
        /// 写入任意字段DB,返回空为正确，否则为错误
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Save(params Object[] args)
        {
            return this.SaveInfo(base.CustomizeColumns(args));
        }
        #endregion

        #region "判断记录是否存在"
        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <returns></returns>
        public bool isRecordExist()
        {
            String strSQL = "";
            strSQL = "select count(*) from " + ObjectUnit.GetType().Name + " where " + RecordExistWhere;
            return objSQLDbHelper.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }
        #endregion

        #region "删除记录"
        public string Delete()
        {
            string strReturn = DeleteInfo(RecordDeleteWhere);
            return strReturn;
        }
        public string Delete(string Where)
        {
            string strReturn = DeleteInfo(Where);
            return strReturn;
        }
        private string DeleteInfo(string Where)
        {
            string strReturn = "";
            String strSQL = "";
            strSQL = "delete " + ObjectUnit.GetType().Name + " where " + Where;
            strReturn = objSQLDbHelper.funString_SQLExecuteNonQuery(strSQL);
            return strReturn;
        }
        #endregion

        #region "自动赋值"
        public void SetValues(Dictionary<string, string> dic)
        {
            Type t = ((Columns)this.ObjectUnit).GetType();
            foreach (var item in dic)
            {
                PropertyInfo p = t.GetProperty(item.Key);
                if (p != null)
                {
                    object col = p.GetValue(((Columns)ObjectUnit), null);
                    object ftype = col.GetType().GetProperty("FieldType").GetValue(col, null);
                   if (col != null)
                    {
                        switch (ftype.ToString())
                        {
                            case "System.Int32":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funInt_StringToInt(0), null);
                                break;
                            case "System.Decimal":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funDec_StringToDecimal(0), null);
                                break;
                            case "System.Boolean":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funBoolean_StringToBoolean(), null);
                                break;
                            case "System.DateTime":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funDateTime_StringToDatetimeAllowNull(), null);
                                break;
                            case "System.Guid":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funGuid_StringToGuid(), null);
                                break;
                            case "System.String":
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funString_SQLToString(), null);
                                break;
                            default:
                                col.GetType().GetProperty("FieldValue").SetValue(col, Uri.UnescapeDataString(item.Value).funString_SQLToString(), null);
                                break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
