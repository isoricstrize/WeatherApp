using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; } = null!;

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; } = [];

        [JsonPropertyName("base")]
        public string Base { get; set; } = null!;

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; } = null!;

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = null!;

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; } = null!;

        [JsonPropertyName("rain")]
        public Rain? Rain { get; set; } = null!;

        [JsonPropertyName("snow")]
        public Snow? Snow { get; set; } = null!;

        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; } = null!;

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("cod")]
        public int Cod { get; set; }

    }
}