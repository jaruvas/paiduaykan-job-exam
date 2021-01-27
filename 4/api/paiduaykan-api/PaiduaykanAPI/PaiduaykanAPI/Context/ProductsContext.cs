using MySql.Data.MySqlClient;
using PaiduaykanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Context
{
    public class ProductsContext
    {
        public List<Products> GetByStoreId(int store_id)
        {
            List<Products> list = new List<Products>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT P.product_id AS product_id, P.store_id AS store_id, P.product_name AS product_name, P.product_description AS product_description,"
                        + "P.price AS price, P.product_type_id AS product_type_id, T.product_type_name AS product_type_name, P.unit_id AS unit_id, U.unit_name AS unit_name FROM PRODUCTS P "
                        + "LEFT JOIN product_type T ON P.product_type_id = T.product_type_id LEFT JOIN units U ON P.unit_id = U.unit_id WHERE store_id = @store_id", conn);
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Products()
                        {
                            product_id = Convert.ToInt32(reader["product_id"]),
                            store_id = Convert.ToInt32(reader["store_id"]),
                            product_name = reader["product_name"].ToString(),
                            product_description = (reader["product_description"] ?? string.Empty).ToString(),
                            price = Convert.ToDouble(reader["price"]),
                            product_type_id = Convert.ToInt32(reader["product_type_id"]),
                            product_type_name = reader["product_type_name"].ToString(),
                            unit_id = Convert.ToInt32(reader["unit_id"]),
                            product_unit_name = (reader["unit_name"] ?? string.Empty).ToString(),
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

        public Products Save(Products dataSave)
        {
            Products data = dataSave;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    if (data.product_id == 0)
                    {
                        cmd.CommandText = @"INSERT INTO PRODUCTS(store_id,product_name,product_description,price,product_type_id,unit_id) VALUES (@store_id, @product_name, @product_description, @price, @product_type_id, @unit_id);";
                        cmd.Parameters.AddWithValue("@store_id", data.store_id);
                        cmd.Parameters.AddWithValue("@product_name", data.product_name);
                        cmd.Parameters.AddWithValue("@product_description", data.product_description);
                        cmd.Parameters.AddWithValue("@price", data.price);
                        cmd.Parameters.AddWithValue("@product_type_id", data.product_type_id);
                        cmd.Parameters.AddWithValue("@unit_id", data.unit_id);
                        var resule = cmd.ExecuteNonQuery();
                        if (resule == 1)
                        {
                            data.product_id = (int)cmd.LastInsertedId;
                        }
                        else
                        {
                            conn.Close();
                            return null;
                        }
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE PRODUCTS SET store_id = @store_id, product_name = @product_name, product_description = @product_description, price = @price, product_type_id = @product_type_id, unit_id = @unit_id WHERE product_id = @product_id;";
                        cmd.Parameters.AddWithValue("@product_id", data.product_id);
                        cmd.Parameters.AddWithValue("@store_id", data.store_id);
                        cmd.Parameters.AddWithValue("@product_name", data.product_name);
                        cmd.Parameters.AddWithValue("@product_description", data.product_description);
                        cmd.Parameters.AddWithValue("@price", data.price);
                        cmd.Parameters.AddWithValue("@product_type_id", data.product_type_id);
                        cmd.Parameters.AddWithValue("@unit_id", data.unit_id);
                        var resule = cmd.ExecuteNonQuery();
                        if (resule == 0)
                        {
                            conn.Close();
                            return null;
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    conn.Close();
                    return null;
                }
            }
            return data;
        }

        public bool Delete(int id)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"DELETE FROM PRODUCTS WHERE product_id = @product_id;";
                    cmd.Parameters.AddWithValue("@product_id", id);
                    var resule = cmd.ExecuteNonQuery();
                    if (resule == 1)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }

                }
                catch
                {
                    conn.Close();
                    return false;
                }
            }
        }
    }
}
