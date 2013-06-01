using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Picross_W8.Classes
{
    class IntToStringConverter : IValueConverter
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

    class IntToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Setting setting = new Setting();

            int intValue = (int)value;
            SolidColorBrush brush;

            if (intValue == 1)
                brush = setting.CellCorrectBackgroundColor;
            else if (intValue == 2)
                brush = setting.CellIncorrectBackgroundColor;
            else if (intValue == 3)
                brush = setting.CellHoverBackgroundColor;
            else
                brush = setting.CellBackgroundColor;

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Setting setting = new Setting();

            SolidColorBrush brushValue = value as SolidColorBrush;
            int intValue;

            if (brushValue == setting.CellCorrectBackgroundColor)
                intValue = 1;
            if (brushValue == setting.CellIncorrectBackgroundColor)
                intValue = 2;
            if (brushValue == setting.CellHoverBackgroundColor)
                intValue = 3;
            else
                intValue = 0;

            return intValue;
        }
    }
}
