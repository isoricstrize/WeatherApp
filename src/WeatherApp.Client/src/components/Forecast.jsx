import "../styles/Forecast.css";
import ForecastItem from "./ForecastItem";

export default function Forecast({ forecastList, unit }) {
  if (!forecastList) return null;

  return (
    <div className="forecast-row">
      {forecastList.map((item, idx) => (
        <ForecastItem key={idx} forecast={item} unit={unit} />
      ))}
    </div>
  );
}
