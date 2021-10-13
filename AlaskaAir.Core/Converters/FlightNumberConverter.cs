using System;
using System.Globalization;
using MvvmCross.Converters;

namespace AlaskaAir.Core.Converters
{
    public class FlightNumberConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var flightNumber = $"Flight #{value}";
            return flightNumber;
        }
    }
}
