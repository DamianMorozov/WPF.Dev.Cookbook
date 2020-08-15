using System.Windows;

namespace CH01.PageDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Page1 _page1 = new Page1();
        private readonly Page2 _page2 = new Page2();
        private readonly Page3 _page3 = new Page3();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(_page1);
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (FrameMain.Content is Page3)
                FrameMain.Navigate(_page2);
            else if(FrameMain.Content is Page2)
                FrameMain.Navigate(_page1);
            //if (NavigationService != null && NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            if (FrameMain.Content is Page1)
                FrameMain.Navigate(_page2);
            else if (FrameMain.Content is Page2)
                FrameMain.Navigate(_page3);
            //NavigationService?.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
    }
}
