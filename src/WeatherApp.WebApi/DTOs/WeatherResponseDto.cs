using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.DTOs
{
    public class WeatherResponseDto
    {
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string Description { get; set; } = "";
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; } = "";
    }
}

// TODO!!!