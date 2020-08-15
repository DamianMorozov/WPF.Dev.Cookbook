using System.Linq;
using System.Windows;

namespace CH01.CommandLineArgumentDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (e.Args.Contains("/other") || e.Args.Contains("-other"))
            {
                new OtherWindow().Show();
            }
            else
            {
                new MainWindow().Show();
            }
        }
    }
}
