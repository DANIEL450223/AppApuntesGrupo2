using AppApuntesGrupo2.Models;
using AppApuntesGrupo2.ViewModel;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace AppApuntesGrupo2.ViewModels
{
    public class NotePageViewModel : BaseViewModel
    {
        private string nuevaNota;
        private const string FileName = "notas.json";
        private string FilePath => Path.Combine(FileSystem.AppDataDirectory, FileName);

        public ObservableCollection<Nota> Notas { get; set; } = new();

        public string NuevaNota
        {
            get => nuevaNota;
            set => SetProperty(ref nuevaNota, value);
        }

        public ICommand AgregarNotaCommand { get; }
        public ICommand EliminarNotaCommand { get; }

        public NotePageViewModel()
        {
            AgregarNotaCommand = new Command(AgregarNota);
            EliminarNotaCommand = new Command<Nota>(EliminarNota);
            CargarNotas();
        }

        private void AgregarNota()
        {
            if (string.IsNullOrWhiteSpace(NuevaNota))
                return;

            var nota = new Nota
            {
                Texto = NuevaNota,
                FechaCreacion = DateTime.Now
            };
            Notas.Add(nota);
            GuardarNotas();
            NuevaNota = string.Empty;
        }

        private void EliminarNota(Nota nota)
        {
            if (Notas.Contains(nota))
            {
                Notas.Remove(nota);
                GuardarNotas();
            }
        }

        private async void CargarNotas()
        {
            if (File.Exists(FilePath))
            {
                string json = await File.ReadAllTextAsync(FilePath);
                var lista = JsonSerializer.Deserialize<List<Nota>>(json);
                if (lista != null)
                {
                    foreach (var n in lista)
                        Notas.Add(n);
                }
            }
        }

        private async void GuardarNotas()
        {
            string json = JsonSerializer.Serialize(Notas.ToList());
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}
