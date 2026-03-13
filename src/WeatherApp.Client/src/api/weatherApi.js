export async function getCurrentWeather(cityId) {
  const response = await fetch(`http://localhost:5107/api/Weather/current/city/${cityId}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json"
    }
  });

  if (!response.ok) {
    throw new Error("Failed to fetch current weather data for cityId:", cityId);
  }

  return response.json();
}

export async function getWeatherForecast(cityId) {
  const response = await fetch(`http://localhost:5107/api/Weather/forecast/city/${cityId}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json"
    }
  });

  if (!response.ok) {
    throw new Error("Failed to fetch weather forecast data for cityId:", cityId);
  }

  return response.json();
}