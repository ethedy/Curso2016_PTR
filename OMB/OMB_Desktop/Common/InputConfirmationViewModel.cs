using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Prism.Interactivity.InteractionRequest;

namespace OMB_Desktop.Common
{
  public class InputConfirmationViewModel : ViewModelBase, IInteractionRequestAware
  {
    private InputConfirmation _inputConfirmation;

    private string _descripcion;

    public string Descripcion
    {
      get { return _descripcion; }
      set { Set(() => Descripcion, ref _descripcion, value); }
    }

    private string _inputText;

    public string Input
    {
      get { return _inputText; }
      set { Set(() => Input, ref _inputText, value); }
    }

    public ICommand AceptarCommand { get; set; }

    public ICommand CancelarCommand { get; set; }

    public ICommand LoadedBehavior { get; set; }

    public INotification Notification { get; set; }

    public Action FinishInteraction { get; set; }

    public InputConfirmationViewModel()
    {
      if (ViewModelBase.IsInDesignModeStatic)
      {
        Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam laoreet odio hendrerit, sagittis enim non, molestie urna. Sed vitae nisi varius, mattis neque quis, auctor augue. Donec sit amet neque";
      }

      LoadedBehavior = new RelayCommand(() =>
      {
        _inputConfirmation = Notification as InputConfirmation;

        if (_inputConfirmation != null)
        {
          Descripcion = _inputConfirmation.Descripcion;
        }
      });

      AceptarCommand = new RelayCommand(() =>
      {
        _inputConfirmation.Confirmed = true;
        FinishInteraction();
      });

      CancelarCommand = new RelayCommand(() =>
      {
        _inputConfirmation.Confirmed = false;
        FinishInteraction();
      });
    }
  }
}
