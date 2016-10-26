using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  /// <summary>
  /// TODO agregar autores (M-N)
  /// Agregar ediciones (primera, segunda...)
  /// Agregar tipo de edicion disponible (ebook, tapa dura...)
  /// Agregar idioma
  /// </summary>
  public class Libro
  {
    public Guid IDLibro { get; set; }
    public string ISBN { get; set; }
    public string ISBN10 { get; set; }
    public string Titulo { get; set; }
    public string Subtitulo { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public int? Paginas { get; set; }

    /// <summary>
    /// Colocariamos datos que tienen que ver con el shipping del libro, por ejemplo peso y dimensiones
    /// </summary>
    public string DatosEnvio { get; set; }
    public byte[] Portada { get; set; }

    public virtual Editorial Editorial { get; set; }

    public Libro()
    {
      IDLibro = Guid.NewGuid();
    }
  }
}
