using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entidades;
using OMB_Desktop.Common;

namespace OMB_Desktop.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    public ICommand LoginShow { get; set; }

    private Usuario _usuario;

    public event PropertyChangedEventHandler PropertyChanged;

    public Usuario Usuario 
    {
      get { return _usuario; }
      set
      {
        _usuario = value;
        OnPropertyChanged(nameof(Usuario));
      }
    }

    public void MostrarUsuario(Usuario usr)
    {
      this.Usuario = usr;
    }


    public MainWindowViewModel()
    {
      LoginShow = new OMBCommand((param) =>
      {
        Messenger.Default.Send<LoginMessage>(new LoginMessage() {Show = true});
      }, (o) => true);

      Messenger.Default.Register<Usuario>(this, MostrarUsuario);
    }

    private void OnPropertyChanged(string property)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

      // if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
  }
}
