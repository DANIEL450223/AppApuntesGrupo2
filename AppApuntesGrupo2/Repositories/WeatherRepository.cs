using Microsoft.Maui.Devices.Sensors;
using System.Net.Http.Json;
using AppApuntesGrupo2.Models;

namespace AppApuntesGrupo2.Repositories
{
    public class WeatherRepository
    {
        public async Task<WeatherCurrent> GetWeatherAsync()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location == null)
                throw new Exception("No se pudo obtener la ubicación");

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,relative_humidity_2m,rain";
            using var http = new HttpClient();
            var json = await http.GetFromJsonAsync<WeatherResponse>(url);

            if (json == null || json.current == null)
                throw new Exception("No se pudo obtener el clima");

            return json.current;
        }
    }
}
