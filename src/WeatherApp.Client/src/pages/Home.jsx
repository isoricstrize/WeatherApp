import { useState } from "react";
import "../styles/Home.css";
import SearchBar from "../components/SearchBar";
import { getCurrentWeather } from "../api/weatherApi.js";
import CurrentWeather from "../components/CurrentWeather.jsx";

function App() {
  const [currentWeather, setCurrentWeather] = useState(null);

  async function handleCitySelect(city) {
    console.log("Choosen city: ", city.name, city.countryCode, city.geoNameId);

    if (city.geoNameId == null) return;

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
      <CurrentWeather weather={currentWeather} />
    </div>
  );
}

export default App;
