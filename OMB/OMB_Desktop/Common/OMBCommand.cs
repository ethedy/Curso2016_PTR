using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OMB_Desktop.Common
{
  public class OMBCommand : ICommand
  {
    private Action<object> _execute;
    private Predicate<object> _canExecute;

    public OMBCommand(Action<object> execute, Predicate<object> canExecute)
    {
      _execute = execute;
      _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute == null ? true: _canExecute(parameter);
    }

    public void Execute(object parameter)
    {
      _execute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value;  }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }
}
