using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    public class Day
    {
        public DateTime Date { get; set; }
        public WeatherData Morning { get; set; }
        public WeatherData Afternoon { get; set; }
        public WeatherData Evening { get; set; }
        public WeatherData Night { get; set; }
    }
}
