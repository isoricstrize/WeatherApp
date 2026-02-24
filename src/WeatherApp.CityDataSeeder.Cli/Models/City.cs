using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.CityDataSeeder.Cli.Models
{
    public class City
    {
        public int GeoNameId { get; set; }
        public string Name { get; set; } = "";
        public string? AsciiName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CountryCode { get; set; } = "";
        public int? Population { get; set; }
        public string? Timezone { get; set; }
    }
}