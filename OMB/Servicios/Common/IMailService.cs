using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Common
{
  /// <summary>
  /// Permite abstraer el comportamiento de casi cualquier servicio de envio de correos
  /// </summary>
  public interface IMailService
  {
    /// <summary>
    /// Crea un mensaje en blanco para que el cliente lo complete con los datos necesarios y 
    /// lo pueda enviar
    /// </summary>
    /// <returns></returns>
    IMailMessage NuevoMensaje();

    /// <summary>
    /// Envia el mensaje a los destinatarios ingresados 
    /// </summary>
    void Send(IMailMessage msj);
  }
}
