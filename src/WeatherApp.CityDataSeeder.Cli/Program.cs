using WeatherApp.CityDataSeeder.Cli.Data;
using WeatherApp.CityDataSeeder.Cli;

var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../../", "data");
Directory.CreateDirectory(basePath);

var dbPath = Path.GetFullPath(Path.Combine(basePath, "cities.db"));
// If database already exists, delete it
if (File.Exists(dbPath))
{
    Console.WriteLine("Existing database found. Recreating...");
    File.Delete(dbPath);
}

var connectionString = $"Data Source={dbPath}";

var filePath = "SeedData/cities1000.txt"; // All cities with a population > 1000 

var databaseManager = new DatabaseManager(connectionString);
var seeder = new CityDataSeeder(databaseManager);

databaseManager.CreateDatabase();
seeder.Seed(filePath);

// Result: Parsed 73483 cities
