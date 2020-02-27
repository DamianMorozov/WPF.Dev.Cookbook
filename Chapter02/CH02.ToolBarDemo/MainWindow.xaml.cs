using System;
using System.Windows;
using System.Windows.Controls;

namespace CH02.ToolBarDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ComboBoxSize.SelectionChanged += OnSelectionChanged;
        }

        private void OnBoldButtonClicked(object sender, RoutedEventArgs e)
        {
            txtBox.FontWeight = txtBox.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
        }

        private void OnItalicButtonClicked(object sender, RoutedEventArgs e)
        {
            txtBox.FontStyle = txtBox.FontStyle == FontStyles.Italic ? FontStyles.Normal : FontStyles.Italic;
        }

        private void OnUnderlineButtonClicked(object sender, RoutedEventArgs e)
        {
            if (txtBox.TextDecorations == TextDecorations.Underline)
            {
                txtBox.TextDecorations = null;
            }
            else
                txtBox.TextDecorations = TextDecorations.Underline;

        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedItem is ComboBoxItem item)
                {
                    if (int.TryParse(item.Content.ToString(), out int i))
                        txtBox.FontSize = i;
                }
            }
        }
    }
}
