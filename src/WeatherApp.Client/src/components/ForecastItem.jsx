import "../styles/Forecast.css";
import { formatTemperatureFromK } from "../utils/weatherUtils";

export default function ForecastItem({ forecast, unit }) {
  const tempObj = formatTemperatureFromK(forecast.temperature, unit);

  return (
    <div className="forecast-item">
      {/* Date */}
      <p className="forecast-date">
        {new Date(forecast.date).toLocaleDateString(undefined, {
          weekday: "short",
          month: "short",
          day: "numeric",
        })}
      </p>

      {/* Weather icon */}
      <img
        src={`https://openweathermap.org/img/wn/${forecast.icon}@2x.png`}
        alt={forecast.description}
        className="forecast-icon"
      />
      <p className="forecast-temp">
        {tempObj.temperature}
        <span className="unit">{tempObj.unit}</span>
      </p>

      {/* Humidity */}
      <p className="forecast-detail">
        <span className="icon">💧</span>
        <span>{forecast.humidity}%</span>
      </p>

      {/* Wind */}
      <p className="forecast-detail">
        <span className="icon">🌬</span>
        <span>{Math.round(forecast.windSpeed)} m/s</span>
      </p>
    </div>
  );
}
