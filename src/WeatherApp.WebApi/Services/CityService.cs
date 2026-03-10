using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Data;
using WeatherApp.WebApi.DTOs;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.Services
{
    public class CityService(CitiesDbContext dbContext) : ICityService
    {
        private readonly CitiesDbContext _dbContext = dbContext;

        // id -> geoNameId
        public async Task<City?> GetCityByIdAsync(int id)
        {
            return await _dbContext.Cities.FindAsync(id);
        }

        public async Task<List<CityDto>> SearchCitiesAsync(string searchTerm)
        {
            return await _dbContext.Cities
                .Where(c => c.Name.Contains(searchTerm))
                .OrderBy(c => c.Name)
                .Take(10) // limit results
                .Select(c => new CityDto { GeoNameId = c.GeoNameId, Name = c.Name })
                .ToListAsync();
        }
    }
}