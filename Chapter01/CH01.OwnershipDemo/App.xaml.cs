using System.Windows;

namespace CH01.OwnershipDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            mainWindow.Show();
            
            var toolBox = new ToolBox { Owner = mainWindow };
            toolBox.Show();
        }
    }
}
