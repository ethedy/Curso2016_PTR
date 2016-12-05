using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Entidades;
using Servicios;

namespace OMB_Desktop.ViewModels
{
  public class BookAdminViewModel : ViewModelBase
  {
    #region Binding Properties

    private string _isbn13;

    public string Isbn13
    {
      get { return _isbn13; }
      set { Set(() => Isbn13, ref _isbn13, value); }
    }

    private string _isbn10;

    public string Isbn10
    {
      get { return _isbn10; }
      set { Set(() => Isbn10, ref _isbn10, value); }
    }

    private string _titulo;

    public string Titulo
    {
      get { return _titulo; }
      set { Set(() => Titulo, ref _titulo, value); }
    }

    private string _subtitulo;

    public string Subtitulo
    {
      get { return _subtitulo; }
      set { Set(() => Subtitulo, ref _subtitulo, value); }
    }

    private DateTime _fechaPublicacion;

    public DateTime FechaPublicacion
    {
      get { return _fechaPublicacion; }
      set { Set(() => FechaPublicacion, ref _fechaPublicacion, value); }
    }

    private string _imagePath;

    public string FilePathImage
    {
      get { return _imagePath; }
      set { Set(() => FilePathImage, ref _imagePath, value); }
    }

    private List<Editorial> _editoriales;

    public List<Editorial> Editoriales 
    {
      get { return _editoriales; }
      set { Set(() => Editoriales, ref _editoriales, value); }
    }

    private Editorial _editorialSeleccionada;

    public Editorial EditorialSeleccionada
    {
      get { return _editorialSeleccionada; }
      set { Set(() => EditorialSeleccionada, ref _editorialSeleccionada, value); }
    }

    #endregion

    #region Binding Commands

    public ICommand GetImage { get; set; }

    #endregion

    public BookAdminViewModel()
    {
      if (IsInDesignModeStatic)
      {
        FechaPublicacion = DateTime.Now;
        FilePathImage = "Ingresar una ruta valida...";
      }
      else
      {
        ProductServices prod = new ProductServices();

        FechaPublicacion = DateTime.Now;

        Editoriales = new List<Editorial>(prod.GetEditoriales());

        GetImage = new RelayCommand(DoGetImage);
      }
    }

    private void DoGetImage()
    {
      string file = _imagePath;
    }
  }
}
