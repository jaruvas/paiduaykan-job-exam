using MySql.Data.MySqlClient;
using PaiduaykanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Context
{
    public class StoresContext
    {
        public List<Stores> GetList()
        {
            List<Stores> list = new List<Stores>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM STORES", conn);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Stores()
                        {
                            store_id = Convert.ToInt32(reader["store_id"]),
                            store_name = reader["store_name"].ToString(),
                            store_description = (reader["store_description"] ?? string.Empty).ToString(),
                            store_tel = (reader["store_tel"] ?? string.Empty).ToString(),
                            store_address = (reader["store_address"] ?? string.Empty).ToString()
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

        public Stores Save(Stores dataSave)
        {
            Stores data = dataSave;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    if (data.store_id == 0)
                    {
                        cmd.CommandText = @"INSERT INTO STORES(store_name,store_description,store_tel,store_address) VALUES (@store_name, @store_description, @store_tel, @store_address);";
                        cmd.Parameters.AddWithValue("@store_name", data.store_name);
                        cmd.Parameters.AddWithValue("@store_description", data.store_description);
                        cmd.Parameters.AddWithValue("@store_tel", data.store_tel);
                        cmd.Parameters.AddWithValue("@store_address", data.store_address);
                        var resule = cmd.ExecuteNonQuery();
                        if (resule == 1)
                        {
                            data.store_id = (int)cmd.LastInsertedId;
                        }
                        else
                        {
                            conn.Close();
                            return null;
                        }
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE STORES SET store_name = @store_name, store_description = @store_description, store_tel = @store_tel, store_address = @store_address WHERE store_id = @store_id;";
                        cmd.Parameters.AddWithValue("@store_id", data.store_id);
                        cmd.Parameters.AddWithValue("@store_name", data.store_name);
                        cmd.Parameters.AddWithValue("@store_description", data.store_description);
                        cmd.Parameters.AddWithValue("@store_tel", data.store_tel);
                        cmd.Parameters.AddWithValue("@store_address", data.store_address);
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
                    cmd.CommandText = @"DELETE FROM STORES WHERE store_id = @store_id;";
                    cmd.Parameters.AddWithValue("@store_id", id);
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
