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
    }


}