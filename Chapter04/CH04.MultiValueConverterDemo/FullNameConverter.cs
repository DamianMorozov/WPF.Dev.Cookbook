using System;
using System.Globalization;
using System.Windows.Data;

namespace CH04.MultiValueConverterDemo
{
    public class FullNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0} {1} {2}", values[0], values[1], values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(' ');
        }
    }
}
