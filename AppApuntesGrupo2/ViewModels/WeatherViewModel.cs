using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppApuntesGrupo2.Models;
using AppApuntesGrupo2.Repositories;

namespace AppApuntesGrupo2.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string time;
        private string temperature;
        private string humidity;
        private string rain;

        public string Time { get => time; set { time = value; OnPropertyChanged(); } }
        public string Temperature { get => temperature; set { temperature = value; OnPropertyChanged(); } }
        public string Humidity { get => humidity; set { humidity = value; OnPropertyChanged(); } }
        public string Rain { get => rain; set { rain = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task LoadWeather()
        {
            try
            {
                var repo = new WeatherRepository();
                var weather = await repo.GetWeatherAsync();

                Time = weather.time;
                Temperature = $"{weather.temperature_2m} °C";
                Humidity = $"{weather.relative_humidity_2m} %";
                Rain = $"{weather.rain} mm";
            }
            catch (Exception ex)
            {
                Temperature = "Error";
                Humidity = ex.Message;
                Rain = "";
                Time = "";
            }
        }
    }
}
