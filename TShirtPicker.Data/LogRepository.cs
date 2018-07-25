using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtPicker.Data.Models;
using TShirtPicker.Data.Properties;

namespace TShirtPicker.Data
{
    public class LogRepository
    {
        public void Insert(string message, Severity severity)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
            {
                string query = $"INSERT INTO TShirtsDb..Log(Message, Severity, Timestamp)" +
                    $" VALUES ('{message}', {(int)severity}, '{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        throw new System.Exception("Log insertion failed.");
                    }
                }
            }
        }
    }
}
