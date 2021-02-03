using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ASSIGNMENT2_V1._0.Converters
{
    /// <summary>
    /// Handle the command which has 2 parameters
    /// </summary>
    class ConverterForMainWindow : IMultiValueConverter
    {
        /// <summary>
        /// Convert Parameters in required format
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (values.Length >= 2)
            {
                object[] data = new object[2];
                data[0] = values[0].ToString();
                data[1] = values[1] as Window;
                return data;
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}