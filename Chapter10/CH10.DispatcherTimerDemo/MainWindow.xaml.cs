using System;
using System.Windows;
using System.Windows.Threading;

namespace CH10.DispatcherTimerDemo
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = null;

        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1.0);
            dispatcherTimer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void OnStartTimer(object sender, RoutedEventArgs e)
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Start();

                startButton.IsEnabled = false;
                stopButton.IsEnabled = true;
            }
        }

        private void OnStopTimer(object sender, RoutedEventArgs e)
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();

                startButton.IsEnabled = true;
                stopButton.IsEnabled = false;
            }
        }
    }
}
