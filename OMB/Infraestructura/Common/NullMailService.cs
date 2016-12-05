using System;

namespace Infraestructura.Common
{
  public class NullMailService : IMailService
  {
    public IMailMessage NuevoMensaje()
    {
      throw new NotImplementedException();
    }

    public void Send(IMailMessage msj)
    {
      throw new NotImplementedException();
    }
  }
}
