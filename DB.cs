using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPBDHostel
{
    internal class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DBSRV\vip2022; Initial Catalog=krasukov_107sb_Hotel; Integrated Security=True");

        public static string Login;
        public static int Role;

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
