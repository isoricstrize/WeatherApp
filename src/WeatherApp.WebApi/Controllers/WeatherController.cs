using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("city/{id}")]
        public async Task<ActionResult<string>> GetWeatherForCity(int id)
        {
            var result = await _weatherService.GetWeatherForCityByIdAsync(id);

            if (result is null)
                return BadRequest("Weather not found.");

            return Ok(result);
        }
    }
}