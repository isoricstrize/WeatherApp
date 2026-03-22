using WeatherApp.CityDataSeeder.Cli;

namespace WeatherApp.Cli.UnitTests;

public class CityDataSeederTests
{
    private WeatherApp.CityDataSeeder.Cli.CityDataSeeder _seeder;

    [SetUp]
    public void Setup()
    {
        _seeder = new WeatherApp.CityDataSeeder.Cli.CityDataSeeder(null);
    }

    [Test]
    public void Parse_InvalidLine_RetrunsNull()
    {
        var line = "Invalid line";

        var result = _seeder.Parse(line);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Parse_ValidLine_ReturnsCity()
    {
        var line = string.Join('\t', new string[]
        {
        "1", "Zagreb", "Zagreb", "", "45.8", "15.9",
        "P", "", "HR", "", "", "", "", "", "800000", "", "", "Europe/Zagreb"
        });

        var result = _seeder.Parse(line);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Zagreb"));
    }

    [Test]
    public void Parse_NonEuropeanTimezone_ReturnsNull()
    {
        var line = string.Join('\t', new string[]
        {
        "1", "NY", "NY", "", "40.7", "-74.0",
        "P", "", "US", "", "", "", "", "", "1000000", "", "", "America/New_York"
        });

        var result = _seeder.Parse(line);

        Assert.That(result, Is.Null);
    }

}
