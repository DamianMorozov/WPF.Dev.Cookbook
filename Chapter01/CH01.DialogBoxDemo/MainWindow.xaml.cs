using System.Windows;

namespace CH01.DialogBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMessage_OnClick(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog();
            var dialogResult = messageDialog.ShowDialog();
            switch (dialogResult)
            {
                case true:
                    ListBoxResult.Items.Add("You clicked 'OK' button.");
                    break;
                case false:
                    ListBoxResult.Items.Add("You clicked 'Cancel' button.");
                    break;
            }
        }

        private void ButtonOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text documents (.txt) | *.txt | Log files (.log) | *.log | All files (.*) | *.*"
            };
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == true)
            {
                ListBoxResult.Items.Add("DialogResult is true.");
                ListBoxResult.Items.Add($"FileName: {openFileDialog.FileName}");
            }
            else
                ListBoxResult.Items.Add("DialogResult is false.");
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text documents (.txt) | *.txt | Log files (.log) | *.log | All files (.*) | *.*"
            };
            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == true)
            {
                ListBoxResult.Items.Add("DialogResult is true.");
                ListBoxResult.Items.Add($"FileName: {saveFileDialog.FileName}");
            }
            else
                ListBoxResult.Items.Add("DialogResult is false.");
        }

        private void ButtonPrint_OnClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new System.Windows.Controls.PrintDialog();
            var dialogResult = printDialog.ShowDialog();
            ListBoxResult.Items.Add(dialogResult == true ? "DialogResult is true." : "DialogResult is false.");
        }

        private void ButtonFont_OnClick(object sender, RoutedEventArgs e)
        {
            var fontDialog = new System.Windows.Forms.FontDialog();
            var dialogResult = fontDialog.ShowDialog();
            ListBoxResult.Items.Add($"DialogResult is {dialogResult}.");

        }

        private void ButtonColor_OnClick(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            var dialogResult = colorDialog.ShowDialog();
            ListBoxResult.Items.Add($"DialogResult is {dialogResult}.");
        }
    }
}
