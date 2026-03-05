using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class ForecastSys
    {
        [JsonPropertyName("pod")]
        public string Pod { get; set; } = string.Empty;
    }
}