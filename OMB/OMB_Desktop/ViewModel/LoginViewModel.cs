using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Infraestructura;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;
using Servicios;

namespace OMB_Desktop.ViewModel
{
  public class LoginViewModel : ViewModelBase, IInteractionRequestAware
  {
    private string _userid;

    public string LoginID
    {
      get { return _userid; }
      set { Set(() => LoginID, ref _userid, value); }
    }

    private string _pass;

    public string Password
    {
      get { return _pass; }
      set { Set(() => Password, ref _pass, value); }
    }

    public InteractionRequest<INotification> FaltanDatos { get; set; }

    public InteractionRequest<INotification> CredencialesInvalidas { get; set; }

    public ICommand LoginCommand { get; set; }

    public ICommand ClearLoginData { get; set; }

    public ICommand RecuperarContraseña { get; set; }

    public INotification Notification { get; set; }

    public Action FinishInteraction { get; set; }

    public LoginViewModel()
    {
      //  LoginID = "---";
      //
      //  bindeamos comandos
      LoginCommand = new RelayCommand(DoLogin);

      RecuperarContraseña = new RelayCommand(DoRecuperarContraseña);

      ClearLoginData = new RelayCommand(() =>
      {
        LoginID = null;
        Password = null;
      });

      FaltanDatos = new InteractionRequest<INotification>();
      CredencialesInvalidas = new InteractionRequest<INotification>();
    }

    public void DoLogin()
    {
      SecurityServices seg = new SecurityServices();

      if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(LoginID))
      {
        Console.WriteLine(Password);

        if (seg.Login(LoginID, Password))
        {
          //  OMBSesion sesion = new OMBSesion(user);

          //  MessengerInstance.Send<OMBSesion>(sesion);
          if (FinishInteraction != null)
            FinishInteraction();
          
          //MessengerInstance.Send<LoginMessage>(new LoginMessage() { Show = false });
        }
        else
        {
          CredencialesInvalidas.Raise(new Notification()
          {
            Title = "ERROR INGRESO",
            Content = seg.ErrorInfo
          });
        }
      }
      else
      {
        FaltanDatos.Raise(new Notification()
        {
          Title = "ERROR INGRESO",
          Content = "Debe especificarse un usuario y contraseña"
        });
      }
    }

    public void DoRecuperarContraseña()
    {
      SecurityServices seg = new SecurityServices();

      seg.RecuperarContraseña();
    }
  }
}
