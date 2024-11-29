using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    /// <summary>
    /// Класс, представляющий прогноз погоды для конкретного времени.
    /// </summary>
    public class ForecastItem
    {
        public DateTime Dt_txt { get; set; }  // Дата и время прогноза
        public MainWeather Main { get; set; }  // Температура и другие данные
        public Weather[] Weather { get; set; }  // Описание погоды
    }
}
