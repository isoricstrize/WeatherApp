import { useState } from "react";
import "../styles/SearchBar.css";
import { searchCities } from "../api/cityApi.js";

export default function SearchBar({ onCitySelect, handleError }) {
  const [query, setQuery] = useState("");
  const [cities, setCities] = useState([]);

  async function handleChange(e) {
    const value = e.target.value;
    setQuery(value);
    handleError("");

    if (value.length < 2) {
      setCities([]);
      return;
    }

    try {
      const response = await searchCities(value);
      setCities(response);
    } catch (error) {
      handleError("Unable to load cities. Please try again later.");
    }
  }

  function handleSelect(city) {
    setQuery(`${city.name}, ${city.countryCode}`);
    setCities([]);
    onCitySelect(city);
  }

  return (
    <div className="search-container">
      <input
        type="text"
        placeholder="Search city..."
        value={query}
        onChange={handleChange}
      />

      {cities.length > 0 && (
        <ul className="suggestions">
          {cities.map((city) => (
            <li key={city.geoNameId} onClick={() => handleSelect(city)}>
              {city.name}, {city.countryCode}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
