using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CH04.NotificationPropertiesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        #endregion

        #region Fields and properties

        public string Department => "Software Engineering";

        private string personName;
        public string PersonName
        {
            get => personName;
            set
            {
                personName = value;
                OnPropertyRaised();
            }
        }

        #endregion

        #region Private methods

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello " + PersonName);
        }

        private void OnReset(object sender, RoutedEventArgs e)
        {
            PersonName = string.Empty;
        }


        #endregion
    }
}
