using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OMB_Desktop.Common;

namespace OMB_Desktop.ViewModels
{
  public class MainWindowViewModel
  {
    public ICommand LoginShow { get; set; }

    public MainWindowViewModel()
    {
      LoginShow = new OMBCommand((param) =>
      {
        Messenger.Default.Send<LoginMessage>(new LoginMessage() {Show = true});
      }, null);
    }
  }
}
