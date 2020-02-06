using System.Windows;

namespace CH01.PageDemo
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void ButtonPrevious_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
