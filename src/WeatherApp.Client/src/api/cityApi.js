export async function searchCities(search) {
  const response = await fetch(
    `http://localhost:5107/api/Cities?search=${search}`
  );

  if (!response.ok) {
    throw new Error("Failed to fetch cities");
  }

  return response.json();
}