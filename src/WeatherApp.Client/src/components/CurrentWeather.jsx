import "../styles/CurrentWeather.css";
import { formatTemperatureFromK } from "../utils/weatherUtils";

export default function CurrentWeather({ weather, unit, setUnit }) {
  if (!weather) return null;

  const iconUrl = `https://openweathermap.org/img/wn/${weather.icon}@2x.png`;
  const tempObj = formatTemperatureFromK(weather.temperature, unit);
  const feelsLikeObj = formatTemperatureFromK(weather.feelsLike, unit);

  return (
    <div className="weather-card">
      {/* CITY NAME + TEMP UNIT */}
      <div className="weather-header">
        <h2 className="weather-city">
          {weather.city}, {weather.country}
        </h2>

        {/* Temperature unit toggle */}
        <div className="unit-toggle">
          <button
            className={unit === "C" ? "active" : ""}
            onClick={() => setUnit("C")}
          >
            °C
          </button>
          <span>|</span>
          <button
            className={unit === "F" ? "active" : ""}
            onClick={() => setUnit("F")}
          >
            °F
          </button>
          <span>|</span>
          <button
            className={unit === "K" ? "active" : ""}
            onClick={() => setUnit("K")}
          >
            K
          </button>
        </div>
      </div>

      {/* TWO COLUMN INFO */}
      <div className="weather-columns">
        {/* LEFT COLUMN */}
        <div className="weather-left">
          <div className="weather-main">
            <img src={iconUrl} alt={weather.description} />
            <p className="description">{weather.description}</p>
          </div>
          <p className="temperature">
            {Math.round(tempObj.temperature)}
            <span className="unit">{tempObj.unit}</span>
          </p>
        </div>

        {/* RIGHT COLUMN */}
        <div className="weather-right">
          <div className="weather-detail">
            <span className="icon">💧</span>
            <span>
              Humidity: <span className="value">{weather.humidity}%</span>
            </span>
          </div>
          <div className="weather-detail">
            <span className="icon">🌬</span>
            <span>
              Wind: <span className="value">{weather.windSpeed} m/s</span>
            </span>
          </div>
          <div className="weather-detail">
            <span className="icon">🌡</span>
            <span>
              Feels like:{" "}
              <span className="value">
                {Math.round(feelsLikeObj.temperature)}
                {feelsLikeObj.unit}
              </span>
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}
