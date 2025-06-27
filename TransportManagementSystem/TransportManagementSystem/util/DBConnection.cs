using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TransportManagementSystem.util
{
    public class DBConnection
    {

        public static SqlConnection connection;

        //Getting Connection From Database
        public static SqlConnection getConnection()
        {
            connection = new SqlConnection("data source =selvakamal\\SQLEXPRESS01;initial catalog = TransportManagementSystem;integrated security = true;");
            connection.Open();
            return connection;
        }
    }
}