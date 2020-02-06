using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CH01.DialogBoxDemo
{
    /// <summary>
    /// Interaction logic for CommonDialogs.xaml
    /// </summary>
    public partial class CommonDialogs : Window
    {
        public CommonDialogs()
        {
            InitializeComponent();
        }

        private void OnOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            var openfileDialog = new OpenFileDialog
            {
                Filter = "Text documents (.txt) | *.txt | Log files (.log) | *.log"
            };

            var dialogResult = openfileDialog.ShowDialog();
            if (dialogResult == true)
            {
                var fileName = openfileDialog.FileName;
            }
        }

        private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text documents (.txt) | *.txt | Log files (.log) | *.log"
            };

            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == true)
            {
                var fileName = saveFileDialog.FileName;
            }
        }

        private void OnPrintButtonClicked(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            var dialogResult = printDialog.ShowDialog();

            if (dialogResult == true)
            {
                // perform the print operation
            }
        }

        private void OnFontButtonClicked(object sender, RoutedEventArgs e)
        {
            var fontDialog = new System.Windows.Forms.FontDialog();
            var dialogResult = fontDialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // get the values out of the fontDialog instance
            }
        }

        private void OnColorButtonClicked(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            var dialogResult = colorDialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // get the values out of the colorDialog instance
            }
        }
    }
}
