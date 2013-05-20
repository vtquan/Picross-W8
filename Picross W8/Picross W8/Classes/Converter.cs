using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Picross_W8.Classes
{
    class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int intValue = (int)value;
            return intValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            int intValue;
            if (Int32.TryParse(strValue, out intValue))
            {
                return intValue;
            }
            throw new Exception("Unable to convert string to int");
        }
    }
}
