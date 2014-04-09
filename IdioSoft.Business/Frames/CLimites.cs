using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Business.Frames
{
    public class CLimites
    {
        private System.Web.UI.HtmlControls.HtmlForm from = null;
        private string _UserLimits = "";
        private string UserLimits
        {
            get
            {
                return _UserLimits;
            }
            set
            {
                _UserLimits = value;
            }
        }

        public CLimites()
        {

        }

        public CLimites(System.Web.UI.HtmlControls.HtmlForm from, string userLimits)
        {
            this.from = from;
            this.UserLimits = userLimits;
        }

        public void DoLimits()
        {
            DoLoopControl(from);
        }

        private void DoLoopControl(Control parent)
        {
            foreach (Control item in parent.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    setLimits(item);
                    DoLoopControl(item);
                }
                else
                {
                    setLimits(item);
                }
             }
        }

        private void setLimits(Control item)
        {
            Type t = item.GetType();
            PropertyInfo[] p = t.GetProperties();
            if (t.GetProperty("Attributes") != null)
            {
                try
                {
                    System.Web.UI.AttributeCollection Aclist = (System.Web.UI.AttributeCollection)t.GetProperty("Attributes").GetValue(item, null);
                    object o = Aclist["limitCode"];
                    if (o != null)
                    {
                        string limitCode = Aclist["limitCode"].ToString();
                        if (!this.UserLimits.Contains("," + limitCode + ",") && limitCode != "")
                        {
                            t.GetProperty("Visible").SetValue(item, false, null);
                        }
                    }
                }
                catch (Exception)
                {
 
                }
               
            }
           
        }

    }
}
