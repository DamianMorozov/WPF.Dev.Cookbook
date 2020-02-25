using System.Windows;
using System.Windows.Controls;

namespace CH02.ListBoxDemo
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

        private void OnAddItemClicked(object sender, RoutedEventArgs e)
        {
            var itemsCount = listBoxItems.Items.Count;
            var item = new ListBoxItem { Content = "Item " + (itemsCount + 1) };

            listBoxItems.Items.Add(item);
            listBoxItems.ScrollIntoView(item);
            listBoxItems.SelectedItem = item;
        }

        private void OnDeleteItemClicked(object sender, RoutedEventArgs e)
        {
            var item = listBoxItems.SelectedItem;
            if (item != null)
            {
                listBoxItems.Items.Remove(item);
                listBoxItems.SelectedIndex = 0;
            }
        }
    }
}
