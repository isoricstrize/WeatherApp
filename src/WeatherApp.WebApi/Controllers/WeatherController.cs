using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Domain.Entities;
using WeatherApp.WebApi.DTOs;
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

        [HttpGet("current/city/{id}")]
        public async Task<ActionResult<WeatherResponseDto>> GetCurrentWeatherForCity(int id)
        {
            var result = await _weatherService.GetCurrentWeatherAsync(id);

            if (result is null)
                return BadRequest("Weather not found.");

            return Ok(result);
        }

        [HttpGet("forecast/city/{id}")]
        public async Task<ActionResult<ForecastResponseDto>> GetForecastWeatherForCity(int id)
        {
            var result = await _weatherService.GetForecastWeatherAsync(id);

            if (result is null)
                return BadRequest("Weather not found.");

            return Ok(result);
        }
    }
}