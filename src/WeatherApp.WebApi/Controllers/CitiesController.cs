using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Data;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICityService cityService, ILogger<CitiesController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        // id -> geoNameId
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);

            _logger.LogInformation("Getting city with Id {Id}", id);

            if (city is null)
            {
                _logger.LogWarning("City with Id {Id} was not found", id);
                return NotFound();
            }

            return Ok(city);
        }

    }
}