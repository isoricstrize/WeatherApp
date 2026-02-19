using CityDataSeederCLI.Data;
using CityDataSeederCLI.Seeder;

var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Data");
var dbPath = Path.GetFullPath(Path.Combine(basePath, "cities.db"));
var connectionString = $"Data Source={dbPath}";

var filePath = "SeedData/cities1000.txt"; // all cities with a population > 1000 

var databaseManager = new DatabaseManager(connectionString);
var seeder = new CityDataSeeder(databaseManager);

databaseManager.CreateDatabase();
seeder.Seed(filePath);

// Result: Parsed 73483 cities
