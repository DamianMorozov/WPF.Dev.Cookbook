using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CH01.SingleInstanceDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);

        [DllImport("user32")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mutex = new Mutex(true, "SingleInstanceDemo", out bool isNewInstance);
            if (!isNewInstance)
            {
                // MessageBox.Show("Application instance is already running!");
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
