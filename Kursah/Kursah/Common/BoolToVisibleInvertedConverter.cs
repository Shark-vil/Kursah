using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kursah.Common
{
    /// <summary>
    /// Конвертирует булево значение в состояние отображения
    /// </summary>
    public class BoolToVisibleInvertedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool)value ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
