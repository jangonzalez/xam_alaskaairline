using System;
using System.Globalization;
using MvvmCross.Converters;

namespace AlaskaAir.Core.Converters
{
    public class DateConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value.ToString("dd/MMM hh:mm tt");
            return date;
        }
    }
}
