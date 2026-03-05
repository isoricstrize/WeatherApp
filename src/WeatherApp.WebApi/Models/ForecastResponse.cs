using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class ForecastResponse
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; } = null!;

        [JsonPropertyName("message")]
        public int Message { get; set; }

        [JsonPropertyName("cnt")]
        public int Cnt { get; set; }

        [JsonPropertyName("list")]
        public List<ForecastItem> ForecastItems { get; set; } = [];

        [JsonPropertyName("city")]
        public CityInfo City { get; set; } = null!;
    }
}