using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.Services;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController(IWeatherService weatherService) : ControllerBase
    {
        private readonly IWeatherService _weatherService = weatherService;

        [HttpGet("{lat}/{lon}")]
        public async Task<ActionResult<string>> GetOpenWeather(double lat, double lon)
        {
            var result = await _weatherService.GetWeatherAsync(lat, lon);

            if (result is null)
                return BadRequest("Weather not found.");

            return Ok(result);
        }
    }
}