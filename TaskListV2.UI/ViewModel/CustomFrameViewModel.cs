using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskListV2.UI.Command;

namespace TaskListV2.UI.ViewModel
{
  public class CustomFrameViewModel : ViewModelBase
  {
    public ICommand CloseAppCommand { get { return new CloseAppCommand(); } }

    private bool isClosed = false;

    public bool IsClosed
    {
      set
      {
        isClosed = value;
        OnPropertyChanged();
        if(isClosed) Application.Current.Shutdown();
      }
    }

  }
}
