using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.CityDataSeeder.Cli.Models;
using Microsoft.Data.Sqlite;


namespace WeatherApp.CityDataSeeder.Cli.Data
{
    public class DatabaseManager(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public void CreateDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Cities (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        GeoNameId INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        AsciiName TEXT,
                        CountryCode TEXT NOT NULL,
                        Latitude REAL NOT NULL,
                        Longitude REAL NOT NULL,
                        Population INTEGER,
                        Timezone TEXT
                    );
                ";

            using var command = new SqliteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();

        }

        public void InsertCities(List<City> cities)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                foreach (var city in cities)
                {
                    InsertCity(connection, transaction, city);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private void InsertCity(SqliteConnection connection, SqliteTransaction transaction, City city)
        {
            using var cmd = connection.CreateCommand();

            cmd.Transaction = transaction;

            cmd.CommandText = @"
                INSERT INTO Cities (GeoNameId, Name, AsciiName, Latitude, Longitude, CountryCode, Population, Timezone)
                VALUES (@geoname, @name, @asciiname, @lat, @lon, @country, @population, @timezone)";

            cmd.Parameters.AddWithValue("@geoname", city.GeoNameId);
            cmd.Parameters.AddWithValue("@name", city.Name);
            cmd.Parameters.AddWithValue("@asciiname", city.AsciiName);
            cmd.Parameters.AddWithValue("@lat", city.Latitude);
            cmd.Parameters.AddWithValue("@lon", city.Longitude);
            cmd.Parameters.AddWithValue("@country", city.CountryCode);
            cmd.Parameters.AddWithValue("@population", city.Population);
            cmd.Parameters.AddWithValue("@timezone", city.Timezone);

            cmd.ExecuteNonQuery();
        }
    }
}