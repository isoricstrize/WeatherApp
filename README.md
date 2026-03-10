# WeatherApp

Full-stack weather application using React, ASP.NET Core Web API and SQLite.
The application allows users to view current weather and 5-day forecasts for cities stored in the database.

## Architecture

Project summaries:

- **CLI Project** — Imports GeoNames city data into the SQLite database. This project is used for seeding city data.

- **Domain** — Contains core entities shared across the solution.

- **Web API** — ASP.NET Core Web API that:
  - Serves weather data for cities stored in the database
  - Uses a service layer to separate business logic from controllers
  - Retrieves current weather and forecast data from an external weather API
  - Maps external API responses to clean DTOs
  - Implements in-memory caching (`IMemoryCache`) to reduce external API calls
  - Provides API documentation using Scalar

- **Weather Frontend** [TODO] — React application that will consume the Web API and display current weather and forecasts to users.
