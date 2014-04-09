using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    string ss = Request["name"].ToString();
            //    string pwd = Request["pwd"].ToString();
            //    Response.Write("true");
            //}
            //catch (Exception)
            //{
            //    Response.Write("false");

            //}
            //Response.End();
            long d1 = DateTime.Now.Ticks;
            long lng2 = 0;
            foreach (int item in returnResult())
            {
                lng2++;
            }
            long d2 = DateTime.Now.Ticks;
            Response.Write("d2-d1:" + (d2 - d1).ToString() + "|" + lng2.ToString());
            
            //long lng1 = lng1Sum();

            //IEnumerable ie = returnResult();
            //foreach (int item in ie)
            //{
            //    int v = item;
            //}

            //string strT = ",1,2,3,4,";
            //strT = strT.Trim(',');

            //List<Person> lst = new List<Person>()
            //{
            //    new Person("A",100),
            //    new Person("B",200)
            //};

            //Person p1 = new Person("A", 100);
            //Person p2 = new Person("B", 200);
            //decimal d1 = p1 + p2;
        }



        private IEnumerable returnResult()
        {
            int result = 1;
            for (int i = 0; i < 1000000; i++)
            {
                result++;
                yield return result;
            }
        }

        private long lng1Sum()
        {
            long d1 = DateTime.Now.Ticks;
            long result = 1;
            for (int i = 0; i < 1000000; i++)
            {
                result++;
            }
            long d2 = DateTime.Now.Ticks;
            Response.Write("d2-d1" + (d2 - d1).ToString());
            return result;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string txt = txtName.Text;
            string password = txtPassword.Text;
            if (txt == "1" && password == "123")
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }
    }

    public class Person
    {
        public string name { get; set; }
        public decimal salary { get; set; }

        public Person()
        {
        }

        public Person(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public static decimal operator +(Person p1, Person p2)
        {
            return p1.salary + p2.salary;
        }
    }
}