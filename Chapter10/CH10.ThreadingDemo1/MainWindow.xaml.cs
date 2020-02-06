using System;
using System.Threading;
using System.Windows;

namespace CH10.ThreadingDemo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int totalOdd = 0;
        private int totalEven = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, RoutedEventArgs e)
        {
            totalOdd = 0;
            totalEven = 0;

            if (int.TryParse(fromValue.Text, out int from) &&
                int.TryParse(toValue.Text, out int to))
            {
                calculateButton.IsEnabled = false;

                //CalculateOddEven(from, to);

                //oddResultBlock.Text = "Total odd numbers: " + totalOdd;
                //evenResultBlock.Text = "Total even numbers: " + totalEven;
                //calculateButton.IsEnabled = true;

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    CalculateOddEven(from, to);

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        oddResultBlock.Text = "Total odd numbers: " + totalOdd;
                        evenResultBlock.Text = "Total even numbers: " + totalEven;
                        calculateButton.IsEnabled = true;
                    }));
                });
            }
        }

        private void CalculateOddEven(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                if (i % 2 == 0) { totalEven++; }
                else { totalOdd++; }
            }
        }
    }
}
