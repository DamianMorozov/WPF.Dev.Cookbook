using System;
using System.Windows;
using System.Windows.Controls;

namespace CH02.CalendarDemo
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

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("You selected: " + 
                ((DateTime)e.AddedItems[0]).ToString("yyyy-MM-dd"));
        }
    }
}
