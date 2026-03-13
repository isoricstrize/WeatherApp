import { useState } from "react";
import "../styles/Home.css";
import SearchBar from "../components/SearchBar";
import { getCurrentWeather } from "../api/weatherApi.js";
import CurrentWeather from "../components/CurrentWeather.jsx";

function App() {
  const [currentCity, setCurrentCity] = useState(null);
  const [currentWeather, setCurrentWeather] = useState(null);

  const [unit, setUnit] = useState("C");

  async function handleCitySelect(city) {
    console.log("Choosen city: ", city.name, city.countryCode, city.geoNameId);

    if (city == null) return;
    setCurrentCity(city);

    try {
      const response = await getCurrentWeather(city.geoNameId);
      console.log("WEATHER DATA", response);
      setCurrentWeather(response);
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
    </div>
  );
}

export default App;
