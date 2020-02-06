using System.Windows;

namespace CH01.WindowDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSecondWindowButtonClicked(object sender, RoutedEventArgs e)
        {
            var window = new SecondWindow();
            window.Show();
        }
    }
}
