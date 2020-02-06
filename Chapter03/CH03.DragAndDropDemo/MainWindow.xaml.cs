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
using System.Windows.Navigation;
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

        private void OnBeginDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Rectangle rectangle)
            {
                DragDrop.DoDragDrop(rectangle, rectangle, DragDropEffects.Move);
            }
        }

        void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is Rectangle rectangle)
            {
                dragSource.Children.Remove(rectangle);
                dropTarget.Children.Add(rectangle);
            }
        }
        private void OnDrop(object sender, DragEventArgs e)
        {
            IDataObject draggedData = NewMethod(e);
            if (draggedData.GetData(draggedData.GetFormats()[0])
            is UIElement droppedItem)
            {
                sourcePanel.Children.Remove(droppedItem);
                targetPanel.Children.Add(droppedItem);
            }
        }

        private static IDataObject NewMethod(DragEventArgs e)
        {
            return e.Data;
        }
    }
}
