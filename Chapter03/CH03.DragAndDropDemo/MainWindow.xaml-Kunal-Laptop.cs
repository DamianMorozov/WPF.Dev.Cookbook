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

namespace CH03.DragAndDropDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is UIElement draggedItem)
            {
                DragDrop.DoDragDrop(draggedItem, draggedItem, DragDropEffects.Move);
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var draggedData = e.Data;
            if (draggedData.GetData(draggedData.GetFormats()[0]) is UIElement droppedItem)
            {
                sourcePanel.Children.Remove(droppedItem);
                targetPanel.Children.Add(droppedItem);
            }
        }
    }
}
