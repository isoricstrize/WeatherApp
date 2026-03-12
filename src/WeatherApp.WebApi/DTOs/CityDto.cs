using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.DTOs
{
    public class CityDto
    {
        public int GeoNameId { get; set; }
        public string Name { get; set; } = "";
        public string CountryCode { get; set; } = "";
    }
}