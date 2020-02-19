using System;
using System.Windows;

namespace CH02.MenuDemo
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

        private void OnExitMenuClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exit menu item clicked!");
            Environment.Exit(0);
        }

        private void OnOpenMenuClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open menu item clicked!");
        }

        private void OnSaveMenuClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save menu item clicked!");
        }

        private void OnUndoMenuClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Undo menu item clicked!");
        }

        private void OnRedoMenuClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Redo menu item clicked!");
        }
    }
}
