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
        OnPropertyChanged("LoginID");
      }
    }

    public ICommand LoginCommand { get; set; }

    public LoginViewModel()
    {
      LoginID = "ethedy";
      //
      //  bindeamos comandos
      LoginCommand = new OMBCommand((param) =>
      {
        SecurityServices seg = new SecurityServices();

        Usuario user = seg.LoginUsuario(LoginID, (string) param);
        Messenger.Default.Send<Usuario>(user);

      }, null);
    }

    private void OnPropertyChanged(string property)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
  }
}
