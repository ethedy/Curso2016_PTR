using System;
using Entidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;
using System.Windows.Input;

namespace OMB_Desktop.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    public ICommand LoginCommand { get; set; }

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

    public void MostrarUsuario(Usuario usr)
    {
      this.Usuario = usr;
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
      LoginCommand = new RelayCommand(() => LoginRequest.Raise(new Notification()
        {
          Title = "Ingreso al sistema",
          Content = "oioi"
        }, LoginTerminado), () => true);

      MessengerInstance.Register<Usuario>(this, MostrarUsuario);

      //  lo que tiene que hacer el comando es activar la interaction request...
    }

    private void LoginTerminado(INotification notification)
    {
      Status = "FINALIZADO";
    }
  }
}
