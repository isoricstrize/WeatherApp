using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class ForecastItem
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; } = null!;

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; } = [];

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; } = null!;

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = null!;

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; }

        [JsonPropertyName("rain")]
        public Rain? Rain { get; set; } = null!;

        [JsonPropertyName("snow")]
        public Snow? Snow { get; set; } = null!;

        [JsonPropertyName("sys")]
        public ForecastSys Sys { get; set; } = null!;

        [JsonPropertyName("dt_txt")]
        public string DateText { get; set; } = "";

    }
}