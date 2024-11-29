using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey;  // Замените на ваш API ключ

        // Метод для получения прогноза на 5 дней по названию города (для бесплатного API)
        public async Task<List<Day>> Get5DayForecastByCityName(string cityName)
        {
            try
            {
                var url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}&units=metric";
                var response = await client.GetStringAsync(url);
                var forecastData = JsonConvert.DeserializeObject<ForecastResponse>(response);

                var days = new List<Day>();

                // Группируем прогнозы по дням
                foreach (var dayGroup in forecastData.List.GroupBy(f => UnixTimeToDateTime(f.dt).Date))
                {
                    var day = new Day
                    {
                        Date = dayGroup.Key,
                        Morning = GetWeatherForTimeOfDay(dayGroup, new[] { 6, 9 }), // Утро: 6:00 и 9:00
                        Afternoon = GetWeatherForTimeOfDay(dayGroup, new[] { 12, 15 }), // День: 12:00 и 15:00
                        Evening = GetWeatherForTimeOfDay(dayGroup, new[] { 18, 21 }), // Вечер: 18:00 и 21:00
                        Night = GetWeatherForTimeOfDay(dayGroup, new[] { 0, 3 }) // Ночь: 0:00 и 3:00
                    };

                    days.Add(day);
                }

                return days;
            }
            catch
            {
                return default;
            }
        }

        // Преобразование времени из Unix в DateTime
        private DateTime UnixTimeToDateTime(long unixTime)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);
            return dateTimeOffset.DateTime;
        }

        // Метод для получения данных для определённых временных точек
        private WeatherData GetWeatherForTimeOfDay(IEnumerable<Forecast> forecasts, int[] hours)
        {
            var forecast = forecasts
                .FirstOrDefault(f => hours.Contains(UnixTimeToDateTime(f.dt).Hour));

            if (forecast == null) return null;

            return new WeatherData
            {
                Temp = forecast.main.temp,
                Description = forecast.weather[0].description,
                WindSpeed = forecast.wind.speed,
                WindDeg = forecast.wind.deg,
                Humidity = forecast.main.humidity,
                Pressure = forecast.main.pressure
            };
        }

        public WeatherService(string apiKey)
        {
            this.apiKey = apiKey;
        }
    }
}
