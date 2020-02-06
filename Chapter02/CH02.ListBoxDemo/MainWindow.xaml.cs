using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH02.ListBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAddItemClicked(object sender, RoutedEventArgs e)
        {
            var itemsCount = lstBox.Items.Count;
            var newitem = new ListBoxItem { Content = "Item " + (itemsCount + 1) };

            lstBox.Items.Add(newitem);
            lstBox.ScrollIntoView(newitem);
            lstBox.SelectedItem = newitem;
        }

        private void OnDeleteItemClicked(object sender, RoutedEventArgs e)
        {
            var selectedItem = lstBox.SelectedItem;
            if (selectedItem != null)
            {
                lstBox.Items.Remove(selectedItem);
                lstBox.SelectedIndex = 0;
            }
        }
    }
}
