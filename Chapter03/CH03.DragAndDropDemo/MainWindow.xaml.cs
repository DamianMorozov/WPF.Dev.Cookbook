using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace CH03.DragAndDropDemo
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

        private void Panel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is UIElement element)
            {
                DragDrop.DoDragDrop(element, element, DragDropEffects.Move);
            }
        }
        
        private void Panel_OnDrop(object sender, DragEventArgs e)
        {
            if (!(sender is WrapPanel panel1) || e.Data == null || e.Data.GetFormats().Length == 0)
                return;

            if (e.Data.GetData(e.Data.GetFormats()[0]) is UIElement element)
            {
                if (element is Label label)
                {
                    foreach (var child in UniformGridMain.Children)
                    {
                        if (child is WrapPanel panel2 && !panel2.Name.Equals(panel1.Name))
                        {
                            panel2.Children.Remove(element);
                            panel1.Children.Add(element);
                        }
                    }
                }
            }
        }

    }
}
