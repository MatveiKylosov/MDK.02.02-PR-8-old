using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    /// <summary>
    /// Класс, представляющий основные метеорологические данные (температура, влажность).
    /// </summary>
    public class MainWeather
    {
        public double Temp { get; set; }  // Температура
        public int Humidity { get; set; }  // Влажность
    }
}
