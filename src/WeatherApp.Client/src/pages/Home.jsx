import { useState } from "react";
import "../styles/Home.css";
import SearchBar from "../components/SearchBar";
import { getCurrentWeather, getWeatherForecast } from "../api/weatherApi.js";
import CurrentWeather from "../components/CurrentWeather.jsx";
import Forecast from "../components/Forecast.jsx";

function App() {
  const [currentCity, setCurrentCity] = useState(null);
  const [currentWeather, setCurrentWeather] = useState(null);
  const [forecast, setForecast] = useState(null);
  const [unit, setUnit] = useState("C");

  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  async function handleCitySelect(city) {
    if (city == null) return;
    setCurrentCity(city);
    setError("");

    try {
      setLoading(true);
      const currentWeatherData = await getCurrentWeather(city.geoNameId);
      setCurrentWeather(currentWeatherData);

      const forecastData = await getWeatherForecast(city.geoNameId);
      setForecast(forecastData.forecasts);
    } catch (error) {
      setError(
        "Weather service is currently unavailable. Please try again later.",
      );
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="home-container">
      <SearchBar onCitySelect={handleCitySelect} handleError={setError} />
      {loading && <div className="loader"></div>}
      {error && <p className="search-error">{error}</p>}
      <CurrentWeather
        city={currentCity}
        weather={currentWeather}
        unit={unit}
        setUnit={setUnit}
      />
      <Forecast forecastList={forecast} unit={unit} />
    </div>
  );
}

export default App;
