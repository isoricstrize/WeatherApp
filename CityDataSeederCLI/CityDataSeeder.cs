using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityDataSeederCLI.Data;
using CityDataSeederCLI.Models;

namespace CityDataSeederCLI.Seeder
{
    public class CityDataSeeder(DatabaseManager dbManager)
    {
        private readonly DatabaseManager _dbManager = dbManager;

        public void Seed(string filePath)
        {
            Console.WriteLine("Reading file...");

            var cities = new List<City>();

            foreach (var line in File.ReadLines(filePath))
            {
                var city = Parse(line);

                if (city != null)
                    cities.Add(city);

                if (cities.Count % 1000 == 0)
                    Console.WriteLine($"Parsed {cities.Count} cities...");

            }

            Console.WriteLine($"Parsed {cities.Count} cities");

            Console.WriteLine("Saving to database...");
            _dbManager.InsertCities(cities);

            Console.WriteLine("Done!");
        }

        public City? Parse(string line)
        {
            var parts = line.Split('\t');

            if (parts.Length < 18) return null;
            if (parts[6] != "P") return null; // only P city, village,... http://www.geonames.org/export/codes.html

            var timezone = parts[17];
            if (string.IsNullOrEmpty(timezone) || !timezone.StartsWith("Europe/")) return null; // only Europe timezone

            if (!double.TryParse(parts[4], out double lat)) return null;
            if (!double.TryParse(parts[5], out double lon)) return null;

            int? population = null;
            if (int.TryParse(parts[14], out int pop)) population = pop;

            return new City
            {
                GeoNameId = int.Parse(parts[0]),
                Name = parts[1],
                AsciiName = parts[2],
                Latitude = lat,
                Longitude = lon,
                CountryCode = parts[8],
                Population = population,
                Timezone = timezone
            };

        }
    }
}