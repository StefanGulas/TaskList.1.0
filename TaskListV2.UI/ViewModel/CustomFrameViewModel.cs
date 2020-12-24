using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskListV2.UI.Command;

namespace TaskListV2.UI.ViewModel
{
  public class CustomFrameViewModel : ViewModelBase, ICustomFrameViewModel
  {
    public ICommand CloseAppCommand { get { return new CloseAppCommand(); } }
    //public ICommand ChangeModeCommand

  }
}
