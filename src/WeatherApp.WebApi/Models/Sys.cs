using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class Sys
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}