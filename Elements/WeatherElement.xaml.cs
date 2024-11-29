using Kylosov.Classes.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kylosov.Elements
{
    /// <summary>
    /// Логика взаимодействия для WeatherElement.xaml
    /// </summary>
    public partial class WeatherElement : UserControl
    {
        public WeatherElement(DateTime dateTime, WeatherData morning, WeatherData day, WeatherData evening, WeatherData night)
        {
            InitializeComponent();

            // Устанавливаем дату
            DateOfWeather.Text = dateTime.ToString("dd MMMM yyyy");

            // Обработка данных для утреннего времени
            WeatherMorning.Text = morning?.Temp != null ? $"{morning.Temp}°C" : "Нет данных";
            WeatherTypeMorning.Text = morning?.Description ?? "Нет данных";
            PressureMorning.Text = morning?.Pressure != null ? $"{morning.Pressure} гПа" : "Нет данных";
            HumidityMorning.Text = morning?.Humidity != null ? $"{morning.Humidity}%" : "Нет данных";
            WindMorning.Text = morning?.WindSpeed != null ? $"{morning.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для дневного времени
            WeatherDay.Text = day?.Temp != null ? $"{day.Temp}°C" : "Нет данных";
            WeatherTypeDay.Text = day?.Description ?? "Нет данных";
            PressureDay.Text = day?.Pressure != null ? $"{day.Pressure} гПа" : "Нет данных";
            HumidityDay.Text = day?.Humidity != null ? $"{day.Humidity}%" : "Нет данных";
            WindDay.Text = day?.WindSpeed != null ? $"{day.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для вечернего времени
            WeatherEvening.Text = evening?.Temp != null ? $"{evening.Temp}°C" : "Нет данных";
            WeatherTypeEvening.Text = evening?.Description ?? "Нет данных";
            PressureEvening.Text = evening?.Pressure != null ? $"{evening.Pressure} гПа" : "Нет данных";
            HumidityEvening.Text = evening?.Humidity != null ? $"{evening.Humidity}%" : "Нет данных";
            WindEvening.Text = evening?.WindSpeed != null ? $"{evening.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для ночного времени
            WeatherNight.Text = night?.Temp != null ? $"{night.Temp}°C" : "Нет данных";
            WeatherTypeNight.Text = night?.Description ?? "Нет данных";
            PressureNight.Text = night?.Pressure != null ? $"{night.Pressure} гПа" : "Нет данных";
            HumidityNight.Text = night?.Humidity != null ? $"{night.Humidity}%" : "Нет данных";
            WindNight.Text = night?.WindSpeed != null ? $"{night.WindSpeed} м/с" : "Нет данных";
        }
    }

}
