using System;
using Infraestructura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMB_Desktop.Common;
using OMB_Desktop.ViewModel;

namespace OMB_Tests.Test.ViewModels
{
  [TestClass]
  public class LoginViewModelFixture
  {
    /// <summary>
    /// Tenemos que probar que ante usuario y/o password en blanco se lanza la ventana de faltan datos
    /// </summary>
    [TestMethod]
    public void UserEmptyCantLogin()
    {
      LoginViewModel lvm = new LoginViewModel();
      bool raised = false;

      lvm.LoginID = "";
      lvm.Password = "123456";
      lvm.FaltanDatos.Raised += (sender, args) =>
      {
        raised = true;
      };
      lvm.LoginCommand.Execute(null);
      Assert.IsTrue(raised);
    }

    [TestMethod]
    public void PasswordEmptyCantLogin()
    {
      LoginViewModel lvm = new LoginViewModel();
      bool raised = false;

      lvm.LoginID = "ethedy";
      lvm.Password = "";
      lvm.FaltanDatos.Raised += (sender, args) =>
      {
        raised = true;
      };
      lvm.LoginCommand.Execute(null);
      Assert.IsTrue(raised);
    }

    [TestMethod]
    public void UserPasswordCorrectas_OK()
    {
      LoginViewModel lvm = new LoginViewModel();

      lvm.LoginID = "ethedy";
      lvm.Password = "12345678";

      lvm.LoginCommand.Execute(null);

      Assert.IsNotNull(OMBSesion.Current);
      Assert.AreEqual("Thedy", OMBSesion.Current.Usuario.Empleado.Persona.Apellidos);
    }

    [TestMethod]
    public void PasswordOlvidadaMedianteEmailIncorrecto_BAD()
    {
      LoginViewModel lvm = new LoginViewModel();
      bool validar = true;
      string input = "no_es_email";

      lvm.RecuperarPassword.Raised += (sender, args) =>
      {
        //  imaginemos que estamos dentro del view model donde decimos si buscar email, empleado, etc...
        InputConfirmation ic = args.Context as InputConfirmation;

        if (ic != null)
        {
          validar = ic.Validator(input);
        }
      };
      lvm.RecoverPassCommand.Execute(null);
      Assert.IsFalse(validar, string.Format("El mail ingresado {0} es incorrecto. El test retorna que es correcto", input));
    }
  }
}
