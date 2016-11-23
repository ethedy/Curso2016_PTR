﻿using System;
using Entidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OMB_Desktop.Common;
using Prism.Interactivity.InteractionRequest;
using System.Windows.Input;
using Infraestructura;
using Servicios;

namespace OMB_Desktop.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    public ICommand Login { get; set; }

    public ICommand Logout { get; set; }

    public ICommand NullCommand { get; set; }

    public ICommand Buscar { get; set; }

    private Usuario _usuario;

    public Usuario Usuario 
    {
      get { return _usuario; }
      set
      {
        Set(() => Usuario, ref _usuario, value);
      }
    }

    private string _status;

    public string Status
    {
      get { return _status; }
      set { Set(() => Status, ref _status, value); }
    }

    private string _buscar;

    public string TextoBuscar
    {
      get { return _buscar; }
      set { Set(() => TextoBuscar, ref _buscar, value); }
    }

    public void MostrarUsuario(OMBSesion sesion)
    {
      this.Usuario = sesion.Usuario;
    }

    /*
      InteractionRequest es la manera que tiene la ui de avisarnos que existe un pedido del
      usuario para por ejemplo mostrar unn dialogo
      En este caso el tipo T es INotification porque solamente sera un Aceptar

      Para cada interaccion tambien tenemos que poner un comando
  */

    public InteractionRequest<INotification> LoginRequest { get; set; }


    public MainWindowViewModel()
    {
      LoginRequest = new InteractionRequest<INotification>();

      Login = new RelayCommand(() => LoginRequest.Raise(new Notification()
        {
          Title = "Ingreso al sistema"
        }, LoginTerminado), () => true);

      Logout = new RelayCommand(() =>
      {
        SecurityServices serv = new SecurityServices(null);

        serv.Logout();

        Usuario = null;
      }, () => Usuario != null);

      NullCommand = new RelayCommand(() => { }, () => false );

      MessengerInstance.Register<OMBSesion>(this, MostrarUsuario);

      //  lo que tiene que hacer el comando es activar la interaction request...
      //if (IsInDesignMode)
      //{
      //  Usuario = new Usuario()
      //  {
      //    Empleado = new Empleado()
      //    {
      //      Persona = new Persona() { Nombres = "Enrique", Apellidos = "Thedy" }
      //    }
      //  };
      //}
    }

    /// <summary>
    /// Permite buscar o ejecutar un comando a partir de la barra de busqueda
    /// El comando se ejecuta si esta habilitado
    /// </summary>
    private void BuscarTexto()
    {

    }

    private void LoginTerminado(INotification notification)
    {
      Status = "Login OK";
    }
  }
}
