using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.DTOs;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApi.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponseDto?> GetCurrentWeatherAsync(int cityId);
        Task<ForecastResponseDto?> GetForecastWeatherAsync(int cityId);
    }
}