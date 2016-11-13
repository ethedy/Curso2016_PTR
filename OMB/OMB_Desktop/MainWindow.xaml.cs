﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entidades;
using OMB_Desktop.Common;
using OMB_Desktop.ViewModels;
using OMB_Desktop.Views;

namespace OMB_Desktop
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      __Messenger.Default.Register<LoginMessage>(this, msg =>
      {
        if (msg.Show)
          mainContent.Content = new LoginView();
        else
        {
          mainContent.Content = null;
        }
      });
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
      //this.DataContext = new MainWindowViewModel();
    }
  }
}
