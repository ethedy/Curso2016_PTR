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
using GalaSoft.MvvmLight.Command;
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
      set
      {
        Set(() => LoginID, ref _userid, value); 
      }
    }

    public RelayCommand<string> LoginCommand { get; set; }

    public INotification Notification { get; set; }

    public Action FinishInteraction { get; set; }

    public LoginViewModel()
    {
      //  LoginID = "---";
      //
      //  bindeamos comandos
      LoginCommand = new RelayCommand<string>(DoLogin);
    }

    public void DoLogin(string pass)
    {
      SecurityServices seg = new SecurityServices();

      if (pass != null)
      {
        Console.WriteLine(pass);
        Usuario user = seg.LoginUsuario(LoginID, pass);
        if (user != null)
        {
          MessengerInstance.Send<Usuario>(user);
          MessengerInstance.Send<LoginMessage>(new LoginMessage() { Show = false });
        }
      }
    }
  }
}
