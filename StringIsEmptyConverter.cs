using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RecipeApplicationWPF.Converters
{
    public class StringIsEmptyConverter : IValueConverter // Convert a string to a boolean
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue)// If the value is a boolean and is true
                return Visibility.Visible;// Return visible
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)// Convert back
        {
            throw new NotImplementedException();
        }
    }
}
