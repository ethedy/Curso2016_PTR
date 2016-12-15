using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;

namespace OMB_Desktop.ViewModel
{
  public class EditorialAdminViewModel : ViewModelBase, IInteractionRequestAware
  {
    #region Propiedades Bindeables

    private string _nombre;

    public string Nombre
    {
      get { return _nombre; }
      set { Set(() => Nombre, ref _nombre, value); }
    }

    private string _direccion;

    public string Direccion
    {
      get { return _direccion; }
      set { Set(() => Direccion, ref _direccion, value); }
    }

    private string _logopath;

    public string RutaLogotipo
    {
      get { return _logopath; }
      set { Set(() => RutaLogotipo, ref _logopath, value); }
    }

    //private BitmapImage _logotipo;

    //public BitmapImage Logotipo
    //{
    //  get { return _logotipo; }
    //  set { Set(() => Logotipo, ref _logotipo, value); }
    //}

    private byte[] _logotipo;

    public byte[] Logotipo
    {
      get { return _logotipo; }
      set { Set(() => Logotipo, ref _logotipo, value); }
    }

    #endregion

    #region Comandos Bindeables

    public ICommand UploadImage { get; set; }

    public ICommand Guardar { get; set; }

    public ICommand Cancelar { get; set; }

    #endregion

    #region IInteractionRequestAware

    public INotification Notification { get; set; }

    public Action FinishInteraction { get; set; }

    #endregion

    public EditorialAdminViewModel()
    {
      if (IsInDesignModeStatic)
      {
        RutaLogotipo = "Ingresar una ruta...";
        //Logotipo = new BitmapImage(new Uri(@"F:\CURSO_2016_01\src\OMB\OMB_Desktop\Content\imagenes\Bart-Simpson-01-icon.png"));
        Logotipo =
          Helpers.PathToByteArray(@"F:\CURSO_2016_01\src\OMB\OMB_Desktop\Content\imagenes\Bart-Simpson-01-icon.png");
      }
      UploadImage = new RelayCommand(DoUploadImage, () => !string.IsNullOrWhiteSpace(RutaLogotipo));
    }

    private void DoUploadImage()
    {
      var temp = Helpers.PathToByteArray(RutaLogotipo);

      if (temp != null)
        Logotipo = temp;
    }
  }
}
