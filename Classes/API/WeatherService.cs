using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    public class WeatherService
    {
        private readonly string apiKey;
        private static readonly string baseUrl = "http://api.openweathermap.org/data/2.5/";

        /// <summary>
        /// Конструктор для инициализации класса с API ключом.
        /// </summary>
        /// <param name="apiKey">API ключ для доступа к OpenWeather API.</param>
        public WeatherService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Получает данные о текущей погоде для заданного города.
        /// </summary>
        /// <param name="city">Название города.</param>
        /// <returns>Объект, содержащий данные о текущей погоде.</returns>
        public async Task<CurrentWeatherResponse> GetCurrentWeather(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}weather?q={city}&appid={apiKey}&units=metric";
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<CurrentWeatherResponse>(response);  // Десериализуем в объект
            }
        }

        /// <summary>
        /// Получает прогноз погоды на несколько дней для заданного города.
        /// </summary>
        /// <param name="city">Название города.</param>
        /// <returns>Объект, содержащий прогноз погоды на несколько дней.</returns>
        public async Task<ForecastWeatherResponse> GetForecastWeather(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}forecast?q={city}&appid={apiKey}&units=metric";
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ForecastWeatherResponse>(response);  // Десериализуем в объект
            }
        }

        /// <summary>
        /// Выводит текущую погоду в консоль.
        /// </summary>
        /// <param name="currentWeather">Объект с данными о текущей погоде.</param>
        private void PrintCurrentWeather(CurrentWeatherResponse currentWeather)
        {
            if (currentWeather != null)
            {
                Debug.WriteLine($"Город: {currentWeather.Name}");
                Debug.WriteLine($"Температура: {currentWeather.Main.Temp}°C");
                Debug.WriteLine($"Влажность: {currentWeather.Main.Humidity}%");
                Debug.WriteLine($"Погода: {currentWeather.Weather[0].Description}");
            }
            else
            {
                Debug.WriteLine("Нет данных о текущей погоде.");
            }
        }

        /// <summary>
        /// Выводит прогноз погоды для конкретного времени суток.
        /// </summary>
        /// <param name="timeOfDay">Время суток (утро, день, вечер, ночь).</param>
        /// <param name="forecast">Данные прогноза для соответствующего времени суток.</param>
        private void PrintForecast(string timeOfDay, ForecastItem forecast)
        {
            if (forecast != null)
            {
                Debug.WriteLine($"{timeOfDay}:");
                Debug.WriteLine($"Температура: {forecast.Main.Temp}°C");
                Debug.WriteLine($"Влажность: {forecast.Main.Humidity}%");
                Debug.WriteLine($"Погода: {forecast.Weather[0].Description}");
            }
            else
            {
                Debug.WriteLine($"{timeOfDay}: Нет данных");
            }
        }

        /// <summary>
        /// Выводит прогноз погоды на следующие 5 дней.
        /// </summary>
        /// <param name="forecastWeatherResponse">Ответ с прогнозом погоды.</param>
        public void PrintForecastForNextDays(ForecastWeatherResponse forecastWeatherResponse)
        {
            Debug.WriteLine("\nПрогноз погоды на ближайшие 5 дней:");

            var groupedForecasts = forecastWeatherResponse.List
                .GroupBy(f => f.Dt_txt.Date)  // Группируем по дате
                .Take(5);  // Берем только следующие 5 дней

            foreach (var dayGroup in groupedForecasts)
            {
                Debug.WriteLine($"\nПрогноз для {dayGroup.Key.ToString("dd MMMM yyyy")}:");

                // Разделяем данные по утру, дню, вечеру и ночи
                var morning = dayGroup.FirstOrDefault(f => f.Dt_txt.Hour >= 6 && f.Dt_txt.Hour < 12);
                var afternoon = dayGroup.FirstOrDefault(f => f.Dt_txt.Hour >= 12 && f.Dt_txt.Hour < 18);
                var evening = dayGroup.FirstOrDefault(f => f.Dt_txt.Hour >= 18 && f.Dt_txt.Hour < 24);
                var night = dayGroup.FirstOrDefault(f => f.Dt_txt.Hour >= 0 && f.Dt_txt.Hour < 6);

                PrintForecast("Утро", morning);
                PrintForecast("День", afternoon);
                PrintForecast("Вечер", evening);
                PrintForecast("Ночь", night);
            }
        }

        /// <summary>
        /// Получает почасовой прогноз погоды на несколько дней для заданного города.
        /// </summary>
        /// <param name="city">Название города.</param>
        /// <returns>Объект, содержащий прогноз погоды на несколько дней.</returns>
        public async Task<ForecastWeatherResponse> GetHourlyForecast(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}forecast?q={city}&appid={apiKey}&units=metric";
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ForecastWeatherResponse>(response);  // Десериализуем в объект
            }
        }
    }
}
