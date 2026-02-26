using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
    public class City
    {
        public City(int geoNameId, string name, string? asciiName, double latitude, double longitude, int? population, string? timezone, string countryCode = "")
        {
            GeoNameId = geoNameId;
            Name = name;
            AsciiName = asciiName;
            Latitude = latitude;
            Longitude = longitude;
            Population = population;
            Timezone = timezone;
            CountryCode = countryCode;
        }

        public City() { }

        public int GeoNameId { get; set; }
        public string Name { get; set; } = "";
        public string? AsciiName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Population { get; set; }
        public string? Timezone { get; set; }
        public string CountryCode { get; set; } = "";
    }
}