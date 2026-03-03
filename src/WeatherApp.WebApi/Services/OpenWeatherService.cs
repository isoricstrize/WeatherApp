using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Entities;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ICityService _cityService;

        public OpenWeatherService(HttpClient httpClient, IConfiguration configuration, ICityService cityService)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("OpenWeather API key is missing.");
            _cityService = cityService;

        }

        public async Task<string> GetWeatherForCityByIdAsync(int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city is null)
                return "";

            var url = $"data/2.5/weather?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine(error);
                return "";
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;//JsonSerializer.Deserialize<WeatherResponse>(content);

        }

    }
}


/*
{
  "coord": {
    "lon": 16.441,
    "lat": 43.507
  },
  "weather": [
    {
      "id": 804,
      "main": "Clouds",
      "description": "overcast clouds",
      "icon": "04d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 284.17,
    "feels_like": 283.6,
    "temp_min": 284.17,
    "temp_max": 284.17,
    "pressure": 1026,
    "humidity": 87,
    "sea_level": 1026,
    "grnd_level": 1003
  },
  "visibility": 10000,
  "wind": {
    "speed": 2.57,
    "deg": 10
  },
  "clouds": {
    "all": 100
  },
  "dt": 1772457088,
  "sys": {
    "type": 1,
    "id": 6387,
    "country": "HR",
    "sunrise": 1772429382,
    "sunset": 1772469810
  },
  "timezone": 3600,
  "id": 3190261,
  "name": "Split",
  "cod": 200
}
*/