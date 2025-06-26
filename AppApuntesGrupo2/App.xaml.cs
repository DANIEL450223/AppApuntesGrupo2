using AppApuntesGrupo2.Views;

namespace AppApuntesGrupo2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WeatherView());
        }
    }
}
