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

  async function handleCitySelect(city) {
    console.log("Choosen city: ", city.name, city.countryCode, city.geoNameId);

    if (city == null) return;
    setCurrentCity(city);

    try {
      const currentWeatherData = await getCurrentWeather(city.geoNameId);
      console.log("CURRENT WEATHER DATA", currentWeatherData);
      setCurrentWeather(currentWeatherData);

      const forecastData = await getWeatherForecast(city.geoNameId);
      console.log("FORECAST DATA", forecastData.forecasts);
      setForecast(forecastData.forecasts);
    } catch (error) {
      console.error(error);
    }
  }

  return (
    <div className="home-container">
      <SearchBar onCitySelect={handleCitySelect} />
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
