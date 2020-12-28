using System.Windows.Input;

namespace TaskListV2.UI.ViewModel
{
  public interface ICustomFrameViewModel
  {
    ICommand CloseAppCommand { get; }
    public static int RadioButtonDB { get; }
  }
}