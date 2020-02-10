using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace CH01.SingleInstanceDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [DllImport("user32", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string cls, string win);

        [DllImport("user32")]
        private static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// OnStartup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mutex = new Mutex(true, "SingleInstanceDemo", out bool isNewInstance);
            if (!isNewInstance)
            {
                MessageBox.Show("Application instance is already running!");
                ActivateWindow();
                Shutdown();
            }
        }

        private static void ActivateWindow()
        {
            var otherWindow = FindWindow(null, "Single Instance Demo");
            if (otherWindow != IntPtr.Zero)
            {
                SetForegroundWindow(otherWindow);
            }
        }
    }
}
