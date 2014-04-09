using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IdioSoft.Business.Method;
using System.Reflection;
using System.Collections;

namespace IdioSoft.Business.Frames
{
    public class CView : IDBUnit
    {
        public SQLDbHelper objSQLDbHelper = null;

        public CView()
        {
            objSQLDbHelper = new SQLDbHelper();
        }


        public CView(Object ObjectUnit)
        {
            this.ObjectUnit = ObjectUnit;
            objSQLDbHelper = new SQLDbHelper();
        }

        public CView(Object ObjectUnit, string ConfingKey)
        {
            objSQLDbHelper = new SQLDbHelper(ConfingKey);
            this.ObjectUnit = ObjectUnit;
        }


        public object ObjectUnit
        {
            get;
            set;
        }

        public bool HasData
        {
            get;
            set;
        }

        private string _RecordFindWhere = "";

        /// <summary>
        /// Find record condition
        /// </summary>
        public string RecordFindWhere
        {
            get
            {
                return _RecordFindWhere;
            }
            set
            {
                _RecordFindWhere = value;
            }
        }

        /// <summary>
        /// Return a List
        /// </summary>
        /// <param name="Where"></param>
        /// <returns></returns>
        public List<object> getDatas(string Where)
        {
            return getDatasInfo(Where);
        }

        private List<object> getDatasInfo(string Where, params Object[] args)
        {
            List<object> lstItems;
            Type t1 = ObjectUnit.GetType();
            string strColumns = "";
            if (args == null || args.Length == 0)
            {
                strColumns = ((Columns)ObjectUnit).ColumnsToString();
            }
            else
            {
                strColumns = this.getColumns(args);
            }
            List<object> lst = new List<object>();
            lst.Add(ObjectUnit.GetType().Name);
            lst.Add(strColumns);
            lst.Add(Where);
            DataTable dt = objSQLDbHelper.funDataTable_SPExecuteNonQuery(lst, "sp_getDataGrid");
            lstItems = new List<object>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    object oItem = Activator.CreateInstance(t1);
                    Type t = oItem.GetType();
                    HasData = true;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        switch (dt.Columns[i].DataType.ToString())
                        {
                            case "System.String":
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<String>(dt.Rows[j][i].ToString(), false), null);
                                break;
                            case "System.Int32":
                                if (dt.Rows[j][i].ToString() == "")
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Int32?>(null, false), null);
                                }
                                else
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<Int32?>(dt.Rows[j][i].ToString().funInt_StringToInt(0), false), null);
                                }
                                break;
                            case "System.Decimal":
                                if (dt.Rows[j][i].ToString() == "")
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Decimal?>(null, false), null);
                                }
                                else
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<Decimal?>(dt.Rows[j][i].ToString().funDec_StringToDecimal(0), false), null);
                                }
                                break;
                            case "System.Guid":
                                if (dt.Rows[j][i].ToString() == "")
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Guid?>(null, false), null);
                                }
                                else
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<Guid?>(new Guid(dt.Rows[j][i].ToString()), false), null);
                                }
                                break;
                            case "System.DateTime":
                                if (dt.Rows[j][i].ToString() == "")
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<DateTime?>(null, false), null);
                                }
                                else
                                {
                                    t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<DateTime?>(dt.Rows[j][i].ToString().funDateTime_StringToDatetime(), false), null);
                                }
                                break;
                            case "System.Boolean":
                                //if (dt.Rows[0][i].ToString() == "")
                                //{
                                //    t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Boolean?>(null, false), null);
                                //}
                                //else
                                //{
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Boolean?>(dt.Rows[0][i].ToString().funBoolean_StringToBoolean(), false), null);
                                //}
                                break;
                            default:
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(oItem, new Column<String>(dt.Rows[j][i].ToString(), false), null);
                                break;
                        }
                    }
                    lstItems.Add(oItem);
                }
            }
            else
            {
                HasData = false;
            }
            return lstItems;
        }

        /// <summary>
        /// get fileds values by where
        /// </summary>
        /// <param name="Where"></param>
        public void getData(string Where)
        {
            getDataInfo(Where);
        }

        /// <summary>
        /// get customize columns to List
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="args">customize columns</param>
        /// <returns></returns>
        public List<object> getDatas(string Where, params Object[] args)
        {
            return getDatasInfo(Where, args);
        }

         private void getDataInfo(string Where)
        {
            Type t1 = ObjectUnit.GetType();
            string strColumns = ((Columns)ObjectUnit).ColumnsToString();
            List<object> lst = new List<object>();
            lst.Add(ObjectUnit.GetType().Name);
            lst.Add(strColumns);
            lst.Add(Where);
            DataTable dt = objSQLDbHelper.funDataTable_SPExecuteNonQuery(lst, "sp_getDataGrid");
            if (dt != null && dt.Rows.Count > 0)
            {
                Type t = ObjectUnit.GetType();
                HasData = true;
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    switch (dt.Columns[i].DataType.ToString())
                    {
                        case "System.String":
                            t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<String>(dt.Rows[0][i].ToString(), false), null);
                            break;
                        case "System.Int32":
                            if (dt.Rows[0][i].ToString() == "")
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Int32?>(null, false), null);
                            }
                            else
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Int32?>(dt.Rows[0][i].ToString().funInt_StringToInt(0), false), null);
                            }
                            break;
                        case "System.Decimal":
                            if (dt.Rows[0][i].ToString() == "")
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Decimal?>(null, false), null);
                            }
                            else
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Decimal?>(dt.Rows[0][i].ToString().funDec_StringToDecimal(0), false), null);
                            }
                            break;
                        case "System.Guid":
                            if (dt.Rows[0][i].ToString() == "")
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Guid?>(null, false), null);
                            }
                            else
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Guid?>(Guid.Parse(dt.Rows[0][i].ToString()), false), null);
                            }
                            break;
                        case "System.DateTime":
                            if (dt.Rows[0][i].ToString() == "")
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<DateTime?>(null, false), null);
                            }
                            else
                            {
                                t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<DateTime?>(dt.Rows[0][i].ToString().funDateTime_StringToDatetime(), false), null);
                            }
                            break;
                        case "System.Boolean":
                            //if (dt.Rows[0][i].ToString() == "")
                            //{
                            //    t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Boolean?>(null, false), null);
                            //}
                            //else
                            //{
                            t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<Boolean?>(dt.Rows[0][i].ToString().funBoolean_StringToBoolean(), false), null);
                            //}
                            break;
                        default:
                            t.GetProperty(dt.Columns[i].ColumnName).SetValue(ObjectUnit, new Column<String>(dt.Rows[0][i].ToString(), false), null);
                            break;
                    }
                }
            }
            else
            {
                HasData = false;
            }
        }

        /// <summary>
        /// get fileds values,default condition is RecordFindWhere
        /// </summary>
        public void getData()
        {
            getDataInfo(RecordFindWhere);
        }

        /// <summary>
        /// get customize columns to list
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<string> CustomizeColumns(params Object[] args)
        {
            List<string> lstColumns = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                Type t = args[i].GetType();
                lstColumns.Add(t.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance).GetValue(args[i], null).ToString());
            }
            return lstColumns;
        }

        /// <summary>
        /// get customize columns string
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string getColumns(params Object[] args)
        {
            StringBuilder sb = new StringBuilder();
            List<string> lst = CustomizeColumns(args);
            foreach (var item in lst)
            {
                sb.Append(item + ",");
            }
            string strReturn = sb.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            return strReturn;
        }

        ///<summary>
        /// return DataTable 
        ///</summary>
        public DataTable getCustomizeDt(string Where, string Fileds)
        {
            List<object> lst = new List<object>();
            lst.Add(ObjectUnit.GetType().Name);
            lst.Add(Fileds);
            lst.Add(Where);
            return objSQLDbHelper.funDataTable_SPExecuteNonQuery(lst, "sp_getDataGrid");
        }
    }
}
