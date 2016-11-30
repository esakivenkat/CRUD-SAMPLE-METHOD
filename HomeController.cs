using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Save1.Models;

namespace Save1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public string connectionstring = @"Data Source=WEB-SERVER\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher;";
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr;
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult grid()
        {
            var obj = main();
            var obj1 = from n in obj select new[] { n.id.ToString(), n.name, n.city, n.age.ToString() };
            return Json(new
            {
                aaData = obj1                               //aaData represents the data source for the table
            },
            JsonRequestBehavior.AllowGet);                  //SIMILAR TO HTTP GET

        }

        public List<Class1> main()
        {
            List<Class1> ab = new List<Class1>();
            Class1 abc;
            using (con = new SqlConnection(connectionstring))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_griddet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("","Select"));
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        abc = new Class1();
                        abc.id = Convert.ToInt32(dr["id"]);
                        abc.name = Convert.ToString(dr["name"]);
                        abc.city = Convert.ToString(dr["city"]);
                        abc.age = Convert.ToInt32(dr["age"]);
                        ab.Add(abc);

                    }
                    dr.Close();
                }
                return ab;
            }
        }

        public string save(Int32 id, string name, string city, Int32 age)
        {

            Class1 a = new Class1();

            a.id = id;
            a.name = name;
            a.city = city;
            a.age = age;

            Service1 obj = new Service1();
            return obj.save(a);
        }

        public string update(Int32 id, string name, string city, Int32 age)
        {
            Class1 a = new Class1();

            a.id = id;
            a.name = name;
            a.city = city;
            a.age = age;
            
            Service1 s = new Service1();
            return s.update(a);

        }
        public string delete(Int32 id)
        {
            Class1 a = new Class1();

            a.id = id;
            //a.name = name;
            //a.city = city;
            //a,age = age;
            
            Service1 s = new Service1();
            return s.delete(a);

        }

    }
}
