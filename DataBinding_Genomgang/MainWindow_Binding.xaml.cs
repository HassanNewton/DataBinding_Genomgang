using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DataBinding_Genomgang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _name;
        public string FirstName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                //OnPropertyChanged("Name");
                //OnPropertyChanged(nameof(Name));
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                //OnPropertyChanged("Name");
                //OnPropertyChanged(nameof(Name));
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public List<String> Countries { get; set; } = new List<string> { "Sverige", "Norge", "Finland" };

        private string _selectedCountry;
        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> Tasks { get; set; } = new();

        private string _selectedTask;
        public string SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        private string _newTask;
        public string NewTask
        {
            get { return _newTask; }
            set
            {
                _newTask = value;
                OnPropertyChanged(nameof(NewTask));
            }
        }




        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LÄgga till task i listan TASKS
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                Tasks.Add(NewTask);
                NewTask = "";
            }

        }
    }

    //ObservableCollection notifiera tala om för UI att ändringar har skett
    //textboxen -> newTask twowaybinding,
    //ändringar i textboxen påverkar ändringar i Code-behind

    //När vi trycker på Add -> NewTask läggs till i listan TASKS
    //Listboxen uppdateras automatiskt tack vare ObservableCollection

    //TextBoxen töms automatiskt eftersom NewTask = ""
    //TextBlocket uppdateras automatiskt när selectedTask ändras

    //Vad gör DataContext? 
    //Anger vart props/datan kommer ifrån

    //Vad händer utan OnPropertyChanged?
    //UI uppdateras INTE

    //OneWay och TwoWay
    //oneway kod -> UI
    //TwoWay kod -> UI & UI -> Kod

    //Varför ObservableCollection<> och inte List<>?
    //Den notifierar UI vid ändringar (lagt till/tagit bort element)

    //Vad gör [CallerMemeberName]
    //Skriver automatiskt in prop namnet till metoden OnPropertyChanged
}