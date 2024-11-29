using Kylosov.Classes.API;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.Database
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public void AddRecord(string city, string data, DateTime date)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // Удаление старой записи, если она существует
                string deleteQuery = "DELETE FROM WeatherCache WHERE city = @city AND DATE(`date`) = @date";
                using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@city", city);
                    deleteCommand.Parameters.AddWithValue("@date", date.Date); // Используем только дату
                    deleteCommand.ExecuteNonQuery();
                }

                // Вставка новой записи
                string insertQuery = "INSERT INTO WeatherCache (city, data, date) VALUES (@city, @data, @date)";
                using (var insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@city", city);
                    insertCommand.Parameters.AddWithValue("@data", data);
                    insertCommand.Parameters.AddWithValue("@date", date);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        public int NumberOfRequestsPerDay()
        {
            int quantity = 0;
            string query = "SELECT id FROM WeatherCache WHERE DATE(`date`) = @date";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", DateTime.UtcNow.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quantity++;
                        }
                    }
                }
            }

            return quantity;
        }
        public List<Day> GetData(string city, DateTime dateTime)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT data FROM WeatherCache WHERE city = @city AND date = @dateTime";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@dateTime", dateTime);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string jsonData = result.ToString();
                        return JsonConvert.DeserializeObject<List<Day>>(jsonData);
                    }
                }
            }

            return default;
        }

        public DatabaseManager(string _connectionString = "")
        {
            this._connectionString = _connectionString;
        }
    }
}
