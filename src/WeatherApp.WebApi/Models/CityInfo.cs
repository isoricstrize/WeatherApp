using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.WebApi.Models
{
    public class CityInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("coord")]
        public Coord Coord { get; set; } = null!;

        [JsonPropertyName("country")]
        public string Country { get; set; } = "";

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}