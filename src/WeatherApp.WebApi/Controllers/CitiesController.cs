using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Data;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController(CitiesDbContext dbContext) : ControllerBase
    {
        private readonly CitiesDbContext _dbContext = dbContext;

        // id -> geoNameId
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await _dbContext.Cities.FindAsync(id);

            if (city is null) return NotFound();

            return Ok(city);
        }

    }
}