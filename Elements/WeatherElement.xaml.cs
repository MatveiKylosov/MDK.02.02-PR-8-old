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
        public WeatherElement(Day day)
        {
            InitializeComponent();

            // Устанавливаем дату
            DateOfWeather.Text = $"{day.Date.ToString("dd MMMM")}";

            // Обработка данных для утреннего времени
            WeatherMorning.Text = day.Morning?.Temp != null ? $"{day.Morning.Temp}°C" : "Нет данных";
            WeatherTypeMorning.Text =day.Morning?.Description ?? "Нет данных";
            PressureMorning.Text =day.Morning?.Pressure != null ? $"{day.Morning.Pressure} гПа" : "Нет данных";
            HumidityMorning.Text =day.Morning?.Humidity != null ? $"{day.Morning.Humidity}%" : "Нет данных";
            WindMorning.Text =day.Morning?.WindSpeed != null ? $"{day.Morning.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для дневного времени
            WeatherDay.Text = day.Afternoon?.Temp != null ? $"{day.Afternoon.Temp}°C" : "Нет данных";
            WeatherTypeDay.Text = day.Afternoon?.Description ?? "Нет данных";
            PressureDay.Text = day.Afternoon?.Pressure != null ? $"{day.Afternoon.Pressure} гПа" : "Нет данных";
            HumidityDay.Text = day.Afternoon?.Humidity != null ? $"{day.Afternoon.Humidity}%" : "Нет данных";
            WindDay.Text = day.Afternoon?.WindSpeed != null ? $"{day.Afternoon.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для вечернего времени
            WeatherEvening.Text = day.Evening?.Temp != null ? $"{day.Evening.Temp}°C" : "Нет данных";
            WeatherTypeEvening.Text = day.Evening?.Description ?? "Нет данных";
            PressureEvening.Text = day.Evening?.Pressure != null ? $"{day.Evening.Pressure} гПа" : "Нет данных";
            HumidityEvening.Text = day.Evening?.Humidity != null ? $"{day.Evening.Humidity}%" : "Нет данных";
            WindEvening.Text = day.Evening?.WindSpeed != null ? $"{day.Evening.WindSpeed} м/с" : "Нет данных";

            // Обработка данных для ночного времени
            WeatherNight.Text = day.Night?.Temp != null ? $"{day.Night.Temp}°C" : "Нет данных";
            WeatherTypeNight.Text = day.Night?.Description ?? "Нет данных";
            PressureNight.Text = day.Night?.Pressure != null ? $"{day.Night.Pressure} гПа" : "Нет данных";
            HumidityNight.Text = day.Night?.Humidity != null ? $"{day.Night.Humidity}%" : "Нет данных";
            WindNight.Text = day.Night?.WindSpeed != null ? $"{day.Night.WindSpeed} м/с" : "Нет данных";
        }
    }

}
