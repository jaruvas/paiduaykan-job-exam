using MySql.Data.MySqlClient;
using PaiduaykanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Context
{
    public class UnitsContext
    {
        public List<Units> GetList()
        {
            List<Units> list = new List<Units>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM UNITS", conn);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Units()
                        {
                            unit_id = Convert.ToInt32(reader["unit_id"]),
                            unit_name = reader["unit_name"].ToString(),
                            unit_description = (reader["unit_description"] ?? string.Empty).ToString(),
                        });
                    }
                    conn.Close();
                }
                catch
                {
                    conn.Close();
                }
            }
            return list;
        }
    }
}
