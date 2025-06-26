using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppApuntesGrupo2.ViewModels
{
    public class NotePageViewModel : INotifyPropertyChanged
    {
        private string noteText;
        private readonly string _fileName;

        public string NoteText
        {
            get => noteText;
            set
            {
                if (noteText != value)
                {
                    noteText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public NotePageViewModel()
        {
            _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
            LoadNote();

            SaveCommand = new Command(SaveNote);
            DeleteCommand = new Command(DeleteNote);
        }

        private void LoadNote()
        {
            if (File.Exists(_fileName))
                NoteText = File.ReadAllText(_fileName);
        }

        private void SaveNote()
        {
            try
            {
                File.WriteAllText(_fileName, NoteText);
            }
            catch (Exception ex)
            {
                // Puedes mostrar un mensaje si gustas
                Console.WriteLine($"Error guardando el archivo: {ex.Message}");
            }
        }

        private void DeleteNote()
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            NoteText = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
