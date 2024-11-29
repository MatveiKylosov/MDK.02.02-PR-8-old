using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    /// <summary>
    /// Класс для десериализации прогноза погоды на несколько дней.
    /// </summary>
    public class ForecastWeatherResponse
    {
        public List<ForecastItem> List { get; set; }  // Прогноз на несколько дней
    }
}
