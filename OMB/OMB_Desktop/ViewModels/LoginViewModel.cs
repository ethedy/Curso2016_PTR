using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entidades;
using OMB_Desktop.Common;
using Servicios;

namespace OMB_Desktop.ViewModels
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private string _userid;

    public string LoginID
    {
      get { return _userid; }
      set
      {
        _userid = value;
        OnPropertyChanged(nameof(LoginID));
      }
    }

    public ICommand LoginCommand { get; set; }

    public LoginViewModel()
    {
      LoginID = "---";
      //
      //  bindeamos comandos
      LoginCommand = new OMBCommand(DoLogin, null);
    }

    public void DoLogin(object param)
    {
      SecurityServices seg = new SecurityServices();

      Usuario user = seg.LoginUsuario(LoginID, (string)param);
      if (user != null)
      {
        Messenger.Default.Send<Usuario>(user);
        Messenger.Default.Send<LoginMessage>(new LoginMessage() { Show = false });
      }
    }

    private void OnPropertyChanged(string property)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

      // if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
  }
}
