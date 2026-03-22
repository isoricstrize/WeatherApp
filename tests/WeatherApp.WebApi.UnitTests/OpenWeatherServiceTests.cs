using WeatherApp.WebApi.Models;
using WeatherApp.WebApi.Services;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherApp.WebApi.UnitTests;

public class OpenWeatherServiceTests
{
    [Test]
    public void BuildDailyForecasts_WithMidday_UsesMidday()
    {
        var items = new List<ForecastItem>
        {
            new ForecastItem
            {
                DateText = "2024-01-01 06:00:00",
                Main = new MainInfo { Temp = 10, FeelsLike = 10, Humidity = 50 },
                Weather = new List<WeatherInfo> { new WeatherInfo { Description = "clear", Icon = "01d" } },
                Wind = new Wind { Speed = 5 }
            },
            new ForecastItem
            {
                DateText = "2024-01-01 12:00:00",
                Main = new MainInfo { Temp = 20, FeelsLike = 19, Humidity = 60 },
                Weather = new List<WeatherInfo> { new WeatherInfo { Description = "clear", Icon = "01d" } },
                Wind = new Wind { Speed = 6 }
            }
        };

        var result = OpenWeatherService.BuildDailyForecasts(items);

        Assert.That(result[0].Temperature, Is.EqualTo(20));
    }


    [Test]
    public void BuildDailyForecasts_NoMidday_UsesAverage()
    {
        // Arrange
        var items = new List<ForecastItem>
        {
            new ForecastItem
            {
                DateText = "2024-01-01 06:00:00",
                Main = new MainInfo { Temp = 10, FeelsLike = 10, Humidity = 50 },
                Weather = new List<WeatherInfo> { new WeatherInfo { Description = "clear", Icon = "01d" } },
                Wind = new Wind { Speed = 5 }
            },
            new ForecastItem
            {
                DateText = "2024-01-01 09:00:00",
                Main = new MainInfo { Temp = 20, FeelsLike = 20, Humidity = 60 },
                Weather = new List<WeatherInfo> { new WeatherInfo { Description = "clear", Icon = "01d" } },
                Wind = new Wind { Speed = 6 }
            },
            new ForecastItem
            {
                DateText = "2024-01-01 18:00:00",
                Main = new MainInfo { Temp = 30, FeelsLike = 30, Humidity = 70 },
                Weather = new List<WeatherInfo> { new WeatherInfo { Description = "cloudy", Icon = "02d" } },
                Wind = new Wind { Speed = 4 }
            }
        };

        // Act
        var result = OpenWeatherService.BuildDailyForecasts(items);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));

        var day = result.First();

        // Average of 10, 20, 30 = 20
        Assert.That(day.Temperature, Is.EqualTo(20));
    }
}
