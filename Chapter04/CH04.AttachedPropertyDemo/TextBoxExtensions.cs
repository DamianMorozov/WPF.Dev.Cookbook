using System.Windows;
using System.Windows.Controls;

namespace CH04.AttachedPropertyDemo
{
    public class TextBoxExtensions
    {
        public static bool GetSelectOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectOnFocusProperty);
        }

        public static void SetSelectOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectOnFocusProperty, value);
        }

        public static readonly DependencyProperty SelectOnFocusProperty =
            DependencyProperty.RegisterAttached("SelectOnFocus", typeof(bool), typeof(TextBoxExtensions), new PropertyMetadata(false, OnSelectOnFocusChanged));

        private static void OnSelectOnFocusChanged(DependencyObject d, 
                                 DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += (s, arg) =>
                {
                    textBox.SelectAll();
                };
            }
        }
    }
}
