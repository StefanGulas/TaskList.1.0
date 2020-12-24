using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TaskListV2.UI.ViewModel
{
  public class CustomFrameViewModel : ViewModelBase
  {
    
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
