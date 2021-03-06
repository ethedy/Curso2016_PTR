/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:OMB_Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OMB_Desktop.Common;
using OMB_Desktop.ViewModels;

namespace OMB_Desktop.ViewModel
{
  /// <summary>
  /// This class contains static references to all the view models in the
  /// application and provides an entry point for the bindings.
  /// </summary>
  public class ViewModelLocator
  {
    /// <summary>
    /// Initializes a new instance of the ViewModelLocator class.
    /// </summary>
    public ViewModelLocator()
    {
      if (ViewModelBase.IsInDesignModeStatic)
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      ////if (ViewModelBase.IsInDesignModeStatic)
      ////{
      ////    // Create design time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
      ////}
      ////else
      ////{
      ////    // Create run time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DataService>();
      ////}

      SimpleIoc.Default.Register<MainWindowViewModel>();
      SimpleIoc.Default.Register<LoginViewModel>();
      SimpleIoc.Default.Register<InputConfirmationViewModel>();
      SimpleIoc.Default.Register<BookAdminViewModel>();
      SimpleIoc.Default.Register<EditorialAdminViewModel>();
    }

    public MainWindowViewModel Main
    {
      get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
    }

    public LoginViewModel Login
    {
      get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); }
    }

    public InputConfirmationViewModel InputConfirmation
    {
      get { return ServiceLocator.Current.GetInstance<InputConfirmationViewModel>(); }
    }

    public BookAdminViewModel BookAdmin
    {
      get { return ServiceLocator.Current.GetInstance<BookAdminViewModel>(); }
    }

    public EditorialAdminViewModel EditorialAdmin
    {
      get { return ServiceLocator.Current.GetInstance<EditorialAdminViewModel>(); }
    }
    public static void Cleanup()
    {
      // TODO Clear the ViewModels
    }
  }
}