using System.Windows.Input;
using TaskListV2.UI.Command;

namespace TaskListV2.UI.ViewModel
{
  public class CustomFrameViewModel : ViewModelBase, ICustomFrameViewModel
  {
    public ICommand CloseAppCommand { get { return new CloseAppCommand(); } }


  }
}
