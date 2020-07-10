using Safaksayar.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Safaksayar.Converters
{
   
        public class DisplayedNumberConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            try
            {

                return value;
            }
                catch
                {
                    return value;
                }
}

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
            try
            {
                var a = value as ComboObject;
                return a.sayisi;
            }
            catch (Exception)
            {

                return value;
            }
            
        }
        }

    }

