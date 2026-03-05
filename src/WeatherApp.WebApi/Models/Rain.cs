using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class Rain
    {
        [JsonPropertyName("1h")]
        public double? Volume1h { get; set; }

        [JsonPropertyName("3h")]
        public double? Volume3h { get; set; }
    }
}