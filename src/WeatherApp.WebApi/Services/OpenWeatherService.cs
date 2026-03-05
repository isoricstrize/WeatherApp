using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.DTOs;
using WeatherApp.WebApi.Models;
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

        public async Task<WeatherResponseDto?> GetCurrentWeatherAsync(int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city is null)
                return null;

            var url = $"data/2.5/weather?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine(error);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<WeatherResponse>(content);

            if (weather is null)
                return null;

            // Mapping (WeatherResponse -> WeatherResponseDto)
            return new WeatherResponseDto
            {
                City = weather.Name,
                Country = weather.Sys.Country,
                Temperature = weather.Main.Temp,
                FeelsLike = weather.Main.FeelsLike,
                Description = weather.Weather.FirstOrDefault()?.Description ?? "",
                Icon = weather.Weather.FirstOrDefault()?.Icon ?? "",
                Humidity = weather.Main.Humidity,
                WindSpeed = weather.Wind.Speed
            };

        }

        public async Task<ForecastResponseDto?> GetForecastWeatherAsync(int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city is null)
                return null;

            var url = $"data/2.5/forecast?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine(error);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var forecast = JsonSerializer.Deserialize<ForecastResponse>(content);

            if (forecast is null)
                return null;

            var dailyForecasts = forecast!.ForecastItems
                .GroupBy(x => DateTime.Parse(x.DateText).Date)
                .Select(group =>
                {
                    var first = group.First();

                    return new DailyForecastDto
                    {
                        Date = group.Key,
                        Temperature = group.Average(x => x.Main.Temp), // or First().Main.Temp
                        FeelsLike = group.Average(x => x.Main.FeelsLike),
                        Description = first.Weather.FirstOrDefault()?.Description ?? "",
                        Humidity = (int)group.Average(x => x.Main.Humidity),
                        WindSpeed = group.Average(x => x.Wind.Speed),
                        Icon = first.Weather.FirstOrDefault()?.Icon ?? ""
                    };
                })
                .ToList();

            return new ForecastResponseDto
            {
                City = forecast.City.Name,
                Country = forecast.City.Country,
                Forecasts = dailyForecasts
            };
        }
    }
}


