using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace ServidorBot.src.View.Converter
{
    public class ItemIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DependencyObject depObj))
            {
                return null;
            }

            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(depObj);
            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(depObj);

            return index + 1; // Sumamos 1 para que el índice empiece en 1 en lugar de 0
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
