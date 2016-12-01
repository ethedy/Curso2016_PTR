using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Common;

namespace Infraestructura
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
