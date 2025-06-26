using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesGrupo2.Models
{
    public class WeatherCurrent
    {
        public string time { get; set; }
        public double temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
        public double rain { get; set; }
    }

    public class WeatherResponse
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public WeatherCurrent current { get; set; }
    }
}