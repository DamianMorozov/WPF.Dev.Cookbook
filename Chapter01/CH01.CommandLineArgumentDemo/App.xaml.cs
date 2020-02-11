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

            var args = e.Args;
            if (args.Contains("/other")) { new OtherWindow().Show(); }
            else { new MainWindow().Show(); }
        }
    }
}
