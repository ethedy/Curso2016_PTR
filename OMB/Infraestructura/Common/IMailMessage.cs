using System.Collections.Generic;

namespace Infraestructura.Common
{
  public interface IMailMessage
  {
    /// <summary>
    /// Puedo agregar uno, varios y ademas cada destinatario podria ser un grupo que tengo que convertir
    /// </summary>
    /// <param name="dest"></param>
    ICollection<string> Destinatarios { get; }

    /// <summary>
    /// Permite agregar partes del contenido de un mensaje
    /// </summary>
    ICollection<string> Contenido { get; }

    /// <summary>
    /// Permite incorporar adjuntos al mensaje
    /// Puede ser una Uri, un objeto en particular, etc...
    /// </summary>
    ICollection<object> Adjuntos { get; }
  }
}
