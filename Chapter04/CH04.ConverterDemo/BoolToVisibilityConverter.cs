using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CH04.ConverterDemo
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // return value is bool val && val ? Visibility.Visible : Visibility.Collapsed;

            var val = (bool) value;
            if (parameter is string param && param.ToString().Equals("inverse")) { val = !val; }

            return val ? Visibility.Visible: Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
