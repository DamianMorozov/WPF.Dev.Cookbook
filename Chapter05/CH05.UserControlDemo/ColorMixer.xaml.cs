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

namespace CH05.UserControlDemo
{
    /// <summary>
    /// Interaction logic for ColorMixer.xaml
    /// </summary>
    public partial class ColorMixer : UserControl
    {
        public ColorMixer()
        {
            InitializeComponent();
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorMixer), new PropertyMetadata(Colors.OrangeRed));

        public delegate void OnOkButtonClick(object sender, EventArgs e);
        public delegate void OnCancelButtonClick(object sender, EventArgs e);

        public event OnOkButtonClick OkButtonClick;
        public event OnCancelButtonClick CancelButtonClick;

        private void OnOkClicked(object sender, RoutedEventArgs e)
        {
            OkButtonClick?.Invoke(sender, e);
        }

        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            CancelButtonClick?.Invoke(sender, e);
        }
    }
}
