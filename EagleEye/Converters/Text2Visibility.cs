using System.Globalization;

namespace EagleEye.Converters
{
    public class Text2Visibility : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
            string.IsNullOrEmpty(value.ToString()) ? false : true;

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => "";
    }
}
