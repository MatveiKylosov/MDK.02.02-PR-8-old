using Kylosov.Classes.API;
using Kylosov.Elements;
using Kylosov.Classes.Database;
using Newtonsoft.Json;
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
using Kylosov.Classes;

namespace Kylosov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherManager _weatherManager;
        public MainWindow()
        {
            InitializeComponent();
            _weatherManager = new WeatherManager();
        }

        private async void FindClick(object sender, RoutedEventArgs e)
        {
            var city = City.Text;

            var forecast = await _weatherManager.Get5DayForecastByCityName(city);
            foreach (var day in forecast) 
            {
                Parrent.Children.Add(new WeatherElement(day));
            }
        }
    }
}
