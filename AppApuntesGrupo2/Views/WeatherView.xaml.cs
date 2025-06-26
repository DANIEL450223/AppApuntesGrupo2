using AppApuntesGrupo2.ViewModels;

namespace AppApuntesGrupo2.Views
{
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();
            Appearing += async (s, e) => await ((WeatherViewModel)BindingContext).LoadWeather();
        }
    }
}
