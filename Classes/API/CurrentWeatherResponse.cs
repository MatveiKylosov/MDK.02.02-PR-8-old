using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    /// <summary>
    /// Класс, представляющий данные о текущей погоде.
    /// </summary>
    public class CurrentWeatherResponse
    {
        public string Name { get; set; }  // Название города
        public MainWeather Main { get; set; }  // Температура и другие данные
        public Weather[] Weather { get; set; }  // Описание погоды
    }
}
