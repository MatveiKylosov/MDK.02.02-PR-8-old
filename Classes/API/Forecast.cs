using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylosov.Classes.API
{
    public class Forecast
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Wind wind { get; set; }
    }
}
