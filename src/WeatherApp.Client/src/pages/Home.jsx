import { useState } from "react";
import "../styles/Home.css";
import SearchBar from "../components/SearchBar";

function App() {
  function handleCitySelect(city) {
    console.log("Choosen city: ", city.name, city.countryCode);
  }

  return (
    <div className="home-container">
      <SearchBar onCitySelect={handleCitySelect} />
    </div>
  );
}

export default App;
