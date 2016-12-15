using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Entidades;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;
using Servicios;

namespace OMB_Desktop.ViewModels
{
  public class BookAdminViewModel : ViewModelBase
  {
    #region Propiedades Bindeables

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

    private byte[] _portada;

    public byte[] Portada
    {
      get { return _portada; }
      set { Set(() => Portada, ref _portada, value); }
    }

    #endregion

    #region Comandos Bindeables

    public ICommand UploadImage { get; set; }

    public ICommand NuevaEditorial { get; set; }

    #endregion

    #region Interacciones

    public InteractionRequest<IConfirmation> NuevaEditorialRequest { get; set; }

    #endregion


    public BookAdminViewModel()
    {
      if (IsInDesignModeStatic)
      {
        FechaPublicacion = DateTime.Now;
        FilePathImage = "Ingresar una ruta valida...";
        Portada = Helpers.PathToByteArray(@"F:\CURSO_2016_01\src\OMB\OMB_Desktop\Content\imagenes\Book 01.png");
      }
      else
      {
        ProductServices prod = new ProductServices();

        FechaPublicacion = DateTime.Now;

        var editoriales = prod.GetEditoriales();
        Editoriales = new List<Editorial>(editoriales);

        UploadImage = new RelayCommand(DoUploadImage, () => !string.IsNullOrWhiteSpace(FilePathImage));

        NuevaEditorialRequest = new InteractionRequest<IConfirmation>();

        NuevaEditorial = new RelayCommand(() => NuevaEditorialRequest.Raise(new Confirmation()
        {
          Title = "Nueva Editorial"          
        }, NuevaEditorialConfirmada));

        //  si tengo que editar un libro, no me queda otra que usar un Messenger

        //  no deberia tener un evento de salida para limpiar los campos??
      }
    }

    //  con la confirmacion podria saber si agregamos una nueva editorial o no...
    private void NuevaEditorialConfirmada(IConfirmation conf)
    {
      //
    }

    private void DoUploadImage()
    {
      var temp = Helpers.PathToByteArray(FilePathImage);

      if (temp != null)
        Portada = temp;
    }
  }
}
