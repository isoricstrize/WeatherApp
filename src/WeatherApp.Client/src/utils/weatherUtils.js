export function formatTemperatureFromK(valueK, unit = "C") {
  let temperature;
  let unitSymbol;

  if (unit === "C") {
    temperature = Math.round(valueK - 273.15); // Kelvin → Celsius
    unitSymbol = "°C";
  } else if (unit === "F") {
    temperature = Math.round((valueK - 273.15) * 9/5 + 32); // Kelvin → Fahrenheit
    unitSymbol = "°F";
  } else {
    temperature = Math.round(valueK);
    unitSymbol = "K";
  }

  return { temperature, unit: unitSymbol };
}