using System.Collections.Generic;
using System.Data.SqlClient;
using TShirtPicker.Data.Models;
using TShirtPicker.Data.Properties;

namespace TShirtPicker.Data
{
    public class TShirtRepository
    {
        public IEnumerable<TShirt> GetAll()
        {
            List<TShirt> tShirts = new List<TShirt>();

            using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
            {   
                string query = "SELECT * FROM TShirts";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using ( SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            tShirts.Add(new TShirt()
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Color = dataReader["Color"].ToString(),
                                Quantity = int.Parse(dataReader["Quantity"].ToString()),
                                Size = dataReader["Size"].ToString()
                            });
                        }
                    }
                }
            }

            return tShirts;
        }

        public TShirt GetById(int id)
        {
            TShirt tShirt = null;

            using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
            {
                string query = $"SELECT * FROM TShirts WHERE Id = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();

                            tShirt =  new TShirt
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Color = dataReader["Color"].ToString(),
                                Quantity = int.Parse(dataReader["Quantity"].ToString()),
                                Size = dataReader["Size"].ToString()
                            };
                        }
                    }
                }
            }

            return tShirt;
        }

        public void Restock(int quantity, string color)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
            {
                string query = $"UPDATE TShirts SET Quantity = {quantity} WHERE color = '{color}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    int rowsAffected  = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        throw new System.Exception("Restock failed.");
                    }
                }
            }
        }

        public void DecreaseQuantity(int id, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
            {
                string query = $"UPDATE TShirts SET Quantity = {quantity} WHERE id = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        throw new System.Exception("DecreaseQuantity failed.");
                    }
                }
            }
        }
    }
}
