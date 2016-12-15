using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OMB_Desktop.Common
{
  /// <summary>
  /// Permite convertir una imagen guardada como byte[] en una imagen aceptable para un control Image
  /// o sea un BitmapImage
  /// </summary>
  public class ImageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      //  tratamos de convertir entre byte[] a BitmapImage
      if (value is byte[])
      {
        BitmapImage bimg = new BitmapImage();
        MemoryStream mmstr = new MemoryStream(value as byte[]);

        bimg.BeginInit();
        bimg.StreamSource = mmstr;
        bimg.EndInit();

        return bimg;
      }
      return null;
      //  throw new ApplicationException("No se puede convertir otra cosa que byte[]...");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
