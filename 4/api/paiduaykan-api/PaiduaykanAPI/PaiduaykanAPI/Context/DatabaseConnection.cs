using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Context
{
    public class DatabaseConnection
    {
        static public string stringConnection = "server=localhost;port=3306;database=erpm;user=root;password=";
        static public MySqlConnection GetConnection()
        {
            return new MySqlConnection(stringConnection);
        }
    }
}
