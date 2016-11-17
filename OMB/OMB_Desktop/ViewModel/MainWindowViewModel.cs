using System;
using Entidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;
using System.Windows.Input;
using Infraestructura;
using Servicios;

namespace OMB_Desktop.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    public ICommand Login { get; set; }

    public ICommand Logout { get; set; }

    private Usuario _usuario;

    public Usuario Usuario 
    {
      get { return _usuario; }
      set
      {
        Set(() => Usuario, ref _usuario, value);
      }
    }

    private string _status;

    public string Status
    {
      get { return _status; }
      set { Set(() => Status, ref _status, value); }
    }

    public void MostrarUsuario(OMBSesion sesion)
    {
      this.Usuario = sesion.Usuario;
    }

    /*
      InteractionRequest es la manera que tiene la ui de avisarnos que existe un pedido del
      usuario para por ejemplo mostrar unn dialogo
      En este caso el tipo T es INotification porque solamente sera un Aceptar

      Para cada interaccion tambien tenemos que poner un comando
  */

    public InteractionRequest<INotification> LoginRequest { get; set; }


    public MainWindowViewModel()
    {
      LoginRequest = new InteractionRequest<INotification>();
      Login = new RelayCommand(() => LoginRequest.Raise(new Notification()
        {
          Title = "Ingreso al sistema",
          Content = "oioi"
        }, LoginTerminado), () => true);

      Logout = new RelayCommand(() =>
      {
        SecurityServices serv = new SecurityServices();

        serv.Logout();

        Usuario = null;
      }, () => Usuario != null);

      MessengerInstance.Register<OMBSesion>(this, MostrarUsuario);

      //  lo que tiene que hacer el comando es activar la interaction request...
      //if (IsInDesignMode)
      //{
      //  Usuario = new Usuario()
      //  {
      //    Empleado = new Empleado()
      //    {
      //      Persona = new Persona() { Nombres = "Enrique", Apellidos = "Thedy" }
      //    }
      //  };
      //}
    }

    private void LoginTerminado(INotification notification)
    {
      Status = "Login OK";
    }
  }
}
