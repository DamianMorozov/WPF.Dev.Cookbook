using System.Windows;
using System.Windows.Controls;

namespace CH11.WpfUserControlLibrary
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void OnSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You searched for: {" + searchBox.Text + "}");
        }
    }
}
