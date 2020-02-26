using System.Windows;
using System.Windows.Controls;

namespace CH02.ComboBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox1.SelectionChanged += ComboBox_SelectionChanged;
            ComboBox2.SelectionChanged += ComboBox_SelectionChanged;
            ComboBox3.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedItem is ComboBoxItem item)
                {
                    if (item.Content is StackPanel stackPanel)
                    {
                        foreach (var childStackPanel in stackPanel.Children)
                        {
                            if (childStackPanel is TextBlock textBlock)
                                MessageBox.Show($"Selected item: {textBlock.Text}");
                        }
                    }
                    else
                        MessageBox.Show($"Selected item: {item.Content}");
                }
            }
        }
    }
}
