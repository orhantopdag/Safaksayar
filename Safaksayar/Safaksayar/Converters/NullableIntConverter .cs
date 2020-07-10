﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Safaksayar.Converters
{
  public  class NullableIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullable = value as int?;
            var result = string.Empty;

            if (nullable.HasValue)
            {
                result = nullable.Value.ToString();
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            int intValue;
            int? result = null;

            if (int.TryParse(stringValue, out intValue))
            {
                result = new Nullable<int>(intValue);
            }
            if (intValue>100)
            {
                result = 99;
            }
            return result;
        }
    }
}
