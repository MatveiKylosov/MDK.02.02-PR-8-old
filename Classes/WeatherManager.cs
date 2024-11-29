using System;
using Kylosov.Classes.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kylosov.Classes.API;
using ZstdSharp.Unsafe;
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace Kylosov.Classes
{
    public class WeatherManager
    {
        private const uint MAXIMUM_NUMBER_OF_REQUESTS = 30;
        private int _numberOfRequests = 30;
        private WeatherService _weatherService;
        private DatabaseManager _database;

        public WeatherManager(string apiKey = "c6bf980d1a8191e15b71f8fc5dae106e", string connectionString = "Server=192.168.0.111;Database=PR8;User=root;Password=dawda6358;Port=3306;")
        {
            _weatherService = new WeatherService(apiKey);
            _database = new DatabaseManager(connectionString);

            _numberOfRequests = _database.NumberOfRequestsPerDay();
        }


        public async Task<List<Day>> Get5DayForecastByCityName(string cityName)
        {
            var days = new List<Day>();
            if(_numberOfRequests < MAXIMUM_NUMBER_OF_REQUESTS)
            {
                days = await _weatherService.Get5DayForecastByCityName(cityName);
                _database.AddRecord(cityName, JsonConvert.SerializeObject(days), DateTime.UtcNow);
                _numberOfRequests++;
            }
            else
            {
                days = _database.GetData(cityName, DateTime.UtcNow);
            }
            return days;
        }
    }
}
