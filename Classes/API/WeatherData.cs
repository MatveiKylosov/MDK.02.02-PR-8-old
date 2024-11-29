using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    public class WeatherData
    {
        public double Temp { get; set; }
        public string Description { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}
