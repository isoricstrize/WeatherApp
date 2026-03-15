const API_URL = import.meta.env.VITE_API_BASE_URL;

export async function searchCities(search) {
  const response = await fetch(
    `${API_URL}/Cities?search=${search}`
  );

  if (!response.ok) {
    throw new Error("Failed to fetch cities");
  }

  return response.json();
}