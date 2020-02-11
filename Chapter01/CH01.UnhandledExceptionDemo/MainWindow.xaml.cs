using System;
using System.Windows;

namespace CH01.UnhandledExceptionDemo
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

        private void OnThrowExceptionClicked(object sender, RoutedEventArgs e)
        {
            if (radioOne.IsChecked == true)
            {
                try
                {
                    throw new Exception("Demo Exception");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("'" + ex.Message + "' handled in Try/Catch block");
                }
            }
            else
            {
                throw new Exception("Demo Exception");
            }
        }
    }
}
