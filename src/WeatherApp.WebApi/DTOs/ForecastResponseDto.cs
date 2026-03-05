using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.DTOs
{
    public class ForecastResponseDto
    {
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public List<DailyForecastDto> Forecasts { get; set; } = [];
    }
}