using MySql.Data.MySqlClient;
using PaiduaykanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Context
{
    public class ProductTypeContext
    {
        public List<ProductType> GetList()
        {
            List<ProductType> list = new List<ProductType>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM PRODUCT_TYPE", conn);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductType()
                        {
                            product_type_id = Convert.ToInt32(reader["product_type_id"]),
                            product_type_name = reader["product_type_name"].ToString(),
                            product_type_description = (reader["product_type_description"] ?? string.Empty).ToString(),
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
