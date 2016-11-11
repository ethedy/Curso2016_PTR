using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Infraestructura
{
  /// <summary>
  /// Simplemente se llama OMBSesion para que no se confunda en MVC pero deberia ser Sesion
  /// Mantiene durante el transcurso de la aplicacion toda la informacion necesaria asociada con el usuario conectado
  /// </summary>
  public class OMBSesion
  {
    public Usuario UsuarioConectado { get; private set; }

    public Perfil Perfil { get; private set; }

    public string FullName
    {
      get
      {
        return string.Format($"{UsuarioConectado .Empleado.Persona.Nombres} {UsuarioConectado.Empleado.Persona.Apellidos}");
      }
    }

    public DateTime? FechaExpiracion
    {
      get { return UsuarioConectado.PasswordExpiration ; }
    }

    public OMBSesion(Usuario usr)
    {
      UsuarioConectado = usr;
      //  TODO null object!!
      Perfil = null;
    }

    public OMBSesion(Usuario usr, Perfil perfil)
    {
      UsuarioConectado = usr;
      Perfil = perfil;
    }

    public void Logout()
    {
      UsuarioConectado = null;
      Perfil = null;
    }
  }
}
