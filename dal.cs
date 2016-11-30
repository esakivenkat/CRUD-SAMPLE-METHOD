using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Save1.Models
{
    public class dal
    {
        public string connectionstring = @"Data Source=WEB-SERVER\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher;";
        SqlConnection con = null;
        SqlCommand cmd = null;


        public string save(Class1 a)
        {
            using (con = new SqlConnection(connectionstring))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_perdet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@text","Insert"));
                    cmd.Parameters.Add(new SqlParameter("@id", a.id));
                    cmd.Parameters.Add(new SqlParameter("@name", a.name));
                    cmd.Parameters.Add(new SqlParameter("@city", a.city));
                    cmd.Parameters.Add(new SqlParameter("@age", a.age));
                    cmd.ExecuteNonQuery();
                }
                return "";
            }
        }
        
        public string update(Class1 a)
        {
            using (con = new SqlConnection(connectionstring))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_perdet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@text","Update"));
                    cmd.Parameters.Add(new SqlParameter("@id", a.id));
                    cmd.Parameters.Add(new SqlParameter("@name", a.name));
                    cmd.Parameters.Add(new SqlParameter("@city", a.city));
                    cmd.Parameters.Add(new SqlParameter("@age", a.age));
                    cmd.ExecuteNonQuery();
                }
                return "";
            }
        }
        public string delete(Class1 a)
        {
            using (con = new SqlConnection(connectionstring))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_deldet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@text","Delete"));
                    cmd.Parameters.Add(new SqlParameter("@id",a.id));
                    cmd.ExecuteNonQuery();
                }
                return "";
            }
        }

    }
}
    