using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ShoesStore_WPF.Converter
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value;
            ExistingShoes newtmp = (ExistingShoes)value;
            var uri = new Uri(string.Format("C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Status\\{0}.png", newtmp.IsSelected), UriKind.Absolute);
            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
