using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace polypipe
{
    class dbhelper
    {

        private static SqlConnection con = null;

        public static SqlConnection GetConnection()
        {
            if (con == null)
            {
                string constring = "Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True";
                con = new SqlConnection(constring);
                con.Open();
            }

            return con;
        }

    }
}
