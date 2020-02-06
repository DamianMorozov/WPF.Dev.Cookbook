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

namespace CH03.DynamicPanelDemo
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

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePosition = e.GetPosition(canvasPanel);
            var square = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Green),
                Opacity = new Random().NextDouble()
            };

            // set the position of the element
            Canvas.SetLeft(square, mousePosition.X - square.Width / 2);
            Canvas.SetTop(square, mousePosition.Y - square.Height / 2);

            // add the element on the Canvas
            canvasPanel.Children.Add(square);
        }

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.Source is UIElement square)
            {
                canvasPanel.Children.Remove(square);

                Grid gridPanel;

// set the Row and Column to place the element
Grid.SetRow(square, 2);
Grid.SetColumn(square, 1);

Grid.SetRowSpan(square, 3);
Grid.SetColumnSpan(square, 2);

// add the element to the Grid
gridPanel.Children.Add(square);
            }
        }
    }
}
