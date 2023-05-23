using Discord;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ServidorBot.src.View.Converter
{
    public class UserImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not IUser user)
            {
                return null;
            }

            try
            {
                var url = user.GetAvatarUrl(ImageFormat.Auto, 128);
                if (url != null)
                {
                    var bitmap = new BitmapImage(new Uri(url));
                    return new ImageBrush(bitmap);
                }
            }
            catch (Exception)
            {
                // Ignore any exceptions and use the default image instead
            }

            var defaultImage = new BitmapImage(new Uri("../../../src/View/img/IconUser.png", UriKind.Relative));
            return new ImageBrush(defaultImage);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
