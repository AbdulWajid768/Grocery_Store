﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace ASSIGNMENT2_V1._0.Converters
{
    /// <summary>
    /// Handle the command which has 5 parameters
    /// </summary>
    class ConvertorForAddProduct : IMultiValueConverter
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

            if (values.Length >= 5)
            {
                object[] data = new object[5];
                data[0] = values[0].ToString();
                data[1] = values[1].ToString();
                data[2] = values[2].ToString();
                data[3] = values[3].ToString();
                data[4] = values[4] as Window;
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