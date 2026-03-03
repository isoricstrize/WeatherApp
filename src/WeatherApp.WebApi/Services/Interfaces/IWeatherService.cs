using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Entities;

namespace WeatherApp.WebApi.Services.Interfaces
{
    public interface IWeatherService
    {
        Task</*WeatherResponse?*/string> GetWeatherForCityByIdAsync(int cityId);
    }
}