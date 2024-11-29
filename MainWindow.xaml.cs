using Kylosov.Classes.API;
using Kylosov.Elements;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kylosov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FindClick(object sender, RoutedEventArgs e)
        {
            var forecast = await WeatherService.Get5DayForecastByCityName("Perm");

            foreach (var day in forecast)
            {
                // Создаем WeatherElement для каждого дня
                var weatherElement = new WeatherElement(
                    day.Date,
                    day.Morning,
                    day.Afternoon,
                    day.Evening,
                    day.Night
                );

                // Добавляем элемент в родительский контейнер (например, StackPanel)
                Parrent.Children.Add(weatherElement);
            }
        }
    }
}
