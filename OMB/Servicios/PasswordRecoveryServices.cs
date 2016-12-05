using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
  /// <summary>
  /// Observar que lo sacamos de Security porque la clase se estaba haciendo demasiado grande
  /// </summary>
  public class PasswordRecoveryServices
  {
    public PasswordRecoveryServices()
    {
      MensajeUsuario = "Para recuperar la contraseña, debera ingresar la direccion de correo con que esta registrado, o bien proporcionar la identificacion de empleado o su nombre y apellido";
    }

    public string MensajeUsuario { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Aca ya estamos dentro de las reglas de negocio...podemos decidir que es lo correcto y que no!!
    /// </remarks>
    /// <param name="toValidate"></param>
    /// <returns></returns>
    public bool ValidatePasswordRecoveryInfo(string toValidate)
    {
      return true;
    }

    //  posiblemente podriamos tener un contador de veces que recupero la pass (en Usuario)
    //  en tal caso, avisar al administrador
    //  buscar dato, si lo encuentra lo cambio, si no no ... retornar siempre mimso mensaje
    //  
    public void RecuperarContraseña()
    {
    //  //  generar una nueva password, con una expiracion de 30 minutos
    //  HttpClient mailApi = new HttpClient();
    //  MailDefinition mailMsj = new MailDefinition();

    //  mailApi.DefaultRequestHeaders.Add("Accept", "text/plain");
    //  //  mailApi.DefaultRequestHeaders.Add("Accept", "application/json");
    //  //  mailApi.DefaultRequestHeaders.Add("Accept", "text/xml");

    //  mailMsj.From = "OMB Security";
    //  mailMsj.To.Add("ethedy@gmail.com");
    //  mailMsj.Subject = "Usted olvido otra vez su password!!";
    //  mailMsj.Body = "Su password temporal para ingresar al sistema es ...";

    //  HttpContent contenido = new StringContent(JsonConvert.SerializeObject(mailMsj));
    //  contenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");

    //  Uri senderApi = new Uri(string.Format("?token={0}", "123456789"));

    //  HttpResponseMessage response = mailApi.PostAsync(senderApi, contenido).Result;

    //  mailApi.Dispose();
    }
  }
}
