import "../styles/CurrentWeather.css";

export default function CurrentWeather({ weather }) {
  if (!weather) return null;

  const iconUrl = `https://openweathermap.org/img/wn/${weather.icon}@2x.png`;

  return (
    <div className="weather-card">
      {/* CITY NAME CENTERED */}
      <h2 className="weather-city">
        {weather.city}, {weather.country}
      </h2>

      {/* TWO COLUMN INFO */}
      <div className="weather-columns">
        {/* LEFT COLUMN */}
        <div className="weather-left">
          <div className="weather-main">
            <img src={iconUrl} alt={weather.description} />
            <p className="description">{weather.description}</p>
          </div>
          <p className="temperature">{Math.round(weather.temperature)}°F</p>
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
              <span className="value">{Math.round(weather.feelsLike)}°F</span>
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}
