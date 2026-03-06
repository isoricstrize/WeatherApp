using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.DTOs;
using WeatherApp.WebApi.Models;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _apiKey;
        private readonly ICityService _cityService;
        private readonly ILogger<OpenWeatherService> _logger;

        public OpenWeatherService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration, ICityService cityService, ILogger<OpenWeatherService> logger)
        {
            _httpClient = httpClient;
            _cache = cache;
            _apiKey = configuration["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("OpenWeather API key is missing.");
            _cityService = cityService;
            _logger = logger;
        }

        public async Task<WeatherResponseDto?> GetCurrentWeatherAsync(int cityId)
        {
            // Try get weather data from cache first
            string cacheKey = $"weather_{cityId}";
            if (_cache.TryGetValue(cacheKey, out WeatherResponseDto? cachedWeather))
            {
                _logger.LogInformation("Returning cached weather data.");
                return cachedWeather;
            }

            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city is null)
                return null;

            _logger.LogInformation("Calling external weather API for {City}", city);

            var url = $"data/2.5/weather?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Weather API failed with status {StatusCode}", response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<WeatherResponse>(content);

            if (weather is null)
                return null;

            // Mapping (WeatherResponse -> WeatherResponseDto)
            var result = new WeatherResponseDto
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

            // Save To Cache (10 minutes)
            // Each cached item = size 1 -> SizeLimit is set to 100 in program.cs (cache can hold 100 items)
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)) // Store this data for 10 minutes -> ater that automatically remove it
                .SetSize(1);

            _cache.Set(cacheKey, result, cacheOptions);

            _logger.LogInformation("Saving weather data to cache for {City}", city);

            return result;
        }

        public async Task<ForecastResponseDto?> GetForecastWeatherAsync(int cityId)
        {
            // Try get forecast data from cache first
            string cacheKey = $"forecast_{cityId}";
            if (_cache.TryGetValue(cacheKey, out ForecastResponseDto? cachedForecast))
            {
                _logger.LogInformation("Returning cached forecast data.");
                return cachedForecast;
            }

            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city is null)
                return null;

            _logger.LogInformation("Calling external weather API (forecast) for {City}", city);

            var url = $"data/2.5/forecast?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Weather API (forecast) failed with status {StatusCode}", response.StatusCode);
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

            var result = new ForecastResponseDto
            {
                City = forecast.City.Name,
                Country = forecast.City.Country,
                Forecasts = dailyForecasts
            };

            // Save To Cache (30 minutes)
            // Each cached item = size 1 -> SizeLimit is set to 100 in program.cs (cache can hold 100 items)
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)) // Store this data for 30 minutes -> ater that automatically remove it
                .SetSize(1);

            _cache.Set(cacheKey, result, cacheOptions);

            _logger.LogInformation("Saving forecast data to cache for {City}", city);

            return result;
        }
    }
}


