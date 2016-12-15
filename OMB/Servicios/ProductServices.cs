using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entidades;

namespace Servicios
{
  /// <summary>
  /// Agrupamos todos los servicios relacionados con Productos: Libros, Categorias, Autores, etc...
  /// </summary>
  public class ProductServices
  {
    /// <summary>
    /// Este es el caso en que una editorial nos dice que va a publicar un libro nuevo...
    /// O bien el libro ya esta editado pero vamos a realizar una compra para incorporarlo en el stock...
    /// </summary>
    /// <returns></returns>
    public Libro NuevoLibro(Editorial editor, string titulo, string isbn, string isbn10, string portada, DateTime fechaPublicacion, int paginas)
    {
      Libro nuevoLibro = new Libro()
      {
        Titulo = titulo,
        ISBN = isbn,
        ISBN10 = isbn10,
        FechaPublicacion = fechaPublicacion,
        Paginas = paginas,
        Editorial = editor
      };

      //  obtenemos la imagen de la portada...
      if (portada != null)
      {
        ImageConverter converter = new ImageConverter();
        Bitmap imagen = new Bitmap(portada);

        nuevoLibro.Portada = (byte[]) converter.ConvertTo(imagen, typeof(byte[]));
      }
      try
      {
        OMBContext ctx = OMBContext.DB;

        ctx.Libros.Add(nuevoLibro);
        ctx.SaveChanges();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Problemas ingresando el nuevo libro");
        Console.WriteLine(ex.ToString());
        nuevoLibro = null;
      }
      return nuevoLibro;
    }

    public Editorial NuevaEditorial(string nombre, string direccion, string logotipo)
    {
      return null;
    }

    public IEnumerable<Editorial> GetEditoriales()
    {
      return OMBContext.DB.Editoriales;
    }
  }
}
