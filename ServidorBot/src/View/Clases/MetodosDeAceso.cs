using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ServidorBot.src.View.Clases
{
    public class MetodosDeAceso
    {
        public static Color StringToColor(string colorStr)
        {
            TypeConverter cc = TypeDescriptor.GetConverter(typeof(Color));
            Color result = (Color)cc.ConvertFromString(colorStr);
            return result;
        }

        public static string FormatTimeSpan(TimeSpan timeSpan)
        {
            string daysString = timeSpan.Days > 0 ? $"d: {timeSpan.Days}, " : "";
            string timeString = timeSpan.ToString(@"h\:m\:s");

            return $"{daysString}{timeString}";
        }

        public static SolidColorBrush HexToSolidColorBrush(string hex)
        {
            Color color = (System.Windows.Media.Color)ColorConverter.ConvertFromString(hex);
            return new SolidColorBrush(color);
        }

        public static ImageBrush GetImageBrushFromUrl(string imageUrl)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imageUrl));
                return new ImageBrush(bitmapImage);
            }
            catch
            {
                return null;
            }
        }

        public static ImageBrush GetImageLocal(string url)
        {
            // Create an ImageBrush.
            return new ImageBrush()
            {
                ImageSource =
                new BitmapImage(
                    new Uri(url, UriKind.Relative)
                ),
                AlignmentX = AlignmentX.Left,
                Stretch = Stretch.None
            };
        }

    }
}
