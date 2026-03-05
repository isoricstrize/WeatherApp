using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class Snow
    {
        [JsonPropertyName("1h")]
        public double? OneHour { get; set; }

        [JsonPropertyName("3h")]
        public double? ThreeHours { get; set; }
    }
}