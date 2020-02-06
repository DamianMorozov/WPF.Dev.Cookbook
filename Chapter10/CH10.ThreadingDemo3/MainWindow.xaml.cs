using System;
using System.ComponentModel;
using System.Windows;

namespace CH10.ThreadingDemo3
{
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

                var worker = new BackgroundWorker();
                worker.DoWork += OnWorker_DoWork;
                worker.RunWorkerCompleted += OnWorker_WorkCompleted;
                worker.RunWorkerAsync(new Tuple<int, int>(from, to));
            }
        }

        private void OnWorker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender is BackgroundWorker worker)
            {
                worker.RunWorkerCompleted -= OnWorker_WorkCompleted;
                worker.DoWork -= OnWorker_DoWork;
                worker = null;
            }

            oddResultBlock.Text = "Total odd numbers: " + totalOdd;
            evenResultBlock.Text = "Total even numbers: " + totalEven;

            calculateButton.IsEnabled = true;
        }

        private void OnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var argument = (Tuple<int, int>)e.Argument;
            CalculateOddEven(argument.Item1, argument.Item2);
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
