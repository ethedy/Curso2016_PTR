using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMB_Desktop.Common
{
  public static class Helpers
  {
    public static byte[] PathToByteArray(string path)
    {
      if (File.Exists(path))
      {
        using (Bitmap imagen = new Bitmap(path))
        {
          System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();

          return (byte[])converter.ConvertTo(imagen, typeof(byte[]));
        }
      }
      else
      {
        return null;
      }
    }
  }
}
