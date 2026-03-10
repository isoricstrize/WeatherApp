using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.DTOs;

namespace WeatherApp.WebApi.Services.Interfaces
{
    public interface ICityService
    {
        Task<City?> GetCityByIdAsync(int id);

        Task<List<CityDto>> SearchCitiesAsync(string searchTerm);
    }
}