using System;
using System.Windows;

namespace CH01.PageDemo
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
    }
}
