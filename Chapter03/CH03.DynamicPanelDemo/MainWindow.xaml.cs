using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CH03.DynamicPanelDemo
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

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var square = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Green),
                Opacity = new Random().NextDouble()
            };

            // set the position of the element
            var mousePosition = e.GetPosition(canvasPanel);
            Canvas.SetLeft(square, mousePosition.X - square.Width / 2);
            Canvas.SetTop(square, mousePosition.Y - square.Height / 2);

            // add the element on the Canvas
            canvasPanel.Children.Add(square);
        }

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is UIElement square)
            {
                canvasPanel.Children.Remove(square);
            }
        }
    }
}
