using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Data;
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
    }
}