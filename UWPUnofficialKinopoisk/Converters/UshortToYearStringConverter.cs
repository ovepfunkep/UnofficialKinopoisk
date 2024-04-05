using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Data;

namespace UWPUnofficialKinopoisk.Converters
{
    public class UshortToYearStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (ushort)value == 0 ? null : $"От {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ushort.TryParse(value.ToString(), out ushort year) == true ? year : 0;
        }
    }
}
