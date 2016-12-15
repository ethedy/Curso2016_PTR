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

    #region Propiedades Bindeables

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

    #endregion

    #region Comandos Bindeables

    public ICommand Aceptar { get; set; }

    public ICommand Cancelar { get; set; }

    public ICommand LoadedBehavior { get; set; }

    #endregion

    #region IInteractionRequestAware

    public INotification Notification { get; set; }

    public Action FinishInteraction { get; set; }

    #endregion

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

      Aceptar = new RelayCommand(() =>
      {
        if (_inputConfirmation.Validator(Input))
        {
          _inputConfirmation.Confirmed = true;
          FinishInteraction();
        }
        //  aca podriamos marcar con un error visual en la UI...obviamente con la interface requerida...
      });

      Cancelar = new RelayCommand(() =>
      {
        _inputConfirmation.Confirmed = false;
        FinishInteraction();
      });
    }
  }
}
