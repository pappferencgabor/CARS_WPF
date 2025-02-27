using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_WPF.Helpers
{
    class GetMySQLConnection
    {
        public static string connectionString = "Server=localhost;" +
                                                "Port=3306;" +
                                                "User ID=root;" +
                                                "Password=;" +
                                                "Database=classicmodels;";

        public static MySqlConnection getMysqlConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}
