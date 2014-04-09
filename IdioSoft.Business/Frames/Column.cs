using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IdioSoft.Business.Frames
{
    public class Column<T>
    {
        public Column()
        {

        }

        /// <summary>
        /// default value
        /// </summary>
        /// <param name="FieldValue"></param>
        public Column(T FieldValue, bool isChange)
        {
            
            this.FieldValue = FieldValue;
            this.isChange = isChange;
        }

        public string Name { get; set; }

        private T _FieldValue;
        /// <summary>
        /// get value
        /// </summary>
        public T FieldValue
        {
            get
            {
                return _FieldValue;
            }
            set
            {
                Type t = typeof(T);
                if (t.ToString() == "System.String" && FieldLenght > 0)
                {
                    _FieldValue = (T)Convert.ChangeType(value.ToString().Substring(0, value.ToString().Length < FieldLenght ? value.ToString().Length : FieldLenght), t);
                }
                else
                {
                    _FieldValue = value;
                }
                isChange = true;
            }
        }

        /// <summary>
        /// judge column is null
        /// </summary>
        public bool isNull
        {
            get
            {
                return FieldValue == null;
            }
        }

        /// <summary>
        /// column type
        /// </summary>
        public string FieldType
        {
            get
            {
                string strTmp = typeof(T).ToString();
                strTmp = strTmp.Replace("System.Nullable`1", "");
                strTmp = strTmp.Replace("[", "").Replace("]", "");
                return strTmp;
            }
        }

        /// <summary>
        /// Field lenght
        /// </summary>
        public int FieldLenght
        {
            get;
            set;
        }

        /// <summary>
        /// default to string FieldValue
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FieldValue.ToString();
        }

        public bool isChange { get; set; }

    }
}
