using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace OMB_Desktop.ViewModels
{
  public class BookAdminViewModel : ViewModelBase
  {
    private string _isbn13;
    private string _isbn10;
    private string _titulo;
    private string _subtitulo;

    private DateTime _fechaPublicacion;

    public DateTime FechaPublicacion
    {
      get { return _fechaPublicacion; }
      set { Set(() => FechaPublicacion, ref _fechaPublicacion, value); }
    }

    public BookAdminViewModel()
    {
      if (IsInDesignModeStatic)
      {
        FechaPublicacion = DateTime.Now;
      }
      FechaPublicacion = DateTime.Now;
    }
  }
}
