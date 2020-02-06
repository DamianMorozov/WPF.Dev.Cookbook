using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace CH11.Win32ApiCallDemo
{
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        private static Process process = new Process();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGoClicked(object sender, RoutedEventArgs e)
        {
            goButton.IsEnabled = false;
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Arguments = address.Text;
            process.Start();
        }

        private void OnBringToFrontClicked(object sender, RoutedEventArgs e)
        {
            if (process != null)
            {
                var ptr = process.MainWindowHandle;
                SetForegroundWindow(ptr);
            }
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            if (process != null)
            {
                IntPtr ptr = process.MainWindowHandle;
                SetForegroundWindow(ptr);
                SendKeys.SendWait("{F5}");
            }
        }
    }
}
