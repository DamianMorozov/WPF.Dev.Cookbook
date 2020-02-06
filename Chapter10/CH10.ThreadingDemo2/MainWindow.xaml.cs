using System;
using System.Threading;
using System.Windows;

namespace CH10.ThreadingDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int totalOdd = 0;
        private int totalEven = 0;
        private CancellationTokenSource tokenSource = null;

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
                cancelButton.IsEnabled = true;

                tokenSource = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    CalculateOddEven(from, to, tokenSource.Token);

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (totalOdd < 0 || totalEven < 0)
                        {
                            oddResultBlock.Text = "Operation canceled!";
                            evenResultBlock.Text = string.Empty;
                        }
                        else
                        {
                            oddResultBlock.Text = "Total odd numbers: " + totalOdd;
                            evenResultBlock.Text = "Total even numbers: " + totalEven;
                        }

                        calculateButton.IsEnabled = true;
                        cancelButton.IsEnabled = false;
                    }));
                });
            }
        }

        private void CalculateOddEven(int from, int to, CancellationToken token)
        {
            for (int i = from; i <= to; i++)
            {
                if(token.CanBeCanceled && token.IsCancellationRequested)
                {
                    totalOdd = -1;
                    totalEven = -1;
                    return;
                }

                if (i % 2 == 0) { totalEven++; }
                else { totalOdd++; }
            }
        }

        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
                tokenSource = null;
            }
        }
    }
}
