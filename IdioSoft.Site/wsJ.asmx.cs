using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IdioSoft.Site
{
    /// <summary>
    /// Summary description for wsJ
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsJ : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public List<UserInfoA> UserList()
        {
            List<UserInfoA> lst = new List<UserInfoA>();
            for (int i = 0; i < 30; i++)
            {
                string Name=((char)(i+54)).ToString();
                int Age = (i + 1) * 10;
                UserInfoA item = new UserInfoA();
                item.Name = Name;
                item.Age = Age;
                lst.Add(item);
            }
            return lst;
        }

        [WebMethod]
        public void subSave(string Name,int Age)
        {
            string A = Name + "+" + Age.ToString();
        }

        [WebMethod]
        public UserInfoA UserA()
        {
            string Name = "王亮";
            int Age = 2000;
            UserInfoA item = new UserInfoA();
            item.Name = Name;
            item.Age = Age;
            return item;
        }
        
    }

    [Serializable]
    public class UserInfoA
    {
        public string Name;
        public int Age = 10;
    }

}
