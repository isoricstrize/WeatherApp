export default function TemperatureToggle({ unit, setUnit }) {
  return (
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
  );
}
