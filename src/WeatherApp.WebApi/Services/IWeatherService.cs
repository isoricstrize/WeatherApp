using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Entities;

namespace WeatherApp.WebApi.Services
{
    public interface IWeatherService
    {
        Task</*WeatherResponse?*/string> GetWeatherAsync(double latitude, double longitude);
    }
}