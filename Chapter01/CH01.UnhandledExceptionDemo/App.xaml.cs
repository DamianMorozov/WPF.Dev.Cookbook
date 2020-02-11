using System;
using System.Windows;
using System.Windows.Threading;

namespace CH01.UnhandledExceptionDemo
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            DispatcherUnhandledException += OnUnhandledException;
        }

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            // Logging exception.
            // Maybe restart app.
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Caught on unhandled exception. Application is going to terminate.");
            Environment.Exit(0);
        }
    }
}
