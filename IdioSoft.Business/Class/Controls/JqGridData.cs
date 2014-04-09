using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using IdioSoft.Business.Method;
using IdioSoft.Business.Frames;


namespace IdioSoft.Business.Controls
{

    public class JqGridData
    {
        private int m_total;
        private int m_page;
        private int m_records;
        private List<object> m_rows;
        private List<string> m_rowshead;

        public int total
        {
            get { return m_total; }
            set { m_total = value; }
        }

        public int page
        {
            get { return m_page; }
            set { m_page = value; }
        }

        public int records
        {
            get { return m_records; }
            set { m_records = value; }
        }

        public List<object> rows
        {
            get { return m_rows; }
            set { m_rows = value; }
        }

        public List<string> rowsHead
        {
            get { return m_rowshead; }
            set { m_rowshead = value; }
        }


        public List<object> rowsM
        {
            get { return m_rowsM; }
            set { m_rowsM = value; }
        }

        private List<object> m_rowsM;


        #region "载入数据"
        public string getGridData(int page, int rows, bool _search, string sord, DataTable dtSource, int TotalCount)
        {
            DataTable dtRecords = dtSource;// Data Table
            int recordsCount = dtRecords.Rows.Count;

            JqGridData objJqGrid = new JqGridData();
            objJqGrid.page = page;
            objJqGrid.total = ((TotalCount + rows - 1) / rows);
            objJqGrid.records = TotalCount;
            objJqGrid.rows = ConvertDT(dtRecords);

            List<string> liob = new List<string>();
            foreach (DataColumn column in dtRecords.Columns)
            {
                liob.Add(column.ColumnName);
            }
            objJqGrid.rowsHead = liob;
            List<object> colcontetn = new List<object>();
            foreach (var item in liob)
            {
                JqGridDataHeading obj = new JqGridDataHeading();
                obj.name = item.ToString();
                obj.index = item.ToString();
                colcontetn.Add(obj);
            }
            objJqGrid.rowsM = colcontetn;
            JavaScriptSerializer jser = new JavaScriptSerializer();
            string sr = jser.Serialize(objJqGrid);
            return sr;
        }
        private List<object> ConvertDT(DataTable dsProducts)
        {
            List<object> objListOfEmployeeEntity = new List<object>();
            foreach (DataRow dRow in dsProducts.Rows)
            {
                Hashtable hashtable = new Hashtable();
                foreach (DataColumn column in dsProducts.Columns)
                {
                    if (column.DataType == typeof(int))
                    {
                        hashtable.Add(column.ColumnName, Function.funInt_StringToInt(dRow[column.ColumnName].ToString(),0));
                    }
                    else
                    {
                        if (column.DataType == typeof(DateTime))
                        {
                            hashtable.Add(column.ColumnName, dRow[column.ColumnName].ToString().funDateTime_StringToDatetime().funString_StringToDatetime());
                        }
                        else
                        {
                            hashtable.Add(column.ColumnName, dRow[column.ColumnName].ToString());
                        }
                    }
                }
                objListOfEmployeeEntity.Add(hashtable);
            }
            return objListOfEmployeeEntity;
        }

        private string strEQ = "{0}{1} {2}";
        public string funString_FilterReturn(Dictionary<string, object> dict, object objectView)
        {
            //{"groupOp":"AND","rules":[{"field":"ID","op":"eq","data":"c7"}]}
            string groupOp = dict["groupOp"].ToString();
            ArrayList ary = (ArrayList)dict["rules"];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ary.Count; i++)
            {
                Dictionary<string, object> dic = (Dictionary<string, object>)ary[i];
                int intIndex = 0;
                string strType = "";
                string sField = "";
                string sOp = "";
                string sData = "";
                string strSQL = "";
                foreach (var item in dic)
                {
                    switch (intIndex)
                    {
                        case 0:
                            sField = "[" + item.Value.ToString() + "]";
                            Type t = ((Columns)objectView).GetType();
                            object o = t.GetProperty(item.Value.ToString()).GetValue(((Columns)objectView), null);
                            object v = o.GetType().GetProperty("FieldType").GetValue(o, null);
                            strType =v.GetType().ToString(); //;DicSearchFiledType[item.Value.ToString()]
                            break;
                        case 1:
                            sOp = item.Value.ToString();
                            break;
                        case 2:
                            sData = item.Value.ToString();
                            switch (strType)
                            {
                                case "System.Guid":
                                case "System.String":
                                    switch (sOp)
                                    {
                                        case "eq":
                                            strSQL = String.Format(strEQ, sField, "=", "'" + sData + "'");
                                            break;
                                        case "bw":
                                            strSQL = String.Format(strEQ, sField, "", "like '" + sData + "%'");
                                            break;
                                        case "bn":
                                            strSQL = String.Format(strEQ, sField, "", "not like '" + sData + "%'");
                                            break;
                                        case "cn":
                                            strSQL = String.Format(strEQ, sField, "", "like '%" + sData + "%'");
                                            break;
                                        case "nc":
                                            strSQL = String.Format(strEQ, sField, "", "not like '%" + sData + "%'");
                                            break;
                                        case "ew":
                                            strSQL = String.Format(strEQ, sField, "", "like '%" + sData + "'");
                                            break;
                                        case "en":
                                            strSQL = String.Format(strEQ, sField, "", "not like '%" + sData + "'");
                                            break;
                                        case "ne":
                                            strSQL = String.Format(strEQ, sField, "<>", "'" + sData + "'");
                                            break;
                                        case "in":
                                            strSQL = String.Format(strEQ, sField, " in", "('" + sData + "')");
                                            break;
                                        case "ni":
                                            strSQL = String.Format(strEQ, sField, " not in", "('" + sData + "')");
                                            break;
                                    }
                                    sb.Append(strSQL);
                                    break;
                                case "System.Boolean":
                                    switch (sOp)
                                    {
                                        case "eq":
                                            strSQL = String.Format(strEQ, sField, "=", sData);
                                            break;
                                        case "ne":
                                            strSQL = String.Format(strEQ, sField, "<>", sData);
                                            break;
                                    }
                                    break;
                                case "System.Decimal":
                                case "System.Int32":
                                    switch (sOp)
                                    {
                                        case "eq":
                                            strSQL = String.Format(strEQ, sField, "=", sData);
                                            break;
                                        case "ne":
                                            strSQL = String.Format(strEQ, sField, "<>", sData);
                                            break;
                                        case "le":
                                            strSQL = String.Format(strEQ, sField, "<=", sData);
                                            break;
                                        case "lt":
                                            strSQL = String.Format(strEQ, sField, "<", sData);
                                            break;
                                        case "gt":
                                            strSQL = String.Format(strEQ, sField, ">", sData);
                                            break;
                                        case "ge":
                                            strSQL = String.Format(strEQ, sField, ">=", sData);
                                            break;
                                    }
                                    sb.Append(strSQL);
                                    break;
                                case "System.DateTime":
                                    switch (sOp)
                                    {
                                        case "eq":
                                            strSQL = String.Format(strEQ, sField, "=", "'" + sData + "'");
                                            break;
                                        case "ne":
                                            strSQL = String.Format(strEQ, sField, "<>", "'" + sData + "'");
                                            break;
                                        case "le":
                                            strSQL = String.Format(strEQ, sField, "<=", "'" + sData + "'");
                                            break;
                                        case "lt":
                                            strSQL = String.Format(strEQ, sField, "<", "'" + sData + "'");
                                            break;
                                        case "gt":
                                            strSQL = String.Format(strEQ, sField, ">", "'" + sData + "'");
                                            break;
                                        case "ge":
                                            strSQL = String.Format(strEQ, sField, ">=", "'" + sData + "'");
                                            break;
                                    }
                                    sb.Append(strSQL);
                                    break;
                            }
                            if (i + 1 < ary.Count)
                            {
                                sb.Append(" " + groupOp + " ");
                            }
                            break;
                        default:
                            break;
                    }
                    intIndex++;
                }
            }
            string strFilter = sb.ToString();
            return strFilter;
        }
        #endregion
    }

    public class JqGridDataHeading
    {
        public string name { get; set; }
        public string index { get; set; }
    }
}
